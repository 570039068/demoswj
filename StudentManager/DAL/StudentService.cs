using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 学生数据访问类
    /// </summary>
    public class StudentService
    {
        //判断身份证号是否存在
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
    }
}
