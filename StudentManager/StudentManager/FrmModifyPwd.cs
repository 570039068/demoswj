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
    public partial class FrmModifyPwd : Form
    {
        public FrmModifyPwd()
        {
            InitializeComponent();
        }
        //修改密码
        private SysAdminService adminService=new SysAdminService();
        private void btnModify_Click(object sender, EventArgs e)
        {
            #region 密码验证

            //验证
            if (this.txtOldPwd.Text.Trim()=="")
            {
                MessageBox.Show("请输入原密码", "提示");
                this.txtOldPwd.Focus();
                return;
            }
            if (this.txtNewPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入新密码", "提示");
                this.txtNewPwd.Focus();
                return;
            }
            if (this.txtNewPwdConfirm.Text.Trim() == "")
            {
                MessageBox.Show("请再次输入新密码", "提示");
                this.txtNewPwdConfirm.Focus();
                return;
            }
            if(this.txtOldPwd.Text!=Program.currentAdmin.LoginPwd)
            {
                MessageBox.Show("原密码输入不正确", "提示");
            }
            if(this.txtNewPwd.Text.Trim()!= this.txtNewPwdConfirm.Text.Trim())
            {
                MessageBox.Show("两次密码不同", "提示");
                this.txtNewPwdConfirm.Focus();
                return;
            }
            #endregion
            
            try
            {
                SysAdmin sysAdmin = new SysAdmin();
                sysAdmin.LoginId= Program.currentAdmin.LoginId;
                sysAdmin.LoginPwd = this.txtNewPwdConfirm.Text.Trim();
                if(adminService.ModifyLogin(sysAdmin)==1)
                {
                    MessageBox.Show("密码修改成功", "提示");
                    Program.currentAdmin.LoginPwd=this.txtNewPwdConfirm.Text.Trim();
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
