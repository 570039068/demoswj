using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;
using Common;


namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        //数据访问对象
        private StudentClassService studentClassService=new StudentClassService();
        private StudentService studentService=new StudentService();
      private  List<Student> studentslist = new List<Student>();//临时保存添加的学生的信息
        public FrmAddStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClassName.DataSource = studentClassService.GetAllClass();
            this.cboClassName.DisplayMember= "ClassName";//设置下拉框显示内容
            this.cboClassName.ValueMember = "ClassId";//设置下拉框显示内容对应的value
            this.cboClassName.SelectedIndex = -1;//
      
        }
        //添加新学员
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if (txtStudentName.Text.Trim() == "")
            {
                MessageBox.Show("请输入姓名", "提示");
                return;
            }
            if (rdoMale.Checked == false && rdoFemale.Checked == false)
            {
                MessageBox.Show("请选择性别", "提示");
                return;
            }
            if (cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级", "提示");
                return;
            }
            if (txtCardNo.Text.Trim() == "")
            {
                MessageBox.Show("请输入卡号", "提示");
                return;
            }
            //验证身份证号和出生日期是否相符
            string birthDateString = txtStudentIdNo.Text.Substring(6, 8);
            string selectedBirthdayString = dtpBirthday.Value.ToString("yyyyMMdd");
            if (birthDateString != selectedBirthdayString)
            {
                MessageBox.Show("身份证号和出生日期不匹配", "提示");
                return;
            }
            //验证年龄
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age > 35 || age < 18)
            {
                MessageBox.Show("年龄必须在18-35", "提示");
                return;
            }
            //身份证格式验证
            if(!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证不符合要求", "提示");
                this.txtStudentIdNo.Clear();
                this.txtStudentIdNo.Focus();
                return;
            }

            //从数据库判断身份证是否存在
            if(studentService.IsIdNo(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号已存在", "提示");
                this.txtStudentIdNo.Clear();
                this.txtStudentIdNo.Focus();
                return;
            }
            //从数据库判断卡号是否存在

            if (studentService.IsCardNo(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("考勤卡号已存在", "提示");
                this.txtCardNo.Clear();
                this.txtCardNo.Focus();
                return;
            }












            #endregion
            #region 封住学生对象
            Student objStudent = new Student()
            {
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked ? "男" : "女",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                ClassName = this.cboClassName.Text,
                StudentAddress = this.txtAddress.Text.Trim() == "" ? "地址不详" : this.txtAddress.Text.Trim(),
                CardNo = this.txtCardNo.Text.Trim(),
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//获取选择班级对应classId
                Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year,
                StuImage = this.pbStu.Image != null ? new SerializeObjectToString().SerializeObject(this.pbStu.Image) : ""

            };


            #endregion
            #region 调用后台数据访问
            try
            {
                int result = studentService.AddStudent(objStudent);//执行添加语句,返回第一行一列(studentId)
                if (result > 1)
                {
                    objStudent.StudentId = result;
                    this.studentslist.Add(objStudent);
                    this.dgvStudentList.DataSource = null;
                    this.dgvStudentList.AutoGenerateColumns = false;

                    this.dgvStudentList.DataSource = this.studentslist;
                   
                }
            }
            catch (Exception)
            {

                throw;
            }

            #endregion
            #region 添加完成后清空内容
            // 清空文本框
            this.txtStudentName.Text = "";
            this.txtStudentIdNo.Text = "";
            this.txtPhoneNumber.Text = "";
            this.txtAddress.Text = "";
            this.txtCardNo.Text = "";

            // 重置单选按钮
            this.rdoMale.Checked = false;
            this.rdoFemale.Checked = false;

            // 重置日期选择器（可设置为默认日期或保持当前值）
            this.dtpBirthday.Value = DateTime.Now; // 或设置为默认值

            // 清空下拉框选择
            this.cboClassName.SelectedIndex = -1;

            // 清空图片框
            this.pbStu.Image = null;

            // 将焦点定位到第一个输入控件
            this.txtStudentName.Focus();
            #endregion
        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
       

        }
        //选择新照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog objFileDialog = new OpenFileDialog();
                DialogResult result = objFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                    this.pbStu.Image = Image.FromFile(objFileDialog.FileName);
            }


        }
        //启动摄像头
        private void btnStartVideo_Click(object sender, EventArgs e)
        {
         
        }
        //拍照
        private void btnTake_Click(object sender, EventArgs e)
        {
        
        }
        //清除照片
        private void btnClear_Click(object sender, EventArgs e)
        {
         this.pbStu.Image = null;
        }

     
    }
}