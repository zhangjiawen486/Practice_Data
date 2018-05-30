using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlFile;
using PractuceClient;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace PracticeClient
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }

        Thread fThread;
        Thread threadT;
        Thread threadT1;
        Thread threadLoading;
        frmLoading frmLoading1;
        private DataTable dt;
        private DataTable dt1;
        private string sSqlTouch = clsFormStatic.sSqlTouch;
        private string sSqlRecord = clsFormStatic.sSqlRecord;
        private string sIdCard = "";

        private void frmInput_Load(object sender, EventArgs e)
        {
            if (!sqlOpen())
                this.Close();
            group1Refresh();
            dataHead();
        }


        private void s()
        {
            frmLoading1 = new frmLoading();
            frmLoading1.str = "尝试与‘指纹’服务器进行连接...";
            frmLoading1.ShowDialog();
        }

        private void s1()
        {
            frmLoading1 = new frmLoading();
            frmLoading1.str = "尝试与‘记录’服务器进行连接...";
            frmLoading1.ShowDialog();
        }

        private bool sqlOpen()
        {
            threadLoading = new Thread(new ThreadStart(s));
            threadLoading.IsBackground = true;
            threadLoading.Start();
            String str = new SqlFile.clsSql().sqlOpen1(sSqlTouch);
            if (frmLoading1.InvokeRequired)//判断是否有其他线程想访问
            {
                Action act = () => { frmLoading1.Close(); };//封装一个窗体关闭的方法
                frmLoading1.Invoke(act);//在拥有该控件的线程上执行该方法
            }
            if (threadLoading != null)
                threadLoading.Abort();
            if (str != "")
            {
                MessageBox.Show("与指纹服务器连接失败！失败原因！\n"+str,"服务器异常");
                return false;
            }
            threadLoading = new Thread(new ThreadStart(s1));
            threadLoading.IsBackground = true;
            threadLoading.Start();
            String str1 = new SqlFile.clsSql().sqlOpen1(sSqlRecord);
            if (frmLoading1.InvokeRequired)//判断是否有其他线程想访问
            {
                Action act = () => { frmLoading1.Close(); };//封装一个窗体关闭的方法
                frmLoading1.Invoke(act);//在拥有该控件的线程上执行该方法
            }
            if (threadLoading != null)
                threadLoading.Abort();
            if (str1 != "")
            {
                MessageBox.Show("与记录服务器连接失败！失败原因！\n" + str1,"服务器异常");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 显示‘dataGridView1’和‘dataGridView2’列表
        /// </summary>
        private void dataHead()
        {
            dt = new DataTable();
            dt.Columns.Add("学号", typeof(System.String));
            dt.Columns.Add("姓名", typeof(System.String));
            dt.Columns.Add("班级", typeof(System.String));
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.RowTemplate.Height = 22;
            dataGridView1.Columns[0].Width = dataGridView1.Width * 1 / 4;
            dataGridView1.Columns[1].Width = dataGridView1.Width * 1 / 4;
            dataGridView1.Columns[2].Width = dataGridView1.Width * 2 / 4;
            dt1 = new DataTable();
            dt1.Columns.Add("学号", typeof(System.String));
            dt1.Columns.Add("姓名", typeof(System.String));
            dt1.Columns.Add("班级", typeof(System.String));
            dt1.Columns.Add("检录时间", typeof(System.DateTime));
            dataGridView2.DataSource = dt1;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView2.RowTemplate.Height = 22;
            dataGridView2.Columns[0].Width = dataGridView2.Width / 6;
            dataGridView2.Columns[1].Width = dataGridView2.Width / 6;
            dataGridView2.Columns[2].Width = dataGridView2.Width * 5 / 18;
            dataGridView2.Columns[3].Width = dataGridView2.Width * 7 / 18;
        }

        /// <summary>
        /// GroupBox1组件内容刷新
        /// </summary>
        private void group1Refresh()
        {
            cboYear.Items.Clear();
            cboDepartment.Items.Clear();
            cboMajor.Items.Clear();
            cboClass.Items.Clear();
            DataSet ds = new clsSql().sqlSelect1(sSqlTouch, "NianJi");//查询
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboYear.Items.Add(ds.Tables[0].Rows[i][1]+ "*                                  #" + ds.Tables[0].Rows[i][0] );
            DataSet ds1 = new clsSql().sqlSelect1(sSqlTouch, "XueBu");//查询
            cboDepartment.Items.Add("");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                cboDepartment.Items.Add(ds1.Tables[0].Rows[i][1] + "*                                  #" + ds1.Tables[0].Rows[i][0]);
        }

        /// <summary>
        /// ‘专业’下拉列表刷新
        /// </summary>
        /// <param name="strDepartment">选择的学部ID</param>
        private void cboMajorRefresh(String strDepartment)
        {
            cboMajor.Items.Clear();
            cboClass.Items.Clear();
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where XueBuID = '" + strDepartment + "' ");
            cboMajor.Items.Add("");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboMajor.Items.Add(ds.Tables[0].Rows[i][1] + "*                                  #" + ds.Tables[0].Rows[i][0]);
        }

        /// <summary>
        /// ‘班级’下拉列表刷新
        /// </summary>
        /// <param name="strYear">选择的学年ID</param>
        /// <param name="strMajor">选择的专业ID</param>
        private void cboClassRefresh(String strYear,String strMajor)
        {
            cboClass.Items.Clear();
            DataSet ds = new clsSql().sql1(sSqlTouch, "select * from BanJi where ZhuanYeID = '" + strMajor + "' and NianJiID = '" + strYear + "' ");
            cboClass.Items.Add("");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                cboClass.Items.Add(ds.Tables[0].Rows[i][1] + "*                                  #" + ds.Tables[0].Rows[i][0]);
        }

        /// <summary>
        /// GroupBox3内容清空
        /// </summary>
        private void group3Clear()
        {
            txtNumber.Text = null;
            txtName.Text = null;
            rdoMale.Checked = false;
            rdoLady.Checked = false;
            txtYear.Text = null;
            txtDepartment.Text = null;
            txtMajor.Text = null;
            txtClass.Text = null;
            txtTel.Text = null;
            checkBox2.Checked = false;
            txtIdCard.Text = null;
        }

        /// <summary>
        /// 选择‘年级’下拉列表内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboYear.SelectedIndex > 0 && cboMajor.SelectedIndex > 0)
            {
                String sYear = cboYear.Text.Substring(cboYear.Text.IndexOf("#") + 1);
                String sMajor = cboMajor.Text.Substring(cboMajor.Text.IndexOf("#") + 1);
                cboClassRefresh(sYear, sMajor);
            }
        }

        /// <summary>
        /// 选择‘学部’下拉列表内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedIndex == 0)
            {
                cboMajor.Items.Clear();
                cboClass.Items.Clear();
            }
            if (cboDepartment.SelectedIndex > 0)
            {
                String sDepartment = cboDepartment.Text.Substring(cboDepartment.Text.IndexOf("#")+1);
                cboMajorRefresh(sDepartment);
            }
        }

        /// <summary>
        /// 选择‘专业’下拉列表内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMajor.SelectedIndex == 0)
            {
                cboClass.Items.Clear();
            }
            if (cboYear.SelectedIndex > 0 && cboMajor.SelectedIndex > 0)
            {
                String sYear = cboYear.Text.Substring(cboYear.Text.IndexOf("#") + 1);
                String sMajor = cboMajor.Text.Substring(cboMajor.Text.IndexOf("#") + 1);
                cboClassRefresh(sYear, sMajor);
            }
        }

        /// <summary>
        /// 单击‘班级信息’按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClass_Click(object sender, EventArgs e)
        {
            label2.Text = "0";
            dt.Clear();
            string strYear = "";
            string strDepartment = "";
            string strMajor = "";
            string strClass = "";
            if (cboYear.SelectedIndex < 0)
                return;
            if (cboDepartment.SelectedIndex < 1)
            {
                strYear = cboYear.Text.Substring(cboYear.Text.IndexOf("#") + 1);
                DataSet ds = new clsSql().sql1(sSqlTouch, "select * from BanJi where NianJiID = '" + strYear + "'");
                if (ds.Tables[0].Rows.Count <= 0)
                    return;
                string str = " BanJiID = '" + ds.Tables[0].Rows[0][0].ToString() + "' ";
                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    str += "or BanJiID = '" + ds.Tables[0].Rows[i][0].ToString() + "' ";
                }
                DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from XueSheng where "+str);
                if (ds1.Tables[0].Rows.Count <= 0)
                    return;
                string n = ds1.Tables[0].Rows[0][6].ToString();
                DataSet ds2 = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + n + "'");
                string strName = ds2.Tables[0].Rows[0][1].ToString(); 
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i][6].ToString() != n)
                    {
                        strName = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + ds1.Tables[0].Rows[i][6].ToString() + "'").Tables[0].Rows[0][1].ToString();
                        n = ds1.Tables[0].Rows[i][6].ToString();
                    }
                    DataRow dr = dt.NewRow();
                    dr[0] = ds1.Tables[0].Rows[i][0];
                    dr[1] = ds1.Tables[0].Rows[i][7];
                    dr[2] = strName;
                    dt.Rows.Add(dr);
                }
                label2.Text = ds1.Tables[0].Rows.Count.ToString();
            }
            else if (cboMajor.SelectedIndex < 1)
            {
                strYear = cboYear.Text.Substring(cboYear.Text.IndexOf("#") + 1);
                strDepartment = cboDepartment.Text.Substring(cboDepartment.Text.IndexOf("#") + 1);
                DataSet ds = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where XueBuID = '" + strDepartment + "'");
                if (ds.Tables[0].Rows.Count <= 0)
                    return;
                string str = " ZhuanYeID = '" + ds.Tables[0].Rows[0][0].ToString() + "' ";
                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    str += "or ZhuanYeID = '" + ds.Tables[0].Rows[i][0].ToString() + "' ";
                }
                DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from BanJi where NianJiID = '"+strYear+"' and " + str);
                if (ds1.Tables[0].Rows.Count <= 0)
                    return;
                string str1 = " BanJiID = '" + ds1.Tables[0].Rows[0][0].ToString() + "' ";
                for (int i = 1; i < ds1.Tables[0].Rows.Count; i++)
                {
                    str1 += "or BanJiID = '" + ds1.Tables[0].Rows[i][0].ToString() + "' ";
                }
                DataSet ds2 = new clsSql().sql1(sSqlTouch, "select * from XueSheng where " + str1);
                if (ds2.Tables[0].Rows.Count <= 0)
                    return;
                string n = ds2.Tables[0].Rows[0][6].ToString();
                DataSet ds3 = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + n + "'");
                string strName = ds3.Tables[0].Rows[0][1].ToString();
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (ds2.Tables[0].Rows[i][6].ToString() != n)
                    {
                        strName = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + ds2.Tables[0].Rows[i][6].ToString() + "'").Tables[0].Rows[0][1].ToString();
                        n = ds2.Tables[0].Rows[i][6].ToString();
                    }
                    DataRow dr = dt.NewRow();
                    dr[0] = ds2.Tables[0].Rows[i][0];
                    dr[1] = ds2.Tables[0].Rows[i][7];
                    dr[2] = strName;
                    dt.Rows.Add(dr);
                }
                label2.Text = ds2.Tables[0].Rows.Count.ToString();
            }
            else if (cboClass.SelectedIndex < 1)
            {
                strYear = cboYear.Text.Substring(cboYear.Text.IndexOf("#") + 1);
                strMajor = cboMajor.Text.Substring(cboMajor.Text.IndexOf("#") + 1);
                DataSet ds = new clsSql().sql1(sSqlTouch, "select * from BanJi where ZhuanYeID = '" + strMajor + "' and NianJiID = '"+strYear+"'");
                if (ds.Tables[0].Rows.Count <= 0)
                    return;
                string str = " BanJiID = '" + ds.Tables[0].Rows[0][0].ToString() + "' ";
                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    str += "or BanJiID = '" + ds.Tables[0].Rows[i][0].ToString() + "' ";
                }
                DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from XueSheng where "+str);
                if (ds1.Tables[0].Rows.Count <= 0)
                    return;
                string n = ds1.Tables[0].Rows[0][6].ToString();
                DataSet ds2 = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + n + "'");
                string strName = ds2.Tables[0].Rows[0][1].ToString();
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (ds1.Tables[0].Rows[i][6].ToString() != n)
                    {
                        strName = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + ds1.Tables[0].Rows[i][6].ToString() + "'").Tables[0].Rows[0][1].ToString();
                        n = ds1.Tables[0].Rows[i][6].ToString();
                    }
                    DataRow dr = dt.NewRow();
                    dr[0] = ds1.Tables[0].Rows[i][0];
                    dr[1] = ds1.Tables[0].Rows[i][7];
                    dr[2] = strName;
                    dt.Rows.Add(dr);
                }
                label2.Text = ds1.Tables[0].Rows.Count.ToString();
            }
            else
            {
                strClass = cboClass.Text.Substring(cboClass.Text.IndexOf("#") + 1);
                DataSet ds = new clsSql().sql1(sSqlTouch, "select * from XueSheng where BanJiID = '" + strClass + "'");
                if (ds.Tables[0].Rows.Count <= 0)
                    return;
                DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + ds.Tables[0].Rows[0][6].ToString() + "'");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = ds.Tables[0].Rows[i][0];
                    dr[1] = ds.Tables[0].Rows[i][7];
                    dr[2] = ds1.Tables[0].Rows[0][1];
                    dt.Rows.Add(dr);
                }
                label2.Text = ds.Tables[0].Rows.Count.ToString();
            }
        }

        /// <summary>
        /// 刷新‘groupBox3’中内容
        /// </summary>
        /// <param name="sNumber">输入学号</param>
        private void group3Refresh(string sNumber)
        {
            pictureBox1.Image = null;
            DataSet ds = new SqlFile.clsSql().sqlSelect3(sSqlTouch, "XueSheng", "XueHao", sNumber);
            if (ds.Tables[0].Rows.Count <= 0)
                return;
            txtNumber.Text = ds.Tables[0].Rows[0][0].ToString();//显示学号
            txtName.Text = ds.Tables[0].Rows[0][7].ToString();//显示名字
            rdoMale.Checked = false;
            rdoLady.Checked = false;
            if (ds.Tables[0].Rows[0][9].ToString() == "男")
                rdoMale.Checked = true;
            else if (ds.Tables[0].Rows[0][9].ToString() == "女")
                rdoLady.Checked = true;
            DataSet ds1 = new clsSql().sql1(sSqlTouch, "select * from BanJi where BanJiID = '" + ds.Tables[0].Rows[0][6].ToString() + "'");//查询班级
            DataSet ds2 = new clsSql().sql1(sSqlTouch, "select * from ZhuanYe where ZhuanYeID = '" + ds1.Tables[0].Rows[0][2].ToString() + "'");//查询专业
            DataSet ds3 = new clsSql().sql1(sSqlTouch, "select * from XueBu where XueBuID = '" + ds2.Tables[0].Rows[0][2].ToString() + "'");//查询学部
            DataSet ds4 = new clsSql().sql1(sSqlTouch, "select * from NianJi where NianJiID = '" + ds1.Tables[0].Rows[0][3].ToString() + "'");//查询年级
            txtYear.Text = ds4.Tables[0].Rows[0][1].ToString();//显示年级
            txtDepartment.Text = ds3.Tables[0].Rows[0][1].ToString();//显示学部
            txtMajor.Text = ds2.Tables[0].Rows[0][1].ToString();//显示专业
            txtClass.Text = ds1.Tables[0].Rows[0][1].ToString();//显示班级
            txtTel.Text = ds.Tables[0].Rows[0][10].ToString();//显示手机号
            checkBox2.Checked = false;
            sIdCard = ds.Tables[0].Rows[0][8].ToString();
            txtIdCard.Text = sIdCard.Substring(0, 6) + "********" + sIdCard.Substring(14);//显示身份证号码
            if (ds.Tables[0].Rows[0][1].ToString() != "")
                pictureBox1.Image = new Bitmap(new MemoryStream((byte[])ds.Tables[0].Rows[0][1]));//显示照片
            lbl1.Text = null;
            if (0 >= new clsSql().sql1(sSqlRecord, "select * from Record where Record_Number = '" + sNumber + "'").Tables[0].Rows.Count)
                new clsSql().sql2(sSqlRecord, "insert into Record (Record_Number,Record_Name,Record_ClassId,Record_Class,Record_Time) values ('" + sNumber + "','" + ds.Tables[0].Rows[0][7].ToString() + "','" + ds.Tables[0].Rows[0][6].ToString() + "','" + ds1.Tables[0].Rows[0][1].ToString() + "',getdate())");
        }

        /// <summary>
        /// 刷新‘groupBox4’中内容
        /// </summary>
        private void group4Refresh()
        {
            label4.Text = "";
            dt1.Clear();
            DataSet ds = new clsSql().sql1(sSqlRecord, "select * from Record ");
            if (ds.Tables[0].Rows.Count <= 0)
                return;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt1.NewRow();
                dr[0] = ds.Tables[0].Rows[i][1];
                dr[1] = ds.Tables[0].Rows[i][2];
                dr[2] = ds.Tables[0].Rows[i][4];
                dr[3] = ds.Tables[0].Rows[i][5];
                dt1.Rows.Add(dr);
            }
            label4.Text = ds.Tables[0].Rows.Count.ToString();
        }

        /// <summary>
        /// 点击‘检录’按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            frmInput.CheckForIllegalCrossThreadCalls = false;//允许线程非安全调用窗体控件
            if (btnOK.Text == "开始检测")
            {
                group3Clear();
                ThreadStart thr_start_func = new ThreadStart(VerifyFinger_Thread);
                fThread = new Thread(thr_start_func);
                fThread.Name = "VerifyFinger_Thread";
                fThread.Start();
                timer1.Start();
                btnOK.Text = "关闭检测";
            }
            else
            {
                timer1.Stop();
                lbl1.Text = "";
                fThread.Abort();
                btnOK.Text = "开始检测";
            }
        }

        /// <summary>
        /// 计时器触发内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!fThread.IsAlive)
            {
                ThreadStart thr_start_func = new ThreadStart(VerifyFinger_Thread);
                fThread = new Thread(thr_start_func);
                fThread.Name = "VerifyFinger_Thread";
                fThread.Start();
            }
        }

        /// <summary>
        /// 打开连接数据库进度条窗体
        /// </summary>
        private void threadA()
        {
            frmLoading1 = new frmLoading();
            frmLoading1.str = "正在访问服务器》》》";
            frmLoading1.ShowDialog();
        }

        /// <summary>
        /// 打开指纹匹配进度条窗体
        /// </summary>
        private void threadB()
        {
            frmLoading1 = new frmLoading();
            frmLoading1.str = "正在进行指纹匹配。。。";
            frmLoading1.ShowDialog();
        }

        /// <summary>
        /// 指纹信息匹配
        /// </summary>
        private void VerifyFinger_Thread()
        {
            while (true)
            {
                int lRV = 0;
                byte[] FingerBuf = new byte[304 * 256]; //图像缓冲区
                byte[] tzBuf = new byte[345];
                byte[] mbBuf = new byte[345];
                string strFileName = "";
                string strNumber = "";
                try
                {
                    lRV = OpticalDriver.mxGetImage(0, FingerBuf, 5000, 1);
                    if (lRV != 0)
                    {
                        lbl1.Text = GetErrorInfo(lRV);
                    }
                    else
                    {
                        strFileName += "image1.bmp";
                        //图像数据流保存成bmp
                        OpticalDriver.mxSaveBMP(strFileName, FingerBuf, 256, 304);
                        //显示图像
                        // this.pictureBox1.Image = Image.FromFile(strFileName);
                        lRV = OpticalDriver.mxGetTzBase64(FingerBuf, tzBuf);
                        threadT = new Thread(new ThreadStart(threadA));
                        threadT.Start();
                        DataSet XiangMu2 = new SqlFile.clsSql().RunProcedure(sSqlTouch, "chaxunyundongyuanzhiwenxinxipipei", new IDataParameter[] { }, "db");
                        if (frmLoading1.InvokeRequired)//判断是否有其他线程想访问
                        {
                            Action act = () => { frmLoading1.Close(); };//封装一个窗体关闭的方法
                            frmLoading1.Invoke(act);//在拥有该控件的线程上执行该方法
                        }
                        if (threadT != null)
                            threadT.Abort();//关闭进程释
                        threadT1 = new Thread(new ThreadStart(threadB));
                        threadT1.Start();
                        int i;
                        for (i = 0; i < XiangMu2.Tables[0].Rows.Count; i++)
                        {
                            if (XiangMu2.Tables[0].Rows[i][2].ToString().Equals("") == false)
                            {
                                mbBuf = (byte[])XiangMu2.Tables[0].Rows[i][2];
                                //验证指纹
                                lRV = OpticalDriver.mxFingerMatchBase64(mbBuf, tzBuf, 3);
                                if (lRV == 0)
                                {
                                    strNumber = XiangMu2.Tables[0].Rows[i][0].ToString();
                                    lbl1.Text = "指纹比对成功";
                                    group3Refresh(strNumber);
                                    group4Refresh();
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
                                    strNumber = XiangMu2.Tables[0].Rows[i][0].ToString();
                                    lbl1.Text = "指纹比对成功";
                                    group3Refresh(strNumber);
                                    group4Refresh();
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
                                    strNumber = XiangMu2.Tables[0].Rows[i][0].ToString();
                                    lbl1.Text = "指纹比对成功";
                                    group3Refresh(strNumber);
                                    group4Refresh();
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
                                    strNumber = XiangMu2.Tables[0].Rows[i][0].ToString();
                                    lbl1.Text = "指纹比对成功";
                                    group3Refresh(strNumber);
                                    group4Refresh();
                                    break;
                                }
                            }
                        }
                        if (i == XiangMu2.Tables[0].Rows.Count)
                        {
                            lbl1.Text = "指纹比对失败";
                            strNumber = "";
                        }
                        //pictureBox1.Image = Image.FromFile(strFileName);
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
                    //MessageBox.Show(this, e.Message, "异常");
                }
                finally
                {
                    fThread.Abort();
                }
            }
        }

        /// <summary>
        /// 输出指纹核对错误原因
        /// </summary>
        /// <param name="ret">错误序号</param>
        /// <returns></returns>
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

        /// <summary>
        /// 改变‘显示证件’复选框组件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (sIdCard.Length != 18)
                return;
            if (checkBox2.Checked)
            {
                txtIdCard.Text = sIdCard;
            }
            else
            {
                String str = sIdCard.Substring(0, 6) + "********" + sIdCard.Substring(14);
                txtIdCard.Text = str;
            }
        }

        /// <summary>
        /// 双击‘dataGridView1’内单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            frmStudent frmStudent1 = new frmStudent();
            frmStudent1.sNumber = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            frmStudent1.Show(this);
        }


        /// <summary>
        /// 双击‘dataGridView2’内单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            frmStudent frmStudent1 = new frmStudent();
            frmStudent1.sNumber = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            frmStudent1.Show(this);
        }

        private void frmInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult r = MessageBox.Show("确定要退出程序?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void frmInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            fThread.Abort();
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


    }
}
