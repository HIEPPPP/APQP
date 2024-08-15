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

namespace APQP.FORM._07_FOLLOW_UP
{
    public partial class FRM_FOLLOW_UP : DevExpress.XtraEditors.XtraForm
    {
        public FRM_FOLLOW_UP(string ControlNo)
        {
            this.ControlNo = ControlNo;
            InitializeComponent();
        }
        string ControlNo;



        private void FRM_FOLLOW_UP_Load(object sender, EventArgs e)
        {
            label1.Text = "Follow Up Problems (" + ControlNo + ")";
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_FOLLOW_UP_PROBLEMS WHERE CONTROL_NO = '" + ControlNo + "' ORDER BY CREATE_AT ASC";
                DataTable Data = DBUtils._getData(queryData);
                gcData.DataSource = Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận lưu thông tin!", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //delete 
                    string queryDeleteItems = "DELETE TBL_FOLLOW_UP_PROBLEMS WHERE CONTROL_NO = '" + ControlNo + "'";
                    using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                    {
                        _conn.Open();
                        using (SqlCommand cmd = new SqlCommand(queryDeleteItems, _conn))
                        {
                            int n = cmd.ExecuteNonQuery();
                        }
                    }
                    //Insert TBL_FOLLOW_UP_PROBLEMS
                    for (int i = 0; i < gvData.RowCount; i++)
                    {
                        DataRow row = gvData.GetDataRow(i);
                        string querySave = "INSERT INTO TBL_FOLLOW_UP_PROBLEMS (CONTROL_NO, ITEM, PROBLEMS, COUNTERMEASURES, PIC, DUE_DATE, RESULTS, DONE, UPDATE_AT, UPDATE_BY) " +
                            "VALUES (@CONTROL_NO, @ITEM, @PROBLEMS, @COUNTERMEASURES, @PIC, @DUE_DATE, @RESULTS, @DONE, @UPDATE_AT, @UPDATE_BY)";
                        using (SqlConnection _conn = new SqlConnection(DBUtils._stringConnection))
                        {
                            _conn.Open();
                            using (SqlCommand cmd = new SqlCommand(querySave, _conn))
                            {
                                cmd.Parameters.AddWithValue("@CONTROL_NO", ControlNo);
                                cmd.Parameters.AddWithValue("@ITEM", Convert.ToString(row["ITEM"]));
                                cmd.Parameters.AddWithValue("@PROBLEMS", Convert.ToString(row["PROBLEMS"]));
                                cmd.Parameters.AddWithValue("@COUNTERMEASURES", Convert.ToString(row["COUNTERMEASURES"]));
                                cmd.Parameters.AddWithValue("@PIC", Convert.ToString(row["PIC"]));
                                if (string.IsNullOrEmpty(Convert.ToString(row["DUE_DATE"])))
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@DUE_DATE", Convert.ToDateTime(row["DUE_DATE"]));
                                }
                                cmd.Parameters.AddWithValue("@RESULTS", Convert.ToString(row["RESULTS"]));
                                cmd.Parameters.AddWithValue("@DONE", Convert.ToString(row["DONE"]));
                                cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@UPDATE_BY", Constaint._userID);
                                cmd.ExecuteNonQuery();
                            }
                        }

                    }
                    MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAddRowsBom_Click(object sender, EventArgs e)
        {
            try
            {
                gvData.AddNewRow();
                gvData.Focus();
                //gvData.FocusedRowHandle = GridControl.NewItemRowHandle;
                ////gvData.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                gvData.FocusedColumn = gvData.Columns[0];
                gvData.ShowEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gvData_RowCountChanged(object sender, EventArgs e)
        {
            txtRecord.Text = gvData.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteRowsBom_Click(object sender, EventArgs e)
        {
            gvData.DeleteSelectedRows();
        }
    }
}