namespace Practice
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.服务器配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相片管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指纹录制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ContextMenuStrip = this.contextMenuStrip1;
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人信息ToolStripMenuItem,
            this.相片管理ToolStripMenuItem,
            this.指纹录制ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1432, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务器配置ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 50);
            // 
            // 服务器配置ToolStripMenuItem
            // 
            this.服务器配置ToolStripMenuItem.Name = "服务器配置ToolStripMenuItem";
            this.服务器配置ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.服务器配置ToolStripMenuItem.Text = "服务器配置";
            this.服务器配置ToolStripMenuItem.Click += new System.EventHandler(this.服务器配置ToolStripMenuItem_Click);
            // 
            // 个人信息ToolStripMenuItem
            // 
            this.个人信息ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.个人信息ToolStripMenuItem.Name = "个人信息ToolStripMenuItem";
            this.个人信息ToolStripMenuItem.Size = new System.Drawing.Size(104, 31);
            this.个人信息ToolStripMenuItem.Text = "个人信息";
            this.个人信息ToolStripMenuItem.Click += new System.EventHandler(this.个人信息ToolStripMenuItem_Click_1);
            // 
            // 相片管理ToolStripMenuItem
            // 
            this.相片管理ToolStripMenuItem.Name = "相片管理ToolStripMenuItem";
            this.相片管理ToolStripMenuItem.Size = new System.Drawing.Size(104, 31);
            this.相片管理ToolStripMenuItem.Text = "采集相片";
            this.相片管理ToolStripMenuItem.Click += new System.EventHandler(this.相片管理ToolStripMenuItem_Click);
            // 
            // 指纹录制ToolStripMenuItem
            // 
            this.指纹录制ToolStripMenuItem.Name = "指纹录制ToolStripMenuItem";
            this.指纹录制ToolStripMenuItem.Size = new System.Drawing.Size(104, 31);
            this.指纹录制ToolStripMenuItem.Text = "指纹录制";
            this.指纹录制ToolStripMenuItem.Click += new System.EventHandler(this.指纹录制ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 830);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生信息采集系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ForMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ForMain_FormClosed);
            this.Load += new System.EventHandler(this.ForMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 个人信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 相片管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指纹录制ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 服务器配置ToolStripMenuItem;
    }
}