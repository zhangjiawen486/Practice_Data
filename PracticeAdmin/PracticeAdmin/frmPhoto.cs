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
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Data.SqlClient;

namespace PracticeAdmin
{
    public partial class frmPhoto : Form
    {
        public frmPhoto()
        {
            InitializeComponent();
        }

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;
        private String sSqlTouch = clsForm.sSqlTouch;

        private void frmPhoto_Load(object sender, EventArgs e)
        {

        }

        //查询学生信息
        private void clsPhoto()
        {
            DataSet ds = new clsSql().sql1(sSqlTouch,"select * from XueSheng where XueHao = '" + txtNumber.Text + "'");//查询学生信息
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][1].ToString() != "")
                {
                    try
                    {
                        pictureBox1.Image = new Bitmap(new MemoryStream((byte[])ds.Tables[0].Rows[0][1]));
                    }
                    catch
                    {
                        pictureBox1.Image = null;
                    }
                    lblNo.Visible = false;
                }
                else
                {
                    lblNo.Visible = true;
                    pictureBox1.Image = null;
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
                lblNumberY.Visible = true;
            }
            else
            {
                txt1.Text = null;
                txt2.Text = null;
                txt3.Text = null;
                txt4.Text = null;
                lblNumberY.Visible = false;
                pictureBox1.Image = null;
            }
        }

        //输入学号查询
        public void clsNumber(String strNumber)
        {
            txtNumber.Text = strNumber;
            clsPhoto();
        }

        //输入学号
        private void textNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar) == false) && (e.KeyChar != '\b'))//判断输入的是否为数字或退格键
                e.Handled = true;//事件结束
            else
            {
                txt1.Text = null;
                txt2.Text = null;
                txt3.Text = null;
                txt4.Text = null;
                lblNumberY.Visible = false;
                pictureBox1.Image = null;
            }
        }

        //单击更新按钮
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlParameter xuehao = new SqlParameter("@xuehao", txtNumber.Text);
            DataSet chauxn = new SqlFile.clsSql().RunProcedure(sSqlTouch,"chaxunxueshengxinxi", new IDataParameter[] { xuehao }, "a");
            if (chauxn.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("数据库中无该学生信息请联系管理员！", "提示");
                return ;
            }
            DialogResult dr = MessageBox.Show("确认更新吗？", "提示", MessageBoxButtons.OKCancel);
            if (dr != DialogResult.OK)
                return;
            string picName = "MyPhoto" + "\\" + "Photo" + ".jpg";
            byte[] mbBuf = new byte[345];
            mbBuf = File.ReadAllBytes(picName);
            SqlParameter sp1 = new SqlParameter("@xuehao", txtNumber.Text);
            SqlParameter sp2 = new SqlParameter("@zhaopian", mbBuf);
            new SqlFile.clsSql().RunProcedure(sSqlTouch,"baocunzhaopian", new IDataParameter[] { sp1, sp2 },"a");
            MessageBox.Show("更新成功！", "提示");
            clsPhoto();
        }

        //改变学号时触发
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.ToString().Length == 8)//当输入字符串为八位时
                clsPhoto();
            else
            {
                lblNo.Visible = false;
                lblNumberY.Visible = false;
                pictureBox1.Image = null;
                txt1.Text = null;
                txt2.Text = null;
                txt3.Text = null;
                txt4.Text = null;
            }
        }

        //获取设备
        private FilterInfoCollection clsDevices()
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            videoSourcePlayer1.VideoSource = null;
            try
            {
                //枚举所有视频输入设备  
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cbo1.Items.Clear();
                if (videoDevices.Count != 0)
                {
                    foreach (FilterInfo device in videoDevices)
                    {
                        this.cbo1.Items.Add(device.Name);
                    }
                    MessageBox.Show("已找到视频设备.");
                    return videoDevices;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:没有找到视频设备！具体原因：" + ex.Message);
                return null;
            }
        }

        //连接摄像头
        private VideoCaptureDevice VideoConnect(int deviceIndex = 0, int resolutionIndex = 0)
        {
            if (videoDevices.Count <= 0)
                return null;
            selectedDeviceIndex = deviceIndex;
            videoSource = new VideoCaptureDevice(videoDevices[deviceIndex].MonikerString);//连接摄像头  
            return videoSource;
        }

        //选择设备时触发
        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            videoSource = new VideoCaptureDevice(videoDevices[cbo1.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        //单击照相按钮
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists("MyPhoto"))
                    Directory.CreateDirectory("MyPhoto");
                String picName = "MyPhoto" + "\\" + "Photo" + ".jpg";
                if (File.Exists(picName))
                    File.Delete(picName);
                //抓到图保存到指定路径
                Bitmap jpg = videoSourcePlayer1.GetCurrentVideoFrame();
                if (jpg == null)
                {
                    MessageBox.Show("捕获图像失败！", "提示");
                    return;
                }
                jpg.Save(picName, ImageFormat.Jpeg);
                pictureBox1.ImageLocation = picName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("捕获图像失败！" + ex.Message, "提示");
            }
        }

        //单击删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblNumberY.Visible)
            {
                DialogResult r = MessageBox.Show("是否删除照片?", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r != DialogResult.OK)
                    return;
                if (new clsSql().sql2(sSqlTouch,"update XueSheng set ZhaoPian = null where XueHao = '" + txtNumber.Text + "'"))
                {
                    MessageBox.Show("删除成功！O(∩_∩)O~~~", "提示！");
                    clsPhoto();
                }
                else
                    MessageBox.Show("删除失败！", "提示！");
            }
            else
                MessageBox.Show("请确认学生信息是否存在！", "提示！");
        }

        //单击刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsDevices();
        }

        //单击指纹修改
        private void btnTouch_Click(object sender, EventArgs e)
        {
            clsForm.frmTouch1 = new frmTouch();
            clsForm.frmTouch1.MdiParent = this.MdiParent;
            clsForm.frmTouch1.Show();
            clsForm.frmTouch1.clsNumber(txtNumber.Text);
            //clsForm.frmPhoto1 = null;
            //this.Close();
        }

        //关闭窗体
        private void frmPhoto_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
        }

        private void frmPhoto_Activated(object sender, EventArgs e)
        {
            clsDevices();
        }

    }
}
