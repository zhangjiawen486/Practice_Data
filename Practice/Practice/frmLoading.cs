using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Practice
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        //Thread ThreadSql = new Thread(new ThreadStart(method1));
        //ThreadSql.Start();
        public String str = "";

        private void method1()
        {
            for (int i = 0; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(1000);
                method2(i,100);
            }
        }

        private delegate void SetPos(int i, int j);//定义一个引用函数
        private void method2(int i,int j)
        {
            if (this.InvokeRequired)//判断是否为需要invoke方法调用，检测调用是否为非本线程控件。
            {
                SetPos setpos = new SetPos(method2);//将setpos实例化，并且将method2方法添加到setpod上。
                this.Invoke(setpos, new object[] { i, j });//执行setpos中的方法
            }
            else
            {
                this.progressBar1.Value = i ;
            }
        }

        private void frmLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    DialogResult r = MessageBox.Show("是否取消与服务器的连接?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (r != DialogResult.OK)
            //        e.Cancel = true;
            //    else
            //        e.Cancel = false;
            //}
        }

        internal void Invoke()
        {
            throw new NotImplementedException();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            label1.Text = str;
        }
    }
}
