namespace APQP.FORM._05_TRIAL_PRODUCTION
{
    partial class FRM_CONFIRM_PREPARATION
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CONFIRM_PREPARATION));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.STATUS = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.PLAN_START = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.PLAN_COMPLETE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ACTUAL_START = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ACTUAL_COMPLETE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ATTACHED_FILE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnOpenFile = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.file = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnFile = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.NOTE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJudgement = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnConfirmTrial = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJudgement.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gcData.Location = new System.Drawing.Point(12, 25);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnFile,
            this.btnOpenFile,
            this.repositoryItemMemoEdit1});
            this.gcData.Size = new System.Drawing.Size(1329, 555);
            this.gcData.TabIndex = 80;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvData.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand5,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand6});
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn4,
            this.STATUS,
            this.PLAN_START,
            this.PLAN_COMPLETE,
            this.ACTUAL_START,
            this.ACTUAL_COMPLETE,
            this.ATTACHED_FILE,
            this.bandedGridColumn6,
            this.bandedGridColumn5,
            this.file,
            this.NOTE});
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsNavigation.AutoFocusNewRow = true;
            this.gvData.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvData.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvData.OptionsView.AllowCellMerge = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.RowAutoHeight = true;
            this.gvData.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.RowHeight = 20;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Nội dung/ Contents";
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Columns.Add(this.bandedGridColumn4);
            this.gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 606;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.Caption = "Nội dung chính/ Main Contents";
            this.bandedGridColumn1.ColumnEdit = this.repositoryItemMemoEdit1;
            this.bandedGridColumn1.FieldName = "MAIN_CONTENTS";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 155;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn2.Caption = "Nội dung chi tiết/ Detailed Contents";
            this.bandedGridColumn2.ColumnEdit = this.repositoryItemMemoEdit1;
            this.bandedGridColumn2.FieldName = "DETAILED_CONTENTS";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 372;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn4.Caption = "PIC";
            this.bandedGridColumn4.FieldName = "PIC_SECTION";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 79;
            // 
            // gridBand5
            // 
            this.gridBand5.Columns.Add(this.STATUS);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 1;
            this.gridBand5.Width = 109;
            // 
            // STATUS
            // 
            this.STATUS.AppearanceCell.Options.UseTextOptions = true;
            this.STATUS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.STATUS.AppearanceHeader.Options.UseTextOptions = true;
            this.STATUS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.STATUS.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.STATUS.Caption = "Tình trạng/ Status";
            this.STATUS.FieldName = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.OptionsColumn.AllowEdit = false;
            this.STATUS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.STATUS.Visible = true;
            this.STATUS.Width = 109;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridBand2.AppearanceHeader.Options.UseBorderColor = true;
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Kế hoạch chuẩn bị/ Preparation Plan";
            this.gridBand2.Columns.Add(this.PLAN_START);
            this.gridBand2.Columns.Add(this.PLAN_COMPLETE);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 274;
            // 
            // PLAN_START
            // 
            this.PLAN_START.AppearanceCell.Options.UseTextOptions = true;
            this.PLAN_START.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PLAN_START.AppearanceHeader.Options.UseTextOptions = true;
            this.PLAN_START.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PLAN_START.Caption = "Bắt đầu/ Start";
            this.PLAN_START.FieldName = "PLAN_START";
            this.PLAN_START.Name = "PLAN_START";
            this.PLAN_START.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLAN_START.Visible = true;
            this.PLAN_START.Width = 143;
            // 
            // PLAN_COMPLETE
            // 
            this.PLAN_COMPLETE.AppearanceCell.Options.UseTextOptions = true;
            this.PLAN_COMPLETE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PLAN_COMPLETE.AppearanceHeader.Options.UseTextOptions = true;
            this.PLAN_COMPLETE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PLAN_COMPLETE.Caption = "Hoàn thành/ Completed";
            this.PLAN_COMPLETE.FieldName = "PLAN_COMPLETE";
            this.PLAN_COMPLETE.Name = "PLAN_COMPLETE";
            this.PLAN_COMPLETE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLAN_COMPLETE.Visible = true;
            this.PLAN_COMPLETE.Width = 131;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Thực tế/ Actual";
            this.gridBand3.Columns.Add(this.ACTUAL_START);
            this.gridBand3.Columns.Add(this.ACTUAL_COMPLETE);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 3;
            this.gridBand3.Width = 275;
            // 
            // ACTUAL_START
            // 
            this.ACTUAL_START.AppearanceCell.Options.UseTextOptions = true;
            this.ACTUAL_START.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ACTUAL_START.AppearanceHeader.Options.UseTextOptions = true;
            this.ACTUAL_START.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ACTUAL_START.Caption = "Bắt đầu/ Start";
            this.ACTUAL_START.FieldName = "ACTUAL_START";
            this.ACTUAL_START.Name = "ACTUAL_START";
            this.ACTUAL_START.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ACTUAL_START.Visible = true;
            this.ACTUAL_START.Width = 147;
            // 
            // ACTUAL_COMPLETE
            // 
            this.ACTUAL_COMPLETE.AppearanceCell.Options.UseTextOptions = true;
            this.ACTUAL_COMPLETE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ACTUAL_COMPLETE.AppearanceHeader.Options.UseTextOptions = true;
            this.ACTUAL_COMPLETE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ACTUAL_COMPLETE.Caption = "Hoàn thành/ Completed";
            this.ACTUAL_COMPLETE.FieldName = "ACTUAL_COMPLETE";
            this.ACTUAL_COMPLETE.Name = "ACTUAL_COMPLETE";
            this.ACTUAL_COMPLETE.OptionsColumn.AllowEdit = false;
            this.ACTUAL_COMPLETE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ACTUAL_COMPLETE.Visible = true;
            this.ACTUAL_COMPLETE.Width = 128;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "FILE";
            this.gridBand4.Columns.Add(this.ATTACHED_FILE);
            this.gridBand4.Columns.Add(this.bandedGridColumn6);
            this.gridBand4.Columns.Add(this.file);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 4;
            this.gridBand4.Width = 217;
            // 
            // ATTACHED_FILE
            // 
            this.ATTACHED_FILE.AppearanceHeader.Options.UseTextOptions = true;
            this.ATTACHED_FILE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ATTACHED_FILE.Caption = "File";
            this.ATTACHED_FILE.ColumnEdit = this.btnOpenFile;
            this.ATTACHED_FILE.FieldName = "ATTACHED_FILE";
            this.ATTACHED_FILE.Name = "ATTACHED_FILE";
            this.ATTACHED_FILE.OptionsColumn.AllowEdit = false;
            this.ATTACHED_FILE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ATTACHED_FILE.Visible = true;
            this.ATTACHED_FILE.Width = 177;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AutoHeight = false;
            this.btnOpenFile.Name = "btnOpenFile";
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn6.Caption = "FileExtension";
            this.bandedGridColumn6.FieldName = "FILE_EXTENSION";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // file
            // 
            this.file.AppearanceHeader.Options.UseTextOptions = true;
            this.file.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.file.ColumnEdit = this.btnFile;
            this.file.Name = "file";
            this.file.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.file.ShowUnboundExpressionMenu = true;
            this.file.Visible = true;
            this.file.Width = 40;
            // 
            // btnFile
            // 
            this.btnFile.AutoHeight = false;
            editorButtonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions4.Image")));
            this.btnFile.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnFile.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFile.ContextImageOptions.Image")));
            this.btnFile.Name = "btnFile";
            this.btnFile.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridBand6
            // 
            this.gridBand6.Columns.Add(this.bandedGridColumn5);
            this.gridBand6.Columns.Add(this.NOTE);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 5;
            this.gridBand6.Width = 405;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn5.Caption = "Documents";
            this.bandedGridColumn5.FieldName = "DOCUMENTS";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 195;
            // 
            // NOTE
            // 
            this.NOTE.AppearanceHeader.Options.UseTextOptions = true;
            this.NOTE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NOTE.Caption = "Note";
            this.NOTE.FieldName = "NOTE";
            this.NOTE.Name = "NOTE";
            this.NOTE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.NOTE.Visible = true;
            this.NOTE.Width = 210;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtJudgement);
            this.groupBox1.Controls.Add(this.btnConfirmTrial);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 586);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1329, 114);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "Judgement:";
            // 
            // txtJudgement
            // 
            this.txtJudgement.Location = new System.Drawing.Point(122, 30);
            this.txtJudgement.Name = "txtJudgement";
            this.txtJudgement.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJudgement.Properties.Appearance.Options.UseFont = true;
            this.txtJudgement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtJudgement.Properties.Items.AddRange(new object[] {
            "OK",
            "NG"});
            this.txtJudgement.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtJudgement.Size = new System.Drawing.Size(203, 26);
            this.txtJudgement.TabIndex = 37;
            // 
            // btnConfirmTrial
            // 
            this.btnConfirmTrial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmTrial.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmTrial.Appearance.Options.UseFont = true;
            this.btnConfirmTrial.Location = new System.Drawing.Point(122, 70);
            this.btnConfirmTrial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmTrial.Name = "btnConfirmTrial";
            this.btnConfirmTrial.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmTrial.TabIndex = 36;
            this.btnConfirmTrial.Text = "Confirm";
            this.btnConfirmTrial.Click += new System.EventHandler(this.btnConfirmTrial_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(203, 70);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            // 
            // FRM_CONFIRM_PREPARATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 712);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gcData);
            this.Name = "FRM_CONFIRM_PREPARATION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_CONFIRM_PREPARATION";
            this.Load += new System.EventHandler(this.FRM_CONFIRM_PREPARATION_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJudgement.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvData;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn STATUS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn PLAN_START;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn PLAN_COMPLETE;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ACTUAL_START;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ACTUAL_COMPLETE;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ATTACHED_FILE;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit btnOpenFile;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn file;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnFile;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NOTE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.ComboBoxEdit txtJudgement;
        private DevExpress.XtraEditors.SimpleButton btnConfirmTrial;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}