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

namespace APQP.FORM._03._FEASIBILITY
{
    public partial class FRM_FEASIBILITY_MST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_FEASIBILITY_MST()
        {
            InitializeComponent();
        }

        private void FRM_FEASIBILITY_MST_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string queryData = "SELECT * FROM TBL_FEASIBILITY_MST WHERE MOLD_TYPE = '"+Constaint.MoldType +"' ORDER BY SORT_NUMBER ASC";
            DataTable data = DBUtils._getData(queryData);
            gcData.DataSource = data;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool Add = true;
            int IDEntity = 0;
            FRM_ADD_FEASIBILITY_MST f = new FRM_ADD_FEASIBILITY_MST(Add, IDEntity);
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
                if (IDEntity == 2)
                {
                    MessageBox.Show("Để xóa nội dung này, vui lòng liên hệ bộ phận IT!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận xóa thông tin?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string querySave = "DELETE TBL_FEASIBILITY_MST WHERE ID_IDENTITY = '" + IDEntity + "'";
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
            if (IDEntity == 2)
            {
                MessageBox.Show("Để sửa nội dung này, vui lòng liên hệ bộ phận IT!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FRM_ADD_FEASIBILITY_MST f = new FRM_ADD_FEASIBILITY_MST(Add, IDEntity);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}