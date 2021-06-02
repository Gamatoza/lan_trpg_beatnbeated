using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace BeatNBeated
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnConnectTo_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        void StartGame()
        {
            string userName = txtName.Text;
            string host = txtAdress.Text;//добавить проверку по регексу
            int port = Int32.Parse(txtPort.Text);//добавить проверку по числу
            Game game = new Game(userName, host, port, this);
            this.Hide();
            game.ShowDialog();
        }

        private void btnCreateOwn_Click(object sender, EventArgs e)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory() + @"\server.exe";
                proc.StartInfo.Arguments = "--hidden"; //--log for вести логирование, лол, --hidden что бы запустилась сразу в трее
                proc.Start(); 
                StartGame();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }


    }
}
