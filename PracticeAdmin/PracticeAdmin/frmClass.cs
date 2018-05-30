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
    public partial class frmClass : Form
    {
        private String strNianJiID = "";
        private String strXueBuID = "";
        private String strZhuanYeID = "";
        private String sSqlTouch = clsForm.sSqlTouch;
        
        public frmClass()
        {
            InitializeComponent();
        }

        //刷新学年和学部列表
        private void clsRefresh1()
        {
            lstClass.Items.Clear();
            strNianJiID = "";
            strXueBuID = "";
            strZhuanYeID = "";
            cboYear.Items.Clear();
            cboDepartment.Items.Clear();
            cboMajor.Items.Clear();
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch,"NianJi");//查询
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboYear.Items.Add(ds.Tables[0].Rows[i][1]);
            DataSet ds1 = new clsSql().sqlSelect1(sSqlTouch,"XueBu");//查询
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                cboDepartment.Items.Add(ds1.Tables[0].Rows[i][1]);
            txtAdd.Text = "";
            txtUpdate.Text = "";
        }

        //刷新专业列表
        private void clsRefresh2()
        {
            lstClass.Items.Clear();
            cboMajor.Items.Clear();
            DataSet ds1 = new clsSql().sql1(sSqlTouch,"select * from XueBu where XueBuMingCheng = '" + cboDepartment.Text + "' ");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                strXueBuID = ds1.Tables[0].Rows[0][0].ToString();
                DataSet ds2 = new clsSql().sql1(sSqlTouch,"select * from ZhuanYe where XueBuID = '" + strXueBuID + "' ");
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    cboMajor.Items.Add(ds2.Tables[0].Rows[i][1]);
            }
            txtAdd.Text = "";
            txtUpdate.Text = "";
        }

        //刷新班级列表
        private void clsRefresh3()
        {
            lstClass.Items.Clear();
            DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where ZhuanYeMingCheng = '" + cboMajor.Text + "'");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                strZhuanYeID = ds1.Tables[0].Rows[0][0].ToString();
                DataSet ds2 = new clsSql().sql1(sSqlTouch, "select * from BanJi where ZhuanYeID = '" + strZhuanYeID + "' and NianJiID = '" + strNianJiID + "'");
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    lstClass.Items.Add(ds2.Tables[0].Rows[i][1]);
            }
            txtAdd.Text = "";
            txtUpdate.Text = "";
        }

        //单击刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsRefresh1();
        }

        //年级列表发生改变时触发
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from NianJi where NianJiMingCheng = '" + cboYear.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
                strNianJiID = ds.Tables[0].Rows[0][0].ToString();
            clsRefresh3();
        }

        //学部列表发生改变时触发
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsRefresh2();
        }

        //专业列表发生改变时触发
        private void cboMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsRefresh3();
        }

        //当lstClass控件发生改变时触发
        private void lstClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClass.SelectedIndex >= 0)
                txtUpdate.Text = lstClass.SelectedItem.ToString();
        }

        //单击添加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboYear.SelectedIndex >= 0 && cboDepartment.SelectedIndex >= 0 && cboMajor.SelectedIndex >= 0)
            {
                if (txtAdd.Text != "")
                {
                    if (new clsSql().sqlSelect2(sSqlTouch, "BanJi", "BanJiMingCheng", txtAdd.Text) == false)
                    {
                        if (new clsSql().sql2(sSqlTouch, "insert into BanJi (BanJiMingCheng,ZhuanYeID,NianJiID) values ('" + txtAdd.Text + "','" + strZhuanYeID + "','" + strNianJiID + "')") == true)//添加
                            MessageBox.Show("添加成功O(∩_∩)O~~~", "提示！");
                        else
                            MessageBox.Show("添加失败！", "提示！");
                    }
                    else
                        MessageBox.Show("该班级已存在，请确认后再添加！", "提示！");
                }
                else
                    MessageBox.Show("请输入要添加的班级", "提示！");
            }
            else
                MessageBox.Show("请先选择年级，学部，专业等信息！", "提示！");
            clsRefresh3();
        }

        //单击删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboYear.SelectedIndex >= 0 && cboDepartment.SelectedIndex >= 0 && cboMajor.SelectedIndex >= 0)
            {
                if (txtUpdate.Text != "")
                {
                    if (new clsSql().sqlSelect2(sSqlTouch, "BanJi", "BanJiMingCheng", txtUpdate.Text) == true)
                    {
                        if (new clsSql().sql2(sSqlTouch, "delete from BanJi where BanJiMingCheng = '" + txtUpdate.Text + "' and ZhuanYeID = '" + strZhuanYeID + "' and NianJiID = '" + strNianJiID + "'"))//删除
                            MessageBox.Show("删除成功O(∩_∩)O~~~", "提示！");
                        else
                            MessageBox.Show("删除失败！", "提示！");
                    }
                    else
                        MessageBox.Show("该班级不存在，请确认后再删除！", "提示！");
                }
                else
                    MessageBox.Show("请选择或输入要删除的班级", "提示！");
            }
            else
                MessageBox.Show("请先选择年级，学部，专业等信息！", "提示！");
            clsRefresh3();
        }

        //单击修改按钮
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstClass.Text != "")
            {
                if (new clsSql().sqlUpdate(sSqlTouch, "BanJi", "BanJiID", "BanJiMingCheng", lstClass.Text, txtUpdate.Text))
                    MessageBox.Show("修改成功！O(∩_∩)O~~~", "提示！");
                else
                    MessageBox.Show("修改失败！", "提示！");
            }
            else
                MessageBox.Show("请选择要修改的年级", "提示！");
            clsRefresh3();
        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            clsRefresh1();
        }
    }
}
