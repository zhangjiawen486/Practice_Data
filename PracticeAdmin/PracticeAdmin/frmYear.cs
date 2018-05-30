using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SqlFile;

namespace PracticeAdmin
{
    public partial class frmYear : Form
    {
        public frmYear()
        {
            InitializeComponent();
        }

        private String sSqlTouch = clsForm.sSqlTouch;

        //刷新年级列表
        private void clsRefresh()
        {
            lstYear.Items.Clear();
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch,"Nianji") ;//查询
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                lstYear.Items.Add(ds.Tables[0].Rows[i][1]);
            txtAdd.Text = "";
            txtUpdate.Text = "";
        }

        //单击刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsRefresh();
        }

        private void frmYear_Load(object sender, EventArgs e)
        {
            clsRefresh();
        }

        //单击添加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text != "")
            {
                if (new clsSql().sqlSelect2(sSqlTouch,"NianJi", "NianJiMingCheng", txtAdd.Text) == false )
                {
                    if (new clsSql().sql2(sSqlTouch,"insert into NianJi (NianJiMingCheng) values ('" + txtAdd.Text + "')") == true)//添加
                        MessageBox.Show("添加成功O(∩_∩)O~~~", "提示！");
                    else
                        MessageBox.Show("添加失败！", "提示！");
                }
                else
                    MessageBox.Show("该年级已存在，请确认后再添加！", "提示！");
            }
            else
                MessageBox.Show("请输入要添加的年级", "提示！");
            clsRefresh();
        }

        //单击删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUpdate.Text != "")
            {
                if (new clsSql().sqlDelete(sSqlTouch, "NianJi", "NianJiMingCheng", txtUpdate.Text) == true)
                    MessageBox.Show("删除成功！O(∩_∩)O~~~", "提示！");
                else
                    MessageBox.Show("删除失败！", "提示！");
            }
            else
                MessageBox.Show("请选择或输入要删除的年级", "提示！");
            clsRefresh();
        }

        //单击修改按钮
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstYear.Text != "")
            {
                if (new clsSql().sqlUpdate(sSqlTouch, "NianJi", "NianjiID", "NianJiMingCheng", lstYear.Text, txtUpdate.Text) == true)
                    MessageBox.Show("修改成功！O(∩_∩)O~~~", "提示！");  
                else
                    MessageBox.Show("修改失败！", "提示！");
            }
            else
                MessageBox.Show("请选择要修改的年级", "提示！");
            clsRefresh();
        }

        //当lstYear控件改变时触发
        private void lstYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstYear.SelectedIndex >= 0)
                txtUpdate.Text = lstYear.SelectedItem.ToString();
        }

    }
}
