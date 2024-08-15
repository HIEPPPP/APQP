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

namespace APQP.FORM._06_MASS_PRODUCTION
{
    public partial class FRM_ADD_MASS_PRODUCTION : DevExpress.XtraEditors.XtraForm
    {
        public FRM_ADD_MASS_PRODUCTION(bool Add, int IDEntity)
        {
            this.Add = Add;
            this.IDEntity = IDEntity;
            InitializeComponent();
        }
        bool Add;
        int IDEntity;

        private void FRM_ADD_MASS_PRODUCTION_Load(object sender, EventArgs e)
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
                    string queryDataMST = "SELECT * FROM TBL_MASS_PRODUCTION_MST WHERE ID_IDENTITY = '" + IDEntity + "'";
                    DataTable DataMST = DBUtils._getData(queryDataMST);
                    if (DataMST.Rows.Count > 0)
                    {
                        txtMainContents.Text = Convert.ToString(DataMST.Rows[0]["MAIN_CONTENTS"]);
                        txtDetailContents.Text = Convert.ToString(DataMST.Rows[0]["DETAILED_CONTENTS"]);
                        txtSection.Text = Convert.ToString(DataMST.Rows[0]["PIC_SECTION"]);
                        int OnlyAPQP = Convert.ToInt32(DataMST.Rows[0]["ONLY_APQP"]);
                        if (OnlyAPQP == 1)
                        {
                            cbAPQP.Checked = true;
                        }
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
                if (string.IsNullOrEmpty(txtSection.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin PIC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtSection.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin loại hàng áp dụng", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Add == true)
                {
                    string querySave = "INSERT INTO TBL_MASS_PRODUCTION_MST (MOLD_TYPE, MAIN_CONTENTS, DETAILED_CONTENTS, ONLY_APQP, PIC_SECTION) VALUES (@MOLD_TYPE, @MAIN_CONTENTS, @DETAILED_CONTENTS, @ONLY_APQP, @PIC_SECTION)";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            cmd.Parameters.AddWithValue("@MOLD_TYPE", Constaint.MoldType);
                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", txtMainContents.Text);
                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", txtDetailContents.Text);
                            if (cbAPQP.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@ONLY_APQP", "1");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@ONLY_APQP", "0");
                            }
                            cmd.Parameters.AddWithValue("@PIC_SECTION", txtSection.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string querySave = "UPDATE TBL_MASS_PRODUCTION_MST SET MAIN_CONTENTS = @MAIN_CONTENTS, DETAILED_CONTENTS = @DETAILED_CONTENTS, ONLY_APQP = @ONLY_APQP, PIC_SECTION = @PIC_SECTION  WHERE ID_IDENTITY = @ID_IDENTITY";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_IDENTITY", IDEntity);
                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", txtMainContents.Text);
                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", txtDetailContents.Text);
                            if (cbAPQP.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@ONLY_APQP", "1");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@ONLY_APQP", "0");
                            }
                            cmd.Parameters.AddWithValue("@PIC_SECTION", txtSection.Text);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}