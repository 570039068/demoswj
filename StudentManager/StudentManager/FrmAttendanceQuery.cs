using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmAttendanceQuery : Form
    {
     private AttendanceService attendanceService=new AttendanceService();
        public FrmAttendanceQuery()
        {
            InitializeComponent();
            this.dgvStudentList.AutoGenerateColumns = false;
        }
        //查询考勤列表
        private void btnQuery_Click(object sender, EventArgs e)
        {
         //根据日期和姓名查询考勤列表
         DateTime begin=Convert.ToDateTime(this.dtpTime.Text);
            DateTime end=begin.AddDays(1);
            this.dgvStudentList.DataSource=attendanceService.GetSignByTimeandname(begin, end,this.txtName.Text.Trim());
            //根据日期查询考勤统计信息
            //应到人数
            this.lblCount.Text = Convert.ToString(attendanceService.GetStudentCount());
            //实到人数
            this.lblReal.Text = Convert.ToString(attendanceService.GetAttendanceStu(begin,end));
            //缺勤人数
            this.lblAbsenceCount.Text = Convert.ToString(attendanceService.GetStudentCount() - attendanceService.GetAttendanceStu(begin, end));
        }
        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
