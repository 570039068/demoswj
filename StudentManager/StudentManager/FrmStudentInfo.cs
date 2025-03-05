using Common;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace StudentManager
{
    public partial class FrmStudentInfo : Form
    {
        public FrmStudentInfo()
        {
            InitializeComponent();
        }
        public FrmStudentInfo(Student objStudent):this()
        {
            //��ʾѧԱ��Ϣ
            this.lblStudentName.Text = objStudent.StudentName;
            this.lblStudentIdNo.Text = objStudent.StudentIdNo.ToString();
            this.lblPhoneNumber.Text = objStudent.PhoneNumber;
            this.lblBirthday.Text = objStudent.Birthday.ToShortDateString();
            this.lblAddress.Text = objStudent.StudentAddress;
            this.lblClass.Text = objStudent.ClassName;
            this.lblGender.Text = objStudent.Gender;
            this.lblCardNo.Text = objStudent.CardNo;

            this.pbStu.Image = objStudent.StuImage.Length != 0 ?
              (Image)new SerializeObjectToString().DeserializeObject(objStudent.StuImage) : Image.FromFile("default.png"); ;

        }

        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}