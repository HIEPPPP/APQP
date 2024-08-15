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

namespace APQP.FORM.ADMIN
{
    public partial class FRM_UPDATE_ACCOUNT : DevExpress.XtraEditors.XtraForm
    {
        public FRM_UPDATE_ACCOUNT(int IDEntity)
        {
            this.IDEntity = IDEntity;
            InitializeComponent();
        }
        int IDEntity;
        private void FRM_UPDATE_ACCOUNT_Load(object sender, EventArgs e)
        {
            try
            {
                string queryLoadAccess = "SELECT * FROM TBL_ACCESS";
                DataTable dataAccess = DBUtils._getData(queryLoadAccess);
                txtQuyen.DataSource = dataAccess;
                txtQuyen.ValueMember = "ID_ACCESS";
                txtQuyen.DisplayMember = "ACCESS";
                txtQuyen.SelectedIndex = -1;
                //==================
                string queryLoadSection = "SELECT * FROM TBL_SECTION_MST";
                DataTable dataSection = DBUtils._getData(queryLoadSection);
                txtBoPhan.DataSource = dataSection;
                txtBoPhan.ValueMember = "SECTION_ID";
                txtBoPhan.DisplayMember = "SECTION_SHORT_NAME";
                txtBoPhan.SelectedIndex = -1;
                //=================
                txtNhaMay.SelectedIndex = -1;
                string queryDataMST = "SELECT u.ID_IDENTITY, u.USER_ID, u.FULLNAME, s.SECTION_SHORT_NAME , u.FACTORY , a.ACCESS FROM TBL_ACCOUNT u LEFT JOIN  TBL_SECTION_MST s ON u.SECTION_ID = s.SECTION_ID LEFT JOIN TBL_ACCESS a ON u.ID_ACCESS = a.ID_ACCESS WHERE u.ID_IDENTITY = '" + IDEntity + "'";
                DataTable DataMST = DBUtils._getData(queryDataMST);
                if (DataMST.Rows.Count > 0)
                {
                    txtMaNV.Text = Convert.ToString(DataMST.Rows[0]["USER_ID"]);
                    txtTen.Text = Convert.ToString(DataMST.Rows[0]["FULLNAME"]);
                    txtBoPhan.Text = Convert.ToString(DataMST.Rows[0]["SECTION_SHORT_NAME"]);
                    txtNhaMay.Text = Convert.ToString(DataMST.Rows[0]["FACTORY"]);
                    txtQuyen.Text = Convert.ToString(DataMST.Rows[0]["ACCESS"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận lưu tài khoản?", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(txtMaNV.Text.Trim()))
                    {
                        MessageBox.Show("Mã không được để trống!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaNV.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txtTen.Text.Trim()))
                    {
                        MessageBox.Show("Tên không được để trống!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTen.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txtBoPhan.Text.Trim()))
                    {
                        MessageBox.Show("Bộ phận không được để trống!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(txtNhaMay.Text.Trim()))
                    {
                        MessageBox.Show("Nhà máy không được để trống!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrEmpty(txtQuyen.Text.Trim()))
                    {
                        MessageBox.Show("Quyền không được để trống!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string queryAdd = "UPDATE TBL_ACCOUNT SET FULLNAME = @FULLNAME, USERID_FULLNAME = @USERID_FULLNAME, SECTION_ID = @SECTION_ID, FACTORY = @FACTORY, ID_ACCESS = @ID_ACCESS WHERE ID_IDENTITY = @ID_IDENTITY";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryAdd, _conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_IDENTITY", IDEntity);
                            cmd.Parameters.AddWithValue("@FULLNAME", txtTen.Text);
                            cmd.Parameters.AddWithValue("@USERID_FULLNAME", txtMaNV.Text + "-" + txtTen.Text);
                            cmd.Parameters.AddWithValue("@SECTION_ID", txtBoPhan.SelectedValue);
                            cmd.Parameters.AddWithValue("@FACTORY", txtNhaMay.Text);
                            cmd.Parameters.AddWithValue("@ID_ACCESS", txtQuyen.SelectedValue);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Lưu thành công", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}