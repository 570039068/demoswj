using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 学员实体类
    /// </summary>
    /// 
    [Serializable]
    public class Student
    {
        public int StudentId { get; set; } // 学生ID
        public string StudentName { get; set; } // 学生姓名
        public string Gender { get; set; } // 性别
        public DateTime Birthday { get; set; } // 生日
        public string StudentIdNo { get; set; } // 身份证号
        public string CardNo { get; set; } // 考勤卡号
        public int Age { get; set; } // 年龄
        public string StuImage {  get; set; }//照片
        public string PhoneNumber { get; set; } // 电话号码
        public string StudentAddress { get; set; } // 地址
        public int ClassId { get; set; } // 班级外键
        //扩展
        public string ClassName {  get; set; }//班级名称

        public int CSharp {  get; set; }
        public int SQLServerDB { get; set; }
        public DateTime SignTime { get; set; }//签到时间


    }
}
