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
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }


        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //验证数据
            if(txtLoginId.Text=="")
            {
                MessageBox.Show("请输入账号", "提示");
                txtLoginId.Focus();
                return;
            }
            if(txtLoginPwd.Text=="")
            {
                MessageBox.Show("请输入密码", "提示");
                txtLoginPwd.Focus();
                return;
            }
            //封装对象
            SysAdmin sysAdmin = new SysAdmin();
            sysAdmin.LoginId = Convert.ToInt32(txtLoginId.Text.Trim());
            sysAdmin.LoginPwd = txtLoginPwd.Text.Trim();
            //后台交互
            SysAdminService sysAdminService = new SysAdminService();
            sysAdmin=sysAdminService.AdminLogin(sysAdmin);
            //处理交互结果(保存数据,返回值)
            if (sysAdmin!=null)
            {
                Program.currentAdmin = sysAdmin;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("账号或密码有误", "登录提示");
            }

        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
          
           this.Close();
        }

        private void FrmUserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtLoginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnLogin_Click(sender, e); }
        }
    }
}
