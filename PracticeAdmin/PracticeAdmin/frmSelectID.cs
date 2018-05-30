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
    public partial class frmSelectID : Form
    {
        public frmSelectID()
        {
            InitializeComponent();
        }

        private String sSqlTouch = clsForm.sSqlTouch;

        private void frmSelectID_Load(object sender, EventArgs e)
        {
            cls1();
        }

        private void cls1()
        {
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch, "NianJi");//查询年级
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboYear.Items.Add(ds.Tables[0].Rows[i][1]);
            DataSet ds1 = new clsSql().sqlSelect1(sSqlTouch, "XueBu");//查询学部
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                cboDepartment.Items.Add(ds1.Tables[0].Rows[i][1]);
        }

        private String strNianJiID = "";
        private String strXueBuID = "";

        //接收学号信息
        public void clsNumber(String strNumber)
        {
            txtNumber.Text = strNumber;
        }

        //刷新年级和学部列表内容
        private void clsRefresh()
        {
            txtNumber.Text = null;
            txtName.Text = null;
            txtTel.Text = null;
            txtIdCard.Text = null;
            rdoMen.Checked = false;
            rdoWomen.Checked = false;
            cboYear.Items.Clear();
            cboDepartment.Items.Clear();
            cboClass.Items.Clear();
            strNianJiID = "";
            strXueBuID = "";
            label1.Visible = false;
            lblNumberY.Visible = false;
            lblNameY.Visible = false;
            lblIdCardY.Visible = false;
            lblTelY.Visible = false;
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch, "NianJi");//查询年级
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboYear.Items.Add(ds.Tables[0].Rows[i][1]);
            DataSet ds1 = new clsSql().sqlSelect1(sSqlTouch, "XueBu");//查询学部
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                cboDepartment.Items.Add(ds1.Tables[0].Rows[i][1]);
        }

        //刷新班级列表内容
        private void clsRefresh1()
        {
            cboClass.Items.Clear();
            DataSet ds5 = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where XueBuID = '" + strXueBuID + "' ");
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                DataSet ds6 = new clsSql().sql1(sSqlTouch, "select * from BanJi where ZhuanYeID = '" + ds5.Tables[0].Rows[i][0].ToString() + "' and NianJiID = '" + strNianJiID + "' ");
                for (int j = 0; j < ds6.Tables[0].Rows.Count; j++)
                    cboClass.Items.Add(ds6.Tables[0].Rows[j][1]);
            }
        }

        //键入学号判断
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar) == false) && (e.KeyChar != '\b'))//判断输入的是否为数字或退格键
                e.Handled = true;//事件结束
        }

        //键入手机号判断
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar) == false) && (e.KeyChar != '\b'))//判断输入的是否为数字或退格键
                e.Handled = true;//事件结束
        }

        //键入身份证判断输入类型
        private void txtIdCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar) == false) && (e.KeyChar != (char)88) && (e.KeyChar != '\b'))//判断输入的是否为数字或X或退格键
                e.Handled = true;//事件结束
        }

        //单击更新按钮
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sSex = "";
            if (rdoMen.Checked == true)
                sSex = rdoMen.Text;
            else if (rdoWomen.Checked == true)
                sSex = rdoWomen.Text;
            if (!(txtNumber.Text != "" && txtName.Text != "" && txtIdCard.Text != "" && txtTel.Text != "" && cboYear.Text != "" && cboDepartment.Text != "" && cboClass.Text != "" && sSex != ""))
            {
                MessageBox.Show("请确认信息填写的完整性！", "提示");
                return;
            }
            if (!(lblNumberY.Visible == true && lblNameY.Visible == true && lblIdCardY.Visible == true && lblTelY.Visible == true && label1.Visible == false))
            {
                MessageBox.Show("请确认各项格式输入正确！", "提示");
                return;
            }
            DialogResult r = MessageBox.Show("是否修改数据?", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r != DialogResult.OK)
                return;
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiMingCheng = '" + cboClass.Text + "' and NianJiID = '" + strNianJiID + "' ");
            if (new clsSql().sql2(sSqlTouch, "update XueSheng set BanJiID = '" + ds.Tables[0].Rows[0][0].ToString() + "' , XingMing = '" + txtName.Text + "' , ShenFenZhengHao = '" + txtIdCard.Text + "' , XingBie = '" + sSex + "' , DianHua = '" + txtTel.Text + "' where XueHao = '" + txtNumber.Text + "'") == true)//执行修改语句
                MessageBox.Show("修改成功！O(∩_∩)O~~~", "提示！");
            else
                MessageBox.Show("修改失败！", "提示！");
        }

        //学年选项改变时触发
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.ToString().Length == 8)
            {
                DataSet ds = new clsSql().sql1(sSqlTouch, "select * from NianJi where NianJiMingCheng = '" + cboYear.Text + "'");//查询年级
                if (ds.Tables[0].Rows.Count > 0)
                    strNianJiID = ds.Tables[0].Rows[0][0].ToString();//获取年级id
                clsRefresh1();
            }
        }

        //学部选项改变时触发
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.ToString().Length == 8)
            {
                DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from XueBu where XueBuMingCheng = '" + cboDepartment.Text + "'");//查询学部
                if (ds1.Tables[0].Rows.Count > 0)
                    strXueBuID = ds1.Tables[0].Rows[0][0].ToString();//获取学部id
                clsRefresh1();
            }
        }

        //单击删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!lblNumberY.Visible)
            {
                MessageBox.Show("请确认学生信息是否存在！", "提示！");
                return;
            }
            DialogResult r = MessageBox.Show("是否删除学生信息?", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r != DialogResult.OK)
                return;
            if (new clsSql().sqlDelete(sSqlTouch, "XueSheng", "XueHao", txtNumber.Text) == true)
            {
                MessageBox.Show("删除成功！O(∩_∩)O~~~", "提示！");
                clsRefresh();
            }
            else
                MessageBox.Show("删除失败！", "提示！");
        }

        //更改学号text时触发
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.ToString().Length == 8)//当输入字符串为八位时
            {
                DataSet ds = new clsSql().sql1(sSqlTouch, "select * from XueSheng where XueHao = '" + txtNumber.Text + "'");//查询学生信息
                if (ds.Tables[0].Rows.Count <= 0)
                    return;
                lblNumberY.Visible = true;
                label1.Visible = false;
                txtName.Text = ds.Tables[0].Rows[0][7].ToString();//显示名字
                txtIdCard.Text = ds.Tables[0].Rows[0][8].ToString();//显示身份证号码
                txtTel.Text = ds.Tables[0].Rows[0][10].ToString();//显示手机号
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
                DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + ds.Tables[0].Rows[0][6].ToString() + "'");//查询班级
                DataSet ds2 = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where ZhuanYeID = '" + ds1.Tables[0].Rows[0][2].ToString() + "'");//查询专业
                DataSet ds3 = new clsSql().sql1(sSqlTouch, "select * from XueBu where XueBuID = '" + ds2.Tables[0].Rows[0][2].ToString() + "'");//查询学部
                DataSet ds4 = new clsSql().sql1(sSqlTouch, "select * from NianJi where NianJiID = '" + ds1.Tables[0].Rows[0][3].ToString() + "'");//查询年级
                cboYear.SelectedItem = ds4.Tables[0].Rows[0][1].ToString();//显示年级
                cboDepartment.SelectedItem = ds3.Tables[0].Rows[0][1].ToString();//显示学部
                cboClass.SelectedItem = ds1.Tables[0].Rows[0][1].ToString();//显示班级
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
            }
            else
            {
                txt1.Text = null;
                txt2.Text = null;
                txt3.Text = null;
                txt4.Text = null;
                label1.Visible = true;
                label2.Visible = false;
                lblNumberY.Visible = false;
                cboYear.SelectedIndex = -1;
                cboDepartment.SelectedIndex = -1;
                cboClass.SelectedIndex=-1;
                pictureBox1.Image = null;
                txtName.Text = null;
                txtIdCard.Text = null;
                txtTel.Text = null;
                rdoMen.Checked = false;
                rdoWomen.Checked = false;
            }
        }

        //更改姓名值触发
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.ToString().Length > 0)
                lblNameY.Visible = true;
            else
                lblNameY.Visible = false;
        }

        //更改身份证值时触发
        private void txtIdCard_TextChanged(object sender, EventArgs e)
        {
            if (txtIdCard.Text.ToString().Length == 18)
            {
                string s = txtIdCard.Text.ToString().Substring(16, 1);
                if ((s == "0") || (s == "2") || (s == "4") || (s == "6") || (s == "8"))
                    rdoWomen.Checked = true;
                else if ((s == "1") || (s == "3") || (s == "5") || (s == "7") || (s == "9"))
                    rdoMen.Checked = true;
                else
                {
                    rdoMen.Checked = false;
                    rdoWomen.Checked = false;
                }
                lblIdCardY.Visible = true;
            }
            else
            {
                lblIdCardY.Visible = false;
                rdoMen.Checked = false;
                rdoWomen.Checked = false;
            }
        }

        //更改电话号值时触发
        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            if (txtTel.Text.ToString().Length == 11)
                lblTelY.Visible = true;
            else
                lblTelY.Visible = false;
        }

        //单击相片
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

        //单击指纹更新
        private void button1_Click(object sender, EventArgs e)
        {
            if (lblNumberY.Visible)
            {
                clsForm.frmTouch1 = new frmTouch();
                clsForm.frmTouch1.MdiParent = this.MdiParent;
                clsForm.frmTouch1.Show();
                clsForm.frmTouch1.clsNumber(txtNumber.Text);
                //clsForm.frmSelectID1 = null;
                //this.Close();
            }
        }

    }
}
