
using Models;
using Microsoft.Office.Interop.Excel;
using System;
namespace StudentManager.ExcelPrint
{
    /// <summary>
    /// 基于excel模板打印学生信息
    /// </summary>
    public class PrintStudent
    {

        public void ExecPrint(Student student)
        {
            
            //1.定义一个工作簿
            dynamic excelApp = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Application excelApp=new Microsoft.Office.Interop.Excel.Application();
            
            //2.获取创建好的工作簿
            //string excelBookPath = "StudentInfo.xlsx";
            string excelBookPath = Environment.CurrentDirectory + "\\StudentInfo.xlsx";
            //3.将现有工作簿加入已经定义的工作簿集合
            excelApp.Workbooks.Add(excelBookPath);
            //4.获取第一个工作表
            Microsoft.Office.Interop.Excel.Worksheet sheet = excelApp.Worksheets[1];
            //5.在当前excel表中写入数据
            
            //写入其他相关数据
            sheet.Cells[4, 4] = student.StudentId;
            sheet.Cells[4, 6] = student.StudentName;
            sheet.Cells[4, 8] = student.Gender;
            sheet.Cells[6, 4] = student.ClassName;
            sheet.Cells[6, 6] = student.PhoneNumber;
            sheet.Cells[8,4]=student.StudentAddress;
            //6.打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);

            //7.释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;


        }
    }
}
