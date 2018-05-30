using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Practice
{
    public partial class frmPrompt : Form
    {
        public frmPrompt()
        {
            InitializeComponent();
        }

        private void frmPrompt_Load(object sender, EventArgs e)
        {
            
        }
        public void clsPromp(string sNumber, string sName, string sIdCard, string sTel, string sYear, string sDepartment, string sClass, string sSex)
        {
            txtNumber.Text = sNumber;
            txtName.Text = sName;
            txtIdCard.Text = sIdCard;
            txtTel.Text = sTel;
            txtYear.Text = sYear;
            txtDepartment.Text = sDepartment;
            txtClass.Text = sClass;
            txtSex.Text = sSex;
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            clsFormStatic.frmInfo1.clsSave();
            this.Close();
        }
    }
}
