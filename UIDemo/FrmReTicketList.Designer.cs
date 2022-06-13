﻿namespace Demo
{
    partial class FrmReTicketList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReTicketList));
            this.panel_reTicket = new System.Windows.Forms.Panel();
            this.tBox_reTicketMsg = new System.Windows.Forms.TextBox();
            this.panel_com = new System.Windows.Forms.Panel();
            this.cBoxCOM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.btnReTicket = new System.Windows.Forms.Button();
            this.lbTips = new System.Windows.Forms.Label();
            this.panel_reTicket.SuspendLayout();
            this.panel_com.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_reTicket
            // 
            this.panel_reTicket.BackColor = System.Drawing.Color.Transparent;
            this.panel_reTicket.Controls.Add(this.tBox_reTicketMsg);
            this.panel_reTicket.Controls.Add(this.panel_com);
            this.panel_reTicket.Location = new System.Drawing.Point(5, 59);
            this.panel_reTicket.Name = "panel_reTicket";
            this.panel_reTicket.Size = new System.Drawing.Size(410, 305);
            this.panel_reTicket.TabIndex = 11;
            // 
            // tBox_reTicketMsg
            // 
            this.tBox_reTicketMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBox_reTicketMsg.Location = new System.Drawing.Point(0, 41);
            this.tBox_reTicketMsg.Multiline = true;
            this.tBox_reTicketMsg.Name = "tBox_reTicketMsg";
            this.tBox_reTicketMsg.ReadOnly = true;
            this.tBox_reTicketMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBox_reTicketMsg.Size = new System.Drawing.Size(410, 264);
            this.tBox_reTicketMsg.TabIndex = 1;
            // 
            // panel_com
            // 
            this.panel_com.Controls.Add(this.cBoxCOM);
            this.panel_com.Controls.Add(this.label1);
            this.panel_com.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_com.Location = new System.Drawing.Point(0, 0);
            this.panel_com.Name = "panel_com";
            this.panel_com.Size = new System.Drawing.Size(410, 41);
            this.panel_com.TabIndex = 0;
            // 
            // cBoxCOM
            // 
            this.cBoxCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCOM.FormattingEnabled = true;
            this.cBoxCOM.Location = new System.Drawing.Point(109, 5);
            this.cBoxCOM.Name = "cBoxCOM";
            this.cBoxCOM.Size = new System.Drawing.Size(294, 20);
            this.cBoxCOM.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口***机型:";
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(395, 15);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(14, 14);
            this.picClose.TabIndex = 10;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReTicket
            // 
            this.btnReTicket.BackgroundImage = global::Demo.Properties.Resources.btnPrintUnfocused;
            this.btnReTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReTicket.FlatAppearance.BorderSize = 0;
            this.btnReTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReTicket.Location = new System.Drawing.Point(325, 370);
            this.btnReTicket.Name = "btnReTicket";
            this.btnReTicket.Size = new System.Drawing.Size(83, 24);
            this.btnReTicket.TabIndex = 9;
            this.btnReTicket.UseVisualStyleBackColor = true;
            this.btnReTicket.Click += new System.EventHandler(this.btnReTicket_Click);
            // 
            // lbTips
            // 
            this.lbTips.AutoSize = true;
            this.lbTips.BackColor = System.Drawing.Color.Transparent;
            this.lbTips.Location = new System.Drawing.Point(66, 55);
            this.lbTips.Name = "lbTips";
            this.lbTips.Size = new System.Drawing.Size(0, 12);
            this.lbTips.TabIndex = 8;
            // 
            // FrmReTicketList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Demo.Properties.Resources.updateBackImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(420, 408);
            this.Controls.Add(this.panel_reTicket);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.btnReTicket);
            this.Controls.Add(this.lbTips);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReTicketList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTicketNumberSearch";
            this.Load += new System.EventHandler(this.FrmReTicketList_Load);
            this.panel_reTicket.ResumeLayout(false);
            this.panel_reTicket.PerformLayout();
            this.panel_com.ResumeLayout(false);
            this.panel_com.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_reTicket;
        private System.Windows.Forms.TextBox tBox_reTicketMsg;
        private System.Windows.Forms.Panel panel_com;
        private System.Windows.Forms.ComboBox cBoxCOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Button btnReTicket;
        private System.Windows.Forms.Label lbTips;
    }
}