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
using APQP.DTO;

namespace APQP.FORM
{
    public partial class FRM_LOGIN : DevExpress.XtraEditors.XtraForm
    {
        public FRM_LOGIN()
        {
            InitializeComponent();
        }
        UserDTO _userDTO = new UserDTO();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtMoldType.Text == "Connector")
                //{
                //    DBUtils._stringConnection = @"Data Source=172.17.140.55;Initial Catalog=APQP_CON;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
                //}
                //if (txtMoldType.Text == "Terminal")
                //{
                //    DBUtils._stringConnection = @"Data Source=172.16.253.2;Initial Catalog=APQP;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
                //}
                string _userID = txtUser.Text.Trim();
                string _pass = txtPassword.Text.Trim();
                string _MoldType = txtMoldType.Text;
                if (string.IsNullOrEmpty(_userID))
                {
                    MessageBox.Show("Account can not be blank!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtMoldType.Text.Trim()))
                {
                    MessageBox.Show("Select mold type!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!string.IsNullOrEmpty(_userID))
                {
                    DataTable _data;
                    double _exsitsUser = 0;
                    string _query = "SELECT COUNT(*) as exsitsUser FROM TBL_ACCOUNT WHERE USER_ID='" + _userID + "'";
                    _data = DBUtils._getData(_query);
                    if (_data.Rows.Count > 0 && _data != null)
                    {
                        _exsitsUser = Convert.ToDouble(_data.Rows[0]["exsitsUser"]);
                        if (_exsitsUser <= 0)
                        {
                            MessageBox.Show("Account does not exist!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUser.Focus();
                            txtUser.SelectAll();
                            return;
                        }
                        else
                        {
                            txtPassword.Focus();
                        }
                    }
                }
                if (string.IsNullOrEmpty(_pass))
                {
                    MessageBox.Show("Password can not be blank!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (!string.IsNullOrEmpty(_userID) && !string.IsNullOrEmpty(_pass))
                {
                    try
                    {
                        bool _checkLogin = _userDTO._loginUser(_userID, _pass, _MoldType);
                        if (_checkLogin == true)
                        {
                            FRM_MAIN _main = new FRM_MAIN();
                            _main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect password!", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Focus();
                            txtPassword.SelectAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), _userID);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Đã sảy ra lỗi khi đăng nhập!\nLiên hệ bộ phận IT để được hỗ trợ!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FRM_LOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {
            txtMoldType.SelectedIndex = -1;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}