using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace StudentManager
{
    public partial class FrmScoreManage : Form
    {     
        private StudentClassService studentClassService=new StudentClassService();
        private ScoreListService scoreListService=new ScoreListService();   
        public FrmScoreManage()
        {
            InitializeComponent();
            this.cboClass.DataSource = studentClassService.GetAllClass();
            this.cboClass.DisplayMember = "ClassName";//设置下拉框显示内容
            this.cboClass.ValueMember = "ClassId";//设置下拉框显示内容对应的value
            this.cboClass.SelectedIndex = -1;//

        }     
        //根据班级查询      
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvScoreList.AutoGenerateColumns=false;//不显示datagripview控件中未封装的内容
          //if(this.cboClass.SelectedIndex != -1)
          //  {
          //      MessageBox.Show("请选择查询的班级", "提示");
          //      return;
          //  }
          //  this.dgvScoreList.DataSource = scoreListService.GetScoreList(this.cboClass.Text.Trim());
          //查询数据集
            if (this.cboClass.SelectedIndex != -1)
            {
                this.dgvScoreList.DataSource = scoreListService.GetScoreList(this.cboClass.Text.Trim());
            }
            //查询统计结果


            Dictionary<string, string> dic = scoreListService.QueryScoreInfo(Convert.ToInt32(this.cboClass.SelectedValue));
            this.lblAttendCount.Text = dic["stuCount"];
            this.lblCSharpAvg.Text = dic["avgCSharp"];
            this.lblDBAvg.Text = dic["avgDB"];
            this.lblCount.Text = dic["absentCount"];
            //显示缺考人员姓名
            List<string> list = scoreListService.GetStudentsque(Convert.ToInt32(this.cboClass.SelectedValue));
            this.lblList.Items.Clear();
            if (list.Count == 0) this.lblList.Items.Add("没有缺考");
            else
            {
                lblList.Items.AddRange(list.ToArray());
                //   lblList.DataSource = list;
            }



        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //统计全校考试成绩
        private void btnStat_Click(object sender, EventArgs e)
        {          
                this.dgvScoreList.DataSource = scoreListService.GetScoreList("");

        }

        private void dgvScoreList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Common.DataGridViewStyle.DgvRowPostPaint(this.dgvScoreList, e);
        }

    
     
        //选择框选择改变处理
        private void dgvScoreList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
         
        }

       
    }
}