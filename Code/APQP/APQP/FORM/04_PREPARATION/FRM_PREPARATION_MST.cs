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
using APQP.FORM._03_FEASIBILITY;
using System.Data.SqlClient;
using APQP.FORM._04_PREPARATION;

namespace APQP.FORM._04._PREPARATION
{
    public partial class FRM_PREPARATION_MST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_PREPARATION_MST()
        {
            InitializeComponent();
        }

        private void FRM_PREPARATION_MST_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_PREPARATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                DataTable data = DBUtils._getData(queryData);
                gcData.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    string querySave = "DELETE TBL_PREPARATION_MST WHERE ID_IDENTITY = '" + IDEntity + "'";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                        {
                            int n = cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Xóa thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
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
            bool Add = false;
            int IDEntity = Convert.ToInt32(gvData.GetFocusedRowCellValue("ID_IDENTITY"));
            if (IDEntity == 6)
            {
                MessageBox.Show("Để sửa nội dung này, vui lòng liên hệ bộ phận IT!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_ADD_PREPARATION_MST f = new FRM_ADD_PREPARATION_MST(Add, IDEntity);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool Add = true;
            int IDEntity = 0;
            FRM_ADD_PREPARATION_MST f = new FRM_ADD_PREPARATION_MST(Add, IDEntity);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gcData_Click(object sender, EventArgs e)
        {

        }
    }
}