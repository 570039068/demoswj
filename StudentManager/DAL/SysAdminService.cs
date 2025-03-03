using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL
{
    /// <summary>
    /// 管理员数据访问类
    /// </summary>
    public class SysAdminService
    {
        /// <summary>
        /// 根据账号和密码登录
        /// </summary>
        /// <param name="admin">管理员对象</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //返回值SysAdmin对象>>>>参数SysAdmin
        public SysAdmin AdminLogin(SysAdmin admin)
        {
            //sql语句
            string sql = $"select AdminName from Admins where LoginId={admin.LoginId} and LoginPwd='{admin.LoginPwd}'";
            //调用通用访问类
            try
            {
                SqlDataReader reader=SQLHelper.GetReader(sql);
                if(reader.Read())
                {
                    admin.AdminName = reader["AdminName"].ToString();
                    reader.Close();
                }
                else
                {
                    admin=null;
                }
            }
            catch ( SqlException ex)
            {
                throw new Exception("数据库异常"+ex.Message );
                
            }
            catch(Exception) { throw; }   
            //返回结果
            return admin;
        }

        public int ModifyLogin(SysAdmin admin)
        {
            string sql = $"update Admins set LoginPwd={admin.LoginPwd} where LoginId={admin.LoginId}";
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }













    }
}
