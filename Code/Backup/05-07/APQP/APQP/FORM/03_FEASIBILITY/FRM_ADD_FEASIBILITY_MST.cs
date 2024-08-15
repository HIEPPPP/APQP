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

namespace APQP.FORM._03_FEASIBILITY
{
    public partial class FRM_ADD_FEASIBILITY_MST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_ADD_FEASIBILITY_MST(bool Add, int IDEntity)
        {
            this.Add = Add;
            this.IDEntity = IDEntity;
            InitializeComponent();
        }
        bool Add;
        int IDEntity;
        int SortNumber;
        private void FRM_ADD_FEASIBILITY_MST_Load(object sender, EventArgs e)
        {
            try
            {
                string queryData = "SELECT * FROM TBL_SECTION_MST";
                DataTable Data = DBUtils._getData(queryData);
                txtSection.DataSource = Data;
                txtSection.ValueMember = "SECTION_SHORT_NAME";
                txtSection.DisplayMember = "SECTION_SHORT_NAME";
                txtSection.SelectedIndex = -1;
                if (Add == false)
                {
                    string queryDataMST = "SELECT * FROM TBL_FEASIBILITY_MST WHERE ID_IDENTITY = '" + IDEntity +"'";
                    DataTable DataMST = DBUtils._getData(queryDataMST);
                    if (DataMST.Rows.Count > 0)
                    {
                        txtReviewItems.Text = Convert.ToString(DataMST.Rows[0]["REVIEW_ITEMS"]);
                        txtSection.Text = Convert.ToString(DataMST.Rows[0]["PIC_SECTION"]);
                        txtApplyWith.Text = Convert.ToString(DataMST.Rows[0]["APPLY_WITH"]);
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
                if (string.IsNullOrEmpty(txtReviewItems.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin tiêu chí xem xét", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtSection.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin PIC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtApplyWith.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin hàng áp dụng", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Add == true)
                {
                    string querySave = "INSERT INTO TBL_FEASIBILITY_MST ( MOLD_TYPE , REVIEW_ITEMS, APPLY_WITH, PIC_SECTION, SORT_NUMBER, CREATE_AT, CREATE_BY) VALUES (@MOLD_TYPE, @REVIEW_ITEMS, @APPLY_WITH, @PIC_SECTION, @SORT_NUMBER, @CREATE_AT, @CREATE_BY)";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            cmd.Parameters.AddWithValue("@MOLD_TYPE", Constaint.MoldType);
                            cmd.Parameters.AddWithValue("@REVIEW_ITEMS", txtReviewItems.Text);
                            if (string.IsNullOrEmpty(txtApplyWith.Text))
                            {
                                cmd.Parameters.AddWithValue("@APPLY_WITH", "All");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@APPLY_WITH", txtApplyWith.Text);
                            }
                            cmd.Parameters.AddWithValue("@PIC_SECTION", txtSection.Text);
                            cmd.Parameters.AddWithValue("@SORT_NUMBER", SortNumber);
                            cmd.Parameters.AddWithValue("@CREATE_AT", DateTime.Now);
                            cmd.Parameters.AddWithValue("@CREATE_BY", Constaint._userID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string querySave = "UPDATE TBL_FEASIBILITY_MST SET REVIEW_ITEMS = @REVIEW_ITEMS, APPLY_WITH = @APPLY_WITH, CREATE_AT = @CREATE_AT, CREATE_BY = @CREATE_BY WHERE ID_IDENTITY = @ID_IDENTITY";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_IDENTITY", IDEntity);
                            cmd.Parameters.AddWithValue("@REVIEW_ITEMS", txtReviewItems.Text);
                            if (string.IsNullOrEmpty(txtApplyWith.Text))
                            {
                                cmd.Parameters.AddWithValue("@APPLY_WITH", "All");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@APPLY_WITH", txtApplyWith.Text);
                            }
                            cmd.Parameters.AddWithValue("@CREATE_AT", DateTime.Now);
                            cmd.Parameters.AddWithValue("@CREATE_BY", Constaint._userID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtSection_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string queryData = "SELECT * FROM TBL_FEASIBILITY_MST WHERE PIC_SECTION = '" + txtSection.Text + "'";
                DataTable Data = DBUtils._getData(queryData);
                if (Data.Rows.Count > 0)
                {
                    SortNumber = Convert.ToInt32(Data.Rows[0]["SORT_NUMBER"]);
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