using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    ///考勤数据访问类 
    /// </summary>
    public class AttendanceService
    {
        /// <summary>
        /// 添加打卡数据
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public string  AddRecord(string cardName)
        {
            string sql = $"insert into Attendance(CardNo) values('{cardName}')";
            try
            {
                SQLHelper.Update(sql);
                return "打卡成功";

            }
            catch (Exception)
            {

                return "打卡失败";
            }
        }
        /// <summary>
        /// 返回总人数
        /// </summary>
        /// <returns></returns>
        public int GetStudentCount()
        {
            string sql = "select count(*) from Students";
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql));
        }
        /// <summary>
        /// 当天实到人数
        /// </summary>
        /// <returns></returns>
        public int GetAttendanceStu()
        {
            DateTime dt1=Convert.ToDateTime(SQLHelper.GetServerTime().ToShortDateString());
            DateTime dt2=dt1.AddDays(1);
            string sql = $"select Count(distinct CardNo) from Attendance where DTime between '{dt1}' and '{dt2}'";
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql));
        }
        /// <summary>
        /// 查询某天实到人数
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int GetAttendanceStu(DateTime begin,DateTime end)
        {
         
            string sql = $"select Count(distinct CardNo) from Attendance where DTime between '{begin}' and '{end}'";
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql));
        }
        /// <summary>
        /// 根据日期和姓名查询考信息
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public  List<Student> GetSignByTimeandname(DateTime begin,DateTime end,string name)
        {
            string sql = "select StudentId,StudentName,Gender,DTime,ClassName,Attendance.CardNo from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += " inner join Attendance on Students.CardNo=Attendance.CardNo";
            sql += " where DTime between '{0}' and '{1}'";
            sql = string.Format(sql, begin, end);
            if (name != null && name.Length != 0)
            {
                sql += string.Format(" and StudentName='{0}'", name);
            }
            sql += " Order By DTime ASC";
            SqlDataReader reader=SQLHelper.GetReader(sql);
            List<Student> list = new List<Student>();   
            while (reader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StudentName = reader["StudentName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    CardNo = reader["CardNo"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    SignTime = Convert.ToDateTime(reader["DTime"])
                });
            }
            reader.Close();
            return list;
            }
        
    }
}
