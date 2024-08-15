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

namespace APQP.FORM._04_PREPARATION
{
    public partial class FRM_ADD_PREPARATION_MST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_ADD_PREPARATION_MST(bool Add, int IDEntity)
        {
            this.Add = Add;
            this.IDEntity = IDEntity;
            InitializeComponent();
        }
        bool Add;
        int IDEntity;
        int SortNumber;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMainContents.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin nội dung chính", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtDetailContents.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin nội dung chi tiết", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtApplyWith.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin loại hàng áp dụng", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtSection.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin PIC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Add == true)
                {
                    string querySave = "INSERT INTO TBL_PREPARATION_MST (MOLD_TYPE, MAIN_CONTENTS, DETAILED_CONTENTS, APPLY_WITH, PIC_SECTION, SORT_NUMBER) VALUES (@MOLD_TYPE, @MAIN_CONTENTS, @DETAILED_CONTENTS, @APPLY_WITH, @PIC_SECTION, @SORT_NUMBER)";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            cmd.Parameters.AddWithValue("@MOLD_TYPE", Constaint.MoldType);
                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", txtMainContents.Text);
                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", txtDetailContents.Text);
                            if (string.IsNullOrEmpty(txtApplyWith.Text))
                            {
                                cmd.Parameters.AddWithValue("@APPLY_WITH", "All");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@APPLY_WITH", txtApplyWith.Text);
                            }
                            cmd.Parameters.AddWithValue("@PIC_SECTION", txtSection.Text);
                            cmd.Parameters.AddWithValue("@SORT_NUMBER", txtSortNumber.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string querySave = "UPDATE TBL_PREPARATION_MST SET MAIN_CONTENTS = @MAIN_CONTENTS, DETAILED_CONTENTS = @DETAILED_CONTENTS, APPLY_WITH = @APPLY_WITH, PIC_SECTION = @PIC_SECTION, SORT_NUMBER = @SORT_NUMBER  WHERE ID_IDENTITY = @ID_IDENTITY";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_IDENTITY", IDEntity);
                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", txtMainContents.Text);
                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", txtDetailContents.Text);
                            if (string.IsNullOrEmpty(txtApplyWith.Text))
                            {
                                cmd.Parameters.AddWithValue("@APPLY_WITH", "All");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@APPLY_WITH", txtApplyWith.Text);
                            }
                            cmd.Parameters.AddWithValue("@PIC_SECTION", txtSection.Text);
                            cmd.Parameters.AddWithValue("@SORT_NUMBER", txtSortNumber.Text);
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

        private void FRM_ADD_PREPARATION_MST_Load(object sender, EventArgs e)
        {
            try
            {
                string queryDadaNumber = "SELECT DISTINCT SORT_NUMBER FROM TBL_PREPARATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "'";
                DataTable dataNumber = DBUtils._getData(queryDadaNumber);
                txtSortNumber.DataSource = dataNumber;
                txtSortNumber.DisplayMember = "SORT_NUMBER";
                txtSortNumber.ValueMember = "SORT_NUMBER";
                txtSortNumber.SelectedIndex = -1;
                string queryData = "SELECT * FROM TBL_SECTION_MST";
                DataTable Data = DBUtils._getData(queryData);
                txtSection.DataSource = Data;
                txtSection.ValueMember = "SECTION_SHORT_NAME";
                txtSection.DisplayMember = "SECTION_SHORT_NAME";
                txtSection.SelectedIndex = -1;
                if (Add == false)
                {
                    string queryDataMST = "SELECT * FROM TBL_PREPARATION_MST WHERE ID_IDENTITY = '" + IDEntity + "'";
                    DataTable DataMST = DBUtils._getData(queryDataMST);
                    if (DataMST.Rows.Count > 0)
                    {
                        txtMainContents.Text = Convert.ToString(DataMST.Rows[0]["MAIN_CONTENTS"]);
                        txtDetailContents.Text = Convert.ToString(DataMST.Rows[0]["DETAILED_CONTENTS"]);
                        txtApplyWith.Text = Convert.ToString(DataMST.Rows[0]["APPLY_WITH"]);
                        txtSection.Text = Convert.ToString(DataMST.Rows[0]["PIC_SECTION"]);
                        txtSortNumber.Text = Convert.ToString(DataMST.Rows[0]["SORT_NUMBER"]);
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
    }
}