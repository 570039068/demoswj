using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
namespace DAL
{
    /// <summary>
    /// 班级数据访问类
    /// </summary>
    public class StudentClassService
    {
        /// <summary>
        /// 查询所有班级对象
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetAllClass()
        {
            string sql = "select ClassName,ClassId from StudentClass";
            SqlDataReader reader = SQLHelper.GetReader(sql);
            List<StudentClass> list = new List<StudentClass>();
            while (reader.Read())
            {
                list.Add(new StudentClass()
                {
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    ClassName = reader["ClassName"].ToString(),
                });
            }
            reader.Close();
            return list;
        }
        //dataset绑定班级
        public DataSet GetClassDataSet()
        {
            string sql = "select ClassName,ClassId from StudentClass";
            return SQLHelper.GetDataSet(sql);
        }

    }
}
