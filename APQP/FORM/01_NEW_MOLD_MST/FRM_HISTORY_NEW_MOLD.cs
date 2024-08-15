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
using DevExpress.XtraGrid.Views.Grid;
using APQP.FORM._04._PREPARATION;
using APQP.FORM._07_FOLLOW_UP;
using APQP.FORM._06._MASS_PRODUCTION;
using APQP.FORM._05_TRIAL_PRODUCTION;
using APQP.FORM._03._FEASIBILITY;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using APQP.FORM._04_PREPARATION;

namespace APQP.FORM._01_NEW_MOLD_MST
{
    public partial class FRM_HISTORY_NEW_MOLD : DevExpress.XtraEditors.XtraForm
    {
        public FRM_HISTORY_NEW_MOLD()
        {
            InitializeComponent();
        }

        private void FRM_HISTORY_NEW_MOLD_Load(object sender, EventArgs e)
        {
            if (Constaint.MoldType == "Connector")
            {
                gvData.Columns["TRIAL_MP"].Visible = false;
            }
            if (Constaint.MoldType == "Terminal")
            {
                gvData.Columns["TRIAL_ASSY"].Visible = false;
                gvData.Columns["TRIAL_IM"].Visible = false;
            }
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND STEP_CODE = '07' ORDER BY CONTROL_NO ASC";
                DataTable data = DBUtils._getData(queryData);
                gcData.DataSource = data;
                lbMoldType.Text = "New mold history (" + Constaint.MoldType + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle >= 0)
                {

                    string Produc = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PRODUCT_INFORMATION"]));
                    if (Produc != "Wait" && Produc != "Finish")
                    {
                        if (e.Column.FieldName == "PRODUCT_INFORMATION")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (Produc == "Finish")
                    {
                        if (e.Column.FieldName == "PRODUCT_INFORMATION")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (Produc.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "PRODUCT_INFORMATION")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUE_DATE_PRODUCT_INFORMATION"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        string controlno = Convert.ToString(row["CONTROL_NO"]);
                        string date = Convert.ToString(row["DUE_DATE_PRODUCT_INFORMATION"]);
                        if (row["DUE_DATE_PRODUCT_INFORMATION"] != DBNull.Value)
                        {
                            DateTime Plant = Convert.ToDateTime(row["DUE_DATE_PRODUCT_INFORMATION"]);
                            TimeSpan time = Plant - now;
                            if (time.Days < 0)
                            {
                                if (Produc != "Wait" && Produc != "Finish")
                                {
                                    if (e.Column.FieldName == "PRODUCT_INFORMATION")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string Feasibility = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["FEASIBILITY"]));
                    if (!Feasibility.Contains("Wait") && !Feasibility.Contains("Finish"))
                    {
                        if (e.Column.FieldName == "FEASIBILITY")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (Feasibility == "Finish")
                    {
                        if (e.Column.FieldName == "FEASIBILITY")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (Feasibility.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "FEASIBILITY")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUE_DATE_FEASIBILITY"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        string controlno = Convert.ToString(row["CONTROL_NO"]);
                        string date = Convert.ToString(row["DUE_DATE_FEASIBILITY"]);
                        if (row["DUE_DATE_FEASIBILITY"] != DBNull.Value)
                        {
                            DateTime Plan = Convert.ToDateTime(row["DUE_DATE_FEASIBILITY"]);
                            TimeSpan time = Plan - now;
                            if (time.Days < 0)
                            {
                                if (!Feasibility.Contains("Wait") && !Feasibility.Contains("Finish"))
                                {
                                    if (e.Column.FieldName == "FEASIBILITY")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string Preparation = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["PREPARATION"]));
                    if (!Preparation.Contains("Wait") && !Preparation.Contains("Finish"))
                    {
                        if (e.Column.FieldName == "PREPARATION")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (Preparation == "Finish")
                    {
                        if (e.Column.FieldName == "PREPARATION")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (Preparation.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "PREPARATION")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUE_DATE_PREPARATION"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        if (row["DUE_DATE_PREPARATION"] != DBNull.Value)
                        {
                            DateTime Plant = Convert.ToDateTime(row["DUE_DATE_PREPARATION"]);
                            TimeSpan time = Plant - now;
                            if (time.Days < 0)
                            {
                                if (!Preparation.Contains("Wait") && !Preparation.Contains("Finish"))
                                {
                                    if (e.Column.FieldName == "PREPARATION")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string TryIM = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_IM"]));
                    if (!TryIM.Contains("Wait") && !TryIM.Contains("Finish"))
                    {
                        if (e.Column.FieldName == "TRIAL_IM")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (TryIM == "Finish")
                    {
                        if (e.Column.FieldName == "TRIAL_IM")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (TryIM.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "TRIAL_IM")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUE_DATE_TRIAL_PRODUCTION"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        if (row["DUE_DATE_TRIAL_PRODUCTION"] != DBNull.Value)
                        {
                            DateTime Plant = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"]);
                            TimeSpan time = Plant - now;
                            if (time.Days < 0)
                            {
                                if (!TryIM.Contains("Wait") && !TryIM.Contains("Finish"))
                                {
                                    if (e.Column.FieldName == "TRIAL_IM")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string TryASSY = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_ASSY"]));
                    if (!TryASSY.Contains("Wait") && !TryASSY.Contains("Finish"))
                    {
                        if (e.Column.FieldName == "TRIAL_ASSY")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (TryASSY == "Finish")
                    {
                        if (e.Column.FieldName == "TRIAL_ASSY")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (TryASSY.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "TRIAL_ASSY")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (TryASSY.Contains("N/A"))
                    {
                        if (e.Column.FieldName == "TRIAL_ASSY")
                        {
                            e.Appearance.BackColor = Color.LightGray;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUE_DATE_TRIAL_PRODUCTION"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        if (row["DUE_DATE_TRIAL_PRODUCTION"] != DBNull.Value)
                        {
                            DateTime Plant = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"]);
                            TimeSpan time = Plant - now;
                            if (time.Days < 0)
                            {
                                if (!TryASSY.Contains("Wait") && !TryASSY.Contains("Finish") && !TryASSY.Contains("N/A"))
                                {
                                    if (e.Column.FieldName == "TRIAL_ASSY")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string TryPK = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_PK"]));
                    if (!TryPK.Contains("Wait") && !TryPK.Contains("Finish"))
                    {
                        if (e.Column.FieldName == "TRIAL_PK")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (TryPK == "Finish")
                    {
                        if (e.Column.FieldName == "TRIAL_PK")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (TryPK.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "TRIAL_PK")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUE_DATE_TRIAL_PRODUCTION"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        if (row["DUE_DATE_TRIAL_PRODUCTION"] != DBNull.Value)
                        {
                            DateTime Plant = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"]);
                            TimeSpan time = Plant - now;
                            if (time.Days < 0)
                            {
                                if (!TryPK.Contains("Wait") && !TryPK.Contains("Finish"))
                                {
                                    if (e.Column.FieldName == "TRIAL_PK")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string TryMP = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_MP"]));
                    if (!TryPK.Contains("Wait") && !TryPK.Contains("Finish"))
                    {
                        if (e.Column.FieldName == "TRIAL_MP")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (TryPK == "Finish")
                    {
                        if (e.Column.FieldName == "TRIAL_MP")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (TryPK.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "TRIAL_MP")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUE_DATE_TRIAL_PRODUCTION"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        if (row["DUE_DATE_TRIAL_PRODUCTION"] != DBNull.Value)
                        {
                            DateTime Plant = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"]);
                            TimeSpan time = Plant - now;
                            if (time.Days < 0)
                            {
                                if (!TryPK.Contains("Wait") && !TryPK.Contains("Finish"))
                                {
                                    if (e.Column.FieldName == "TRIAL_PK")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string ConfirmTry = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["TRIAL_CONFIRMATION"]));
                    if (!ConfirmTry.Contains("Wait") && !ConfirmTry.Contains("Finish"))
                    {
                        if (e.Column.FieldName == "TRIAL_CONFIRMATION")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (ConfirmTry == "Finish")
                    {
                        if (e.Column.FieldName == "TRIAL_CONFIRMATION")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (ConfirmTry.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "TRIAL_CONFIRMATION")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUE_DATE_TRIAL_PRODUCTION"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        if (row["DUE_DATE_TRIAL_PRODUCTION"] != DBNull.Value)
                        {
                            DateTime Plant = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"]);
                            TimeSpan time = Plant - now;
                            if (time.Days < 0)
                            {
                                if (!ConfirmTry.Contains("Wait") && !ConfirmTry.Contains("Finish"))
                                {
                                    if (e.Column.FieldName == "TRIAL_CONFIRMATION")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string Mass_production = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["MASS_PRODUCTION"]));
                    if (!Mass_production.Contains("Wait") || !Mass_production.Contains("Finish"))
                    {
                        if (e.Column.FieldName == "MASS_PRODUCTION")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (Mass_production == "Finish")
                    {
                        if (e.Column.FieldName == "MASS_PRODUCTION")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                    if (Mass_production.Contains("Wait"))
                    {
                        if (e.Column.FieldName == "MASS_PRODUCTION")
                        {
                            e.Appearance.BackColor = Color.Aquamarine;
                        }
                    }
                    if (gvData.GetRowCellValue(e.RowHandle, gvData.Columns["DUA_DATE_MASS_PRODUCTION"]) != DBNull.Value)
                    {
                        DateTime now = DateTime.Now;
                        DataRow row = gvData.GetDataRow(e.RowHandle);
                        if (row["DUA_DATE_MASS_PRODUCTION"] != DBNull.Value)
                        {
                            DateTime Plant = Convert.ToDateTime(row["DUA_DATE_MASS_PRODUCTION"]);
                            TimeSpan time = Plant - now;
                            if (time.Days < 0)
                            {
                                if (!Mass_production.Contains("Wait") && !Mass_production.Contains("Finish"))
                                {
                                    if (e.Column.FieldName == "MASS_PRODUCTION")
                                    {
                                        e.Appearance.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    string FOLLOW_UP = Convert.ToString(gvData.GetRowCellValue(e.RowHandle, gvData.Columns["FOLLOW_UP"]));
                    if (FOLLOW_UP == "Processing")
                    {
                        if (e.Column.FieldName == "FOLLOW_UP")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                    }
                    if (FOLLOW_UP == "Finish")
                    {
                        if (e.Column.FieldName == "FOLLOW_UP")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void gvData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string ControlNo = Convert.ToString(gvData.GetFocusedRowCellValue("CONTROL_NO"));
                DXMouseEventArgs ea = e as DXMouseEventArgs;
                GridView view = sender as GridView;
                GridHitInfo info = view.CalcHitInfo(ea.Location);
                string ProductType = Convert.ToString(gvData.GetFocusedRowCellValue("PRODUCT_TYPE"));
                if (info.InRow || info.InRowCell)
                {
                    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    if (colCaption == "Product info")
                    {

                        PRODUCT_INFO.FRM_PRODUCT_INFO f = new PRODUCT_INFO.FRM_PRODUCT_INFO(ControlNo);
                        f.ShowDialog();
                    }
                    else if (colCaption == "Feasibility")
                    {
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("PRODUCT_INFORMATION"));
                        if (Status == "Finish")
                        {
                            FRM_FEASIBILITY f = new FRM_FEASIBILITY(ControlNo);
                            f.ShowDialog();
                        }
                    }
                    else if (colCaption == "Preparation")
                    {
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("FEASIBILITY"));
                        if (Status == "Finish")
                        {
                            FRM_PREPARATION f = new FRM_PREPARATION(ControlNo, ProductType);
                            f.ShowDialog();
                        }
                    }
                    else if (colCaption == "Try Injection")
                    {
                        string Stage = "IM";
                        int CoutTrialIM = Convert.ToInt32(gvData.GetFocusedRowCellValue("COUNT_TRIAL_IM"));
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("TRIAL_IM"));
                        if (!Status.Contains("Wait"))
                        {
                            FRM_PREPARATION_TRY_STAGE f = new FRM_PREPARATION_TRY_STAGE(ControlNo, Stage, ProductType);
                            f.ShowDialog();
                        }
                    }
                    else if (colCaption == "Try Assy")
                    {
                        string Stage = "ASSY";
                        int CoutTrialASSY = Convert.ToInt32(gvData.GetFocusedRowCellValue("COUNT_TRIAL_ASSY"));
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("TRIAL_ASSY"));
                        if (!Status.Contains("Wait") && !Status.Contains("N/A"))
                        {
                            FRM_PREPARATION_TRY_STAGE f = new FRM_PREPARATION_TRY_STAGE(ControlNo, Stage, ProductType);
                            f.ShowDialog();
                        }
                    }
                    else if (colCaption == "Try Packing")
                    {
                        string Stage = "PK";
                        int CoutTrialPK = Convert.ToInt32(gvData.GetFocusedRowCellValue("COUNT_TRIAL_PK"));
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("TRIAL_PK"));
                        if (!Status.Contains("Wait"))
                        {
                            FRM_PREPARATION_TRY_STAGE f = new FRM_PREPARATION_TRY_STAGE(ControlNo, Stage, ProductType);
                            f.ShowDialog();
                        }
                    }
                    else if (colCaption == "Try MP")
                    {
                        string Stage = "MP";
                        int CoutTrialMP = Convert.ToInt32(gvData.GetFocusedRowCellValue("COUNT_TRIAL_MP"));
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("TRIAL_MP"));
                        if (!Status.Contains("Wait") && !Status.Contains("N/A"))
                        {
                            FRM_PREPARATION_TRY_STAGE f = new FRM_PREPARATION_TRY_STAGE(ControlNo, Stage, ProductType);
                            f.ShowDialog();
                        }
                    }
                    else if (colCaption == "Try Confirmation")
                    {
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("TRIAL_CONFIRMATION"));
                        if (!Status.Contains("Wait"))
                        {
                            FRM_TRIAL_CONFIRMATION f = new FRM_TRIAL_CONFIRMATION(ControlNo);
                            f.ShowDialog();
                        }
                    }

                    else if (colCaption == "Mass production")
                    {
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("TRIAL_CONFIRMATION"));
                        if (!Status.Contains("Wait") && !Status.Contains("N/A"))
                        {
                            FRM_MASS_PRODUCTION f = new FRM_MASS_PRODUCTION(ControlNo);
                            f.ShowDialog();
                        }
                    }
                    else if (colCaption == "Follow up")
                    {
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue(""));
                        FRM_FOLLOW_UP f = new FRM_FOLLOW_UP(ControlNo);
                        f.ShowDialog();
                    }
                }
                btnRefresh_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void gvData_RowCountChanged(object sender, EventArgs e)
        {
            txtRecord.Text = gvData.RowCount.ToString();
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvData, gcData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}