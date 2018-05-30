using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlFile;
using System.Threading;

namespace Practice
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public String sSqlTouch = "sqlConfig";
        private bool b = true;
        Thread threadLoading;
        frmLoading frmLoading1;

        private void s()
        {
            frmLoading1= new frmLoading();
            frmLoading1.str = "尝试与服务器进行连接...";
            frmLoading1.ShowDialog();
        }

        /// <summary>
        /// 关闭窗体
        /// </summary> 
        private bool FormClose()
        {
            if (b)
            {
                threadLoading = new Thread(new ThreadStart(s));
                threadLoading.IsBackground = true;
                threadLoading.Start();
                String str = new SqlFile.clsSql().sqlOpen1(sSqlTouch);
                if (frmLoading1.InvokeRequired)//判断是否有其他线程想访问
                {
                    Action act = () => { frmLoading1.Close(); };//封装一个窗体关闭的方法
                    frmLoading1.Invoke(act);//在拥有该控件的线程上执行该方法
                }
                if (threadLoading != null)
                    threadLoading.Abort();
                if (str == "")
                    b = false;
                else
                {
                    MessageBox.Show(str);
                    return false;
                }
            }
            if (clsFormStatic.frmInfo1 != null)
            {
                clsFormStatic.frmInfo1.Close();
                clsFormStatic.frmInfo1 = null;
            }
            if (clsFormStatic.frmPhoto1 != null)
            {
                clsFormStatic.frmPhoto1.Close();
                clsFormStatic.frmPhoto1 = null;
            }
            if (clsFormStatic.frmTouch1 != null)
            {
                clsFormStatic.frmTouch1.Close();
                clsFormStatic.frmTouch1 = null;
            }
            return true;
        }

        private void 相片管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsFormStatic.frmPhoto1 == null)
            {
                clsFormStatic.frmPhoto1 = new frmPhoto();
                clsFormStatic.frmPhoto1.MdiParent = this;
                clsFormStatic.frmPhoto1.Show();
            }
        }

        private void 指纹录制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsFormStatic.frmTouch1 == null)
            {
                clsFormStatic.frmTouch1 = new frmTouch();
                clsFormStatic.frmTouch1.MdiParent = this;
                clsFormStatic.frmTouch1.Show();
            }
        }

        private void 个人信息ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsFormStatic.frmInfo1 == null)
            {
                clsFormStatic.frmInfo1 = new frmInfo();
                clsFormStatic.frmInfo1.MdiParent = this;
                clsFormStatic.frmInfo1.Show();
            }
        }

        private void ForMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult r = MessageBox.Show("确定要退出程序?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r != DialogResult.OK)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
        }

        private void ForMain_Load(object sender, EventArgs e)
        {

        }

        private void ForMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);//关闭所有线程
        }

        private void 服务器配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b = true;
            SqlFile.frmConfig frmConfig1 = new frmConfig();
            frmConfig1.sServer = "sqlConfig";
            frmConfig1.ShowDialog(this);
        }
    }
}
