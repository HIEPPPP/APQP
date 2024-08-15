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

namespace APQP.FORM.PRODUCT_INFO
{
    public partial class FRM_PRODUCT_INFO : DevExpress.XtraEditors.XtraForm
    {
        public FRM_PRODUCT_INFO(string ControlNo)
        {
            this.ControlNo = ControlNo;
            InitializeComponent();
        }
        string ControlNo;
        private void FRM_PRODUCT_INFO_Load(object sender, EventArgs e)
        {
            label3.Text = "PRODUCT INFO (" + ControlNo + ")"; 
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
                btnAddRowsBom.Enabled = true;
                btnAddRowsItem.Enabled = true;
                btnDeleteRowsBom.Enabled = true;
                btnDeteleRowsItem.Enabled = true;
            }
            if (Constaint.MoldType == "Terminal")
            {
                gvBom.Columns["UNIT_WEIGHT"].Caption = "Unit weight (g) - MP";
                gvBom.Columns["BLUE_BOX_QTY"].Caption = "Q'ty (pcs/ box) - PC";
                gvBom.Columns["MACHINE_TYPE"].Caption = "Stamping Machine type - MP";
                gvBom.Columns["MOLD_DIMENSION"].Caption = "Mold dimension (H * W * T) - DM";
                gvBom.Columns["PACKING_METHOD"].Caption = "Packing method - MP";
            }
            if (Constaint._access == "01")
            {
                gvBom.Columns["PART_NO_ITEMS"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["PART_NAME_ITEMS"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["CHILD_PART_NO"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["CHILD_PART_NAME"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["USAGE_QTY"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["MATERIAL_GRADE"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["UNIT_WEIGHT"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["BLUE_BOX_QTY"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["MACHINE_TYPE"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["MOLD_DIMENSION"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["PACKING_METHOD"].OptionsColumn.AllowEdit = true;
            }
            if (Constaint._sectionShort == "QA")
            {
                gvBom.Columns["PART_NO_ITEMS"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["PART_NAME_ITEMS"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["CHILD_PART_NO"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["CHILD_PART_NAME"].OptionsColumn.AllowEdit = true;
                gvBom.Columns["USAGE_QTY"].OptionsColumn.AllowEdit = true;
            }
            if (Constaint.MoldType == "Connector")
            {
                if (Constaint._sectionShort == "PC")
                {
                    gvBom.Columns["MATERIAL_GRADE"].OptionsColumn.AllowEdit = true;
                    gvBom.Columns["MACHINE_TYPE"].OptionsColumn.AllowEdit = true;

                }
                if (Constaint._sectionShort == "IM")
                {
                    gvBom.Columns["UNIT_WEIGHT"].OptionsColumn.AllowEdit = true;
                    gvBom.Columns["BLUE_BOX_QTY"].OptionsColumn.AllowEdit = true;
                }
                if (Constaint._sectionShort == "MM")
                {
                    gvBom.Columns["MOLD_DIMENSION"].OptionsColumn.AllowEdit = true;

                }
                if (Constaint._sectionShort == "PK")
                {
                    gvBom.Columns["PACKING_METHOD"].OptionsColumn.AllowEdit = true;

                }
            }
            else
            {
                if (Constaint._sectionShort == "PC")
                {
                    gvBom.Columns["MATERIAL_GRADE"].OptionsColumn.AllowEdit = true;
                    gvBom.Columns["BLUE_BOX_QTY"].OptionsColumn.AllowEdit = true;
                }
                if (Constaint._sectionShort == "MP")
                {
                    gvBom.Columns["UNIT_WEIGHT"].OptionsColumn.AllowEdit = true;
                    gvBom.Columns["PACKING_METHOD"].OptionsColumn.AllowEdit = true;
                    gvBom.Columns["MACHINE_TYPE"].OptionsColumn.AllowEdit = true;
                }
                if (Constaint._sectionShort == "DM")
                {
                    gvBom.Columns["MOLD_DIMENSION"].OptionsColumn.AllowEdit = true;
                }
            }
            GetData();
            LoadData();
        }
        private void GetData()
        {
            try
            {
                string queryItems = "SELECT * FROM TBL_APPLICABLE_ITEMS WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable dataItems = DBUtils._getData(queryItems);
                gcItems.DataSource = dataItems;
                string queryBom = "SELECT * FROM TBL_BOM_INFOMRATION WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable dataBom = DBUtils._getData(queryBom);
                gcBom.DataSource = dataBom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        DateTime DueDate;
        DateTime DueDateFeasibility;
       
        private void LoadData()
        {
            string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
            DataTable Data = DBUtils._getData(queryData);
            if (!string.IsNullOrEmpty(Convert.ToString(Data.Rows[0]["DUE_DATE_FEASIBILITY"])))
            {
                DueDateFeasibility = Convert.ToDateTime(Data.Rows[0]["DUE_DATE_FEASIBILITY"].ToString());
            }
            
            DateTime DateChecked;
            DateTime DateApproved;

            if (Data.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Data.Rows[0]["CHECKED_PRODUCT_INFORMATION"])))
                {
                    txtChecked.Text = Data.Rows[0]["CHECKED_PRODUCT_INFORMATION"].ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Data.Rows[0]["DATE_CHECKED_PRODUCT_INFORMATION"])))
                {
                    DateChecked = Convert.ToDateTime(Data.Rows[0]["DATE_CHECKED_PRODUCT_INFORMATION"].ToString());
                    txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Data.Rows[0]["APPROVED_PRODUCT_INFORMATION"])))
                {
                    txtApproved.Text = Data.Rows[0]["APPROVED_PRODUCT_INFORMATION"].ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Data.Rows[0]["DATE_APPROVED_PRODUCT_INFORMATION"])))
                {
                    DateApproved = Convert.ToDateTime(Data.Rows[0]["DATE_APPROVED_PRODUCT_INFORMATION"].ToString());
                    txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Data.Rows[0]["COMMENTS_PRODUCT_INFORMATION"])))
                {
                    txtComments.Text = Data.Rows[0]["COMMENTS_PRODUCT_INFORMATION"].ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Data.Rows[0]["DUE_DATE_PRODUCT_INFORMATION"])))
                {
                    DueDate = Convert.ToDateTime(Data.Rows[0]["DUE_DATE_PRODUCT_INFORMATION"].ToString());
                    txtDueDate.Text = DueDate.ToString("dd/MM/yyyy");
                }
            }
        }

        private void btnAddRowsItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvItems.AddNewRow();
                gvItems.Focus();
                //gvData.FocusedRowHandle = GridControl.NewItemRowHandle;
                ////gvData.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                gvItems.FocusedColumn = gvItems.Columns[0];
                string queryData = "SELECT TYPE, PRODUCT_TYPE FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable Data = DBUtils._getData(queryData);
                string Type = Convert.ToString(Data.Rows[0]["TYPE"]);
                string ProDucType = Convert.ToString(Data.Rows[0]["PRODUCT_TYPE"]);
                int y = gvItems.FocusedRowHandle;
                gvItems.SetRowCellValue(y, gvItems.Columns["TYPE"], Type);
                gvItems.SetRowCellValue(y, gvItems.Columns["PRODUCT_TYPE"], ProDucType);
                gvItems.ShowEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAddRowsBom_Click(object sender, EventArgs e)
        {
            gvBom.AddNewRow();
            gvBom.Focus();
            //gvData.FocusedRowHandle = GridControl.NewItemRowHandle;
            ////gvData.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gvBom.FocusedColumn = gvBom.Columns[0];
            string PartNo = Convert.ToString(gvBom.GetRowCellValue(0, "PART_NO_ITEMS"));
            string PartName = Convert.ToString(gvBom.GetRowCellValue(0, "PART_NAME_ITEMS"));
            int y = gvBom.FocusedRowHandle;
            gvBom.SetRowCellValue(y, gvBom.Columns["PART_NO_ITEMS"], PartNo);
            gvBom.SetRowCellValue(y, gvBom.Columns["PART_NAME_ITEMS"], PartName);
            gvBom.ShowEditor();
        }

        private void btnDeteleRowsItem_Click(object sender, EventArgs e)
        {
            gvItems.DeleteSelectedRows();
        }

        private void btnDeleteRowsBom_Click(object sender, EventArgs e)
        {
            gvBom.DeleteSelectedRows();
        }
        string fileUpLoad;
        int ID_Entity;
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
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin ban đầu!", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < gvItems.RowCount; i++)
                    {
                        DataRow row = gvItems.GetDataRow(i);
                        if (row.RowState == DataRowState.Added)
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(row["PART_TYPE"])))
                            {
                                MessageBox.Show("Nhập thông tin Part type!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["PART_NO"])))
                            {
                                MessageBox.Show("Nhập thông tin Part No!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["PART_NAME"])))
                            {
                                MessageBox.Show("Nhập thông tin Part name!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["CAVITY_NO"])))
                            {
                                MessageBox.Show("Nhập thông tin Cavity No!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["DESIGN_CHANGE_IN"])))
                            {
                                MessageBox.Show("Nhập thông tin Design change in!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["TYPE"])))
                            {
                                MessageBox.Show("Nhập thông tin Type!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                            {
                                MessageBox.Show("Nhập thông tin file!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["MOLD_NO"])))
                            {
                                MessageBox.Show("Nhập thông tin Mold No!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < gvBom.RowCount; i++)
                    {
                        DataRow row = gvBom.GetDataRow(i);
                        if (row.RowState == DataRowState.Added)
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(row["PART_NO_ITEMS"])))
                            {
                                MessageBox.Show("Nhập thông tin Part No items!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["PART_NAME_ITEMS"])))
                            {
                                MessageBox.Show("Nhập thông tin Part name items!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["CHILD_PART_NO"])))
                            {
                                MessageBox.Show("Nhập thông tin Child Part NO!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["CHILD_PART_NAME"])))
                            {
                                MessageBox.Show("Nhập thông tin Child Part name!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(row["USAGE_QTY"])))
                            {
                                MessageBox.Show("Nhập thông tin Usage qty!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    //delete 
                    if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                    {
                        string queryDeleteItems = "DELETE TBL_APPLICABLE_ITEMS WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryDeleteItems, _conn))
                            {
                                int n = cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    string queryDeleteBom = "DELETE TBL_BOM_INFOMRATION WHERE CONTROL_NO = '" + ControlNo + "'";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryDeleteBom, _conn))
                        {
                            int n = cmd.ExecuteNonQuery();
                        }
                    }
                    string queryDeleteBomValues = "DELETE TBL_INSERT_VALUES_BOM_INFO WHERE CONTROL_NO = '" + ControlNo + "'";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryDeleteBomValues, _conn))
                        {
                            int n = cmd.ExecuteNonQuery();
                        }
                    }
                    if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                    {
                        //Insert TBL_APPLICABlE_ITEMS
                        for (int i = 0; i < gvItems.RowCount; i++)
                        {
                            DataRow row = gvItems.GetDataRow(i);
                            string queryItems = "INSERT INTO TBL_APPLICABLE_ITEMS (CONTROL_NO, PART_TYPE, PART_NO, PART_NAME, CAVITY_NO, PRODUCT_TYPE, DESIGN_CHANGE_IN, TYPE, MOLD_NO, ATTACHED_FILE, FILE_EXTENSION, NOTE, CREATE_AT, CREATE_BY) " +
                                "VALUES (@CONTROL_NO, @PART_TYPE, @PART_NO, @PART_NAME, @CAVITY_NO, @PRODUCT_TYPE, @DESIGN_CHANGE_IN, @TYPE, @MOLD_NO, @ATTACHED_FILE, @FILE_EXTENSION, @NOTE, @CREATE_AT, @CREATE_BY)";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                    cmd.Parameters.AddWithValue("@PART_TYPE", Convert.ToString(row["PART_TYPE"]));
                                    cmd.Parameters.AddWithValue("@PART_NO", Convert.ToString(row["PART_NO"]));
                                    cmd.Parameters.AddWithValue("@PART_NAME", Convert.ToString(row["PART_NAME"]));
                                    cmd.Parameters.AddWithValue("@CAVITY_NO", Convert.ToString(row["CAVITY_NO"]));
                                    cmd.Parameters.AddWithValue("@PRODUCT_TYPE", Convert.ToString(row["PRODUCT_TYPE"]));
                                    cmd.Parameters.AddWithValue("@DESIGN_CHANGE_IN", Convert.ToString(row["DESIGN_CHANGE_IN"]));
                                    cmd.Parameters.AddWithValue("@TYPE", Convert.ToString(row["TYPE"]));
                                    cmd.Parameters.AddWithValue("@MOLD_NO", Convert.ToString(row["MOLD_NO"]));
                                    cmd.Parameters.AddWithValue("@ATTACHED_FILE", ControlNo + "-" + "I");
                                    cmd.Parameters.AddWithValue("@FILE_EXTENSION", Convert.ToString(row["FILE_EXTENSION"]));
                                    cmd.Parameters.AddWithValue("@NOTE", Convert.ToString(row["NOTE"]));
                                    cmd.Parameters.AddWithValue("@CREATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@CREATE_BY", Constaint._userID);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                        }
                    }
                    //Insert TBL_BOM_INFOMRATION
                    for (int i = 0; i < gvBom.RowCount; i++)
                    {
                        string QueryDataSectionBom = "SELECT * FROM TBL_SECTION_BOM WHERE MOLD_TYPE = '" + Constaint.MoldType + "'";
                        DataTable DataSectionBom = DBUtils._getData(QueryDataSectionBom);
                        DataRow row = gvBom.GetDataRow(i);
                        string queryBom = "INSERT INTO TBL_BOM_INFOMRATION (CONTROL_NO, PART_NO_ITEMS, PART_NAME_ITEMS, CHILD_PART_NO, CHILD_PART_NAME, USAGE_QTY, MATERIAL_GRADE, UNIT_WEIGHT, BLUE_BOX_QTY, MACHINE_TYPE, MOLD_DIMENSION, PACKING_METHOD, CREATE_AT, CREATE_BY) " +
                            "VALUES (@CONTROL_NO, @PART_NO_ITEMS, @PART_NAME_ITEMS, @CHILD_PART_NO, @CHILD_PART_NAME, @USAGE_QTY, @MATERIAL_GRADE, @UNIT_WEIGHT, @BLUE_BOX_QTY, @MACHINE_TYPE, @MOLD_DIMENSION, @PACKING_METHOD, @CREATE_AT, @CREATE_BY)";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryBom, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@PART_NO_ITEMS", Convert.ToString(row["PART_NO_ITEMS"]));
                                cmd.Parameters.AddWithValue("@PART_NAME_ITEMS", Convert.ToString(row["PART_NAME_ITEMS"]));
                                cmd.Parameters.AddWithValue("@CHILD_PART_NO", Convert.ToString(row["CHILD_PART_NO"]));
                                cmd.Parameters.AddWithValue("@CHILD_PART_NAME", Convert.ToString(row["CHILD_PART_NAME"]));
                                cmd.Parameters.AddWithValue("@USAGE_QTY", Convert.ToString(row["USAGE_QTY"]));
                                cmd.Parameters.AddWithValue("@MATERIAL_GRADE", Convert.ToString(row["MATERIAL_GRADE"]));
                                if (!string.IsNullOrEmpty(Convert.ToString(row["UNIT_WEIGHT"])))
                                {
                                    cmd.Parameters.AddWithValue("@UNIT_WEIGHT", Convert.ToDouble(row["UNIT_WEIGHT"]));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@UNIT_WEIGHT", DBNull.Value);
                                }
                                if (!string.IsNullOrEmpty(Convert.ToString(row["BLUE_BOX_QTY"])))
                                {
                                    cmd.Parameters.AddWithValue("@BLUE_BOX_QTY", Convert.ToInt32(row["BLUE_BOX_QTY"]));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@BLUE_BOX_QTY", DBNull.Value);
                                }
                                cmd.Parameters.AddWithValue("@MACHINE_TYPE", Convert.ToString(row["MACHINE_TYPE"]));
                                cmd.Parameters.AddWithValue("@MOLD_DIMENSION", Convert.ToString(row["MOLD_DIMENSION"]));
                                cmd.Parameters.AddWithValue("@PACKING_METHOD", Convert.ToString(row["PACKING_METHOD"]));
                                cmd.Parameters.AddWithValue("@CREATE_AT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@CREATE_BY", Constaint._userID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        for (int j = 0; j < DataSectionBom.Rows.Count; j++)
                        {
                            string ColumnName = Convert.ToString(DataSectionBom.Rows[j]["COLUMN_NAME"]);
                            string Section = Convert.ToString(DataSectionBom.Rows[j]["SECTION_INPUT"]);
                            string queryValuesBom = "INSERT INTO TBL_INSERT_VALUES_BOM_INFO (CONTROL_NO, ITEMS, PIC_SECTION, ROW, VALUES_INPUT) VALUES (@CONTROL_NO, @ITEMS, @PIC_SECTION, @ROW, @VALUES_INPUT)";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryValuesBom, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                    cmd.Parameters.AddWithValue("@ITEMS", ColumnName);
                                    cmd.Parameters.AddWithValue("@PIC_SECTION", Section);
                                    cmd.Parameters.AddWithValue("@ROW", Convert.ToString(row["PART_NO_ITEMS"]));
                                    cmd.Parameters.AddWithValue("@VALUES_INPUT", Convert.ToString(row[ColumnName]));
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                    }
                    //Lưu tên bộ phận chưa nhập đủ
                    string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS PRODUCT_INFO FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_INSERT_VALUES_BOM_INFO WHERE CONTROL_NO = '" + ControlNo + "' AND LEN(RTRIM(VALUES_INPUT)) = 0 GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                    DataTable dataSection = DBUtils._getData(queryDataSection);
                    string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET PRODUCT_INFORMATION = @PRODUCT_INFORMATION WHERE CONTROL_NO = '" + ControlNo + "'";
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
                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", Convert.ToString(dataSection.Rows[0]["PRODUCT_INFO"]));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", Convert.ToString(dataSection.Rows[0]["PRODUCT_INFO"]) + "-" + DueDate.ToString("dd/MMM"));
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(DueDate.ToString()))
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "Processing");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "Processing-" + DueDate.ToString("dd/MMM"));
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, PRODUCT_INFORMATION = @PRODUCT_INFORMATION, FEASIBILITY = @FEASIBILITY, " +
                            "APPROVED_PRODUCT_INFORMATION = @APPROVED_PRODUCT_INFORMATION, DATE_APPROVED_PRODUCT_INFORMATION = @DATE_APPROVED_PRODUCT_INFORMATION, COMMENTS_PRODUCT_INFORMATION = @COMMENTS_PRODUCT_INFORMATION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@STEP_CODE", "02");
                                cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "Finish");
                                cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing");
                                cmd.Parameters.AddWithValue("@APPROVED_PRODUCT_INFORMATION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_APPROVED_PRODUCT_INFORMATION", DateTime.Now);
                                cmd.Parameters.AddWithValue("@COMMENTS_PRODUCT_INFORMATION", txtComments.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //Lưu bộ phận chưa nhập đủ thông tin
                        string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS FEASIBILITY FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_FEASIBILITY WHERE CONTROL_NO = '" + ControlNo + "' AND ID_SITUATION != '02' AND ID_SITUATION != '03' AND (DATE_ORDER_EQUIPMENT is null or DATE_RECEIVE_EQUIPMENT is null or LEN(RTRIM(ID_SITUATION)) = 0 or LEN(RTRIM(DETAILS_PREPARED)) = 0) GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                        DataTable dataSection = DBUtils._getData(queryDataSection);
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET FEASIBILITY = @FEASIBILITY WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                if (dataSection.Rows.Count > 0)
                                {
                                    if (string.IsNullOrEmpty(DueDateFeasibility.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]) + "-" + DueDateFeasibility.ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDateFeasibility.ToString()))
                                    {
                                        cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing-" + DueDateFeasibility.ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Phê duyệt thành công.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_PRODUCT_INFO_Load(sender, e);
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

        private void btnChecked_Click(object sender, EventArgs e)
        {
            try
            {
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    DialogResult result = MessageBox.Show("Xác nhận đã kiểm tra thông tin?", "Checked", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        for (int i = 0; i < gvBom.RowCount; i++)
                        {
                            DataRow row = gvBom.GetDataRow(i);
                            if (string.IsNullOrEmpty(Convert.ToString(row["MATERIAL_GRADE"])) || string.IsNullOrEmpty(Convert.ToString(row["UNIT_WEIGHT"])) || string.IsNullOrEmpty(Convert.ToString(row["BLUE_BOX_QTY"])) || string.IsNullOrEmpty(Convert.ToString(row["MACHINE_TYPE"])) || string.IsNullOrEmpty(Convert.ToString(row["MOLD_DIMENSION"])) || string.IsNullOrEmpty(Convert.ToString(row["PACKING_METHOD"])))
                            {
                                MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (gvItems.RowCount <= 0)
                        {
                            MessageBox.Show("Thông tin chưa được nhập đầy đủ Không thể xác nhận", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (gvBom.RowCount <= 0)
                        {
                            MessageBox.Show("Thông tin chưa được nhập đầy đủ Không thể xác nhận", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_PRODUCT_INFORMATION = @CHECKED_PRODUCT_INFORMATION, DATE_CHECKED_PRODUCT_INFORMATION = @DATE_CHECKED_PRODUCT_INFORMATION WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@CHECKED_PRODUCT_INFORMATION", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_CHECKED_PRODUCT_INFORMATION", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Xác nhận đã kiểm tra thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_PRODUCT_INFO_Load(sender, e);
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
        string Status = string.Empty;

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
                        string queryUpdateDueDate = "UPDATE TBL_NEW_MOLD_MST SET DUE_DATE_PRODUCT_INFORMATION = @DUE_DATE_PRODUCT_INFORMATION WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateDueDate, conn))
                            {
                                cmd.Parameters.AddWithValue("@DUE_DATE_PRODUCT_INFORMATION", Convert.ToDateTime(txtDueDate.Text));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Thay đổi thời hạn hoàn thành thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
                string queryItems = "SELECT * FROM TBL_APPLICABLE_ITEMS WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable dataItems = DBUtils._getData(queryItems);
                string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                DataTable Data = DBUtils._getData(queryData);
                Status = Convert.ToString(Data.Rows[0]["PRODUCT_INFORMATION"]);
                if (!Status.Contains("Finish"))
                {
                    //Lưu tên bộ phận chưa nhập đủ
                    if (dataItems.Rows.Count > 0)
                    {
                        string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS PRODUCT_INFO FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_INSERT_VALUES_BOM_INFO WHERE CONTROL_NO = '" + ControlNo + "' AND LEN(RTRIM(VALUES_INPUT)) = 0 GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                        DataTable dataSection = DBUtils._getData(queryDataSection);
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET PRODUCT_INFORMATION = @PRODUCT_INFORMATION WHERE CONTROL_NO = '" + ControlNo + "'";
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
                                        cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", Convert.ToString(dataSection.Rows[0]["PRODUCT_INFO"]));
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", Convert.ToString(dataSection.Rows[0]["PRODUCT_INFO"]) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(txtDueDate.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "Processing");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                    }
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS PRODUCT_INFO FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_INSERT_VALUES_BOM_INFO WHERE CONTROL_NO = '" + ControlNo + "' AND LEN(RTRIM(VALUES_INPUT)) = 0 GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                        DataTable dataSection = DBUtils._getData(queryDataSection);
                        string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET PRODUCT_INFORMATION = @PRODUCT_INFORMATION WHERE CONTROL_NO = '" + ControlNo + "'";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "QA" + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                cmd.ExecuteNonQuery();
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
        string fileExtension;
        // chọn file và copy file
        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
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
                        int y = gvItems.FocusedRowHandle;
                        gvItems.SetRowCellValue(y, gvItems.Columns["ATTACHED_FILE"], _fileCopy.Substring(1));
                        gvItems.SetRowCellValue(y, gvItems.Columns["FILE_EXTENSION"], fileExtension);
                        fileUpLoad = Path.Combine(Constaint._folderFileUpload, ControlNo + "-" + "I" + fileExtension);
                        File.Copy(pathPdfFile, fileUpLoad, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gvItems_DoubleClick(object sender, EventArgs e)
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
                        if (!string.IsNullOrEmpty(Convert.ToString(gvItems.GetFocusedRowCellValue("ATTACHED_FILE"))))
                        {
                            System.Diagnostics.Process.Start(Constaint._folderFileUpload + gvItems.GetFocusedRowCellValue("ATTACHED_FILE").ToString() + gvItems.GetFocusedRowCellValue("FILE_EXTENSION").ToString());
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("File không tồn tại!");
            }
        }
    }
}