namespace APQP.FORM.NEW_MOLD_MST
{
     partial class FRM_NEW_MOLD_LIST
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_NEW_MOLD_LIST));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Control_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PART_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PART_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MOLD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAVITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Factory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRODUCT_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MOLD_RECEIVE_PLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MOLD_RECEIVE_ACTUAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRODUCT_INFORMATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FEASIBILITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PREPARATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRIAL_PRODUCTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MASS_PRODUCTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FOLLOW_UP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.btnFile = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEx = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lbMoldType = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // gvData
            // 
            this.gvData.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvData.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Control_No,
            this.PART_NAME,
            this.PART_NO,
            this.MOLD_NO,
            this.CAVITY,
            this.Factory,
            this.TYPE,
            this.PRODUCT_TYPE,
            this.gridColumn6,
            this.MOLD_RECEIVE_PLAN,
            this.MOLD_RECEIVE_ACTUAL,
            this.PRODUCT_INFORMATION,
            this.FEASIBILITY,
            this.PREPARATION,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5,
            this.TRIAL_PRODUCTION,
            this.MASS_PRODUCTION,
            this.FOLLOW_UP});
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsNavigation.AutoFocusNewRow = true;
            this.gvData.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvData.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvData.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvData.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.RowAutoHeight = true;
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.RowHeight = 15;
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            this.gvData.DoubleClick += new System.EventHandler(this.gvData_DoubleClick);
            this.gvData.RowCountChanged += new System.EventHandler(this.gvData_RowCountChanged);
            // 
            // Control_No
            // 
            this.Control_No.AppearanceCell.Options.UseTextOptions = true;
            this.Control_No.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Control_No.AppearanceHeader.Options.UseTextOptions = true;
            this.Control_No.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Control_No.Caption = "Control No";
            this.Control_No.FieldName = "CONTROL_NO";
            this.Control_No.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Control_No.Name = "Control_No";
            this.Control_No.OptionsColumn.ReadOnly = true;
            this.Control_No.Visible = true;
            this.Control_No.VisibleIndex = 0;
            this.Control_No.Width = 82;
            // 
            // PART_NAME
            // 
            this.PART_NAME.AppearanceCell.Options.UseTextOptions = true;
            this.PART_NAME.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PART_NAME.AppearanceHeader.Options.UseTextOptions = true;
            this.PART_NAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PART_NAME.Caption = "Part name";
            this.PART_NAME.ColumnEdit = this.repositoryItemMemoEdit2;
            this.PART_NAME.FieldName = "PART_NAME";
            this.PART_NAME.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.PART_NAME.Name = "PART_NAME";
            this.PART_NAME.OptionsColumn.ReadOnly = true;
            this.PART_NAME.Visible = true;
            this.PART_NAME.VisibleIndex = 1;
            this.PART_NAME.Width = 108;
            // 
            // PART_NO
            // 
            this.PART_NO.AppearanceCell.Options.UseTextOptions = true;
            this.PART_NO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PART_NO.AppearanceHeader.Options.UseTextOptions = true;
            this.PART_NO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PART_NO.Caption = "Part No";
            this.PART_NO.FieldName = "PART_NO";
            this.PART_NO.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.PART_NO.Name = "PART_NO";
            this.PART_NO.Visible = true;
            this.PART_NO.VisibleIndex = 2;
            this.PART_NO.Width = 84;
            // 
            // MOLD_NO
            // 
            this.MOLD_NO.AppearanceCell.Options.UseTextOptions = true;
            this.MOLD_NO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MOLD_NO.AppearanceHeader.Options.UseTextOptions = true;
            this.MOLD_NO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MOLD_NO.Caption = "Mold No";
            this.MOLD_NO.FieldName = "MOLD_NO";
            this.MOLD_NO.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.MOLD_NO.Name = "MOLD_NO";
            this.MOLD_NO.OptionsColumn.ReadOnly = true;
            this.MOLD_NO.Visible = true;
            this.MOLD_NO.VisibleIndex = 3;
            this.MOLD_NO.Width = 91;
            // 
            // CAVITY
            // 
            this.CAVITY.AppearanceCell.Options.UseTextOptions = true;
            this.CAVITY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAVITY.AppearanceHeader.Options.UseTextOptions = true;
            this.CAVITY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAVITY.Caption = "Cavity";
            this.CAVITY.FieldName = "CAVITY";
            this.CAVITY.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.CAVITY.Name = "CAVITY";
            this.CAVITY.OptionsColumn.ReadOnly = true;
            this.CAVITY.Visible = true;
            this.CAVITY.VisibleIndex = 4;
            this.CAVITY.Width = 87;
            // 
            // Factory
            // 
            this.Factory.AppearanceCell.Options.UseTextOptions = true;
            this.Factory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Factory.AppearanceHeader.Options.UseTextOptions = true;
            this.Factory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Factory.Caption = "Factory";
            this.Factory.FieldName = "FACTORY";
            this.Factory.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Factory.Name = "Factory";
            this.Factory.OptionsColumn.AllowEdit = false;
            this.Factory.Visible = true;
            this.Factory.VisibleIndex = 5;
            this.Factory.Width = 58;
            // 
            // TYPE
            // 
            this.TYPE.AppearanceCell.Options.UseTextOptions = true;
            this.TYPE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TYPE.AppearanceHeader.Options.UseTextOptions = true;
            this.TYPE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TYPE.Caption = "Type";
            this.TYPE.FieldName = "TYPE";
            this.TYPE.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.TYPE.Name = "TYPE";
            this.TYPE.OptionsColumn.AllowEdit = false;
            this.TYPE.Visible = true;
            this.TYPE.VisibleIndex = 6;
            this.TYPE.Width = 73;
            // 
            // PRODUCT_TYPE
            // 
            this.PRODUCT_TYPE.AppearanceCell.Options.UseTextOptions = true;
            this.PRODUCT_TYPE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PRODUCT_TYPE.AppearanceHeader.Options.UseTextOptions = true;
            this.PRODUCT_TYPE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PRODUCT_TYPE.Caption = "Product type";
            this.PRODUCT_TYPE.FieldName = "PRODUCT_TYPE";
            this.PRODUCT_TYPE.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.PRODUCT_TYPE.Name = "PRODUCT_TYPE";
            this.PRODUCT_TYPE.OptionsColumn.AllowEdit = false;
            this.PRODUCT_TYPE.Visible = true;
            this.PRODUCT_TYPE.VisibleIndex = 7;
            this.PRODUCT_TYPE.Width = 82;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "1st ship plan";
            this.gridColumn6.FieldName = "1ST_SHIP_PLAN";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 125;
            // 
            // MOLD_RECEIVE_PLAN
            // 
            this.MOLD_RECEIVE_PLAN.AppearanceCell.Options.UseTextOptions = true;
            this.MOLD_RECEIVE_PLAN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MOLD_RECEIVE_PLAN.AppearanceHeader.Options.UseTextOptions = true;
            this.MOLD_RECEIVE_PLAN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MOLD_RECEIVE_PLAN.Caption = "Mold receive plan";
            this.MOLD_RECEIVE_PLAN.FieldName = "MOLD_RECEIVE_PLAN";
            this.MOLD_RECEIVE_PLAN.Name = "MOLD_RECEIVE_PLAN";
            this.MOLD_RECEIVE_PLAN.OptionsColumn.AllowEdit = false;
            this.MOLD_RECEIVE_PLAN.Visible = true;
            this.MOLD_RECEIVE_PLAN.VisibleIndex = 9;
            this.MOLD_RECEIVE_PLAN.Width = 114;
            // 
            // MOLD_RECEIVE_ACTUAL
            // 
            this.MOLD_RECEIVE_ACTUAL.AppearanceCell.Options.UseTextOptions = true;
            this.MOLD_RECEIVE_ACTUAL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MOLD_RECEIVE_ACTUAL.AppearanceHeader.Options.UseTextOptions = true;
            this.MOLD_RECEIVE_ACTUAL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MOLD_RECEIVE_ACTUAL.Caption = "Mold receive actual";
            this.MOLD_RECEIVE_ACTUAL.FieldName = "MOLD_RECEIVE_ACTUAL";
            this.MOLD_RECEIVE_ACTUAL.Name = "MOLD_RECEIVE_ACTUAL";
            this.MOLD_RECEIVE_ACTUAL.OptionsColumn.AllowEdit = false;
            this.MOLD_RECEIVE_ACTUAL.Visible = true;
            this.MOLD_RECEIVE_ACTUAL.VisibleIndex = 10;
            this.MOLD_RECEIVE_ACTUAL.Width = 112;
            // 
            // PRODUCT_INFORMATION
            // 
            this.PRODUCT_INFORMATION.AppearanceCell.Options.UseTextOptions = true;
            this.PRODUCT_INFORMATION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PRODUCT_INFORMATION.AppearanceHeader.Options.UseTextOptions = true;
            this.PRODUCT_INFORMATION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PRODUCT_INFORMATION.Caption = "Product info";
            this.PRODUCT_INFORMATION.FieldName = "PRODUCT_INFORMATION";
            this.PRODUCT_INFORMATION.Name = "PRODUCT_INFORMATION";
            this.PRODUCT_INFORMATION.OptionsColumn.AllowEdit = false;
            this.PRODUCT_INFORMATION.OptionsColumn.ReadOnly = true;
            this.PRODUCT_INFORMATION.Visible = true;
            this.PRODUCT_INFORMATION.VisibleIndex = 11;
            this.PRODUCT_INFORMATION.Width = 128;
            // 
            // FEASIBILITY
            // 
            this.FEASIBILITY.AppearanceCell.Options.UseTextOptions = true;
            this.FEASIBILITY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FEASIBILITY.AppearanceHeader.Options.UseTextOptions = true;
            this.FEASIBILITY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FEASIBILITY.Caption = "Feasibility";
            this.FEASIBILITY.FieldName = "FEASIBILITY";
            this.FEASIBILITY.Name = "FEASIBILITY";
            this.FEASIBILITY.OptionsColumn.AllowEdit = false;
            this.FEASIBILITY.OptionsColumn.ReadOnly = true;
            this.FEASIBILITY.Visible = true;
            this.FEASIBILITY.VisibleIndex = 12;
            this.FEASIBILITY.Width = 188;
            // 
            // PREPARATION
            // 
            this.PREPARATION.AppearanceCell.Options.UseTextOptions = true;
            this.PREPARATION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PREPARATION.AppearanceHeader.Options.UseTextOptions = true;
            this.PREPARATION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PREPARATION.Caption = "Preparation";
            this.PREPARATION.FieldName = "PREPARATION";
            this.PREPARATION.Name = "PREPARATION";
            this.PREPARATION.OptionsColumn.AllowEdit = false;
            this.PREPARATION.OptionsColumn.ReadOnly = true;
            this.PREPARATION.Visible = true;
            this.PREPARATION.VisibleIndex = 13;
            this.PREPARATION.Width = 213;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Try Injection";
            this.gridColumn1.FieldName = "TRIAL_IM";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 14;
            this.gridColumn1.Width = 215;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Try MP";
            this.gridColumn4.FieldName = "TRIAL_MP";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 15;
            this.gridColumn4.Width = 215;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Try Assy";
            this.gridColumn2.FieldName = "TRIAL_ASSY";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 16;
            this.gridColumn2.Width = 215;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Try Packing";
            this.gridColumn3.FieldName = "TRIAL_PK";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 17;
            this.gridColumn3.Width = 144;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Try Confirmation";
            this.gridColumn5.FieldName = "TRIAL_CONFIRMATION";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 18;
            this.gridColumn5.Width = 150;
            // 
            // TRIAL_PRODUCTION
            // 
            this.TRIAL_PRODUCTION.AppearanceCell.Options.UseTextOptions = true;
            this.TRIAL_PRODUCTION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TRIAL_PRODUCTION.AppearanceHeader.Options.UseTextOptions = true;
            this.TRIAL_PRODUCTION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TRIAL_PRODUCTION.Caption = "Trial production";
            this.TRIAL_PRODUCTION.FieldName = "TRIAL_PRODUCTION";
            this.TRIAL_PRODUCTION.Name = "TRIAL_PRODUCTION";
            this.TRIAL_PRODUCTION.OptionsColumn.AllowEdit = false;
            this.TRIAL_PRODUCTION.OptionsColumn.ReadOnly = true;
            this.TRIAL_PRODUCTION.Visible = true;
            this.TRIAL_PRODUCTION.VisibleIndex = 19;
            this.TRIAL_PRODUCTION.Width = 221;
            // 
            // MASS_PRODUCTION
            // 
            this.MASS_PRODUCTION.AppearanceCell.Options.UseTextOptions = true;
            this.MASS_PRODUCTION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MASS_PRODUCTION.AppearanceHeader.Options.UseTextOptions = true;
            this.MASS_PRODUCTION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MASS_PRODUCTION.Caption = "Mass production";
            this.MASS_PRODUCTION.FieldName = "MASS_PRODUCTION";
            this.MASS_PRODUCTION.Name = "MASS_PRODUCTION";
            this.MASS_PRODUCTION.OptionsColumn.AllowEdit = false;
            this.MASS_PRODUCTION.OptionsColumn.ReadOnly = true;
            this.MASS_PRODUCTION.Visible = true;
            this.MASS_PRODUCTION.VisibleIndex = 20;
            this.MASS_PRODUCTION.Width = 160;
            // 
            // FOLLOW_UP
            // 
            this.FOLLOW_UP.AppearanceCell.Options.UseTextOptions = true;
            this.FOLLOW_UP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FOLLOW_UP.AppearanceHeader.Options.UseTextOptions = true;
            this.FOLLOW_UP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FOLLOW_UP.Caption = "Follow up";
            this.FOLLOW_UP.FieldName = "FOLLOW_UP";
            this.FOLLOW_UP.Name = "FOLLOW_UP";
            this.FOLLOW_UP.OptionsColumn.AllowEdit = false;
            this.FOLLOW_UP.OptionsColumn.ReadOnly = true;
            this.FOLLOW_UP.Visible = true;
            this.FOLLOW_UP.VisibleIndex = 21;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gcData.Location = new System.Drawing.Point(21, 48);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnFile});
            this.gcData.Size = new System.Drawing.Size(1183, 563);
            this.gcData.TabIndex = 56;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // btnFile
            // 
            this.btnFile.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.btnFile.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnFile.Name = "btnFile";
            this.btnFile.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(169, 16);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnRefresh.TabIndex = 58;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1015, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Mode";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(1076, 45);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(101, 21);
            this.textBox2.TabIndex = 54;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "View";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(90, 16);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1015, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Record";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(9, 16);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRecord
            // 
            this.txtRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtRecord.Location = new System.Drawing.Point(1076, 19);
            this.txtRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.ReadOnly = true;
            this.txtRecord.Size = new System.Drawing.Size(101, 21);
            this.txtRecord.TabIndex = 52;
            this.txtRecord.TabStop = false;
            this.txtRecord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnEx);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtRecord);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Location = new System.Drawing.Point(12, 617);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1183, 74);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // btnEx
            // 
            this.btnEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEx.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEx.Appearance.Options.UseFont = true;
            this.btnEx.Location = new System.Drawing.Point(90, 42);
            this.btnEx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEx.Name = "btnEx";
            this.btnEx.Size = new System.Drawing.Size(75, 23);
            this.btnEx.TabIndex = 34;
            this.btnEx.Text = "Export";
            this.btnEx.Click += new System.EventHandler(this.btnEx_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(169, 42);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(9, 42);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lbMoldType
            // 
            this.lbMoldType.AutoSize = true;
            this.lbMoldType.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoldType.Location = new System.Drawing.Point(16, 7);
            this.lbMoldType.Name = "lbMoldType";
            this.lbMoldType.Size = new System.Drawing.Size(177, 29);
            this.lbMoldType.TabIndex = 57;
            this.lbMoldType.Text = "New mold list";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox1.Location = new System.Drawing.Point(562, 18);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(55, 18);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(55, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 18);
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Turquoise;
            this.pictureBox2.Location = new System.Drawing.Point(702, 18);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(55, 18);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(55, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 18);
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.GreenYellow;
            this.pictureBox3.Location = new System.Drawing.Point(440, 18);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(55, 18);
            this.pictureBox3.MinimumSize = new System.Drawing.Size(55, 18);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(55, 18);
            this.pictureBox3.TabIndex = 60;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(623, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Processing";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(763, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Wait";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Finish";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(885, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Delay";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Red;
            this.pictureBox4.Location = new System.Drawing.Point(821, 18);
            this.pictureBox4.MaximumSize = new System.Drawing.Size(55, 18);
            this.pictureBox4.MinimumSize = new System.Drawing.Size(55, 18);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(55, 18);
            this.pictureBox4.TabIndex = 62;
            this.pictureBox4.TabStop = false;
            // 
            // FRM_NEW_MOLD_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 699);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbMoldType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gcData);
            this.Name = "FRM_NEW_MOLD_LIST";
            this.Text = "New mold list";
            this.Load += new System.EventHandler(this.FRM_NEW_MOLD_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn TRIAL_PRODUCTION;
        private DevExpress.XtraGrid.Columns.GridColumn PREPARATION;
        private DevExpress.XtraGrid.Columns.GridColumn FEASIBILITY;
        private DevExpress.XtraGrid.Columns.GridColumn PRODUCT_INFORMATION;
        private DevExpress.XtraGrid.Columns.GridColumn MOLD_RECEIVE_ACTUAL;
        private DevExpress.XtraGrid.Columns.GridColumn MOLD_RECEIVE_PLAN;
        private DevExpress.XtraGrid.Columns.GridColumn TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn CAVITY;
        private DevExpress.XtraGrid.Columns.GridColumn MOLD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn PART_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn Control_No;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnEx;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Label lbMoldType;
        private DevExpress.XtraGrid.Columns.GridColumn MASS_PRODUCTION;
        private DevExpress.XtraGrid.Columns.GridColumn FOLLOW_UP;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private DevExpress.XtraGrid.Columns.GridColumn PRODUCT_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn Factory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnFile;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn PART_NO;
    }
}