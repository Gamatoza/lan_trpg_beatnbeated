using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        static ServerObject server; // сервер
        static Thread listenThread; // потока для прослушивания
                                    //bool isActive = true;
        #region GraphicStuff

        bool _log;
        bool _hidden;
        public Server(string[] args)//TODO: Hide on args
        {
            InitializeComponent();

            foreach (var item in args)
            {
                if (item == "--log") _log = true;
                if (item == "--hidden") _hidden = true;
            }


            _notifyIcon.Text = "Server is Running";
            //устанавливаем значок, отображаемый в трее:
            //либо один из стандартных:
            //_notifyIcon.Icon = SystemIcons.Error;
            //либо свой из файла:
            //_notifyIcon.Icon = new Icon("server.ico"); //поместил сразу в настройки
            //подписываемся на событие клика мышкой по значку в трее
            _notifyIcon.MouseClick += new MouseEventHandler(_notifyIcon_MouseClick);
            //подписываемся на событие изменения размера формы
            this.Resize += new EventHandler(FormForTray_Resize);
            if (_hidden)
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
            }
            StartServer();

            //timer.Start();

        }


        ///
        /// здесь хранится состояние окна до сворачивания (максимизированное или нормальное)
        ///
        private FormWindowState _OldFormState;

        ///
        /// обрабатываем событие клика мышью по значку в трее
        ///
        void _notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //проверяем, какой кнопкой было произведено нажатие
            if (e.Button == MouseButtons.Left)//если левой кнопкой мыши
            {
                //проверяем текущее состояние окна
                if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)//если оно развернуто
                {
                    //сохраняем текущее состояние
                    _OldFormState = WindowState;
                    //сворачиваем окно
                    WindowState = FormWindowState.Minimized;
                    //скрываться в трей оно будет по событию Resize (изменение размера), которое сгенерировалось после минимизации строчкой выше
                }
                else//в противном случае
                {
                    //и показываем на нанели задач
                    Show();
                    //разворачиваем (возвращаем старое состояние "до сворачивания")
                    WindowState = _OldFormState;
                }
            }
        }

        ///
        /// обрабатываем событие изменения размера
        ///
        void FormForTray_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)//если окно "свернуто"
            {
                //то скрываем его
                Hide();
            }
        }
        #endregion
        string GetLogName()
        {
            string normalDate = DateTime.Now.Date.ToString().Split(' ')[0];
            string normalTime = DateTime.Now.TimeOfDay.ToString().Split('.')[0].Replace(":", "");
            string normalize = normalDate + "_" + normalTime;
            string path = "log" + normalize + ".log";
            return path;
        }
        static FileStream log;
        void StartServer()
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\logs";
                string file = path + "\\" + GetLogName();
                if (_log)
                {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                log = new FileStream(file,FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(log);
                    sw.WriteLine("Server application start");
                    sw.Flush();
                server = new ServerObject(log);
                }
                else server = new ServerObject();
                
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                server.Disconnect();
            }
        }
        private void btnCloseServer_Click(object sender, EventArgs e)
        {
            server.Disconnect();
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logs in file");
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Disconnect();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
