using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 学生实体
    /// </summary>
    public class StudentExt
    { 
        public Student Studentobj {  get; set; }
        public StudentClass Classobj {  get; set; }
        public ScoreList Scoreobj { get; set; }

    }
}
