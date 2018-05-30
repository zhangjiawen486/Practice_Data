using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PracticeAdmin
{
    public partial class frmProve : Form
    {
        public frmProve()
        {
            InitializeComponent();
        }

        private void frmProve_Load(object sender, EventArgs e)
        {

        }


        //单击确定时触发
        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        //单击取消时触发
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //输入word文档
        private void InputWord()
        {
            //if (File.Exists("./" + "补录人员文档" + ".word"))
                //File.Open
        }

        //输出word文档
        private void OnputWord()
        {

        }
    }
}
