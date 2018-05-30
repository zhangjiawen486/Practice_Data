namespace PracticeAdmin
{
    partial class frmSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblIdCard = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTouch = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.btnTouch = new System.Windows.Forms.Button();
            this.lstStudent = new System.Windows.Forms.ListBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoMen = new System.Windows.Forms.RadioButton();
            this.rdoWomen = new System.Windows.Forms.RadioButton();
            this.lblSex = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(534, 255);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(59, 32);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "刷 新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(143, 201);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(52, 15);
            this.lblDepartment.TabIndex = 17;
            this.lblDepartment.Text = "学部：";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(143, 140);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(52, 15);
            this.lblYear.TabIndex = 16;
            this.lblYear.Text = "学年：";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(209, 198);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(333, 23);
            this.cboDepartment.TabIndex = 14;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(209, 130);
            this.cboYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(243, 23);
            this.cboYear.TabIndex = 13;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // cboClass
            // 
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(211, 261);
            this.cboClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(299, 23);
            this.cboClass.TabIndex = 20;
            this.cboClass.SelectedIndexChanged += new System.EventHandler(this.cboClass_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(144, 265);
            this.lblClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(52, 15);
            this.lblClass.TabIndex = 22;
            this.lblClass.Text = "班级：";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(889, 406);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(309, 25);
            this.txtNumber.TabIndex = 23;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(889, 459);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(309, 25);
            this.txtName.TabIndex = 24;
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(889, 514);
            this.txtIdCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.ReadOnly = true;
            this.txtIdCard.Size = new System.Drawing.Size(309, 25);
            this.txtIdCard.TabIndex = 25;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(889, 569);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTel.Name = "txtTel";
            this.txtTel.ReadOnly = true;
            this.txtTel.Size = new System.Drawing.Size(309, 25);
            this.txtTel.TabIndex = 26;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(827, 410);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(52, 15);
            this.lblNumber.TabIndex = 27;
            this.lblNumber.Text = "学号：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(827, 462);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 28;
            this.lblName.Text = "姓名：";
            // 
            // lblIdCard
            // 
            this.lblIdCard.AutoSize = true;
            this.lblIdCard.Location = new System.Drawing.Point(795, 518);
            this.lblIdCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdCard.Name = "lblIdCard";
            this.lblIdCard.Size = new System.Drawing.Size(82, 15);
            this.lblIdCard.TabIndex = 29;
            this.lblIdCard.Text = "身份证号：";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(811, 572);
            this.lblTel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(67, 15);
            this.lblTel.TabIndex = 30;
            this.lblTel.Text = "电话号：";
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(833, 669);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(145, 64);
            this.btnAdmin.TabIndex = 31;
            this.btnAdmin.Text = "管理";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(1071, 669);
            this.btnClean.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(147, 64);
            this.btnClean.TabIndex = 32;
            this.btnClean.Text = "清除";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(797, 49);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(441, 272);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblTouch
            // 
            this.lblTouch.AutoSize = true;
            this.lblTouch.Location = new System.Drawing.Point(827, 349);
            this.lblTouch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTouch.Name = "lblTouch";
            this.lblTouch.Size = new System.Drawing.Size(52, 15);
            this.lblTouch.TabIndex = 34;
            this.lblTouch.Text = "指纹：";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(887, 349);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(30, 15);
            this.lbl1.TabIndex = 35;
            this.lbl1.Text = "1：";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(972, 349);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(30, 15);
            this.lbl2.TabIndex = 36;
            this.lbl2.Text = "2：";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(1052, 349);
            this.lbl3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(30, 15);
            this.lbl3.TabIndex = 37;
            this.lbl3.Text = "3：";
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(907, 345);
            this.txt1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            this.txt1.Size = new System.Drawing.Size(43, 25);
            this.txt1.TabIndex = 38;
            this.txt1.Text = "null";
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(992, 345);
            this.txt2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt2.Name = "txt2";
            this.txt2.ReadOnly = true;
            this.txt2.Size = new System.Drawing.Size(43, 25);
            this.txt2.TabIndex = 39;
            this.txt2.Text = "null";
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(1071, 345);
            this.txt3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt3.Name = "txt3";
            this.txt3.ReadOnly = true;
            this.txt3.Size = new System.Drawing.Size(43, 25);
            this.txt3.TabIndex = 40;
            this.txt3.Text = "null";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(1137, 349);
            this.lbl4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(30, 15);
            this.lbl4.TabIndex = 41;
            this.lbl4.Text = "4：";
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(1156, 345);
            this.txt4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt4.Name = "txt4";
            this.txt4.ReadOnly = true;
            this.txt4.Size = new System.Drawing.Size(43, 25);
            this.txt4.TabIndex = 42;
            this.txt4.Text = "null";
            // 
            // btnTouch
            // 
            this.btnTouch.Location = new System.Drawing.Point(1225, 345);
            this.btnTouch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTouch.Name = "btnTouch";
            this.btnTouch.Size = new System.Drawing.Size(53, 26);
            this.btnTouch.TabIndex = 43;
            this.btnTouch.Text = "更新";
            this.btnTouch.UseVisualStyleBackColor = true;
            this.btnTouch.Click += new System.EventHandler(this.btnTouch_Click);
            // 
            // lstStudent
            // 
            this.lstStudent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstStudent.FormattingEnabled = true;
            this.lstStudent.ItemHeight = 20;
            this.lstStudent.Location = new System.Drawing.Point(131, 322);
            this.lstStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstStudent.Name = "lstStudent";
            this.lstStudent.Size = new System.Drawing.Size(448, 404);
            this.lstStudent.TabIndex = 44;
            this.lstStudent.SelectedIndexChanged += new System.EventHandler(this.lstStudent_SelectedIndexChanged);
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStudent.Location = new System.Drawing.Point(143, 731);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(0, 20);
            this.lblStudent.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(792, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 46;
            this.label2.Text = "null";
            this.label2.Visible = false;
            // 
            // rdoMen
            // 
            this.rdoMen.AutoCheck = false;
            this.rdoMen.AutoSize = true;
            this.rdoMen.Location = new System.Drawing.Point(904, 628);
            this.rdoMen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoMen.Name = "rdoMen";
            this.rdoMen.Size = new System.Drawing.Size(43, 19);
            this.rdoMen.TabIndex = 47;
            this.rdoMen.TabStop = true;
            this.rdoMen.Text = "男";
            this.rdoMen.UseVisualStyleBackColor = true;
            // 
            // rdoWomen
            // 
            this.rdoWomen.AutoCheck = false;
            this.rdoWomen.AutoSize = true;
            this.rdoWomen.Location = new System.Drawing.Point(975, 628);
            this.rdoWomen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoWomen.Name = "rdoWomen";
            this.rdoWomen.Size = new System.Drawing.Size(43, 19);
            this.rdoWomen.TabIndex = 48;
            this.rdoWomen.TabStop = true;
            this.rdoWomen.Text = "女";
            this.rdoWomen.UseVisualStyleBackColor = true;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(827, 630);
            this.lblSex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(52, 15);
            this.lblSex.TabIndex = 49;
            this.lblSex.Text = "性别：";
            // 
            // frmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 826);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.rdoWomen);
            this.Controls.Add(this.rdoMen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lstStudent);
            this.Controls.Add(this.btnTouch);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblTouch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblIdCard);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtIdCard);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.cboClass);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.cboYear);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "班级查询";
            this.Load += new System.EventHandler(this.frmSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIdCard;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTouch;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Button btnTouch;
        private System.Windows.Forms.ListBox lstStudent;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoMen;
        private System.Windows.Forms.RadioButton rdoWomen;
        private System.Windows.Forms.Label lblSex;

    }
}