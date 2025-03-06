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
            if(className != null&&className.Length!=0)//这里添加判断,当查询全校成绩时,不使用where
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
        public Dictionary<string, string> QueryScoreInfo(int classId)
        {
            string sql = "select stuCount=count(*),avgCSharp=avg(CSharp),avgDB=avg(SQLServerDB) from ScoreList ";
            sql += "inner join Students on Students.StudentId=ScoreList.StudentId";
            if( classId !=-1)
            {
                sql += string.Format(" where ClassId={0}", classId);
            }
            sql += ";select absentCount=count(*) from Students where StudentId not in";
            sql += "(select StudentId from ScoreList)";
            if (classId!=-1)
            {
                sql += string.Format(" and ClassId={0}", classId);
            }
            
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            Dictionary<string, string> scoreInfo = null;
            if (objReader.Read())//读取考试成绩统计结果
            {
                scoreInfo = new Dictionary<string, string>();
                scoreInfo.Add("stuCount", objReader["stucount"].ToString());
                scoreInfo.Add("avgCSharp", objReader["avgCSharp"].ToString());
                scoreInfo.Add("avgDB", objReader["avgDB"].ToString());
            }
            if (objReader.NextResult())//读取缺考人数列表
            {
                if (objReader.Read())
                {
                    scoreInfo.Add("absentCount", objReader["absentCount"].ToString());
                }
            }
            objReader.Close();
            return scoreInfo;


        }






        //根据班级(全校)查询缺考人员列表
        public List<string> GetStudentsque(int classId)
        {
            string sql = "select StudentName from Students where StudentId not in ";
            sql += "(select StudentId from ScoreList)";
            if(classId != -1)
            {
                sql += string.Format(" and ClassId='{0}'", classId);
            }
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<string> list = new List<string>();
            while (objReader.Read())
            {
                list.Add(objReader["StudentName"].ToString());
            }
            objReader.Close();
            return list;

        }



    }


}
