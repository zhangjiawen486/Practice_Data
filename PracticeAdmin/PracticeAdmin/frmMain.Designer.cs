namespace PracticeAdmin
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学号查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学生信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.照片管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指纹管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学部管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学年管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学部管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.专业管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学号解析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.服务器配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ContextMenuStrip = this.contextMenuStrip1;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.信息管理ToolStripMenuItem,
            this.学生信息管理ToolStripMenuItem,
            this.学部管理ToolStripMenuItem,
            this.学号解析ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1351, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 信息管理ToolStripMenuItem
            // 
            this.信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.学号查询ToolStripMenuItem,
            this.班级查询ToolStripMenuItem});
            this.信息管理ToolStripMenuItem.Name = "信息管理ToolStripMenuItem";
            this.信息管理ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.信息管理ToolStripMenuItem.Text = "学生信息查询";
            // 
            // 学号查询ToolStripMenuItem
            // 
            this.学号查询ToolStripMenuItem.Name = "学号查询ToolStripMenuItem";
            this.学号查询ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.学号查询ToolStripMenuItem.Text = "按学号查询";
            this.学号查询ToolStripMenuItem.Click += new System.EventHandler(this.学号查询ToolStripMenuItem_Click);
            // 
            // 班级查询ToolStripMenuItem
            // 
            this.班级查询ToolStripMenuItem.Name = "班级查询ToolStripMenuItem";
            this.班级查询ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.班级查询ToolStripMenuItem.Text = "按班级查询";
            this.班级查询ToolStripMenuItem.Click += new System.EventHandler(this.班级查询ToolStripMenuItem_Click);
            // 
            // 学生信息管理ToolStripMenuItem
            // 
            this.学生信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.照片管理ToolStripMenuItem,
            this.指纹管理ToolStripMenuItem});
            this.学生信息管理ToolStripMenuItem.Name = "学生信息管理ToolStripMenuItem";
            this.学生信息管理ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.学生信息管理ToolStripMenuItem.Text = "学生信息管理";
            // 
            // 照片管理ToolStripMenuItem
            // 
            this.照片管理ToolStripMenuItem.Name = "照片管理ToolStripMenuItem";
            this.照片管理ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.照片管理ToolStripMenuItem.Text = "照片管理";
            this.照片管理ToolStripMenuItem.Click += new System.EventHandler(this.照片管理ToolStripMenuItem_Click);
            // 
            // 指纹管理ToolStripMenuItem
            // 
            this.指纹管理ToolStripMenuItem.Name = "指纹管理ToolStripMenuItem";
            this.指纹管理ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.指纹管理ToolStripMenuItem.Text = "指纹管理";
            this.指纹管理ToolStripMenuItem.Click += new System.EventHandler(this.指纹管理ToolStripMenuItem_Click);
            // 
            // 学部管理ToolStripMenuItem
            // 
            this.学部管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.学年管理ToolStripMenuItem,
            this.学部管理ToolStripMenuItem1,
            this.专业管理ToolStripMenuItem,
            this.班级管理ToolStripMenuItem});
            this.学部管理ToolStripMenuItem.Name = "学部管理ToolStripMenuItem";
            this.学部管理ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.学部管理ToolStripMenuItem.Text = "学校信息管理";
            // 
            // 学年管理ToolStripMenuItem
            // 
            this.学年管理ToolStripMenuItem.Name = "学年管理ToolStripMenuItem";
            this.学年管理ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.学年管理ToolStripMenuItem.Text = "学年管理";
            this.学年管理ToolStripMenuItem.Click += new System.EventHandler(this.学年管理ToolStripMenuItem_Click);
            // 
            // 学部管理ToolStripMenuItem1
            // 
            this.学部管理ToolStripMenuItem1.Name = "学部管理ToolStripMenuItem1";
            this.学部管理ToolStripMenuItem1.Size = new System.Drawing.Size(138, 24);
            this.学部管理ToolStripMenuItem1.Text = "学部管理";
            this.学部管理ToolStripMenuItem1.Click += new System.EventHandler(this.学部管理ToolStripMenuItem1_Click);
            // 
            // 专业管理ToolStripMenuItem
            // 
            this.专业管理ToolStripMenuItem.Name = "专业管理ToolStripMenuItem";
            this.专业管理ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.专业管理ToolStripMenuItem.Text = "专业管理";
            this.专业管理ToolStripMenuItem.Click += new System.EventHandler(this.专业管理ToolStripMenuItem_Click);
            // 
            // 班级管理ToolStripMenuItem
            // 
            this.班级管理ToolStripMenuItem.Name = "班级管理ToolStripMenuItem";
            this.班级管理ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.班级管理ToolStripMenuItem.Text = "班级管理";
            this.班级管理ToolStripMenuItem.Click += new System.EventHandler(this.班级管理ToolStripMenuItem_Click);
            // 
            // 学号解析ToolStripMenuItem
            // 
            this.学号解析ToolStripMenuItem.Name = "学号解析ToolStripMenuItem";
            this.学号解析ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.学号解析ToolStripMenuItem.Text = "学号解析";
            this.学号解析ToolStripMenuItem.Click += new System.EventHandler(this.学号解析ToolStripMenuItem_Click);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 848);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "学生管理后台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学部管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学年管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学部管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 专业管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 班级管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学号查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 班级查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学号解析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 照片管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指纹管理ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 服务器配置ToolStripMenuItem;
    }
}

