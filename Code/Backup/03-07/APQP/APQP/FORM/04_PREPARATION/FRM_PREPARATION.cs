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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace APQP.FORM._04._PREPARATION
{
    public partial class FRM_PREPARATION : DevExpress.XtraEditors.XtraForm
    {
        public FRM_PREPARATION(string ControlNo, string ProductType)
        {
            this.ProductType = ProductType;
            this.ControlNo = ControlNo;
            InitializeComponent();
        }
        string ControlNo;
        string ProductType;
        private void FRM_PREPARATION_Load(object sender, EventArgs e)
        {
            label1.Text = "PREPARATION (" + ControlNo + ")";
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
        DateTime DTDueDateTrial;
        string DueDateTrial = string.Empty;
        string Status = string.Empty;
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_PREPARATION WHERE STATUS_DELETE = '0' AND CONTROL_NO = '" + ControlNo + "' ORDER BY SORT_NUMBER ASC";
                DataTable data = DBUtils._getData(queryData);
                gcData.DataSource = data;
                //Load Data Approved
                string queryDataApproved = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                DataTable DataApproved = DBUtils._getData(queryDataApproved);
                Status = Convert.ToString(DataApproved.Rows[0]["PREPARATION"]);
                if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"])))
                {
                    DTDueDateTrial = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"].ToString());
                    DueDateTrial = DTDueDateTrial.ToString("dd/MMM");
                }
                DateTime DateChecked;
                DateTime DateApproved;
                
                if (DataApproved.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECKED_PREPARATION"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECKED_PREPARATION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECKED_PREPARATION"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECKED_PREPARATION"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_PREPARATION"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_PREPARATION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_PREPARATION"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_PREPARATION"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_PREPARATION"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_PREPARATION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_PREPARATION"])))
                    {
                        DTDueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_PREPARATION"].ToString());
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
                        for (int i = 0; i < gvData.RowCount; i++)
                        {
                            DataRow row = gvData.GetDataRow(i);
                            string Section = Convert.ToString(row["PIC_SECTION"]);
                            if (Section == Constaint._sectionShort)
                            {
                                //string queryItems = "UPDATE TBL_PREPARATION SET STATUS = @STATUS, PLAN_START = @PLAN_START, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_START = @ACTUAL_START, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                //using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                //{
                                //    _conn.Open();
                                //    using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                //    {
                                //        cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                //        if (string.IsNullOrEmpty(Convert.ToString(row["STATUS"])))
                                //        {
                                //            cmd.Parameters.AddWithValue("@STATUS", DBNull.Value);
                                //        }
                                //        else
                                //        {
                                //            cmd.Parameters.AddWithValue("@STATUS", Convert.ToString(row["STATUS"]));
                                //        }
                                //        if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_START"])))
                                //        {
                                //            cmd.Parameters.AddWithValue("@PLAN_START", DBNull.Value);
                                //        }
                                //        else
                                //        {
                                //            cmd.Parameters.AddWithValue("@PLAN_START", Convert.ToDateTime(row["PLAN_START"]));
                                //        }
                                //        if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])))
                                //        {
                                //            cmd.Parameters.AddWithValue("@PLAN_COMPLETE", DBNull.Value);
                                //        }
                                //        else
                                //        {
                                //            cmd.Parameters.AddWithValue("@PLAN_COMPLETE", Convert.ToDateTime(row["PLAN_COMPLETE"]));
                                //        }
                                //        if (string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_START"])))
                                //        {
                                //            cmd.Parameters.AddWithValue("@ACTUAL_START", DBNull.Value);
                                //        }
                                //        else
                                //        {
                                //            cmd.Parameters.AddWithValue("@ACTUAL_START", Convert.ToDateTime(row["ACTUAL_START"]));
                                //        }
                                //        if (string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])))
                                //        {
                                //            cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", DBNull.Value);
                                //        }
                                //        else
                                //        {
                                //            cmd.Parameters.AddWithValue("@ACTUAL_COMPLETE", Convert.ToDateTime(row["ACTUAL_COMPLETE"]));
                                //        }
                                //        if (string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                                //        {
                                //            cmd.Parameters.AddWithValue("@ATTACHED_FILE", DBNull.Value);
                                //        }
                                //        else
                                //        {
                                //            cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"]) + "-" + "P");
                                //        }
                                //        if (string.IsNullOrEmpty(Convert.ToString(row["FILE_EXTENSION"])))
                                //        {
                                //            cmd.Parameters.AddWithValue("@FILE_EXTENSION", DBNull.Value);
                                //        }
                                //        else
                                //        {
                                //            cmd.Parameters.AddWithValue("@FILE_EXTENSION", Convert.ToString(row["FILE_EXTENSION"]));
                                //        }
                                //        cmd.Parameters.AddWithValue("@DOCUMENTS", Convert.ToString(row["DOCUMENTS"]));
                                //        cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                                //        cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                //        cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                //        cmd.ExecuteNonQuery();

                                //    }
                                //}
                                string queryItems = "UPDATE TBL_PREPARATION SET STATUS = @STATUS, PLAN_START = @PLAN_START, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_START = @ACTUAL_START, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
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
                                            cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"]) + "-" + "P");
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
                            string queryItems = "UPDATE TBL_PREPARATION SET STATUS = @STATUS, PLAN_START = @PLAN_START, PLAN_COMPLETE = @PLAN_COMPLETE, ACTUAL_START = @ACTUAL_START, ACTUAL_COMPLETE = @ACTUAL_COMPLETE, ATTACHED_FILE = @ATTACHED_FILE, FILE_EXTENSION = @FILE_EXTENSION, DOCUMENTS = @DOCUMENTS, NOTE = @NOTE, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
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
                                        cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + Convert.ToString(row["ID_IDENTITY"]) + "-" + "P");
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
                    //Lưu bộ phận chưa nhập đủ thông tin
                    string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS PREPARATION FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_PREPARATION WHERE CONTROL_NO = '" + ControlNo + "' AND STATUS_DELETE = '0' AND (PLAN_START is null or PLAN_COMPLETE is null or  ACTUAL_START is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0) GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                    DataTable dataSection = DBUtils._getData(queryDataSection);
                    string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET PREPARATION = @PREPARATION WHERE CONTROL_NO = '" + ControlNo + "'";
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
                                    cmd.Parameters.AddWithValue("@PREPARATION", Convert.ToString(dataSection.Rows[0]["PREPARATION"]));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PREPARATION", Convert.ToString(dataSection.Rows[0]["PREPARATION"]) + "-" + DueDate);
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(DueDate.ToString()))
                                {
                                    cmd.Parameters.AddWithValue("@PREPARATION", "Processing");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PREPARATION", "Processing-" + DueDate);
                                }
                            }
                            cmd.ExecuteNonQuery();
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

        string _fileCopy = string.Empty;
        string pathPdfFile = string.Empty;
        string fileExtension= string.Empty;
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
                            fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + "-" + "P" + fileExtension));
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
                        fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + "-" + "P" + fileExtension));
                        File.Copy(pathPdfFile, fileUpLoad, true);
                    }
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
                        if (string.IsNullOrEmpty(Convert.ToString(row["STATUS"])) || string.IsNullOrEmpty(Convert.ToString(row["PLAN_START"])) || string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_START"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_PREPARATION = @CHECKED_PREPARATION, DATE_CHECKED_PREPARATION = @DATE_CHECKED_PREPARATION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@CHECKED_PREPARATION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_CHECKED_PREPARATION", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Xác nhận đã kiểm tra thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_PREPARATION_Load(sender, e);
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, PREPARATION = @PREPARATION, TRIAL_IM = @TRIAL_IM, TRIAL_ASSY = @TRIAL_ASSY, TRIAL_PK = @TRIAL_PK, TRIAL_MP = @TRIAL_MP, TRIAL_PRODUCTION = @TRIAL_PRODUCTION, " +
                            "APPROVED_PREPARATION = @APPROVED_PREPARATION, DATE_APPROVED_PREPARATION = @DATE_APPROVED_PREPARATION, COMMENTS_PREPARATION = @COMMENTS_PREPARATION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@STEP_CODE", "04");
                                cmd.Parameters.AddWithValue("@PREPARATION", "Finish");
                                if (Constaint.MoldType == "Connector")
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing");
                                    if (ProductType == "Assy")
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing");
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing");
                                    }
                                    else
                                    {
                                        if (ProductType == "Unit")
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_ASSY", "NA");
                                            cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_ASSY", "NA");
                                            cmd.Parameters.AddWithValue("@TRIAL_PK", "NA");
                                        }
                                    }
                                    cmd.Parameters.AddWithValue("@TRIAL_MP", "NA");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_IM", "NA");
                                    cmd.Parameters.AddWithValue("@TRIAL_ASSY", "NA");
                                    cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing");
                                    cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing");
                                }
                                cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION", "Processing");
                                cmd.Parameters.AddWithValue("@APPROVED_PREPARATION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_APPROVED_PREPARATION", DateTime.Now);
                                cmd.Parameters.AddWithValue("@COMMENTS_PREPARATION", txtComments.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //lưu tên bộ phận chưa nhập đủ thông tin 
                        //IM
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
                                        if (string.IsNullOrEmpty(DueDateTrial))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain1.Substring(2));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain1.Substring(2) + "-" + DueDateTrial);
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(DueDateTrial))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing-" + DueDateTrial);
                                        }
                                    }
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        //ASSY
                        {
                            string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                            DataTable Data = DBUtils._getData(queryData);
                            string Status = Convert.ToString(Data.Rows[0]["TRIAL_ASSY"]);
                            if (!Status.Contains("NA"))
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
                                            if (string.IsNullOrEmpty(DueDateTrial))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain2.Substring(2));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain2.Substring(2) + "-" + DueDateTrial);
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(DueDateTrial))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing-" + DueDateTrial);
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
                            if (!Status.Contains("NA"))
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
                                            if (string.IsNullOrEmpty(DueDateTrial))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain3.Substring(2));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain3.Substring(2) + "-" + DueDateTrial);
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(DueDateTrial))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing-" + DueDateTrial);
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        //MP
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
                                        if (string.IsNullOrEmpty(DueDateTrial))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain4.Substring(2));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain4.Substring(2) + "-" + DueDateTrial);
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(DueDateTrial))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing-" + DueDateTrial);
                                        }
                                    }
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        MessageBox.Show("Phê duyệt thành công.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_PREPARATION_Load(sender, e);
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
                        string queryUpdateDueDate = "UPDATE TBL_NEW_MOLD_MST SET DUE_DATE_PREPARATION = @DUE_DATE_PREPARATION WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateDueDate, conn))
                            {
                                cmd.Parameters.AddWithValue("@DUE_DATE_PREPARATION", Convert.ToDateTime(txtDueDate.Text));
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
                            string queryItems = "UPDATE TBL_PREPARATION SET STATUS = @STATUS WHERE ID_IDENTITY = @ID_IDENTITY";
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
                        string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                        DataTable Data = DBUtils._getData(queryData);
                        string Status = Convert.ToString(Data.Rows[0]["PREPARATION"]);
                        if (!Status.Contains("Finish"))
                        {
                            //Lưu bộ phận chưa nhập đủ thông tin
                            string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS PREPARATION FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_PREPARATION WHERE CONTROL_NO = '" + ControlNo + "' AND STATUS_DELETE = '0' AND (PLAN_START is null or PLAN_COMPLETE is null or  ACTUAL_START is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0) GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                            DataTable dataSection = DBUtils._getData(queryDataSection);
                            string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET PREPARATION = @PREPARATION WHERE CONTROL_NO = '" + ControlNo + "'";
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
                                            cmd.Parameters.AddWithValue("@PREPARATION", Convert.ToString(dataSection.Rows[0]["PREPARATION"]));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", Convert.ToString(dataSection.Rows[0]["PREPARATION"]) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(txtDueDate.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
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
                //if (e.Column.FieldName == "PLAN_START" || e.Column.FieldName == "PLAN_COMPLETE" || e.Column.FieldName == "ACTUAL_START" || e.Column.FieldName == "ACTUAL_COMPLETE")
                //{
                //    string PlanStart = "";
                //    string PlanComplete = "";
                //    string ActualStart = "";
                //    string ActualComplete = "";
                //    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[4]) != DBNull.Value)
                //    {
                //        PlanStart = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns[4]));
                //    }
                //    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[5]) != DBNull.Value)
                //    {
                //        PlanComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns[5]));
                //    }
                //    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[6]) != DBNull.Value)
                //    {
                //        ActualStart = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns[6]));
                //    }
                //    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns[7]) != DBNull.Value)
                //    {
                //        ActualComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns[7]));
                //    }

                //    if (!string.IsNullOrEmpty(PlanStart) && !string.IsNullOrEmpty(PlanComplete) && string.IsNullOrEmpty(ActualStart) || string.IsNullOrEmpty(ActualComplete))
                //    {
                //        gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Plan");
                //    }
                //    if (!string.IsNullOrEmpty(ActualStart) && !string.IsNullOrEmpty(ActualComplete))
                //    {
                //        DateTime DateActualComplete = Convert.ToDateTime(ActualComplete);
                //        DateTime DueDate = Convert.ToDateTime(txtDueDate.Text);
                //        TimeSpan time = DueDate - DateActualComplete;
                //        if (time.Days < 0)
                //        {
                //            gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Delay");
                //        }
                //        else
                //        {
                //            gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "OK");
                //        }
                //    }
                //    if (!string.IsNullOrEmpty(PlanStart) && !string.IsNullOrEmpty(PlanComplete) && !string.IsNullOrEmpty(ActualStart) && string.IsNullOrEmpty(ActualComplete))
                //    {
                //        gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Processing");
                //    }
                //    if (string.IsNullOrEmpty(PlanStart) || string.IsNullOrEmpty(PlanComplete))
                //    {
                //        gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Not yet");
                //    }
                //}
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

        private void gcData_Click(object sender, EventArgs e)
        {

        }

        private void gvData_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //    if (e.Column.FieldName == "PLAN_START" || e.Column.FieldName == "PLAN_COMPLETE" || e.Column.FieldName == "ACTUAL_START" || e.Column.FieldName == "ACTUAL_COMPLETE")
            //    {
            //        string PlanStart = "";
            //        string PlanComplete = "";
            //        string ActualStart = "";
            //        string ActualComplete = "";
            //        if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PLAN_START"]) != DBNull.Value)
            //        {
            //            PlanStart = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PLAN_START"]));
            //        }
            //        if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PLAN_COMPLETE"]) != DBNull.Value)
            //        {
            //            PlanComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PLAN_COMPLETE"]));
            //        }
            //        if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ACTUAL_START"]) != DBNull.Value)
            //        {
            //            ActualStart = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ACTUAL_START"]));
            //        }
            //        if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ACTUAL_COMPLETE"]) != DBNull.Value)
            //        {
            //            ActualComplete = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ACTUAL_COMPLETE"]));
            //        }

            //        if (!string.IsNullOrEmpty(PlanStart) && !string.IsNullOrEmpty(PlanComplete) && string.IsNullOrEmpty(ActualStart) || string.IsNullOrEmpty(ActualComplete))
            //        {
            //            gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Plan");
            //        }
            //        if (!string.IsNullOrEmpty(ActualStart) && !string.IsNullOrEmpty(ActualComplete) && !string.IsNullOrEmpty(txtDueDate.Text))
            //        {
            //            DateTime DateActualComplete = Convert.ToDateTime(ActualComplete);
            //            DateTime DueDate = Convert.ToDateTime(txtDueDate.Text);
            //            TimeSpan time = DueDate - DateActualComplete;
            //            if (time.Days < 0)
            //            {
            //                gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Delay");
            //            }
            //            else
            //            {
            //                gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "OK");
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(PlanStart) && !string.IsNullOrEmpty(PlanComplete) && !string.IsNullOrEmpty(ActualStart) && string.IsNullOrEmpty(ActualComplete))
            //        {
            //            gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Processing");
            //        }
            //        if (string.IsNullOrEmpty(PlanStart) || string.IsNullOrEmpty(PlanComplete))
            //        {
            //            gvData.SetRowCellValue(e.RowHandle, gvData.Columns["STATUS"], "Not yet");
            //        }
            //    }
        }
    }
}