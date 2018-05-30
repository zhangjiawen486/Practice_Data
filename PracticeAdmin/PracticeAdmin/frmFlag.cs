using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlFile;

namespace PracticeAdmin
{
    public partial class frmFlag : Form
    {
        public frmFlag()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsRefresh();
        }

        bool b = true;
        private String sSqlTouch = clsForm.sSqlTouch;

        //刷新学年，学部信息
        private void clsRefresh()
        {
            b = true;
            cboYear.Items.Clear();
            cboDepartment.Items.Clear();
            cboMajor.Items.Clear();
            cboClass.Items.Clear();
            txtFlag.Text = null;
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch,"NianJi");//查询
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboYear.Items.Add(ds.Tables[0].Rows[i][0] + "#    *" + ds.Tables[0].Rows[i][1]);
            DataSet ds1 = new clsSql().sqlSelect1(sSqlTouch, "XueBu");//查询
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                cboDepartment.Items.Add(ds1.Tables[0].Rows[i][0] + "#    *" + ds1.Tables[0].Rows[i][1]);
        }

        //刷新专业信息
        private void clsRefresh1()
        {
            cboMajor.Items.Clear();
            cboClass.Items.Clear();
            if (cboYear.SelectedIndex == -1 || cboDepartment.SelectedIndex == -1)
                return;
            DataSet ds = new clsSql().sql1(sSqlTouch,"select * from ZhuanYe where XueBuID = '" + cboDepartment.Text.Substring(0, cboDepartment.Text.IndexOf("#")) + "' ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboMajor.Items.Add(ds.Tables[0].Rows[i][0] + "#    *" + ds.Tables[0].Rows[i][1]);
        }

        //选择学部时触发
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsRefresh1();
        }

        //选择学年时触发
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsRefresh1();
        }

        //选择专业时触发
        private void cboMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboClass.Items.Clear();
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from BanJi where ZhuanYeID = '" + cboMajor.Text.Substring(0, cboMajor.Text.IndexOf("#")) + "' and NianJiID = '" + cboYear.Text.Substring(0, cboYear.Text.IndexOf("#")) + "' ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboClass.Items.Add(ds.Tables[0].Rows[i][1]);
        }

        //选择班级时触发
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            String NianJi = cboYear.Text.Substring(cboYear.Text.IndexOf("*")+1, cboYear.Text.ToString().Length - cboYear.Text.IndexOf("*")-1);
            String XueBu = cboDepartment.Text.Substring(cboDepartment.Text.IndexOf("*")+1, cboDepartment.Text.ToString().Length - cboDepartment.Text.IndexOf("*")-1);
            String ZhuanYe = cboMajor.Text.Substring(cboMajor.Text.IndexOf("*")+1, cboMajor.Text.ToString().Length - cboMajor.Text.IndexOf("*")-1);
            String BanJi = cboClass.Text.ToString();
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from GuiFan where NianJiMingCheng = '" + NianJi + "' and XueBuMingCheng = '" + XueBu + "' and ZhuanYeMingCheng = '" + ZhuanYe + "' and BanJiMingCheng = '" + BanJi + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtFlag.Text = ds.Tables[0].Rows[0][0].ToString();
                b = true;
            }
            else
            {
                txtFlag.Text = null;
                b = false;
            }
        }

        //单击修改时触发
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboYear.SelectedIndex == -1 || cboDepartment.SelectedIndex == -1 || cboMajor.SelectedIndex == -1 || cboClass.SelectedIndex == -1)
                return;
            String NianJi = cboYear.Text.Substring(cboYear.Text.IndexOf("*") + 1, cboYear.Text.ToString().Length - cboYear.Text.IndexOf("*") - 1);
            String XueBu = cboDepartment.Text.Substring(cboDepartment.Text.IndexOf("*") + 1, cboDepartment.Text.ToString().Length - cboDepartment.Text.IndexOf("*") - 1);
            String ZhuanYe = cboMajor.Text.Substring(cboMajor.Text.IndexOf("*") + 1, cboMajor.Text.ToString().Length - cboMajor.Text.IndexOf("*") - 1);
            String BanJi = cboClass.Text.ToString();
            if (b)//修改指令
            {
                if (new clsSql().sql2(sSqlTouch, "update GuiFan set ID = '" + txtFlag.Text + "' where NianJiMingCheng = '" + NianJi + "' and XueBuMingCheng = '" + XueBu + "' and ZhuanYeMingCheng = '" + ZhuanYe + "' and BanJiMingCheng = '" + BanJi + "'"))//添加
                    MessageBox.Show("操作成功O(∩_∩)O~~~", "提示！");
                else
                    MessageBox.Show("操作失败！！！", "提示！");
            }
            else//添加
            {
                if (new clsSql().sql2(sSqlTouch, "insert into GuiFan (ID,NianJiMingCheng,XueBuMingCheng,ZhuanYeMingCheng,BanJiMingCheng) values ('" + txtFlag.Text + "','" + NianJi + "','" + XueBu + "','" + ZhuanYe + "','" + BanJi + "')"))//添加
                    MessageBox.Show("操作成功O(∩_∩)O~~~", "提示！");
                else
                    MessageBox.Show("操作失败！！！", "提示！");
            }
        }

        //单击删除时触发
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (new clsSql().sqlDelete(sSqlTouch, "GuiFan", "ID", txtFlag.Text))
                MessageBox.Show("删除成功！", "提示");
            else
                MessageBox.Show("删除失败！", "提示");
        }

        //键入学号
        private void txtFlag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar) == false) && (e.KeyChar != '\b'))//判断输入的是否为数字或退格键
                e.Handled = true;//事件结束
        }

        private void frmFlag_Load(object sender, EventArgs e)
        {
            clsRefresh();
        }
    }
}
