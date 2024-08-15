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
    public partial class FRM_ACCOUNT_LIST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_ACCOUNT_LIST()
        {
            InitializeComponent();
        }

        private void FRM_ACCOUNT_LIST_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT u.ID_IDENTITY, u.USER_ID, u.FULLNAME, s.SECTION_SHORT_NAME , u.FACTORY , a.ACCESS FROM TBL_ACCOUNT u LEFT JOIN  TBL_SECTION_MST s ON u.SECTION_ID = s.SECTION_ID LEFT JOIN TBL_ACCESS a ON u.ID_ACCESS = a.ID_ACCESS";
                DataTable data = DBUtils._getData(queryData);
                gcData.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRM_ADD_ACCOUNT f = new FRM_ADD_ACCOUNT();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận xóa thông tin?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string querySave = "DELETE TBL_ACCOUNT WHERE ID_IDENTITY = '" + Convert.ToString(gvData.GetFocusedRowCellValue("ID_IDENTITY")) + "'";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            int n = cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int IDEntity = Convert.ToInt32(gvData.GetFocusedRowCellValue("ID_IDENTITY"));
            FRM_UPDATE_ACCOUNT f = new FRM_UPDATE_ACCOUNT(IDEntity);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            int IDEntity = Convert.ToInt32(gvData.GetFocusedRowCellValue("ID_IDENTITY"));
            FRM_CHANGE_PASSWORD f = new FRM_CHANGE_PASSWORD(IDEntity);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}