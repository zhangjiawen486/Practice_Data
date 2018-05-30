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


namespace PracticeAdmin
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
            frmLoading1 = new frmLoading();
            frmLoading1.str = "尝试与服务器进行连接...";
            frmLoading1.ShowDialog();
        }

        //关闭窗体
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
            if (clsForm.frmSelect1 != null)
            {
                clsForm.frmSelect1.Close();
                clsForm.frmSelect1 = null;
            }
            if (clsForm.frmSelectID1 != null)
            {
                clsForm.frmSelectID1.Close();
                clsForm.frmSelectID1 = null;
            }
            if (clsForm.frmYear1 != null)
            {
                clsForm.frmYear1.Close();
                clsForm.frmYear1 = null;
            }
            if (clsForm.frmClass1 != null)
            {
                clsForm.frmClass1.Close();
                clsForm.frmClass1 = null;
            }
            if (clsForm.frmDepartment1 != null)
            {
                clsForm.frmDepartment1.Close();
                clsForm.frmDepartment1 = null;
            }
            if (clsForm.frmFlag1 != null)
            {
                clsForm.frmFlag1.Close();
                clsForm.frmFlag1 = null;
            }
            if (clsForm.frmMajor1 != null)
            {
                clsForm.frmMajor1.Close();
                clsForm.frmMajor1 = null;
            }
            if (clsForm.frmPhoto1 != null)
            {
                clsForm.frmPhoto1.Close();
                clsForm.frmPhoto1 = null;
            }
            if (clsForm.frmTouch1 != null)
            {
                clsForm.frmTouch1.Close();
                clsForm.frmTouch1 = null;
            }
            return true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }


        private void 学年管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmYear1 == null)
            {
                clsForm.frmYear1 = new frmYear();
                clsForm.frmYear1.MdiParent = this;
                clsForm.frmYear1.Show();
            }
        }

        private void 学部管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmDepartment1 == null)
            {
                clsForm.frmDepartment1 = new frmDepartment();
                clsForm.frmDepartment1.MdiParent = this;
                clsForm.frmDepartment1.Show();
            }
        }

        private void 专业管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmMajor1 == null)
            {
                clsForm.frmMajor1 = new frmMajor();
                clsForm.frmMajor1.MdiParent = this;
                clsForm.frmMajor1.Show();
            }
        }

        private void 班级管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmClass1 == null)
            {
                clsForm.frmClass1 = new frmClass();
                clsForm.frmClass1.MdiParent = this;
                clsForm.frmClass1.Show();
            }
        }

        private void 学号解析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmFlag1 == null)
            {
                clsForm.frmFlag1 = new frmFlag();
                clsForm.frmFlag1.MdiParent = this;
                clsForm.frmFlag1.Show();
            }
        }

        private void 学号查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmSelectID1 == null)
            {
                clsForm.frmSelectID1 = new frmSelectID();
                clsForm.frmSelectID1.MdiParent = this;
                clsForm.frmSelectID1.Show();
            }
        }

        private void 班级查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmSelect1 == null)
            {
                clsForm.frmSelect1 = new frmSelect();
                clsForm.frmSelect1.MdiParent = this;
                clsForm.frmSelect1.Show();
            }
        }

        private void 照片管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmPhoto1 == null)
            {
                clsForm.frmPhoto1 = new frmPhoto();
                clsForm.frmPhoto1.MdiParent = this;
                clsForm.frmPhoto1.Show();
            }
        }

        private void 指纹管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormClose())
                return;
            if (clsForm.frmTouch1 == null)
            {
                clsForm.frmTouch1 = new frmTouch();
                clsForm.frmTouch1.MdiParent = this;
                clsForm.frmTouch1.Show();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);//关闭所有窗体线程
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
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

        private void 服务器配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b = true;
            SqlFile.frmConfig frmConfig1 = new frmConfig();
            frmConfig1.sServer = "sqlConfig";
            frmConfig1.ShowDialog(this);
        }
    }
}
