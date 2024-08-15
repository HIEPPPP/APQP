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
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace APQP.FORM._05_TRIAL_PRODUCTION
{
    public partial class FRM_TRIAL_PRODUCTION : DevExpress.XtraEditors.XtraForm
    {
        public FRM_TRIAL_PRODUCTION(string ControlNo, int CountTrial, string StatusTrial, int CountTrialIM, int CountTrialASSY, string ProductType)
        {
            this.ControlNo = ControlNo;
            this.CountTrial = CountTrial;
            this.CountTrialIM = CountTrialIM;
            this.CountTrialASSY = CountTrialASSY;
            this.StatusTrial = StatusTrial;
            this.ProductType = ProductType;
            InitializeComponent();
        }
        int CountTrialIM;
        int CountTrialASSY;
        string ControlNo;
        int CountTrial;
        string StatusTrial;
        string ProductType;

        private void FRM_TRIAL_PRODUCTION_Load(object sender, EventArgs e)
        {
            try
            {
                if (Constaint._access == "01" || Constaint._sectionShort == "QA" || Constaint._sectionShort == "PC")
                {
                    btnEdit.Visible = true;
                }
                LoadData();
                string QueryDataJudgement = "SELECT JUDGEMENT FROM TBL_JUDGEMENT";
                DataTable DataJudgement = DBUtils._getData(QueryDataJudgement);
                rpDataJudgement.DataSource = DataJudgement;
                rpDataJudgement.ValueMember = "JUDGEMENT";
                rpDataJudgement.DisplayMember = "JUDGEMENT";
                rpJudgement2.DataSource = DataJudgement;
                rpJudgement2.ValueMember = "JUDGEMENT";
                rpJudgement2.DisplayMember = "JUDGEMENT";
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
                string queryData = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' ORDER BY SORT_NUMBER ASC";
                DataTable Data = DBUtils._getData(queryData);
                gcData.DataSource = Data;
                string queryDataOther = "SELECT * FROM TBL_OTHER_EVALUATION WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable DataOther = DBUtils._getData(queryDataOther);
                gcDataOther.DataSource = DataOther;
                string queryDataOtherValuable = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable DataOtherValuable = DBUtils._getData(queryDataOtherValuable);
                gcDataOtherCycaltime.DataSource = DataOtherValuable;
                //Load Data Approved
                string queryDataApproved = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                DataTable DataApproved = DBUtils._getData(queryDataApproved);
                DateTime DateChecked;
                DateTime DateApproved;
                DateTime DueDate;
                if (DataApproved.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECKED_TRIAL_PRODUCTION"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECKED_TRIAL_PRODUCTION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECK_TRIAL_PRODUCTION"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECK_TRIAL_PRODUCTION"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_TRIAL_PRODUCTION"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_TRIAL_PRODUCTION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_PRODUCTION"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_PRODUCTION"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_TRIAL_PRODUCTION"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_TRIAL_PRODUCTION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"])))
                    {
                        DueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"].ToString());
                        txtDueDate.Text = DueDate.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtChecked.Text))
                {
                    MessageBox.Show("Thông tin đã được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin!", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (Constaint._access != "01")
                    {
                        //for (int i = 0; i < gvData.RowCount; i++)
                        //{
                        //    DataRow row = gvData.GetDataRow(i);
                        //    string Section = Convert.ToString(row["PIC_SECTION"]);
                        //    if (Section == Constaint._sectionShort)
                        //    {
                        //        string querySave = "UPDATE TBL_TRIAL_PRODUCTION SET TRY = @TRY, JUDGEMENT = @JUDGEMENT, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                        //        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        //        {
                        //            _conn.Open();
                        //            using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        //            {
                        //                cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                        //                if (string.IsNullOrEmpty(Convert.ToString(row["TRY"])))
                        //                {
                        //                    cmd.Parameters.AddWithValue("@TRY", DBNull.Value);
                        //                }
                        //                else
                        //                {
                        //                    cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["TRY"]));
                        //                }
                        //                if (string.IsNullOrEmpty(Convert.ToString(row["JUDGEMENT"])))
                        //                {
                        //                    cmd.Parameters.AddWithValue("@JUDGEMENT", DBNull.Value);
                        //                }
                        //                else
                        //                {
                        //                    cmd.Parameters.AddWithValue("@JUDGEMENT", Convert.ToString(row["JUDGEMENT"]));
                        //                }
                        //                if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])))
                        //                {
                        //                    cmd.Parameters.AddWithValue("@PLAN_COMPLETE", DBNull.Value);
                        //                }
                        //                else
                        //                {
                        //                    cmd.Parameters.AddWithValue("@PLAN_COMPLETE", Convert.ToDateTime(row["PLAN_COMPLETE"]));
                        //                }
                        //                if (string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])))
                        //                {
                        //                    cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", DBNull.Value);
                        //                }
                        //                else
                        //                {
                        //                    cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", Convert.ToDateTime(row["ACTUAL_COMPLETE"]));
                        //                }
                        //                if (string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                        //                {
                        //                    cmd.Parameters.AddWithValue("@ATTACHED_FILE", DBNull.Value);
                        //                }
                        //                else
                        //                {
                        //                    cmd.Parameters.AddWithValue("@ATTACHED_FILE", Convert.ToString(row["ATTACHED_FILE"]));
                        //                }
                        //                cmd.Parameters.AddWithValue("@DOCUMENTS", Convert.ToString(row["DOCUMENTS"]));
                        //                cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                        //                cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                        //                cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                        //                cmd.ExecuteNonQuery();
                        //            }
                        //        }
                        //    }
                        //}
                        //Update TBL_OTHER_EVALUATION
                        for (int i = 0; i < gvDataOther.RowCount; i++)
                        {
                            DataRow row = gvDataOther.GetDataRow(i);
                            string Section = Convert.ToString(row["PIC_SECTION"]);
                            if (Section == Constaint._sectionShort)
                            {
                                string querySave = "UPDATE TBL_OTHER_EVALUATION SET JUDGEMENT = @JUDGEMENT, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                        if (string.IsNullOrEmpty(Convert.ToString(row["JUDGEMENT"])))
                                        {
                                            cmd.Parameters.AddWithValue("@JUDGEMENT", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@JUDGEMENT", Convert.ToString(row["JUDGEMENT"]));
                                        }
                                        if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])))
                                        {
                                            cmd.Parameters.AddWithValue("@PLAN_COMPLETE", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@PLAN_COMPLETE", Convert.ToDateTime(row["PLAN_COMPLETE"]));
                                        }
                                        if (string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])))
                                        {
                                            cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", Convert.ToDateTime(row["ACTUAL_COMPLETE"]));
                                        }
                                        if (string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                                        {
                                            cmd.Parameters.AddWithValue("@ATTACHED_FILE", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"]) + "-" + "T");
                                        }
                                        if (string.IsNullOrEmpty(Convert.ToString(row["FILE_EXTENSION"])))
                                        {
                                            cmd.Parameters.AddWithValue("@FILE_EXTENSION", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@FILE_EXTENSION", Convert.ToString(row["FILE_EXTENSION"]));
                                        }
                                        cmd.Parameters.AddWithValue("@DOCUMENTS", Convert.ToString(row["DOCUMENTS"]));
                                        cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                                        cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < gvDataOtherCycaltime.RowCount; i++)
                        {
                            DataRow row = gvDataOtherCycaltime.GetDataRow(i);
                            string Section = Convert.ToString(row["PIC_SECTION"]);
                            if (Section == Constaint._sectionShort)
                            {
                                string querySave = "UPDATE TBL_OTHER_VALUABLE_EVALUATION SET JUDGEMENT = @JUDGEMENT, [PLAN] = @PLAN, ACTUAL = @ACTUAL, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                        cmd.Parameters.AddWithValue("@JUDGEMENT", Convert.ToString(row["JUDGEMENT"]));
                                        cmd.Parameters.AddWithValue("@PLAN", Convert.ToString(row["PLAN"]));
                                        cmd.Parameters.AddWithValue("@ACTUAL", Convert.ToString(row["ACTUAL"]));
                                        cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
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
                        //for (int i = 0; i < gvData.RowCount; i++)
                        //{
                        //    DataRow row = gvData.GetDataRow(i);
                        //    string querySave = "UPDATE TBL_TRIAL_PRODUCTION SET TRY = @TRY, JUDGEMENT = @JUDGEMENT, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                        //    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        //    {
                        //        _conn.Open();
                        //        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        //        {
                        //            cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                        //            if (string.IsNullOrEmpty(Convert.ToString(row["TRY"])))
                        //            {
                        //                cmd.Parameters.AddWithValue("@TRY", DBNull.Value);
                        //            }
                        //            else
                        //            {
                        //                cmd.Parameters.AddWithValue("@TRY", Convert.ToString(row["TRY"]));
                        //            }
                        //            if (string.IsNullOrEmpty(Convert.ToString(row["JUDGEMENT"])))
                        //            {
                        //                cmd.Parameters.AddWithValue("@JUDGEMENT", DBNull.Value);
                        //            }
                        //            else
                        //            {
                        //                cmd.Parameters.AddWithValue("@JUDGEMENT", Convert.ToString(row["JUDGEMENT"]));
                        //            }
                        //            if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])))
                        //            {
                        //                cmd.Parameters.AddWithValue("@PLAN_COMPLETE", DBNull.Value);
                        //            }
                        //            else
                        //            {
                        //                cmd.Parameters.AddWithValue("@PLAN_COMPLETE", Convert.ToDateTime(row["PLAN_COMPLETE"]));
                        //            }
                        //            if (string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])))
                        //            {
                        //                cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", DBNull.Value);
                        //            }
                        //            else
                        //            {
                        //                cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", Convert.ToDateTime(row["ACTUAL_COMPLETE"]));
                        //            }
                        //            if (string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                        //            {
                        //                cmd.Parameters.AddWithValue("@ATTACHED_FILE", DBNull.Value);
                        //            }
                        //            else
                        //            {
                        //                cmd.Parameters.AddWithValue("@ATTACHED_FILE", Convert.ToString(row["ATTACHED_FILE"]));
                        //            }
                        //            cmd.Parameters.AddWithValue("@DOCUMENTS", Convert.ToString(row["DOCUMENTS"]));
                        //            cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                        //            cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                        //            cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                        //            cmd.ExecuteNonQuery();
                        //        }
                        //    }
                        //}
                        //Update TBL_OTHER_EVALUATION
                        for (int i = 0; i < gvDataOther.RowCount; i++)
                        {
                            DataRow row = gvDataOther.GetDataRow(i);
                            string querySave = "UPDATE TBL_OTHER_EVALUATION SET JUDGEMENT = @JUDGEMENT, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    if (string.IsNullOrEmpty(Convert.ToString(row["JUDGEMENT"])))
                                    {
                                        cmd.Parameters.AddWithValue("@JUDGEMENT", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@JUDGEMENT", Convert.ToString(row["JUDGEMENT"]));
                                    }
                                    if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])))
                                    {
                                        cmd.Parameters.AddWithValue("@PLAN_COMPLETE", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PLAN_COMPLETE", Convert.ToDateTime(row["PLAN_COMPLETE"]));
                                    }
                                    if (string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])))
                                    {
                                        cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", Convert.ToDateTime(row["ACTUAL_COMPLETE"]));
                                    }
                                    if (string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                                    {
                                        cmd.Parameters.AddWithValue("@ATTACHED_FILE", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"]) + "-" + "T");
                                    }
                                    if (string.IsNullOrEmpty(Convert.ToString(row["FILE_EXTENSION"])))
                                    {
                                        cmd.Parameters.AddWithValue("@FILE_EXTENSION", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@FILE_EXTENSION", Convert.ToString(row["FILE_EXTENSION"]));
                                    }
                                    cmd.Parameters.AddWithValue("@DOCUMENTS", Convert.ToString(row["DOCUMENTS"]));
                                    cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                                    cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        //Update TBL_OTHER_VALUABLE_EVALUATION
                        for (int i = 0; i < gvDataOtherCycaltime.RowCount; i++)
                        {
                            DataRow row = gvDataOtherCycaltime.GetDataRow(i);
                            string Section = Convert.ToString(row["PIC_SECTION"]);
                            string querySave = "UPDATE TBL_OTHER_VALUABLE_EVALUATION SET JUDGEMENT = @JUDGEMENT, [PLAN] = @PLAN, ACTUAL = @ACTUAL, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    cmd.Parameters.AddWithValue("@JUDGEMENT", Convert.ToString(row["JUDGEMENT"]));
                                    cmd.Parameters.AddWithValue("@PLAN", Convert.ToString(row["PLAN"]));
                                    cmd.Parameters.AddWithValue("@ACTUAL", Convert.ToString(row["ACTUAL"]));
                                    cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                                    cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnChecked_Click(object sender, EventArgs e)
        {
            try
            {

                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    for (int i = 0; i < gvData.RowCount; i++)
                    {
                        DataRow row = gvData.GetDataRow(i);
                        if (string.IsNullOrEmpty(Convert.ToString(row["TRY"])))
                        {
                            MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    for (int i = 0; i < gvDataOther.RowCount; i++)
                    {
                        DataRow row = gvDataOther.GetDataRow(i);
                        if (string.IsNullOrEmpty(Convert.ToString(row["JUDGEMENT"])) || string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                        {
                            MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    for (int i = 0; i < gvDataOtherCycaltime.RowCount; i++)
                    {
                        DataRow row = gvDataOtherCycaltime.GetDataRow(i);
                        if (string.IsNullOrEmpty(Convert.ToString(row["JUDGEMENT"])) || string.IsNullOrEmpty(Convert.ToString(row["PLAN"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL"])))
                        {
                            MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    DialogResult result = MessageBox.Show("Xác nhận đã kiểm tra thông tin?", "Checked", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        if (StatusTrial != "04")
                        {
                            MessageBox.Show("Chạy thử chưa hoàn thành! \nKhông thể xác nhận", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!string.IsNullOrEmpty(txtApproved.Text.Trim()))
                        {
                            MessageBox.Show("Thông tin đã được phê duyệt! \nKhông thể xác nhận", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!string.IsNullOrEmpty(txtChecked.Text.Trim()))
                        {
                            MessageBox.Show("Thông tin đã được xác nhận kiểm tra trước đó! \nKhông thể xác nhận", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_TRIAL_PRODUCTION = @CHECKED_TRIAL_PRODUCTION, DATE_CHECK_TRIAL_PRODUCTION = @DATE_CHECK_TRIAL_PRODUCTION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@CHECKED_TRIAL_PRODUCTION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_CHECK_TRIAL_PRODUCTION", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Xác nhận đã kiểm tra thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_TRIAL_PRODUCTION_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Không có quyền xác nhận.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            try
            {
                if (Constaint._access == "01" || Constaint._access == "05")
                {
                    DialogResult result = MessageBox.Show("Xác nhận phê duyệt thông tin?", "Approved", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        if (string.IsNullOrEmpty(txtChecked.Text.Trim()))
                        {
                            MessageBox.Show("Thông tin chưa được xác nhận kiểm tra! \nKhông thể phê duyệt", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!string.IsNullOrEmpty(txtApproved.Text.Trim()))
                        {
                            MessageBox.Show("Thông tin đã được phê duyệt trước đó! \nKhông thể phê duyệt", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, TRIAL_PRODUCTION = @TRIAL_PRODUCTION, MASS_PRODUCTION = @MASS_PRODUCTION, " +
                            "APPROVED_TRIAL_PRODUCTION = @APPROVED_TRIAL_PRODUCTION, DATE_APPROVED_TRIAL_PRODUCTION = @DATE_APPROVED_TRIAL_PRODUCTION, COMMENTS_TRIAL_PRODUCTION = @COMMENTS_TRIAL_PRODUCTION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@STEP_CODE", "05");
                                cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION", "Finish");
                                cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing");
                                cmd.Parameters.AddWithValue("@APPROVED_TRIAL_PRODUCTION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_APPROVED_TRIAL_PRODUCTION", DateTime.Now);
                                cmd.Parameters.AddWithValue("@COMMENTS_TRIAL_PRODUCTION", txtComments.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Phê duyệt thành công.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_TRIAL_PRODUCTION_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Không có quyền phê duyệt.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDueDate.Text.Trim()))
                {
                    MessageBox.Show("Chọn thời hạn hoàn thành!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    DialogResult result = MessageBox.Show("Xác nhận thay đổi thời hạn hoàn thành?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        string queryUpdateDueDate = "UPDATE TBL_NEW_MOLD_MST SET DUE_DATE_TRIAL_PRODUCTION = @DUE_DATE_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateDueDate, conn))
                            {
                                cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", Convert.ToDateTime(txtDueDate.Text));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Thay đổi thời hạn hoàn thành thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnApprovedTrial_Click(object sender, EventArgs e)
        {
            //FRM_COMFIRM_TRIAL f = new FRM_COMFIRM_TRIAL(ControlNo, CountTrial);
            //f.ShowDialog();
        }

        string _fileCopy = string.Empty;
        string pathPdfFile = string.Empty;
        string fileExtension;
        string fileUpLoad;
        private void gvData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DXMouseEventArgs ea = e as DXMouseEventArgs;
                GridView view = sender as GridView;
                GridHitInfo info = view.CalcHitInfo(ea.Location);
                if (info.InRow || info.InRowCell)
                {
                    if (ProductType == "Unit" || Constaint.MoldType == "Terminal")
                    {
                        FRM_DETAIL_TRY_TER f = new FRM_DETAIL_TRY_TER(ControlNo);
                        f.ShowDialog();
                    }
                    if (ProductType == "Assy")
                    {
                        FRM_DETAIL_TRY f = new FRM_DETAIL_TRY(ControlNo);
                        f.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            try
            {
                int y = gvDataOther.FocusedRowHandle;
                if (Constaint._access != "01")
                {
                    if (Constaint._sectionShort == Convert.ToString(gvDataOther.GetRowCellValue(y, "PIC_SECTION")))
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        DialogResult result = openFileDialog.ShowDialog();
                        openFileDialog.CheckFileExists = true;
                        openFileDialog.AddExtension = true;
                        openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                        if (result == DialogResult.OK)
                        {
                            pathPdfFile = openFileDialog.FileName;
                            _fileCopy = pathPdfFile.Substring(pathPdfFile.LastIndexOf("\\"));
                            fileExtension = Path.GetExtension(pathPdfFile);
                            gvDataOther.SetRowCellValue(y, gvDataOther.Columns["ATTACHED_FILE"], _fileCopy.Substring(1));
                            gvDataOther.SetRowCellValue(y, gvDataOther.Columns["FILE_EXTENSION"], fileExtension);
                            gvDataOther.SetRowCellValue(y, gvDataOther.Columns["ACTUAL_COMPLETE"], DateTime.Now);
                            fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + Convert.ToString(gvDataOther.GetRowCellValue(y, "ID_IDENTITY") + "-" + "T" + fileExtension));
                            File.Copy(pathPdfFile, fileUpLoad, true);
                        }
                    }
                }
                if (Constaint._access == "01")
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    DialogResult result = openFileDialog.ShowDialog();
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.AddExtension = true;
                    openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    if (result == DialogResult.OK)
                    {
                        pathPdfFile = openFileDialog.FileName;
                        _fileCopy = pathPdfFile.Substring(pathPdfFile.LastIndexOf("\\"));
                        fileExtension = Path.GetExtension(pathPdfFile);
                        gvDataOther.SetRowCellValue(y, gvDataOther.Columns["ATTACHED_FILE"], _fileCopy.Substring(1));
                        gvDataOther.SetRowCellValue(y, gvDataOther.Columns["FILE_EXTENSION"], fileExtension);
                        gvDataOther.SetRowCellValue(y, gvDataOther.Columns["ACTUAL_COMPLETE"], DateTime.Now);
                        fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + Convert.ToString(gvDataOther.GetRowCellValue(y, "ID_IDENTITY") + "-" + "T" + fileExtension));
                        File.Copy(pathPdfFile, fileUpLoad, true);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gvDataOther_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DXMouseEventArgs ea = e as DXMouseEventArgs;
                GridView view = sender as GridView;
                GridHitInfo info = view.CalcHitInfo(ea.Location);
                if (info.InRow || info.InRowCell)
                {
                    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    if (colCaption == "File")
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(gvDataOther.GetFocusedRowCellValue("ATTACHED_FILE"))))
                        {
                            System.Diagnostics.Process.Start(Constaint._folderFileUpload + gvDataOther.GetFocusedRowCellValue("ATTACHED_FILE").ToString() + gvDataOther.GetFocusedRowCellValue("FILE_EXTENSION").ToString());
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("File không tồn tại!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            FRM_TRIAL_PRODUCTION_Load(sender, e);
        }
    }
}