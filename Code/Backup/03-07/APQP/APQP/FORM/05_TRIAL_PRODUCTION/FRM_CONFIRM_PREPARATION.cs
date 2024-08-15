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
    public partial class FRM_CONFIRM_PREPARATION : DevExpress.XtraEditors.XtraForm
    {
        public FRM_CONFIRM_PREPARATION(string ControlNo, string Stage, int CountTrial, string ProductType)
        {
            this.ProductType = ProductType;
            this.ControlNo = ControlNo;
            this.Stage = Stage;
            this.CountTrial = CountTrial;
            InitializeComponent();
        }
        string ProductType;
        string ControlNo;
        string Stage;
        int CountTrial;

        private void FRM_CONFIRM_PREPARATION_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryDataPreparation = "SELECT * FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = '" + Stage + "'";
                DataTable dataPreparation = DBUtils._getData(queryDataPreparation);
                gcData.DataSource = dataPreparation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnConfirmTrial_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvData.RowCount; i++)
                {
                    DataRow row = gvData.GetDataRow(i);
                    if (string.IsNullOrEmpty(Convert.ToString(row["PLAN_START"])) || string.IsNullOrEmpty(Convert.ToString(row["PLAN_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_START"])) || string.IsNullOrEmpty(Convert.ToString(row["ACTUAL_COMPLETE"])) || string.IsNullOrEmpty(Convert.ToString(row["ATTACHED_FILE"])))
                    {
                        MessageBox.Show("Thông tin chưa được nhập đầy đủ, không thể xác nhận kiểm tra!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin!", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (txtJudgement.Text == "OK")
                    {
                        for (int i = 0; i < gvData.RowCount; i++)
                        {
                            DataRow row = gvData.GetDataRow(i);
                            string queryConfirm = "UPDATE TBL_PREPARATION_TRY SET STATUS_PREPARATION_TRY = @STATUS_PREPARATION_TRY WHERE ID_IDENTITY = @ID_IDENTITY";
                            using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                            {
                                _conn.Open();
                                using (SqlCommand cmd = new SqlCommand(queryConfirm, _conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID_IDENTITY", Convert.ToString(row["ID_IDENTITY"]));
                                    cmd.Parameters.AddWithValue("@STATUS_PREPARATION_TRY", "02");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        MessageBox.Show("Xác nhận thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}