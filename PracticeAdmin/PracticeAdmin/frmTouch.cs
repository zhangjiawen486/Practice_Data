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

namespace PracticeAdmin
{
    public partial class frmTouch : Form
    {
        public frmTouch()
        {
            InitializeComponent();
        }

        private String sSqlTouch = clsForm.sSqlTouch;

        private void frmTouch_Load(object sender, EventArgs e)
        {

        }
        
        //输入学号查询指纹信息
        public void clsNumber(String strNumber)
        {
            txtNumber.Text = strNumber;
        }

        //清空信息
        private void clsRefresh()
        {
            lblNumberY.Visible = false;
            txtName.Text = null;
            pictureBox1.Image = null;
            label1.Visible = false;
            txtYear.Text = null;
            txtDepartment.Text = null;
            txtMajor.Text = null;
            txtClass.Text = null;
            rdoMen.Checked = false;
            rdoWomen.Checked = false;
            txt1.Text = null;
            txt2.Text = null;
            txt3.Text = null;
            txt4.Text = null;
        }

        //查询学生信息
        private void clsInfo()
        {
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from XueSheng where XueHao = '" + txtNumber.Text + "'");//查询学生信息
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblNumberY.Visible = true;
                txtName.Text = ds.Tables[0].Rows[0][7].ToString();//导出姓名
                if (ds.Tables[0].Rows[0][1].ToString() != "")
                {
                    pictureBox1.Image = new Bitmap(new MemoryStream((byte[])ds.Tables[0].Rows[0][1]));//显示照片
                    label1.Visible = false;
                }
                else
                {
                    pictureBox1.Image = null;
                    label1.Visible = true;
                }
                DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + ds.Tables[0].Rows[0][6].ToString() + "'");//查询班级
                DataSet ds2 = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where ZhuanYeID = '" + ds1.Tables[0].Rows[0][2].ToString() + "'");//查询专业
                DataSet ds3 = new clsSql().sql1(sSqlTouch, "select * from XueBu where XueBuID = '" + ds2.Tables[0].Rows[0][2].ToString() + "'");//查询学部
                DataSet ds4 = new clsSql().sql1(sSqlTouch, "select * from NianJi where NianJiID = '" + ds1.Tables[0].Rows[0][3].ToString() + "'");//查询年级
                txtYear.Text = ds4.Tables[0].Rows[0][1].ToString();//显示年级
                txtDepartment.Text = ds3.Tables[0].Rows[0][1].ToString();//显示学部
                txtMajor.Text = ds2.Tables[0].Rows[0][1].ToString();//显示专业
                txtClass.Text = ds1.Tables[0].Rows[0][1].ToString();//显示班级
                if (ds.Tables[0].Rows[0][9].ToString() == "男")
                {
                    rdoMen.Checked = true;
                    rdoWomen.Checked = false;
                }
                else if (ds.Tables[0].Rows[0][9].ToString() == "女")
                {
                    rdoMen.Checked = false;
                    rdoWomen.Checked = true;
                }
                else
                {
                    rdoMen.Checked = false;
                    rdoWomen.Checked = false;
                }
                if (ds.Tables[0].Rows[0][2].ToString() != "")
                    txt1.Text = "存在";
                else
                    txt1.Text = "null";
                if (ds.Tables[0].Rows[0][3].ToString() != "")
                    txt2.Text = "存在";
                else
                    txt2.Text = "null";
                if (ds.Tables[0].Rows[0][4].ToString() != "")
                    txt3.Text = "存在";
                else
                    txt3.Text = "null";
                if (ds.Tables[0].Rows[0][5].ToString() != "")
                    txt4.Text = "存在";
                else
                    txt4.Text = "null";
            }
            else
                clsRefresh();
        }

        //学号改变时触发
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.ToString().Length == 8)//当输入字符串为八位时
                clsInfo();
            else
                clsRefresh();
        }

        //键入学号
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar) == false) && (e.KeyChar != '\b'))//判断输入的是否为数字或退格键
                e.Handled = true;//事件结束
        }

        //删除指纹
        private void clsDelete(String str)
        {
            DialogResult r = MessageBox.Show("是否删除指纹?", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r != DialogResult.OK)
                return;
            if (new clsSql().sql2(sSqlTouch, "update XueSheng set " + str + " = null where XueHao = '" + txtNumber.Text + "'"))
            {
                MessageBox.Show("删除成功！O(∩_∩)O~~~", "提示！");
                clsInfo();
            }
            else
                MessageBox.Show("删除失败！", "提示！");
        }

        //单击删除指纹1
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "存在")
                return;
            clsDelete("ZuoShou1");
        }

        //单击删除指纹2
        private void button2_Click(object sender, EventArgs e)
        {
            if (txt2.Text != "存在")
                return;
            clsDelete("ZuoShou2");
        }

        //单击删除指纹3
        private void button3_Click(object sender, EventArgs e)
        {
            if (txt3.Text != "存在")
                return;
            clsDelete("YouShou1");
        }

        //单击删除指纹4
        private void button4_Click(object sender, EventArgs e)
        {
            if (txt4.Text != "存在")
                return;
            clsDelete("YouShou2");
        }

        //单击生成证明按钮
        private void btnProve_Click(object sender, EventArgs e)
        {
            frmProve frmProve1 = new frmProve();
            frmProve1.ShowDialog(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (lblNumberY.Visible)
            {
                clsForm.frmPhoto1 = new frmPhoto();
                clsForm.frmPhoto1.MdiParent = this.MdiParent;
                clsForm.frmPhoto1.Show();
                clsForm.frmPhoto1.clsNumber(txtNumber.Text);
                //clsForm.frmSelectID1 = null;
                //this.Close();
            }
        }
    }
}
