
namespace Server
{
    partial class Server
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.btnServer = new System.Windows.Forms.Button();
            this.lbStatistic = new System.Windows.Forms.Label();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.lbPeopleOnline = new System.Windows.Forms.Label();
            this.lbFightNow = new System.Windows.Forms.Label();
            this.lbFIghtGeneral = new System.Windows.Forms.Label();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnServer
            // 
            this.btnServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServer.Location = new System.Drawing.Point(18, 12);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(207, 47);
            this.btnServer.TabIndex = 0;
            this.btnServer.Text = "Close Server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnCloseServer_Click);
            // 
            // lbStatistic
            // 
            this.lbStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatistic.Location = new System.Drawing.Point(18, 62);
            this.lbStatistic.Name = "lbStatistic";
            this.lbStatistic.Size = new System.Drawing.Size(207, 29);
            this.lbStatistic.TabIndex = 1;
            this.lbStatistic.Text = "Status: Online";
            this.lbStatistic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnShowLog
            // 
            this.btnShowLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowLog.Location = new System.Drawing.Point(12, 187);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(213, 34);
            this.btnShowLog.TabIndex = 2;
            this.btnShowLog.Text = "ShowLog";
            this.btnShowLog.UseVisualStyleBackColor = true;
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // lbPeopleOnline
            // 
            this.lbPeopleOnline.AutoSize = true;
            this.lbPeopleOnline.Location = new System.Drawing.Point(12, 104);
            this.lbPeopleOnline.Name = "lbPeopleOnline";
            this.lbPeopleOnline.Size = new System.Drawing.Size(120, 17);
            this.lbPeopleOnline.TabIndex = 3;
            this.lbPeopleOnline.Text = "People on server:";
            // 
            // lbFightNow
            // 
            this.lbFightNow.AutoSize = true;
            this.lbFightNow.Location = new System.Drawing.Point(12, 130);
            this.lbFightNow.Name = "lbFightNow";
            this.lbFightNow.Size = new System.Drawing.Size(91, 17);
            this.lbFightNow.TabIndex = 4;
            this.lbFightNow.Text = "Fighting now:";
            // 
            // lbFIghtGeneral
            // 
            this.lbFIghtGeneral.AutoSize = true;
            this.lbFIghtGeneral.Location = new System.Drawing.Point(12, 157);
            this.lbFIghtGeneral.Name = "lbFIghtGeneral";
            this.lbFIghtGeneral.Size = new System.Drawing.Size(117, 17);
            this.lbFIghtGeneral.TabIndex = 5;
            this.lbFIghtGeneral.Text = "Fights in general:";
            // 
            // _notifyIcon
            // 
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "notifyIcon1";
            this._notifyIcon.Visible = true;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(241, 233);
            this.Controls.Add(this.lbFIghtGeneral);
            this.Controls.Add(this.lbFightNow);
            this.Controls.Add(this.lbPeopleOnline);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.lbStatistic);
            this.Controls.Add(this.btnServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Label lbStatistic;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.Label lbPeopleOnline;
        private System.Windows.Forms.Label lbFightNow;
        private System.Windows.Forms.Label lbFIghtGeneral;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.Timer timer;
    }
}

