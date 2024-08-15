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
using System.Data.SqlClient;
using APQP.DB;

namespace APQP.FORM.NEW_MOLD_MST
{
    public partial class FRM_ADD_NEW_MOLD : DevExpress.XtraEditors.XtraForm
    {
        public FRM_ADD_NEW_MOLD(bool Add, string ControlNo, string ProductType, string Type)
        {

            this.ControlNo = ControlNo;
            this.Add = Add;
            this.Type = Type;
            this.ProductType = ProductType;
            InitializeComponent();
        }
        string ControlNo;
        bool Add;
        string ProductType;
        string Type;
        int Number;
        private void FRM_ADD_NEW_MOLD_Load(object sender, EventArgs e)
        {
            try
            {
                if (Add == true)
                {
                    LoadControlNo();
                    //load Type
                    string queryDataType = "SELECT * FROM TBL_MOLD_TYPE_MST";
                    DataTable dataType = DBUtils._getData(queryDataType);
                    txtType.DataSource = dataType;
                    txtType.DisplayMember = "TYPE_NAME";
                    txtType.ValueMember = "TYPE_NAME";
                    txtType.SelectedIndex = -1;
                    txtProductType.SelectedIndex = -1;
                    if (Constaint.MoldType == "Terminal")
                    {
                        txtProductType.Text = "Unit";
                        txtProductType.Enabled = false;
                    }
                }
                if (Add == false)
                {
                    //txtDueDateMass.ReadOnly = true;
                    //txtDueDatePreparation.ReadOnly = true;
                    //txtDueDateProductInfo.ReadOnly = true;
                    //txtDueDateTrial.ReadOnly = true;
                    //load Type
                    if (Constaint._sectionShort == "PC")
                    {
                        txtFactory.Enabled = false;
                        txtPartName.ReadOnly = true;
                        txtPartNo.ReadOnly = true;
                        txtMoldNo.ReadOnly = true;
                        txtCavity.ReadOnly = true;
                        txtMoldReceiveActual.ReadOnly = true;
                        txtMoldReceivePlan.ReadOnly = true;
                    }
                    if (Constaint._sectionShort == "MM" || Constaint._sectionShort == "DM")
                    {
                        txtFactory.Enabled = false;
                        txtPartName.ReadOnly = true;
                        txtPartNo.ReadOnly = true;
                        //txtMoldNo.ReadOnly = true;
                        //txtCavity.ReadOnly = true;
                        txtMoldReceiveActual.ReadOnly = true;
                        txtMoldReceivePlan.ReadOnly = true;
                        txtDueDateMass.ReadOnly = true;
                        txtDueDatePreparation.ReadOnly = true;
                        txtDueDateProductInfo.ReadOnly = true;
                        txtDueDateTrial.ReadOnly = true;
                        txt1STShipPlan.ReadOnly = true;
                    }
                    string queryDataType = "SELECT * FROM TBL_MOLD_TYPE_MST";
                    DataTable dataType = DBUtils._getData(queryDataType);
                    txtType.DataSource = dataType;
                    txtType.DisplayMember = "TYPE_NAME";
                    txtType.ValueMember = "TYPE_NAME";
                    txtType.SelectedIndex = -1;
                    txtProductType.SelectedIndex = -1;
                    if (Constaint.MoldType == "Terminal")
                    {
                        txtProductType.Text = "Unit";
                        txtProductType.Enabled = false;
                    }
                    //txtType.Enabled = false;
                    //txtProductType.Enabled = false;
                    string QueryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                    DataTable data = DBUtils._getData(QueryData);
                    if (data.Rows.Count > 0)
                    {
                        txtControlNo.Text = Convert.ToString(data.Rows[0]["CONTROL_NO"]);
                        txtFactory.Text = Convert.ToString(data.Rows[0]["FACTORY"]);
                        txtPartName.Text = Convert.ToString(data.Rows[0]["PART_NAME"]);
                        txtPartNo.Text = Convert.ToString(data.Rows[0]["PART_NO"]);
                        txtMoldNo.Text = Convert.ToString(data.Rows[0]["MOLD_NO"]);
                        txtCavity.Text = Convert.ToString(data.Rows[0]["CAVITY"]);
                        txtType.Text = Convert.ToString(data.Rows[0]["TYPE"]);
                        txtProductType.Text = Convert.ToString(data.Rows[0]["PRODUCT_TYPE"]);
                        txtMoldReceivePlan.Text = Convert.ToString(data.Rows[0]["MOLD_RECEIVE_PLAN"]);
                        txtMoldReceiveActual.Text = Convert.ToString(data.Rows[0]["MOLD_RECEIVE_ACTUAL"]);
                        txtDueDateProductInfo.Text = Convert.ToString(data.Rows[0]["DUE_DATE_PRODUCT_INFORMATION"]);
                        txtDueDatePreparation.Text = Convert.ToString(data.Rows[0]["DUE_DATE_PREPARATION"]);
                        txtDueDateTrial.Text = Convert.ToString(data.Rows[0]["DUE_DATE_TRIAL_PRODUCTION"]);
                        txtDueDateMass.Text = Convert.ToString(data.Rows[0]["DUA_DATE_MASS_PRODUCTION"]);
                        txt1STShipPlan.Text = Convert.ToString(data.Rows[0]["1ST_SHIP_PLAN"]);
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
               
                if (string.IsNullOrEmpty(txtControlNo.Text.Trim()))
                {
                    MessageBox.Show("Chọn loại khuôn!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //if (string.IsNullOrEmpty(txtCavity.Text.Trim()))
                //{
                //    MessageBox.Show("Cavity không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (string.IsNullOrEmpty(txtMoldNo.Text.Trim()))
                //{
                //    MessageBox.Show("Mold No không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (string.IsNullOrEmpty(txtPartName.Text.Trim()))
                {
                    MessageBox.Show("Part name không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtPartNo.Text.Trim()))
                {
                    MessageBox.Show("Part No không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtType.Text.Trim()))
                {
                    MessageBox.Show("Type không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtProductType.Text.Trim()))
                {
                    MessageBox.Show("Product type không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //if (string.IsNullOrEmpty(txtMoldReceiveActual.Text.Trim()))
                //{
                //    MessageBox.Show("Ngày nhận khuôn không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (string.IsNullOrEmpty(txtMoldReceivePlan.Text.Trim()))
                {
                    MessageBox.Show("Kế hoạch nhận khuôn không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtFactory.Text.Trim()))
                {
                    MessageBox.Show("Thông tin nhà máy không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult = MessageBox.Show("Xác nhận lưu thông tin?", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.OK)
                {
                    //Add
                    if (Add == true)
                    {
                        string QueryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + txtControlNo.Text + "'";
                        DataTable data = DBUtils._getData(QueryData);
                        if (data.Rows.Count > 0)
                        {
                            LoadControlNo();
                        }
                        //insert TBL_NEW_MOLD_MST
                        string querySave = "INSERT INTO TBL_NEW_MOLD_MST (MOLD_TYPE, CONTROL_NO, FACTORY, PART_NAME, PART_NO, MOLD_NO, CAVITY, TYPE, PRODUCT_TYPE, [1ST_SHIP_PLAN], MOLD_RECEIVE_PLAN, MOLD_RECEIVE_ACTUAL, PRODUCT_INFORMATION, FEASIBILITY, PREPARATION, TRIAL_IM, TRIAL_MP, TRIAL_ASSY, TRIAL_PK , TRIAL_CONFIRMATION , COUNT_TRIAL, COUNT_TRIAL_IM, COUNT_TRIAL_ASSY, COUNT_TRIAL_PK, COUNT_TRIAL_MP , STATUS_TRIAL, MASS_PRODUCTION, FOLLOW_UP, STEP_CODE, DUE_DATE_PRODUCT_INFORMATION, DUE_DATE_FEASIBILITY, DUE_DATE_PREPARATION, DUE_DATE_TRIAL_PRODUCTION, DUA_DATE_MASS_PRODUCTION, TRIAL_PRODUCTION_ASSY_PLAN, ASSY_VISUAL_PLAN, ASSY_FUNCTION_PLAN, TRIAL_PRODUCTION_ASSY_ACTUAL, ASSY_VISUAL_ACTUAL, ASSY_FUNCTION_ACTUAL, PRODUCTION_STATUS, CREATE_AT, CREATE_BY, STATUS_DELETE) " +
                            "VALUES(@MOLD_TYPE, @CONTROL_NO, @FACTORY, @PART_NAME, @PART_NO, @MOLD_NO, @CAVITY, @TYPE, @PRODUCT_TYPE, @1ST_SHIP_PLAN, @MOLD_RECEIVE_PLAN, @MOLD_RECEIVE_ACTUAL, @PRODUCT_INFORMATION, @FEASIBILITY, @PREPARATION, @TRIAL_IM, @TRIAL_MP, @TRIAL_ASSY, @TRIAL_PK, @TRIAL_CONFIRMATION , @COUNT_TRIAL, @COUNT_TRIAL_IM, @COUNT_TRIAL_ASSY, @COUNT_TRIAL_PK, @COUNT_TRIAL_MP, @STATUS_TRIAL, @MASS_PRODUCTION, @FOLLOW_UP, @STEP_CODE , @DUE_DATE_PRODUCT_INFORMATION, @DUE_DATE_FEASIBILITY, @DUE_DATE_PREPARATION, @DUE_DATE_TRIAL_PRODUCTION, @DUA_DATE_MASS_PRODUCTION, @TRIAL_PRODUCTION_ASSY_PLAN, @ASSY_VISUAL_PLAN, @ASSY_FUNCTION_PLAN, @TRIAL_PRODUCTION_ASSY_ACTUAL, @ASSY_VISUAL_ACTUAL, @ASSY_FUNCTION_ACTUAL, @PRODUCTION_STATUS, @CREATE_AT, @CREATE_BY, @STATUS_DELETE)";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(querySave, conn))
                            {
                                cmd.Parameters.AddWithValue("@MOLD_TYPE", Constaint.MoldType);
                                cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@FACTORY", txtFactory.Text.Trim());
                                cmd.Parameters.AddWithValue("@PART_NAME", txtPartName.Text.Trim());
                                cmd.Parameters.AddWithValue("@PART_NO", txtPartNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@MOLD_NO", txtMoldNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@CAVITY", txtCavity.Text.Trim());
                                cmd.Parameters.AddWithValue("@TYPE", txtType.Text.Trim());
                                cmd.Parameters.AddWithValue("@PRODUCT_TYPE", txtProductType.Text.Trim());
                                if (string.IsNullOrEmpty(txt1STShipPlan.Text))
                                {
                                    cmd.Parameters.AddWithValue("@1ST_SHIP_PLAN", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@1ST_SHIP_PLAN", Convert.ToDateTime(txt1STShipPlan.Text));
                                }
                                if (string.IsNullOrEmpty(txtMoldReceivePlan.Text))
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_RECEIVE_PLAN", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_RECEIVE_PLAN", Convert.ToDateTime(txtMoldReceivePlan.Text));
                                }
                                if (string.IsNullOrEmpty(txtMoldReceiveActual.Text))
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_RECEIVE_ACTUAL", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_RECEIVE_ACTUAL", Convert.ToDateTime(txtMoldReceiveActual.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "QA");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "QA" + "-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                }
                                if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", "Wait");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@FEASIBILITY", "Wait" + "-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                }
                                if (string.IsNullOrEmpty(txtDueDatePreparation.Text))
                                {
                                    cmd.Parameters.AddWithValue("@PREPARATION", "Wait");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PREPARATION", "Wait" + "-" + Convert.ToDateTime(txtDueDatePreparation.Text).ToString("dd/MMM"));
                                }
                                if (Constaint.MoldType == "Connector")
                                {
                                    if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", "Wait");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                    }
                                    cmd.Parameters.AddWithValue("@TRIAL_MP", "N/A");
                                    if (txtProductType.Text == "Assy")
                                    {
                                        if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Wait");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                        }
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", "N/A");
                                    }
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_IM", "N/A");
                                    cmd.Parameters.AddWithValue("@TRIAL_ASSY", "N/A");
                                    if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", "Wait");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                    }
                                }
                                if (txtProductType.Text == "Unit" || txtProductType.Text == "Assy")
                                {
                                    if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", "Wait");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                    }
                                }
                                if (txtProductType.Text == "Child part")
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_PK", "N/A");
                                }
                                if ((string.IsNullOrEmpty(txtDueDateTrial.Text)))
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                }
                                cmd.Parameters.AddWithValue("@COUNT_TRIAL", 1);
                                cmd.Parameters.AddWithValue("@COUNT_TRIAL_IM", 1);
                                cmd.Parameters.AddWithValue("@COUNT_TRIAL_ASSY", 1);
                                cmd.Parameters.AddWithValue("@COUNT_TRIAL_PK", 1);
                                cmd.Parameters.AddWithValue("@COUNT_TRIAL_MP", 1);
                                cmd.Parameters.AddWithValue("@STATUS_TRIAL", "01");
                                if ((string.IsNullOrEmpty(txtDueDateMass.Text)))
                                {
                                    cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Wait");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Wait" + "-" + Convert.ToDateTime(txtDueDateMass.Text).ToString("dd/MMM"));
                                }
                                cmd.Parameters.AddWithValue("@FOLLOW_UP", "Processing");
                                cmd.Parameters.AddWithValue("@STEP_CODE", "01");
                                if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_PRODUCT_INFORMATION", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_PRODUCT_INFORMATION", Convert.ToDateTime(txtDueDateProductInfo.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_FEASIBILITY", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_FEASIBILITY", Convert.ToDateTime(txtDueDateProductInfo.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDatePreparation.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_PREPARATION", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_PREPARATION", Convert.ToDateTime(txtDueDatePreparation.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", Convert.ToDateTime(txtDueDateTrial.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDateMass.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUA_DATE_MASS_PRODUCTION", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUA_DATE_MASS_PRODUCTION", Convert.ToDateTime(txtDueDateMass.Text));
                                }
                                if (txtProductType.Text == "Assy" || txtProductType.Text == "Child part")
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_PLAN", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@ASSY_VISUAL_PLAN", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@ASSY_FUNCTION_PLAN", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_ACTUAL", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@ASSY_VISUAL_ACTUAL", DBNull.Value);
                                    cmd.Parameters.AddWithValue("@ASSY_FUNCTION_ACTUAL", DBNull.Value);
                                }
                                if (txtProductType.Text == "Unit")
                                {
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_PLAN", "N/A");
                                    cmd.Parameters.AddWithValue("@ASSY_VISUAL_PLAN", "N/A");
                                    cmd.Parameters.AddWithValue("@ASSY_FUNCTION_PLAN", "N/A");
                                    cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_ACTUAL", "N/A");
                                    cmd.Parameters.AddWithValue("@ASSY_VISUAL_ACTUAL", "N/A");
                                    cmd.Parameters.AddWithValue("@ASSY_FUNCTION_ACTUAL", "N/A");
                                }
                                if (!string.IsNullOrEmpty(txtMoldReceiveActual.Text))
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCTION_STATUS", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCTION_STATUS", "2");
                                }
                                cmd.Parameters.AddWithValue("@CREATE_AT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@CREATE_BY", Constaint._userID);
                                cmd.Parameters.AddWithValue("@STATUS_DELETE", "0");
                                cmd.ExecuteNonQuery();
                            }
                        }

                        string queryUpdateID = "";
                        if (Constaint.MoldType == "Connector")
                        {
                            queryUpdateID = "UPDATE TBL_ID_NUMBER SET NUMBER = '" + Number + "' WHERE ID_NAME = 'CONNECTOR'";
                        }
                        else
                        {
                            queryUpdateID = "UPDATE TBL_ID_NUMBER SET NUMBER = '" + Number + "' WHERE ID_NAME = 'TERMINAL'";
                        }
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdateID, _conn))
                            {
                                int n = cmd.ExecuteNonQuery();
                            }
                        }
                        //insert data TBL_FEASIBILITY
                        string queryDateFeasibilityMST = "";
                        if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                        {
                            queryDateFeasibilityMST = "SELECT * FROM TBL_FEASIBILITY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                        }
                        if (txtProductType.Text == "Assy")
                        {
                            queryDateFeasibilityMST = "SELECT * FROM TBL_FEASIBILITY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                        }
                        DataTable dataFeasibilityMST = DBUtils._getData(queryDateFeasibilityMST);
                        for (int i = 0; i < dataFeasibilityMST.Rows.Count; i++)
                        {
                            string ReviewItems = Convert.ToString(dataFeasibilityMST.Rows[i]["REVIEW_ITEMS"]);
                            string PICSection = Convert.ToString(dataFeasibilityMST.Rows[i]["PIC_SECTION"]);
                            int SortNumber = Convert.ToInt32(dataFeasibilityMST.Rows[i]["SORT_NUMBER"]);
                            int ID = Convert.ToInt32(dataFeasibilityMST.Rows[i]["ID_IDENTITY"]);
                            string queryInsertDataFeasibility = "INSERT INTO TBL_FEASIBILITY (CONTROL_NO, ID, REVIEW_ITEMS, ID_SITUATION, PIC_SECTION, SORT_NUMBER) VALUES (@CONTROL_NO, @ID, @REVIEW_ITEMS, @ID_SITUATION, @PIC_SECTION, @SORT_NUMBER)";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryInsertDataFeasibility, conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                    cmd.Parameters.AddWithValue("@ID", ID);
                                    cmd.Parameters.AddWithValue("@REVIEW_ITEMS", ReviewItems);
                                    cmd.Parameters.AddWithValue("@ID_SITUATION", "");
                                    cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                    cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        //insert data TBL_PREPARATION
                        string queryDatePreparationMST = "";
                        if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                        {
                            queryDatePreparationMST = "SELECT * FROM TBL_PREPARATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                        }
                        if (txtProductType.Text == "Assy")
                        {
                            queryDatePreparationMST = "SELECT * FROM TBL_PREPARATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                        }
                        DataTable dataPreparationMST = DBUtils._getData(queryDatePreparationMST);
                        for (int i = 0; i < dataPreparationMST.Rows.Count; i++)
                        {
                            string MainContents = Convert.ToString(dataPreparationMST.Rows[i]["MAIN_CONTENTS"]);
                            string DetailedContent = Convert.ToString(dataPreparationMST.Rows[i]["DETAILED_CONTENTS"]);
                            string PICSection = Convert.ToString(dataPreparationMST.Rows[i]["PIC_SECTION"]);
                            int SortNumber = Convert.ToInt32(dataPreparationMST.Rows[i]["SORT_NUMBER"]);
                            int ID = Convert.ToInt32(dataPreparationMST.Rows[i]["ID_IDENTITY"]);
                            string Stage = Convert.ToString(dataPreparationMST.Rows[i]["STAGE"]);
                            string queryInsertDataPreparation = "INSERT INTO TBL_PREPARATION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, STATUS, PIC_SECTION, SORT_NUMBER, STAGE, STATUS_DELETE) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @STATUS, @PIC_SECTION, @SORT_NUMBER, @STAGE, @STATUS_DELETE)";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryInsertDataPreparation, conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                    cmd.Parameters.AddWithValue("@ID", ID);
                                    cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                    cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                    cmd.Parameters.AddWithValue("@STATUS", "Not yet");
                                    cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                    cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                                    cmd.Parameters.AddWithValue("@STAGE", Stage);
                                    cmd.Parameters.AddWithValue("@STATUS_DELETE", "0");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        //insert data TBL_PREPARATION_TRY
                        string queryDatePreparationTryMST = "";
                        if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                        {
                            queryDatePreparationTryMST = "SELECT * FROM TBL_PREPARATION_TRY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                        }
                        if (txtProductType.Text == "Assy")
                        {
                            queryDatePreparationTryMST = "SELECT * FROM TBL_PREPARATION_TRY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                        }
                        DataTable dataPreparationTryMST = DBUtils._getData(queryDatePreparationTryMST);
                        for (int i = 0; i < dataPreparationTryMST.Rows.Count; i++)
                        {
                            string MainContents = Convert.ToString(dataPreparationTryMST.Rows[i]["MAIN_CONTENTS"]);
                            string DetailedContent = Convert.ToString(dataPreparationTryMST.Rows[i]["DETAILED_CONTENTS"]);
                            string PICSection = Convert.ToString(dataPreparationTryMST.Rows[i]["PIC_SECTION"]);
                            int SortNumber = Convert.ToInt32(dataPreparationTryMST.Rows[i]["SORT_NUMBER"]);
                            int ID = Convert.ToInt32(dataPreparationTryMST.Rows[i]["ID_IDENTITY"]);
                            string Stage = Convert.ToString(dataPreparationTryMST.Rows[i]["STAGE"]);
                            string queryInsertDataPreparationTry = "INSERT INTO TBL_PREPARATION_TRY (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, STATUS, PIC_SECTION, SORT_NUMBER, STAGE, STATUS_DELETE) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @STATUS, @PIC_SECTION, @SORT_NUMBER, @STAGE, @STATUS_DELETE)";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryInsertDataPreparationTry, conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                    cmd.Parameters.AddWithValue("@ID", ID);
                                    cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                    cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                    cmd.Parameters.AddWithValue("@STATUS", "Not yet");
                                    cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                    cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                                    cmd.Parameters.AddWithValue("@STAGE", Stage);
                                    cmd.Parameters.AddWithValue("@STATUS_DELETE", "0");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        string queryDataTrialMST = "";
                        if (Constaint.MoldType == "Connector")
                        {
                            if (txtProductType.Text == "Assy")
                            {
                                queryDataTrialMST = "SELECT * FROM TBL_TRIAL_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                            }
                            if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                            {
                                queryDataTrialMST = "SELECT * FROM TBL_TRIAL_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND STAGE != 'ASSY' ORDER BY SORT_NUMBER ASC";
                            }
                        }
                        if (Constaint.MoldType == "Terminal")
                        {
                            queryDataTrialMST = "SELECT * FROM TBL_TRIAL_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                        }
                        DataTable dataTrialMST = DBUtils._getData(queryDataTrialMST);
                        for (int i = 0; i < dataTrialMST.Rows.Count; i++)
                        {
                            string MainContents = Convert.ToString(dataTrialMST.Rows[i]["MAIN_CONTENTS"]);
                            string DetailedContent = Convert.ToString(dataTrialMST.Rows[i]["DETAILED_CONTENTS"]);
                            string PICSection = Convert.ToString(dataTrialMST.Rows[i]["PIC_SECTION"]);
                            int SortNumber = Convert.ToInt32(dataTrialMST.Rows[i]["SORT_NUMBER"]);
                            int ID = Convert.ToInt32(dataTrialMST.Rows[i]["ID_IDENTITY"]);
                            string Stage = Convert.ToString(dataTrialMST.Rows[i]["STAGE"]);
                            string queryInsertDataTrial = "INSERT INTO TBL_TRIAL_PRODUCTION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, PIC_SECTION, STAGE, SORT_NUMBER) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @PIC_SECTION, @STAGE, @SORT_NUMBER)";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryInsertDataTrial, conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                    cmd.Parameters.AddWithValue("@ID", ID);
                                    cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                    cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                    cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                    cmd.Parameters.AddWithValue("@STAGE", Stage);
                                    cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        //insert data TBL_OTHER_EVALUATION
                        string queryDataOtherEvaluationMST = "";
                        if (txtType.Text == "APQP")
                        {
                            if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                            {
                                queryDataOtherEvaluationMST = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                            }
                            if (txtProductType.Text == "Assy")
                            {
                                queryDataOtherEvaluationMST = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                            }
                        }
                        else
                        {
                            if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                            {
                                queryDataOtherEvaluationMST = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' AND ONLY_APQP != '1' ORDER BY SORT_NUMBER ASC";
                            }
                            if (txtProductType.Text == "Assy")
                            {
                                queryDataOtherEvaluationMST = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND ONLY_APQP != '1' ORDER BY SORT_NUMBER ASC";
                            }
                        }
                        DataTable dataOtherEvaluationMST = DBUtils._getData(queryDataOtherEvaluationMST);
                        for (int i = 0; i < dataOtherEvaluationMST.Rows.Count; i++)
                        {
                            string MainContents = Convert.ToString(dataOtherEvaluationMST.Rows[i]["MAIN_CONTENTS"]);
                            string DetailedContent = Convert.ToString(dataOtherEvaluationMST.Rows[i]["DETAILED_CONTENTS"]);
                            string PICSection = Convert.ToString(dataOtherEvaluationMST.Rows[i]["PIC_SECTION"]);
                            int ID = Convert.ToInt32(dataOtherEvaluationMST.Rows[i]["ID_IDENTITY"]);
                            string queryInsertDataOtherEvaluation = "INSERT INTO TBL_OTHER_EVALUATION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, PIC_SECTION) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @PIC_SECTION)";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryInsertDataOtherEvaluation, conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                    cmd.Parameters.AddWithValue("@ID", ID);
                                    cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                    cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                    cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        //insert data TBL_OTHER_VALUABLE_EVALUATION
                        string queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                        if (txtType.Text == "APQP")
                        {
                            if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                            {
                                queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                            }
                            if (txtProductType.Text == "Assy")
                            {
                                queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                            }
                        }
                        else
                        {
                            if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                            {
                                queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' AND ONLY_APQP != '1' ORDER BY SORT_NUMBER ASC";
                            }
                            if (txtProductType.Text == "Assy")
                            {
                                queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND ONLY_APQP != '1' ORDER BY SORT_NUMBER ASC";
                            }
                        }
                        DataTable DataOtherValuableEvaluationMST = DBUtils._getData(queryDataOtherValuableEvaluationMST);
                        if (DataOtherValuableEvaluationMST.Rows.Count > 0)
                        {
                            for (int i = 0; i < DataOtherValuableEvaluationMST.Rows.Count; i++)
                            {
                                string MainContents = Convert.ToString(DataOtherValuableEvaluationMST.Rows[i]["MAIN_CONTENTS"]);
                                string DetailedContent = Convert.ToString(DataOtherValuableEvaluationMST.Rows[i]["DETAILED_CONTENTS"]);
                                string PICSection = Convert.ToString(DataOtherValuableEvaluationMST.Rows[i]["PIC_SECTION"]);
                                int ID = Convert.ToInt32(DataOtherValuableEvaluationMST.Rows[i]["ID_IDENTITY"]);
                                string qrInsertDataOtherValuableEvaluationMST = "INSERT INTO TBL_OTHER_VALUABLE_EVALUATION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, PIC_SECTION) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @PIC_SECTION)";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(qrInsertDataOtherValuableEvaluationMST, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                        cmd.Parameters.AddWithValue("@ID", ID);
                                        cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                        cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                        cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        //insert data TBL_MASS_PRODUCTION
                        string queryMassProductionMST = "";
                        if (txtType.Text == "APQP")
                        {
                            queryMassProductionMST = "SELECT * FROM TBL_MASS_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                        }
                        else
                        {
                            queryMassProductionMST = "SELECT * FROM TBL_MASS_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND ONLY_APQP = '0' ORDER BY SORT_NUMBER ASC";
                        }
                        DataTable dataMassProductionMST = DBUtils._getData(queryMassProductionMST);
                        for (int i = 0; i < dataMassProductionMST.Rows.Count; i++)
                        {
                            string MainContents = Convert.ToString(dataMassProductionMST.Rows[i]["MAIN_CONTENTS"]);
                            string DetailedContent = Convert.ToString(dataMassProductionMST.Rows[i]["DETAILED_CONTENTS"]);
                            string PICSection = Convert.ToString(dataMassProductionMST.Rows[i]["PIC_SECTION"]);
                            int ID = Convert.ToInt32(dataMassProductionMST.Rows[i]["ID_IDENTITY"]);
                            string queryInsertDataMassProduction = "INSERT INTO TBL_MASS_PRODUCTION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, PIC_SECTION) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @PIC_SECTION)";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryInsertDataMassProduction, conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                    cmd.Parameters.AddWithValue("@ID", ID);
                                    cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                    cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                    cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    //Lưu tên bộ phận chưa nhập thông tin ở bảng TBL_FEASIBILITY
                    //FEASIBILITY
                    {
                        string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + txtControlNo.Text + "' ";
                        DataTable Data = DBUtils._getData(queryData);
                        string Status = Convert.ToString(Data.Rows[0]["FEASIBILITY"]);
                        if (!Status.Contains("Finish"))
                        {
                            string queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS FEASIBILITY FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_FEASIBILITY WHERE CONTROL_NO = '" + txtControlNo.Text + "' AND ID_SITUATION != '02' AND ID_SITUATION != '03' AND (DATE_ORDER_EQUIPMENT is null or DATE_RECEIVE_EQUIPMENT is null or LEN(RTRIM(ID_SITUATION)) = 0 or LEN(RTRIM(DETAILS_PREPARED)) = 0) GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
                            DataTable dataSection = DBUtils._getData(queryDataSection);
                            string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET FEASIBILITY = @FEASIBILITY WHERE CONTROL_NO = '" + txtControlNo.Text + "'";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                    if (dataSection.Rows.Count > 0)
                                    {
                                        if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]) + "-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                        }
                                    }
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    //Update
                    if (Add == false)
                    {
                        //Update TBL_NEW_MOLD_MST
                        string queryUpdate = "UPDATE TBL_NEW_MOLD_MST SET FACTORY = @FACTORY, PART_NAME = @PART_NAME, PART_NO = @PART_NO, MOLD_NO = @MOLD_NO, CAVITY = @CAVITY, TYPE = @TYPE, PRODUCT_TYPE = @PRODUCT_TYPE, [1ST_SHIP_PLAN] = @1ST_SHIP_PLAN, MOLD_RECEIVE_PLAN = @MOLD_RECEIVE_PLAN, MOLD_RECEIVE_ACTUAL = @MOLD_RECEIVE_ACTUAL, DUE_DATE_PRODUCT_INFORMATION = @DUE_DATE_PRODUCT_INFORMATION, " +
                            "DUE_DATE_FEASIBILITY = @DUE_DATE_FEASIBILITY, DUE_DATE_PREPARATION = @DUE_DATE_PREPARATION, DUE_DATE_TRIAL_PRODUCTION = @DUE_DATE_TRIAL_PRODUCTION, DUA_DATE_MASS_PRODUCTION = @DUA_DATE_MASS_PRODUCTION, PRODUCTION_STATUS = @PRODUCTION_STATUS, UPDATE_AT = @UPDATE_AT, UPDATE_BY = @UPDATE_BY WHERE CONTROL_NO = @CONTROL_NO";
                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(queryUpdate, conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@FACTORY", txtFactory.Text.Trim());
                                cmd.Parameters.AddWithValue("@PART_NAME", txtPartName.Text.Trim());
                                cmd.Parameters.AddWithValue("@PART_NO", txtPartNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@MOLD_NO", txtMoldNo.Text.Trim());
                                cmd.Parameters.AddWithValue("@CAVITY", txtCavity.Text.Trim());
                                cmd.Parameters.AddWithValue("@TYPE", txtType.Text.Trim());
                                cmd.Parameters.AddWithValue("@PRODUCT_TYPE", txtProductType.Text.Trim());
                                if (string.IsNullOrEmpty(txt1STShipPlan.Text))
                                {
                                    cmd.Parameters.AddWithValue("@1ST_SHIP_PLAN", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@1ST_SHIP_PLAN", Convert.ToDateTime(txt1STShipPlan.Text));
                                }
                                if (string.IsNullOrEmpty(txtMoldReceivePlan.Text))
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_RECEIVE_PLAN", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_RECEIVE_PLAN", Convert.ToDateTime(txtMoldReceivePlan.Text));
                                }
                                if (string.IsNullOrEmpty(txtMoldReceiveActual.Text))
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_RECEIVE_ACTUAL", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_RECEIVE_ACTUAL", Convert.ToDateTime(txtMoldReceiveActual.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_PRODUCT_INFORMATION", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_PRODUCT_INFORMATION", Convert.ToDateTime(txtDueDateProductInfo.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_FEASIBILITY", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_FEASIBILITY", Convert.ToDateTime(txtDueDateProductInfo.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDatePreparation.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_PREPARATION", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_PREPARATION", Convert.ToDateTime(txtDueDatePreparation.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", Convert.ToDateTime(txtDueDateTrial.Text));
                                }
                                if (string.IsNullOrEmpty(txtDueDateMass.Text))
                                {
                                    cmd.Parameters.AddWithValue("@DUA_DATE_MASS_PRODUCTION", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUA_DATE_MASS_PRODUCTION", Convert.ToDateTime(txtDueDateMass.Text));
                                }
                                if (!string.IsNullOrEmpty(txtMoldReceiveActual.Text))
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCTION_STATUS", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCTION_STATUS", "2");
                                }
                                cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //Update TBL_APPLICABLE_ITEMS
                        {
                            string queryUpdateTBL_BOM_INFOMRATION = "UPDATE TBL_APPLICABLE_ITEMS SET PRODUCT_TYPE = @PRODUCT_TYPE, TYPE = @TYPE WHERE CONTROL_NO = '" + ControlNo + "'";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateTBL_BOM_INFOMRATION, conn))
                                {
                                    cmd.Parameters.AddWithValue("@PRODUCT_TYPE", txtProductType.Text);
                                    cmd.Parameters.AddWithValue("@TYPE", txtType.Text);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        //Nếu sửa thông tin Type hoặc Product type
                        if ((((Type == "Add" || Type == "Expand") && txtType.Text == "APQP") || (Type == "APQP" && (txtType.Text == "Add" || txtType.Text == "Expand"))) || ((ProductType == "Assy" && (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")) || ((ProductType == "Unit" || ProductType == "Child part") && txtProductType.Text == "Assy")))
                        {
                            //Delete TBL_NEW_MOLD_MST
                            {
                                string queryDeleteTBL_NEW_MOLD_MST = "DELETE TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryDeleteTBL_NEW_MOLD_MST, conn))
                                    {
                                        int n = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //insert TBL_NEW_MOLD_MST
                            string querySave = "INSERT INTO TBL_NEW_MOLD_MST (MOLD_TYPE, CONTROL_NO, FACTORY, PART_NAME, PART_NO, MOLD_NO, CAVITY, TYPE, PRODUCT_TYPE, [1ST_SHIP_PLAN], MOLD_RECEIVE_PLAN, MOLD_RECEIVE_ACTUAL, PRODUCT_INFORMATION, FEASIBILITY, PREPARATION, TRIAL_IM, TRIAL_MP, TRIAL_ASSY, TRIAL_PK , TRIAL_CONFIRMATION , COUNT_TRIAL, COUNT_TRIAL_IM, COUNT_TRIAL_ASSY, COUNT_TRIAL_PK, COUNT_TRIAL_MP , STATUS_TRIAL, MASS_PRODUCTION, FOLLOW_UP, STEP_CODE, DUE_DATE_PRODUCT_INFORMATION, DUE_DATE_FEASIBILITY, DUE_DATE_PREPARATION, DUE_DATE_TRIAL_PRODUCTION, DUA_DATE_MASS_PRODUCTION, TRIAL_PRODUCTION_ASSY_PLAN, ASSY_VISUAL_PLAN, ASSY_FUNCTION_PLAN, TRIAL_PRODUCTION_ASSY_ACTUAL, ASSY_VISUAL_ACTUAL, ASSY_FUNCTION_ACTUAL, PRODUCTION_STATUS, CREATE_AT, CREATE_BY, STATUS_DELETE) " +
                                "VALUES(@MOLD_TYPE, @CONTROL_NO, @FACTORY, @PART_NAME, @PART_NO, @MOLD_NO, @CAVITY, @TYPE, @PRODUCT_TYPE, @1ST_SHIP_PLAN, @MOLD_RECEIVE_PLAN, @MOLD_RECEIVE_ACTUAL, @PRODUCT_INFORMATION, @FEASIBILITY, @PREPARATION, @TRIAL_IM, @TRIAL_MP, @TRIAL_ASSY, @TRIAL_PK, @TRIAL_CONFIRMATION , @COUNT_TRIAL, @COUNT_TRIAL_IM, @COUNT_TRIAL_ASSY, @COUNT_TRIAL_PK, @COUNT_TRIAL_MP, @STATUS_TRIAL, @MASS_PRODUCTION, @FOLLOW_UP, @STEP_CODE , @DUE_DATE_PRODUCT_INFORMATION, @DUE_DATE_FEASIBILITY, @DUE_DATE_PREPARATION, @DUE_DATE_TRIAL_PRODUCTION, @DUA_DATE_MASS_PRODUCTION, @TRIAL_PRODUCTION_ASSY_PLAN, @ASSY_VISUAL_PLAN, @ASSY_FUNCTION_PLAN, @TRIAL_PRODUCTION_ASSY_ACTUAL, @ASSY_VISUAL_ACTUAL, @ASSY_FUNCTION_ACTUAL, @PRODUCTION_STATUS, @CREATE_AT, @CREATE_BY, @STATUS_DELETE)";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(querySave, conn))
                                {
                                    cmd.Parameters.AddWithValue("@MOLD_TYPE", Constaint.MoldType);
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text.Trim());
                                    cmd.Parameters.AddWithValue("@FACTORY", txtFactory.Text.Trim());
                                    cmd.Parameters.AddWithValue("@PART_NAME", txtPartName.Text.Trim());
                                    cmd.Parameters.AddWithValue("@PART_NO", txtPartNo.Text.Trim());
                                    cmd.Parameters.AddWithValue("@MOLD_NO", txtMoldNo.Text.Trim());
                                    cmd.Parameters.AddWithValue("@CAVITY", txtCavity.Text.Trim());
                                    cmd.Parameters.AddWithValue("@TYPE", txtType.Text.Trim());
                                    cmd.Parameters.AddWithValue("@PRODUCT_TYPE", txtProductType.Text.Trim());
                                    if (string.IsNullOrEmpty(txt1STShipPlan.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@1ST_SHIP_PLAN", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@1ST_SHIP_PLAN", Convert.ToDateTime(txt1STShipPlan.Text));
                                    }
                                    if (string.IsNullOrEmpty(txtMoldReceivePlan.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@MOLD_RECEIVE_PLAN", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@MOLD_RECEIVE_PLAN", Convert.ToDateTime(txtMoldReceivePlan.Text));
                                    }
                                    if (string.IsNullOrEmpty(txtMoldReceiveActual.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@MOLD_RECEIVE_ACTUAL", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@MOLD_RECEIVE_ACTUAL", Convert.ToDateTime(txtMoldReceiveActual.Text));
                                    }
                                    if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "QA");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "QA" + "-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                    }
                                    if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@FEASIBILITY", "Wait");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@FEASIBILITY", "Wait" + "-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                    }
                                    if (string.IsNullOrEmpty(txtDueDatePreparation.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@PREPARATION", "Wait");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PREPARATION", "Wait" + "-" + Convert.ToDateTime(txtDueDatePreparation.Text).ToString("dd/MMM"));
                                    }
                                    if (Constaint.MoldType == "Connector")
                                    {
                                        if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_IM", "Wait");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_IM", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                        }
                                        cmd.Parameters.AddWithValue("@TRIAL_MP", "N/A");
                                        if (txtProductType.Text == "Assy")
                                        {
                                            if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Wait");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_ASSY", "N/A");
                                        }
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_IM", "N/A");
                                        cmd.Parameters.AddWithValue("@TRIAL_ASSY", "N/A");
                                        if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_MP", "Wait");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_MP", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                        }
                                    }
                                    if (txtProductType.Text == "Unit" || txtProductType.Text == "Assy")
                                    {
                                        if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_PK", "Wait");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@TRIAL_PK", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                        }
                                    }
                                    if (txtProductType.Text == "Child part")
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PK", "N/A");
                                    }
                                    if ((string.IsNullOrEmpty(txtDueDateTrial.Text)))
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                    }
                                    cmd.Parameters.AddWithValue("@COUNT_TRIAL", 1);
                                    cmd.Parameters.AddWithValue("@COUNT_TRIAL_IM", 1);
                                    cmd.Parameters.AddWithValue("@COUNT_TRIAL_ASSY", 1);
                                    cmd.Parameters.AddWithValue("@COUNT_TRIAL_PK", 1);
                                    cmd.Parameters.AddWithValue("@COUNT_TRIAL_MP", 1);
                                    cmd.Parameters.AddWithValue("@STATUS_TRIAL", "01");
                                    if ((string.IsNullOrEmpty(txtDueDateMass.Text)))
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Wait");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Wait" + "-" + Convert.ToDateTime(txtDueDateMass.Text).ToString("dd/MMM"));
                                    }
                                    cmd.Parameters.AddWithValue("@FOLLOW_UP", "Processing");
                                    cmd.Parameters.AddWithValue("@STEP_CODE", "01");
                                    if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@DUE_DATE_PRODUCT_INFORMATION", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@DUE_DATE_PRODUCT_INFORMATION", Convert.ToDateTime(txtDueDateProductInfo.Text));
                                    }
                                    if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@DUE_DATE_FEASIBILITY", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@DUE_DATE_FEASIBILITY", Convert.ToDateTime(txtDueDateProductInfo.Text));
                                    }
                                    if (string.IsNullOrEmpty(txtDueDatePreparation.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@DUE_DATE_PREPARATION", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@DUE_DATE_PREPARATION", Convert.ToDateTime(txtDueDatePreparation.Text));
                                    }
                                    if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@DUE_DATE_TRIAL_PRODUCTION", Convert.ToDateTime(txtDueDateTrial.Text));
                                    }
                                    if (string.IsNullOrEmpty(txtDueDateMass.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@DUA_DATE_MASS_PRODUCTION", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@DUA_DATE_MASS_PRODUCTION", Convert.ToDateTime(txtDueDateMass.Text));
                                    }
                                    if (txtProductType.Text == "Assy" || txtProductType.Text == "Child part")
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_PLAN", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@ASSY_VISUAL_PLAN", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@ASSY_FUNCTION_PLAN", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_ACTUAL", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@ASSY_VISUAL_ACTUAL", DBNull.Value);
                                        cmd.Parameters.AddWithValue("@ASSY_FUNCTION_ACTUAL", DBNull.Value);
                                    }
                                    if (txtProductType.Text == "Unit")
                                    {
                                        cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_PLAN", "N/A");
                                        cmd.Parameters.AddWithValue("@ASSY_VISUAL_PLAN", "N/A");
                                        cmd.Parameters.AddWithValue("@ASSY_FUNCTION_PLAN", "N/A");
                                        cmd.Parameters.AddWithValue("@TRIAL_PRODUCTION_ASSY_ACTUAL", "N/A");
                                        cmd.Parameters.AddWithValue("@ASSY_VISUAL_ACTUAL", "N/A");
                                        cmd.Parameters.AddWithValue("@ASSY_FUNCTION_ACTUAL", "N/A");
                                    }
                                    if (!string.IsNullOrEmpty(txtMoldReceiveActual.Text))
                                    {
                                        cmd.Parameters.AddWithValue("@PRODUCTION_STATUS", DBNull.Value);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@PRODUCTION_STATUS", "2");
                                    }
                                    cmd.Parameters.AddWithValue("@CREATE_AT", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@CREATE_BY", Constaint._userID);
                                    cmd.Parameters.AddWithValue("@STATUS_DELETE", "0");
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            //Delete TBL_FEASIBILITY 
                            {
                                string queryDeleteTBL_FEASIBILITY_MST = "DELETE TBL_FEASIBILITY WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryDeleteTBL_FEASIBILITY_MST, conn))
                                    {
                                        int n = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //Delete TBL_PREPARATION
                            {
                                string queryDeleteTBL_PREPARATION = "DELETE TBL_PREPARATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryDeleteTBL_PREPARATION, conn))
                                    {
                                        int n = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //Delete TBL_PREPARATION_TRY
                            {
                                string queryDeleteTBL_PREPARATION_TRY = "DELETE TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryDeleteTBL_PREPARATION_TRY, conn))
                                    {
                                        int n = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //Delete TBL_TRIAL_PRODUCTION
                            {
                                string queryDeleteTBL_TRIAL_PRODUCTION = "DELETE TBL_TRIAL_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryDeleteTBL_TRIAL_PRODUCTION, conn))
                                    {
                                        int n = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //Delete TBL_MASS_PRODUCTION
                            {
                                string queryDeleteTBL_MASS_PRODUCTION = "DELETE TBL_MASS_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryDeleteTBL_MASS_PRODUCTION, conn))
                                    {
                                        int n = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //Delete TBL_OTHER_EVALUATION
                            {
                                string queryDeleteTBL_OTHER_EVALUATION = "DELETE TBL_OTHER_EVALUATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryDeleteTBL_OTHER_EVALUATION, conn))
                                    {
                                        int n = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //Delete TBL_OTHER_VALUABLE_EVALUATION
                            {
                                string queryDeleteTBL_OTHER_VALUABLE_EVALUATION = "DELETE TBL_OTHER_VALUABLE_EVALUATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryDeleteTBL_OTHER_VALUABLE_EVALUATION, conn))
                                    {
                                        int n = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            //INSERT DATA
                            {
                                //insert data TBL_FEASIBILITY
                                string queryDateFeasibilityMST = "";
                                if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                                {
                                    queryDateFeasibilityMST = "SELECT * FROM TBL_FEASIBILITY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                                }
                                if (txtProductType.Text == "Assy")
                                {
                                    queryDateFeasibilityMST = "SELECT * FROM TBL_FEASIBILITY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                }
                                DataTable dataFeasibilityMST = DBUtils._getData(queryDateFeasibilityMST);
                                for (int i = 0; i < dataFeasibilityMST.Rows.Count; i++)
                                {
                                    string ReviewItems = Convert.ToString(dataFeasibilityMST.Rows[i]["REVIEW_ITEMS"]);
                                    string PICSection = Convert.ToString(dataFeasibilityMST.Rows[i]["PIC_SECTION"]);
                                    int SortNumber = Convert.ToInt32(dataFeasibilityMST.Rows[i]["SORT_NUMBER"]);
                                    int ID = Convert.ToInt32(dataFeasibilityMST.Rows[i]["ID_IDENTITY"]);
                                    string queryInsertDataFeasibility = "INSERT INTO TBL_FEASIBILITY (CONTROL_NO, ID, REVIEW_ITEMS, ID_SITUATION, PIC_SECTION, SORT_NUMBER) VALUES (@CONTROL_NO, @ID, @REVIEW_ITEMS, @ID_SITUATION, @PIC_SECTION, @SORT_NUMBER)";
                                    using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryInsertDataFeasibility, conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                            cmd.Parameters.AddWithValue("@ID", ID);
                                            cmd.Parameters.AddWithValue("@REVIEW_ITEMS", ReviewItems);
                                            cmd.Parameters.AddWithValue("@ID_SITUATION", "");
                                            cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                            cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                //insert data TBL_PREPARATION
                                string queryDatePreparationMST = "";
                                if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                                {
                                    queryDatePreparationMST = "SELECT * FROM TBL_PREPARATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                                }
                                if (txtProductType.Text == "Assy")
                                {
                                    queryDatePreparationMST = "SELECT * FROM TBL_PREPARATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                }
                                DataTable dataPreparationMST = DBUtils._getData(queryDatePreparationMST);
                                for (int i = 0; i < dataPreparationMST.Rows.Count; i++)
                                {
                                    string MainContents = Convert.ToString(dataPreparationMST.Rows[i]["MAIN_CONTENTS"]);
                                    string DetailedContent = Convert.ToString(dataPreparationMST.Rows[i]["DETAILED_CONTENTS"]);
                                    string PICSection = Convert.ToString(dataPreparationMST.Rows[i]["PIC_SECTION"]);
                                    int SortNumber = Convert.ToInt32(dataPreparationMST.Rows[i]["SORT_NUMBER"]);
                                    int ID = Convert.ToInt32(dataPreparationMST.Rows[i]["ID_IDENTITY"]);
                                    string Stage = Convert.ToString(dataPreparationMST.Rows[i]["STAGE"]);
                                    string queryInsertDataPreparation = "INSERT INTO TBL_PREPARATION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, STATUS, PIC_SECTION, SORT_NUMBER, STAGE, STATUS_DELETE) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @STATUS, @PIC_SECTION, @SORT_NUMBER, @STAGE, @STATUS_DELETE)";
                                    using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryInsertDataPreparation, conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                            cmd.Parameters.AddWithValue("@ID", ID);
                                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                            cmd.Parameters.AddWithValue("@STATUS", "Not yet");
                                            cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                            cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                                            cmd.Parameters.AddWithValue("@STAGE", Stage);
                                            cmd.Parameters.AddWithValue("@STATUS_DELETE", "0");
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                //insert data TBL_PREPARATION_TRY
                                string queryDatePreparationTryMST = "";
                                if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                                {
                                    queryDatePreparationTryMST = "SELECT * FROM TBL_PREPARATION_TRY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                                }
                                if (txtProductType.Text == "Assy")
                                {
                                    queryDatePreparationTryMST = "SELECT * FROM TBL_PREPARATION_TRY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                }
                                DataTable dataPreparationTryMST = DBUtils._getData(queryDatePreparationTryMST);
                                for (int i = 0; i < dataPreparationTryMST.Rows.Count; i++)
                                {
                                    string MainContents = Convert.ToString(dataPreparationTryMST.Rows[i]["MAIN_CONTENTS"]);
                                    string DetailedContent = Convert.ToString(dataPreparationTryMST.Rows[i]["DETAILED_CONTENTS"]);
                                    string PICSection = Convert.ToString(dataPreparationTryMST.Rows[i]["PIC_SECTION"]);
                                    int SortNumber = Convert.ToInt32(dataPreparationTryMST.Rows[i]["SORT_NUMBER"]);
                                    int ID = Convert.ToInt32(dataPreparationTryMST.Rows[i]["ID_IDENTITY"]);
                                    string Stage = Convert.ToString(dataPreparationTryMST.Rows[i]["STAGE"]);
                                    string queryInsertDataPreparationTry = "INSERT INTO TBL_PREPARATION_TRY (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, STATUS, PIC_SECTION, SORT_NUMBER, STAGE, STATUS_DELETE) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @STATUS, @PIC_SECTION, @SORT_NUMBER, @STAGE, @STATUS_DELETE)";
                                    using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryInsertDataPreparationTry, conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                            cmd.Parameters.AddWithValue("@ID", ID);
                                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                            cmd.Parameters.AddWithValue("@STATUS", "Not yet");
                                            cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                            cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                                            cmd.Parameters.AddWithValue("@STAGE", Stage);
                                            cmd.Parameters.AddWithValue("@STATUS_DELETE", "0");
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                //insert data TBL_TRIAL_PRODUCTION_MST
                                string queryDataTrialMST = "";
                                if (Constaint.MoldType == "Connector")
                                {
                                    if (txtProductType.Text == "Assy")
                                    {
                                        queryDataTrialMST = "SELECT * FROM TBL_TRIAL_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                    }
                                    if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                                    {
                                        queryDataTrialMST = "SELECT * FROM TBL_TRIAL_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND STAGE != 'ASSY' ORDER BY SORT_NUMBER ASC";
                                    }
                                }
                                if (Constaint.MoldType == "Terminal")
                                {
                                    queryDataTrialMST = "SELECT * FROM TBL_TRIAL_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                }
                                DataTable dataTrialMST = DBUtils._getData(queryDataTrialMST);
                                for (int i = 0; i < dataTrialMST.Rows.Count; i++)
                                {
                                    string MainContents = Convert.ToString(dataTrialMST.Rows[i]["MAIN_CONTENTS"]);
                                    string DetailedContent = Convert.ToString(dataTrialMST.Rows[i]["DETAILED_CONTENTS"]);
                                    string PICSection = Convert.ToString(dataTrialMST.Rows[i]["PIC_SECTION"]);
                                    int SortNumber = Convert.ToInt32(dataTrialMST.Rows[i]["SORT_NUMBER"]);
                                    int ID = Convert.ToInt32(dataTrialMST.Rows[i]["ID_IDENTITY"]);
                                    string Stage = Convert.ToString(dataTrialMST.Rows[i]["STAGE"]);
                                    string queryInsertDataTrial = "INSERT INTO TBL_TRIAL_PRODUCTION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, PIC_SECTION, STAGE, SORT_NUMBER) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @PIC_SECTION, @STAGE, @SORT_NUMBER)";
                                    using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryInsertDataTrial, conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                            cmd.Parameters.AddWithValue("@ID", ID);
                                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                            cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                            cmd.Parameters.AddWithValue("@STAGE", Stage);
                                            cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                //insert data TBL_OTHER_EVALUATION
                                string queryDataOtherEvaluationMST = "";
                                if (txtType.Text == "APQP")
                                {
                                    if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                                    {
                                        queryDataOtherEvaluationMST = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                                    }
                                    if (txtProductType.Text == "Assy")
                                    {
                                        queryDataOtherEvaluationMST = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                    }
                                }
                                else
                                {
                                    if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                                    {
                                        queryDataOtherEvaluationMST = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' AND ONLY_APQP != '1' ORDER BY SORT_NUMBER ASC";
                                    }
                                    if (txtProductType.Text == "Assy")
                                    {
                                        queryDataOtherEvaluationMST = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND ONLY_APQP != '1' ORDER BY SORT_NUMBER ASC";
                                    }
                                }
                                DataTable dataOtherEvaluationMST = DBUtils._getData(queryDataOtherEvaluationMST);
                                for (int i = 0; i < dataOtherEvaluationMST.Rows.Count; i++)
                                {
                                    string MainContents = Convert.ToString(dataOtherEvaluationMST.Rows[i]["MAIN_CONTENTS"]);
                                    string DetailedContent = Convert.ToString(dataOtherEvaluationMST.Rows[i]["DETAILED_CONTENTS"]);
                                    string PICSection = Convert.ToString(dataOtherEvaluationMST.Rows[i]["PIC_SECTION"]);
                                    int ID = Convert.ToInt32(dataOtherEvaluationMST.Rows[i]["ID_IDENTITY"]);
                                    string queryInsertDataOtherEvaluation = "INSERT INTO TBL_OTHER_EVALUATION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, PIC_SECTION) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @PIC_SECTION)";
                                    using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryInsertDataOtherEvaluation, conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                            cmd.Parameters.AddWithValue("@ID", ID);
                                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                            cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                //insert data TBL_OTHER_VALUABLE_EVALUATION
                                string queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                if (txtType.Text == "APQP")
                                {
                                    if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                                    {
                                        queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' ORDER BY SORT_NUMBER ASC";
                                    }
                                    if (txtProductType.Text == "Assy")
                                    {
                                        queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                    }
                                }
                                else
                                {
                                    if (txtProductType.Text == "Unit" || txtProductType.Text == "Child part")
                                    {
                                        queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND APPLY_WITH != 'Assy' AND ONLY_APQP != '1' ORDER BY SORT_NUMBER ASC";
                                    }
                                    if (txtProductType.Text == "Assy")
                                    {
                                        queryDataOtherValuableEvaluationMST = "SELECT * FROM TBL_OTHER_VALUABLE_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND ONLY_APQP != '1' ORDER BY SORT_NUMBER ASC";
                                    }
                                }
                                DataTable DataOtherValuableEvaluationMST = DBUtils._getData(queryDataOtherValuableEvaluationMST);
                                if (DataOtherValuableEvaluationMST.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DataOtherValuableEvaluationMST.Rows.Count; i++)
                                    {
                                        string MainContents = Convert.ToString(DataOtherValuableEvaluationMST.Rows[i]["MAIN_CONTENTS"]);
                                        string DetailedContent = Convert.ToString(DataOtherValuableEvaluationMST.Rows[i]["DETAILED_CONTENTS"]);
                                        string PICSection = Convert.ToString(DataOtherValuableEvaluationMST.Rows[i]["PIC_SECTION"]);
                                        int ID = Convert.ToInt32(DataOtherValuableEvaluationMST.Rows[i]["ID_IDENTITY"]);
                                        string qrInsertDataOtherValuableEvaluationMST = "INSERT INTO TBL_OTHER_VALUABLE_EVALUATION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, PIC_SECTION) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @PIC_SECTION)";
                                        using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                        {
                                            conn.Open();
                                            using (SqlCommand cmd = new SqlCommand(qrInsertDataOtherValuableEvaluationMST, conn))
                                            {
                                                cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                                cmd.Parameters.AddWithValue("@ID", ID);
                                                cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                                cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                                cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                                //insert data TBL_MASS_PRODUCTION
                                string queryMassProductionMST = "";
                                if (txtType.Text == "APQP")
                                {
                                    queryMassProductionMST = "SELECT * FROM TBL_MASS_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                                }
                                else
                                {
                                    queryMassProductionMST = "SELECT * FROM TBL_MASS_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND ONLY_APQP = '0' ORDER BY SORT_NUMBER ASC";
                                }
                                DataTable dataMassProductionMST = DBUtils._getData(queryMassProductionMST);
                                for (int i = 0; i < dataMassProductionMST.Rows.Count; i++)
                                {
                                    string MainContents = Convert.ToString(dataMassProductionMST.Rows[i]["MAIN_CONTENTS"]);
                                    string DetailedContent = Convert.ToString(dataMassProductionMST.Rows[i]["DETAILED_CONTENTS"]);
                                    string PICSection = Convert.ToString(dataMassProductionMST.Rows[i]["PIC_SECTION"]);
                                    int ID = Convert.ToInt32(dataMassProductionMST.Rows[i]["ID_IDENTITY"]);
                                    string queryInsertDataMassProduction = "INSERT INTO TBL_MASS_PRODUCTION (CONTROL_NO, ID, MAIN_CONTENTS, DETAILED_CONTENTS, PIC_SECTION) VALUES (@CONTROL_NO, @ID, @MAIN_CONTENTS, @DETAILED_CONTENTS, @PIC_SECTION)";
                                    using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryInsertDataMassProduction, conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text);
                                            cmd.Parameters.AddWithValue("@ID", ID);
                                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", MainContents);
                                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", DetailedContent);
                                            cmd.Parameters.AddWithValue("@PIC_SECTION", PICSection);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                        }
                        if (txtProductType.Text == "Child part")
                        {
                            string queryUpdateChilPart = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_PK = @TRIAL_PK WHERE CONTROL_NO = @CONTROL_NO";
                            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryUpdateChilPart, conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONTROL_NO", txtControlNo.Text.Trim());
                                    cmd.Parameters.AddWithValue("@TRIAL_PK", "N/A");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        //lưu tên bộ phận chưa nhập đủ thông tin
                        //PRODUCT_INFO
                        {
                            string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                            DataTable Data = DBUtils._getData(queryData);
                            string Status = Convert.ToString(Data.Rows[0]["PRODUCT_INFORMATION"]);
                            if (!Status.Contains("Finish"))
                            {
                                string queryItems = "SELECT * FROM TBL_APPLICABLE_ITEMS WHERE CONTROL_NO = '" + ControlNo + "'";
                                DataTable dataItems = DBUtils._getData(queryItems);
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
                                                if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", Convert.ToString(dataSection.Rows[0]["PRODUCT_INFO"]));
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", Convert.ToString(dataSection.Rows[0]["PRODUCT_INFO"]) + "-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "Processing");
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "Processing-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
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
                                            if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "QA");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@PRODUCT_INFORMATION", "QA" + "-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                            }
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                        }
                        //FEASIBILITY
                        {
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
                                            if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@FEASIBILITY", Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]) + "-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtDueDateProductInfo.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@FEASIBILITY", "Processing-" + Convert.ToDateTime(txtDueDateProductInfo.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        //PREPARATION
                        {
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
                                            if (string.IsNullOrEmpty(txtDueDatePreparation.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@PREPARATION", Convert.ToString(dataSection.Rows[0]["PREPARATION"]));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@PREPARATION", Convert.ToString(dataSection.Rows[0]["PREPARATION"]) + "-" + Convert.ToDateTime(txtDueDatePreparation.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtDueDatePreparation.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@PREPARATION", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@PREPARATION", "Processing-" + Convert.ToDateTime(txtDueDatePreparation.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            if (Status.Contains("Wait"))
                            {
                                string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET PREPARATION = @PREPARATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                        if (string.IsNullOrEmpty(txtDueDatePreparation.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", "Wait");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@PREPARATION", "Wait" + "-" + Convert.ToDateTime(txtDueDatePreparation.Text).ToString("dd/MMM"));
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        //Trial 
                        {
                            //IM
                            {
                                string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE CONTROL_NO = '" + ControlNo + "' ";
                                DataTable Data = DBUtils._getData(queryData);
                                string Status = Convert.ToString(Data.Rows[0]["TRIAL_IM"]);
                                if (!Status.Contains("Finish") && !Status.Contains("Wait"))
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
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain1.Substring(2));
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_IM", sectionRemain1.Substring(2) + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing");
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_IM", "Processing-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                if (Status.Contains("Wait"))
                                {
                                    string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_IM = @TRIAL_IM WHERE CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                            if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_IM", "Wait");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_IM", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
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
                                if (!Status.Contains("Finish") && !Status.Contains("N/A"))
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
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain2.Substring(2));
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_ASSY", sectionRemain2.Substring(2) + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing");
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Processing-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                if (Status.Contains("Wait"))
                                {
                                    string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_ASSY = @TRIAL_ASSY WHERE CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                            if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Wait");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_ASSY", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
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
                                if (!Status.Contains("Finish") && !Status.Contains("N/A"))
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
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain3.Substring(2));
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_PK", sectionRemain3.Substring(2) + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing");
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_PK", "Processing-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                if (Status.Contains("Wait"))
                                {
                                    string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_PK = @TRIAL_PK WHERE CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                            if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", "Wait");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_PK", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
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
                                if (!Status.Contains("Finish") && !Status.Contains("N/A"))
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
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain4.Substring(2));
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_MP", sectionRemain4.Substring(2) + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing");
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_MP", "Processing-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                if (Status.Contains("Wait"))
                                {
                                    string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_MP = @TRIAL_MP WHERE CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                            if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_MP", "Wait");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_MP", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
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
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2));
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", sectionRemain5.Substring(2) + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing");
                                                }
                                                else
                                                {
                                                    cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Processing-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                                }
                                            }
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                if (Status.Contains("Wait"))
                                {
                                    string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET TRIAL_CONFIRMATION = @TRIAL_CONFIRMATION WHERE CONTROL_NO = '" + ControlNo + "'";
                                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                    {
                                        _conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                        {
                                            cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                            if (string.IsNullOrEmpty(txtDueDateTrial.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@TRIAL_CONFIRMATION", "Wait" + "-" + Convert.ToDateTime(txtDueDateTrial.Text).ToString("dd/MMM"));
                                            }
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        //MASS_PRODCTION
                        {
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
                                            if (string.IsNullOrEmpty(txtDueDateMass.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@MASS_PRODUCTION", Convert.ToString(dataSection.Rows[0]["MASS_PRODUCTION"]));
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@MASS_PRODUCTION", Convert.ToString(dataSection.Rows[0]["MASS_PRODUCTION"]) + "-" + Convert.ToDateTime(txtDueDateMass.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtDueDateMass.Text))
                                            {
                                                cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing");
                                            }
                                            else
                                            {
                                                cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Processing-" + Convert.ToDateTime(txtDueDateMass.Text).ToString("dd/MMM"));
                                            }
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            if (Status.Contains("Wait"))
                            {
                                string queryUpdateSection = "UPDATE TBL_NEW_MOLD_MST SET MASS_PRODUCTION = @MASS_PRODUCTION WHERE CONTROL_NO = '" + ControlNo + "'";
                                using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                                {
                                    _conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(queryUpdateSection, _conn))
                                    {
                                        cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                        if (string.IsNullOrEmpty(txtDueDateMass.Text))
                                        {
                                            cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Wait");
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@MASS_PRODUCTION", "Wait" + "-" + Convert.ToDateTime(txtDueDateMass.Text).ToString("dd/MMM"));
                                        }
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                    }
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void LoadControlNo()
        {
            try
            {
                if (Constaint.MoldType == "Connector")
                {
                    string queryIDNumber = "SELECT * FROM TBL_ID_NUMBER WHERE ID_NAME = 'CONNECTOR'";
                    DataTable dataNumberID = DBUtils._getData(queryIDNumber);
                    Number = Convert.ToInt32(dataNumberID.Rows[0]["NUMBER"]) + 1;
                    if (Number < 10)
                    {
                        txtControlNo.Text = "C-APQP-00" + Number;
                    }
                    if (Number >= 10 && Number <= 100)
                    {
                        txtControlNo.Text = "C-APQP-0" + Number;
                    }
                    if (Number >= 100)
                    {
                        txtControlNo.Text = "C-APQP-" + Number;
                    }
                }
                if (Constaint.MoldType == "Terminal")
                {
                    string queryIDNumber = "SELECT * FROM TBL_ID_NUMBER WHERE ID_NAME = 'TERMINAL'";
                    DataTable dataNumberID = DBUtils._getData(queryIDNumber);
                    Number = Convert.ToInt32(dataNumberID.Rows[0]["NUMBER"]) + 1;
                    if (Number < 10)
                    {
                        txtControlNo.Text = "T-APQP-00" + Number;
                    }
                    if (Number >= 10 && Number <= 100)
                    {
                        txtControlNo.Text = "T-APQP-0" + Number;
                    }
                    if (Number >= 100)
                    {
                        txtControlNo.Text = "T-APQP-" + Number;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}