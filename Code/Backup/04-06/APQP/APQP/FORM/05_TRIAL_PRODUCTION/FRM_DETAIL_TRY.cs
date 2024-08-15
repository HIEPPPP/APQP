using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using APQP.DB;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data.SqlClient;

namespace APQP.FORM._05_TRIAL_PRODUCTION
{
    public partial class FRM_DETAIL_TRY : DevExpress.XtraEditors.XtraForm
    {
        public FRM_DETAIL_TRY(string ControlNo/*, int CountTrial, int CountTrialIM, int CountTrialASSY*/)
        {
            //this.CountTrial = CountTrial;
            //this.CountTrialIM = CountTrialIM;
            //this.CountTrialASSY = CountTrialASSY;
            this.ControlNo = ControlNo;
            InitializeComponent();
        }
        int CountTrialIM;
        int CountTrialASSY;
        int CountTrial;
        int CountTrialPK;
        string ControlNo;
        string StatusTrial;
        private void FRM_DETAIL_TRY_Load(object sender, EventArgs e)
        {
            try
            {
                gvDataIM.Columns["1ST_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["2ND_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["3RD_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["4TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["5TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["6TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["7TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["8TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["9TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["10TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataIM.Columns["MAIN_CONTENTS"].VisibleIndex = 0;
                gvDataIM.Columns["DETAILED_CONTENTS"].VisibleIndex = 1;
                gvDataIM.Columns["PIC_SECTION"].VisibleIndex = 2;
                gvDataIM.Columns["1ST_TRY"].VisibleIndex = 3;
                gvDataIM.Columns["2ND_TRY"].VisibleIndex = 4;
                gvDataIM.Columns["3RD_TRY"].VisibleIndex = 5;
                gvDataIM.Columns["4TH_TRY"].VisibleIndex = 6;
                gvDataIM.Columns["5TH_TRY"].VisibleIndex = 7;
                gvDataIM.Columns["6TH_TRY"].VisibleIndex = 8;
                gvDataIM.Columns["7TH_TRY"].VisibleIndex = 9;
                gvDataIM.Columns["8TH_TRY"].VisibleIndex = 10;
                gvDataIM.Columns["9TH_TRY"].VisibleIndex = 11;
                gvDataIM.Columns["10TH_TRY"].VisibleIndex = 12;

                gvDataASSY.Columns["1ST_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["2ND_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["3RD_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["4TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["5TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["6TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["7TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["8TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["9TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["10TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataASSY.Columns["MAIN_CONTENTS"].VisibleIndex = 0;
                gvDataASSY.Columns["DETAILED_CONTENTS"].VisibleIndex = 1;
                gvDataASSY.Columns["PIC_SECTION"].VisibleIndex = 2;
                gvDataASSY.Columns["1ST_TRY"].VisibleIndex = 3;
                gvDataASSY.Columns["2ND_TRY"].VisibleIndex = 4;
                gvDataASSY.Columns["3RD_TRY"].VisibleIndex = 5;
                gvDataASSY.Columns["4TH_TRY"].VisibleIndex = 6;
                gvDataASSY.Columns["5TH_TRY"].VisibleIndex = 7;
                gvDataASSY.Columns["6TH_TRY"].VisibleIndex = 8;
                gvDataASSY.Columns["7TH_TRY"].VisibleIndex = 9;
                gvDataASSY.Columns["8TH_TRY"].VisibleIndex = 10;
                gvDataASSY.Columns["9TH_TRY"].VisibleIndex = 11;
                gvDataASSY.Columns["10TH_TRY"].VisibleIndex = 12;

                gvDataPK.Columns["1ST_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["2ND_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["3RD_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["4TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["5TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["6TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["7TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["8TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["9TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["10TH_TRY"].OptionsColumn.AllowEdit = false;
                gvDataPK.Columns["MAIN_CONTENTS"].VisibleIndex = 0;
                gvDataPK.Columns["DETAILED_CONTENTS"].VisibleIndex = 1;
                gvDataPK.Columns["PIC_SECTION"].VisibleIndex = 2;
                gvDataPK.Columns["1ST_TRY"].VisibleIndex = 3;
                gvDataPK.Columns["2ND_TRY"].VisibleIndex = 4;
                gvDataPK.Columns["3RD_TRY"].VisibleIndex = 5;
                gvDataPK.Columns["4TH_TRY"].VisibleIndex = 6;
                gvDataPK.Columns["5TH_TRY"].VisibleIndex = 7;
                gvDataPK.Columns["6TH_TRY"].VisibleIndex = 8;
                gvDataPK.Columns["7TH_TRY"].VisibleIndex = 9;
                gvDataPK.Columns["8TH_TRY"].VisibleIndex = 10;
                gvDataPK.Columns["9TH_TRY"].VisibleIndex = 11;
                gvDataPK.Columns["10TH_TRY"].VisibleIndex = 12;

                string queryCountTrial = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable Data = DBUtils._getData(queryCountTrial);
                if (Data.Rows.Count > 0)
                {
                    CountTrialIM = Convert.ToInt32(Data.Rows[0]["COUNT_TRIAL_IM"]);
                    CountTrialASSY = Convert.ToInt32(Data.Rows[0]["COUNT_TRIAL_ASSY"]);
                    CountTrialPK = Convert.ToInt32(Data.Rows[0]["COUNT_TRIAL_PK"]);
                    StatusTrial = Convert.ToString(Data.Rows[0]["STATUS_TRIAL"]);
                }
                LoadTry();
                LoadData();
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    btnConfirmTrial1.Enabled = true;
                    btnConfirmTrial2.Enabled = true;
                    btnConfirmTrial3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadTry()
        {
            //IM
            if (CountTrialIM == 1)
            {
                gvDataIM.Columns["1ST_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[4].Visible = false;
                gvDataIM.Columns[5].Visible = false;
                gvDataIM.Columns[6].Visible = false;
                gvDataIM.Columns[7].Visible = false;
                gvDataIM.Columns[8].Visible = false;
                gvDataIM.Columns[9].Visible = false;
                gvDataIM.Columns[10].Visible = false;
                gvDataIM.Columns[11].Visible = false;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 2)
            {
                gvDataIM.Columns["2ND_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[5].Visible = false;
                gvDataIM.Columns[6].Visible = false;
                gvDataIM.Columns[7].Visible = false;
                gvDataIM.Columns[8].Visible = false;
                gvDataIM.Columns[9].Visible = false;
                gvDataIM.Columns[10].Visible = false;
                gvDataIM.Columns[11].Visible = false;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 3)
            {
                gvDataIM.Columns["3RD_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[6].Visible = false;
                gvDataIM.Columns[7].Visible = false;
                gvDataIM.Columns[8].Visible = false;
                gvDataIM.Columns[9].Visible = false;
                gvDataIM.Columns[10].Visible = false;
                gvDataIM.Columns[11].Visible = false;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 4)
            {
                gvDataIM.Columns["4TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[7].Visible = false;
                gvDataIM.Columns[8].Visible = false;
                gvDataIM.Columns[9].Visible = false;
                gvDataIM.Columns[10].Visible = false;
                gvDataIM.Columns[11].Visible = false;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 5)
            {
                gvDataIM.Columns["5TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[8].Visible = false;
                gvDataIM.Columns[9].Visible = false;
                gvDataIM.Columns[10].Visible = false;
                gvDataIM.Columns[11].Visible = false;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 6)
            {
                gvDataIM.Columns["6TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[9].Visible = false;
                gvDataIM.Columns[10].Visible = false;
                gvDataIM.Columns[11].Visible = false;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 7)
            {
                gvDataIM.Columns["7TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[10].Visible = false;
                gvDataIM.Columns[11].Visible = false;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 8)
            {
                gvDataIM.Columns["8TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[11].Visible = false;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 9)
            {
                gvDataIM.Columns["9TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataIM.Columns[12].Visible = false;
            }
            if (CountTrialIM == 10)
            {
                gvDataIM.Columns["10TH_TRY"].OptionsColumn.AllowEdit = true;
            }
            //ASSY
            if (CountTrialASSY == 1)
            {
                gvDataASSY.Columns["1ST_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[4].Visible = false;
                gvDataASSY.Columns[5].Visible = false;
                gvDataASSY.Columns[6].Visible = false;
                gvDataASSY.Columns[7].Visible = false;
                gvDataASSY.Columns[8].Visible = false;
                gvDataASSY.Columns[9].Visible = false;
                gvDataASSY.Columns[10].Visible = false;
                gvDataASSY.Columns[11].Visible = false;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 2)
            {
                gvDataASSY.Columns["2ND_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[5].Visible = false;
                gvDataASSY.Columns[6].Visible = false;
                gvDataASSY.Columns[7].Visible = false;
                gvDataASSY.Columns[8].Visible = false;
                gvDataASSY.Columns[9].Visible = false;
                gvDataASSY.Columns[10].Visible = false;
                gvDataASSY.Columns[11].Visible = false;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 3)
            {
                gvDataASSY.Columns["3RD_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[6].Visible = false;
                gvDataASSY.Columns[7].Visible = false;
                gvDataASSY.Columns[8].Visible = false;
                gvDataASSY.Columns[9].Visible = false;
                gvDataASSY.Columns[10].Visible = false;
                gvDataASSY.Columns[11].Visible = false;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 4)
            {
                gvDataASSY.Columns["4TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[7].Visible = false;
                gvDataASSY.Columns[8].Visible = false;
                gvDataASSY.Columns[9].Visible = false;
                gvDataASSY.Columns[10].Visible = false;
                gvDataASSY.Columns[11].Visible = false;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 5)
            {
                gvDataASSY.Columns["5TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[8].Visible = false;
                gvDataASSY.Columns[9].Visible = false;
                gvDataASSY.Columns[10].Visible = false;
                gvDataASSY.Columns[11].Visible = false;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 6)
            {
                gvDataASSY.Columns["6TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[9].Visible = false;
                gvDataASSY.Columns[10].Visible = false;
                gvDataASSY.Columns[11].Visible = false;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 7)
            {
                gvDataASSY.Columns["7TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[10].Visible = false;
                gvDataASSY.Columns[11].Visible = false;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 8)
            {
                gvDataASSY.Columns["8TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[11].Visible = false;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 9)
            {
                gvDataASSY.Columns["9TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataASSY.Columns[12].Visible = false;
            }
            if (CountTrialASSY == 10)
            {
                gvDataASSY.Columns["10TH_TRY"].OptionsColumn.AllowEdit = true;
            }
            //PK
            if (CountTrialPK == 1)
            {
                gvDataPK.Columns["1ST_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[4].Visible = false;
                gvDataPK.Columns[5].Visible = false;
                gvDataPK.Columns[6].Visible = false;
                gvDataPK.Columns[7].Visible = false;
                gvDataPK.Columns[8].Visible = false;
                gvDataPK.Columns[9].Visible = false;
                gvDataPK.Columns[10].Visible = false;
                gvDataPK.Columns[11].Visible = false;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 2)
            {
                gvDataPK.Columns["2ND_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[5].Visible = false;
                gvDataPK.Columns[6].Visible = false;
                gvDataPK.Columns[7].Visible = false;
                gvDataPK.Columns[8].Visible = false;
                gvDataPK.Columns[9].Visible = false;
                gvDataPK.Columns[10].Visible = false;
                gvDataPK.Columns[11].Visible = false;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 3)
            {
                gvDataPK.Columns["3RD_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[6].Visible = false;
                gvDataPK.Columns[7].Visible = false;
                gvDataPK.Columns[8].Visible = false;
                gvDataPK.Columns[9].Visible = false;
                gvDataPK.Columns[10].Visible = false;
                gvDataPK.Columns[11].Visible = false;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 4)
            {
                gvDataPK.Columns["4TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[7].Visible = false;
                gvDataPK.Columns[8].Visible = false;
                gvDataPK.Columns[9].Visible = false;
                gvDataPK.Columns[10].Visible = false;
                gvDataPK.Columns[11].Visible = false;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 5)
            {
                gvDataPK.Columns["5TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[8].Visible = false;
                gvDataPK.Columns[9].Visible = false;
                gvDataPK.Columns[10].Visible = false;
                gvDataPK.Columns[11].Visible = false;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 6)
            {
                gvDataPK.Columns["6TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[9].Visible = false;
                gvDataPK.Columns[10].Visible = false;
                gvDataPK.Columns[11].Visible = false;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 7)
            {
                gvDataPK.Columns["7TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[10].Visible = false;
                gvDataPK.Columns[11].Visible = false;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 8)
            {
                gvDataPK.Columns["8TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[11].Visible = false;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 9)
            {
                gvDataPK.Columns["9TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataPK.Columns[12].Visible = false;
            }
            if (CountTrialPK == 10)
            {
                gvDataPK.Columns["10TH_TRY"].OptionsColumn.AllowEdit = true;
            }
        }
        private void LoadData()
        {
            try
            {
                string queryDataStageIM = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM'";
                DataTable DataStageIM = DBUtils._getData(queryDataStageIM);
                gcDataIM.DataSource = DataStageIM;
                string queryDataStageASSY = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY'";
                DataTable DataStageASSY = DBUtils._getData(queryDataStageASSY);
                gcDataASSY.DataSource = DataStageASSY;
                string queryDataStagePK = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK'";
                DataTable DataStagePK = DBUtils._getData(queryDataStagePK);
                gcDataPK.DataSource = DataStagePK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gvData_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    DXMouseEventArgs ea = e as DXMouseEventArgs;
            //    GridView view = sender as GridView;
            //    GridHitInfo info = view.CalcHitInfo(ea.Location);
            //    if (info.InRow || info.InRowCell)
            //    {
            //        string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
            //        if (colCaption == "1st try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 0);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "2nd try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 1);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "3rd try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 2);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "4th try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 3);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "5th try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 4);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "6th try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 5);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "7th try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 6);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "8th try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 7);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "9th try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 8);
            //            f.ShowDialog();
            //        }
            //        if (colCaption == "10th try")
            //        {
            //            FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, 9);
            //            f.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (StatusTrial == "02" || StatusTrial == "03" || StatusTrial == "04")
                {
                    MessageBox.Show("Thông tin đã được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (Constaint._access != "01")
                    {
                        for (int i = 0; i < gvDataIM.RowCount; i++)
                        {
                            DataRow row = gvDataIM.GetDataRow(i);
                            string Section = Convert.ToString(row["PIC_SECTION"]);
                            if (Section == Constaint._sectionShort)
                            {
                                string querySave = "UPDATE TBL_TRIAL_PRODUCTION SET [1ST_TRY] = @1ST_TRY, [2ND_TRY] = @2ND_TRY, [3RD_TRY] = @3RD_TRY, [4TH_TRY] = @4TH_TRY, [5TH_TRY] = @5TH_TRY, [6TH_TRY] = @6TH_TRY, [7TH_TRY] = @7TH_TRY, [8TH_TRY] = @8TH_TRY, [9TH_TRY] = @9TH_TRY, [10TH_TRY] = @10TH_TRY , TEMPORARY_TRY = @TEMPORARY_TRY, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                        cmd.Parameters.AddWithValue("@1ST_TRY", Convert.ToString(row["1ST_TRY"]));
                                        cmd.Parameters.AddWithValue("@2ND_TRY", Convert.ToString(row["2ND_TRY"]));
                                        cmd.Parameters.AddWithValue("@3RD_TRY", Convert.ToString(row["3RD_TRY"]));
                                        cmd.Parameters.AddWithValue("@4TH_TRY", Convert.ToString(row["4TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@5TH_TRY", Convert.ToString(row["5TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@6TH_TRY", Convert.ToString(row["6TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@7TH_TRY", Convert.ToString(row["7TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@8TH_TRY", Convert.ToString(row["8TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@9TH_TRY", Convert.ToString(row["9TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@10TH_TRY", Convert.ToString(row["10TH_TRY"]));
                                        if (CountTrialIM == 1)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["1ST_TRY"]));
                                        }
                                        if (CountTrialIM == 2)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["2ND_TRY"]));
                                        }
                                        if (CountTrialIM == 3)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["3RD_TRY"]));
                                        }
                                        if (CountTrialIM == 4)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["4TH_TRY"]));
                                        }
                                        if (CountTrialIM == 5)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["5TH_TRY"]));
                                        }
                                        if (CountTrialIM == 6)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["6TH_TRY"]));
                                        }
                                        if (CountTrialIM == 7)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["7TH_TRY"]));
                                        }
                                        if (CountTrialIM == 8)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["8TH_TRY"]));
                                        }
                                        if (CountTrialIM == 9)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["9TH_TRY"]));
                                        }
                                        if (CountTrialIM == 10)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["10TH_TRY"]));
                                        }
                                        cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    if (Constaint._access == "01")
                    {
                        for (int i = 0; i < gvDataIM.RowCount; i++)
                        {
                            DataRow row = gvDataIM.GetDataRow(i);
                            string querySave = "UPDATE TBL_TRIAL_PRODUCTION SET [1ST_TRY] = @1ST_TRY, [2ND_TRY] = @2ND_TRY, [3RD_TRY] = @3RD_TRY, [4TH_TRY] = @4TH_TRY, [5TH_TRY] = @5TH_TRY, [6TH_TRY] = @6TH_TRY, [7TH_TRY] = @7TH_TRY, [8TH_TRY] = @8TH_TRY, [9TH_TRY] = @9TH_TRY, [10TH_TRY] = @10TH_TRY, TEMPORARY_TRY = @TEMPORARY_TRY, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    cmd.Parameters.AddWithValue("@1ST_TRY", Convert.ToString(row["1ST_TRY"]));
                                    cmd.Parameters.AddWithValue("@2ND_TRY", Convert.ToString(row["2ND_TRY"]));
                                    cmd.Parameters.AddWithValue("@3RD_TRY", Convert.ToString(row["3RD_TRY"]));
                                    cmd.Parameters.AddWithValue("@4TH_TRY", Convert.ToString(row["4TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@5TH_TRY", Convert.ToString(row["5TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@6TH_TRY", Convert.ToString(row["6TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@7TH_TRY", Convert.ToString(row["7TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@8TH_TRY", Convert.ToString(row["8TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@9TH_TRY", Convert.ToString(row["9TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@10TH_TRY", Convert.ToString(row["10TH_TRY"]));
                                    if (CountTrialIM == 1)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["1ST_TRY"]));
                                    }
                                    if (CountTrialIM == 2)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["2ND_TRY"]));
                                    }
                                    if (CountTrialIM == 3)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["3RD_TRY"]));
                                    }
                                    if (CountTrialIM == 4)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["4TH_TRY"]));
                                    }
                                    if (CountTrialIM == 5)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["5TH_TRY"]));
                                    }
                                    if (CountTrialIM == 6)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["6TH_TRY"]));
                                    }
                                    if (CountTrialIM == 7)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["7TH_TRY"]));
                                    }
                                    if (CountTrialIM == 8)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["8TH_TRY"]));
                                    }
                                    if (CountTrialIM == 9)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["9TH_TRY"]));
                                    }
                                    if (CountTrialIM == 10)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["10TH_TRY"]));
                                    }
                                    cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Lưu Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAddTry1_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStatus = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable DataStatus = DBUtils._getData(queryStatus);
                string StatusTrial = DataStatus.Rows[0]["STATUS_TRIAL"].ToString();
                if (StatusTrial == "02" || StatusTrial == "03")
                {
                    MessageBox.Show("Thông tin kết quả chạy thử đã được xác nhận.\nkhông thể thêm lần chạy thử!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận thêm lần chạy thử", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string queryUpdateCountTrial = "UPDATE TBL_NEW_MOLD_MST SET COUNT_TRIAL_IM  = @COUNT_TRIAL_IM WHERE CONTROL_NO = '" + ControlNo + "'";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryUpdateCountTrial, _conn))
                        {
                            cmd.Parameters.AddWithValue("@COUNT_TRIAL_IM", CountTrialIM + 1);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Thêm Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FRM_DETAIL_TRY_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAddTry2_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStatus = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable DataStatus = DBUtils._getData(queryStatus);
                string StatusTrial = DataStatus.Rows[0]["STATUS_TRIAL"].ToString();
                if (StatusTrial == "03")
                {
                    MessageBox.Show("Thông tin kết quả chạy thử đã được xác nhận.\nkhông thể thêm lần chạy thử!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận thêm lần chạy thử", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string queryUpdateCountTrial = "UPDATE TBL_NEW_MOLD_MST SET COUNT_TRIAL_ASSY = @COUNT_TRIAL_ASSY WHERE CONTROL_NO = '" + ControlNo + "'";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryUpdateCountTrial, _conn))
                        {
                            cmd.Parameters.AddWithValue("@COUNT_TRIAL_ASSY", CountTrialASSY + 1);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Thêm Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FRM_DETAIL_TRY_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                if (StatusTrial == "03" || StatusTrial == "04")
                {
                    MessageBox.Show("Thông tin đã được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //if (StatusTrial == "01")
                //{
                //    MessageBox.Show("Thông tin công đoạn đúc chưa được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (Constaint._access != "01")
                    {
                        for (int i = 0; i < gvDataASSY.RowCount; i++)
                        {
                            DataRow row = gvDataASSY.GetDataRow(i);
                            string Section = Convert.ToString(row["PIC_SECTION"]);
                            if (Section == Constaint._sectionShort)
                            {
                                string queryItems = "UPDATE TBL_TRIAL_PRODUCTION SET [1ST_TRY] = @1ST_TRY, [2ND_TRY] = @2ND_TRY, [3RD_TRY] = @3RD_TRY, [4TH_TRY] = @4TH_TRY, [5TH_TRY] = @5TH_TRY, [6TH_TRY] = @6TH_TRY, [7TH_TRY] = @7TH_TRY, [8TH_TRY] = @8TH_TRY, [9TH_TRY] = @9TH_TRY, [10TH_TRY] = @10TH_TRY, TEMPORARY_TRY = @TEMPORARY_TRY, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                        cmd.Parameters.AddWithValue("@1ST_TRY", Convert.ToString(row["1ST_TRY"]));
                                        cmd.Parameters.AddWithValue("@2ND_TRY", Convert.ToString(row["2ND_TRY"]));
                                        cmd.Parameters.AddWithValue("@3RD_TRY", Convert.ToString(row["3RD_TRY"]));
                                        cmd.Parameters.AddWithValue("@4TH_TRY", Convert.ToString(row["4TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@5TH_TRY", Convert.ToString(row["5TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@6TH_TRY", Convert.ToString(row["6TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@7TH_TRY", Convert.ToString(row["7TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@8TH_TRY", Convert.ToString(row["8TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@9TH_TRY", Convert.ToString(row["9TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@10TH_TRY", Convert.ToString(row["10TH_TRY"]));
                                        if (CountTrialASSY == 1)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["1ST_TRY"]));
                                        }
                                        if (CountTrialASSY == 2)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["2ND_TRY"]));
                                        }
                                        if (CountTrialASSY == 3)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["3RD_TRY"]));
                                        }
                                        if (CountTrialASSY == 4)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["4TH_TRY"]));
                                        }
                                        if (CountTrialASSY == 5)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["5TH_TRY"]));
                                        }
                                        if (CountTrialASSY == 6)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["6TH_TRY"]));
                                        }
                                        if (CountTrialASSY == 7)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["7TH_TRY"]));
                                        }
                                        if (CountTrialASSY == 8)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["8TH_TRY"]));
                                        }
                                        if (CountTrialASSY == 9)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["9TH_TRY"]));
                                        }
                                        if (CountTrialASSY == 10)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["10TH_TRY"]));
                                        }
                                        cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    if (Constaint._access == "01")
                    {
                        for (int i = 0; i < gvDataASSY.RowCount; i++)
                        {
                            DataRow row = gvDataASSY.GetDataRow(i);
                            string queryItems = "UPDATE TBL_TRIAL_PRODUCTION SET [1ST_TRY] = @1ST_TRY, [2ND_TRY] = @2ND_TRY, [3RD_TRY] = @3RD_TRY, [4TH_TRY] = @4TH_TRY, [5TH_TRY] = @5TH_TRY, [6TH_TRY] = @6TH_TRY, [7TH_TRY] = @7TH_TRY, [8TH_TRY] = @8TH_TRY, [9TH_TRY] = @9TH_TRY, [10TH_TRY] = @10TH_TRY, TEMPORARY_TRY = @TEMPORARY_TRY, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    cmd.Parameters.AddWithValue("@1ST_TRY", Convert.ToString(row["1ST_TRY"]));
                                    cmd.Parameters.AddWithValue("@2ND_TRY", Convert.ToString(row["2ND_TRY"]));
                                    cmd.Parameters.AddWithValue("@3RD_TRY", Convert.ToString(row["3RD_TRY"]));
                                    cmd.Parameters.AddWithValue("@4TH_TRY", Convert.ToString(row["4TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@5TH_TRY", Convert.ToString(row["5TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@6TH_TRY", Convert.ToString(row["6TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@7TH_TRY", Convert.ToString(row["7TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@8TH_TRY", Convert.ToString(row["8TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@9TH_TRY", Convert.ToString(row["9TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@10TH_TRY", Convert.ToString(row["10TH_TRY"]));
                                    if (CountTrialASSY == 1)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["1ST_TRY"]));
                                    }
                                    if (CountTrialASSY == 2)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["2ND_TRY"]));
                                    }
                                    if (CountTrialASSY == 3)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["3RD_TRY"]));
                                    }
                                    if (CountTrialASSY == 4)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["4TH_TRY"]));
                                    }
                                    if (CountTrialASSY == 5)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["5TH_TRY"]));
                                    }
                                    if (CountTrialASSY == 6)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["6TH_TRY"]));
                                    }
                                    if (CountTrialASSY == 7)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["7TH_TRY"]));
                                    }
                                    if (CountTrialASSY == 8)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["8TH_TRY"]));
                                    }
                                    if (CountTrialASSY == 9)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["9TH_TRY"]));
                                    }
                                    if (CountTrialASSY == 10)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["10TH_TRY"]));
                                    }
                                    cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Lưu Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnConfirmTrial1_Click(object sender, EventArgs e)
        {
            FRM_CONFIRM_TRIAL f = new FRM_CONFIRM_TRIAL(ControlNo, CountTrialIM, "IM", "Assy");
            if (f.ShowDialog() == DialogResult.OK)
            {
                FRM_DETAIL_TRY_Load(sender, e);
            }
        }

        private void btnConfirmTrial2_Click(object sender, EventArgs e)
        {
            //if (StatusTrial != "02")
            //{
            //    MessageBox.Show("Thông tin công đoạn trước chưa được xác nhận, Không thể xác nhận!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            FRM_CONFIRM_TRIAL f = new FRM_CONFIRM_TRIAL(ControlNo, CountTrialASSY, "ASSY", "Assy");
            if (f.ShowDialog() == DialogResult.OK)
            {
                FRM_DETAIL_TRY_Load(sender, e);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            try
            {
                if (StatusTrial == "04")
                {
                    MessageBox.Show("Thông tin đã được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //if (StatusTrial == "01" || StatusTrial == "02")
                //{
                //    MessageBox.Show("Thông tin công đoạn trước chưa được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (Constaint._access != "01")
                    {
                        for (int i = 0; i < gvDataPK.RowCount; i++)
                        {
                            DataRow row = gvDataPK.GetDataRow(i);
                            string Section = Convert.ToString(row["PIC_SECTION"]);
                            if (Section == Constaint._sectionShort)
                            {
                                string queryItems = "UPDATE TBL_TRIAL_PRODUCTION SET [1ST_TRY] = @1ST_TRY, [2ND_TRY] = @2ND_TRY, [3RD_TRY] = @3RD_TRY, [4TH_TRY] = @4TH_TRY, [5TH_TRY] = @5TH_TRY, [6TH_TRY] = @6TH_TRY, [7TH_TRY] = @7TH_TRY, [8TH_TRY] = @8TH_TRY, [9TH_TRY] = @9TH_TRY, [10TH_TRY] = @10TH_TRY , TEMPORARY_TRY = @TEMPORARY_TRY, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                        cmd.Parameters.AddWithValue("@1ST_TRY", Convert.ToString(row["1ST_TRY"]));
                                        cmd.Parameters.AddWithValue("@2ND_TRY", Convert.ToString(row["2ND_TRY"]));
                                        cmd.Parameters.AddWithValue("@3RD_TRY", Convert.ToString(row["3RD_TRY"]));
                                        cmd.Parameters.AddWithValue("@4TH_TRY", Convert.ToString(row["4TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@5TH_TRY", Convert.ToString(row["5TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@6TH_TRY", Convert.ToString(row["6TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@7TH_TRY", Convert.ToString(row["7TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@8TH_TRY", Convert.ToString(row["8TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@9TH_TRY", Convert.ToString(row["9TH_TRY"]));
                                        cmd.Parameters.AddWithValue("@10TH_TRY", Convert.ToString(row["10TH_TRY"]));
                                        if (CountTrialPK == 1)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["1ST_TRY"]));
                                        }
                                        if (CountTrialPK == 2)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["2ND_TRY"]));
                                        }
                                        if (CountTrialPK == 3)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["3RD_TRY"]));
                                        }
                                        if (CountTrialPK == 4)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["4TH_TRY"]));
                                        }
                                        if (CountTrialPK == 5)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["5TH_TRY"]));
                                        }
                                        if (CountTrialPK == 6)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["6TH_TRY"]));
                                        }
                                        if (CountTrialPK == 7)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["7TH_TRY"]));
                                        }
                                        if (CountTrialPK == 8)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["8TH_TRY"]));
                                        }
                                        if (CountTrialPK == 9)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["9TH_TRY"]));
                                        }
                                        if (CountTrialPK == 10)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["10TH_TRY"]));
                                        }
                                        cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    if (Constaint._access == "01")
                    {
                        for (int i = 0; i < gvDataPK.RowCount; i++)
                        {
                            DataRow row = gvDataPK.GetDataRow(i);
                            string queryItems = "UPDATE TBL_TRIAL_PRODUCTION SET [1ST_TRY] = @1ST_TRY, [2ND_TRY] = @2ND_TRY, [3RD_TRY] = @3RD_TRY, [4TH_TRY] = @4TH_TRY, [5TH_TRY] = @5TH_TRY, [6TH_TRY] = @6TH_TRY, [7TH_TRY] = @7TH_TRY, [8TH_TRY] = @8TH_TRY, [9TH_TRY] = @9TH_TRY, [10TH_TRY] = @10TH_TRY , TEMPORARY_TRY = @TEMPORARY_TRY, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    cmd.Parameters.AddWithValue("@1ST_TRY", Convert.ToString(row["1ST_TRY"]));
                                    cmd.Parameters.AddWithValue("@2ND_TRY", Convert.ToString(row["2ND_TRY"]));
                                    cmd.Parameters.AddWithValue("@3RD_TRY", Convert.ToString(row["3RD_TRY"]));
                                    cmd.Parameters.AddWithValue("@4TH_TRY", Convert.ToString(row["4TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@5TH_TRY", Convert.ToString(row["5TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@6TH_TRY", Convert.ToString(row["6TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@7TH_TRY", Convert.ToString(row["7TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@8TH_TRY", Convert.ToString(row["8TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@9TH_TRY", Convert.ToString(row["9TH_TRY"]));
                                    cmd.Parameters.AddWithValue("@10TH_TRY", Convert.ToString(row["10TH_TRY"]));
                                    if (CountTrialPK == 1)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["1ST_TRY"]));
                                    }
                                    if (CountTrialPK == 2)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["2ND_TRY"]));
                                    }
                                    if (CountTrialPK == 3)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["3RD_TRY"]));
                                    }
                                    if (CountTrialPK == 4)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["4TH_TRY"]));
                                    }
                                    if (CountTrialPK == 5)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["5TH_TRY"]));
                                    }
                                    if (CountTrialPK == 6)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["6TH_TRY"]));
                                    }
                                    if (CountTrialPK == 7)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["7TH_TRY"]));
                                    }
                                    if (CountTrialPK == 8)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["8TH_TRY"]));
                                    }
                                    if (CountTrialPK == 9)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["9TH_TRY"]));
                                    }
                                    if (CountTrialPK == 10)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["10TH_TRY"]));
                                    }
                                    cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Lưu Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnConfirmTrial3_Click(object sender, EventArgs e)
        {
            if (StatusTrial != "03")
            {
                MessageBox.Show("Thông tin công đoạn trước chưa được xác nhận, Không thể xác nhận!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_CONFIRM_TRIAL f = new FRM_CONFIRM_TRIAL(ControlNo, CountTrialPK, "PK", "Assy");
            if (f.ShowDialog() == DialogResult.OK)
            {
                FRM_DETAIL_TRY_Load(sender, e);
            }
        }
    }
}