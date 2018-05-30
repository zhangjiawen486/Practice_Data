namespace Practice
{
    partial class frmInfo
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblIdCard = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.rdoMen = new System.Windows.Forms.RadioButton();
            this.rdoWomen = new System.Windows.Forms.RadioButton();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNumberY = new System.Windows.Forms.Label();
            this.lblNameY = new System.Windows.Forms.Label();
            this.lblIdCardY = new System.Windows.Forms.Label();
            this.lblTelY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("宋体", 14.25F);
            this.lblNumber.Location = new System.Drawing.Point(211, 92);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(67, 19);
            this.lblNumber.TabIndex = 7;
            this.lblNumber.Text = "学 号:";
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("宋体", 14.25F);
            this.txtNumber.Location = new System.Drawing.Point(303, 90);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumber.MaxLength = 8;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(236, 29);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 14.25F);
            this.lblName.Location = new System.Drawing.Point(211, 154);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 19);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "姓 名:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 14.25F);
            this.txtName.Location = new System.Drawing.Point(303, 145);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 29);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblIdCard
            // 
            this.lblIdCard.AutoSize = true;
            this.lblIdCard.Font = new System.Drawing.Font("宋体", 14.25F);
            this.lblIdCard.Location = new System.Drawing.Point(175, 215);
            this.lblIdCard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdCard.Name = "lblIdCard";
            this.lblIdCard.Size = new System.Drawing.Size(114, 19);
            this.lblIdCard.TabIndex = 7;
            this.lblIdCard.Text = "身份证号码:";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Font = new System.Drawing.Font("宋体", 14.25F);
            this.txtIdCard.Location = new System.Drawing.Point(303, 206);
            this.txtIdCard.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdCard.MaxLength = 18;
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(236, 29);
            this.txtIdCard.TabIndex = 2;
            this.txtIdCard.TextChanged += new System.EventHandler(this.txtIdCard_TextChanged);
            this.txtIdCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCard_KeyPress);
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("宋体", 14.25F);
            this.lblTel.Location = new System.Drawing.Point(202, 270);
            this.lblTel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(76, 19);
            this.lblTel.TabIndex = 7;
            this.lblTel.Text = "手机号:";
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("宋体", 14.25F);
            this.txtTel.Location = new System.Drawing.Point(303, 268);
            this.txtTel.Margin = new System.Windows.Forms.Padding(2);
            this.txtTel.MaxLength = 11;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(236, 29);
            this.txtTel.TabIndex = 3;
            this.txtTel.TextChanged += new System.EventHandler(this.txtTel_TextChanged);
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("宋体", 14.25F);
            this.lblYear.Location = new System.Drawing.Point(211, 344);
            this.lblYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(67, 19);
            this.lblYear.TabIndex = 7;
            this.lblYear.Text = "年 级:";
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(303, 341);
            this.cboYear.Margin = new System.Windows.Forms.Padding(2);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(354, 27);
            this.cboYear.TabIndex = 6;
            this.cboYear.TabStop = false;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("宋体", 14.25F);
            this.lblDepartment.Location = new System.Drawing.Point(211, 402);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(67, 19);
            this.lblDepartment.TabIndex = 7;
            this.lblDepartment.Text = "学 部:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(303, 399);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(354, 27);
            this.cboDepartment.TabIndex = 6;
            this.cboDepartment.TabStop = false;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("宋体", 14.25F);
            this.lblClass.Location = new System.Drawing.Point(185, 462);
            this.lblClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(105, 19);
            this.lblClass.TabIndex = 7;
            this.lblClass.Text = "专业/班级:";
            // 
            // cboClass
            // 
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(303, 460);
            this.cboClass.Margin = new System.Windows.Forms.Padding(2);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(354, 24);
            this.cboClass.TabIndex = 6;
            this.cboClass.TabStop = false;
            // 
            // rdoMen
            // 
            this.rdoMen.AutoSize = true;
            this.rdoMen.Font = new System.Drawing.Font("宋体", 14.25F);
            this.rdoMen.Location = new System.Drawing.Point(293, 545);
            this.rdoMen.Margin = new System.Windows.Forms.Padding(2);
            this.rdoMen.Name = "rdoMen";
            this.rdoMen.Size = new System.Drawing.Size(46, 23);
            this.rdoMen.TabIndex = 6;
            this.rdoMen.Text = "男";
            this.rdoMen.UseVisualStyleBackColor = true;
            // 
            // rdoWomen
            // 
            this.rdoWomen.AutoSize = true;
            this.rdoWomen.Font = new System.Drawing.Font("宋体", 14.25F);
            this.rdoWomen.Location = new System.Drawing.Point(457, 545);
            this.rdoWomen.Margin = new System.Windows.Forms.Padding(2);
            this.rdoWomen.Name = "rdoWomen";
            this.rdoWomen.Size = new System.Drawing.Size(46, 23);
            this.rdoWomen.TabIndex = 6;
            this.rdoWomen.Text = "女";
            this.rdoWomen.UseVisualStyleBackColor = true;
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("宋体", 14.25F);
            this.btnClean.Location = new System.Drawing.Point(779, 351);
            this.btnClean.Margin = new System.Windows.Forms.Padding(2);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(148, 75);
            this.btnClean.TabIndex = 5;
            this.btnClean.Text = "刷新";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 14.25F);
            this.btnSave.Location = new System.Drawing.Point(779, 187);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 74);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNumberY
            // 
            this.lblNumberY.AutoSize = true;
            this.lblNumberY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNumberY.ForeColor = System.Drawing.Color.Blue;
            this.lblNumberY.Location = new System.Drawing.Point(544, 98);
            this.lblNumberY.Name = "lblNumberY";
            this.lblNumberY.Size = new System.Drawing.Size(25, 16);
            this.lblNumberY.TabIndex = 8;
            this.lblNumberY.Text = "√";
            this.lblNumberY.Visible = false;
            // 
            // lblNameY
            // 
            this.lblNameY.AutoSize = true;
            this.lblNameY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lblNameY.ForeColor = System.Drawing.Color.Blue;
            this.lblNameY.Location = new System.Drawing.Point(544, 154);
            this.lblNameY.Name = "lblNameY";
            this.lblNameY.Size = new System.Drawing.Size(25, 16);
            this.lblNameY.TabIndex = 9;
            this.lblNameY.Text = "√";
            this.lblNameY.Visible = false;
            // 
            // lblIdCardY
            // 
            this.lblIdCardY.AutoSize = true;
            this.lblIdCardY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lblIdCardY.ForeColor = System.Drawing.Color.Blue;
            this.lblIdCardY.Location = new System.Drawing.Point(544, 215);
            this.lblIdCardY.Name = "lblIdCardY";
            this.lblIdCardY.Size = new System.Drawing.Size(25, 16);
            this.lblIdCardY.TabIndex = 10;
            this.lblIdCardY.Text = "√";
            this.lblIdCardY.Visible = false;
            // 
            // lblTelY
            // 
            this.lblTelY.AutoSize = true;
            this.lblTelY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lblTelY.ForeColor = System.Drawing.Color.Blue;
            this.lblTelY.Location = new System.Drawing.Point(544, 277);
            this.lblTelY.Name = "lblTelY";
            this.lblTelY.Size = new System.Drawing.Size(25, 16);
            this.lblTelY.TabIndex = 11;
            this.lblTelY.Text = "√";
            this.lblTelY.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(575, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "   该学号已存在！\r\n修改信息请联系管理员！";
            this.label1.Visible = false;
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1104, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTelY);
            this.Controls.Add(this.lblIdCardY);
            this.Controls.Add(this.lblNameY);
            this.Controls.Add(this.lblNumberY);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.rdoWomen);
            this.Controls.Add(this.rdoMen);
            this.Controls.Add(this.cboClass);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblIdCard);
            this.Controls.Add(this.txtIdCard);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtNumber);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人信息";
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Label lblIdCard;
        private System.Windows.Forms.RadioButton rdoMen;
        private System.Windows.Forms.RadioButton rdoWomen;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblNumberY;
        private System.Windows.Forms.Label lblNameY;
        private System.Windows.Forms.Label lblIdCardY;
        private System.Windows.Forms.Label lblTelY;
        private System.Windows.Forms.Label label1;
    }
}