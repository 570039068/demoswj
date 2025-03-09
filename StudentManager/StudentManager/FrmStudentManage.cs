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
            this.cboClass.DisplayMember = "ClassName";//������������ʾ����
            this.cboClass.ValueMember = "ClassId";//������������ʾ���ݶ�Ӧ��value
            this.cboClass.SelectedIndex = -1;//

        }
        //���հ༶��ѯ
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if(this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶", "��ʾ");
                return;
            }
            //ִ�в�ѯ,��������
            this.dgvStudentList.AutoGenerateColumns = false;
            this.stulist = studentService.GetStudentList(this.cboClass.Text);
            this.dgvStudentList.DataSource=stulist;


        }
        //����ѧ�Ų�ѯ
        private void btnQueryById_Click(object sender, EventArgs e)
        {
          if(this.txtStudentId.Text=="")
            {
                MessageBox.Show("�������ѯѧ��", "��ʾ");
                this.txtStudentId.Focus();
                return;
            }
            Student student = studentService.GetStudentById(Convert.ToInt32(this.txtStudentId.Text.Trim()));
            if(student == null)
            {
                MessageBox.Show("ѧԱ��Ϣ������", "��ʾ");
                return;
            }
            else
            {
                FrmStudentInfo studentInfo = new FrmStudentInfo(student);
                studentInfo.Show();
            }
        }
        //�س�id��ѯ����
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
         if(this.txtStudentId.Text.Trim()!=""&&e.KeyCode==Keys.Enter)
            {
                btnQueryById_Click(sender, e); 
                return;
            }
        }
        //˫��ѡ�е�ѧԱ������ʾ��ϸ��Ϣ
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
        //�޸�ѧԱ����
        private void btnEidt_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("û���κ�Ҫ�޸ĵ���Ϣ", "��ʾ");
                return;
            }
            if(this.dgvStudentList.CurrentCell == null)
            {
                MessageBox.Show("��ѡ��Ҫ�޸ĵ���Ϣ", "��ʾ");
                return;
            }
            string studentid = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            Student student=studentService.GetStudentById(Convert.ToInt32(studentid));
            FrmEditStudent  frmEditStudent = new FrmEditStudent(student);
            if(frmEditStudent.ShowDialog()==DialogResult.OK)
            {
                //ˢ��
                btnQuery_Click(sender, e);
            };
        }
        //ɾ��ѧԱ����
        private void btnDel_Click(object sender, EventArgs e)
        {
          
           if(this.dgvStudentList.RowCount==0)
            {
                MessageBox.Show("û��Ҫɾ����ѧ��", "��ʾ");
                return;
            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("��ѡ��Ҫɾ����ѧ��", "��ʾ");
                return;
            }
            //ɾ��ȷ��
            DialogResult result=MessageBox.Show("ȷ��ɾ����?","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                string studentid = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
                if(studentService.DeleteStudent(studentid)==1)
                {
                    btnQuery_Click(sender,e);
                }
            }
        }
        //��������
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
         if(this.cboClass.SelectedIndex == -1)return;
         this.stulist.Sort(new NameDESC());
            this.dgvStudentList.Refresh();
        }
        //ѧ�Ž���
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
         if (this.cboClass.SelectedIndex == -1)return ;
         this.stulist.Sort(new IdDESC());
            this.dgvStudentList.Refresh();
        }
        //����к�
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
        Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }
        //��ӡ��ǰѧԱ��Ϣ
        private void btnPrint_Click(object sender, EventArgs e)
        {
          //���û���б���ʾ,����ʾ��ӡ
          if(this.dgvStudentList.RowCount==0||this.dgvStudentList.CurrentRow==null) return;
          //��ȡ��ǰѧ��
          string stuId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //����ѧ�Ż��ѧ������
            Student student = studentService.GetStudentById(Convert.ToInt32(stuId));
            //����excelģ��ʵ�ִ�ӡԤ��
            ExcelPrint.PrintStudent printStudent = new ExcelPrint.PrintStudent();

            printStudent.ExecPrint(student);
        }

        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //������Excel
        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        #region ����
        /// <summary>
        /// ��������
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
        //�Ҽ��޸�
        private void tsmiModifyStu_Click(object sender, EventArgs e)
        {
            btnEidt_Click(sender, e);
        }
        //�Ҽ�ɾ��
        private void tsmidDeleteStu_Click(object sender, EventArgs e)
        {

        }
    }


}