using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Xml.Linq;
using System.Security.Cryptography;
using Models;

namespace StudentManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.lblCurrentUser.Text = Program.currentAdmin.AdminName + "]";
           
            this.lblVersion.Text = "版本号:" + ConfigurationManager.AppSettings["pversion"];//显示版本号
        }

        #region 嵌入窗体显示
        private void OpenForm(Form form)
        {
            // 遍历容器中的所有控件[Control]
            foreach (Control item in spContainer.Panel2.Controls)  // container.Controls是一个控件集合
            {
                // 判断控件是否为窗体[Form]类型
                if (item is Form)  // 判断item是否是Form类型
                {
                    Form formControl = (Form)item;  // 将控件转换为Form类型
                    formControl.Close();  // 关闭该窗体
                }
            }
           
                form.TopLevel = false;//将子窗体设置成非顶级控件
                form.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                form.Dock = DockStyle.Fill;//设置窗体停靠在容器的整个区域，确保窗体填满父容器
                form.Parent = spContainer.Panel2;  // 设置容器控件[Control]作为子窗体的父控件，指定显示位置
                form.Show();  // 显示子窗体

            

        }
       
        //显示添加新学员窗体       
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
          FrmAddStudent student = new FrmAddStudent();
            //判断右侧容器中是否存在窗体
            OpenForm(student);
           


        }
        private void btnAddStu_Click(object sender, EventArgs e)
        {
            tsmiAddStudent_Click(null, null);
        }
        //批量导入学员信息
        private void tsmi_Import_Click(object sender, EventArgs e)
        {
            FrmImportData objForm = new FrmImportData();
                OpenForm(objForm);
        }
        private void btnImportStu_Click(object sender, EventArgs e)
        {
            tsmi_Import_Click(null, null);
        }
        //考勤打卡      
        private void tsmi_Card_Click(object sender, EventArgs e)
        {
            FrmAttendance objForm = new FrmAttendance();
              OpenForm(objForm);
        }
        private void btnCard_Click(object sender, EventArgs e)
        {
            tsmi_Card_Click(null, null);
        }
        //成绩快速查询【嵌入显示】
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
            FrmScoreQuery objForm = new FrmScoreQuery();
            OpenForm(objForm);
        }
        private void btnScoreQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }
        //学员管理【嵌入显示】
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
            FrmStudentManage objForm = new FrmStudentManage();
            OpenForm(objForm);
        }
        private void btnStuManage_Click(object sender, EventArgs e)
        {
            tsmiManageStudent_Click(null, null);
        }
        //显示成绩查询与分析窗口    
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
            FrmScoreManage objForm = new FrmScoreManage();
            OpenForm(objForm);
        }
        private void btnScoreAnalasys_Click(object sender, EventArgs e)
        {
            tsmiQueryAndAnalysis_Click(null, null);
        }
        //考勤查询
        private void tsmi_AQuery_Click(object sender, EventArgs e)
        {
            FrmAttendanceQuery objForm = new FrmAttendanceQuery();
            OpenForm(objForm);
        }
        private void btnAttendanceQuery_Click(object sender, EventArgs e)
        {
            tsmi_AQuery_Click(null, null);
        }

        #endregion

        #region 退出系统确认

        //退出系统
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result=MessageBox.Show("确认退出吗","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(result!=DialogResult.OK)
            {
                e.Cancel = true;//当设置为 true 时，表示取消事件的默认行为。当设置为 false 时（默认值），表示允许事件的默认行为继续执行。

            }
        }

        #endregion

        #region 其他

        //密码修改
        private void tmiModifyPwd_Click(object sender, EventArgs e)
        {
            FrmModifyPwd objPwd = new FrmModifyPwd();
            objPwd.ShowDialog();
             
        }
        private void btnModifyPwd_Click(object sender, EventArgs e)
        {
            tmiModifyPwd_Click(null, null);
        }
        //账号切换
        private void btnChangeAccount_Click(object sender, EventArgs e)
        {
             FrmUserLogin objUserLogin = new FrmUserLogin();
            objUserLogin.Text = "[账号切换]";
            DialogResult result=objUserLogin.ShowDialog();
            if(result==DialogResult.OK)
            {
                this.lblCurrentUser.Text = Program.currentAdmin.AdminName + "]";
            }
        }
        private void tsbAddStudent_Click(object sender, EventArgs e)
        {
            tsmiAddStudent_Click(null, null);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsmiManageStudent_Click(null, null);
        }
        private void tsbScoreAnalysis_Click(object sender, EventArgs e)
        {
            tsmiQueryAndAnalysis_Click(null, null);
        }
        private void tsbModifyPwd_Click(object sender, EventArgs e)
        {
            tmiModifyPwd_Click(null, null);
        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }

        //访问官网
        private void tsmi_linkxkt_Click(object sender, EventArgs e)
        {
         
        }
        private void btnGoXiketang_Click(object sender, EventArgs e)
        {
            tsmi_linkxkt_Click(null, null);
        }
        //系统升级
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        #endregion



    }
}