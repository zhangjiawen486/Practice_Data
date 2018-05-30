using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlFile;

namespace Practice
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            clsRefresh();
        }

        private String sSqlTouch = clsFormStatic.sSqlTouch;
        private String strNianJiID = "";
        private String strXueBuID = "";

        //刷新年级和学部列表内容
        private void clsRefresh()
        {
            txtName.Text = null;
            txtTel.Text = null;
            txtIdCard.Text = null;
            rdoMen.Checked = false;
            rdoWomen.Checked = false;
            strNianJiID = "";
            strXueBuID = "";
            cboYear.SelectedIndex = -1;
            cboDepartment.SelectedIndex = -1;
            cboClass.SelectedIndex = -1;
            label1.Visible = false;
            lblNumberY.Visible = false;
            lblNameY.Visible = false;
            lblIdCardY.Visible = false;
            lblTelY.Visible = false;
        }

        //刷新学年和学部信息
        private void clsRefresh0()
        {
            cboYear.Items.Clear();
            cboDepartment.Items.Clear();
            cboClass.Items.Clear();
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch,"NianJi");//查询年级
            DataSet ds1 = new clsSql().sqlSelect1(sSqlTouch, "XueBu");//查询学部
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboYear.Items.Add(ds.Tables[0].Rows[i][1]);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                cboDepartment.Items.Add(ds1.Tables[0].Rows[i][1]);
        }

        //刷新班级列表内容
        private void clsRefresh1()
        {
            cboClass.Items.Clear();
            DataSet ds2 = new clsSql().sql1(sSqlTouch,"select * from ZhuanYe where XueBuID = '" + strXueBuID + "' ");
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                DataSet ds3 = new clsSql().sql1(sSqlTouch,"select * from BanJi where ZhuanYeID = '" + ds2.Tables[0].Rows[i][0].ToString() + "' and NianJiID = '" + strNianJiID + "' ");
                for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                    cboClass.Items.Add(ds3.Tables[0].Rows[j][1]);
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

        //单击清除按钮
        private void btnClean_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("是否清空数据?", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r == DialogResult.OK)
            {
                txtNumber.Text = null;
                clsRefresh();
                clsRefresh0();
            }
        }

        //单击保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sSex = "";
            if (rdoMen.Checked)
                sSex = rdoMen.Text;
            else if (rdoWomen.Checked)
                sSex = rdoWomen.Text;
            if (txtNumber.Text != "" && txtName.Text != "" && txtIdCard.Text != "" && txtTel.Text != "" && cboYear.Text != "" && cboDepartment.Text != "" && cboClass.Text != "" && sSex != "")
            {
                if ((lblNumberY.Visible == true) && (lblNameY.Visible == true) && (lblIdCardY.Visible == true) && (lblTel.Visible == true) && (label1.Visible == false))
                {
                    frmPrompt frmPrompt1 = new frmPrompt();
                    frmPrompt1.clsPromp(txtNumber.Text, txtName.Text, txtIdCard.Text, txtTel.Text, cboYear.Text, cboDepartment.Text, cboClass.Text, sSex);
                    frmPrompt1.ShowDialog();
                }
                else
                    MessageBox.Show("请确认各项格式输入正确！", "提示");
            }
            else
                MessageBox.Show("请确认信息填写的完整性！","提示");
        }

        //学年选项改变时触发
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new clsSql().sql1(sSqlTouch,"select * from NianJi where NianJiMingCheng = '" + cboYear.Text + "'");//查询年级
            if (ds.Tables[0].Rows.Count > 0)
                strNianJiID = ds.Tables[0].Rows[0][0].ToString();//获取年级id
            if (cboDepartment.SelectedIndex == -1)
                return;
            clsRefresh1();
        }

        //学部选项改变时触发
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new clsSql().sql1(sSqlTouch,"select * from XueBu where XueBuMingCheng = '" + cboDepartment.Text + "'");//查询学部
            if (ds.Tables[0].Rows.Count > 0)
                strXueBuID = ds.Tables[0].Rows[0][0].ToString();//获取学部id
            if (cboYear.SelectedIndex == -1)
                return;
            clsRefresh1();
        }

        //个人信息保存
        public void clsSave()
        {
            string sSex = "";
            if (rdoMen.Checked)
                sSex = rdoMen.Text;
            else if (rdoWomen.Checked)
                sSex = rdoWomen.Text;
            DataSet ds = new clsSql().sql1(sSqlTouch,"select * from BanJi where BanJiMingCheng = '" + cboClass.Text + "' and NianJiID = '" + strNianJiID + "' ");
            if (new clsSql().sql2(sSqlTouch,"insert into XueSheng (XueHao,BanJiID,XingMing,ShenFenZhengHao,XingBie,DianHua) values ('" + txtNumber.Text + "','" + ds.Tables[0].Rows[0][0].ToString() + "','" + txtName.Text + "','" + txtIdCard.Text + "','"+sSex+"','" + txtTel.Text + "')") == true)//执行添加语句
            {
                MessageBox.Show("添加成功O(∩_∩)O~~~", "提示！");
                txtNumber.Text = null;
                clsRefresh();
            }
            else
                MessageBox.Show("添加失败！", "提示！");
        }

        //学号值改变时触发
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.ToString().Length == 8)//当输入字符串为八位时
            {
                if (new clsSql().sqlSelect2(sSqlTouch,"XueSheng", "XueHao", txtNumber.Text.ToString()))
                {
                    label1.Visible = true;
                    lblNumberY.Visible = false;
                }
                else
                {
                    lblNumberY.Visible = true;
                    label1.Visible = false;
                }
                DataSet ds = new clsSql().sql1(sSqlTouch,"select * from GuiFan where ID = '" + txtNumber.Text.ToString().Substring(0, 6) + "'");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    cboYear.SelectedIndex = -1;
                    cboDepartment.SelectedIndex = -1;
                    cboClass.SelectedIndex = -1;
                    return;
                }
                cboYear.SelectedItem = ds.Tables[0].Rows[0][1].ToString();
                cboDepartment.SelectedItem = ds.Tables[0].Rows[0][2].ToString();
                cboClass.SelectedItem = ds.Tables[0].Rows[0][4].ToString();
            }
            else
            {
                clsRefresh();
                lblNumberY.Visible = false;
                label1.Visible = false;
            }
        }

        //姓名值改变时触发
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.ToString().Length > 0)
                lblNameY.Visible = true;
            else
                lblNameY.Visible = false;
        }

        //身份证值改变时触发
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

        //手机号值改变的时候触发
        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            if (txtTel.Text.ToString().Length == 11)
                lblTelY.Visible = true;
            else
                lblTelY.Visible = false;
        }


    }        
}
