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
    public partial class FRM_PREPARATION_TRY_MST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_PREPARATION_TRY_MST()
        {
            InitializeComponent();
        }

        private void FRM_PREPARATION_TRY_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_PREPARATION_TRY_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
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
            bool Add = true;
            int IDEntity = 0;
            FRM_ADD_PREPARATION_TRY f = new FRM_ADD_PREPARATION_TRY(Add, IDEntity);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool Add = false;
            int IDEntity = Convert.ToInt32(gvData.GetFocusedRowCellValue("ID_IDENTITY"));
            FRM_ADD_PREPARATION_TRY f = new FRM_ADD_PREPARATION_TRY(Add, IDEntity);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int IDEntity = Convert.ToInt32(gvData.GetFocusedRowCellValue("ID_IDENTITY"));
                if (IDEntity == 6)
                {
                    MessageBox.Show("Để xóa nội dung này, vui lòng liên hệ bộ phận IT!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận xóa thông tin?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string querySave = "DELETE TBL_PREPARATION_TRY_MST WHERE ID_IDENTITY = '" + IDEntity + "'";
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}