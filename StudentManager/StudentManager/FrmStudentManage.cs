using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DAL;
using Common;
using System.Collections;
using Models;


namespace StudentManager
{
    public partial class FrmStudentManage : Form
    {
        private StudentClassService studentClassService=new StudentClassService();
        private StudentService studentService=new StudentService();
        private List<Student>stulist=new List<Student>();

        public FrmStudentManage()
        {
            InitializeComponent();
            this.cboClass.DataSource = studentClassService.GetAllClass();
            this.cboClass.DisplayMember = "ClassName";//设置下拉框显示内容
            this.cboClass.ValueMember = "ClassId";//设置下拉框显示内容对应的value
            this.cboClass.SelectedIndex = -1;//

        }
        //按照班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if(this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级", "提示");
                return;
            }
            //执行查询,并绑定数据
            this.dgvStudentList.AutoGenerateColumns = false;
            this.stulist = studentService.GetStudentList(this.cboClass.Text);
            this.dgvStudentList.DataSource=stulist;


        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
          if(this.txtStudentId.Text=="")
            {
                MessageBox.Show("请输入查询学号", "提示");
                this.txtStudentId.Focus();
                return;
            }
            Student student = studentService.GetStudentById(Convert.ToInt32(this.txtStudentId.Text.Trim()));
            if(student == null)
            {
                MessageBox.Show("学员信息不存在", "提示");
                return;
            }
            else
            {
                FrmStudentInfo studentInfo = new FrmStudentInfo(student);
                studentInfo.Show();
            }
        }
        //回车id查询数据
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
         if(this.txtStudentId.Text.Trim()!=""&&e.KeyCode==Keys.Enter)
            {
                btnQueryById_Click(sender, e); 
                return;
            }
        }
        //双击选中的学员对象并显示详细信息
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           if(dgvStudentList.CurrentRow!=null)
            {
                string studentid = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
                Student student = studentService.GetStudentById(Convert.ToInt32(studentid));
                FrmStudentInfo studentInfo = new FrmStudentInfo(student);
                studentInfo.Show();
            }    
        }
        //修改学员对象
        private void btnEidt_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("没有任何要修改的信息", "提示");
                return;
            }
            if(this.dgvStudentList.CurrentCell == null)
            {
                MessageBox.Show("请选中要修改的信息", "提示");
                return;
            }
            string studentid = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            Student student=studentService.GetStudentById(Convert.ToInt32(studentid));
            FrmEditStudent  frmEditStudent = new FrmEditStudent(student);
            if(frmEditStudent.ShowDialog()==DialogResult.OK)
            {
                //刷新
                btnQuery_Click(sender, e);
            };
        }
        //删除学员对象
        private void btnDel_Click(object sender, EventArgs e)
        {
          
           if(this.dgvStudentList.RowCount==0)
            {
                MessageBox.Show("没有要删除的学生", "提示");
                return;
            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("请选中要删除的学生", "提示");
                return;
            }
            //删除确认
            DialogResult result=MessageBox.Show("确认删除吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                string studentid = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
                if(studentService.DeleteStudent(studentid)==1)
                {
                    btnQuery_Click(sender,e);
                }
            }
        }
        //姓名降序
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
         if(this.cboClass.SelectedIndex == -1)return;
         this.stulist.Sort(new NameDESC());
            this.dgvStudentList.Refresh();
        }
        //学号降序
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
         if (this.cboClass.SelectedIndex == -1)return ;
         this.stulist.Sort(new IdDESC());
            this.dgvStudentList.Refresh();
        }
        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
        Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }
        //打印当前学员信息
        private void btnPrint_Click(object sender, EventArgs e)
        {
          //如果没有列表显示,则不显示打印
          if(this.dgvStudentList.RowCount==0||this.dgvStudentList.CurrentRow==null) return;
          //获取当前学号
          string stuId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //根据学号获得学生对象
            Student student = studentService.GetStudentById(Convert.ToInt32(stuId));
            //调用excel模块实现打印预览
            ExcelPrint.PrintStudent printStudent = new ExcelPrint.PrintStudent();

            printStudent.ExecPrint(student);
        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //导出到Excel
        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        #region 排序
        /// <summary>
        /// 姓名降序
        /// </summary>
        public class NameDESC : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return y.StudentName.CompareTo(x.StudentName);
            }
        }

        public class IdDESC : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return y.StudentId.CompareTo(x.StudentId);
            }
        }


        #endregion

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }
        //右键修改
        private void tsmiModifyStu_Click(object sender, EventArgs e)
        {
            btnEidt_Click(sender, e);
        }
        //右键删除
        private void tsmidDeleteStu_Click(object sender, EventArgs e)
        {

        }
    }


}