namespace Demo
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.picBrand = new System.Windows.Forms.PictureBox();
            this.plParent = new System.Windows.Forms.Panel();
            this.picNetwork = new System.Windows.Forms.PictureBox();
            this.lbNetwork = new System.Windows.Forms.Label();
            this.plCP = new System.Windows.Forms.Panel();
            this.plFK = new System.Windows.Forms.Panel();
            this.mCMarkFeedBack = new Demo.ModuleCornerMark();
            this.plCLP = new System.Windows.Forms.Panel();
            this.mCMarkError = new Demo.ModuleCornerMark();
            this.plJL = new System.Windows.Forms.Panel();
            this.plSZ = new System.Windows.Forms.Panel();
            this.plSG = new System.Windows.Forms.Panel();
            this.mCMarkManual = new Demo.ModuleCornerMark();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tStripStatusLabbulletin = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSStatusLabDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStripStatusLabUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStripStatusLabCheckVison = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_frmMain = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.plDSSC = new System.Windows.Forms.Panel();
            this.moduleCornerMark1 = new Demo.ModuleCornerMark();
            this.totalTicketsNum = new Demo.ModuleTotalTicketsPrice();
            ((System.ComponentModel.ISupportInitialize)(this.picBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetwork)).BeginInit();
            this.plFK.SuspendLayout();
            this.plCLP.SuspendLayout();
            this.plSG.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.plDSSC.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBrand
            // 
            this.picBrand.BackColor = System.Drawing.Color.Transparent;
            this.picBrand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBrand.BackgroundImage")));
            this.picBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBrand.Location = new System.Drawing.Point(0, 0);
            this.picBrand.Name = "picBrand";
            this.picBrand.Size = new System.Drawing.Size(121, 74);
            this.picBrand.TabIndex = 3;
            this.picBrand.TabStop = false;
            // 
            // plParent
            // 
            this.plParent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plParent.BackColor = System.Drawing.Color.White;
            this.plParent.ForeColor = System.Drawing.Color.Black;
            this.plParent.Location = new System.Drawing.Point(0, 77);
            this.plParent.Name = "plParent";
            this.plParent.Size = new System.Drawing.Size(950, 565);
            this.plParent.TabIndex = 15;
            // 
            // picNetwork
            // 
            this.picNetwork.BackColor = System.Drawing.Color.Transparent;
            this.picNetwork.Image = global::Demo.Properties.Resources.wifi;
            this.picNetwork.Location = new System.Drawing.Point(803, 3);
            this.picNetwork.Name = "picNetwork";
            this.picNetwork.Size = new System.Drawing.Size(21, 18);
            this.picNetwork.TabIndex = 16;
            this.picNetwork.TabStop = false;
            // 
            // lbNetwork
            // 
            this.lbNetwork.AutoSize = true;
            this.lbNetwork.BackColor = System.Drawing.Color.Transparent;
            this.lbNetwork.Location = new System.Drawing.Point(827, 6);
            this.lbNetwork.Name = "lbNetwork";
            this.lbNetwork.Size = new System.Drawing.Size(53, 12);
            this.lbNetwork.TabIndex = 17;
            this.lbNetwork.Text = "网络正常";
            // 
            // plCP
            // 
            this.plCP.BackColor = System.Drawing.Color.Transparent;
            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPfocuse;
            this.plCP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plCP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plCP.Location = new System.Drawing.Point(127, 7);
            this.plCP.Name = "plCP";
            this.plCP.Size = new System.Drawing.Size(72, 67);
            this.plCP.TabIndex = 18;
            this.plCP.Click += new System.EventHandler(this.plCP_Click);
            this.plCP.MouseEnter += new System.EventHandler(this.plCP_MouseHover);
            this.plCP.MouseLeave += new System.EventHandler(this.plCP_MouseLeave);
            // 
            // plFK
            // 
            this.plFK.BackColor = System.Drawing.Color.Transparent;
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKunfocuse;
            this.plFK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plFK.Controls.Add(this.mCMarkFeedBack);
            this.plFK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plFK.Location = new System.Drawing.Point(215, 6);
            this.plFK.Name = "plFK";
            this.plFK.Size = new System.Drawing.Size(72, 67);
            this.plFK.TabIndex = 19;
            this.plFK.Click += new System.EventHandler(this.plFK_Click);
            this.plFK.MouseEnter += new System.EventHandler(this.plFK_MouseHover);
            this.plFK.MouseLeave += new System.EventHandler(this.plFK_MouseLeave);
            // 
            // mCMarkFeedBack
            // 
            this.mCMarkFeedBack.BackColor = System.Drawing.Color.Transparent;
            this.mCMarkFeedBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mCMarkFeedBack.BackgroundImage")));
            this.mCMarkFeedBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mCMarkFeedBack.Location = new System.Drawing.Point(42, 30);
            this.mCMarkFeedBack.Name = "mCMarkFeedBack";
            this.mCMarkFeedBack.Number = 0;
            this.mCMarkFeedBack.Size = new System.Drawing.Size(16, 16);
            this.mCMarkFeedBack.TabIndex = 11;
            this.mCMarkFeedBack.Click += new System.EventHandler(this.plFK_Click);
            // 
            // plCLP
            // 
            this.plCLP.BackColor = System.Drawing.Color.Transparent;
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPunfocuse;
            this.plCLP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plCLP.Controls.Add(this.mCMarkError);
            this.plCLP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plCLP.Location = new System.Drawing.Point(303, 6);
            this.plCLP.Name = "plCLP";
            this.plCLP.Size = new System.Drawing.Size(72, 67);
            this.plCLP.TabIndex = 19;
            this.plCLP.Click += new System.EventHandler(this.plCLP_Click);
            this.plCLP.MouseEnter += new System.EventHandler(this.plCLP_MouseHover);
            this.plCLP.MouseLeave += new System.EventHandler(this.plCLP_MouseLeave);
            // 
            // mCMarkError
            // 
            this.mCMarkError.BackColor = System.Drawing.Color.Transparent;
            this.mCMarkError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mCMarkError.BackgroundImage")));
            this.mCMarkError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mCMarkError.Location = new System.Drawing.Point(43, 30);
            this.mCMarkError.Name = "mCMarkError";
            this.mCMarkError.Number = 0;
            this.mCMarkError.Size = new System.Drawing.Size(16, 16);
            this.mCMarkError.TabIndex = 12;
            this.mCMarkError.Click += new System.EventHandler(this.plCLP_Click);
            // 
            // plJL
            // 
            this.plJL.BackColor = System.Drawing.Color.Transparent;
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLunfocuse;
            this.plJL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plJL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plJL.Location = new System.Drawing.Point(391, 6);
            this.plJL.Name = "plJL";
            this.plJL.Size = new System.Drawing.Size(72, 67);
            this.plJL.TabIndex = 20;
            this.plJL.Click += new System.EventHandler(this.plJL_Click);
            this.plJL.MouseEnter += new System.EventHandler(this.plJL_MouseHover);
            this.plJL.MouseLeave += new System.EventHandler(this.plJL_MouseLeave);
            // 
            // plSZ
            // 
            this.plSZ.BackColor = System.Drawing.Color.Transparent;
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZunfocuse;
            this.plSZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plSZ.Location = new System.Drawing.Point(655, 6);
            this.plSZ.Name = "plSZ";
            this.plSZ.Size = new System.Drawing.Size(72, 67);
            this.plSZ.TabIndex = 20;
            this.plSZ.Click += new System.EventHandler(this.plSZ_Click);
            this.plSZ.MouseEnter += new System.EventHandler(this.plSZ_MouseHover);
            this.plSZ.MouseLeave += new System.EventHandler(this.plSZ_MouseLeave);
            // 
            // plSG
            // 
            this.plSG.BackColor = System.Drawing.Color.Transparent;
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGunfocuse;
            this.plSG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plSG.Controls.Add(this.mCMarkManual);
            this.plSG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plSG.Location = new System.Drawing.Point(479, 6);
            this.plSG.Name = "plSG";
            this.plSG.Size = new System.Drawing.Size(72, 67);
            this.plSG.TabIndex = 21;
            this.plSG.Click += new System.EventHandler(this.plSG_Click);
            this.plSG.MouseEnter += new System.EventHandler(this.plSG_MouseHover);
            this.plSG.MouseLeave += new System.EventHandler(this.plSG_MouseLeave);
            // 
            // mCMarkManual
            // 
            this.mCMarkManual.BackColor = System.Drawing.Color.Transparent;
            this.mCMarkManual.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mCMarkManual.BackgroundImage")));
            this.mCMarkManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mCMarkManual.Location = new System.Drawing.Point(43, 30);
            this.mCMarkManual.Name = "mCMarkManual";
            this.mCMarkManual.Number = 0;
            this.mCMarkManual.Size = new System.Drawing.Size(16, 16);
            this.mCMarkManual.TabIndex = 14;
            this.mCMarkManual.Click += new System.EventHandler(this.plSG_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.BackgroundImage = global::Demo.Properties.Resources.topBackImg01;
            this.statusStrip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripStatusLabbulletin,
            this.toolStripStatusLabel1,
            this.tSStatusLabDate,
            this.toolStripStatusLabel2,
            this.tStripStatusLabUpdate,
            this.tStripStatusLabCheckVison});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 641);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(950, 24);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 22;
            // 
            // tStripStatusLabbulletin
            // 
            this.tStripStatusLabbulletin.BackColor = System.Drawing.Color.Transparent;
            this.tStripStatusLabbulletin.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tStripStatusLabbulletin.ForeColor = System.Drawing.Color.Black;
            this.tStripStatusLabbulletin.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tStripStatusLabbulletin.Name = "tStripStatusLabbulletin";
            this.tStripStatusLabbulletin.Size = new System.Drawing.Size(340, 21);
            this.tStripStatusLabbulletin.Text = "新的出票系统上线，欢迎大家体验!                                    ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 19);
            this.toolStripStatusLabel1.Text = "     服务器时间:";
            // 
            // tSStatusLabDate
            // 
            this.tSStatusLabDate.BackColor = System.Drawing.Color.Transparent;
            this.tSStatusLabDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tSStatusLabDate.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tSStatusLabDate.ForeColor = System.Drawing.Color.Black;
            this.tSStatusLabDate.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tSStatusLabDate.Name = "tSStatusLabDate";
            this.tSStatusLabDate.Size = new System.Drawing.Size(162, 21);
            this.tSStatusLabDate.Text = "xxxx年xx月xx日 xx:xx:xx     ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 21);
            this.toolStripStatusLabel2.Text = "  更新时间:";
            // 
            // tStripStatusLabUpdate
            // 
            this.tStripStatusLabUpdate.BackColor = System.Drawing.Color.Transparent;
            this.tStripStatusLabUpdate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tStripStatusLabUpdate.ForeColor = System.Drawing.Color.Black;
            this.tStripStatusLabUpdate.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tStripStatusLabUpdate.Name = "tStripStatusLabUpdate";
            this.tStripStatusLabUpdate.Size = new System.Drawing.Size(136, 21);
            this.tStripStatusLabUpdate.Text = "2015年09月18日        ";
            // 
            // tStripStatusLabCheckVison
            // 
            this.tStripStatusLabCheckVison.BackColor = System.Drawing.Color.Transparent;
            this.tStripStatusLabCheckVison.IsLink = true;
            this.tStripStatusLabCheckVison.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tStripStatusLabCheckVison.Name = "tStripStatusLabCheckVison";
            this.tStripStatusLabCheckVison.Size = new System.Drawing.Size(56, 21);
            this.tStripStatusLabCheckVison.Spring = true;
            this.tStripStatusLabCheckVison.Text = "数据更新";
            this.tStripStatusLabCheckVison.Click += new System.EventHandler(this.tStripStatusLabCheckVison_Click);
            // 
            // timer_frmMain
            // 
            this.timer_frmMain.Enabled = true;
            this.timer_frmMain.Interval = 500;
            this.timer_frmMain.Tick += new System.EventHandler(this.timer_frmMain_Tick);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Demo.Properties.Resources.btnClose;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(931, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(19, 19);
            this.btnClose.TabIndex = 25;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(909, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(19, 19);
            this.btnMinimize.TabIndex = 26;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseEnter += new System.EventHandler(this.btnMinimize_MouseEnter);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.btnMinimize_MouseLeave);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // plDSSC
            // 
            this.plDSSC.BackColor = System.Drawing.Color.Transparent;
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiUnfocused;
            this.plDSSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plDSSC.Controls.Add(this.moduleCornerMark1);
            this.plDSSC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plDSSC.Enabled = false;
            this.plDSSC.Location = new System.Drawing.Point(567, 6);
            this.plDSSC.Name = "plDSSC";
            this.plDSSC.Size = new System.Drawing.Size(72, 67);
            this.plDSSC.TabIndex = 22;
            this.plDSSC.Click += new System.EventHandler(this.plDSSC_Click);
            this.plDSSC.MouseEnter += new System.EventHandler(this.plDSSC_MouseEnter);
            this.plDSSC.MouseLeave += new System.EventHandler(this.plDSSC_MouseLeave);
            // 
            // moduleCornerMark1
            // 
            this.moduleCornerMark1.BackColor = System.Drawing.Color.Transparent;
            this.moduleCornerMark1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moduleCornerMark1.BackgroundImage")));
            this.moduleCornerMark1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.moduleCornerMark1.Location = new System.Drawing.Point(43, 30);
            this.moduleCornerMark1.Name = "moduleCornerMark1";
            this.moduleCornerMark1.Number = 0;
            this.moduleCornerMark1.Size = new System.Drawing.Size(16, 16);
            this.moduleCornerMark1.TabIndex = 14;
            // 
            // totalTicketsNum
            // 
            this.totalTicketsNum.BackColor = System.Drawing.Color.Transparent;
            this.totalTicketsNum.Location = new System.Drawing.Point(750, 44);
            this.totalTicketsNum.Name = "totalTicketsNum";
            this.totalTicketsNum.Size = new System.Drawing.Size(188, 26);
            this.totalTicketsNum.TabIndex = 23;
            this.totalTicketsNum.value = "0000000";
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Demo.Properties.Resources.top_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(950, 665);
            this.Controls.Add(this.plDSSC);
            this.Controls.Add(this.plParent);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.totalTicketsNum);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.plSG);
            this.Controls.Add(this.lbNetwork);
            this.Controls.Add(this.picNetwork);
            this.Controls.Add(this.picBrand);
            this.Controls.Add(this.plCP);
            this.Controls.Add(this.plFK);
            this.Controls.Add(this.plCLP);
            this.Controls.Add(this.plJL);
            this.Controls.Add(this.plSZ);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetwork)).EndInit();
            this.plFK.ResumeLayout(false);
            this.plCLP.ResumeLayout(false);
            this.plSG.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.plDSSC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBrand;
        private System.Windows.Forms.Panel plParent;
        private System.Windows.Forms.PictureBox picNetwork;
        private System.Windows.Forms.Label lbNetwork;
        private System.Windows.Forms.Panel plCP;
        private System.Windows.Forms.Panel plFK;
        private System.Windows.Forms.Panel plCLP;
        private System.Windows.Forms.Panel plJL;
        private System.Windows.Forms.Panel plSZ;
        private System.Windows.Forms.Panel plDSSC;
        private System.Windows.Forms.Panel plSG;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabDate;
        private System.Windows.Forms.Timer timer_frmMain;
        private System.Windows.Forms.ToolStripStatusLabel tStripStatusLabbulletin;
        private System.Windows.Forms.ToolStripStatusLabel tStripStatusLabUpdate;
        private System.Windows.Forms.ToolStripStatusLabel tStripStatusLabCheckVison;
        private ModuleTotalTicketsPrice totalTicketsNum;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private ModuleCornerMark mCMarkFeedBack;
        private ModuleCornerMark mCMarkError;
        private ModuleCornerMark mCMarkManual;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private ModuleCornerMark moduleCornerMark1;
    }
}

