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
    public partial class frmSelect : Form
    {
        public frmSelect()
        {
            InitializeComponent();
        }

        private String strNianJiID;
        private String strXueBuID;
        private String sSqlTouch = clsForm.sSqlTouch;

        private void frmSelect_Load(object sender, EventArgs e)
        {
            clsRefresh1();
        }

        //清空显示
        private void clsRefresh()
        {
            txt1.Text = null;
            txt2.Text = null;
            txt3.Text = null;
            txt4.Text = null;
            txtNumber.Text = null;
            txtName.Text = null;
            txtIdCard.Text = null;
            txtTel.Text = null;
            pictureBox1.Image = null;
            label2.Visible = false;
            rdoMen.Checked = false;
            rdoWomen.Checked = false;
            lblStudent.Text = "" ;
            lstStudent.Items.Clear();
        }

        //刷新学年和学部列表
        private void clsRefresh1()
        {
            strNianJiID = "";
            strXueBuID = "";
            cboYear.Items.Clear();
            cboDepartment.Items.Clear();
            cboClass.Items.Clear();
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch,"NianJi");//查询
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboYear.Items.Add(ds.Tables[0].Rows[i][1]);
            DataSet ds1 = new clsSql().sqlSelect1(sSqlTouch, "XueBu");//查询
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                cboDepartment.Items.Add(ds1.Tables[0].Rows[i][1]);
        }

        //刷新班级列表
        private void clsRefresh2()
        {
            clsRefresh();
            cboClass.Items.Clear();
            label2.Visible = false;
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where XueBuID = '" + strXueBuID + "' ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from BanJi where ZhuanYeID = '" + ds.Tables[0].Rows[i][0].ToString() + "' and NianJiID = '" + strNianJiID + "' ");
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    cboClass.Items.Add(ds1.Tables[0].Rows[j][1]);
            }
        }

        //刷新班级信息
        private void clsRefresh3()
        {
            clsRefresh();
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiMingCheng = '" + cboClass.Text + "'");//查询班级
            DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from XueSheng where BanJiID = '" + ds.Tables[0].Rows[0][0] + "'");//查询学部
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                lstStudent.Items.Add(ds1.Tables[0].Rows[i][0] + "     " + ds1.Tables[0].Rows[i][7]);
            lblStudent.Text = "共计：" + ds1.Tables[0].Rows.Count + " 人";
        }

        //选择年级时
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from NianJi where NianJiMingCheng = '" + cboYear.Text + "'");//查询年级
            if (ds.Tables[0].Rows.Count > 0)
                strNianJiID = ds.Tables[0].Rows[0][0].ToString();//获取年级id
            clsRefresh2();
        }

        //选择学部时
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from XueBu where XueBuMingCheng = '" + cboDepartment.Text + "'");//查询学部
            if (ds1.Tables[0].Rows.Count > 0)
                strXueBuID = ds1.Tables[0].Rows[0][0].ToString();//获取学部id
            clsRefresh2();
        }

        //选择班级时
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsRefresh3();
        }

        //选择学生时
        private void lstStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudent.SelectedIndex < 0)
                return;
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from XueSheng where XueHao = '" + lstStudent.Text.ToString().Substring(0, 8) + "'");//查询学生
            if (ds.Tables[0].Rows.Count <= 0)
                return;
            txtNumber.Text = ds.Tables[0].Rows[0][0].ToString();//显示学号
            txtName.Text = ds.Tables[0].Rows[0][7].ToString();//显示名字
            txtIdCard.Text = ds.Tables[0].Rows[0][8].ToString();//显示身份证号码
            txtTel.Text = ds.Tables[0].Rows[0][10].ToString();//显示手机号
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
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                pictureBox1.Image = new Bitmap(new MemoryStream((byte[])ds.Tables[0].Rows[0][1]));//显示照片
                label2.Visible = false;
            }
            else
            {
                pictureBox1.Image = null;
                label2.Visible = true;
            }
        }

        //单击照片
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text != "")
            {
                clsForm.frmPhoto1 = new frmPhoto();
                clsForm.frmPhoto1.MdiParent = this.MdiParent;
                clsForm.frmPhoto1.Show();
                clsForm.frmPhoto1.clsNumber(txtNumber.Text);
                //clsForm.frmSelect1 = null;
                //this.Close();
            }
        }

        //单击刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsRefresh3();
        }

        //单击指纹更新按钮
        private void btnTouch_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text != "")
            {
                clsForm.frmTouch1 = new frmTouch();
                clsForm.frmTouch1.MdiParent = this.MdiParent;
                clsForm.frmTouch1.Show();
                clsForm.frmTouch1.clsNumber(txtNumber.Text);
                //clsForm.frmSelect1 = null;
                //this.Close();
            }
        }

        //单击管理按钮
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text != "")
            {
                clsForm.frmSelectID1 = new frmSelectID();
                clsForm.frmSelectID1.MdiParent = this.MdiParent;
                clsForm.frmSelectID1.Show();
                clsForm.frmSelectID1.clsNumber(txtNumber.Text);
                //clsForm.frmSelect1 = null;
                //this.Close();
            }
        }

        //单击删除
        private void btnClean_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text == "")
            {
                MessageBox.Show("请选择学生信息！", "提示！");
                return;
            }
            DialogResult r = MessageBox.Show("是否删除学生信息?", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r != DialogResult.OK)
                return;
            if (new clsSql().sqlDelete(sSqlTouch, "XueSheng", "XueHao", txtNumber.Text))
            {
                MessageBox.Show("删除成功！O(∩_∩)O~~~", "提示！");
                clsRefresh2();
            }
            else
                MessageBox.Show("删除失败！", "提示！");
        }

    }
}
