namespace StudentManager
{
    partial class FrmEditStudent
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditStudent));
            this.btnModify = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.btnChoseImage = new System.Windows.Forms.Button();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.pbStu = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboClassName = new System.Windows.Forms.ComboBox();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStudentIdNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbStu)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModify
            // 
            this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
            this.btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModify.Location = new System.Drawing.Point(1212, 50);
            this.btnModify.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(172, 70);
            this.btnModify.TabIndex = 9;
            this.btnModify.Text = "提交修改";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 24);
            this.label8.TabIndex = 17;
            this.label8.Text = "学号：";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(180, 42);
            this.txtStudentId.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.ReadOnly = true;
            this.txtStudentId.Size = new System.Drawing.Size(282, 35);
            this.txtStudentId.TabIndex = 16;
            // 
            // btnChoseImage
            // 
            this.btnChoseImage.Location = new System.Drawing.Point(130, 576);
            this.btnChoseImage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnChoseImage.Name = "btnChoseImage";
            this.btnChoseImage.Size = new System.Drawing.Size(196, 70);
            this.btnChoseImage.TabIndex = 20;
            this.btnChoseImage.Text = "选择照片";
            this.btnChoseImage.UseVisualStyleBackColor = true;
            this.btnChoseImage.Click += new System.EventHandler(this.btnChoseImage_Click);
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(182, 120);
            this.txtStudentName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(280, 35);
            this.txtStudentName.TabIndex = 0;
            // 
            // pbStu
            // 
            this.pbStu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStu.Location = new System.Drawing.Point(48, 152);
            this.pbStu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbStu.Name = "pbStu";
            this.pbStu.Size = new System.Drawing.Size(376, 392);
            this.pbStu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStu.TabIndex = 19;
            this.pbStu.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Purple;
            this.label9.Location = new System.Drawing.Point(42, 42);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(315, 62);
            this.label9.TabIndex = 18;
            this.label9.Text = "修改学员信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "学生姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(766, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "出生日期：";
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(600, 124);
            this.rdoMale.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(65, 28);
            this.rdoMale.TabIndex = 1;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "男";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(182, 382);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(932, 35);
            this.txtAddress.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 394);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "家庭住址：";
            // 
            // cboClassName
            // 
            this.cboClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassName.FormattingEnabled = true;
            this.cboClassName.Location = new System.Drawing.Point(182, 206);
            this.cboClassName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboClassName.Name = "cboClassName";
            this.cboClassName.Size = new System.Drawing.Size(280, 32);
            this.cboClassName.TabIndex = 4;
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(682, 124);
            this.rdoFemale.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(65, 28);
            this.rdoFemale.TabIndex = 2;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "女";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(652, 292);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(462, 35);
            this.txtPhoneNumber.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStudentName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdoMale);
            this.groupBox1.Controls.Add(this.txtStudentId);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboClassName);
            this.groupBox1.Controls.Add(this.rdoFemale);
            this.groupBox1.Controls.Add(this.txtPhoneNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCardNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpBirthday);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtStudentIdNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(468, 134);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(1174, 488);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[学员基本信息]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 300);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "联系电话：";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(180, 292);
            this.txtCardNo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(282, 35);
            this.txtCardNo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 300);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "考勤卡号：";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthday.Location = new System.Drawing.Point(908, 120);
            this.dtpBirthday.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(206, 35);
            this.dtpBirthday.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "所在班级：";
            // 
            // txtStudentIdNo
            // 
            this.txtStudentIdNo.Location = new System.Drawing.Point(652, 206);
            this.txtStudentIdNo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtStudentIdNo.Name = "txtStudentIdNo";
            this.txtStudentIdNo.Size = new System.Drawing.Size(462, 35);
            this.txtStudentIdNo.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(510, 214);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "身份证号：";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1478, 50);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(164, 70);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmEditStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1688, 690);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChoseImage);
            this.Controls.Add(this.pbStu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnModify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FrmEditStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改学员信息";
            ((System.ComponentModel.ISupportInitialize)(this.pbStu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Button btnChoseImage;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.PictureBox pbStu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboClassName;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStudentIdNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClose;
    }
}