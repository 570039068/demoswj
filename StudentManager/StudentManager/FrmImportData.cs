using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace StudentManager
{
    public partial class FrmImportData : Form
    {
        private List<Student> list=null;//用来保存导入的学生对象
        private ImportDataFromExcel ImportDataFromExcel=new ImportDataFromExcel();

        public FrmImportData()
        {
            InitializeComponent();
            this.dgvStudentList.AutoGenerateColumns = false;
        }
        private void btnChoseExcel_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFile.FileName;//获取文件路径
                list = ImportDataFromExcel.GetStudentByExcel(path);
                //显示数据
                this.dgvStudentList.DataSource = null;
                this.dgvStudentList.AutoGenerateColumns = false;
                this.dgvStudentList.DataSource = list;
            }


        }
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Common.DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
        }
        //保存到数据库
        private void btnSaveToDB_Click(object sender, EventArgs e)
        {
            //验证是否有数据
            if(list==null||list.Count==0)
            {
                MessageBox.Show("当前没有要导入的内容", "提示");
                return;
            }
            //遍历集合(方法一:每查询一个对象,就提交一次到数据;方法二:每遍历一次,就生成一条sql语句,基于事务保存对象)
            try
            {
              if(ImportDataFromExcel.Import(this.list))
                {
                    MessageBox.Show("数据导入成功", "提示");
                    this.dgvStudentList.DataSource=null;
                    this.list.Clear();
                }
                else
                {
                    MessageBox.Show("数据导入失败", "提示");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("导入失败" + ex.Message);
            }
        }
    }
}

