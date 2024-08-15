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

namespace APQP.FORM._03._FEASIBILITY
{
    public partial class FRM_FEASIBILITY : DevExpress.XtraEditors.XtraForm
    {
        public FRM_FEASIBILITY(string ControlNo)
        {
            this.ControlNo = ControlNo;
            InitializeComponent();
        }
        string ControlNo;
        private void FRM_FEASIBILITY_Load(object sender, EventArgs e)
        {
            label1.Text = "FEASIBILITY (" + ControlNo + ")";
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
        DateTime DTDueDatePreparation;
        string DueDatePreparation = string.Empty;

        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_FEASIBILITY WHERE CONTROL_NO = '" + ControlNo + "' ORDER BY SORT_NUMBER ASC";
                DataTable data = DBUtils._getData(queryData);
                gcData.DataSource = data;
                string querySituation = "SELECT ID_SITUATION, SITUATION FROM TBL_SITUATION_MST";
                DataTable dataSituation = DBUtils._getData(querySituation);
                rpsSituation.DataSource = dataSituation;
                rpsSituation.DisplayMember = "SITUATION";
                rpsSituation.ValueMember = "ID_SITUATION";
                //Load Data Approved
                string queryDataApproved = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                DataTable DataApproved = DBUtils._getData(queryDataApproved);
                if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_PREPARATION"])))
                {
                    DTDueDatePreparation = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_PREPARATION"].ToString());
                    DueDatePreparation = DTDueDatePreparation.ToString("dd/MMM");
                }
                DateTime DateChecked;
                DateTime DateApproved;

                if (DataApproved.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["CHECKED_FEASIBILITY"])))
                    {
                        txtChecked.Text = DataApproved.Rows[0]["CHECKED_FEASIBILITY"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_CHECKED_FEASIBILITY"])))
                    {
                        DateChecked = Convert.ToDateTime(DataApproved.Rows[0]["DATE_CHECKED_FEASIBILITY"].ToString());
                        txtDateChecked.Text = DateChecked.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["APPROVED_FEASIBILITY"])))
                    {
                        txtApproved.Text = DataApproved.Rows[0]["APPROVED_FEASIBILITY"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DATE_APPROVED_FEASIBILITY"])))
                    {
                        DateApproved = Convert.ToDateTime(DataApproved.Rows[0]["DATE_APPROVED_FEASIBILITY"].ToString());
                        txtDateApproved.Text = DateApproved.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["COMMENTS_FEASIBILITY"])))
                    {
                        txtComments.Text = DataApproved.Rows[0]["COMMENTS_FEASIBILITY"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(DataApproved.Rows[0]["DUE_DATE_PRODUCT_INFORMATION"])))
                    {
                        DTDueDate = Convert.ToDateTime(DataApproved.Rows[0]["DUE_DATE_PRODUCT_INFORMATION"].ToString());
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
                                string queryItems = "UPDATE TBL_FEASIBILITY SET ID_SITUATION = @ID_SITUATION, DETAILS_PREPARED = @DETAILS_PREPARED, DATE_ORDER_EQUIPMENT = @DATE_ORDER_EQUIPMENT, DATE_RECEIVE_EQUIPMENT = @DATE_RECEIVE_EQUIPMENT, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                        cmd.Parameters.AddWithValue("@ID_SITUATION", Convert.ToString(row["ID_SITUATION"]));
                                        cmd.Parameters.AddWithValue("@DETAILS_PREPARED", Convert.ToString(row["DETAILS_PREPARED"]));
                                        if (string.IsNullOrEmpty(Convert.ToString(row["DATE_ORDER_EQUIPMENT"])))
                                        {
                                            cmd.Parameters.AddWithValue("@DATE_ORDER_EQUIPMENT", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@DATE_ORDER_EQUIPMENT", Convert.ToDateTime(row["DATE_ORDER_EQUIPMENT"]));
                                        }
                                        if (string.IsNullOrEmpty(Convert.ToString(row["DATE_RECEIVE_EQUIPMENT"])))
                                        {
                                            cmd.Parameters.AddWithValue("@DATE_RECEIVE_EQUIPMENT", DBNull.Value);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@DATE_RECEIVE_EQUIPMENT", Convert.ToDateTime(row["DATE_RECEIVE_EQUIPMENT"]));
                                        }
                                        cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //đang sửa đến đây
                            string IDSituation = Convert.ToString(row["ID_SITUATION"]);
                            string ID = Convert.ToString(row["ID"]);
                            if (Constaint.MoldType == "Connector")
                            {
                                if (ID == "2" && IDSituation != "01")
                                {
                                    string queryUpdate = "UPDATE TBL_PREPARATION SET STATUS_DELETE = '1' WHERE ID = '6' AND CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdate, _conn))
                                        {
                                            int n = cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                if (ID == "2" && IDSituation == "01")
                                {
                                    string queryUpdate = "UPDATE TBL_PREPARATION SET STATUS_DELETE = '0' WHERE ID = '6' AND CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdate, _conn))
                                        {
                                            int n = cmd.ExecuteNonQuery();
                                        }
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
                            string queryItems = "UPDATE TBL_FEASIBILITY SET ID_SITUATION = @ID_SITUATION, DETAILS_PREPARED = @DETAILS_PREPARED, DATE_ORDER_EQUIPMENT = @DATE_ORDER_EQUIPMENT, DATE_RECEIVE_EQUIPMENT = @DATE_RECEIVE_EQUIPMENT, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryItems, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    cmd.Parameters.AddWithValue("@ID_SITUATION", Convert.ToString(row["ID_SITUATION"]));
                                    cmd.Parameters.AddWithValue("@DETAILS_PREPARED", Convert.ToString(row["DETAILS_PREPARED"]));
                                    if (string.IsNullOrEmpty(Convert.ToString(row["DATE_ORDER_EQUIPMENT"])))
                                    {
                                        cmd.Parameters.AddWithValue("@DATE_ORDER_EQUIPMENT", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@DATE_ORDER_EQUIPMENT", Convert.ToDateTime(row["DATE_ORDER_EQUIPMENT"]));
                                    }
                                    if (string.IsNullOrEmpty(Convert.ToString(row["DATE_RECEIVE_EQUIPMENT"])))
                                    {
                                        cmd.Parameters.AddWithValue("@DATE_RECEIVE_EQUIPMENT", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@DATE_RECEIVE_EQUIPMENT", Convert.ToDateTime(row["DATE_RECEIVE_EQUIPMENT"]));
                                    }
                                    cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            string IDSituation = Convert.ToString(row["ID_SITUATION"]);
                            string ID = Convert.ToString(row["ID"]);
                            if (Constaint.MoldType == "Connector")
                            {
                                if (ID == "2" && IDSituation != "01")
                                {
                                    string queryUpdate = "UPDATE TBL_PREPARATION SET STATUS_DELETE = '1' WHERE ID = '6' AND CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdate, _conn))
                                        {
                                            int n = cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                if (ID == "2" && IDSituation == "01")
                                {
                                    string queryUpdate = "UPDATE TBL_PREPARATION SET STATUS_DELETE = '0' WHERE ID = '6' AND CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdate, _conn))
                                        {
                                            int n = cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
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
                                if (string.IsNullOrEmpty(DueDate))
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]) + "-" + DueDate);
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(DueDate))
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing-" + DueDate);
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

        private void btnChecked_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvData.RowCount; i++)
                {
                    DataRow row = gvData.GetDataRow(i);
                    string SITUATION = Convert.ToString(row["ID_SITUATION"]);
                    if (SITUATION == "01")
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(row["DETAILS_PREPARED"])) || string.IsNullOrEmpty(Convert.ToString(row["DATE_ORDER_EQUIPMENT"])) || string.IsNullOrEmpty(Convert.ToString(row["DATE_RECEIVE_EQUIPMENT"])))
                        {
                            MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (string.IsNullOrEmpty(SITUATION))
                    {
                        MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
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
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET CHECKED_FEASIBILITY = @CHECKED_FEASIBILITY, DATE_CHECKED_FEASIBILITY = @DATE_CHECKED_FEASIBILITY WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@CHECKED_FEASIBILITY", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_CHECKED_FEASIBILITY", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Xác nhận đã kiểm tra thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_FEASIBILITY_Load(sender, e);
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
                    string queryCheck = "SELECT PRODUCT_INFORMATION FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                    DataTable dataCheck = DBUtils._getData(queryCheck);
                    string status = Convert.ToString(dataCheck.Rows[0]["PRODUCT_INFORMATION"]);
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
                    DialogResult result = MessageBox.Show("Xác nhận phê duyệt thông tin?", "Approved", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        string queryApproved = "UPDATE TBL_NEW_MOLD_MST SET STEP_CODE = @STEP_CODE, FEASIBILITY = @FEASIBILITY, PREPARATION = @PREPARATION, " +
                            "APPROVED_FEASIBILITY = @APPROVED_FEASIBILITY, DATE_APPROVED_FEASIBILITY = @DATE_APPROVED_FEASIBILITY, COMMENTS_FEASIBILITY = @COMMENTS_FEASIBILITY WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryApproved, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@STEP_CODE", "03");
                                cmd.Parameters.AddWithValue("@FEASIBILITY", "Finish");
                                if (status.Contains("Finish"))
                                {
                                    cmd.Parameters.AddWithValue("@PREPARATION", "Processing");
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(DueDatePreparation))
                                    {
                                        cmd.Parameters.AddWithValue("@PREPARATION", "Wait");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PREPARATION", "Wait-" + DueDatePreparation);
                                    }
                                }
                                cmd.Parameters.AddWithValue("@APPROVED_FEASIBILITY", Constaint._nameUser);
                                cmd.Parameters.AddWithValue("@DATE_APPROVED_FEASIBILITY", DateTime.Now);
                                cmd.Parameters.AddWithValue("@COMMENTS_FEASIBILITY", txtComments.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (status.Contains("Finish"))
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
                                        if (string.IsNullOrEmpty(DueDatePreparation))
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", Convert.ToString(dataSection.Rows[0]["PREPARATION"]));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", Convert.ToString(dataSection.Rows[0]["PREPARATION"]) + "-" + DueDatePreparation);
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(DueDatePreparation))
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", "Processing-" + DueDatePreparation);
                                        }
                                    }
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        MessageBox.Show("Phê duyệt thành công.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRM_FEASIBILITY_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Không có quyền phê duyệt.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                //Lưu bộ phận chưa nhập đủ thông tin
                //TBL_FEASIBILITY
                string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                DataTable Data = DBUtils._getData(queryData);
                string Status = Convert.ToString(Data.Rows[0]["FEASIBILITY"]);
                if (!Status.Contains("Finish"))
                {

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
                                if (string.IsNullOrEmpty(txtDueDate.Text))
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]) + "-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(txtDueDate.Text))
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing-" + Convert.ToDateTime(txtDueDate.Text).ToString("dd/MMM"));
                                }
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                //Lưu tên bộ phận chưa nhập đủ
                //PRODUCT_INFORMATION
                string queryItems = "SELECT * FROM TBL_APPLICABLE_ITEMS WHERE CONTROL_NO = '" + ControlNo + "'";
                DataTable dataItems = DBUtils._getData(queryItems);
                Status = Convert.ToString(Data.Rows[0]["PRODUCT_INFORMATION"]);
                if (!Status.Contains("Finish"))
                {

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gcData_Click(object sender, EventArgs e)
        {

        }
    }
}