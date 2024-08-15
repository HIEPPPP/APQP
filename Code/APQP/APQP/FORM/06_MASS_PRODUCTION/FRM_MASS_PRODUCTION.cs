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
using System.IO;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace APQP.FORM._06._MASS_PRODUCTION
{
    public partial class FRM_MASS_PRODUCTION : DevExpress.XtraEditors.XtraForm
    {
        public FRM_MASS_PRODUCTION(string ControlNo)
        {
            this.ControlNo = ControlNo;
            InitializeComponent();
        }
        string ControlNo;

        private void FRM_MASS_PRODUCTION_Load(object sender, EventArgs e)
        {
            label3.Text = "SPECIAL INSPECTION (" + ControlNo + ")";
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
            LoadData();
        }
        DateTime DTDueDate;
        string DueDate = string.Empty;
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_MASS_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable data = DBUtils._getData(queryData);
                gcData.DataSource = data;
                //Load Data Approved
                string queryDataApproved = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                DataTable DataApproved = DBUtils._getData(queryDataApproved);
                DateTime DateChecked;
                DateTime DateApproved;
               
                if (DataApproved.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECKED_MASS_PRODUCTION"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECKED_MASS_PRODUCTION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECKED_MASS_PRODUCTION"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECKED_MASS_PRODUCTION"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_MASS_PRODUCTION"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_MASS_PRODUCTION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_MASS_PRODUCTION"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_MASS_PRODUCTION"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_MASS_PRODUCTION"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_MASS_PRODUCTION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUA_DATE_MASS_PRODUCTION"])))
                    {
                        DTDueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUA_DATE_MASS_PRODUCTION"].ToString());
                        DueDate = DTDueDate.ToString("dd/MMM");
                        txtDueDate.Text = DTDueDate.ToString("dd/MM/yyyy");
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
        string fileExtension;
        string fileUpLoad;
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
                            fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + "-" + "M" + fileExtension));
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
                        fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + "-" + "M" + fileExtension));
                        File.Copy(pathPdfFile, fileUpLoad, true);
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
                if (Constaint._access != "01")
                {
                    if (!string.IsNullOrEmpty(txtChecked.Text))
                    {
                        MessageBox.Show("Thông tin đã được xác nhận, không thể lưu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
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
                                string queryMass = "UPDATE TBL_MASS_PRODUCTION SET JUDGEMENT = @JUDGEMENT, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryMass, _conn))
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
                                            cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"] + "-" + "M"));
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
                                        if (string.IsNullOrEmpty(Convert.ToString(row["NOTE"])))
                                        {
                                            cmd.Parameters.AddWithValue("@NOTE", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
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
                            string queryMass = "UPDATE TBL_MASS_PRODUCTION SET JUDGEMENT = @JUDGEMENT, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryMass, _conn))
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
                                        cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"] + "-" + "M"));
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
                                    if (string.IsNullOrEmpty(Convert.ToString(row["NOTE"])))
                                    {
                                        cmd.Parameters.AddWithValue("@NOTE", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                                    }
                                    cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    //Lưu bộ phận chưa nhập đủ thông tin
                    string queryStatus = "SELECT MASS_PRODUCTION FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                    DataTable dataStatus = DBUtils._getData(queryStatus);
                    string status = Convert.ToString(dataStatus.Rows[0]["MASS_PRODUCTION"]);
                    if (!status.Contains("Finish"))
                    {
                        //Lưu bộ phận chưa nhập đủ thông tin
                        string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS MASS_PRODUCTION FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_MASS_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND (PLAN_COMPLETE is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(NOTE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0) GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                        DataTable dataSection = DBUtils._getData(queryDataSection);
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET MASS_PRODUCTION = @MASS_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDate))
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", Convert.ToString(dataSection.Rows[0]["MASS_PRODUCTION"]));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", Convert.ToString(dataSection.Rows[0]["MASS_PRODUCTION"]) + "-" + DueDate);
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDate))
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing-" + DueDate);
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
                        if (string.IsNullOrEmpty(Convert.ToString(row["JUDGEMENT"])) || string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                        {
                            MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    DialogResult result = MessageBox.Show("Xác nhận đã kiểm tra thông tin?", "Checked", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_MASS_PRODUCTION = @CHECKED_MASS_PRODUCTION, DATE_CHECKED_MASS_PRODUCTION = @DATE_CHECKED_MASS_PRODUCTION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@CHECKED_MASS_PRODUCTION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_CHECKED_MASS_PRODUCTION", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Xác nhận đã kiểm tra thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_MASS_PRODUCTION_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Không có quyền xác nhận", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, MASS_PRODUCTION = @MASS_PRODUCTION," +
                            "APPROVED_MASS_PRODUCTION = @APPROVED_MASS_PRODUCTION, DATE_APPROVED_MASS_PRODUCTION = @DATE_APPROVED_MASS_PRODUCTION, COMMENTS_MASS_PRODUCTION = @COMMENTS_MASS_PRODUCTION, FOLLOW_UP = @FOLLOW_UP WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@STEP_CODE", "07");
                                cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Finish");
                                cmd.Parameters.AddWithValue("@APPROVED_MASS_PRODUCTION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_APPROVED_MASS_PRODUCTION", DateTime.Now);
                                cmd.Parameters.AddWithValue("@COMMENTS_MASS_PRODUCTION", txtComments.Text);
                                cmd.Parameters.AddWithValue("@FOLLOW_UP", "Finish");
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Phê duyệt thành công.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_MASS_PRODUCTION_Load(sender, e);
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

        private void btnEdit_Click(object sender, EventArgs e)
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
                        string queryUpdateDueDate = "UPDATE TBL_NEW_MOLD_MST SET DUA_DATE_MASS_PRODUCTION = @DUA_DATE_MASS_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateDueDate, conn))
                            {
                                cmd.Parameters.AddWithValue("@DUA_DATE_MASS_PRODUCTION", Convert.ToDateTime(txtDueDate.Text));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        for (int i = 0; i < gvData.RowCount; i++)
                        {
                            string PlanComplete = "";
                            string ActualComplete = "";
                            if (gvData.GetRowCellValue(i, gvData.Columns[4]) != DBNull.Value)
                            {
                                PlanComplete = Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns[4]));
                            }
                            if (gvData.GetRowCellValue(i, gvData.Columns[5]) != DBNull.Value)
                            {
                                ActualComplete = Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns[5]));
                            }
                            if (!string.IsNullOrEmpty(PlanComplete) && string.IsNullOrEmpty(ActualComplete))
                            {
                                gvData.SetRowCellValue(i, gvData.Columns["JUDGEMENT"], "Plan");
                            }
                            if (!string.IsNullOrEmpty(PlanComplete) && !string.IsNullOrEmpty(ActualComplete))
                            {
                                DateTime DateActualComplete = Convert.ToDateTime(ActualComplete);
                                DateTime DueDate = Convert.ToDateTime(txtDueDate.Text);
                                TimeSpan time = DueDate - DateActualComplete;
                                if (time.Days < 0)
                                {
                                    gvData.SetRowCellValue(i, gvData.Columns["JUDGEMENT"], "Delay");
                                }
                                else
                                {
                                    gvData.SetRowCellValue(i, gvData.Columns["JUDGEMENT"], "OK");
                                }
                            }
                            //Lưu data status
                            DataRow row = gvData.GetDataRow(i);
                            string queryItems = "UPDATE TBL_MASS_PRODUCTION SET JUDGEMENT = @JUDGEMENT WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
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
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                        DataTable Data = DBUtils._getData(queryData);
                        string Status = Convert.ToString(Data.Rows[0]["MASS_PRODUCTION"]);
                        if (!Status.Contains("Finish"))
                        {
                            //Lưu bộ phận chưa nhập đủ thông tin
                            string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS MASS_PRODUCTION FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_MASS_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "' AND (PLAN_COMPLETE is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(NOTE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0) GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                            DataTable dataSection = DBUtils._getData(queryDataSection);
                            string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET MASS_PRODUCTION = @MASS_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                    if (dataSection.Rows.Count > 0)
                                    {
                                        if (string.IsNullOrEmpty(txtDueDate.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@MASS_PRODUCTION", Convert.ToString(dataSection.Rows[0]["MASS_PRODUCTION"]));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@MASS_PRODUCTION", Convert.ToString(dataSection.Rows[0]["MASS_PRODUCTION"]) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(txtDueDate.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                        }
                                    }
                                    cmd.ExecuteNonQuery();
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

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                //if (e.Column.FieldName == "PLAN_COMPLETE" || e.Column.FieldName == "ACTUAL_COMPLETE")
                //{
                //    string PlanComplete = "";
                //    string ActualComplete = "";
                //    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[4]) != DBNull.Value)
                //    {
                //        PlanComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns[4]));
                //    }
                //    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[5]) != DBNull.Value)
                //    {
                //        ActualComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns[5]));
                //    }
                //    if (!string.IsNullOrEmpty(PlanComplete) && string.IsNullOrEmpty(ActualComplete))
                //    {
                //        gvData.SetRowCellValue(e.RowHandle, gvData.Columns["JUDGEMENT"], "Plan");
                //    }
                //    if (!string.IsNullOrEmpty(PlanComplete) && !string.IsNullOrEmpty(ActualComplete))
                //    {
                //        DateTime DateActualComplete = Convert.ToDateTime(ActualComplete);
                //        DateTime DueDate = Convert.ToDateTime(txtDueDate.Text);
                //        TimeSpan time = DueDate - DateActualComplete;
                //        if (time.Days < 0)
                //        {
                //            gvData.SetRowCellValue(e.RowHandle, gvData.Columns["JUDGEMENT"], "Delay");
                //        }
                //        else
                //        {
                //            gvData.SetRowCellValue(e.RowHandle, gvData.Columns["JUDGEMENT"], "OK");
                //        }
                //    }
                //}
                GridView view = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[3]) != DBNull.Value)
                    {
                        string Status = view.GetRowCellValue(e.RowHandle, "JUDGEMENT").ToString();
                        if (e.Column.FieldName == "JUDGEMENT")
                        {
                            if (Status == "Plan")
                            {
                                e.Appearance.BackColor = Color.PaleGoldenrod;
                            }
                            if (Status == "OK")
                            {
                                e.Appearance.BackColor = Color.GreenYellow;
                            }
                            if (Status == "Delay")
                            {
                                e.Appearance.BackColor = Color.Coral;
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

        private void gvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PLAN_COMPLETE" || e.Column.FieldName == "ACTUAL_COMPLETE")
            {
                string PlanComplete = "";
                string ActualComplete = "";
                if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[4]) != DBNull.Value)
                {
                    PlanComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns[4]));
                }
                if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[5]) != DBNull.Value)
                {
                    ActualComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns[5]));
                }
                if (!string.IsNullOrEmpty(PlanComplete) && string.IsNullOrEmpty(ActualComplete))
                {
                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["JUDGEMENT"], "Plan");
                }
                if (!string.IsNullOrEmpty(PlanComplete) && !string.IsNullOrEmpty(ActualComplete) && !string.IsNullOrEmpty(txtDueDate.Text))
                {
                    DateTime DateActualComplete = Convert.ToDateTime(ActualComplete);
                    DateTime DueDate = Convert.ToDateTime(txtDueDate.Text);
                    TimeSpan time = DueDate - DateActualComplete;
                    if (time.Days < 0)
                    {
                        gvData.SetRowCellValue(e.RowHandle, gvData.Columns["JUDGEMENT"], "Delay");
                    }
                    else
                    {
                        gvData.SetRowCellValue(e.RowHandle, gvData.Columns["JUDGEMENT"], "OK");
                    }
                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}