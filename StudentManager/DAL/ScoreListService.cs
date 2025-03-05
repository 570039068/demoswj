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
  
    public class ScoreListService
    {
        #region DataSet查询成绩
        /// <summary>
        /// 成绩数据访问类
        /// </summary>
        public DataSet GetAllScore()
        {
            string sql = "select Students.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB";
            sql += " from Students";
            sql += " inner join StudentClass on StudentClass.ClassId=Students.ClassId ";
            sql += " inner join ScoreList on ScoreList.StudentId=Students.StudentId ";
            return SQLHelper.GetDataSet(sql);
        }
        #endregion

        /// <summary>
        /// 根据班级(全校)查询成绩
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<Student> GetScoreList(string className )
        {
            string sql = "select Students.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB from Students";
               sql += " inner join StudentClass on StudentClass.ClassId=Students.ClassId ";
               sql += " inner join ScoreList on ScoreList.StudentId=Students.StudentId ";
            if(className != null&&className.Length!=0)
            {
                sql+= " where ClassName='" + className + "'";
            }
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Student> list = new List<Student>();  
            while(objReader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    ClassName = objReader["ClassName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    CSharp = Convert.ToInt32(objReader["CSharp"].ToString()),
                    SQLServerDB = (Convert.ToInt32(objReader["SQLServerDB"].ToString())),

                });
            }
            objReader.Close();
            return list;

        }


        //根据班级(全校)统计成绩信息



        //根据班级(全校)查询缺考人员列表

    }


}
