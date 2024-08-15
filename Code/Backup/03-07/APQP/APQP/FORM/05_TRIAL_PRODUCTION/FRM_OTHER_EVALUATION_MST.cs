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
    public partial class FRM_OTHER_EVALUATION_MST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_OTHER_EVALUATION_MST()
        {
            InitializeComponent();
        }

        private void FRM_OTHER_EVALUATION_MST_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_OTHER_EVALUATION_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' ORDER BY SORT_NUMBER ASC";
                DataTable Data = DBUtils._getData(queryData);
                gcData.DataSource = Data;
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
            FRM_ADD_OTHER_EVALUATION f = new FRM_ADD_OTHER_EVALUATION(Add, IDEntity);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận xóa thông tin?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string querySave = "DELETE TBL_OTHER_EVALUATION_MST WHERE ID_IDENTITY = '" + Convert.ToString(gvData.GetFocusedRowCellValue("ID_IDENTITY")) + "'";
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
            FRM_ADD_OTHER_EVALUATION f = new FRM_ADD_OTHER_EVALUATION(Add, IDEntity);
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