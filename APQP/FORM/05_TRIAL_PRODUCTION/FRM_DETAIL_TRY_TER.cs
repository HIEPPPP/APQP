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
using System.Data.SqlClient;

namespace APQP.FORM._05_TRIAL_PRODUCTION
{
    public partial class FRM_DETAIL_TRY_TER : DevExpress.XtraEditors.XtraForm
    {
        public FRM_DETAIL_TRY_TER(string ControlNo)
        {
            this.ControlNo = ControlNo;
            InitializeComponent();
        }
        string ControlNo;
        int CountTrial;
        int CountTrialPK;
        string ProductType;
        string StatusTrial;
        private void FRM_DETAIL_TRY_TER_Load(object sender, EventArgs e)
        {
            try
            {
                gvData.Columns["1ST_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["2ND_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["3RD_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["4TH_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["5TH_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["6TH_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["7TH_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["8TH_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["9TH_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["10TH_TRY"].OptionsColumn.AllowEdit = false;
                gvData.Columns["MAIN_CONTENTS"].VisibleIndex = 0;
                gvData.Columns["DETAILED_CONTENTS"].VisibleIndex = 1;
                gvData.Columns["PIC_SECTION"].VisibleIndex = 2;
                gvData.Columns["1ST_TRY"].VisibleIndex = 3;
                gvData.Columns["2ND_TRY"].VisibleIndex = 4;
                gvData.Columns["3RD_TRY"].VisibleIndex = 5;
                gvData.Columns["4TH_TRY"].VisibleIndex = 6;
                gvData.Columns["5TH_TRY"].VisibleIndex = 7;
                gvData.Columns["6TH_TRY"].VisibleIndex = 8;
                gvData.Columns["7TH_TRY"].VisibleIndex = 9;
                gvData.Columns["8TH_TRY"].VisibleIndex = 10;
                gvData.Columns["9TH_TRY"].VisibleIndex = 11;
                gvData.Columns["10TH_TRY"].VisibleIndex = 12;

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
                CountTrial = Convert.ToInt32(Data.Rows[0]["COUNT_TRIAL"]);
                CountTrialPK = Convert.ToInt32(Data.Rows[0]["COUNT_TRIAL_PK"]);
                ProductType = Convert.ToString(Data.Rows[0]["PRODUCT_TYPE"]);
                StatusTrial = Convert.ToString(Data.Rows[0]["STATUS_TRIAL"]);
                LoadData();
                LoadTry();
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    btnConfirmTrial1.Enabled = true;
                    btnConfirmTrial2.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadData()
        {
            try
            {
                string queryDataUnit = "";
                if (Constaint.MoldType == "Connector")
                {
                    queryDataUnit = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM'";
                }
                else
                {
                    queryDataUnit = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP'";
                }
                DataTable DataUnit = DBUtils._getData(queryDataUnit);
                gcData.DataSource = DataUnit;
                string queryDataPK = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK'";
                DataTable DataPK = DBUtils._getData(queryDataPK);
                gcDataPK.DataSource = DataPK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadTry()
        {
            //MP
            if (CountTrial == 1)
            {
                gvData.Columns["1ST_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[4].Visible = false;
                gvData.Columns[5].Visible = false;
                gvData.Columns[6].Visible = false;
                gvData.Columns[7].Visible = false;
                gvData.Columns[8].Visible = false;
                gvData.Columns[9].Visible = false;
                gvData.Columns[10].Visible = false;
                gvData.Columns[11].Visible = false;
                gvData.Columns[12].Visible = false;
            }
            if (CountTrial == 2)
            {
                gvData.Columns["2ND_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[5].Visible = false;
                gvData.Columns[6].Visible = false;
                gvData.Columns[7].Visible = false;
                gvData.Columns[8].Visible = false;
                gvData.Columns[9].Visible = false;
                gvData.Columns[10].Visible = false;
                gvData.Columns[11].Visible = false;
                gvData.Columns[12].Visible = false;
            }
            if (CountTrial == 3)
            {
                gvData.Columns["3RD_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[6].Visible = false;
                gvData.Columns[7].Visible = false;
                gvData.Columns[8].Visible = false;
                gvData.Columns[9].Visible = false;
                gvData.Columns[10].Visible = false;
                gvData.Columns[11].Visible = false;
                gvData.Columns[12].Visible = false;
            }
            if (CountTrial == 4)
            {
                gvData.Columns["4TH_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[7].Visible = false;
                gvData.Columns[8].Visible = false;
                gvData.Columns[9].Visible = false;
                gvData.Columns[10].Visible = false;
                gvData.Columns[11].Visible = false;
                gvData.Columns[12].Visible = false;
            }
            if (CountTrial == 5)
            {
                gvData.Columns["5TH_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[8].Visible = false;
                gvData.Columns[9].Visible = false;
                gvData.Columns[10].Visible = false;
                gvData.Columns[11].Visible = false;
                gvData.Columns[12].Visible = false;
            }
            if (CountTrial == 6)
            {
                gvData.Columns["6TH_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[9].Visible = false;
                gvData.Columns[10].Visible = false;
                gvData.Columns[11].Visible = false;
                gvData.Columns[12].Visible = false;
            }
            if (CountTrial == 7)
            {
                gvData.Columns["7TH_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[10].Visible = false;
                gvData.Columns[11].Visible = false;
                gvData.Columns[12].Visible = false;
            }
            if (CountTrial == 8)
            {
                gvData.Columns["8TH_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[11].Visible = false;
                gvData.Columns[12].Visible = false;
            }
            if (CountTrial == 9)
            {
                gvData.Columns["9TH_TRY"].OptionsColumn.AllowEdit = true;
                gvData.Columns[12].Visible = false;
                if (CountTrial == 10)
                {
                    gvData.Columns["10TH_TRY"].OptionsColumn.AllowEdit = true;
                }
            }
            // PK 
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

        private void btnAddTry1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận thêm lần chạy thử", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string queryUpdateCountTrial = "UPDATE TBL_NEW_MOLD_MST SET COUNT_TRIAL  = @COUNT_TRIAL WHERE CONTROL_NO = '" + ControlNo + "'";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryUpdateCountTrial, _conn))
                        {
                            cmd.Parameters.AddWithValue("@COUNT_TRIAL", CountTrial + 1);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Thêm Thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FRM_DETAIL_TRY_TER_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnConfirmTrial1_Click(object sender, EventArgs e)
        {
            if (Constaint.MoldType == "Terminal")
            {
                FRM_CONFIRM_TRIAL f = new FRM_CONFIRM_TRIAL(ControlNo, CountTrial, "MP", "Unit");
                if (f.ShowDialog() == DialogResult.OK)
                {
                    FRM_DETAIL_TRY_TER_Load(sender, e);
                }
            }
            else
            {
                if (ProductType == "Unit")
                {
                    FRM_CONFIRM_TRIAL f = new FRM_CONFIRM_TRIAL(ControlNo, CountTrial, "IM", "Unit");
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        FRM_DETAIL_TRY_TER_Load(sender, e);
                    }
                }
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {

                if (StatusTrial == "03" || StatusTrial == "04")
                {
                    MessageBox.Show("Thông tin đã được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (Constaint._access != "01")
                    {
                        for (int i = 0; i < gvData.RowCount; i++)
                        {
                            DataRow row = gvData.GetDataRow(i);
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
                                        if (CountTrial == 1)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["1ST_TRY"]));
                                        }
                                        if (CountTrial == 2)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["2ND_TRY"]));
                                        }
                                        if (CountTrial == 3)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["3RD_TRY"]));
                                        }
                                        if (CountTrial == 4)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["4TH_TRY"]));
                                        }
                                        if (CountTrial == 5)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["5TH_TRY"]));
                                        }
                                        if (CountTrial == 6)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["6TH_TRY"]));
                                        }
                                        if (CountTrial == 7)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["7TH_TRY"]));
                                        }
                                        if (CountTrial == 8)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["8TH_TRY"]));
                                        }
                                        if (CountTrial == 9)
                                        {
                                            cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["9TH_TRY"]));
                                        }
                                        if (CountTrial == 10)
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
                        for (int i = 0; i < gvData.RowCount; i++)
                        {
                            DataRow row = gvData.GetDataRow(i);
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
                                    if (CountTrial == 1)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["1ST_TRY"]));
                                    }
                                    if (CountTrial == 2)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["2ND_TRY"]));
                                    }
                                    if (CountTrial == 3)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["3RD_TRY"]));
                                    }
                                    if (CountTrial == 4)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["4TH_TRY"]));
                                    }
                                    if (CountTrial == 5)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["5TH_TRY"]));
                                    }
                                    if (CountTrial == 6)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["6TH_TRY"]));
                                    }
                                    if (CountTrial == 7)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["7TH_TRY"]));
                                    }
                                    if (CountTrial == 8)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["8TH_TRY"]));
                                    }
                                    if (CountTrial == 9)
                                    {
                                        cmd.Parameters.AddWithValue("@TEMPORARY_TRY", Convert.ToString(row["9TH_TRY"]));
                                    }
                                    if (CountTrial == 10)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmTrial2_Click(object sender, EventArgs e)
        {
            if (StatusTrial != "03")
            {
                MessageBox.Show("Thông tin công đoạn trước chưa được xác nhận, Không thể xác nhận!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_CONFIRM_TRIAL f = new FRM_CONFIRM_TRIAL(ControlNo, CountTrialPK, "PK", "Assy");
            if (f.ShowDialog() == DialogResult.OK)
            {
                FRM_DETAIL_TRY_TER_Load(sender, e);
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
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
    }
}