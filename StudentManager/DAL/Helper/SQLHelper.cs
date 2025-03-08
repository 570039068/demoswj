using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Models;
namespace DAL
{
    /// <summary>
    /// 数据库访问通用类
    /// </summary>
    internal class SQLHelper
    {
        public static readonly string connsql = ConfigurationManager.ConnectionStrings["connstring"].ToString();//通过配置文件实现数据库连接字符串
    
        /// <summary>
        /// 执行增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connsql);
            SqlCommand cmd = new SqlCommand(sql,conn);
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
        /// 单一结果查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connsql);
            SqlCommand cmd = new SqlCommand(sql, conn);
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
        /// 执行一个结果集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connsql);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close() ;
                throw ex;
            }
        }

        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            return Convert.ToDateTime(GetSingleResult("select getdate()"));
        }

        public static DataSet GetDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(connsql);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally { conn.Close(); }

        }

        /// <summary>
        /// 启用事务执行多条sql语句
        /// </summary>
        /// <param name="sqlList">sql语句集合</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool UpdateByTram(List<string>sqlList)
        {
            SqlConnection conn = new SqlConnection(connsql);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction= conn.BeginTransaction();//开启事务
                foreach (string sql in sqlList)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                }
                cmd.Transaction.Commit();//提交事务(真正保存到数据库,同时自动清除事务)
                return true;

            }
            catch (Exception ex)
            {
                if(cmd.Transaction!=null)
                    cmd.Transaction.Rollback();//回滚事务,同时自动清除事务
                throw new Exception("调用事务方法出错"+ex.Message);
            }
            finally
            {
                if (cmd.Transaction!=null)
                {
                    cmd.Transaction = null;//清除事务
                }
                conn.Close();
            }

        }

    }
}
