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
using System.Data.SqlClient;

namespace Practice
{
    public partial class frmTouch : Form
    {
        public frmTouch()
        {
            InitializeComponent();
        }

        private String sSqlTouch = clsFormStatic.sSqlTouch;
        Thread fThread;
        public String sBanji = "";

        private void frmFingerprint_Load(object sender, EventArgs e)
        {

        }

        //清空信息
        private void clsRefresh()
        {
            sBanji = "";
            lblNumberY.Visible = false;
            txtName.Text = null;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            label1.Visible = false;
            label2.Text = null;
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
            btnTouch.Enabled = true;
            btnSave1.Enabled = true;
            btnSave2.Enabled = true;
            btnSave3.Enabled = true;
            btnSave4.Enabled = true;
        }

        //读取信息
        private void clsInfo()
        {
             DataSet ds = new clsSql().sql1(sSqlTouch,"select * from XueSheng where XueHao = '" + txtNumber.Text + "'");//查询学生信息
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
                 DataSet ds1 = new clsSql().sql1(sSqlTouch,"select * from BanJi where BanJiID = '" + ds.Tables[0].Rows[0][6].ToString() + "'");//查询班级
                 sBanji = ds.Tables[0].Rows[0][6].ToString();
                 DataSet ds2 = new clsSql().sql1(sSqlTouch,"select * from ZhuanYe where ZhuanYeID = '" + ds1.Tables[0].Rows[0][2].ToString() + "'");//查询专业
                 DataSet ds3 = new clsSql().sql1(sSqlTouch,"select * from XueBu where XueBuID = '" + ds2.Tables[0].Rows[0][2].ToString() + "'");//查询学部
                 DataSet ds4 = new clsSql().sql1(sSqlTouch,"select * from NianJi where NianJiID = '" + ds1.Tables[0].Rows[0][3].ToString() + "'");//查询年级
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
                 {
                     txt1.Text = "存在";
                     btnSave1.Enabled = false;
                 }
                 else
                 {
                     txt1.Text = "null";
                     btnSave1.Enabled = true;
                 }
                 if (ds.Tables[0].Rows[0][3].ToString() != "")
                 {
                     txt2.Text = "存在";
                     btnSave2.Enabled = false;
                 }
                 else
                 {
                     txt2.Text = "null";
                     btnSave2.Enabled = true;
                 }
                 if (ds.Tables[0].Rows[0][4].ToString() != "")
                 {
                     txt3.Text = "存在";
                     btnSave3.Enabled = false;
                 }
                 else
                 {
                     txt3.Text = "null";
                     btnSave3.Enabled = true;
                 }
                 if (ds.Tables[0].Rows[0][5].ToString() != "")
                 {
                     txt4.Text = "存在";
                     btnSave4.Enabled = false;
                 }
                 else
                 {
                     txt4.Text = "null";
                     btnSave4.Enabled = true;
                 }
             }
             else
                 clsRefresh();
        }

