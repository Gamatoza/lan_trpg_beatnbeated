
namespace BeatNBeated
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSecond = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.lbOnline = new System.Windows.Forms.Label();
            this.lalble = new System.Windows.Forms.Label();
            this.txtGame = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbHP = new System.Windows.Forms.Label();
            this.lbATK = new System.Windows.Forms.Label();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.lbTest = new System.Windows.Forms.Label();
            this.gpItems = new System.Windows.Forms.GroupBox();
            this.gpOpponent = new System.Windows.Forms.GroupBox();
            this.lbName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbOpATK = new System.Windows.Forms.Label();
            this.lbOpHP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gpItems.SuspendLayout();
            this.gpOpponent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(202, 5);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(61, 23);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(12, 394);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(102, 44);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "Search";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnSecond
            // 
            this.btnSecond.Location = new System.Drawing.Point(12, 444);
            this.btnSecond.Name = "btnSecond";
            this.btnSecond.Size = new System.Drawing.Size(102, 44);
            this.btnSecond.TabIndex = 6;
            this.btnSecond.Text = "Rest";
            this.btnSecond.UseVisualStyleBackColor = true;
            this.btnSecond.Click += new System.EventHandler(this.btnSecond_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLeave.Location = new System.Drawing.Point(269, 5);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(58, 23);
            this.btnLeave.TabIndex = 3;
            this.btnLeave.Text = "Exit";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbOnline
            // 
            this.lbOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOnline.AutoSize = true;
            this.lbOnline.Location = new System.Drawing.Point(230, 302);
            this.lbOnline.Name = "lbOnline";
            this.lbOnline.Size = new System.Drawing.Size(53, 17);
            this.lbOnline.TabIndex = 7;
            this.lbOnline.Text = "Online:";
            // 
            // lalble
            // 
            this.lalble.AutoSize = true;
            this.lalble.Location = new System.Drawing.Point(12, 302);
            this.lalble.Name = "lalble";
            this.lalble.Size = new System.Drawing.Size(65, 17);
            this.lalble.TabIndex = 10;
            this.lalble.Text = "Message";
            // 
            // txtGame
            // 
            this.txtGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGame.Location = new System.Drawing.Point(12, 34);
            this.txtGame.Name = "txtGame";
            this.txtGame.ReadOnly = true;
            this.txtGame.Size = new System.Drawing.Size(315, 265);
            this.txtGame.TabIndex = 11;
            this.txtGame.Text = "";
            this.txtGame.TextChanged += new System.EventHandler(this.txtGame_TextChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(12, 322);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(315, 66);
            this.txtMessage.TabIndex = 12;
            this.txtMessage.Text = "";
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "HP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "ATK:";
            // 
            // lbHP
            // 
            this.lbHP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbHP.Location = new System.Drawing.Point(41, 9);
            this.lbHP.Name = "lbHP";
            this.lbHP.Size = new System.Drawing.Size(51, 17);
            this.lbHP.TabIndex = 15;
            this.lbHP.Text = "100";
            // 
            // lbATK
            // 
            this.lbATK.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbATK.Location = new System.Drawing.Point(143, 9);
            this.lbATK.Name = "lbATK";
            this.lbATK.Size = new System.Drawing.Size(53, 17);
            this.lbATK.TabIndex = 16;
            this.lbATK.Text = "10";
            // 
            // listBoxItems
            // 
            this.listBoxItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.ItemHeight = 16;
            this.listBoxItems.Items.AddRange(new object[] {
            ""});
            this.listBoxItems.Location = new System.Drawing.Point(3, 18);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(201, 73);
            this.listBoxItems.TabIndex = 17;
            // 
            // lbTest
            // 
            this.lbTest.AutoSize = true;
            this.lbTest.Location = new System.Drawing.Point(143, 302);
            this.lbTest.Name = "lbTest";
            this.lbTest.Size = new System.Drawing.Size(36, 17);
            this.lbTest.TabIndex = 19;
            this.lbTest.Text = "Test";
            // 
            // gpItems
            // 
            this.gpItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpItems.Controls.Add(this.gpOpponent);
            this.gpItems.Controls.Add(this.listBoxItems);
            this.gpItems.Location = new System.Drawing.Point(120, 394);
            this.gpItems.Name = "gpItems";
            this.gpItems.Size = new System.Drawing.Size(207, 94);
            this.gpItems.TabIndex = 20;
            this.gpItems.TabStop = false;
            this.gpItems.Text = "Items";
            // 
            // gpOpponent
            // 
            this.gpOpponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpOpponent.Controls.Add(this.lbName);
            this.gpOpponent.Controls.Add(this.label7);
            this.gpOpponent.Controls.Add(this.lbOpATK);
            this.gpOpponent.Controls.Add(this.lbOpHP);
            this.gpOpponent.Controls.Add(this.label6);
            this.gpOpponent.Controls.Add(this.label5);
            this.gpOpponent.Location = new System.Drawing.Point(-1, -1);
            this.gpOpponent.Name = "gpOpponent";
            this.gpOpponent.Size = new System.Drawing.Size(210, 94);
            this.gpOpponent.TabIndex = 21;
            this.gpOpponent.TabStop = false;
            this.gpOpponent.Text = "Opponent";
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Salmon;
            this.lbName.Location = new System.Drawing.Point(59, 26);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(133, 18);
            this.lbName.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "Name:";
            // 
            // lbOpATK
            // 
            this.lbOpATK.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbOpATK.Location = new System.Drawing.Point(139, 64);
            this.lbOpATK.Name = "lbOpATK";
            this.lbOpATK.Size = new System.Drawing.Size(53, 17);
            this.lbOpATK.TabIndex = 25;
            this.lbOpATK.Text = "10";
            // 
            // lbOpHP
            // 
            this.lbOpHP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbOpHP.Location = new System.Drawing.Point(37, 64);
            this.lbOpHP.Name = "lbOpHP";
            this.lbOpHP.Size = new System.Drawing.Size(51, 17);
            this.lbOpHP.TabIndex = 24;
            this.lbOpHP.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "HP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "ATK:";
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(339, 497);
            this.Controls.Add(this.lbTest);
            this.Controls.Add(this.gpItems);
            this.Controls.Add(this.lbATK);
            this.Controls.Add(this.lbHP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtGame);
            this.Controls.Add(this.lalble);
            this.Controls.Add(this.lbOnline);
            this.Controls.Add(this.btnSecond);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(357, 544);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.gpItems.ResumeLayout(false);
            this.gpOpponent.ResumeLayout(false);
            this.gpOpponent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSecond;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Label lbOnline;
        private System.Windows.Forms.Label lalble;
        private System.Windows.Forms.RichTextBox txtGame;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbHP;
        private System.Windows.Forms.Label lbATK;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.Label lbTest;
        private System.Windows.Forms.GroupBox gpItems;
        private System.Windows.Forms.GroupBox gpOpponent;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbOpATK;
        private System.Windows.Forms.Label lbOpHP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer;
    }
}