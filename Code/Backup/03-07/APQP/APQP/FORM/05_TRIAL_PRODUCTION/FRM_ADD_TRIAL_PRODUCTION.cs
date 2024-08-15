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

namespace APQP.FORM._05_TRIAL_PRODUCTION
{
    public partial class FRM_ADD_TRIAL_PRODUCTION : DevExpress.XtraEditors.XtraForm
    {
        public FRM_ADD_TRIAL_PRODUCTION(bool Add, int IDEntity)
        {
            this.Add = Add;
            this.IDEntity = IDEntity;
            InitializeComponent();
        }
        bool Add;
        int IDEntity;
        private void FRM_ADD_TRIAL_PRODUCTION_Load(object sender, EventArgs e)
        {
            try
            {
                string queryDadaNumber = "SELECT DISTINCT SORT_NUMBER FROM TBL_TRIAL_PRODUCTION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "'";
                DataTable dataNumber = DBUtils._getData(queryDadaNumber);
                txtSortNumber.DataSource = dataNumber;
                txtSortNumber.DisplayMember = "SORT_NUMBER";
                txtSortNumber.ValueMember = "SORT_NUMBER";
                txtSortNumber.SelectedIndex = -1;
                string queryDataSection = "SELECT * FROM TBL_SECTION_MST";
                DataTable DataSection = DBUtils._getData(queryDataSection);
                txtSection.DataSource = DataSection;
                txtSection.ValueMember = "SECTION_SHORT_NAME";
                txtSection.DisplayMember = "SECTION_SHORT_NAME";
                txtSection.SelectedIndex = -1;
                //if (Constaint.MoldType == "Terminal")
                //{
                //    txtStage.Visible = false;
                //    label3.Visible = false;
                //}
                if (Add == false)
                {
                    string queryDataMST = "SELECT * FROM TBL_TRIAL_PRODUCTION_MST WHERE ID_IDENTITY = '" + IDEntity + "'";
                    DataTable DataMST = DBUtils._getData(queryDataMST);
                    if (DataMST.Rows.Count > 0)
                    {
                        txtMainContents.Text = Convert.ToString(DataMST.Rows[0]["MAIN_CONTENTS"]);
                        txtDetailsContents.Text = Convert.ToString(DataMST.Rows[0]["DETAILED_CONTENTS"]);
                        txtSection.Text = Convert.ToString(DataMST.Rows[0]["PIC_SECTION"]);
                        txtSortNumber.Text = Convert.ToString(DataMST.Rows[0]["SORT_NUMBER"]);
                        txtStage.Text = Convert.ToString(DataMST.Rows[0]["STAGE"]);
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
                if (string.IsNullOrEmpty(txtDetailsContents.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin nội dung chi tiết", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtSection.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin PIC", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtSortNumber.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin số thứ tự", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtStage.Text.Trim()))
                {
                    MessageBox.Show("Nhập thông tin công đoạn", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Add == true)
                {
                    string querySave = "INSERT INTO TBL_TRIAL_PRODUCTION_MST (MOLD_TYPE, MAIN_CONTENTS, DETAILED_CONTENTS, SORT_NUMBER, STAGE, PIC_SECTION) VALUES (@MOLD_TYPE, @MAIN_CONTENTS, @DETAILED_CONTENTS, @SORT_NUMBER, @STAGE, @PIC_SECTION)";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            cmd.Parameters.AddWithValue("@MOLD_TYPE", Constaint.MoldType);
                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", txtMainContents.Text);
                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", txtDetailsContents.Text);
                            cmd.Parameters.AddWithValue("@SORT_NUMBER", txtSortNumber.Text);
                            cmd.Parameters.AddWithValue("@STAGE", txtStage.Text);
                            cmd.Parameters.AddWithValue("@PIC_SECTION", txtSection.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    string querySave = "UPDATE TBL_TRIAL_PRODUCTION_MST SET MAIN_CONTENTS = @MAIN_CONTENTS, DETAILED_CONTENTS = @DETAILED_CONTENTS, PIC_SECTION = @PIC_SECTION, SORT_NUMBER = @SORT_NUMBER, STAGE = @STAGE  WHERE ID_IDENTITY = @ID_IDENTITY";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_IDENTITY", IDEntity);
                            cmd.Parameters.AddWithValue("@MAIN_CONTENTS", txtMainContents.Text);
                            cmd.Parameters.AddWithValue("@DETAILED_CONTENTS", txtDetailsContents.Text);
                            cmd.Parameters.AddWithValue("@PIC_SECTION", txtSection.Text);
                            cmd.Parameters.AddWithValue("@SORT_NUMBER", Convert.ToInt32(txtSortNumber.Text));
                            cmd.Parameters.AddWithValue("@STAGE", txtStage.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
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