        //输入学号
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.ToString().Length == 8)//当输入字符串为八位时
                clsInfo();
            else
                clsRefresh();
        }

        //采集指纹
        private void clsTouch()
        {
            int lRV = 0;
            byte[] FingerBuf = new byte[304 * 256]; //图像缓冲区
            byte[] tzBuf1 = new byte[345];
            byte[] tzBuf2 = new byte[345];
            byte[] tzBuf3 = new byte[345];
            byte[] mbBuf = new byte[345];

            //  EnabledButton(false);
            try
            {
                //获取指纹特征1
                label2.Text = "注册指纹，请按3次手指......";
                lRV = OpticalDriver.mxGetImage(0, FingerBuf, 0, 1);
                if (lRV != 0)
                {
                    label2.Text = GetErrorInfo(lRV);
                    return;
                }
                //图像数据流保存成bmp
                OpticalDriver.mxSaveBMP("imageTz1.bmp", FingerBuf, 256, 304);
                //显示图像
                this.pictureBox2.Image = Image.FromFile("imageTz1.bmp");
                lRV = OpticalDriver.mxGetTzBase64(FingerBuf, tzBuf1);
                if (lRV != 0)
                {
                    label2.Text = "获取指纹特征1失败";
                    btnTouch.Enabled = true;
                    return;
                }

                //获取指纹特征2
                label2.Text = "请按第2次手指......";
                lRV = OpticalDriver.mxGetImage(0, FingerBuf, 0, 1);
                if (lRV != 0)
                {
                    label2.Text = GetErrorInfo(lRV);
                    return;
                }
                //图像数据流保存成bmp
                OpticalDriver.mxSaveBMP("imageTz2.bmp", FingerBuf, 256, 304);
                //显示图像
                this.pictureBox2.Image = Image.FromFile("imageTz2.bmp");
                lRV = OpticalDriver.mxGetTzBase64(FingerBuf, tzBuf2);
                if (lRV != 0)
                {
                    label2.Text = "获取指纹特征2失败";
                    btnTouch.Enabled = true;
                    return;
                }

                //获取指纹特征3
                label2.Text = "请按第3次手指......";
                lRV = OpticalDriver.mxGetImage(0, FingerBuf, 0, 1);
                if (lRV != 0)
                {
                    label2.Text = GetErrorInfo(lRV);
                    return;
                }
                //图像数据流保存成bmp
                OpticalDriver.mxSaveBMP("imageTz3.bmp", FingerBuf, 256, 304);
                //显示图像
                this.pictureBox2.Image = Image.FromFile("imageTz3.bmp");
                lRV = OpticalDriver.mxGetTzBase64(FingerBuf, tzBuf3);
                if (lRV != 0)
                {
                    label2.Text = "获取指纹特征3失败";
                    btnTouch.Enabled = true;
                    return;
                }

                //合并模板
                lRV = OpticalDriver.mxGetMBBase64(tzBuf1, tzBuf2, tzBuf3, mbBuf);
                if (lRV != 0)
                {
                    label2.Text = "合并模板失败";
                    btnTouch.Enabled = true;
                    return;
                }
                else
                {
                    //内存保存到本地文件
                    File.WriteAllBytes("Touch.dat", mbBuf);
                    label2.Text = "注册指纹成功";
                    btnTouch.Enabled = true;
                }

            }
            catch (Exception e)
            {
                btnTouch.Enabled = true;
             //   MessageBox.Show(this, e.Message, "异常");
            }
            finally
            {
                btnTouch.Enabled = true;
                lRV = OpticalDriver.mxCancelGetImage(0);
                // EnabledButton(true); ;
            }
        }

        //判断错误原因
        private string GetErrorInfo(int ret)
        {
            string strInfo;
            switch (ret)
            {
                case -1:
                    strInfo = "打开设备失败";
                    break;
                case -2:
                    strInfo = "用户取消操作";
                    break;
                case -3:
                    strInfo = "等待手指超时";
                    break;
                case -4:
                    strInfo = "采集图像失败";
                    break;
                case -5:
                    strInfo = "上传图像失败";
                    break;
                case -10:
                    strInfo = "参数非法";
                    break;
                case -11:
                    strInfo = "设备已在获取图像操作";
                    break;
                case -12:
                    strInfo = "驱动安装失败";
                    break;
                default:
                    strInfo = "其他错误";
                    break;
            }
            return strInfo;
        }

        //保存指纹
        private void clsSave(String str)
        {
            if (!lblNumberY.Visible)
            {
                MessageBox.Show("请先输入你要保存的学生！", "提示");
                return;
            }
            if (!File.Exists("Touch.dat"))
            {
                MessageBox.Show("请先录制指纹信息后再保存！", "提示");
                return;
            }
            DialogResult dr = MessageBox.Show("确认添加吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr != DialogResult.OK)
                return;
            byte[] mbBuf = new byte[345];
            mbBuf = File.ReadAllBytes("Touch.dat");
            SqlParameter sp1 = new SqlParameter("@name", txtNumber.Text);
            SqlParameter sp2 = new SqlParameter("@name1", mbBuf);
            SqlParameter sp3 = new SqlParameter("@name2", str);
            new SqlFile.clsSql().RunProcedure(sSqlTouch, "xiugaiyundongyuanxinxizhiwen", new IDataParameter[] { sp1, sp2, sp3 });
            MessageBox.Show("添加成功！", "提示");
            File.Delete("Touch.dat");
        }

        //单击指纹采集按
        private void btnTouch_Click(object sender, EventArgs e)
        {
            btnTouch.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;//允许线程非安全调用窗体控件
            ThreadStart thr_start_func = new ThreadStart(clsTouch);
            fThread = new Thread(thr_start_func);
            fThread.Name = "clsTouch";
            fThread.Start();
        }

        //单击保存到指纹1按钮
        private void btnSave1_Click(object sender, EventArgs e)
        {
            clsSave("1");
            clsInfo();
        }

        //单击保存到指纹2按钮
        private void btnSave2_Click(object sender, EventArgs e)
        {
            clsSave("2");
            clsInfo();
        }

        //单击保存到指纹3按钮
        private void btnSave3_Click(object sender, EventArgs e)
        {
            clsSave("3");
            clsInfo();
        }

        //单击保存到指纹4按钮
        private void btnSave4_Click(object sender, EventArgs e)
        {
            clsSave("4");
            clsInfo();
        }

        //单击指纹校验按钮
        private void btnSelect_Click(object sender, EventArgs e)
        {
            new frmTouchSelect().Show();
        }

        //键入学号
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar) == false) && (e.KeyChar != '\b'))//判断输入的是否为数字或退格键
                e.Handled = true;//事件结束
        }

        private void frmTouch_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fThread != null)
                fThread.Abort();
            OpticalDriver.mxCancelGetImage(0);
        }

    }
}
