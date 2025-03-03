using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Models;
using DAL;


namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        //���ݷ��ʶ���
        private StudentClassService studentClassService=new StudentClassService();
        private StudentService studentService=new StudentService();

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
         OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if(result==DialogResult.OK)
            {
                this.pbStu.Image= Image.FromFile(openFileDialog.FileName);
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