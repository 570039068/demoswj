using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace DAL
{
    internal class OleDbHelper
    {
        //适用于Excel2003及以前
        //private static string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;";
        //连接字符串(适用于Excel2007之后)
        private static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0";
                                          
        #region 数据库操作

        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql,conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行单一查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        ///返回查询数据集内容
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static OleDbDataReader GetReader(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion


        /// <summary>
        /// 返回数据集内容
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, string path)
        {
            OleDbConnection conn = new OleDbConnection(string.Format(connString, path));
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd); //创建数据适配器对象
            DataSet ds = new DataSet();//创建一个内存数据集
            try
            {
                conn.Open();
                da.Fill(ds);  //使用数据适配器填充数据集
                return ds;  //返回数据集
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
