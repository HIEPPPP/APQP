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
using APQP.FORM._03._FEASIBILITY;
using APQP.FORM._04._PREPARATION;
using APQP.FORM._06._MASS_PRODUCTION;
using APQP.FORM._05_TRIAL_PRODUCTION;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using APQP.FORM._07_FOLLOW_UP;
using APQP.FORM._04_PREPARATION;

namespace APQP.FORM.NEW_MOLD_MST
{
    public partial class FRM_NEW_MOLD_LIST : DevExpress.XtraEditors.XtraForm
    {
        public FRM_NEW_MOLD_LIST()
        {
            InitializeComponent();
        }

        private void FRM_NEW_MOLD_LIST_Load(object sender, EventArgs e)
        {

            gvData.Columns["TRIAL_PRODUCTION"].Visible = false;
            if (Constaint._access == "01" || Constaint._sectionShort == "QA")
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
            }
            if (Constaint._sectionShort == "PC" || Constaint._sectionShort == "MM" || Constaint._sectionShort == "DM")
            {
                btnUpdate.Enabled = true;
            }
            if (Constaint._access == "01")
            {
                btnUpdate.Enabled = true;
            }
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
            //LoadSection();

        }
        private void LoadData()
        {
            try
            {
                // cần lấy cột nào lấy ra cột đó thôi nhé
                string queryData = "SELECT * FROM TBL_NEW_MOLD_MST WHERE MOLD_TYPE = '" + Constaint.MoldType + "' AND STEP_CODE != '07' AND STATUS_DELETE = '0' ORDER BY CONTROL_NO ASC";
                DataTable data = DBUtils._getData(queryData);
                gcData.DataSource = data;
                lbMoldType.Text = "New mold list (" + Constaint.MoldType + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //DateTime DueDateProductInfo;
        //DateTime DueDateFeasibility;
        //DateTime DueDatePreparation;
        //DateTime DueDateTrial;
        DateTime DueDateMass;
        string queryDataSection = string.Empty;
        DataTable dataSection = new DataTable();
        // load tên bộ phận chưa nhập thông tin
        //private void LoadSection()
        //{
        //    try
        //    {
        //        string PRODUCTINFO = string.Empty;
        //        string FEASIBILITY = string.Empty;
        //        string PREPARATION = string.Empty;
        //        string TRIAL_IM = string.Empty;
        //        string TRIAL_ASSY = string.Empty;
        //        string TRIAL_PK = string.Empty;
        //        string TRIAL_MP = string.Empty;
        //        string TRIAL_CONFIRMATION = string.Empty;
        //        string MASS_PRODUCTION = string.Empty;
        //        for (int i = 0; i < gvData.RowCount; i++)
        //        {
        //            DataRow row = gvData.GetDataRow(i);
        //            string ControlNo = row["CONTROL_NO"].ToString();
        //            //PRODUCTINFO = row["PRODUCT_INFORMATION"].ToString();
        //            //if (PRODUCTINFO == "Processing")
        //            //{
        //            //    string Section = string.Empty;
        //            //    string DueDate = string.Empty;

        //            //    string queryDataBom = "SELECT * FROM TBL_BOM_INFOMRATION WHERE CONTROL_NO = '" + ControlNo + "'";
        //            //    // giảm số lượng select * from , cần trường dư liệu gì thì select
        //            //    DataTable dataBom = DBUtils._getData(queryDataBom);
        //            //    ////lấy tên bộ phận chưa nhập đủ
        //            //    queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_INSERT_VALUES_BOM_INFO  WHERE CONTROL_NO = '" + ControlNo + "' AND LEN(RTRIM(VALUES_INPUT)) = 0";
        //            //    dataSection = DBUtils._getData(queryDataSection);
        //            //    if (!string.IsNullOrEmpty(row["DUE_DATE_PRODUCT_INFORMATION"].ToString()))
        //            //    {
        //            //        DueDateProductInfo = Convert.ToDateTime(row["DUE_DATE_PRODUCT_INFORMATION"].ToString());
        //            //        DueDate = DueDateProductInfo.ToString("dd/MMM");
        //            //    }
        //            //    if (dataSection.Rows.Count > 0)
        //            //    {
        //            //        string a;
        //            //        for (int j = 0; j < dataSection.Rows.Count; j++)
        //            //        {
        //            //            Section = Section + ", " + Convert.ToString(dataSection.Rows[j]["PIC_SECTION"]);
        //            //        }
        //            //        if (!string.IsNullOrEmpty(DueDate))
        //            //        {
        //            //            a = Section.Substring(2) + "-" + DueDate;
        //            //        }
        //            //        else
        //            //        {
        //            //            a = Section.Substring(2);
        //            //        }

        //            //        gvData.SetRowCellValue(i, gvData.Columns["PRODUCT_INFORMATION"], a);
        //            //    }
        //            //    if (dataBom.Rows.Count <= 0)
        //            //    {
        //            //        gvData.SetRowCellValue(i, gvData.Columns["PRODUCT_INFORMATION"], "QA" + "-" + DueDate);
        //            //    }
        //            //    if (dataSection.Rows.Count <= 0 && dataBom.Rows.Count > 0)
        //            //    {
        //            //        gvData.SetRowCellValue(i, gvData.Columns["PRODUCT_INFORMATION"], "Processing" + "-" + DueDate);
        //            //    }
        //            //}
        //            //FEASIBILITY = row["FEASIBILITY"].ToString(); /*Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns["FEASIBILITY"]));*/
        //            //if (FEASIBILITY == "Processing" || FEASIBILITY == "Wait")
        //            //{
        //            //    string DueDate = string.Empty;
        //            //    queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS FEASIBILITY FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_FEASIBILITY WHERE CONTROL_NO = '" + ControlNo + "' AND ID_SITUATION != '02' AND ID_SITUATION != '03' AND (DATE_ORDER_EQUIPMENT is null or DATE_RECEIVE_EQUIPMENT is null or LEN(RTRIM(ID_SITUATION)) = 0 or LEN(RTRIM(DETAILS_PREPARED)) = 0) GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
        //            //    dataSection = DBUtils._getData(queryDataSection);
        //            //    if (!string.IsNullOrEmpty(row["DUE_DATE_FEASIBILITY"].ToString()))
        //            //    {
        //            //        DueDateFeasibility = Convert.ToDateTime(row["DUE_DATE_FEASIBILITY"].ToString());
        //            //        DueDate = DueDateFeasibility.ToString("dd/MMM");
        //            //    }
        //            //    if (FEASIBILITY == "Processing")
        //            //    {
        //            //        if (dataSection.Rows.Count > 0)
        //            //        {

        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["FEASIBILITY"], Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]) + "-" + DueDate);
        //            //            }
        //            //            else
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["FEASIBILITY"], Convert.ToString(dataSection.Rows[0]["FEASIBILITY"]));
        //            //            }
        //            //        }
        //            //        else
        //            //        {
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["FEASIBILITY"], "Processing" + "-" + DueDate);
        //            //            }
        //            //        }
        //            //    }
        //            //    if (FEASIBILITY == "Wait")
        //            //    {
        //            //        if (!string.IsNullOrEmpty(DueDate))
        //            //        {
        //            //            gvData.SetRowCellValue(i, gvData.Columns["FEASIBILITY"], "Wait" + "-" + DueDate);
        //            //        }
        //            //    }
        //            //}
        //            //PREPARATION = Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns["PREPARATION"]));
        //            //if (PREPARATION == "Processing" || PREPARATION == "Wait")
        //            //{
        //            //    string DueDate = string.Empty;
        //            //    queryDataSection = "SELECT t.CONTROL_NO, string_agg(t.PIC_SECTION, ', ') AS PREPARATION FROM (SELECT CONTROL_NO, PIC_SECTION from TBL_PREPARATION WHERE CONTROL_NO = '" + ControlNo + "' AND STATUS_DELETE = '0' AND (PLAN_START is null or PLAN_COMPLETE is null or  ACTUAL_START is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0) GROUP BY CONTROL_NO, PIC_SECTION ) AS t GROUP BY CONTROL_NO";
        //            //    dataSection = DBUtils._getData(queryDataSection);
        //            //    if (!string.IsNullOrEmpty(row["DUE_DATE_PREPARATION"].ToString()))
        //            //    {
        //            //        DueDatePreparation = Convert.ToDateTime(row["DUE_DATE_PREPARATION"].ToString());
        //            //        DueDate = DueDatePreparation.ToString("dd/MMM");
        //            //    }
        //            //    if (PREPARATION == "Processing")
        //            //    {
        //            //        if (dataSection.Rows.Count > 0)
        //            //        {
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["PREPARATION"], Convert.ToString(dataSection.Rows[0]["PREPARATION"]) + "-" + DueDate);
        //            //            }
        //            //            else
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["PREPARATION"], Convert.ToString(dataSection.Rows[0]["PREPARATION"]));
        //            //            }
        //            //        }
        //            //        else
        //            //        {
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["PREPARATION"], "Processing" + "-" + DueDate);
        //            //            }
        //            //        }
        //            //    }
        //            //    if (PREPARATION == "Wait")
        //            //    {
        //            //        if (!string.IsNullOrEmpty(DueDate))
        //            //        {
        //            //            gvData.SetRowCellValue(i, gvData.Columns["PREPARATION"], "Wait" + "-" + DueDate);
        //            //        }
        //            //    }
        //            //}
        //            //TRIAL_IM 
        //            //TRIAL_IM = row["TRIAL_IM"].ToString();
        //            //if (TRIAL_IM == "Processing" || TRIAL_IM == "Wait")
        //            //{
        //            //    string DueDate = string.Empty;
        //            //    string sectionRemain = string.Empty;
        //            //    queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
        //            //    dataSection = DBUtils._getData(queryDataSection);

        //            //    string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION  WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'IM' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
        //            //    DataTable data2 = DBUtils._getData(queryData2);

        //            //    dataSection.Merge(data2);

        //            //    if (!string.IsNullOrEmpty(row["DUE_DATE_TRIAL_PRODUCTION"].ToString()))
        //            //    {
        //            //        DueDateTrial = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"].ToString());
        //            //        DueDate = DueDateTrial.ToString("dd/MMM");
        //            //    }
        //            //    var sectionRemainList = (from r in dataSection.AsEnumerable()
        //            //                             select r["PIC_SECTION"]).Distinct().ToList();
        //            //    if (TRIAL_IM == "Processing")
        //            //    {
        //            //        if (sectionRemainList.Count > 0)
        //            //        {
        //            //            foreach (var section in sectionRemainList)
        //            //            {
        //            //                sectionRemain = sectionRemain + ", " + section;
        //            //            }
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2) + "-" + DueDate;
        //            //            }
        //            //            else
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2);
        //            //            }
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_IM"], sectionRemain);
        //            //        }
        //            //        else
        //            //        {
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["TRIAL_IM"], "Processing" + "-" + DueDate);
        //            //            }
        //            //        }
        //            //    }
        //            //    if (TRIAL_IM == "Wait")
        //            //    {
        //            //        if (!string.IsNullOrEmpty(DueDate))
        //            //        {
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_IM"], "Wait" + "-" + DueDate);
        //            //        }
        //            //    }
        //            //}
        //            //TRIAL_ASSY
        //            //TRIAL_ASSY = row["TRIAL_ASSY"].ToString();
        //            //if (TRIAL_ASSY == "Processing" || TRIAL_ASSY == "Wait")
        //            //{
        //            //    string DueDate3 = string.Empty;
        //            //    string sectionRemain = string.Empty;
        //            //    queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
        //            //    dataSection = DBUtils._getData(queryDataSection);

        //            //    string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION  WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'ASSY' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
        //            //    DataTable data2 = DBUtils._getData(queryData2);

        //            //    dataSection.Merge(data2);

        //            //    if (!string.IsNullOrEmpty(row["DUE_DATE_TRIAL_PRODUCTION"].ToString()))
        //            //    {
        //            //        DueDateTrial = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"].ToString());
        //            //        DueDate3 = DueDateTrial.ToString("dd/MMM");
        //            //    }
        //            //    var sectionRemainList = (from r in dataSection.AsEnumerable()
        //            //                             select r["PIC_SECTION"]).Distinct().ToList();
        //            //    if (TRIAL_ASSY == "Processing")
        //            //    {
        //            //        if (sectionRemainList.Count > 0)
        //            //        {
        //            //            foreach (var section in sectionRemainList)
        //            //            {
        //            //                sectionRemain = sectionRemain + ", " + section;
        //            //            }
        //            //            if (!string.IsNullOrEmpty(DueDate3))
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2) + "-" + DueDate3;
        //            //            }
        //            //            else
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2);
        //            //            }
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_ASSY"], sectionRemain);
        //            //        }
        //            //        else
        //            //        {
        //            //            if (!string.IsNullOrEmpty(DueDate3))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["TRIAL_ASSY"], "Processing" + "-" + DueDate3);
        //            //            }
        //            //        }
        //            //    }
        //            //    if (TRIAL_ASSY == "Wait")
        //            //    {
        //            //        if (!string.IsNullOrEmpty(DueDate3))
        //            //        {
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_ASSY"], "Wait" + "-" + DueDate3);
        //            //        }
        //            //    }
        //            //}
        //            ////TRIAL_PK
        //            //TRIAL_PK = row["TRIAL_PK"].ToString();
        //            //if (TRIAL_PK == "Processing" || TRIAL_PK == "Wait")
        //            //{
        //            //    string DueDate = string.Empty;
        //            //    string sectionRemain = string.Empty;
        //            //    queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
        //            //    dataSection = DBUtils._getData(queryDataSection);

        //            //    string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION  WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'PK' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
        //            //    DataTable data2 = DBUtils._getData(queryData2);

        //            //    dataSection.Merge(data2);

        //            //    if (!string.IsNullOrEmpty(row["DUE_DATE_TRIAL_PRODUCTION"].ToString()))
        //            //    {
        //            //        DueDateTrial = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"].ToString());
        //            //        DueDate = DueDateTrial.ToString("dd/MMM");
        //            //    }
        //            //    var sectionRemainList = (from r in dataSection.AsEnumerable()
        //            //                             select r["PIC_SECTION"]).Distinct().ToList();
        //            //    if (TRIAL_PK == "Processing")
        //            //    {
        //            //        if (sectionRemainList.Count > 0)
        //            //        {
        //            //            foreach (var section in sectionRemainList)
        //            //            {
        //            //                sectionRemain = sectionRemain + ", " + section;
        //            //            }
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2) + "-" + DueDate;
        //            //            }
        //            //            else
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2);
        //            //            }
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_PK"], sectionRemain);
        //            //        }
        //            //        else
        //            //        {
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["TRIAL_PK"], "Processing" + "-" + DueDate);
        //            //            }
        //            //        }
        //            //    }
        //            //    if (TRIAL_PK == "Wait")
        //            //    {
        //            //        if (!string.IsNullOrEmpty(DueDate))
        //            //        {
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_PK"], "Wait" + "-" + DueDate);
        //            //        }
        //            //    }
        //            //}
        //            ////TRIAL_MP
        //            //TRIAL_MP = row["TRIAL_MP"].ToString();
        //            //if (TRIAL_MP == "Processing" || TRIAL_MP == "Wait")
        //            //{
        //            //    string DueDate = string.Empty;
        //            //    string sectionRemain = string.Empty;
        //            //    queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_PREPARATION_TRY WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP' AND ((PLAN_START IS NULL OR LEN(RTRIM(PLAN_START)) = 0 OR PLAN_COMPLETE IS NULL OR LEN(RTRIM(PLAN_COMPLETE)) = 0) OR ACTUAL_START IS NULL OR LEN(RTRIM(ACTUAL_START)) = 0 OR ACTUAL_COMPLETE IS NULL OR LEN(RTRIM(ACTUAL_COMPLETE)) = 0 OR ATTACHED_FILE IS NULL OR LEN(RTRIM(ATTACHED_FILE)) = 0)";
        //            //    dataSection = DBUtils._getData(queryDataSection);

        //            //    string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION  WHERE CONTROL_NO = '" + ControlNo + "' AND STAGE = 'MP' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
        //            //    DataTable data2 = DBUtils._getData(queryData2);

        //            //    dataSection.Merge(data2);

        //            //    if (!string.IsNullOrEmpty(row["DUE_DATE_TRIAL_PRODUCTION"].ToString()))
        //            //    {
        //            //        DueDateTrial = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"].ToString());
        //            //        DueDate = DueDateTrial.ToString("dd/MMM");
        //            //    }
        //            //    var sectionRemainList = (from r in dataSection.AsEnumerable()
        //            //                             select r["PIC_SECTION"]).Distinct().ToList();
        //            //    if (TRIAL_MP == "Processing")
        //            //    {
        //            //        if (sectionRemainList.Count > 0)
        //            //        {
        //            //            foreach (var section in sectionRemainList)
        //            //            {
        //            //                sectionRemain = sectionRemain + ", " + section;
        //            //            }
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2) + "-" + DueDate;
        //            //            }
        //            //            else
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2);
        //            //            }
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_MP"], sectionRemain);
        //            //        }
        //            //        else
        //            //        {
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["TRIAL_MP"], "Processing" + "-" + DueDate);
        //            //            }
        //            //        }
        //            //    }
        //            //    if (TRIAL_MP == "Wait")
        //            //    {
        //            //        if (!string.IsNullOrEmpty(DueDate))
        //            //        {
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_MP"], "Wait" + "-" + DueDate);
        //            //        }
        //            //    }
        //            //}
        //            //TRIAL_CONFIRMATION
        //            //TRIAL_CONFIRMATION = row["TRIAL_CONFIRMATION"].ToString();
        //            //if (TRIAL_CONFIRMATION == "Processing" || TRIAL_CONFIRMATION == "Wait")
        //            //{
        //            //    string DueDate = string.Empty;
        //            //    string sectionRemain = string.Empty;
        //            //    //string queryData = "SELECT DISTINCT PIC_SECTION FROM TBL_TRIAL_PRODUCTION  WHERE CONTROL_NO = '" + ControlNo + "' AND (TEMPORARY_TRY IS NULL OR LEN(RTRIM(TEMPORARY_TRY)) = 0)";
        //            //    //DataTable data = DBUtils._getData(queryData);

        //            //    queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND (PLAN_COMPLETE is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
        //            //    dataSection = DBUtils._getData(queryDataSection);

        //            //    string queryData2 = "SELECT DISTINCT PIC_SECTION FROM TBL_OTHER_VALUABLE_EVALUATION  WHERE CONTROL_NO = '" + ControlNo + "' AND ([PLAN] is null or ACTUAL is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
        //            //    DataTable data2 = DBUtils._getData(queryData2);

        //            //    dataSection.Merge(data2);

        //            //    if (!string.IsNullOrEmpty(row["DUE_DATE_TRIAL_PRODUCTION"].ToString()))
        //            //    {
        //            //        DueDateTrial = Convert.ToDateTime(row["DUE_DATE_TRIAL_PRODUCTION"].ToString());
        //            //        DueDate = DueDateTrial.ToString("dd/MMM");
        //            //    }
        //            //    var sectionRemainList = (from r in dataSection.AsEnumerable()
        //            //                             select r["PIC_SECTION"]).Distinct().ToList();
        //            //    if (TRIAL_CONFIRMATION == "Processing")
        //            //    {
        //            //        if (sectionRemainList.Count > 0)
        //            //        {
        //            //            foreach (var section in sectionRemainList)
        //            //            {
        //            //                sectionRemain = sectionRemain + ", " + section;
        //            //            }
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2) + "-" + DueDate;
        //            //            }
        //            //            else
        //            //            {
        //            //                sectionRemain = sectionRemain.Substring(2);
        //            //            }
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_CONFIRMATION"], sectionRemain);
        //            //        }
        //            //        else
        //            //        {
        //            //            if (!string.IsNullOrEmpty(DueDate))
        //            //            {
        //            //                gvData.SetRowCellValue(i, gvData.Columns["TRIAL_CONFIRMATION"], "Processing" + "-" + DueDate);
        //            //            }
        //            //        }
        //            //    }
        //            //    if (TRIAL_CONFIRMATION == "Wait")
        //            //    {
        //            //        if (!string.IsNullOrEmpty(DueDate))
        //            //        {
        //            //            gvData.SetRowCellValue(i, gvData.Columns["TRIAL_CONFIRMATION"], "Wait" + "-" + DueDate);
        //            //        }
        //            //    }
        //            //}
        //        //    MASS_PRODUCTION = row["MASS_PRODUCTION"].ToString(); /*Convert.ToString(gvData.GetRowCellValue(i, gvData.Columns["MASS_PRODUCTION"]));*/
        //        //    if (MASS_PRODUCTION == "Processing" || MASS_PRODUCTION == "Wait")
        //        //    {

        //        //        string Section = "";
        //        //        string DueDate4 = string.Empty;
        //        //        queryDataSection = "SELECT DISTINCT PIC_SECTION FROM TBL_MASS_PRODUCTION  WHERE CONTROL_NO = '" + ControlNo + "' AND (PLAN_COMPLETE is null or ACTUAL_COMPLETE is null or LEN(RTRIM(ATTACHED_FILE)) = 0 or LEN(RTRIM(NOTE)) = 0 or LEN(RTRIM(JUDGEMENT)) = 0)";
        //        //        dataSection = DBUtils._getData(queryDataSection);
        //        //        if (!string.IsNullOrEmpty(row["DUA_DATE_MASS_PRODUCTION"].ToString()))
        //        //        {
        //        //            DueDateMass = Convert.ToDateTime(row["DUA_DATE_MASS_PRODUCTION"].ToString());
        //        //            DueDate4 = DueDateMass.ToString("dd/MMM");
        //        //        }
        //        //        if (MASS_PRODUCTION == "Processing")
        //        //        {
        //        //            if (dataSection.Rows.Count > 0)
        //        //            {
        //        //                string a = string.Empty;
        //        //                for (int j = 0; j < dataSection.Rows.Count; j++)
        //        //                {
        //        //                    Section = Section + ", " + Convert.ToString(dataSection.Rows[j]["PIC_SECTION"]);
        //        //                }
        //        //                if (!string.IsNullOrEmpty(DueDate4))
        //        //                {
        //        //                    a = Section.Substring(2) + "-" + DueDate4;
        //        //                }
        //        //                else
        //        //                {
        //        //                    a = Section.Substring(2);
        //        //                }
        //        //                gvData.SetRowCellValue(i, gvData.Columns["MASS_PRODUCTION"], a);
        //        //            }
        //        //            else
        //        //            {
        //        //                if (!string.IsNullOrEmpty(DueDate4))
        //        //                {
        //        //                    gvData.SetRowCellValue(i, gvData.Columns["MASS_PRODUCTION"], "Processing" + "-" + DueDate4);
        //        //                }
        //        //            }
        //        //        }
        //        //        if (MASS_PRODUCTION == "Wait")
        //        //        {
        //        //            if (!string.IsNullOrEmpty(DueDate4))
        //        //            {
        //        //                gvData.SetRowCellValue(i, gvData.Columns["MASS_PRODUCTION"], "Wait" + "-" + DueDate4);
        //        //            }
        //        //        }
        //        //    }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool Add = true;
            FRM_ADD_NEW_MOLD f = new FRM_ADD_NEW_MOLD(Add, "");
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                //LoadSection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            //LoadSection();
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
                        if (!Status.Contains("Wait") && !Status.Contains("NA"))
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
                        if (!Status.Contains("Wait") && !Status.Contains("NA"))
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

                    else if (colCaption == "Trial production")
                    {
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("PREPARATION"));
                        if (Status == "Finish")
                        {
                            int CountTrial = Convert.ToInt32(gvData.GetFocusedRowCellValue("COUNT_TRIAL"));
                            int CountTrialIM = Convert.ToInt32(gvData.GetFocusedRowCellValue("COUNT_TRIAL_IM"));
                            int CountTrialASSY = Convert.ToInt32(gvData.GetFocusedRowCellValue("COUNT_TRIAL_ASSY"));
                            string StatusTrial = Convert.ToString(gvData.GetFocusedRowCellValue("STATUS_TRIAL"));
                            FRM_TRIAL_PRODUCTION f = new FRM_TRIAL_PRODUCTION(ControlNo, CountTrial, StatusTrial, CountTrialIM, CountTrialASSY, ProductType);
                            f.ShowDialog();
                        }
                    }
                    else if (colCaption == "Mass production")
                    {
                        string Status = Convert.ToString(gvData.GetFocusedRowCellValue("MASS_PRODUCTION"));
                        if (!Status.Contains("Wait") && !Status.Contains("NA"))
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

        private void gvData_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
                    if (TryASSY.Contains("NA"))
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
                                if (!TryASSY.Contains("Wait") && !TryASSY.Contains("Finish") && !TryASSY.Contains("NA"))
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
                                    if (e.Column.FieldName == "TRIAL_MP")
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

        private void gvData_RowCountChanged(object sender, EventArgs e)
        {
            txtRecord.Text = Convert.ToString(gvData.RowCount);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool Add = false;
            string ControlNo = Convert.ToString(gvData.GetFocusedRowCellValue("CONTROL_NO"));
            FRM_ADD_NEW_MOLD f = new FRM_ADD_NEW_MOLD(Add, ControlNo);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                //LoadSection();
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}