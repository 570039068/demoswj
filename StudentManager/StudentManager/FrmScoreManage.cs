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
            this.cboClass.DisplayMember = "ClassName";//������������ʾ����
            this.cboClass.ValueMember = "ClassId";//������������ʾ���ݶ�Ӧ��value
            this.cboClass.SelectedIndex = -1;//

        }     
        //���ݰ༶��ѯ      
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvScoreList.AutoGenerateColumns=false;//����ʾdatagripview�ؼ���δ��װ������
          //if(this.cboClass.SelectedIndex != -1)
          //  {
          //      MessageBox.Show("��ѡ���ѯ�İ༶", "��ʾ");
          //      return;
          //  }
          //  this.dgvScoreList.DataSource = scoreListService.GetScoreList(this.cboClass.Text.Trim());
          //��ѯ���ݼ�
            if (this.cboClass.SelectedIndex != -1)
            {
                this.dgvScoreList.DataSource = scoreListService.GetScoreList(this.cboClass.Text.Trim());
            }
            //��ѯͳ�ƽ��


            Dictionary<string, string> dic = scoreListService.QueryScoreInfo(Convert.ToInt32(this.cboClass.SelectedValue));
            this.lblAttendCount.Text = dic["stuCount"];
            this.lblCSharpAvg.Text = dic["avgCSharp"];
            this.lblDBAvg.Text = dic["avgDB"];
            this.lblCount.Text = dic["absentCount"];
            //��ʾȱ����Ա����
            List<string> list = scoreListService.GetStudentsque(Convert.ToInt32(this.cboClass.SelectedValue));
            this.lblList.Items.Clear();
            if (list.Count == 0) this.lblList.Items.Add("û��ȱ��");
            else
            {
                lblList.Items.AddRange(list.ToArray());
                //   lblList.DataSource = list;
            }



        }
        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //ͳ��ȫУ���Գɼ�
        private void btnStat_Click(object sender, EventArgs e)
        {          
                this.dgvScoreList.DataSource = scoreListService.GetScoreList("");

        }

        private void dgvScoreList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Common.DataGridViewStyle.DgvRowPostPaint(this.dgvScoreList, e);
        }

    
     
        //ѡ���ѡ��ı䴦��
        private void dgvScoreList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
         
        }

       
    }
}