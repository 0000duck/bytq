﻿namespace Sys.SysBusiness
{
    partial class FrmDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDialog));
            this.label4 = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pnl_yn = new System.Windows.Forms.Panel();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.pnl_ok = new System.Windows.Forms.Panel();
            this.btn_TipsOk = new System.Windows.Forms.Button();
            this.pnl_ask = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.pic_Message = new System.Windows.Forms.PictureBox();
            this.pnl_yn.SuspendLayout();
            this.pnl_ok.SuspendLayout();
            this.pnl_ask.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Message)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(445, 2);
            this.label4.TabIndex = 13;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Add.ico");
            this.imageList.Images.SetKeyName(1, "Delete.ico");
            this.imageList.Images.SetKeyName(2, "Edit.ico");
            this.imageList.Images.SetKeyName(3, "Exit.ico");
            this.imageList.Images.SetKeyName(4, "Cancel.ico");
            this.imageList.Images.SetKeyName(5, "ok.ico");
            // 
            // pnl_yn
            // 
            this.pnl_yn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_yn.Controls.Add(this.btn_Yes);
            this.pnl_yn.Controls.Add(this.btn_No);
            this.pnl_yn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_yn.Location = new System.Drawing.Point(0, 104);
            this.pnl_yn.Name = "pnl_yn";
            this.pnl_yn.Size = new System.Drawing.Size(445, 45);
            this.pnl_yn.TabIndex = 20;
            // 
            // btn_Yes
            // 
            this.btn_Yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Yes.BackColor = System.Drawing.Color.Transparent;
            this.btn_Yes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Yes.BackgroundImage")));
            this.btn_Yes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Yes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Yes.FlatAppearance.BorderSize = 0;
            this.btn_Yes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Yes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Yes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Yes.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Yes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Yes.ImageList = this.imageList;
            this.btn_Yes.Location = new System.Drawing.Point(281, 1);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(80, 40);
            this.btn_Yes.TabIndex = 11;
            this.btn_Yes.Text = "Yes";
            this.btn_Yes.UseVisualStyleBackColor = false;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_No
            // 
            this.btn_No.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_No.BackColor = System.Drawing.Color.Transparent;
            this.btn_No.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_No.BackgroundImage")));
            this.btn_No.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_No.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_No.FlatAppearance.BorderSize = 0;
            this.btn_No.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_No.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_No.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_No.ForeColor = System.Drawing.Color.Transparent;
            this.btn_No.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_No.ImageList = this.imageList;
            this.btn_No.Location = new System.Drawing.Point(362, 1);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(80, 40);
            this.btn_No.TabIndex = 12;
            this.btn_No.Text = "No";
            this.btn_No.UseVisualStyleBackColor = false;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // pnl_ok
            // 
            this.pnl_ok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ok.Controls.Add(this.btn_TipsOk);
            this.pnl_ok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_ok.Location = new System.Drawing.Point(0, 149);
            this.pnl_ok.Name = "pnl_ok";
            this.pnl_ok.Size = new System.Drawing.Size(445, 45);
            this.pnl_ok.TabIndex = 19;
            // 
            // btn_TipsOk
            // 
            this.btn_TipsOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TipsOk.BackColor = System.Drawing.Color.Transparent;
            this.btn_TipsOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TipsOk.BackgroundImage")));
            this.btn_TipsOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TipsOk.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_TipsOk.FlatAppearance.BorderSize = 0;
            this.btn_TipsOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_TipsOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_TipsOk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TipsOk.ForeColor = System.Drawing.Color.Transparent;
            this.btn_TipsOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TipsOk.ImageList = this.imageList;
            this.btn_TipsOk.Location = new System.Drawing.Point(362, 1);
            this.btn_TipsOk.Name = "btn_TipsOk";
            this.btn_TipsOk.Size = new System.Drawing.Size(80, 40);
            this.btn_TipsOk.TabIndex = 11;
            this.btn_TipsOk.Text = "OK";
            this.btn_TipsOk.UseVisualStyleBackColor = false;
            this.btn_TipsOk.Click += new System.EventHandler(this.btn_TipsOk_Click);
            // 
            // pnl_ask
            // 
            this.pnl_ask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ask.Controls.Add(this.btn_Ok);
            this.pnl_ask.Controls.Add(this.btn_Cancle);
            this.pnl_ask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_ask.Location = new System.Drawing.Point(0, 194);
            this.pnl_ask.Name = "pnl_ask";
            this.pnl_ask.Size = new System.Drawing.Size(445, 45);
            this.pnl_ask.TabIndex = 18;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Ok.BackgroundImage")));
            this.btn_Ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.ImageList = this.imageList;
            this.btn_Ok.Location = new System.Drawing.Point(281, 1);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 40);
            this.btn_Ok.TabIndex = 11;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Option_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancle.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancle.BackgroundImage")));
            this.btn_Cancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancle.FlatAppearance.BorderSize = 0;
            this.btn_Cancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancle.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancle.ImageList = this.imageList;
            this.btn_Cancle.Location = new System.Drawing.Point(362, 1);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(80, 40);
            this.btn_Cancle.TabIndex = 12;
            this.btn_Cancle.Text = "Cancel";
            this.btn_Cancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancle.UseVisualStyleBackColor = false;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Info);
            this.panel2.Controls.Add(this.pic_Message);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 102);
            this.panel2.TabIndex = 21;
            // 
            // lbl_Info
            // 
            this.lbl_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Info.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Info.Location = new System.Drawing.Point(70, 0);
            this.lbl_Info.MinimumSize = new System.Drawing.Size(313, 94);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(375, 102);
            this.lbl_Info.TabIndex = 3;
            this.lbl_Info.Text = "确定退出系统？如退出则不能正常接收生产数据。";
            this.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pic_Message
            // 
            this.pic_Message.BackgroundImage = global::Sys.SysBusiness.Properties.Resources.qustion;
            this.pic_Message.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_Message.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic_Message.Location = new System.Drawing.Point(0, 0);
            this.pic_Message.Name = "pic_Message";
            this.pic_Message.Size = new System.Drawing.Size(70, 102);
            this.pic_Message.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Message.TabIndex = 2;
            this.pic_Message.TabStop = false;
            // 
            // FrmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 239);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_yn);
            this.Controls.Add(this.pnl_ok);
            this.Controls.Add(this.pnl_ask);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提示信息 Info";
            this.Load += new System.EventHandler(this.FrmDialog_Load);
            this.pnl_yn.ResumeLayout(false);
            this.pnl_ok.ResumeLayout(false);
            this.pnl_ask.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Message)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel pnl_yn;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Panel pnl_ok;
        private System.Windows.Forms.Button btn_TipsOk;
        private System.Windows.Forms.Panel pnl_ask;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.PictureBox pic_Message;
    }
}