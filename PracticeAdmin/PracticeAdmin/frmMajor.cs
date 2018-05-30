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
    public partial class frmMajor : Form
    {
        private String strXueBuID = "";
        private String sSqlTouch = clsForm.sSqlTouch;

        public frmMajor()
        {
            InitializeComponent();
        }

        private void frmMajor_Load(object sender, EventArgs e)
        {
            clsRefresh1();
        }

        //学部刷新
        private void clsRefresh1()
        {
            lstMajor.Items.Clear();
            strXueBuID = "";
            cboDepartment.Items.Clear();
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch,"XueBu");//查询
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboDepartment.Items.Add(ds.Tables[0].Rows[i][1]);
            txtAdd.Text = "";
            txtUpdate.Text = "";
        }

        //专业刷新
        private void clsRefresh2()
        {
            lstMajor.Items.Clear();
            DataSet ds1 = new clsSql().sql1(sSqlTouch,"select * from XueBu where XueBuMingCheng = '" + cboDepartment.Text + "' ");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                strXueBuID = ds1.Tables[0].Rows[0][0].ToString();
                DataSet ds2 = new clsSql().sql1(sSqlTouch,"select * from ZhuanYe where XueBuID = '" + strXueBuID + "' ");
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    lstMajor.Items.Add(ds2.Tables[0].Rows[i][1]);
            }
            txtAdd.Text = "";
            txtUpdate.Text = "";
        }

        //单击刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsRefresh1();
        }

        //改变下拉列表内选项时触发
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsRefresh2();
        }

        //单击添加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex >= 0)
            {
                if (txtAdd.Text != "")
                {
                    if (new clsSql().sqlSelect2(sSqlTouch,"ZhuanYe", "ZhuanYeMingCheng", txtAdd.Text) == false)
                    {
                        if (new clsSql().sql2(sSqlTouch, "insert into ZhuanYe (ZhuanYeMingCheng,XueBuID) values ('" + txtAdd.Text + "','" + strXueBuID + "')") == true)//添加
                            MessageBox.Show("添加成功O(∩_∩)O~~~", "提示！");
                        else
                            MessageBox.Show("添加失败！", "提示！");
                    }
                    else
                        MessageBox.Show("该专业已存在，请确认后再添加！", "提示！");
                }
                else
                    MessageBox.Show("请输入要添加的专业", "提示！");
            }
            else
                MessageBox.Show("请先选择要添加专业的学部！", "提示！");
            clsRefresh2();
        }

        //lstMajor控件选项改变时触发
        private void lstMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMajor.SelectedIndex >= 0)
                txtUpdate.Text = lstMajor.SelectedItem.ToString();
        }

        //单击删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex >= 0)
            {
                if (txtUpdate.Text != "")
                {
                    if (new clsSql().sqlSelect2(sSqlTouch, "ZhuanYe", "ZhuanYeMingCheng", txtUpdate.Text))
                    {
                        if (new clsSql().sql2(sSqlTouch, "delete from ZhuanYe where ZhuanYeMingCheng = '" + txtUpdate.Text + "' and XueBuID = '" + strXueBuID + "'") == true)//删除
                            MessageBox.Show("删除成功O(∩_∩)O~~~", "提示！");
                        else
                            MessageBox.Show("删除失败！", "提示！");
                    }
                    else
                        MessageBox.Show("该专业不存在，请确认后再删除！", "提示！");
                }
                else
                    MessageBox.Show("请选择或输入要删除的专业", "提示！");
            }
            else
                MessageBox.Show("请先选择要删除专业的学部！", "提示！");
            clsRefresh2();
        }

        //单击修改按钮
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstMajor.Text != "")
            {
                if (new clsSql().sqlUpdate(sSqlTouch, "ZhuanYe", "ZhuanYeID", "ZhuanYeMingCheng", lstMajor.Text, txtUpdate.Text) == true)
                    MessageBox.Show("修改成功！O(∩_∩)O~~~", "提示！");
                else
                    MessageBox.Show("修改失败！", "提示！");
            }
            else
                MessageBox.Show("请选择要修改的年级", "提示！");
            clsRefresh2();
        }
    }
}
