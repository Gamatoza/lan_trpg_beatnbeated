using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatNBeated
{
    public partial class Game : Form
    {

        #region ClientRegion
        
        static string userName = "Gay";
        private string host = "127.0.0.1";
        private int port = 8888;
        static TcpClient client;
        static NetworkStream stream;

        public Game(string Name, string Adress, int Port, Form parent)
        {
            InitializeComponent();
            client = new TcpClient();
            userName = Name;
            host = Adress;//добавить проверку по регексу
            port = Port;//добавить проверку по числу
            Thread receiveThread = null;
            try
            {
                client.Connect(host, port); //подключение клиента
                stream = client.GetStream(); // получаем поток

                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                // запускаем новый поток для получения данных
                receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start(); //старт потока
                txtGame.Text += "Welcome to Beat N Beated " + userName + "!\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if(receiveThread!=null)
                receiveThread.Abort();
                Disconnect();
            }
            HP = 100;
            ATK = 10;
            timer.Interval = 500;

            gpOpponent.Visible = false;
        }

        void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    //signals
                    if (message[0] == '/')
                    {
                        
                        //if(message[1] != 'o')
                        //MessageBox.Show(message);

                        if (inOnlineBattle)
                        {
                            try
                            {
                                if(message[1] == 'q') //????? update opponent stats
                                {
                                    string[] parts = message.Split(';');
                                    opHP = int.Parse(parts[1]);
                                }
                                else
                                if(message[1] == 'a') //attacked
                                {
                                    string[] parts = message.Split(';');
                                    HP -= int.Parse(parts[1]);
                                    if (hp <= 0)
                                    {
                                        Ping("l;");
                                        inOnlineBattle = false;
                                        ChangeMode(GameMode.Peace);
                                        HP = 10;
                                        txtGame.Text += "you lose!\n";
                                    }
                                    else Ping("q;");
                                }
                                if (message[1] == 'l') //opponent leaved or battle ended
                                {
                                    Ping("l;");
                                    inOnlineBattle = false;
                                    ChangeMode(GameMode.Peace);
                                    txtGame.Text += "you win!" + "\n";
                                }
                            }
                            catch (Exception ex)
                            {
                                Ping("l;");
                                inOnlineBattle = false;
                                ChangeMode(GameMode.Peace);
                                txtGame.Text += "something wrong happend\n" + ex.Message + "\n";
                            }
                        }

                        //online stat update
                        if (message[1] == 'o')
                        {
                            string[] parts = message.Split(';');
                            lbOnline.Text = "Online: " + parts[1]; //перенести в signals
                        }

                        if (message[1] == 'n') //not accepted
                        {
                            txtGame.Text += "but nothing happens..." + "\n";
                            inOnlineBattle = false;
                        }
                        else if (message[1] == 'f') //fight
                        {
                            //MessageBox.Show(message);
                            inOnlineBattle = true;
                            ChangeMode(GameMode.Battle);
                            string[] parts = message.Split(';');
                            opNAME = parts[1];
                            opHP = int.Parse(parts[2]);
                            opATK = int.Parse(parts[3]);
                            //[1] username [2] hp [3] atk
                        }
                        else if(message[1] == 'u') //update stats
                        {
                            string[] parts = message.Split(';');
                            hp = int.Parse(parts[1]);
                            atk = int.Parse(parts[2]);
                            if (hp <= 0)
                            {
                                MessageBox.Show("You dead!");
                                Ping("l;");
                                Disconnect();
                            }
                        }
                        //w - win l - loose?
                        else
                        {
                            //txtGame.Text += "error:" + message + "\n";
                        }
                    }
                    //maybe add bool isWaiting for ping("f");
                    else
                    {
                        txtGame.Text += message + "\n";//вывод сообщения
                    }

                }
                catch (Exception ex)
                {
                    //соединение было прервано
                    MessageBox.Show(ex.Message + "\n" + "lol");
                    Disconnect();
                }
            }
        }

        void Disconnect()
        {

            if (inOnlineBattle)
            {
                Ping("l");
            }

            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's me, Mario!");
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                //inBattle and inOnlineBattle !!!!!!!
                if(txtMessage.Text[0] != '/')
                {
                    SendMessage(txtMessage.Text);
                }
                else { 
                    MessageBox.Show("/ can't be used by first letter in message, youse [space] instead id if you want");
                }
                    txtMessage.Text = "";
            }
        }

        void SendMessage(string msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            stream.Write(data, 0, data.Length);
            
            txtGame.Text += userName + ": " + txtMessage.Text + '\n';
        }

        #endregion

        #region GameRegion

        #region Params

        string buffer;

        int hp;
        int atk;

        int opponenthp;
        int opponentatk;
        string opname;

        int HP { get { return hp; } set { hp = value; lbHP.Text = hp.ToString(); } }
        int ATK { get { return atk; } set {  atk = value; lbATK.Text = atk.ToString(); } }
        
        
        int opHP { get { return opponenthp; } set { opponenthp = value; lbOpHP.Text = opponenthp.ToString(); } }
        int opATK { get { return opponentatk; } set { opponentatk = value; lbOpATK.Text = opponentatk.ToString(); } }
        

        string opNAME { get { return opname; } set { opname = value; lbName.Text = opname; } }

        public enum GameEvents
        {//L - Loose ; A - Add
            LHP,
            LATK,
            AHP,
            AATK,
            MobFight,
            PVP,
            AItem,
            LItem,
        }

        List<string> Enemies = new List<string>()
        {
            "Goblin;20;3","Bat;10;1"
        };

        List<string> items = new List<string>()
        {

        };

        Random rand = new Random();

        List<string> First = new List<string>()
        {
            "thinking about something bad","praying to the Buddha",
            "praying to the Allah","praying to the Your Cat",
            "praying to the your wife", "praying to the GreatRandom"
        };

        List<string> Second = new List<string>()
        {
            "turning badly", "choking on a piece of bread", 
            "choking on a sweet candy","reaching for the sky", 
            "reaching for the sky","turning 180 degrees",
            "turning 666 degrees", "turning 228 degrees", "turning 1488 degrees",
            "after finishing your soda"
        };

        

        #endregion

        string GenerateItem()
        {
            string[] f = { "some", "dark", "light", "mysterious", "", "eeew", "idk" };
            string[] s = { "stuf", "sword", "shield", "cat", "banana", "code?" };
            return String.Format("{0} {1}", f[rand.Next(f.Length)], s[rand.Next(s.Length)]);
        }

        enum GameMode
        {
            Peace = 0,
            Battle
        }

        bool inBattle = false;
        bool inOnlineBattle = false;
        void ChangeMode(GameMode wm)
        {
            switch (wm)
            {
                case GameMode.Peace:
                    Ping("p"); //peace
                    inBattle = false;
                    btnFirst.Text = "Search";
                    btnSecond.Text = "Rest";
                    txtGame.Text = buffer;
                    lbOnline.Visible = true;
                    gpOpponent.Visible = false;
                    break;
                case GameMode.Battle:
                    Ping("b"); //battle
                    btnFirst.Text = "Beat!";
                    btnSecond.Text = "Run!";
                    buffer = txtGame.Text;
                    inBattle = true;
                    txtGame.Text = "The battle has begun!"+'\n';
                    lbOnline.Visible = false;
                    gpOpponent.Visible = true;
                    break;
                default:
                    break;
            }
        }

        public void DoEvent(GameEvents ev) //add chanses like 0.3 0.3 0.3 in looseChanse addChanse fightChanse
        {
            lbTest.Text = "Test: " + ev.ToString();
            string first;
            string second;
            string third = " "; //на всякий добавил
            string final = "";

            inBattle = false;
            inOnlineBattle = false;


            first = First[rand.Next(First.Count)];
            second = Second[rand.Next(Second.Count)];
            int cng;
            switch (ev)
            {
                case GameEvents.LHP:
                    cng = rand.Next(0, HP / 5);
                    final = "decrease your hp by " + cng.ToString();
                    HP -= cng;
                    if (cng == 0) final += " ,lucky bustard";
                    UpdStats();
                    break;
                case GameEvents.LATK:
                    cng = rand.Next(0, ATK/3);
                    final = "decrease your atk by " + cng.ToString();
                    ATK -= cng;
                    if (cng == 0) final += " ,lucky bustard";
                    if (atk <= 1) atk += 5;
                    UpdStats();
                    break;
                case GameEvents.LItem:
                    if (items.Count == 0)
                        final = "nothing happend";
                    else
                    {
                        cng = rand.Next(0, items.Count);
                        final = "losse item, and it's a " + items[cng];
                        items.RemoveAt(cng);
                    }

                    break;
                case GameEvents.AHP:
                    cng = rand.Next(0, HP / 3);
                    final = "increse your hp by " + cng.ToString();
                    HP += cng;
                    if (cng == 0) final += " ,lucky bustard";
                    UpdStats();
                    break;
                case GameEvents.AATK:
                    cng = rand.Next(0, ATK);
                    final = "increse your atk by " + cng.ToString();
                    ATK += cng;
                    lbATK.Text = ATK.ToString();
                    UpdStats();
                    break;
                case GameEvents.AItem:
                    final = "found an item, and it's a";
                    if (items.Count == 0)
                        final = "nothing happend";
                    else
                    {
                        string item = GenerateItem();
                        final = "losse item, and it's a " + item;
                        items.Add(item);
                    }
                    break;
                case GameEvents.MobFight:
                    //"it's fight my friend, but with monster, lucky bastard";
                    ChangeMode(GameMode.Battle);
                    string[] opponent = Enemies[rand.Next(Enemies.Count)].Split(';');
                    opNAME = opponent[0];
                    opHP = int.Parse(opponent[1]);
                    opATK = int.Parse(opponent[2]);
                    //there is going to battle
                    break;
                case GameEvents.PVP:
                    //"it's fight my friend";
                    Ping("f");//find opponent
                    txtGame.Text += "something strange out there is happening..." + '\n';
                    inOnlineBattle = true;
                    //there is goint go battle
                    break;
                default:
                    //"something go wrong";
                    //there is what the heck it is
                    break;
            }
            
            if(!inBattle && !inOnlineBattle)
            {
                txtGame.Text += String.Format("You {0}, than {1} -{2}you {3}!\n", first, second, third, final);
                if (hp <= 0)
                {
                    MessageBox.Show("You dead, body!");
                    Disconnect();
                }
                if (atk <= 0) atk = 1;
            }
        }

        List<string> AttackReplics = new List<string>()
        {
            "make a graceful somersault and attack","from the subtitle","with all strength",
            "somehow sluggish","not cool at all","crossing himself","spread your wings"
        };

        

        string GenerateAttackMove(string who, int atk)
        {
            string[] ways = { "above", "below", "on the side", "obliquely","head on" };
            string attackmove = AttackReplics[rand.Next(AttackReplics.Count)];
            string way = ways[rand.Next(ways.Length)];
            return String.Format("{0} {1} - {2}, dealing {3} damage!", who,attackmove,way,atk);
        }

        int beforePVP = 3;

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (inBattle)
            {
                if (inOnlineBattle)
                {
                    Ping("a;" + atk);
                    string msg = GenerateAttackMove(userName, ATK);
                    SendMessage(msg);
                    txtGame.Text += msg + "\n";
                }
                else
                {
                    txtGame.Text += GenerateAttackMove("You", ATK) + "\n";
                    opHP -= atk;
                    if (opHP <= 0)
                    {
                        ChangeMode(GameMode.Peace);
                        txtGame.Text += "You win, congrats!" + "\n";
                    }
                    else
                    {
                        txtGame.Text += GenerateAttackMove(opNAME, opATK) + "\n";
                        HP -= opATK;
                        if (hp <= 0)
                        {
                            MessageBox.Show("You dead, body!");
                            Disconnect();
                        }
                    }
                }

                btnFirst.Enabled = false;
                timer.Start();

            }
            else
            {
                if (beforePVP <= 0)
                    DoEvent((GameEvents)rand.Next(6));
                else
                {
                    DoEvent((GameEvents)rand.Next(5));
                    beforePVP--;
                    MessageBox.Show(beforePVP.ToString());
                }
                //DoEvent(GameEvents.PVP);
            }
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            if (inBattle)
            {
                /*double chanses = HP / opHP * 100;
                if (rand.Next((int)chanses) > 50) 
                {*/
                    ChangeMode(GameMode.Peace);
                    if(inOnlineBattle)
                    {
                        Ping("l;"); //leave
                        inOnlineBattle = false;
                    }
                    txtGame.Text += "You leaved the battle!" + "\n";
                //}
            }
            else
            {
                txtGame.Text += "You sleep and  restoring some of your life force" + "\n";
                HP += 1;
            }
        }


        void Ping(string signal) // don't forget about '/'
        {
            if (signal[0] != '/') signal = "/" + signal;
            byte[] data = Encoding.Unicode.GetBytes(signal);
            stream.Write(data, 0, data.Length);
            
            Thread.Sleep(200);

        }

        void UpdStats()
        {
            byte[] data = Encoding.Unicode.GetBytes("/u;"+hp.ToString()+";"+atk.ToString());
            stream.Write(data, 0, data.Length);
        }

        #endregion

        private void txtGame_TextChanged(object sender, EventArgs e)
        {

            txtGame.SelectionStart = txtGame.Text.Length;
            txtGame.ScrollToCaret();
            if (!inBattle)
            buffer = txtGame.Text;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            btnFirst.Enabled = true;
            timer.Stop();
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
