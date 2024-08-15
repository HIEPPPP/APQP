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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace APQP.FORM._05_TRIAL_PRODUCTION
{
    public partial class FRM_TRIAL_CONFIRMATION : DevExpress.XtraEditors.XtraForm
    {
        public FRM_TRIAL_CONFIRMATION(string ControlNo)
        {
            this.ControlNo = ControlNo;
            InitializeComponent();
        }
        string ControlNo;
        private void FRM_TRIAL_CONFIRMATION_Load(object sender, EventArgs e)
        {
            label1.Text = "TRIAL CONFIRMATION (" + ControlNo + ")";
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
            string QueryDataJudgement = "SELECT JUDGEMENT FROM TBL_JUDGEMENT";
            DataTable DataJudgement = DBUtils._getData(QueryDataJudgement);
            rpDataJudgement.DataSource = DataJudgement;
            rpDataJudgement.ValueMember = "JUDGEMENT";
            rpDataJudgement.DisplayMember = "JUDGEMENT";
            rpJudgement2.DataSource = DataJudgement;
            rpJudgement2.ValueMember = "JUDGEMENT";
            rpJudgement2.DisplayMember = "JUDGEMENT";
        }
        DateTime DTDueDate;
        string DueDate = string.Empty;
        DateTime DTDueDateMassProduction;
        string DueDateMassProduction;
        private void LoadData()
        {
            try
            {
                string queryDataOther = "SELECT * FROM TBL_OTHER_EVALUATION WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable DataOther = DBUtils._getData(queryDataOther);
                gcDataOther.DataSource = DataOther;
                string queryDataOtherValuable = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable DataOtherValuable = DBUtils._getData(queryDataOtherValuable);
                gcDataOtherCycaltime.DataSource = DataOtherValuable;
                //Load Data Approved
                string queryDataApproved = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                DataTable DataApproved = DBUtils._getData(queryDataApproved);
                if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUA_DATE_MASS_PRODUCTION"])))
                {
                    DTDueDateMassProduction = Convert.ToDateTime(DataApproved.Rows[0]["DUA_DATE_MASS_PRODUCTION"].ToString());
                    DueDateMassProduction = DTDueDateMassProduction.ToString("dd/MMM");
                }
                DateTime DateChecked;
                DateTime DateApproved;
                
                if (DataApproved.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECK_TRIAL_CONFIRMATION"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECK_TRIAL_CONFIRMATION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_CONFIRMATION"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECKED_TRIAL_CONFIRMATION"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_TRIAL_CONFIRMATION"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_TRIAL_CONFIRMATION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_CONFIRMATION"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_TRIAL_CONFIRMATION"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_TRIAL_CONFIRMATION"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_TRIAL_CONFIRMATION"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"])))
                    {
                        DTDueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"].ToString());
                        DueDate = DTDueDate.ToString("dd/MMM");
                        txtDueDate.EditValue = DTDueDate;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
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
                    }
                    if (Constaint._access == "01")
                    {
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
                    }
                    //Lưu bộ phận chưa nhập đủ thông tin
                    string queryStatus = "SELECT TRIAL_CONFIRMATION FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                    DataTable dataStatus = DBUtils._getData(queryStatus);
                    string status = Convert.ToString(dataStatus.Rows[0]["TRIAL_CONFIRMATION"]);
                    if (!status.Contains("Finish"))
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
                                        if (string.IsNullOrEmpty(DueDate))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2) + "-" + DueDate);
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(DueDate))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing-" + DueDate);
                                        }
                                    }
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

        private void btnSave2_Click(object sender, EventArgs e)
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
                        //Update TBL_OTHER_VALUABLE_EVALUATION
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
                        //Update TBL_OTHER_VALUABLE_EVALUATION
                        for (int i = 0; i < gvDataOtherCycaltime.RowCount; i++)
                        {
                            DataRow row = gvDataOtherCycaltime.GetDataRow(i);
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
                    //Lưu bộ phận chưa nhập đủ thông tin
                    string queryStatus = "SELECT TRIAL_CONFIRMATION FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                    DataTable dataStatus = DBUtils._getData(queryStatus);
                    string status = Convert.ToString(dataStatus.Rows[0]["TRIAL_CONFIRMATION"]);
                    if (!status.Contains("Finish"))
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
                                        if (string.IsNullOrEmpty(DueDate))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2) + "-" + DueDate);
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(DueDate))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing-" + DueDate);
                                        }
                                    }
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

        string _fileCopy = string.Empty;
        string pathPdfFile = string.Empty;
        string fileExtension;
        string fileUpLoad;
        private void btnFile_Click(object sender, EventArgs e)
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
                        //lưu tên bộ phận chưa nhập đủ thông tin
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

        private void btnChecked_Click(object sender, EventArgs e)
        {
            try
            {
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECK_TRIAL_CONFIRMATION = @CHECK_TRIAL_CONFIRMATION, DATE_CHECKED_TRIAL_CONFIRMATION = @DATE_CHECKED_TRIAL_CONFIRMATION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@CHECK_TRIAL_CONFIRMATION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_CHECKED_TRIAL_CONFIRMATION", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Xác nhận đã kiểm tra thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_TRIAL_CONFIRMATION_Load(sender, e);
                    }
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION, MASS_PRODUCTION = @MASS_PRODUCTION, " +
                            "APPROVED_TRIAL_CONFIRMATION = @APPROVED_TRIAL_CONFIRMATION, DATE_APPROVED_TRIAL_CONFIRMATION = @DATE_APPROVED_TRIAL_CONFIRMATION, COMMENTS_TRIAL_CONFIRMATION = @COMMENTS_TRIAL_CONFIRMATION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@STEP_CODE", "06");
                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Finish");
                                cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing");
                                cmd.Parameters.AddWithValue("@APPROVED_TRIAL_CONFIRMATION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_APPROVED_TRIAL_CONFIRMATION", DateTime.Now);
                                cmd.Parameters.AddWithValue("@COMMENTS_TRIAL_CONFIRMATION", txtComments.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
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
                                    if (string.IsNullOrEmpty(DueDateMassProduction))
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", Convert.ToString(dataSection.Rows[0]["MASS_PRODUCTION"]));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", Convert.ToString(dataSection.Rows[0]["MASS_PRODUCTION"]) + "-" + DueDateMassProduction);
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDateMassProduction))
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing-" + DueDateMassProduction);
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Phê duyệt thành công.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_TRIAL_CONFIRMATION_Load(sender, e);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}