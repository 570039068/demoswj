using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 学生数据访问类
    /// </summary>
    /// 

    public class StudentService
    {
        #region 添加学生信息的验证

        //判断身份证号是否存在
        public bool IsIdNo(string idNo,string studentid)
        {
            string sql = $"select count(*) from Students where StudentIdNo='{idNo}'and StudentId<>studentid";
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1)
            {
                return true;
            }
            else { return false; }
        }
        public bool IsIdNo(string idNo)
        {
            string sql = $"select count(*) from Students where StudentIdNo='{idNo}'";
            int result=Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if(result == 1 )
            {
                return true;
            }
            else { return false; }
        }
        public bool IsCardNo(string CardNo, string studentid)
        {
            string sql = $"select count(*) from Students where CardNo='{CardNo}' and StudentId<>studentid";
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1)
            {
                return true;
            }
            else { return false; }
        }
        //判断考勤卡号是否存在
        public bool IsCardNo(string CardNo)
        {
            string sql = $"select count(*) from Students where CardNo='{CardNo}'";
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1)
            {
                return true;
            }
            else { return false; }
        }
        #endregion

        #region 添加学生信息到数据库
        public int AddStudent(Student student)
        {
            string sql = $"insert into Students (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId)  " +
                $" values('{student.StudentName}','{student.Gender}','{student.Birthday.ToString("yyyy-MM-dd")}'," +
                $"{student.Age},'{student.StudentIdNo}','{student.CardNo}'," +
                $"'{student.PhoneNumber}','{student.StudentAddress}',{student.ClassId});select @@identity";
            try
            {

                return Convert.ToInt32(SQLHelper.GetSingleResult(sql));

            }

            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

        #region 查询学生信息
        /// <summary>
        /// 根据班级查询
        /// </summary>
        /// <param name="Classname"></param>
        /// <returns></returns>
        public List<Student> GetStudentList(string Classname)
        {
            string sql = $"select StudentId,StudentName,Gender,Birthday,StudentIdNo,PhoneNumber,ClassName from Students " +
                $"inner join StudentClass on StudentClass.ClassId=Students.ClassId where ClassName='{Classname}' ";
            SqlDataReader reader=SQLHelper.GetReader(sql);
            List<Student> list = new List<Student>();
            while (reader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StudentName = reader["StudentName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    StudentIdNo = reader["StudentIdNo"].ToString(),
                    Birthday = Convert.ToDateTime(reader["Birthday"].ToString()),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    ClassName = reader["ClassName"].ToString()
                });
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// 根据学号查信息
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public Student GetStudentById(int StudentId)
        {
            string sql = $"select StudentId,StudentName,Gender,Birthday,StudentIdNo," +
                $"PhoneNumber,ClassName,StudentAddress,CardNo,StuImage from Students " +
                $"inner join StudentClass on StudentClass.ClassId=Students.ClassId where StudentId='{StudentId}' ";
            SqlDataReader reader = SQLHelper.GetReader(sql);
           Student student = null;
            while (reader.Read())
            {
                student = new Student()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StudentName = reader["StudentName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    StudentIdNo = reader["StudentIdNo"].ToString(),
                    Birthday = Convert.ToDateTime(reader["Birthday"].ToString()),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    CardNo = reader["CardNo"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StuImage = reader["StuImage"] == null ? "" : reader["StuImage"].ToString(),
                };
            }
            reader.Close ();
            return student;
        }




        #endregion

        #region 修改学生信息
        public int ModifyStudent(Student student)
        {
            string sql = $"UPDATE Students SET " +
    $"StudentName = '{student.StudentName}', " +
    $"Gender = '{student.Gender}', " +
    $"Birthday = '{student.Birthday.ToString("yyyy-MM-dd")}', " +
    $"Age = {student.Age}, " +
    $"CardNo = '{student.CardNo}', " +
    $"PhoneNumber = '{student.PhoneNumber}', " +
    $"StudentAddress = '{student.StudentAddress}', StuImage='{student.StuImage}',  " +
    $"StudentIdNo = '{student.StudentIdNo}',"+
    $"ClassId = {student.ClassId}  " +
    $"WHERE StudentId = '{student.StudentId}'";
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (Exception ex)
            {

                throw new Exception("修改异常"+ex.Message);
            }

        }



        #endregion
        #region 删除学生信息
        public int DeleteStudent(string  studentId)
        {
            string sql = $"delete from Students where StudentId='{studentId}'";
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if(ex.Number==547)
                {
                    throw new Exception("被外键关联,不能直接删除");
                }
                else
                {
                    throw new Exception("数据操作异常" + ex.Message);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        #endregion
    }
}
