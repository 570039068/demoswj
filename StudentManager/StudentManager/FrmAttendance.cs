using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;  

namespace StudentManager
{
    public partial class FrmAttendance : Form
    {
        private AttendanceService attendanceService=new AttendanceService();
        private StudentService studentService=new StudentService();
        private List<Student>signlist= new List<Student>();
        public FrmAttendance()
        {
            InitializeComponent();
            timer1_Tick(null,null);//构造方法中调用,避免延迟
            this.dgvStudentList.AutoGenerateColumns = false;
            ShowStat();
        }
        private void ShowStat()
        {
            //应到人数
         this.lblCount.Text=   Convert.ToString(attendanceService.GetStudentCount());
            //实到人数
            this.lblReal.Text = Convert.ToString(attendanceService.GetAttendanceStu());
            //缺勤人数
            this.lblAbsenceCount.Text = Convert.ToString(attendanceService.GetStudentCount() - attendanceService.GetAttendanceStu());



        }
        //显示当前时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblYear.Text = DateTime.Now.Year.ToString();
            this.lblMonth.Text = DateTime.Now.Month.ToString();
            this.lblDay.Text = DateTime.Now.Day.ToString();
            this.lblTime.Text = DateTime.Now.ToLongTimeString();
            //显示星期
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday: this.lblWeek.Text= "天"; break;
                case DayOfWeek.Monday: this.lblWeek.Text ="一";break;
                case DayOfWeek.Tuesday: this.lblWeek.Text= "二";break;
                case DayOfWeek.Wednesday: this.lblWeek.Text = "三"; break;
                case DayOfWeek.Thursday: this.lblWeek.Text = "四"; break;
                case DayOfWeek.Friday: this.lblWeek.Text = "五"; break;
                case DayOfWeek.Saturday: this.lblWeek.Text = "六"; break;
             
            }

        }
        //学员打卡        
        private void txtStuCardNo_KeyDown(object sender, KeyEventArgs e)
        {
         if(this.txtStuCardNo.TextLength!=0&&e.KeyCode==Keys.Enter)
            {
                Student student = new Student();
                student = studentService.GetStudentByCardNo(txtStuCardNo.Text.Trim());
                if(student==null)
                {
                    MessageBox.Show("考勤卡号不正确", "提示");
                    this.lblInfo.Text = "打卡失败";
                    this.txtStuCardNo.Clear();
                    this.txtStuCardNo.Focus();
                    return;
                }else
                {
                    this.lblStuName.Text=student.StudentName;
                    this.lblStuId.Text=student.StudentId.ToString();
                    this.lblStuClass.Text=student.ClassName.ToString();
                   
                }
                //添加打卡信息
                string result = attendanceService.AddRecord(this.txtStuCardNo.Text.Trim());
                if(result== "打卡成功")
                {
                    this.lblInfo.Text = "打卡成功";
                    ShowStat();
                    //显示信息在列中
                    student.SignTime = Convert.ToDateTime(DateTime.Now.ToString("G"));
                    signlist.Add(student);
                    this.dgvStudentList.DataSource = null;
                    this.dgvStudentList.DataSource = signlist;
                }
                else
                {
                    this.lblInfo.Text = "打卡失败";
                    MessageBox.Show("打卡失败", "提示");
                }


            }
        }
        //结束打卡
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
