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
    public partial class FRM_CONFIRM_TRIAL : DevExpress.XtraEditors.XtraForm
    {
        public FRM_CONFIRM_TRIAL(string ControlNo, int CountTrial, string Stage, string ProductType)
        {
            this.Stage = Stage;
            this.CountTrial = CountTrial;
            this.ControlNo = ControlNo;
            this.ProductType = ProductType;
            InitializeComponent();
        }
        int CountTrial;
        string Stage;
        string ControlNo;
        string ProductType;
        private void FRM_COMFIRM_TRIAL_Load(object sender, EventArgs e)
        {
            LoadData();
            gvData.Columns[3].Visible = false;
            gvData.Columns[4].Visible = false;
            gvData.Columns[5].Visible = false;
            gvData.Columns[6].Visible = false;
            gvData.Columns[7].Visible = false;
            gvData.Columns[8].Visible = false;
            gvData.Columns[9].Visible = false;
            gvData.Columns[10].Visible = false;
            gvData.Columns[11].Visible = false;
            gvData.Columns[12].Visible = false;
            LoadTry();
        }
        int StatusTrial;
        int CountTrialIM;
        int CountTrialASSY;
        int CountTrialPK;
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "' ORDER BY SORT_NUMBER ASC";
                DataTable Data = DBUtils._getData(queryData);
                gcData.DataSource = Data;
                string queryStatus = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable DataStatus = DBUtils._getData(queryStatus);
                StatusTrial = Convert.ToInt32(DataStatus.Rows[0]["STATUS_TRIAL"]);
                CountTrialIM = Convert.ToInt32(DataStatus.Rows[0]["COUNT_TRIAL_IM"]);
                CountTrialASSY = Convert.ToInt32(DataStatus.Rows[0]["COUNT_TRIAL_ASSY"]);
                CountTrialPK = Convert.ToInt32(DataStatus.Rows[0]["COUNT_TRIAL_PK"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadTry()
        {
            if (CountTrial == 1)
            {
                gvData.Columns[3].Visible = true;
            }
            if (CountTrial == 2)
            {
                gvData.Columns[4].Visible = true;
            }
            if (CountTrial == 3)
            {
                gvData.Columns[5].Visible = true;
            }
            if (CountTrial == 4)
            {
                gvData.Columns[6].Visible = true;
            }
            if (CountTrial == 5)
            {
                gvData.Columns[7].Visible = true;
            }
            if (CountTrial == 6)
            {
                gvData.Columns[8].Visible = true;
            }
            if (CountTrial == 7)
            {
                gvData.Columns[9].Visible = true;
            }
            if (CountTrial == 8)
            {
                gvData.Columns[10].Visible = true;
            }
            if (CountTrial == 9)
            {
                gvData.Columns[11].Visible = true;
            }
            if (CountTrial == 10)
            {
                gvData.Columns[12].Visible = true;
            }
        }



        private void btnConfirmTrial_Click(object sender, EventArgs e)
        {
            try
            {
                
                //if (Stage == "IM" && StatusTrial != "01")
                //{
                //    MessageBox.Show("Không thể xác nhận \nĐã xác nhận kết quả chạy thử công đoạn đúc trước đó!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (Stage == "ASSY" && StatusTrial == "03")
                //{
                //    MessageBox.Show("Không thể xác nhận \nĐã xác nhận kết quả chạy thử công đoạn Assy trước đó!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (Stage == "MP" && StatusTrial == "04")
                //{
                //    MessageBox.Show("Không thể xác nhận \nĐã xác nhận kết quả chạy thử trước đó!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (Stage == "IM" && StatusTrial == "04")
                //{
                //    MessageBox.Show("Không thể xác nhận \nĐã xác nhận kết quả chạy thử trước đó!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (Stage == "PK" && StatusTrial == "04")
                //{
                //    MessageBox.Show("Không thể xác nhận \nĐã xác nhận kết quả chạy thử trước đó!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (string.IsNullOrEmpty(txtJudgement.Text.Trim()))
                {
                    MessageBox.Show("Nhập kết quả xác nhận!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin!", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (txtJudgement.Text == "OK")
                    {
                        if (CountTrial == 1)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["1ST_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 2)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["2ND_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 3)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["3RD_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 4)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["4TH_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 5)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["5TH_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 6)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["6TH_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 7)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["7TH_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 8)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["8TH_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 9)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["9TH_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (CountTrial == 10)
                        {
                            for (int i = 0; i < gvData.RowCount; i++)
                            {
                                DataRow row = gvData.GetDataRow(i);
                                if (string.IsNullOrEmpty(Convert.ToString(row["10TH_TRY"])))
                                {
                                    MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(txtJudgement.Text.Trim()))
                        {
                            MessageBox.Show("Nhập kết quả xác nhận!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        for (int i = 0; i < gvData.RowCount; i++)
                        {
                            DataRow row = gvData.GetDataRow(i);
                            string queryConfirm = "UPDATE TBL_TRIAL_PRODUCTION SET TRY = @TRY, STATUS_TRIAL = @STATUS_TRIAL WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryConfirm, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    if (CountTrial == 1)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["1ST_TRY"]));
                                    }
                                    else if (CountTrial == 2)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["2ND_TRY"]));
                                    }
                                    else if (CountTrial == 3)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["3RD_TRY"]));
                                    }
                                    else if (CountTrial == 4)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["4TH_TRY"]));
                                    }
                                    else if (CountTrial == 5)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["5TH_TRY"]));
                                    }
                                    else if (CountTrial == 6)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["6TH_TRY"]));
                                    }
                                    else if (CountTrial == 7)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["7TH_TRY"]));
                                    }
                                    else if (CountTrial == 8)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["8TH_TRY"]));
                                    }
                                    else if (CountTrial == 9)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["9TH_TRY"]));
                                    }
                                    else if (CountTrial == 10)
                                    {
                                        cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["10TH_TRY"]));
                                    }
                                    cmd.Parameters.AddWithValue("@STATUS_TRIAL", "02");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        //string queryStatusTrial = "UPDATE TBL_NEW_MOLD_MST SET STATUS_TRIAL = @STATUS_TRIAL WHERE CONTROL_NO = '" + ControlNo + "'";
                        //using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        //{
                        //    _conn.Open();
                        //    using (SqlCommand cmd = new SqlCommand(queryStatusTrial, _conn))
                        //    {
                        //        //if (Stage == "IM" && ProductType == "Assy")
                        //        //{
                        //        //    cmd.Parameters.AddWithValue("@STATUS_TRIAL", "02");
                        //        //}
                        //        //if (Stage == "ASSY" || Stage == "MP" || ProductType == "Unit")
                        //        //{
                        //        //    cmd.Parameters.AddWithValue("@STATUS_TRIAL", "03");
                        //        //}
                        //        //if (Stage == "PK")
                        //        //{
                        //        //    cmd.Parameters.AddWithValue("@STATUS_TRIAL", "04");
                        //        //}
                        //        cmd.Parameters.AddWithValue("@STATUS_TRIAL", StatusTrial + 1);
                        //        cmd.ExecuteNonQuery();
                        //    }
                        //}
                    }
                    else
                    {
                        if (Stage == "ASSY")
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
                            string queryUpdateTryTemporary = "UPDATE TBL_TRIAL_PRODUCTION SET TEMPORARY_TRY = @TEMPORARY_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateTryTemporary, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@TEMPORARY_TRY", "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        if (Stage == "IM" && ProductType == "Assy")
                        {
                            string queryUpdateCountTrial = "UPDATE TBL_NEW_MOLD_MST SET COUNT_TRIAL_IM = @COUNT_TRIAL_IM WHERE CONTROL_NO = '" + ControlNo + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateCountTrial, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@COUNT_TRIAL_IM", CountTrialIM + 1);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            string queryUpdateTryTemporary = "UPDATE TBL_TRIAL_PRODUCTION SET TEMPORARY_TRY = @TEMPORARY_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateTryTemporary, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@TEMPORARY_TRY", "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        if (Stage == "PK")
                        {
                            string queryUpdateCountTrial = "UPDATE TBL_NEW_MOLD_MST SET COUNT_TRIAL_PK = @COUNT_TRIAL_PK WHERE CONTROL_NO = '" + ControlNo + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateCountTrial, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@COUNT_TRIAL_PK", CountTrialPK + 1);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            string queryUpdateTryTemporary = "UPDATE TBL_TRIAL_PRODUCTION SET TEMPORARY_TRY = @TEMPORARY_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateTryTemporary, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@TEMPORARY_TRY", "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        if (Stage == "IM" && (ProductType == "Unit" || ProductType == "Child part" || Stage == "MP"))
                        {
                            string queryUpdateCountTrial = "UPDATE TBL_NEW_MOLD_MST SET COUNT_TRIAL = @COUNT_TRIAL WHERE CONTROL_NO = '" + ControlNo + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateCountTrial, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@COUNT_TRIAL", CountTrial + 1);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            string queryUpdateTryTemporary = "UPDATE TBL_TRIAL_PRODUCTION SET TEMPORARY_TRY = @TEMPORARY_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateTryTemporary, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@TEMPORARY_TRY", "");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Xác nhận thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
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

        private void gcData_Click(object sender, EventArgs e)
        {

        }
    }
}