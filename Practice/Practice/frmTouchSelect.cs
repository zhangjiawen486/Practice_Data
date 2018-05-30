using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using SqlFile;
using System.IO;

namespace Practice
{
    public partial class frmTouchSelect : Form
    {
        public frmTouchSelect()
        {
            InitializeComponent();
        }

        Thread fThread;
        Thread threadT;
        Thread threadT1;
        frmLoading frmLoading1;

        private String sSqlTouch = clsFormStatic.sSqlTouch;

        private void frmTouchSelect_Load(object sender, EventArgs e)
        {

        }

        //单击查询按钮
        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnSelect.Enabled = false;
            frmTouchSelect.CheckForIllegalCrossThreadCalls = false;//允许线程非安全调用窗体控件
            ThreadStart thr_start_func = new ThreadStart(VerifyFinger_Thread);
            fThread = new Thread(thr_start_func);
            fThread.Name = "VerifyFinger_Thread";
            fThread.Start();
        }

        //输出错误原因
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

        //
        private void GetImage_Thread()
        {
            string strFileName = "d:\\";
            int lRV = 0;
            byte[] FingerBuf = new byte[304 * 256]; //图像缓冲区

            try
            {
                //获取图像
                label1.Text = "获取指纹图像，请按手指......";
                lRV = OpticalDriver.mxGetImage(0, FingerBuf, 0, 1);
                if (lRV != 0)
                {
                    label1.Text = GetErrorInfo(lRV);
                    return;
                }
                else
                {
                    label1.Text = "获取指纹图像成功";
                    strFileName += "image.bmp";
                    //图像数据流保存成bmp
                    OpticalDriver.mxSaveBMP(strFileName, FingerBuf, 256, 304);
                    //显示图像
                    pictureBox1.Image = Image.FromFile(strFileName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "异常");
            }
            finally
            {
                lRV = OpticalDriver.mxCancelGetImage(0);
                // EnabledButton(true); ;
            }
        }

        //打开连接数据库进度条窗体
        public void threadA()
        {
            frmLoading1 = new frmLoading();
            frmLoading1.str = "正在访问服务器》》》";
            frmLoading1.ShowDialog(this);
        }

        //打开指纹匹配进度条窗体
        public void threadB()
        {
            frmLoading1 = new frmLoading();
            frmLoading1.str = "正在进行指纹匹配。。。";
            frmLoading1.ShowDialog(this);
        }

        private void VerifyFinger_Thread()
        {
            while (true)
            {
                int lRV = 0;
                byte[] FingerBuf = new byte[304 * 256]; //图像缓冲区
                byte[] tzBuf = new byte[345];
                byte[] mbBuf = new byte[345];
                string strFileName = "";
                try
                {
                    lRV = OpticalDriver.mxGetImage(0, FingerBuf, 5000, 1);
                    if (lRV != 0)
                    {
                        // label1.Text = GetErrorInfo(lRV);
                    }
                    else
                    {
                        strFileName += "image1.bmp";
                        //图像数据流保存成bmp
                        OpticalDriver.mxSaveBMP(strFileName, FingerBuf, 256, 304);
                        //显示图像
                        // this.pictureBox1.Image = Image.FromFile(strFileName);
                        lRV = OpticalDriver.mxGetTzBase64(FingerBuf, tzBuf);
                        if (lRV != 0)
                        {
                            label1.Text = "获取指纹特征失败";
                            // return;
                        }
                        DataSet XiangMu4 = null;
                        if (!clsFormStatic.frmTouch1.sBanji.Equals(""))
                        {
                            threadT = new Thread(new ThreadStart(threadA));
                            threadT.Start();
                            SqlParameter jj = new SqlParameter("@BanjiID", clsFormStatic.frmTouch1.sBanji);
                            XiangMu4 = new SqlFile.clsSql().RunProcedure(sSqlTouch,"chaxunyundongyuanzhiwenxinxipipeibanji", new IDataParameter[] { jj }, "db");
                            if (frmLoading1.InvokeRequired)//判断是否有其他线程想访问
                            {
                                Action act = () => { frmLoading1.Close(); };//封装一个窗体关闭的方法
                                frmLoading1.Invoke(act);//在拥有该控件的线程上执行该方法
                            }
                            if (threadT != null)
                                threadT.Abort();//关闭进程释
                            threadT1 = new Thread(new ThreadStart(threadB));
                            threadT1.Start();
                        }
                       
                        int i; 
                        if (XiangMu4!=null)
                        for (i = 0; i < XiangMu4.Tables[0].Rows.Count; i++)
                        {
                            if (XiangMu4.Tables[0].Rows[i][2].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu4.Tables[0].Rows[i][2];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    label1.Text = "  指纹比对成功!";
                                    lblNumber.Text = XiangMu4.Tables[0].Rows[i][0].ToString();
                                    lblName.Text = XiangMu4.Tables[0].Rows[i][1].ToString();
                                    pictureBox1.Image = Image.FromFile(strFileName);
                                    SelectImage(XiangMu4.Tables[0].Rows[i][0].ToString());
                                    goto gg ;
                                }
                            }
                            if (XiangMu4.Tables[0].Rows[i][3].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu4.Tables[0].Rows[i][3];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    label1.Text = "  指纹比对成功!";
                                    lblNumber.Text = XiangMu4.Tables[0].Rows[i][0].ToString();
                                    lblName.Text = XiangMu4.Tables[0].Rows[i][1].ToString();
                                    pictureBox1.Image = Image.FromFile(strFileName);
                                    SelectImage(XiangMu4.Tables[0].Rows[i][0].ToString());
                                     goto gg ;
                                }
                            }
                            if (XiangMu4.Tables[0].Rows[i][4].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu4.Tables[0].Rows[i][4];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    label1.Text = "  指纹比对成功!";
                                    lblNumber.Text = XiangMu4.Tables[0].Rows[i][0].ToString();
                                    lblName.Text = XiangMu4.Tables[0].Rows[i][1].ToString();
                                    pictureBox1.Image = Image.FromFile(strFileName);
                                    SelectImage(XiangMu4.Tables[0].Rows[i][0].ToString());
                                     goto gg ;
                                }
                            }
                            if (XiangMu4.Tables[0].Rows[i][5].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu4.Tables[0].Rows[i][5];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    label1.Text = "  指纹比对成功!";
                                    lblNumber.Text = XiangMu4.Tables[0].Rows[i][0].ToString();
                                    lblName.Text = XiangMu4.Tables[0].Rows[i][1].ToString();
                                    pictureBox1.Image = Image.FromFile(strFileName);
                                    SelectImage(XiangMu4.Tables[0].Rows[i][0].ToString());
                                    goto gg ;
                                }
                            }
                        }
                        if (frmLoading1.InvokeRequired)//判断是否有其他线程想访问
                        {
                            Action act = () => { frmLoading1.Close(); };//封装一个窗体关闭的方法
                            frmLoading1.Invoke(act);//在拥有该控件的线程上执行该方法
                        }
                        if (threadT1 != null)
                            threadT1.Abort();//关闭进程释


                        threadT = new Thread(new ThreadStart(threadA));
                        threadT.Start();
                        DataSet XiangMu2 = new SqlFile.clsSql().RunProcedure(sSqlTouch,"chaxunyundongyuanzhiwenxinxipipei", new IDataParameter[] { }, "db");
                        if (frmLoading1.InvokeRequired)//判断是否有其他线程想访问
                        {
                            Action act = () => { frmLoading1.Close(); };//封装一个窗体关闭的方法
                            frmLoading1.Invoke(act);//在拥有该控件的线程上执行该方法
                        }
                        if (threadT != null)
                            threadT.Abort();//关闭进程释
                        threadT = new Thread(new ThreadStart(threadB));
                        threadT.Start();
                        for (i = 0; i < XiangMu2.Tables[0].Rows.Count; i++)
                        {
                            if (XiangMu2.Tables[0].Rows[i][2].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu2.Tables[0].Rows[i][2];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    label1.Text = "  指纹比对成功!";
                                    lblNumber.Text = XiangMu2.Tables[0].Rows[i][0].ToString();
                                    lblName.Text = XiangMu2.Tables[0].Rows[i][1].ToString();
                                    pictureBox1.Image = Image.FromFile(strFileName);
                                    SelectImage(XiangMu2.Tables[0].Rows[i][0].ToString());
                                    break;
                                }
                            }
                            if (XiangMu2.Tables[0].Rows[i][3].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu2.Tables[0].Rows[i][3];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    label1.Text = "  指纹比对成功!";
                                    lblNumber.Text = XiangMu2.Tables[0].Rows[i][0].ToString();
                                    lblName.Text = XiangMu2.Tables[0].Rows[i][1].ToString();
                                    pictureBox1.Image = Image.FromFile(strFileName);
                                    SelectImage(XiangMu2.Tables[0].Rows[i][0].ToString());
                                    break;
                                }
                            }
                            if (XiangMu2.Tables[0].Rows[i][4].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu2.Tables[0].Rows[i][4];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    label1.Text = "  指纹比对成功!";
                                    lblNumber.Text = XiangMu2.Tables[0].Rows[i][0].ToString();
                                    lblName.Text = XiangMu2.Tables[0].Rows[i][1].ToString();
                                    pictureBox1.Image = Image.FromFile(strFileName);
                                    SelectImage(XiangMu2.Tables[0].Rows[i][0].ToString());
                                    break;
                                }
                            }
                            if (XiangMu2.Tables[0].Rows[i][5].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu2.Tables[0].Rows[i][5];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    label1.Text = "  指纹比对成功!";
                                    lblNumber.Text = XiangMu2.Tables[0].Rows[i][0].ToString();
                                    lblName.Text = XiangMu2.Tables[0].Rows[i][1].ToString();
                                    pictureBox1.Image = Image.FromFile(strFileName);
                                    SelectImage(XiangMu2.Tables[0].Rows[i][0].ToString());
                                    break;
                                }
                            }
                        }

                        if (i == XiangMu2.Tables[0].Rows.Count)
                        {
                            label1.Text = "指纹比对失败";
                            this.pictureBox1.Image = Image.FromFile(strFileName);
                            lblNumber.Text = "Null";
                            lblName.Text = "Null";
                            lblClass.Text = "Null";
                            lblImage.Visible = true;
                            pictureBox2.Image = null;
                        }
                        else
                            pictureBox1.Image = Image.FromFile(strFileName);
                    gg: ;
                        if (frmLoading1.InvokeRequired)//判断是否有其他线程想访问
                        {
                            Action act = () => { frmLoading1.Close(); };//封装一个窗体关闭的方法
                            frmLoading1.Invoke(act);//在拥有该控件的线程上执行该方法
                        }
                        if (threadT1 != null)
                            threadT1.Abort();//关闭进程释
                    }
                }
                catch (Exception e)
                {
                    //  MessageBox.Show(this, e.Message, "异常");
                }
                finally
                {
                    lRV = OpticalDriver.mxCancelGetImage(0);
                    btnSelect.Enabled = true;
                    fThread.Abort();
                    // EnabledButton(true); ;
                }
            }
        }

        //通过学号查询班级和照片
        private void SelectImage(String sNumber)
        {
            DataSet ds = new SqlFile.clsSql().sqlSelect3(sSqlTouch,"XueSheng","XueHao",sNumber);
            if (ds.Tables[0].Rows.Count < 0)
                return;
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                pictureBox2.Image = new Bitmap(new MemoryStream((byte[])ds.Tables[0].Rows[0][1]));//显示照片
                lblImage.Visible = false;
            }
            else
            {
                pictureBox1.Image = null;
                lblImage.Visible = true;
            }
            DataSet ds1 = new clsSql().sql1(sSqlTouch,"select * from BanJi where BanJiID = '" + ds.Tables[0].Rows[0][6].ToString() + "'");//查询班级
            lblClass.Text = ds1.Tables[0].Rows[0][1].ToString();
        }

        private void frmTouchSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fThread != null)
                fThread.Abort();
             OpticalDriver.mxCancelGetImage(0);
        }

    }
}
