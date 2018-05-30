namespace PracticeAdmin
{
    partial class frmTouch
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
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblNumberY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoWomen = new System.Windows.Forms.RadioButton();
            this.rdoMen = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblMajor = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblTouch = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnProve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(255, 178);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumber.MaxLength = 8;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(281, 25);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(192, 181);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(52, 15);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "学号：";
            // 
            // lblNumberY
            // 
            this.lblNumberY.AutoSize = true;
            this.lblNumberY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNumberY.ForeColor = System.Drawing.Color.Blue;
            this.lblNumberY.Location = new System.Drawing.Point(545, 186);
            this.lblNumberY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberY.Name = "lblNumberY";
            this.lblNumberY.Size = new System.Drawing.Size(27, 18);
            this.lblNumberY.TabIndex = 80;
            this.lblNumberY.Text = "√";
            this.lblNumberY.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(763, 178);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "null";
            this.label1.Visible = false;
            // 
            // rdoWomen
            // 
            this.rdoWomen.AutoCheck = false;
            this.rdoWomen.AutoSize = true;
            this.rdoWomen.Location = new System.Drawing.Point(364, 616);
            this.rdoWomen.Margin = new System.Windows.Forms.Padding(4);
            this.rdoWomen.Name = "rdoWomen";
            this.rdoWomen.Size = new System.Drawing.Size(43, 19);
            this.rdoWomen.TabIndex = 78;
            this.rdoWomen.TabStop = true;
            this.rdoWomen.Text = "女";
            this.rdoWomen.UseVisualStyleBackColor = true;
            // 
            // rdoMen
            // 
            this.rdoMen.AutoCheck = false;
            this.rdoMen.AutoSize = true;
            this.rdoMen.Location = new System.Drawing.Point(255, 616);
            this.rdoMen.Margin = new System.Windows.Forms.Padding(4);
            this.rdoMen.Name = "rdoMen";
            this.rdoMen.Size = new System.Drawing.Size(43, 19);
            this.rdoMen.TabIndex = 77;
            this.rdoMen.TabStop = true;
            this.rdoMen.Text = "男";
            this.rdoMen.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(763, 178);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 384);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(255, 536);
            this.txtClass.Margin = new System.Windows.Forms.Padding(4);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(376, 25);
            this.txtClass.TabIndex = 75;
            // 
            // txtMajor
            // 
            this.txtMajor.Location = new System.Drawing.Point(255, 464);
            this.txtMajor.Margin = new System.Windows.Forms.Padding(4);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.ReadOnly = true;
            this.txtMajor.Size = new System.Drawing.Size(376, 25);
            this.txtMajor.TabIndex = 74;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(255, 386);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(376, 25);
            this.txtDepartment.TabIndex = 73;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(255, 311);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(376, 25);
            this.txtYear.TabIndex = 72;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(255, 242);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(253, 25);
            this.txtName.TabIndex = 71;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(192, 619);
            this.lblSex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(52, 15);
            this.lblSex.TabIndex = 69;
            this.lblSex.Text = "性别：";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(192, 548);
            this.lblClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(52, 15);
            this.lblClass.TabIndex = 68;
            this.lblClass.Text = "班级：";
            // 
            // lblMajor
            // 
            this.lblMajor.AutoSize = true;
            this.lblMajor.Location = new System.Drawing.Point(192, 475);
            this.lblMajor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMajor.Name = "lblMajor";
            this.lblMajor.Size = new System.Drawing.Size(52, 15);
            this.lblMajor.TabIndex = 67;
            this.lblMajor.Text = "专业：";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(192, 398);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(52, 15);
            this.lblDepartment.TabIndex = 66;
            this.lblDepartment.Text = "学部：";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(192, 315);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(52, 15);
            this.lblYear.TabIndex = 65;
            this.lblYear.Text = "年级：";
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(700, 178);
            this.lblPhoto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(52, 15);
            this.lblPhoto.TabIndex = 64;
            this.lblPhoto.Text = "照片：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(192, 246);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 63;
            this.lblName.Text = "姓名：";
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(1148, 588);
            this.txt4.Margin = new System.Windows.Forms.Padding(4);
            this.txt4.Name = "txt4";
            this.txt4.ReadOnly = true;
            this.txt4.Size = new System.Drawing.Size(43, 25);
            this.txt4.TabIndex = 89;
            this.txt4.Text = "null";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(1129, 591);
            this.lbl4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(30, 15);
            this.lbl4.TabIndex = 88;
            this.lbl4.Text = "4：";
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(1029, 588);
            this.txt3.Margin = new System.Windows.Forms.Padding(4);
            this.txt3.Name = "txt3";
            this.txt3.ReadOnly = true;
            this.txt3.Size = new System.Drawing.Size(43, 25);
            this.txt3.TabIndex = 87;
            this.txt3.Text = "null";
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(911, 588);
            this.txt2.Margin = new System.Windows.Forms.Padding(4);
            this.txt2.Name = "txt2";
            this.txt2.ReadOnly = true;
            this.txt2.Size = new System.Drawing.Size(43, 25);
            this.txt2.TabIndex = 86;
            this.txt2.Text = "null";
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(791, 588);
            this.txt1.Margin = new System.Windows.Forms.Padding(4);
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            this.txt1.Size = new System.Drawing.Size(43, 25);
            this.txt1.TabIndex = 85;
            this.txt1.Text = "null";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(1011, 591);
            this.lbl3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(30, 15);
            this.lbl3.TabIndex = 84;
            this.lbl3.Text = "3：";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(891, 591);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(30, 15);
            this.lbl2.TabIndex = 83;
            this.lbl2.Text = "2：";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(767, 591);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(30, 15);
            this.lbl1.TabIndex = 82;
            this.lbl1.Text = "1：";
            // 
            // lblTouch
            // 
            this.lblTouch.AutoSize = true;
            this.lblTouch.Location = new System.Drawing.Point(707, 591);
            this.lblTouch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTouch.Name = "lblTouch";
            this.lblTouch.Size = new System.Drawing.Size(52, 15);
            this.lblTouch.TabIndex = 81;
            this.lblTouch.Text = "指纹：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(769, 634);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 46);
            this.button1.TabIndex = 90;
            this.button1.Text = "删除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(893, 634);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 46);
            this.button2.TabIndex = 91;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1013, 634);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 46);
            this.button3.TabIndex = 92;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1131, 634);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 46);
            this.button4.TabIndex = 93;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnProve
            // 
            this.btnProve.Location = new System.Drawing.Point(1235, 588);
            this.btnProve.Name = "btnProve";
            this.btnProve.Size = new System.Drawing.Size(142, 109);
            this.btnProve.TabIndex = 94;
            this.btnProve.Text = "生成证明";
            this.btnProve.UseVisualStyleBackColor = true;
            this.btnProve.Click += new System.EventHandler(this.btnProve_Click);
            // 
            // frmTouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 826);
            this.Controls.Add(this.btnProve);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblTouch);
            this.Controls.Add(this.lblNumberY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoWomen);
            this.Controls.Add(this.rdoMen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtMajor);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblMajor);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtNumber);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTouch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指纹管理";
            this.Load += new System.EventHandler(this.frmTouch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblNumberY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoWomen;
        private System.Windows.Forms.RadioButton rdoMen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtMajor;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblMajor;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblTouch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnProve;
    }
}