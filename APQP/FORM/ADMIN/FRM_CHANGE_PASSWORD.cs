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
    public partial class FRM_CHANGE_PASSWORD : DevExpress.XtraEditors.XtraForm
    {
        public FRM_CHANGE_PASSWORD(int IDEntity)
        {
            this.IDEntity = IDEntity;
            InitializeComponent();
        }
        int IDEntity;
        private void FRM_CHANGE_PASSWORD_Load(object sender, EventArgs e)
        {
            try
            {
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
                    if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
                    {
                        MessageBox.Show("Mật khẩu không được để trống!", "CHANGE PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMatKhau.Focus();
                        return;
                    }
                    if (txtMatKhau2.Text != txtMatKhau.Text)
                    {
                        MessageBox.Show("Mật khẩu nhập lại không đúng!", "CHANGE PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMatKhau2.Focus();
                        txtMatKhau2.SelectAll();
                        return;
                    }
                    string queryAdd = "UPDATE TBL_ACCOUNT SET PASSWORD = @PASSWORD WHERE ID_IDENTITY = @ID_IDENTITY";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryAdd, _conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_IDENTITY", IDEntity);
                            cmd.Parameters.AddWithValue("@PASSWORD", Constaint._md5(txtMatKhau2.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }
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