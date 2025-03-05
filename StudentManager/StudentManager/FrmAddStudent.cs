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
        //���ݷ��ʶ���
        private StudentClassService studentClassService=new StudentClassService();
        private StudentService studentService=new StudentService();
      private  List<Student> studentslist = new List<Student>();//��ʱ������ӵ�ѧ������Ϣ
        public FrmAddStudent()
        {
            InitializeComponent();
            //��ʼ���༶������
            this.cboClassName.DataSource = studentClassService.GetAllClass();
            this.cboClassName.DisplayMember= "ClassName";//������������ʾ����
            this.cboClassName.ValueMember = "ClassId";//������������ʾ���ݶ�Ӧ��value
            this.cboClassName.SelectedIndex = -1;//
      
        }
        //�����ѧԱ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region ������֤
            if (txtStudentName.Text.Trim() == "")
            {
                MessageBox.Show("����������", "��ʾ");
                return;
            }
            if (rdoMale.Checked == false && rdoFemale.Checked == false)
            {
                MessageBox.Show("��ѡ���Ա�", "��ʾ");
                return;
            }
            if (cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶", "��ʾ");
                return;
            }
            if (txtCardNo.Text.Trim() == "")
            {
                MessageBox.Show("�����뿨��", "��ʾ");
                return;
            }
            //��֤���֤�źͳ��������Ƿ����
            string birthDateString = txtStudentIdNo.Text.Substring(6, 8);
            string selectedBirthdayString = dtpBirthday.Value.ToString("yyyyMMdd");
            if (birthDateString != selectedBirthdayString)
            {
                MessageBox.Show("���֤�źͳ������ڲ�ƥ��", "��ʾ");
                return;
            }
            //��֤����
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age > 35 || age < 18)
            {
                MessageBox.Show("���������18-35", "��ʾ");
                return;
            }
            //���֤��ʽ��֤
            if(!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤������Ҫ��", "��ʾ");
                this.txtStudentIdNo.Clear();
                this.txtStudentIdNo.Focus();
                return;
            }

            //�����ݿ��ж����֤�Ƿ����
            if(studentService.IsIdNo(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤���Ѵ���", "��ʾ");
                this.txtStudentIdNo.Clear();
                this.txtStudentIdNo.Focus();
                return;
            }
            //�����ݿ��жϿ����Ƿ����

            if (studentService.IsCardNo(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("���ڿ����Ѵ���", "��ʾ");
                this.txtCardNo.Clear();
                this.txtCardNo.Focus();
                return;
            }












            #endregion
            #region ��סѧ������
            Student objStudent = new Student()
            {
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked ? "��" : "Ů",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                ClassName = this.cboClassName.Text,
                StudentAddress = this.txtAddress.Text.Trim() == "" ? "��ַ����" : this.txtAddress.Text.Trim(),
                CardNo = this.txtCardNo.Text.Trim(),
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//��ȡѡ��༶��ӦclassId
                Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year,
                StuImage = this.pbStu.Image != null ? new SerializeObjectToString().SerializeObject(this.pbStu.Image) : ""

            };


            #endregion
            #region ���ú�̨���ݷ���
            try
            {
                int result = studentService.AddStudent(objStudent);//ִ��������,���ص�һ��һ��(studentId)
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
            #region �����ɺ��������
            // ����ı���
            this.txtStudentName.Text = "";
            this.txtStudentIdNo.Text = "";
            this.txtPhoneNumber.Text = "";
            this.txtAddress.Text = "";
            this.txtCardNo.Text = "";

            // ���õ�ѡ��ť
            this.rdoMale.Checked = false;
            this.rdoFemale.Checked = false;

            // ��������ѡ������������ΪĬ�����ڻ򱣳ֵ�ǰֵ��
            this.dtpBirthday.Value = DateTime.Now; // ������ΪĬ��ֵ

            // ���������ѡ��
            this.cboClassName.SelectedIndex = -1;

            // ���ͼƬ��
            this.pbStu.Image = null;

            // �����㶨λ����һ������ؼ�
            this.txtStudentName.Focus();
            #endregion
        }
        //�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
       

        }
        //ѡ������Ƭ
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog objFileDialog = new OpenFileDialog();
                DialogResult result = objFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                    this.pbStu.Image = Image.FromFile(objFileDialog.FileName);
            }


        }
        //��������ͷ
        private void btnStartVideo_Click(object sender, EventArgs e)
        {
         
        }
        //����
        private void btnTake_Click(object sender, EventArgs e)
        {
        
        }
        //�����Ƭ
        private void btnClear_Click(object sender, EventArgs e)
        {
         this.pbStu.Image = null;
        }

     
    }
}