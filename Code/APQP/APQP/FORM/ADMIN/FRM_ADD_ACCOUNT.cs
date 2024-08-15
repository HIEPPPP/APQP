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
    public partial class FRM_ADD_ACCOUNT : DevExpress.XtraEditors.XtraForm
    {
        public FRM_ADD_ACCOUNT()
        {
            InitializeComponent();
        }
        private void FRM_ADD_ACCOUNT_Load(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return;
                }
                if (txtMatKhau.Text != txtMatKhau2.Text)
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                String queryCheck = "SELECT * FROM TBL_ACCOUNT WHERE USER_ID = '" + txtMaNV.Text + "'";
                DataTable dataCheck = DBUtils._getData(queryCheck);
                DialogResult result = MessageBox.Show("Xác nhận đăng ký tài khoản?", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (dataCheck.Rows.Count > 0)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string queryAdd = "INSERT INTO TBL_ACCOUNT (USER_ID, FULLNAME, USERID_FULLNAME, PASSWORD, SECTION_ID, FACTORY, ID_ACCESS, CREATE_AT) " +
                        "VALUES (@USER_ID, @FULLNAME, @USERID_FULLNAME, @PASSWORD, @SECTION_ID, @FACTORY, @ID_ACCESS, @CREATE_AT)";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryAdd, _conn))
                        {
                            cmd.Parameters.AddWithValue("@USER_ID", txtMaNV.Text);
                            cmd.Parameters.AddWithValue("@FULLNAME", txtTen.Text);
                            cmd.Parameters.AddWithValue("@USERID_FULLNAME", txtMaNV.Text + "-" + txtTen.Text);
                            cmd.Parameters.AddWithValue("@PASSWORD", Constaint._createMD5(txtMatKhau.Text));
                            cmd.Parameters.AddWithValue("@SECTION_ID", txtBoPhan.SelectedValue);
                            cmd.Parameters.AddWithValue("@FACTORY", txtNhaMay.Text);
                            cmd.Parameters.AddWithValue("@ID_ACCESS", txtQuyen.SelectedValue);
                            cmd.Parameters.AddWithValue("@CREATE_AT", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Đăng ký thành công", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
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