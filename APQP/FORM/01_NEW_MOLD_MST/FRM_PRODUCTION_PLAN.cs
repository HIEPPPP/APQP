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
using System.Runtime.InteropServices;

namespace APQP.FORM._01_NEW_MOLD_MST
{
    public partial class FRM_PRODUCTION_PLAN : DevExpress.XtraEditors.XtraForm
    {
        public FRM_PRODUCTION_PLAN()
        {
            InitializeComponent();
        }

        private void FRM_PRODUCTION_PLAN_Load(object sender, EventArgs e)
        {
            lbMoldType.Text = "Production plan (" + Constaint.MoldType + ")";
            if (Constaint._access == "01")
            {
                gvData.Columns["TRIAL_PRODUCTION_IM_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["IM_VISUAL_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["IM_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_ASSY_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["ASSY_VISUAL_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["ASSY_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_MP_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["MP_VISUAL_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["MP_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["PACKING_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_IM_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["IM_VISUAL_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["IM_FUNCTION_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_ASSY_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["ASSY_VISUAL_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["ASSY_FUNCTION_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_MP_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["MP_VISUAL_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["MP_FUNCTION_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["PACKING_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["PRODUCTION_STATUS"].OptionsColumn.ReadOnly = false;
                gvData.Columns["NOTE"].OptionsColumn.ReadOnly = false;
                btnImport.Enabled = true;
            }
            if (Constaint._sectionShort == "PC")
            {
                btnImport.Enabled = true;
                gvData.Columns["TRIAL_PRODUCTION_IM_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["IM_VISUAL_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["IM_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_ASSY_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["ASSY_VISUAL_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["ASSY_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_MP_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["MP_VISUAL_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["MP_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["PACKING_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["PRODUCTION_STATUS"].OptionsColumn.ReadOnly = false;
                gvData.Columns["NOTE"].OptionsColumn.ReadOnly = false;
            }
            if (Constaint._sectionShort == "IM")
            {
                //gvData.Columns["TRIAL_PRODUCTION_IM_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_IM_ACTUAL"].OptionsColumn.ReadOnly = false;
            }
            if (Constaint._sectionShort == "ASSY")
            {
                //gvData.Columns["TRIAL_PRODUCTION_ASSY_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_ASSY_ACTUAL"].OptionsColumn.ReadOnly = false;
            }
            if (Constaint._sectionShort.Contains("MP"))
            {
                //gvData.Columns["TRIAL_PRODUCTION_MP_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["TRIAL_PRODUCTION_MP_ACTUAL"].OptionsColumn.ReadOnly = false;
            }
            if (Constaint._sectionShort == "PK" || Constaint._sectionShort.Contains("MP"))
            {
                //gvData.Columns["PACKING_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["PACKING_ACTUAL"].OptionsColumn.ReadOnly = false;
            }
            if (Constaint._sectionShort == "PV")
            {
                //gvData.Columns["IM_VISUAL_PLAN"].OptionsColumn.ReadOnly = false;
                //gvData.Columns["ASSY_VISUAL_PLAN"].OptionsColumn.ReadOnly = false;
                //gvData.Columns["MP_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["IM_VISUAL_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["ASSY_VISUAL_ACTUAL"].OptionsColumn.ReadOnly = false;
                //gvData.Columns["MP_FUNCTION_ACTUAL"].OptionsColumn.ReadOnly = false;
            }
            if (Constaint._sectionShort == "QA")
            {

                //gvData.Columns["IM_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                //gvData.Columns["ASSY_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                //gvData.Columns["MP_FUNCTION_PLAN"].OptionsColumn.ReadOnly = false;
                gvData.Columns["PRODUCTION_STATUS"].OptionsColumn.ReadOnly = false;
                gvData.Columns["NOTE"].OptionsColumn.ReadOnly = false;
                gvData.Columns["IM_FUNCTION_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["ASSY_FUNCTION_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["MP_FUNCTION_ACTUAL"].OptionsColumn.ReadOnly = false;
                gvData.Columns["MP_VISUAL_ACTUAL"].OptionsColumn.ReadOnly = false;
            }
            if (Constaint.MoldType == "Connector")
            {
                gridBand5.Visible = false;
            }
            else
            {
                gridBand1.Visible = false;
                gridBand4.Visible = false;
            }

            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND STEP_CODE != '07' AND STATUS_DELETE = '0' ORDER BY CONTROL_NO ASC";
                DataTable Data = DBUtils._getData(queryData);
                gcData.DataSource = Data;
                string queryDataSatus = "SELECT ID, STATUS FROM TBL_PRODUCTION_STATUS_MST";
                DataTable DataStatus = DBUtils._getData(queryDataSatus);
                rptStatus.DataSource = DataStatus;
                rptStatus.DisplayMember = "STATUS";
                rptStatus.ValueMember = "ID";
                string queryActualStatus = "SELECT ID, STATUS FROM TBL_ACTUAL_STATUS_MST";
                DataTable DataActualStatus = DBUtils._getData(queryActualStatus);
                rptActualStatus.DataSource = DataActualStatus;
                rptActualStatus.DisplayMember = "STATUS";
                rptActualStatus.ValueMember = "STATUS";
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

        private void btnFile_Click_1(object sender, EventArgs e)
        {
            try
            {
                string ControlNo = Convert.ToString(gvData.GetFocusedRowCellValue("CONTROL_NO"));
                int y = gvData.FocusedRowHandle;
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
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
                        gvData.SetRowCellValue(y, gvData.Columns["FILE_PRODUCTION_PLAN"], "PLAN-" + ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + fileExtension));
                        fileUpLoad = Path.Combine(Constaint._folderFileUpload, "PLAN-" + ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + fileExtension));
                        File.Copy(pathPdfFile, fileUpLoad, true);
                        string querySaveFile = "UPDATE TBL_NEW_MOLD_MST SET FILE_PRODUCTION_PLAN = @FILE_PRODUCTION_PLAN WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(querySaveFile, _conn))
                            {
                                cmd.Parameters.AddWithValue("FILE_PRODUCTION_PLAN", "PLAN-" + ControlNo + "-" + Convert.ToString(gvData.GetRowCellValue(y, "ID_IDENTITY") + fileExtension));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Lưu file thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    string ControlNo = Convert.ToString(gvData.GetFocusedRowCellValue("CONTROL_NO"));
                    int y = gvData.FocusedRowHandle;
                    DialogResult = MessageBox.Show("Xác nhận xóa file kế hoạch?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.OK)
                    {
                        gvData.SetRowCellValue(y, gvData.Columns["FILE_PRODUCTION_PLAN"], "");
                        string querySaveFile = "UPDATE TBL_NEW_MOLD_MST SET FILE_PRODUCTION_PLAN = @FILE_PRODUCTION_PLAN WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(querySaveFile, _conn))
                            {
                                cmd.Parameters.AddWithValue("FILE_PRODUCTION_PLAN", "");
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Xóa file thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (colCaption == "File Production Plan")
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(gvData.GetFocusedRowCellValue("FILE_PRODUCTION_PLAN"))))
                        {
                            System.Diagnostics.Process.Start(Constaint._folderFileUpload + gvData.GetFocusedRowCellValue("FILE_PRODUCTION_PLAN").ToString());
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

        private void gvData_RowCountChanged(object sender, EventArgs e)
        {
            txtRecord.Text = Convert.ToString(gvData.RowCount);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int RowIndex = gvData.FocusedRowHandle;
                DateTime TRIAL_PRODUCTION_IM_PLAN;
                DateTime IM_VISUAL_PLAN;
                DateTime IM_FUNCTION_PLAN;
                DateTime TRIAL_PRODUCTION_ASSY_PLAN;
                DateTime ASSY_VISUAL_PLAN;
                DateTime ASSY_FUNCTION_PLAN;
                DateTime TRIAL_PRODUCTION_MP_PLAN;
                DateTime MP_VISUAL_PLAN;
                DateTime MP_FUNCTION_PLAN;
                DateTime PACKING_PLAN;
                DialogResult = MessageBox.Show("Xác nhận lưu thông tin?", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.OK)
                {
                    for (int i = 0; i < gvData.RowCount; i++)
                    {
                        DataRow row = gvData.GetDataRow(i);

                        string querySave = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_PRODUCTION_IM_PLAN = @TRIAL_PRODUCTION_IM_PLAN, IM_VISUAL_PLAN = @IM_VISUAL_PLAN, IM_FUNCTION_PLAN = @IM_FUNCTION_PLAN, TRIAL_PRODUCTION_ASSY_PLAN = @TRIAL_PRODUCTION_ASSY_PLAN, ASSY_VISUAL_PLAN = @ASSY_VISUAL_PLAN, ASSY_FUNCTION_PLAN = @ASSY_FUNCTION_PLAN, TRIAL_PRODUCTION_MP_PLAN = @TRIAL_PRODUCTION_MP_PLAN, MP_VISUAL_PLAN = @MP_VISUAL_PLAN, MP_FUNCTION_PLAN = @MP_FUNCTION_PLAN, PACKING_PLAN = @PACKING_PLAN, " +
                            "TRIAL_PRODUCTION_IM_ACTUAL = @TRIAL_PRODUCTION_IM_ACTUAL, IM_VISUAL_ACTUAL = @IM_VISUAL_ACTUAL, IM_FUNCTION_ACTUAL = @IM_FUNCTION_ACTUAL, TRIAL_PRODUCTION_ASSY_ACTUAL = @TRIAL_PRODUCTION_ASSY_ACTUAL, ASSY_VISUAL_ACTUAL = @ASSY_VISUAL_ACTUAL, ASSY_FUNCTION_ACTUAL = @ASSY_FUNCTION_ACTUAL, TRIAL_PRODUCTION_MP_ACTUAL = @TRIAL_PRODUCTION_MP_ACTUAL, MP_VISUAL_ACTUAL = @MP_VISUAL_ACTUAL, MP_FUNCTION_ACTUAL = @MP_FUNCTION_ACTUAL, PACKING_ACTUAL = @PACKING_ACTUAL, NOTE = @NOTE, PRODUCTION_STATUS = @PRODUCTION_STATUS WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", Convert.ToString(row["CONTROL_NO"]));
                                if (Convert.ToString(row["TRIAL_PRODUCTION_IM_PLAN"]).Length > 9)
                                {
                                    TRIAL_PRODUCTION_IM_PLAN = Convert.ToDateTime(row["TRIAL_PRODUCTION_IM_PLAN"]);
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_IM_PLAN", Convert.ToString(TRIAL_PRODUCTION_IM_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_IM_PLAN", Convert.ToString(row["TRIAL_PRODUCTION_IM_PLAN"]));
                                }
                                if (Convert.ToString(row["IM_VISUAL_PLAN"]).Length > 9)
                                {
                                    IM_VISUAL_PLAN = Convert.ToDateTime(row["IM_VISUAL_PLAN"]);
                                    cmd.Parameters.AddWithValue("@IM_VISUAL_PLAN", Convert.ToString(IM_VISUAL_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@IM_VISUAL_PLAN", Convert.ToString(row["IM_VISUAL_PLAN"]));
                                }
                                if (Convert.ToString(row["IM_FUNCTION_PLAN"]).Length > 9)
                                {
                                    IM_FUNCTION_PLAN = Convert.ToDateTime(row["IM_FUNCTION_PLAN"]);
                                    cmd.Parameters.AddWithValue("@IM_FUNCTION_PLAN", Convert.ToString(IM_FUNCTION_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@IM_FUNCTION_PLAN", Convert.ToString(row["IM_FUNCTION_PLAN"]));
                                }
                                if (Convert.ToString(row["TRIAL_PRODUCTION_ASSY_PLAN"]).Length > 9)
                                {
                                    TRIAL_PRODUCTION_ASSY_PLAN = Convert.ToDateTime(row["TRIAL_PRODUCTION_ASSY_PLAN"]);
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_PLAN", Convert.ToString(TRIAL_PRODUCTION_ASSY_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_PLAN", Convert.ToString(row["TRIAL_PRODUCTION_ASSY_PLAN"]));
                                }
                                if (Convert.ToString(row["ASSY_VISUAL_PLAN"]).Length > 9)
                                {
                                    ASSY_VISUAL_PLAN = Convert.ToDateTime(row["ASSY_VISUAL_PLAN"]);
                                    cmd.Parameters.AddWithValue("@ASSY_VISUAL_PLAN", Convert.ToString(ASSY_VISUAL_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@ASSY_VISUAL_PLAN", Convert.ToString(row["ASSY_VISUAL_PLAN"]));
                                }
                                if (Convert.ToString(row["ASSY_FUNCTION_PLAN"]).Length > 9)
                                {
                                    ASSY_FUNCTION_PLAN = Convert.ToDateTime(row["ASSY_FUNCTION_PLAN"]);
                                    cmd.Parameters.AddWithValue("@ASSY_FUNCTION_PLAN", Convert.ToString(ASSY_FUNCTION_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@ASSY_FUNCTION_PLAN", Convert.ToString(row["ASSY_FUNCTION_PLAN"]));
                                }
                                if (Convert.ToString(row["TRIAL_PRODUCTION_MP_PLAN"]).Length > 9)
                                {
                                    TRIAL_PRODUCTION_MP_PLAN = Convert.ToDateTime(row["TRIAL_PRODUCTION_MP_PLAN"]);
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_MP_PLAN", Convert.ToString(TRIAL_PRODUCTION_MP_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_MP_PLAN", Convert.ToString(row["TRIAL_PRODUCTION_MP_PLAN"]));
                                }
                                if (Convert.ToString(row["MP_VISUAL_PLAN"]).Length > 9)
                                {
                                    MP_VISUAL_PLAN = Convert.ToDateTime(row["MP_VISUAL_PLAN"]);
                                    cmd.Parameters.AddWithValue("@MP_VISUAL_PLAN", Convert.ToString(MP_VISUAL_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@MP_VISUAL_PLAN", Convert.ToString(row["MP_VISUAL_PLAN"]));
                                }
                                if (Convert.ToString(row["MP_FUNCTION_PLAN"]).Length > 9)
                                {
                                    MP_FUNCTION_PLAN = Convert.ToDateTime(row["MP_FUNCTION_PLAN"]);
                                    cmd.Parameters.AddWithValue("@MP_FUNCTION_PLAN", Convert.ToString(MP_FUNCTION_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@MP_FUNCTION_PLAN", Convert.ToString(row["MP_FUNCTION_PLAN"]));
                                }
                                if (Convert.ToString(row["PACKING_PLAN"]).Length > 9)
                                {
                                    PACKING_PLAN = Convert.ToDateTime(row["PACKING_PLAN"]);
                                    cmd.Parameters.AddWithValue("@PACKING_PLAN", Convert.ToString(PACKING_PLAN.ToString("dd/MMM")));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PACKING_PLAN", Convert.ToString(row["PACKING_PLAN"]));
                                }
                                cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_IM_ACTUAL", Convert.ToString(row["TRIAL_PRODUCTION_IM_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@IM_VISUAL_ACTUAL", Convert.ToString(row["IM_VISUAL_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@IM_FUNCTION_ACTUAL", Convert.ToString(row["IM_FUNCTION_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_ACTUAL", Convert.ToString(row["TRIAL_PRODUCTION_ASSY_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@ASSY_VISUAL_ACTUAL", Convert.ToString(row["ASSY_VISUAL_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@ASSY_FUNCTION_ACTUAL", Convert.ToString(row["ASSY_FUNCTION_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_MP_ACTUAL", Convert.ToString(row["TRIAL_PRODUCTION_MP_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@MP_VISUAL_ACTUAL", Convert.ToString(row["MP_VISUAL_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@MP_FUNCTION_ACTUAL", Convert.ToString(row["MP_FUNCTION_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@PACKING_ACTUAL", Convert.ToString(row["PACKING_ACTUAL"]));
                                cmd.Parameters.AddWithValue("@PRODUCTION_STATUS", Convert.ToString(row["PRODUCTION_STATUS"]));
                                cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Lưu thành công", "Save", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    LoadData();
                    gvData.FocusedRowHandle = RowIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gvData_RowCountChanged_1(object sender, EventArgs e)
        {
            txtRecord.Text = gvData.RowCount.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvData, gcData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                string fileName = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.AddExtension = true;
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileName = openFileDialog.FileNames[0];

                }
                else return;

                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("File không tồn tại!");
                    return;
                }
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlApp.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = null;
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = null;
                Microsoft.Office.Interop.Excel.Range xlRange = null;
                try
                {
                    xlWorkbook = xlApp.Workbooks.Open(fileName);
                    xlWorksheet = xlWorkbook.Sheets[1];
                    xlRange = xlWorksheet.UsedRange;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File đang được sử dụng.");
                    return;
                }

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                if (rowCount == 0 && colCount == 0)
                {
                    MessageBox.Show("File dữ liệu trùng.");
                    return;
                }
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                string PART_NAME = string.Empty;
                string MOLD_NO = string.Empty;
                string TRIAL_PRODUCTION_IM_PLAN = string.Empty;
                string IM_VISUAL_PLAN = string.Empty;
                string IM_FUNCTION_PLAN = string.Empty;
                string TRIAL_PRODUCTION_ASSY_PLAN = string.Empty;
                string ASSY_VISUAL_PLAN = string.Empty;
                string ASSY_FUNCTION_PLAN = string.Empty;
                string TRIAL_PRODUCTION_MP_PLAN = string.Empty;
                string MP_VISUAL_PLAN = string.Empty;
                string MP_FUNCTION_PLAN = string.Empty;
                string PACKING_PLAN = string.Empty;
                progressBar1.Minimum = 2; //Đặt giá trị nhỏ nhất cho ProgressBar
                progressBar1.Maximum = rowCount; //Đặt giá trị lớn nhất cho ProgressBar

                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                {
                    _conn.Open();
                    SqlTransaction sqltran = _conn.BeginTransaction();
                    try
                    {
                        for (int i = 2; i <= rowCount; i++)
                        {
                            {
                                if (Constaint.MoldType == "Connector")
                                {
                                    PART_NAME = (xlRange.Cells[i, 1] != null) ? Convert.ToString(xlRange.Cells[i, 1].Value2) : string.Empty;
                                    MOLD_NO = (xlRange.Cells[i, 2] != null) ? Convert.ToString(xlRange.Cells[i, 2].Value2) : string.Empty;
                                    TRIAL_PRODUCTION_IM_PLAN = (xlRange.Cells[i, 3] != null && xlRange.Cells[i, 3].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 3].Value2) : string.Empty;
                                    IM_VISUAL_PLAN = (xlRange.Cells[i, 4] != null && xlRange.Cells[i, 4].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 4].Value2) : string.Empty;
                                    IM_FUNCTION_PLAN = (xlRange.Cells[i, 5] != null && xlRange.Cells[i, 5].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 5].Value2) : string.Empty;
                                    TRIAL_PRODUCTION_ASSY_PLAN = (xlRange.Cells[i, 6] != null && xlRange.Cells[i, 6].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 6].Value2) : string.Empty;
                                    ASSY_VISUAL_PLAN = (xlRange.Cells[i, 7] != null && xlRange.Cells[i, 7].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 7].Value2) : string.Empty;
                                    ASSY_FUNCTION_PLAN = (xlRange.Cells[i, 8] != null && xlRange.Cells[i, 8].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 8].Value2) : string.Empty;
                                    PACKING_PLAN = (xlRange.Cells[i, 9] != null && xlRange.Cells[i, 9].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 9].Value2) : string.Empty;
                                    if (!string.IsNullOrEmpty(MOLD_NO))
                                    {
                                        string QueryUpdate = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_PRODUCTION_IM_PLAN = @TRIAL_PRODUCTION_IM_PLAN, IM_VISUAL_PLAN = @IM_VISUAL_PLAN, IM_FUNCTION_PLAN = @IM_FUNCTION_PLAN, " +
                                            "TRIAL_PRODUCTION_ASSY_PLAN = @TRIAL_PRODUCTION_ASSY_PLAN, ASSY_VISUAL_PLAN = @ASSY_VISUAL_PLAN, ASSY_FUNCTION_PLAN = @ASSY_FUNCTION_PLAN, PACKING_PLAN = @PACKING_PLAN WHERE MOLD_NO = @MOLD_NO AND PART_NAME = @PART_NAME";
                                        SqlCommand cmd = new SqlCommand(QueryUpdate, _conn, sqltran);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.Add("@PART_NAME", SqlDbType.NVarChar).Value = PART_NAME;
                                        cmd.Parameters.Add("@MOLD_NO", SqlDbType.NVarChar).Value = MOLD_NO;
                                        if (!string.IsNullOrEmpty(TRIAL_PRODUCTION_IM_PLAN))
                                            cmd.Parameters.Add("@TRIAL_PRODUCTION_IM_PLAN", SqlDbType.NVarChar).Value = TRIAL_PRODUCTION_IM_PLAN;
                                        else
                                            cmd.Parameters.Add("@TRIAL_PRODUCTION_IM_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(IM_VISUAL_PLAN))
                                            cmd.Parameters.Add("@IM_VISUAL_PLAN", SqlDbType.NVarChar).Value = IM_VISUAL_PLAN;
                                        else
                                            cmd.Parameters.Add("@IM_VISUAL_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(IM_FUNCTION_PLAN))
                                            cmd.Parameters.Add("@IM_FUNCTION_PLAN", SqlDbType.NVarChar).Value = IM_FUNCTION_PLAN;
                                        else
                                            cmd.Parameters.Add("@IM_FUNCTION_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(TRIAL_PRODUCTION_ASSY_PLAN))
                                            cmd.Parameters.Add("@TRIAL_PRODUCTION_ASSY_PLAN", SqlDbType.NVarChar).Value = TRIAL_PRODUCTION_ASSY_PLAN;
                                        else
                                            cmd.Parameters.Add("@TRIAL_PRODUCTION_ASSY_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(ASSY_VISUAL_PLAN))
                                            cmd.Parameters.Add("@ASSY_VISUAL_PLAN", SqlDbType.NVarChar).Value = ASSY_VISUAL_PLAN;
                                        else
                                            cmd.Parameters.Add("@ASSY_VISUAL_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(ASSY_FUNCTION_PLAN))
                                            cmd.Parameters.Add("@ASSY_FUNCTION_PLAN", SqlDbType.NVarChar).Value = ASSY_FUNCTION_PLAN;
                                        else
                                            cmd.Parameters.Add("@ASSY_FUNCTION_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(PACKING_PLAN))
                                            cmd.Parameters.Add("@PACKING_PLAN", SqlDbType.NVarChar).Value = PACKING_PLAN;
                                        else
                                            cmd.Parameters.Add("@PACKING_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    PART_NAME = (xlRange.Cells[i, 1] != null) ? Convert.ToString(xlRange.Cells[i, 1].Value2) : string.Empty;
                                    MOLD_NO = (xlRange.Cells[i, 2] != null) ? Convert.ToString(xlRange.Cells[i, 2].Value2) : string.Empty;
                                    TRIAL_PRODUCTION_MP_PLAN = (xlRange.Cells[i, 3] != null && xlRange.Cells[i, 3].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 3].Value2) : string.Empty;
                                    MP_VISUAL_PLAN = (xlRange.Cells[i, 4] != null && xlRange.Cells[i, 4].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 4].Value2) : string.Empty;
                                    MP_FUNCTION_PLAN = (xlRange.Cells[i, 5] != null && xlRange.Cells[i, 5].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 5].Value2) : string.Empty;
                                    PACKING_PLAN = (xlRange.Cells[i, 6] != null && xlRange.Cells[i, 6].Value2 != null) ? Convert.ToString(xlRange.Cells[i, 6].Value2) : string.Empty;
                                    if (!string.IsNullOrEmpty(MOLD_NO))
                                    {
                                        string QueryUpdate = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_PRODUCTION_MP_PLAN = @TRIAL_PRODUCTION_MP_PLAN, MP_VISUAL_PLAN = @MP_VISUAL_PLAN, MP_FUNCTION_PLAN = @MP_FUNCTION_PLAN, PACKING_PLAN = @PACKING_PLAN WHERE MOLD_NO = @MOLD_NO AND PART_NAME = @PART_NAME";
                                        SqlCommand cmd = new SqlCommand(QueryUpdate, _conn, sqltran);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.Add("@PART_NAME", SqlDbType.NVarChar).Value = PART_NAME;
                                        cmd.Parameters.Add("@MOLD_NO", SqlDbType.NVarChar).Value = MOLD_NO;
                                        if (!string.IsNullOrEmpty(TRIAL_PRODUCTION_MP_PLAN))
                                            cmd.Parameters.Add("@TRIAL_PRODUCTION_MP_PLAN", SqlDbType.NVarChar).Value = TRIAL_PRODUCTION_MP_PLAN;
                                        else
                                            cmd.Parameters.Add("@MP_VISUAL_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(MP_VISUAL_PLAN))
                                            cmd.Parameters.Add("@MP_VISUAL_PLAN", SqlDbType.NVarChar).Value = MP_VISUAL_PLAN;
                                        else
                                            cmd.Parameters.Add("@MP_VISUAL_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(MP_FUNCTION_PLAN))
                                            cmd.Parameters.Add("@MP_FUNCTION_PLAN", SqlDbType.DateTime).Value = DateTime.FromOADate(Convert.ToDouble(MP_FUNCTION_PLAN)).ToString();
                                        else
                                            cmd.Parameters.Add("@MP_FUNCTION_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        if (!string.IsNullOrEmpty(PACKING_PLAN))
                                            cmd.Parameters.Add("@PACKING_PLAN", SqlDbType.NVarChar).Value = PACKING_PLAN;
                                        else
                                            cmd.Parameters.Add("@PACKING_PLAN", SqlDbType.NVarChar).Value = DBNull.Value;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            progressBar1.Value = i;
                        }
                        sqltran.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqltran.Rollback();
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    MessageBox.Show("Upload thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Visible = false;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(ex.ToString());
            }
        }

        private void gvData_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                DateTime Now = DateTime.Now;
                GridView view = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string IMPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_IM_PLAN"]));
                    string IMActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_IM_ACTUAL"]));
                    string IMVisualPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["IM_VISUAL_PLAN"]));
                    string IMVisualActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["IM_VISUAL_ACTUAL"]));
                    string IMFunctionPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["IM_FUNCTION_PLAN"]));
                    string IMFunctionActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["IM_FUNCTION_ACTUAL"]));
                    string ASSYPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_ASSY_PLAN"]));
                    string ASSYActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_ASSY_ACTUAL"]));
                    string ASSYVisualPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_VISUAL_PLAN"]));
                    string ASSYVisualActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_VISUAL_ACTUAL"]));
                    string ASSYFunctionPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_FUNCTION_PLAN"]));
                    string ASSYFunctionActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_FUNCTION_ACTUAL"]));
                    string MPPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_MP_PLAN"]));
                    string MPActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_MP_ACTUAL"]));
                    string MPVisualPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MP_VISUAL_PLAN"]));
                    string MPVisualActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MP_VISUAL_ACTUAL"]));
                    string MPFunctionPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MP_FUNCTION_PLAN"]));
                    string MPFunctionActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MP_FUNCTION_ACTUAL"]));
                    string PKPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PACKING_PLAN"]));
                    string PKActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PACKING_ACTUAL"]));
                    if (!string.IsNullOrEmpty(IMPlan) && IMPlan != "<Null>" && string.IsNullOrEmpty(IMActual))
                    {
                        DateTime Datelan = Convert.ToDateTime(IMPlan);
                        TimeSpan time = Datelan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "TRIAL_PRODUCTION_IM_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "TRIAL_PRODUCTION_IM_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(IMVisualPlan) && IMVisualPlan != "<Null>" && string.IsNullOrEmpty(IMVisualActual))
                    {
                        DateTime Datelan = Convert.ToDateTime(IMVisualPlan);
                        TimeSpan time = Datelan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "IM_VISUAL_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "IM_VISUAL_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(IMFunctionPlan) && IMFunctionPlan != "<Null>" && string.IsNullOrEmpty(IMFunctionActual))
                    {
                        DateTime Datelan = Convert.ToDateTime(IMFunctionPlan);
                        TimeSpan time = Datelan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "IM_FUNCTION_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "IM_FUNCTION_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(ASSYPlan) && ASSYPlan != "<Null>" && ASSYPlan != "N/A" && string.IsNullOrEmpty(ASSYActual))
                    {
                        DateTime DASSYPlan = Convert.ToDateTime(ASSYPlan);
                        TimeSpan time = DASSYPlan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "TRIAL_PRODUCTION_ASSY_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "TRIAL_PRODUCTION_ASSY_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(ASSYVisualPlan) && ASSYPlan != "<Null>" && ASSYVisualPlan != "N/A" && string.IsNullOrEmpty(ASSYVisualActual))
                    {
                        DateTime DASSYPlan = Convert.ToDateTime(ASSYVisualPlan);
                        TimeSpan time = DASSYPlan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "ASSY_VISUAL_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "ASSY_VISUAL_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(ASSYFunctionPlan) && ASSYPlan != "<Null>" && ASSYFunctionPlan != "N/A" && string.IsNullOrEmpty(ASSYVisualActual))
                    {
                        DateTime DASSYPlan = Convert.ToDateTime(ASSYFunctionPlan);
                        TimeSpan time = DASSYPlan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "ASSY_FUNCTION_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "ASSY_FUNCTION_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(MPPlan) && ASSYPlan != "<Null>" && MPPlan != "N/A" && string.IsNullOrEmpty(MPActual))
                    {
                        DateTime DASSYPlan = Convert.ToDateTime(MPPlan);
                        TimeSpan time = DASSYPlan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "TRIAL_PRODUCTION_MP_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "TRIAL_PRODUCTION_MP_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(MPVisualPlan) && ASSYPlan != "<Null>" && MPVisualPlan != "N/A" && string.IsNullOrEmpty(MPVisualActual))
                    {
                        DateTime DASSYPlan = Convert.ToDateTime(MPVisualPlan);
                        TimeSpan time = DASSYPlan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "MP_VISUAL_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "MP_VISUAL_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(MPFunctionPlan) && ASSYPlan != "<Null>" && MPFunctionPlan != "N/A" && string.IsNullOrEmpty(MPFunctionActual))
                    {
                        DateTime DASSYPlan = Convert.ToDateTime(MPFunctionPlan);
                        TimeSpan time = DASSYPlan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "MP_FUNCTION_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "MP_FUNCTION_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(PKPlan) && ASSYPlan != "<Null>" && PKPlan != "N/A" && string.IsNullOrEmpty(PKActual))
                    {
                        DateTime DASSYPlan = Convert.ToDateTime(PKPlan);
                        TimeSpan time = DASSYPlan - Now;
                        if (time.Days < 0)
                        {
                            if (e.Column.FieldName == "PACKING_PLAN")
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                        if (time.Days >= 0 && time.Days < 3)
                        {
                            if (e.Column.FieldName == "PACKING_PLAN")
                            {
                                e.Appearance.BackColor = Color.Orange;
                            }
                        }
                    }
                    if (ASSYPlan == "N/A")
                    {
                        if (e.Column.FieldName == "TRIAL_PRODUCTION_ASSY_PLAN")
                        {
                            e.Appearance.BackColor = Color.LightGray;
                        }
                    }


                    if (ASSYVisualPlan == "N/A")
                    {
                        if (e.Column.FieldName == "ASSY_VISUAL_PLAN")
                        {
                            e.Appearance.BackColor = Color.LightGray;
                        }
                    }
                    if (ASSYFunctionPlan == "N/A")
                    {
                        if (e.Column.FieldName == "ASSY_FUNCTION_PLAN")
                        {
                            e.Appearance.BackColor = Color.LightGray;
                        }
                    }
                    if (ASSYActual == "N/A")
                    {
                        if (e.Column.FieldName == "TRIAL_PRODUCTION_ASSY_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.LightGray;
                        }
                    }
                    if (ASSYActual.Contains("OK") || ASSYActual.Contains("ok") || ASSYActual.Contains("Ok") || ASSYActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "TRIAL_PRODUCTION_ASSY_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (ASSYActual.Contains("NG") || ASSYActual.Contains("ng") || ASSYActual.Contains("Ng") || ASSYActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "TRIAL_PRODUCTION_ASSY_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    string VisualASSYActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_VISUAL_ACTUAL"]));
                    if (VisualASSYActual == "N/A")
                    {
                        if (e.Column.FieldName == "ASSY_VISUAL_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.LightGray;
                        }
                    }
                    if (VisualASSYActual.Contains("OK") || VisualASSYActual.Contains("ok") || VisualASSYActual.Contains("Ok") || VisualASSYActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "ASSY_VISUAL_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (VisualASSYActual.Contains("NG") || VisualASSYActual.Contains("ng") || VisualASSYActual.Contains("Ng") || VisualASSYActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "ASSY_VISUAL_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    if (ASSYFunctionActual == "N/A")
                    {
                        if (e.Column.FieldName == "ASSY_FUNCTION_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.LightGray;
                        }
                    }
                    if (ASSYFunctionActual.Contains("OK") || ASSYFunctionActual.Contains("ok") || ASSYFunctionActual.Contains("Ok") || ASSYFunctionActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "ASSY_FUNCTION_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (ASSYFunctionActual.Contains("NG") || ASSYFunctionActual.Contains("ng") || ASSYFunctionActual.Contains("Ng") || ASSYFunctionActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "ASSY_FUNCTION_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    string IMPActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_IM_ACTUAL"]));
                    if (IMPActual.Contains("OK") || IMPActual.Contains("ok") || IMPActual.Contains("Ok") || IMPActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "TRIAL_PRODUCTION_IM_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (IMPActual.Contains("NG") || IMPActual.Contains("ng") || IMPActual.Contains("Ng") || IMPActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "TRIAL_PRODUCTION_IM_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    if (IMVisualActual.Contains("OK") || IMVisualActual.Contains("ok") || IMVisualActual.Contains("Ok") || IMVisualActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "IM_VISUAL_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (IMVisualActual.Contains("NG") || IMVisualActual.Contains("ng") || IMVisualActual.Contains("Ng") || IMVisualActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "IM_VISUAL_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    if (IMFunctionActual.Contains("OK") || IMFunctionActual.Contains("ok") || IMFunctionActual.Contains("Ok") || IMFunctionActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "IM_FUNCTION_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (IMFunctionActual.Contains("NG") || IMFunctionActual.Contains("ng") || IMFunctionActual.Contains("Ng") || IMFunctionActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "IM_FUNCTION_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    if (MPActual.Contains("OK") || MPActual.Contains("ok") || MPActual.Contains("Ok") || MPActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "TRIAL_PRODUCTION_MP_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (MPActual.Contains("NG") || MPActual.Contains("ng") || MPActual.Contains("Ng") || MPActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "TRIAL_PRODUCTION_MP_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    if (MPVisualActual.Contains("OK") || MPVisualActual.Contains("ok") || MPVisualActual.Contains("Ok") || MPVisualActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "MP_VISUAL_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (MPVisualActual.Contains("NG") || MPVisualActual.Contains("ng") || MPVisualActual.Contains("Ng") || MPVisualActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "MP_VISUAL_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    if (MPFunctionActual.Contains("OK") || MPFunctionActual.Contains("ok") || MPFunctionActual.Contains("Ok") || MPFunctionActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "MP_FUNCTION_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (MPFunctionActual.Contains("NG") || MPFunctionActual.Contains("ng") || MPFunctionActual.Contains("Ng") || MPFunctionActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "MP_FUNCTION_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    if (PKActual.Contains("OK") || PKActual.Contains("ok") || PKActual.Contains("Ok") || PKActual.Contains("oK"))
                    {
                        if (e.Column.FieldName == "PACKING_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (PKActual.Contains("NG") || PKActual.Contains("ng") || PKActual.Contains("Ng") || PKActual.Contains("nG"))
                    {
                        if (e.Column.FieldName == "PACKING_ACTUAL")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                    string Status = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"]));
                    if (Status.Contains("1"))
                    {
                        if (e.Column.FieldName == "PRODUCTION_STATUS")
                        {
                            e.Appearance.BackColor = Color.LightGreen;
                        }
                    }
                    if (Status.Contains("2"))
                    {
                        if (e.Column.FieldName == "PRODUCTION_STATUS")
                        {
                            e.Appearance.BackColor = Color.OrangeRed;
                        }

                    }
                    if (Status.Contains("3"))
                    {
                        if (e.Column.FieldName == "PRODUCTION_STATUS")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void gvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "TRIAL_PRODUCTION_IM_ACTUAL" || e.Column.FieldName == "IM_VISUAL_ACTUAL" || e.Column.FieldName == "IM_FUNCTION_ACTUAL" || e.Column.FieldName == "TRIAL_PRODUCTION_ASSY_ACTUAL" || e.Column.FieldName == "ASSY_VISUAL_ACTUAL" || e.Column.FieldName == "ASSY_FUNCTION_ACTUAL" || e.Column.FieldName == "TRIAL_PRODUCTION_MP_ACTUAL" || e.Column.FieldName == "MP_VISUAL_ACTUAL" || e.Column.FieldName == "MP_FUNCTION_ACTUAL" || e.Column.FieldName == "PACKING_ACTUAL" || e.Column.FieldName == "TRIAL_PRODUCTION_IM_PLAN" || e.Column.FieldName == "IM_VISUAL_PLAN" || e.Column.FieldName == "IM_FUNCTION_PLAN" || e.Column.FieldName == "TRIAL_PRODUCTION_ASSY_PLAN" || e.Column.FieldName == "ASSY_VISUAL_PLAN" || e.Column.FieldName == "ASSY_FUNCTION_PLAN" || e.Column.FieldName == "TRIAL_PRODUCTION_MP_PLAN" || e.Column.FieldName == "MP_VISUAL_PLAN" || e.Column.FieldName == "MP_FUNCTION_PLAN" || e.Column.FieldName == "PACKING_PLAN")
                {
                    string ProductType = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PRODUCT_TYPE"]));
                    string IMActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_IM_ACTUAL"]));
                    string IMVisualActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["IM_VISUAL_ACTUAL"]));
                    string IMFunctionActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["IM_FUNCTION_ACTUAL"]));
                    string ASSYActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_ASSY_ACTUAL"]));
                    string ASSYVisualActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_VISUAL_ACTUAL"]));
                    string ASSYFunctionActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_FUNCTION_ACTUAL"]));
                    string MPActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_MP_ACTUAL"]));
                    string MPVisualActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MP_VISUAL_ACTUAL"]));
                    string MPFunctionActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MP_FUNCTION_ACTUAL"]));
                    string PKActual = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PACKING_ACTUAL"]));
                    string IMPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_IM_PLAN"]));
                    string IMVisualPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["IM_VISUAL_PLAN"]));
                    string IMFunctionPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["IM_FUNCTION_PLAN"]));
                    string ASSYPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_ASSY_PLAN"]));
                    string ASSYVisualPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_VISUAL_PLAN"]));
                    string ASSYFunctionPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["ASSY_FUNCTION_PLAN"]));
                    string MPPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PRODUCTION_MP_PLAN"]));
                    string MPVisualPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MP_VISUAL_PLAN"]));
                    string MPFunctionPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MP_FUNCTION_PLAN"]));
                    string PKPlan = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PACKING_PLAN"]));
                    if (!string.IsNullOrEmpty(Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MOLD_RECEIVE_ACTUAL"]))))
                    {
                        if (Constaint.MoldType == "Connector")
                        {
                            if (ProductType == "Unit")
                            {
                                if (IMActual == "OK" && IMVisualActual == "OK" && IMFunctionActual == "OK" && PKActual == "OK")
                                {
                                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "1");
                                }
                                if (IMActual == "NG" || IMVisualActual == "NG" || IMFunctionActual == "NG" || PKActual == "NG")
                                {
                                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "3");
                                }
                                if ((IMActual != "OK" || IMVisualActual != "OK" || IMFunctionActual != "OK" || PKActual != "OK") && (!string.IsNullOrEmpty(IMPlan) || !string.IsNullOrEmpty(IMVisualPlan) || !string.IsNullOrEmpty(IMFunctionPlan) || !string.IsNullOrEmpty(PKPlan)))
                                {
                                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "3");
                                }
                                if ((string.IsNullOrEmpty(IMPlan) || IMPlan == "<Null>") && (string.IsNullOrEmpty(IMVisualPlan) || IMVisualPlan == "<Null>") && (string.IsNullOrEmpty(IMFunctionPlan) || IMFunctionPlan == "<Null>") && (string.IsNullOrEmpty(PKPlan) || PKPlan == "<Null>") && string.IsNullOrEmpty(IMActual) && string.IsNullOrEmpty(IMVisualActual) && string.IsNullOrEmpty(IMFunctionActual) && string.IsNullOrEmpty(PKActual))
                                {
                                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], DBNull.Value);
                                }
                            }
                            else
                            {
                                if (IMActual == "OK" && IMVisualActual == "OK" && IMFunctionActual == "OK" && ASSYActual == "OK" && ASSYVisualActual == "OK" && ASSYFunctionActual == "OK" && PKActual == "OK")
                                {
                                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "1");
                                }
                                if (IMActual == "NG" || IMVisualActual == "NG" || IMFunctionActual == "NG" || ASSYActual == "NG" || ASSYVisualActual == "NG" || ASSYFunctionActual == "NG" || PKActual == "NG")
                                {
                                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "3");
                                }
                                if ((IMActual != "OK" || IMVisualActual != "OK" || IMFunctionActual != "OK" || ASSYActual != "OK" || ASSYVisualActual != "OK" || ASSYFunctionActual != "OK" || PKActual != "OK") && (!string.IsNullOrEmpty(IMPlan) || !string.IsNullOrEmpty(IMVisualPlan) || !string.IsNullOrEmpty(IMFunctionPlan) || !string.IsNullOrEmpty(ASSYPlan) || !string.IsNullOrEmpty(ASSYVisualPlan) || !string.IsNullOrEmpty(ASSYFunctionPlan) || !string.IsNullOrEmpty(PKPlan)))
                                {
                                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "3");
                                }
                                if ((string.IsNullOrEmpty(IMPlan) || IMPlan == "<Null>") && (string.IsNullOrEmpty(IMVisualPlan) || IMVisualPlan == "<Null>") && (string.IsNullOrEmpty(IMFunctionPlan) || IMFunctionPlan == "<Null>") && (string.IsNullOrEmpty(ASSYPlan) || ASSYPlan == "<Null>") && (string.IsNullOrEmpty(ASSYVisualPlan) || ASSYVisualPlan == "<Null>") && (string.IsNullOrEmpty(ASSYFunctionPlan) || ASSYFunctionPlan == "<Null>") && (string.IsNullOrEmpty(PKPlan) || PKPlan == "<Null>") && string.IsNullOrEmpty(IMActual) && string.IsNullOrEmpty(IMVisualActual) && string.IsNullOrEmpty(IMFunctionActual) && string.IsNullOrEmpty(ASSYActual) && string.IsNullOrEmpty(ASSYVisualActual) && string.IsNullOrEmpty(ASSYFunctionActual) && string.IsNullOrEmpty(PKActual))
                                {
                                    gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], DBNull.Value);
                                }
                            }
                        }
                        else
                        {
                            if (MPActual == "OK" && MPVisualActual == "OK" && MPFunctionActual == "OK" && PKActual == "OK")
                            {
                                gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "1");
                            }
                            if (MPActual == "NG" || MPVisualActual == "NG" || MPFunctionActual == "NG" || PKActual == "NG")
                            {
                                gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "3");
                            }
                            if ((MPActual != "OK" || MPVisualActual != "OK" || MPFunctionActual != "OK" || PKActual != "OK") && (!string.IsNullOrEmpty(MPPlan) || !string.IsNullOrEmpty(MPVisualPlan) || !string.IsNullOrEmpty(MPFunctionPlan) || !string.IsNullOrEmpty(PKPlan)))
                            {
                                gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], "3");
                            }
                            if ((string.IsNullOrEmpty(MPPlan) || MPPlan == "<Null>") && (string.IsNullOrEmpty(MPVisualPlan) || MPVisualPlan == "<Null>") && (string.IsNullOrEmpty(MPFunctionPlan) || MPFunctionPlan == "<Null>") && (string.IsNullOrEmpty(PKPlan) || PKPlan == "<Null>") && string.IsNullOrEmpty(MPActual) && string.IsNullOrEmpty(MPVisualPlan) && string.IsNullOrEmpty(MPVisualActual) && string.IsNullOrEmpty(PKActual))
                            {
                                gvData.SetRowCellValue(e.RowHandle, gvData.Columns["PRODUCTION_STATUS"], DBNull.Value);
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
    }
}