using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlFile;
using System.IO;
using System.Threading;

namespace PracticeClient
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private String sIdCard = "";
        private String sSqlTouch = clsFormStatic.sSqlTouch;
        public string sNumber="";

        private void frmStudent_Load(object sender, EventArgs e)
        {
            Student1(sNumber);
        }

        /// <summary>
        /// 加载学生信息
        /// </summary>
        /// <param name="sNumber">学生学号</param>
        private void Student1(string strNumber)
        {
            DataSet ds = new SqlFile.clsSql().sqlSelect3(sSqlTouch, "XueSheng", "XueHao", strNumber);
            if (ds.Tables[0].Rows.Count <= 0)
                return;
            txtNumber.Text = ds.Tables[0].Rows[0][0].ToString();//显示学号
            txtName.Text = ds.Tables[0].Rows[0][7].ToString();//显示名字
            rdoMale.Checked = false;
            rdoLady.Checked = false;
            if (ds.Tables[0].Rows[0][9].ToString() == "男")
                rdoMale.Checked = true;
            else if (ds.Tables[0].Rows[0][9].ToString() == "女")
                rdoLady.Checked = true;
            DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + ds.Tables[0].Rows[0][6].ToString() + "'");//查询班级
            DataSet ds2 = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where ZhuanYeID = '" + ds1.Tables[0].Rows[0][2].ToString() + "'");//查询专业
            DataSet ds3 = new clsSql().sql1(sSqlTouch, "select * from XueBu where XueBuID = '" + ds2.Tables[0].Rows[0][2].ToString() + "'");//查询学部
            DataSet ds4 = new clsSql().sql1(sSqlTouch, "select * from NianJi where NianJiID = '" + ds1.Tables[0].Rows[0][3].ToString() + "'");//查询年级
            txtYear.Text = ds4.Tables[0].Rows[0][1].ToString();//显示年级
            txtDepartment.Text = ds3.Tables[0].Rows[0][1].ToString();//显示学部
            txtMajor.Text = ds2.Tables[0].Rows[0][1].ToString();//显示专业
            txtClass.Text = ds1.Tables[0].Rows[0][1].ToString();//显示班级
            txtTel.Text = ds.Tables[0].Rows[0][10].ToString();//显示手机号
            checkBox2.Checked = false;
            sIdCard = ds.Tables[0].Rows[0][8].ToString();
            txtIdCard.Text = sIdCard.Substring(0, 6) + "********" + sIdCard.Substring(14);//显示身份证号码
            if (ds.Tables[0].Rows[0][1].ToString() != "")
                pictureBox1.Image = new Bitmap(new MemoryStream((byte[])ds.Tables[0].Rows[0][1]));//显示照片
            if (ds.Tables[0].Rows[0][2].ToString() != "")
                txtTouch1.Text = "存在";
            else
                txtTouch1.Text = "null";
            if (ds.Tables[0].Rows[0][3].ToString() != "")
                txtTouch2.Text = "存在";
            else
                txtTouch2.Text = "null";
            if (ds.Tables[0].Rows[0][4].ToString() != "")
                txtTouch3.Text = "存在";
            else
                txtTouch3.Text = "null";
            if (ds.Tables[0].Rows[0][5].ToString() != "")
                txtTouch4.Text = "存在";
            else
                txtTouch4.Text = "null";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (sIdCard.Length != 18)
                return;
            if (checkBox2.Checked)
            {
                txtIdCard.Text = sIdCard;
            }
            else
            {
                String str = sIdCard.Substring(0, 6) + "********" + sIdCard.Substring(14);
                txtIdCard.Text = str;
            }
        }

    }
}
