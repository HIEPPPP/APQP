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
using APQP.FORM._05_TRIAL_PRODUCTION;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace APQP.FORM._04_PREPARATION
{
    public partial class FRM_PREPARATION_TRY_STAGE : DevExpress.XtraEditors.XtraForm
    {
        public FRM_PREPARATION_TRY_STAGE(string ControlNo, string Stage, string ProductType)
        {
            this.ProductType = ProductType;
            this.ControlNo = ControlNo;
            this.Stage = Stage;
            InitializeComponent();
        }
        string ProductType;
        string ControlNo;
        string Stage;
        int CountTrial;

        string queryStatusPreparation = string.Empty;
        DataTable dataStatusPreparation = new DataTable();
        string queryStatusTrial = string.Empty;
        DataTable dataStatusTrial = new DataTable();
        private void FRM_PREPARATION_TRY_STAGE_Load(object sender, EventArgs e)
        {
            label1.Text = "TRIAL PRODUCTION (" + ControlNo + ")";
            if (Constaint._access == "01" || Constaint._sectionShort == "QA")
            {
                btnConfirm1.Enabled = true;
                btnConfirm2.Enabled = true;
                btnEdit.Visible = true;
            }
            if (Constaint._access == "01" || Constaint._sectionShort == "QA" || Constaint._sectionShort == "PC")
            {
                btnEdit.Visible = true;
            }
            else
            {
                txtDueDate.ReadOnly = true;
            }
            if (Constaint._access == "01" || Constaint._access == "05")
            {
                btnApproved.Enabled = true;
            }
            if (Constaint._access == "01" || Constaint._sectionShort == "QA")
            {
                btnChecked.Enabled = true;
            }
            queryStatusPreparation = "SELECT * FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "' AND (STATUS_PREPARATION_TRY IS NULL OR LEN(RTRIM(STATUS_PREPARATION_TRY)) = 0 )";
            dataStatusPreparation = DBUtils._getData(queryStatusPreparation);
            if (dataStatusPreparation.Rows.Count <= 0)
            {
                groupBox2.Text = "Preparation - Confirmed";
            }
            queryStatusTrial = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "' AND (STATUS_TRIAL IS NULL OR LEN(RTRIM(STATUS_TRIAL)) = 0 )";
            dataStatusTrial = DBUtils._getData(queryStatusTrial);
            if (dataStatusTrial.Rows.Count <= 0)
            {
                groupBox3.Text = "Trial - Confirmed";
            }
            LoadDataApproved();
            LoadTry();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryDataPreparation = "SELECT * FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "'";
                DataTable dataPreparation = DBUtils._getData(queryDataPreparation);
                gcData.DataSource = dataPreparation;
                string queryDataTrial = "SELECT * FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "'";
                DataTable dataTrial = DBUtils._getData(queryDataTrial);
                gcDataTry.DataSource = dataTrial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        DateTime DueDate;
        private void LoadDataApproved()
        {
            //Load Data Approved
            string queryDataApproved = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
            DataTable DataApproved = DBUtils._getData(queryDataApproved);
            if (DataApproved.Rows.Count > 0)
            {
                if (Stage == "IM")
                {
                    CountTrial = Convert.ToInt32(DataApproved.Rows[0]["COUNT_TRIAL_IM"]);
                }
                if (Stage == "ASSY")
                {
                    CountTrial = Convert.ToInt32(DataApproved.Rows[0]["COUNT_TRIAL_ASSY"]);
                }
                if (Stage == "PK")
                {
                    CountTrial = Convert.ToInt32(DataApproved.Rows[0]["COUNT_TRIAL_PK"]);
                }
                if (Stage == "MP")
                {
                    CountTrial = Convert.ToInt32(DataApproved.Rows[0]["COUNT_TRIAL_MP"]);
                }
            }
            DateTime DateChecked;
            DateTime DateApproved;


            if (DataApproved.Rows.Count > 0)
            {
                if (Stage == "IM")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECKED_TRIAL_IM"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECKED_TRIAL_IM"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_IM"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_IM"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_TRIAL_IM"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_TRIAL_IM"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_IM"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_IM"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_TRIAL_IM"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_TRIAL_IM"].ToString();
                    }
                    //if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_TRIAL_IM"])))
                    //{
                    //    DueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_TRIAL_IM"].ToString());
                    //    txtDueDate.Text = DueDate.ToString("dd/MM/yyyy");
                    //}
                }
                if (Stage == "ASSY")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECKED_TRIAL_ASSY"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECKED_TRIAL_ASSY"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_ASSY"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_ASSY"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_TRIAL_ASSY"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_TRIAL_ASSY"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_ASSY"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_ASSY"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_TRIAL_ASSY"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_TRIAL_ASSY"].ToString();
                    }
                    //if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_TRIAL_ASSY"])))
                    //{
                    //    DueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_TRIAL_ASSY"].ToString());
                    //    txtDueDate.Text = DueDate.ToString("dd/MM/yyyy");
                    //}
                }
                if (Stage == "PK")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECKED_TRIAL_PK"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECKED_TRIAL_PK"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_PK"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_PK"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_TRIAL_PK"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_TRIAL_PK"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_PK"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_PK"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_TRIAL_PK"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_TRIAL_PK"].ToString();
                    }
                    //if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_TRIAL_PK"])))
                    //{
                    //    DueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_TRIAL_PK"].ToString());
                    //    txtDueDate.Text = DueDate.ToString("dd/MM/yyyy");
                    //}
                }
                if (Stage == "MP")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECKED_TRIAL_MP"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECKED_TRIAL_MP"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_MP"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_MP"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_TRIAL_MP"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_TRIAL_PK"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_MP"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_MP"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_TRIAL_MP"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_TRIAL_MP"].ToString();
                    }
                    //if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_TRIAL_MP"])))
                    //{
                    //    DueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_TRIAL_MP"].ToString());
                    //    txtDueDate.Text = DueDate.ToString("dd/MM/yyyy");
                    //}
                }
                if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"])))
                {
                    DueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"].ToString());
                    txtDueDate.Text = DueDate.ToString("dd/MM/yyyy");
                }
            }
        }
        private void LoadTry()
        {
            gvDataTry.Columns[3].Visible = true;
            gvDataTry.Columns[4].Visible = true;
            gvDataTry.Columns[5].Visible = true;
            gvDataTry.Columns[6].Visible = true;
            gvDataTry.Columns[7].Visible = true;
            gvDataTry.Columns[8].Visible = true;
            gvDataTry.Columns[9].Visible = true;
            gvDataTry.Columns[10].Visible = true;
            gvDataTry.Columns[11].Visible = true;
            gvDataTry.Columns[12].Visible = true;
            //IM
            if (CountTrial == 1)
            {
                gvDataTry.Columns["1ST_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[4].Visible = false;
                gvDataTry.Columns[5].Visible = false;
                gvDataTry.Columns[6].Visible = false;
                gvDataTry.Columns[7].Visible = false;
                gvDataTry.Columns[8].Visible = false;
                gvDataTry.Columns[9].Visible = false;
                gvDataTry.Columns[10].Visible = false;
                gvDataTry.Columns[11].Visible = false;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 2)
            {
                gvDataTry.Columns["2ND_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[5].Visible = false;
                gvDataTry.Columns[6].Visible = false;
                gvDataTry.Columns[7].Visible = false;
                gvDataTry.Columns[8].Visible = false;
                gvDataTry.Columns[9].Visible = false;
                gvDataTry.Columns[10].Visible = false;
                gvDataTry.Columns[11].Visible = false;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 3)
            {
                gvDataTry.Columns["3RD_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[6].Visible = false;
                gvDataTry.Columns[7].Visible = false;
                gvDataTry.Columns[8].Visible = false;
                gvDataTry.Columns[9].Visible = false;
                gvDataTry.Columns[10].Visible = false;
                gvDataTry.Columns[11].Visible = false;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 4)
            {
                gvDataTry.Columns["4TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[7].Visible = false;
                gvDataTry.Columns[8].Visible = false;
                gvDataTry.Columns[9].Visible = false;
                gvDataTry.Columns[10].Visible = false;
                gvDataTry.Columns[11].Visible = false;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 5)
            {
                gvDataTry.Columns["5TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[8].Visible = false;
                gvDataTry.Columns[9].Visible = false;
                gvDataTry.Columns[10].Visible = false;
                gvDataTry.Columns[11].Visible = false;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 6)
            {
                gvDataTry.Columns["6TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[9].Visible = false;
                gvDataTry.Columns[10].Visible = false;
                gvDataTry.Columns[11].Visible = false;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 7)
            {
                gvDataTry.Columns["7TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[10].Visible = false;
                gvDataTry.Columns[11].Visible = false;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 8)
            {
                gvDataTry.Columns["8TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[11].Visible = false;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 9)
            {
                gvDataTry.Columns["9TH_TRY"].OptionsColumn.AllowEdit = true;
                gvDataTry.Columns[12].Visible = false;
            }
            if (CountTrial == 10)
            {
                gvDataTry.Columns["10TH_TRY"].OptionsColumn.AllowEdit = true;
            }
        }

        private void btnConfirm1_Click(object sender, EventArgs e)
        {
            if (dataStatusPreparation.Rows.Count <= 0)
            {
                MessageBox.Show("Thông tin đã được xác nhận, không thể xác nhận!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_CONFIRM_PREPARATION f = new FRM_CONFIRM_PREPARATION(ControlNo, Stage, CountTrial, ProductType);
            if (f.ShowDialog() == DialogResult.OK)
            {
                FRM_PREPARATION_TRY_STAGE_Load(sender, e);
            }
        }

        private void btnConfirm2_Click(object sender, EventArgs e)
        {
            if (dataStatusTrial.Rows.Count <= 0)
            {
                MessageBox.Show("Thông tin đã được xác nhận, không thể xác nhận!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_CONFIRM_TRIAL f = new FRM_CONFIRM_TRIAL(ControlNo, CountTrial, Stage, ProductType);
            if (f.ShowDialog() == DialogResult.OK)
            {
                FRM_PREPARATION_TRY_STAGE_Load(sender, e);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataStatusPreparation.Rows.Count <= 0)
                {
                    MessageBox.Show("Thông tin đã được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin!", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                                string queryItems = "UPDATE TBL_PREPARATION_TRY SET STATUS = @STATUS, PLAN_START = @PLAN_START, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_START = @ACTUAL_START, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                        if (string.IsNullOrEmpty(Convert.ToString(row["STATUS"])))
                                        {
                                            cmd.Parameters.AddWithValue("@STATUS", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@STATUS", Convert.ToString(row["STATUS"]));
                                        }
                                        if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_START"])))
                                        {
                                            cmd.Parameters.AddWithValue("@PLAN_START", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@PLAN_START", Convert.ToDateTime(row["PLAN_START"]));
                                        }
                                        if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])))
                                        {
                                            cmd.Parameters.AddWithValue("@PLAN_COMPLETE", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@PLAN_COMPLETE", Convert.ToDateTime(row["PLAN_COMPLETE"]));
                                        }
                                        if (string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_START"])))
                                        {
                                            cmd.Parameters.AddWithValue("@ACTUAL_START", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@ACTUAL_START", Convert.ToDateTime(row["ACTUAL_START"]));
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
                                            cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"]) + "-" + "PT");
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
                    }
                    if (Constaint._access == "01")
                    {
                        for (int i = 0; i < gvData.RowCount; i++)
                        {
                            DataRow row = gvData.GetDataRow(i);
                            string queryItems = "UPDATE TBL_PREPARATION_TRY SET STATUS = @STATUS, PLAN_START = @PLAN_START, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_START = @ACTUAL_START, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    if (string.IsNullOrEmpty(Convert.ToString(row["STATUS"])))
                                    {
                                        cmd.Parameters.AddWithValue("@STATUS", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@STATUS", Convert.ToString(row["STATUS"]));
                                    }
                                    if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_START"])))
                                    {
                                        cmd.Parameters.AddWithValue("@PLAN_START", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PLAN_START", Convert.ToDateTime(row["PLAN_START"]));
                                    }
                                    if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])))
                                    {
                                        cmd.Parameters.AddWithValue("@PLAN_COMPLETE", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PLAN_COMPLETE", Convert.ToDateTime(row["PLAN_COMPLETE"]));
                                    }
                                    if (string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_START"])))
                                    {
                                        cmd.Parameters.AddWithValue("@ACTUAL_START", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@ACTUAL_START", Convert.ToDateTime(row["ACTUAL_START"]));
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
                                        cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"]) + "-" + "PT");
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
                    //lưu tên bộ phận chưa nhập đủ thông tin
                    if (Stage == "IM")
                    {
                        string sectionRemain = string.Empty;
                        string queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                        DataTable dataSection = DBUtils._getData(queryDataSection);

                        string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                        DataTable data2 = DBUtils._getData(queryData2);

                        dataSection.Merge(data2);

                        var sectionRemainList = (from r in dataSection.AsEnumerable()
                                                 select r["PIC_SECTION"]).Distinct().ToList();
                        if (sectionRemainList.Count > 0)
                        {
                            foreach (var section in sectionRemainList)
                            {
                                sectionRemain = sectionRemain + ", " + section;
                            }
                        }
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_IM = @TRIAL_IM WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain.Substring(2));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain.Substring(2) + "-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    if (Stage == "ASSY")
                    {
                        string sectionRemain = string.Empty;
                        string queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                        DataTable dataSection = DBUtils._getData(queryDataSection);

                        string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                        DataTable data2 = DBUtils._getData(queryData2);

                        dataSection.Merge(data2);

                        var sectionRemainList = (from r in dataSection.AsEnumerable()
                                                 select r["PIC_SECTION"]).Distinct().ToList();
                        if (sectionRemainList.Count > 0)
                        {
                            foreach (var section in sectionRemainList)
                            {
                                sectionRemain = sectionRemain + ", " + section;
                            }
                        }
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_ASSY = @TRIAL_ASSY WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain.Substring(2));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain.Substring(2) + "-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    if (Stage == "PK")
                    {
                        string sectionRemain = string.Empty;
                        string queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                        DataTable dataSection = DBUtils._getData(queryDataSection);

                        string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                        DataTable data2 = DBUtils._getData(queryData2);

                        dataSection.Merge(data2);

                        var sectionRemainList = (from r in dataSection.AsEnumerable()
                                                 select r["PIC_SECTION"]).Distinct().ToList();
                        if (sectionRemainList.Count > 0)
                        {
                            foreach (var section in sectionRemainList)
                            {
                                sectionRemain = sectionRemain + ", " + section;
                            }
                        }
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_PK = @TRIAL_PK WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain.Substring(2));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain.Substring(2) + "-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    if (Stage == "MP")
                    {
                        string sectionRemain = string.Empty;
                        string queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                        DataTable dataSection = DBUtils._getData(queryDataSection);

                        string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                        DataTable data2 = DBUtils._getData(queryData2);

                        dataSection.Merge(data2);

                        var sectionRemainList = (from r in dataSection.AsEnumerable()
                                                 select r["PIC_SECTION"]).Distinct().ToList();
                        if (sectionRemainList.Count > 0)
                        {
                            foreach (var section in sectionRemainList)
                            {
                                sectionRemain = sectionRemain + ", " + section;
                            }
                        }
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_MP = @TRIAL_MP WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain.Substring(2));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain.Substring(2) + "-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
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
        private void btnSave3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataStatusPreparation.Rows.Count > 0)
                {
                    MessageBox.Show("Thông tin chuẩn bị chưa được xác nhận, không thể lưu", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dataStatusTrial.Rows.Count <= 0)
                {
                    MessageBox.Show("Thông tin đã được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (Constaint._access != "01")
                    {
                        for (int i = 0; i < gvDataTry.RowCount; i++)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
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
                        for (int i = 0; i < gvDataTry.RowCount; i++)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
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
                    //lưu tên bộ phận chưa nhập đủ thông tin
                    if (Stage == "IM")
                    {
                        string sectionRemain = string.Empty;
                        string queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                        DataTable dataSection = DBUtils._getData(queryDataSection);

                        string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                        DataTable data2 = DBUtils._getData(queryData2);

                        dataSection.Merge(data2);

                        var sectionRemainList = (from r in dataSection.AsEnumerable()
                                                 select r["PIC_SECTION"]).Distinct().ToList();
                        if (sectionRemainList.Count > 0)
                        {
                            foreach (var section in sectionRemainList)
                            {
                                sectionRemain = sectionRemain + ", " + section;
                            }
                        }
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_IM = @TRIAL_IM WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain.Substring(2));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain.Substring(2) + "-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    if (Stage == "ASSY")
                    {
                        string sectionRemain = string.Empty;
                        string queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                        DataTable dataSection = DBUtils._getData(queryDataSection);

                        string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                        DataTable data2 = DBUtils._getData(queryData2);

                        dataSection.Merge(data2);

                        var sectionRemainList = (from r in dataSection.AsEnumerable()
                                                 select r["PIC_SECTION"]).Distinct().ToList();
                        if (sectionRemainList.Count > 0)
                        {
                            foreach (var section in sectionRemainList)
                            {
                                sectionRemain = sectionRemain + ", " + section;
                            }
                        }
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_ASSY = @TRIAL_ASSY WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain.Substring(2));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain.Substring(2) + "-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    if (Stage == "PK")
                    {
                        string sectionRemain = string.Empty;
                        string queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                        DataTable dataSection = DBUtils._getData(queryDataSection);

                        string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                        DataTable data2 = DBUtils._getData(queryData2);

                        dataSection.Merge(data2);

                        var sectionRemainList = (from r in dataSection.AsEnumerable()
                                                 select r["PIC_SECTION"]).Distinct().ToList();
                        if (sectionRemainList.Count > 0)
                        {
                            foreach (var section in sectionRemainList)
                            {
                                sectionRemain = sectionRemain + ", " + section;
                            }
                        }
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_PK = @TRIAL_PK WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain.Substring(2));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain.Substring(2) + "-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    if (Stage == "MP")
                    {
                        string sectionRemain = string.Empty;
                        string queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                        DataTable dataSection = DBUtils._getData(queryDataSection);

                        string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                        DataTable data2 = DBUtils._getData(queryData2);

                        dataSection.Merge(data2);

                        var sectionRemainList = (from r in dataSection.AsEnumerable()
                                                 select r["PIC_SECTION"]).Distinct().ToList();
                        if (sectionRemainList.Count > 0)
                        {
                            foreach (var section in sectionRemainList)
                            {
                                sectionRemain = sectionRemain + ", " + section;
                            }
                        }
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_MP = @TRIAL_MP WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain.Substring(2));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain.Substring(2) + "-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing-" + DueDate.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
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

        private void gvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PLAN_START" || e.Column.FieldName == "PLAN_COMPLETE" || e.Column.FieldName == "ACTUAL_START" || e.Column.FieldName == "ACTUAL_COMPLETE")
            {
                string PlanStart = "";
                string PlanComplete = "";
                string ActualStart = "";
                string ActualComplete = "";
                if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PLAN_START"]) != DBNull.Value)
                {
                    PlanStart = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PLAN_START"]));
                }
                if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PLAN_COMPLETE"]) != DBNull.Value)
                {
                    PlanComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PLAN_COMPLETE"]));
                }
                if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ACTUAL_START"]) != DBNull.Value)
                {
                    ActualStart = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ACTUAL_START"]));
                }
                if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ACTUAL_COMPLETE"]) != DBNull.Value)
                {
                    ActualComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ACTUAL_COMPLETE"]));
                }

                if (!string.IsNullOrEmpty(PlanStart) && !string.IsNullOrEmpty(PlanComplete) && string.IsNullOrEmpty(ActualStart) || string.IsNullOrEmpty(ActualComplete))
                {
                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Plan");
                }
                if (!string.IsNullOrEmpty(ActualStart) && !string.IsNullOrEmpty(ActualComplete) && !string.IsNullOrEmpty(txtDueDate.Text))
                {
                    DateTime DateActualComplete = Convert.ToDateTime(ActualComplete);
                    DateTime DueDate = Convert.ToDateTime(txtDueDate.Text);
                    TimeSpan time = DueDate - DateActualComplete;
                    if (time.Days < 0)
                    {
                        gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Delay");
                    }
                    else
                    {
                        gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "OK");
                    }
                }
                if (!string.IsNullOrEmpty(PlanStart) && !string.IsNullOrEmpty(PlanComplete) && !string.IsNullOrEmpty(ActualStart) && string.IsNullOrEmpty(ActualComplete))
                {
                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Processing");
                }
                if (string.IsNullOrEmpty(PlanStart) || string.IsNullOrEmpty(PlanComplete))
                {
                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Not yet");
                }
            }
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["STATUS"]) != DBNull.Value)
                    {
                        string Status = view.GetRowCellValue(e.RowHandle, "STATUS").ToString();
                        if (e.Column.FieldName == "STATUS")
                        {
                            if (Status == "Plan")
                            {
                                e.Appearance.BackColor = Color.PaleGoldenrod;
                            }
                            if (Status == "OK")
                            {
                                e.Appearance.BackColor = Color.GreenYellow;
                            }
                            if (Status == "NA")
                            {
                                e.Appearance.BackColor = Color.Gainsboro;
                            }
                            if (Status == "Delay")
                            {
                                e.Appearance.BackColor = Color.Coral;
                            }
                            if (Status == "Processing")
                            {
                                e.Appearance.BackColor = Color.Yellow;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        string _fileCopy = string.Empty;
        string pathPdfFile = string.Empty;
        string fileExtension = string.Empty;
        string fileUpLoad = string.Empty;
        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
                int y = gvData.FocusedRowHandle;
                if (Constaint._access != "01")
                {
                    if (Constaint._sectionShort == Convert.ToString(gvData.GetRowCellValue(y, "PIC_SECTION")))
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
                            gvData.SetRowCellValue(y, gvData.Columns["ATTACHED_FILE"], _fileCopy.Substring(1));
                            gvData.SetRowCellValue(y, gvData.Columns["FILE_EXTENSION"], fileExtension);
                            gvData.SetRowCellValue(y, gvData.Columns["ACTUAL_COMPLETE"], DateTime.Now);
                            fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + "-" + "PT" + fileExtension));
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
                        gvData.SetRowCellValue(y, gvData.Columns["ATTACHED_FILE"], _fileCopy.Substring(1));
                        gvData.SetRowCellValue(y, gvData.Columns["FILE_EXTENSION"], fileExtension);
                        gvData.SetRowCellValue(y, gvData.Columns["ACTUAL_COMPLETE"], DateTime.Now);
                        fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + "-" + "PT" + fileExtension));
                        File.Copy(pathPdfFile, fileUpLoad, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDueDate.Text.Trim()))
                {
                    MessageBox.Show("Chọn thời hạn hoàn thành!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string queryUpdateDueDate = "UPDATE TBL_NEW_MOLD_MST SET DUE_DATE_TRIAL_PRODUCTION = @DUE_DATE_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    DialogResult result = MessageBox.Show("Xác nhận thay đổi thời hạn hoàn thành?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateDueDate, conn))
                            {
                                if (!string.IsNullOrEmpty(txtDueDate.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", Convert.ToDateTime(txtDueDate.Text));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", DBNull.Value);
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                        for (int i = 0; i < gvData.RowCount; i++)
                        {
                            string PlanStart = "";
                            string PlanComplete = "";
                            string ActualStart = "";
                            string ActualComplete = "";
                            if (gvData.GetRowCellValue(i, gvData.Columns[4]) != DBNull.Value)
                            {
                                PlanStart = Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns["PLAN_START"]));
                            }
                            if (gvData.GetRowCellValue(i, gvData.Columns[5]) != DBNull.Value)
                            {
                                PlanComplete = Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns["PLAN_COMPLETE"]));
                            }
                            if (gvData.GetRowCellValue(i, gvData.Columns[6]) != DBNull.Value)
                            {
                                ActualStart = Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns["ACTUAL_START"]));
                            }
                            if (gvData.GetRowCellValue(i, gvData.Columns[7]) != DBNull.Value)
                            {
                                ActualComplete = Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns["ACTUAL_COMPLETE"]));
                            }

                            if (!string.IsNullOrEmpty(PlanStart) && !string.IsNullOrEmpty(PlanComplete) && string.IsNullOrEmpty(ActualStart) || string.IsNullOrEmpty(ActualComplete))
                            {
                                gvData.SetRowCellValue(i, gvData.Columns["STATUS"], "Plan");
                            }
                            if (!string.IsNullOrEmpty(ActualStart) && !string.IsNullOrEmpty(ActualComplete))
                            {
                                DateTime DateActualComplete = Convert.ToDateTime(ActualComplete);
                                DateTime DueDate = Convert.ToDateTime(txtDueDate.Text);
                                TimeSpan time = DueDate - DateActualComplete;
                                if (time.Days < 0)
                                {
                                    gvData.SetRowCellValue(i, gvData.Columns["STATUS"], "Delay");
                                }
                                else
                                {
                                    gvData.SetRowCellValue(i, gvData.Columns["STATUS"], "OK");
                                }
                            }
                            if (!string.IsNullOrEmpty(PlanStart) && !string.IsNullOrEmpty(PlanComplete) && !string.IsNullOrEmpty(ActualStart) && string.IsNullOrEmpty(ActualComplete))
                            {
                                gvData.SetRowCellValue(i, gvData.Columns["STATUS"], "Processing");
                            }
                            if (string.IsNullOrEmpty(PlanStart) || string.IsNullOrEmpty(PlanComplete))
                            {
                                gvData.SetRowCellValue(i, gvData.Columns["STATUS"], "Not yet");
                            }
                            //Lưu data status
                            DataRow row = gvData.GetDataRow(i);
                            string queryItems = "UPDATE TBL_PREPARATION_TRY SET STATUS = @STATUS WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    if (string.IsNullOrEmpty(Convert.ToString(row["STATUS"])))
                                    {
                                        cmd.Parameters.AddWithValue("@STATUS", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@STATUS", Convert.ToString(row["STATUS"]));
                                    }
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        //lưu tên bộ phận chưa nhập đủ thông tin
                        //IM
                        {
                            string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                            DataTable Data = DBUtils._getData(queryData);
                            string Status = Convert.ToString(Data.Rows[0]["TRIAL_IM"]);
                            if (!Status.Contains("Finish"))
                            {
                                string sectionRemain1 = string.Empty;
                                string queryDataSection1 = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                                DataTable dataSection1 = DBUtils._getData(queryDataSection1);

                                string queryDataSection21 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                                DataTable dataSection21 = DBUtils._getData(queryDataSection21);

                                dataSection1.Merge(dataSection21);

                                var sectionRemainList1 = (from r in dataSection1.AsEnumerable()
                                                          select r["PIC_SECTION"]).Distinct().ToList();
                                if (sectionRemainList1.Count > 0)
                                {
                                    foreach (var section in sectionRemainList1)
                                    {
                                        sectionRemain1 = sectionRemain1 + ", " + section;
                                    }
                                }
                                string queryUpdateSection1 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_IM = @TRIAL_IM WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryUpdateSection1, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                        if (dataSection1.Rows.Count > 0)
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain1.Substring(2));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain1.Substring(2) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        //ASSY
                        {
                            string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                            DataTable Data = DBUtils._getData(queryData);
                            string Status = Convert.ToString(Data.Rows[0]["TRIAL_ASSY"]);
                            if (!Status.Contains("Finish"))
                            {
                                string sectionRemain2 = string.Empty;
                                string queryDataSection2 = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                                DataTable dataSection2 = DBUtils._getData(queryDataSection2);

                                string queryDataSection22 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                                DataTable dataSection22 = DBUtils._getData(queryDataSection22);

                                dataSection2.Merge(dataSection22);

                                var sectionRemainList2 = (from r in dataSection2.AsEnumerable()
                                                          select r["PIC_SECTION"]).Distinct().ToList();
                                if (sectionRemainList2.Count > 0)
                                {
                                    foreach (var section in sectionRemainList2)
                                    {
                                        sectionRemain2 = sectionRemain2 + ", " + section;
                                    }
                                }
                                string queryUpdateSection2 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_ASSY = @TRIAL_ASSY WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryUpdateSection2, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                        if (dataSection2.Rows.Count > 0)
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain2.Substring(2));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain2.Substring(2) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        //PK
                        {
                            string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                            DataTable Data = DBUtils._getData(queryData);
                            string Status = Convert.ToString(Data.Rows[0]["TRIAL_PK"]);
                            if (!Status.Contains("Finish"))
                            {
                                string sectionRemain3 = string.Empty;
                                string queryDataSection3 = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                                DataTable dataSection3 = DBUtils._getData(queryDataSection3);

                                string queryDataSection23 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                                DataTable dataSection23 = DBUtils._getData(queryDataSection23);

                                dataSection3.Merge(dataSection23);

                                var sectionRemainList3 = (from r in dataSection3.AsEnumerable()
                                                          select r["PIC_SECTION"]).Distinct().ToList();
                                if (sectionRemainList3.Count > 0)
                                {
                                    foreach (var section in sectionRemainList3)
                                    {
                                        sectionRemain3 = sectionRemain3 + ", " + section;
                                    }
                                }
                                string queryUpdateSection3 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_PK = @TRIAL_PK WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryUpdateSection3, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                        if (dataSection3.Rows.Count > 0)
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain3.Substring(2));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain3.Substring(2) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        //MP
                        {
                            string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                            DataTable Data = DBUtils._getData(queryData);
                            string Status = Convert.ToString(Data.Rows[0]["TRIAL_MP"]);
                            if (!Status.Contains("Finish"))
                            {
                                string sectionRemain4 = string.Empty;
                                string queryDataSection4 = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
                                DataTable dataSection4 = DBUtils._getData(queryDataSection4);

                                string queryDataSection24 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
                                DataTable dataSection24 = DBUtils._getData(queryDataSection24);

                                dataSection4.Merge(dataSection24);

                                var sectionRemainList4 = (from r in dataSection4.AsEnumerable()
                                                          select r["PIC_SECTION"]).Distinct().ToList();
                                if (sectionRemainList4.Count > 0)
                                {
                                    foreach (var section in sectionRemainList4)
                                    {
                                        sectionRemain4 = sectionRemain4 + ", " + section;
                                    }
                                }
                                string queryUpdateSection4 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_MP = @TRIAL_MP WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryUpdateSection4, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                        if (dataSection4.Rows.Count > 0)
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain4.Substring(2));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain4.Substring(2) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        //CONFIRMED_TRIAL
                        {
                            string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                            DataTable Data = DBUtils._getData(queryData);
                            string Status = Convert.ToString(Data.Rows[0]["TRIAL_CONFIRMATION"]);
                            if (!Status.Contains("Finish"))
                            {
                                string sectionRemain5 = string.Empty;
                                string queryDataSection5 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND (PLAN_COMPLETE is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
                                DataTable dataSection5 = DBUtils._getData(queryDataSection5);

                                string queryDataSection25 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_VALUABLE_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND ([PLAN] is null or ACTUAL is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
                                DataTable dataSection25 = DBUtils._getData(queryDataSection25);

                                dataSection5.Merge(dataSection25);

                                var sectionRemainList5 = (from r in dataSection5.AsEnumerable()
                                                          select r["PIC_SECTION"]).Distinct().ToList();
                                if (sectionRemainList5.Count > 0)
                                {
                                    foreach (var section in sectionRemainList5)
                                    {
                                        sectionRemain5 = sectionRemain5 + ", " + section;
                                    }
                                }
                                string queryUpdateSection5 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryUpdateSection5, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                        if (dataSection5.Rows.Count > 0)
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            if (Status.Contains("Wait"))
                            {
                                string queryUpdateSection5 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryUpdateSection5, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                            if (string.IsNullOrEmpty(txtDueDate.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait" + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                            }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
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

        private void gvData_DoubleClick(object sender, EventArgs e)
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
                        if (!string.IsNullOrEmpty(Convert.ToString(gvData.GetFocusedRowCellValue("ATTACHED_FILE"))))
                        {
                            System.Diagnostics.Process.Start(Constaint._folderFileUpload + gvData.GetFocusedRowCellValue("ATTACHED_FILE").ToString() + gvData.GetFocusedRowCellValue("FILE_EXTENSION").ToString());
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("File không tồn tại!");
            }
        }

        private void btnChecked_Click(object sender, EventArgs e)
        {
            try
            {
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    if (dataStatusPreparation.Rows.Count > 0)
                    {
                        MessageBox.Show("Thông tin chuẩn bị chưa được xác nhận, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (dataStatusTrial.Rows.Count > 0)
                    {
                        MessageBox.Show("Thông tin chạy thử chưa được xác nhận, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    for (int i = 0; i < gvData.RowCount; i++)
                    {
                        DataRow row = gvData.GetDataRow(i);
                        if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_START"])) || string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_START"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                        {
                            MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    for (int i = 0; i < gvDataTry.RowCount; i++)
                    {
                        if (CountTrial == 1)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["1ST_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 2)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["2ND_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 3)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["3RD_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 4)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["4TH_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 5)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["5TH_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 6)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["6TH_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 7)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["7TH_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 8)
                        {
                            DataRow row = gvData.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["8TH_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 9)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["9TH_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (CountTrial == 10)
                        {
                            DataRow row = gvDataTry.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["10TH_TRY"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
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
                    DialogResult result = MessageBox.Show("Xác nhận đã kiểm tra thông tin?", "Checked", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    string queryApproved = string.Empty;
                    if (result == DialogResult.OK)
                    {
                        if (Stage == "IM")
                        {
                            queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_TRIAL_IM = @CHECKED_TRIAL_IM, DATE_CHECKED_TRIAL_IM = @DATE_CHECKED_TRIAL_IM WHERE CONTROL_NO = @CONTROL_NO";
                        }
                        if (Stage == "ASSY")
                        {
                            queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_TRIAL_ASSY = @CHECKED_TRIAL_ASSY, DATE_CHECKED_TRIAL_ASSY = @DATE_CHECKED_TRIAL_ASSY WHERE CONTROL_NO = @CONTROL_NO";
                        }
                        if (Stage == "PK")
                        {
                            queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_TRIAL_PK = @CHECKED_TRIAL_PK, DATE_CHECKED_TRIAL_PK = @DATE_CHECKED_TRIAL_PK WHERE CONTROL_NO = @CONTROL_NO";
                        }
                        if (Stage == "MP")
                        {
                            queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_TRIAL_MP = @CHECKED_TRIAL_MP, DATE_CHECKED_TRIAL_MP = @DATE_CHECKED_TRIAL_MP WHERE CONTROL_NO = @CONTROL_NO";
                        }

                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (Stage == "IM")
                                {
                                    cmd.Parameters.AddWithValue("@CHECKED_TRIAL_IM", Constaint._nameUser);
                                    cmd.Parameters.AddWithValue("@DATE_CHECKED_TRIAL_IM", DateTime.Now);
                                }
                                if (Stage == "ASSY")
                                {
                                    cmd.Parameters.AddWithValue("@CHECKED_TRIAL_ASSY", Constaint._nameUser);
                                    cmd.Parameters.AddWithValue("@DATE_CHECKED_TRIAL_ASSY", DateTime.Now);
                                }
                                if (Stage == "PK")
                                {
                                    cmd.Parameters.AddWithValue("@CHECKED_TRIAL_PK", Constaint._nameUser);
                                    cmd.Parameters.AddWithValue("@DATE_CHECKED_TRIAL_PK", DateTime.Now);
                                }
                                if (Stage == "MP")
                                {
                                    cmd.Parameters.AddWithValue("@CHECKED_TRIAL_MP", Constaint._nameUser);
                                    cmd.Parameters.AddWithValue("@DATE_CHECKED_TRIAL_MP", DateTime.Now);
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Xác nhận đã kiểm tra thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_PREPARATION_TRY_STAGE_Load(sender, e);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        DateTime DueDate2;
        private void btnApproved_Click(object sender, EventArgs e)
        {
            try
            {
                string TrialIM = string.Empty;
                string TrialASSY = string.Empty;
                string TrialPK = string.Empty;
                string TrialMP = string.Empty;
                string queryApproved = string.Empty;
                string queryDataAppved = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable dataAppved = DBUtils._getData(queryDataAppved);
                if (dataAppved.Rows.Count > 0)
                {
                    TrialIM = Convert.ToString(dataAppved.Rows[0]["TRIAL_IM"]);
                    TrialASSY = Convert.ToString(dataAppved.Rows[0]["TRIAL_ASSY"]);
                    TrialPK = Convert.ToString(dataAppved.Rows[0]["TRIAL_PK"]);
                    TrialMP = Convert.ToString(dataAppved.Rows[0]["TRIAL_MP"]);
                }

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
                        if (Stage == "IM")
                        {
                            queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, TRIAL_IM = @TRIAL_IM, TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION, " +
                                "APPROVED_TRIAL_IM = @APPROVED_TRIAL_IM, DATE_APPROVED_TRIAL_IM = @DATE_APPROVED_TRIAL_IM, COMMENTS_TRIAL_IM = @COMMENTS_TRIAL_IM WHERE CONTROL_NO = @CONTROL_NO";
                        }
                        if (Stage == "ASSY")
                        {
                            queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, TRIAL_ASSY = @TRIAL_ASSY, TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION, " +
                                "APPROVED_TRIAL_ASSY = @APPROVED_TRIAL_ASSY, DATE_APPROVED_TRIAL_ASSY = @DATE_APPROVED_TRIAL_ASSY, COMMENTS_TRIAL_ASSY = @COMMENTS_TRIAL_ASSY WHERE CONTROL_NO = @CONTROL_NO";
                        }
                        if (Stage == "PK")
                        {
                            queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, TRIAL_PK = @TRIAL_PK, TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION, " +
                                "APPROVED_TRIAL_PK = @APPROVED_TRIAL_PK, DATE_APPROVED_TRIAL_PK = @DATE_APPROVED_TRIAL_PK, COMMENTS_TRIAL_PK = @COMMENTS_TRIAL_PK WHERE CONTROL_NO = @CONTROL_NO";
                        }
                        if (Stage == "MP")
                        {
                            queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, TRIAL_MP = @TRIAL_MP, TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION, " +
                                "APPROVED_TRIAL_MP = @APPROVED_TRIAL_MP, DATE_APPROVED_TRIAL_MP = @DATE_APPROVED_TRIAL_MP, COMMENTS_TRIAL_MP = @COMMENTS_TRIAL_MP WHERE CONTROL_NO = @CONTROL_NO";
                        }
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (Stage == "IM")
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_IM", "Finish");
                                }
                                if (Stage == "ASSY")
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Finish");
                                }
                                if (Stage == "PK")
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_PK", "Finish");
                                }
                                if (Stage == "MP")
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_MP", "Finish");
                                }
                                if (Constaint.MoldType == "Connector")
                                {
                                    if (Stage == "IM" && ProductType == "Unit")
                                    {
                                        if (TrialPK == "Finish")
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "05");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "04");
                                        }
                                    }
                                    if (Stage == "IM" && ProductType == "Assy")
                                    {
                                        if (TrialPK == "Finish" && TrialASSY == "Finish")
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "05");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "04");
                                        }
                                    }
                                    if (Stage == "ASSY")
                                    {
                                        if (TrialIM == "Finish" && TrialPK == "Finish")
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "05");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "04");
                                        }
                                    }
                                    if (Stage == "PK" && ProductType == "Assy")
                                    {
                                        if (TrialIM == "Finish" && TrialASSY == "Finish")
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "05");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "04");
                                        }
                                    }
                                    if (Stage == "PK" && ProductType == "Unit")
                                    {
                                        if (TrialIM == "Finish")
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "05");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "04");
                                        }
                                    }

                                }
                                else
                                {
                                    if (Stage == "MP")
                                    {
                                        if (TrialPK == "Finish")
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "05");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "04");
                                        }
                                    }
                                    if (Stage == "PK")
                                    {
                                        if (TrialMP == "Finish")
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "05");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            cmd.Parameters.AddWithValue("@STEP_CODE", "04");
                                        }
                                    }
                                }
                                if (Stage == "IM")
                                {
                                    cmd.Parameters.AddWithValue("@APPROVED_TRIAL_IM", Constaint._nameUser);
                                    cmd.Parameters.AddWithValue("@DATE_APPROVED_TRIAL_IM", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@COMMENTS_TRIAL_IM", txtComments.Text);
                                }
                                if (Stage == "ASSY")
                                {
                                    cmd.Parameters.AddWithValue("@APPROVED_TRIAL_ASSY", Constaint._nameUser);
                                    cmd.Parameters.AddWithValue("@DATE_APPROVED_TRIAL_ASSY", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@COMMENTS_TRIAL_ASSY", txtComments.Text);
                                }
                                if (Stage == "PK")
                                {
                                    cmd.Parameters.AddWithValue("@APPROVED_TRIAL_PK", Constaint._nameUser);
                                    cmd.Parameters.AddWithValue("@DATE_APPROVED_TRIAL_PK", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@COMMENTS_TRIAL_PK", txtComments.Text);
                                }
                                if (Stage == "MP")
                                {
                                    cmd.Parameters.AddWithValue("@APPROVED_TRIAL_MP", Constaint._nameUser);
                                    cmd.Parameters.AddWithValue("@DATE_APPROVED_TRIAL_MP", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@COMMENTS_TRIAL_MP", txtComments.Text);
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                        string TrialIM2 = string.Empty;
                        string TrialASSY2 = string.Empty;
                        string TrialPK2 = string.Empty;
                        string TrialMP2 = string.Empty;

                        
                        string queryDataAppved2 = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                        DataTable dataAppved2 = DBUtils._getData(queryDataAppved2);
                        if (!string.IsNullOrEmpty(Convert.ToString(dataAppved2.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"])))
                        {
                            DueDate2 = Convert.ToDateTime(dataAppved2.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"].ToString());
                        }
                        if (dataAppved2.Rows.Count > 0)
                        {
                            TrialIM2 = Convert.ToString(dataAppved2.Rows[0]["TRIAL_IM"]);
                            TrialASSY2 = Convert.ToString(dataAppved2.Rows[0]["TRIAL_ASSY"]);
                            TrialPK2 = Convert.ToString(dataAppved2.Rows[0]["TRIAL_PK"]);
                            TrialMP2 = Convert.ToString(dataAppved2.Rows[0]["TRIAL_MP"]);

                        }
                        //lưu tên bộ phận chưa nhập đủ thông tin
                        if (Constaint.MoldType == "Connector")
                        {
                            if (ProductType == "Unit")
                            {
                                if (TrialIM2 == "Finish" && TrialPK2 == "Finish")
                                {
                                    //CONFIRMED_TRIAL
                                    {
                                        string sectionRemain5 = string.Empty;
                                        string queryDataSection5 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND (PLAN_COMPLETE is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
                                        DataTable dataSection5 = DBUtils._getData(queryDataSection5);

                                        string queryDataSection25 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_VALUABLE_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND ([PLAN] is null or ACTUAL is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
                                        DataTable dataSection25 = DBUtils._getData(queryDataSection25);

                                        dataSection5.Merge(dataSection25);

                                        var sectionRemainList5 = (from r in dataSection5.AsEnumerable()
                                                                  select r["PIC_SECTION"]).Distinct().ToList();
                                        if (sectionRemainList5.Count > 0)
                                        {
                                            foreach (var section in sectionRemainList5)
                                            {
                                                sectionRemain5 = sectionRemain5 + ", " + section;
                                            }
                                        }
                                        string queryUpdateSection5 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                        {
                                            _conn.Open();
                                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection5, _conn))
                                            {
                                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                                if (dataSection5.Rows.Count > 0)
                                                {
                                                    if (string.IsNullOrEmpty(DueDate2.ToString()))
                                                    {
                                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2));
                                                    }
                                                    else
                                                    {
                                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2) + "-" + DueDate2.ToString("dd/MMM"));
                                                    }
                                                }
                                                else
                                                {
                                                    if (string.IsNullOrEmpty(DueDate2.ToString()))
                                                    {
                                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                                    }
                                                    else
                                                    {
                                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing-" + DueDate2.ToString("dd/MMM"));
                                                    }
                                                }
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (TrialIM2 == "Finish" && TrialASSY2 == "Finish" && TrialPK2 == "Finish")
                                {
                                    //CONFIRMED_TRIAL
                                    {
                                        string sectionRemain5 = string.Empty;
                                        string queryDataSection5 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND (PLAN_COMPLETE is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
                                        DataTable dataSection5 = DBUtils._getData(queryDataSection5);

                                        string queryDataSection25 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_VALUABLE_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND ([PLAN] is null or ACTUAL is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
                                        DataTable dataSection25 = DBUtils._getData(queryDataSection25);

                                        dataSection5.Merge(dataSection25);

                                        var sectionRemainList5 = (from r in dataSection5.AsEnumerable()
                                                                  select r["PIC_SECTION"]).Distinct().ToList();
                                        if (sectionRemainList5.Count > 0)
                                        {
                                            foreach (var section in sectionRemainList5)
                                            {
                                                sectionRemain5 = sectionRemain5 + ", " + section;
                                            }
                                        }
                                        string queryUpdateSection5 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                        {
                                            _conn.Open();
                                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection5, _conn))
                                            {
                                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                                if (dataSection5.Rows.Count > 0)
                                                {
                                                    if (string.IsNullOrEmpty(DueDate2.ToString()))
                                                    {
                                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2));
                                                    }
                                                    else
                                                    {
                                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2) + "-" + DueDate2.ToString("dd/MMM"));
                                                    }
                                                }
                                                else
                                                {
                                                    if (string.IsNullOrEmpty(DueDate2.ToString()))
                                                    {
                                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                                    }
                                                    else
                                                    {
                                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing-" + DueDate2.ToString("dd/MMM"));
                                                    }
                                                }
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (Constaint.MoldType == "Connector")
                        {
                            if (TrialMP2 == "Finish" && TrialPK2 == "Finish")
                            {
                                //CONFIRMED_TRIAL
                                {
                                    string sectionRemain5 = string.Empty;
                                    string queryDataSection5 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND (PLAN_COMPLETE is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
                                    DataTable dataSection5 = DBUtils._getData(queryDataSection5);

                                    string queryDataSection25 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_VALUABLE_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND ([PLAN] is null or ACTUAL is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
                                    DataTable dataSection25 = DBUtils._getData(queryDataSection25);

                                    dataSection5.Merge(dataSection25);

                                    var sectionRemainList5 = (from r in dataSection5.AsEnumerable()
                                                              select r["PIC_SECTION"]).Distinct().ToList();
                                    if (sectionRemainList5.Count > 0)
                                    {
                                        foreach (var section in sectionRemainList5)
                                        {
                                            sectionRemain5 = sectionRemain5 + ", " + section;
                                        }
                                    }
                                    string queryUpdateSection5 = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdateSection5, _conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                            if (dataSection5.Rows.Count > 0)
                                            {
                                                if (string.IsNullOrEmpty(txtDueDate.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2));
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(txtDueDate.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Phê duyệt thành công.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_PREPARATION_TRY_STAGE_Load(sender, e);
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

        private void gcData_Click(object sender, EventArgs e)
        {

        }

    }
}