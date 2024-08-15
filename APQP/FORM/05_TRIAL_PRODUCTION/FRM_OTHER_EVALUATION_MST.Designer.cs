namespace APQP.FORM._05_TRIAL_PRODUCTION
{
    partial class FRM_OTHER_EVALUATION_MST
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
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rspStatus = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.btnDetailPur = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.PIC_SECTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DETAILED_CONTENTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.MAIN_CONTENTS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ApplyWith = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OnlyAPQP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnApproDisposal = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnDeatailCalibration = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetailPur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApproDisposal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeatailCalibration)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(175, 23);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(69, 24);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // rspStatus
            // 
            this.rspStatus.AutoHeight = false;
            this.rspStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspStatus.Name = "rspStatus";
            this.rspStatus.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // btnDetailPur
            // 
            this.btnDetailPur.AutoHeight = false;
            this.btnDetailPur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnDetailPur.Name = "btnDetailPur";
            // 
            // PIC_SECTION
            // 
            this.PIC_SECTION.AppearanceCell.Options.UseTextOptions = true;
            this.PIC_SECTION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PIC_SECTION.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PIC_SECTION.AppearanceHeader.Options.UseFont = true;
            this.PIC_SECTION.AppearanceHeader.Options.UseTextOptions = true;
            this.PIC_SECTION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PIC_SECTION.Caption = "PIC";
            this.PIC_SECTION.FieldName = "PIC_SECTION";
            this.PIC_SECTION.Name = "PIC_SECTION";
            this.PIC_SECTION.Visible = true;
            this.PIC_SECTION.VisibleIndex = 2;
            this.PIC_SECTION.Width = 84;
            // 
            // DETAILED_CONTENTS
            // 
            this.DETAILED_CONTENTS.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DETAILED_CONTENTS.AppearanceHeader.Options.UseFont = true;
            this.DETAILED_CONTENTS.AppearanceHeader.Options.UseTextOptions = true;
            this.DETAILED_CONTENTS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DETAILED_CONTENTS.Caption = "Nội dung chi tiết";
            this.DETAILED_CONTENTS.ColumnEdit = this.repositoryItemMemoEdit1;
            this.DETAILED_CONTENTS.FieldName = "DETAILED_CONTENTS";
            this.DETAILED_CONTENTS.Name = "DETAILED_CONTENTS";
            this.DETAILED_CONTENTS.Visible = true;
            this.DETAILED_CONTENTS.VisibleIndex = 1;
            this.DETAILED_CONTENTS.Width = 431;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // MAIN_CONTENTS1
            // 
            this.MAIN_CONTENTS1.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MAIN_CONTENTS1.AppearanceHeader.Options.UseFont = true;
            this.MAIN_CONTENTS1.AppearanceHeader.Options.UseTextOptions = true;
            this.MAIN_CONTENTS1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MAIN_CONTENTS1.Caption = "Nội dung chính";
            this.MAIN_CONTENTS1.ColumnEdit = this.repositoryItemMemoEdit1;
            this.MAIN_CONTENTS1.FieldName = "MAIN_CONTENTS";
            this.MAIN_CONTENTS1.Name = "MAIN_CONTENTS1";
            this.MAIN_CONTENTS1.Visible = true;
            this.MAIN_CONTENTS1.VisibleIndex = 0;
            this.MAIN_CONTENTS1.Width = 263;
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
            this.MAIN_CONTENTS1,
            this.DETAILED_CONTENTS,
            this.PIC_SECTION,
            this.ApplyWith,
            this.OnlyAPQP});
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
            // 
            // ApplyWith
            // 
            this.ApplyWith.AppearanceCell.Options.UseTextOptions = true;
            this.ApplyWith.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ApplyWith.AppearanceHeader.Options.UseTextOptions = true;
            this.ApplyWith.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ApplyWith.Caption = "Loại hàng áp dụng";
            this.ApplyWith.FieldName = "APPLY_WITH";
            this.ApplyWith.Name = "ApplyWith";
            this.ApplyWith.Visible = true;
            this.ApplyWith.VisibleIndex = 3;
            this.ApplyWith.Width = 110;
            // 
            // OnlyAPQP
            // 
            this.OnlyAPQP.AppearanceCell.Options.UseTextOptions = true;
            this.OnlyAPQP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OnlyAPQP.AppearanceHeader.Options.UseTextOptions = true;
            this.OnlyAPQP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OnlyAPQP.Caption = "Chỉ áp dụng cho sản phẩm APQP";
            this.OnlyAPQP.FieldName = "ONLY_APQP";
            this.OnlyAPQP.Name = "OnlyAPQP";
            this.OnlyAPQP.Visible = true;
            this.OnlyAPQP.VisibleIndex = 4;
            this.OnlyAPQP.Width = 179;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gcData.Location = new System.Drawing.Point(21, 12);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.btnDetailPur,
            this.btnApproDisposal,
            this.btnDeatailCalibration,
            this.repositoryItemMemoEdit1,
            this.rspStatus});
            this.gcData.Size = new System.Drawing.Size(1101, 461);
            this.gcData.TabIndex = 69;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // btnApproDisposal
            // 
            this.btnApproDisposal.AutoHeight = false;
            this.btnApproDisposal.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnApproDisposal.Name = "btnApproDisposal";
            // 
            // btnDeatailCalibration
            // 
            this.btnDeatailCalibration.AutoHeight = false;
            this.btnDeatailCalibration.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnDeatailCalibration.Name = "btnDeatailCalibration";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Location = new System.Drawing.Point(13, 50);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 56;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(13, 23);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(21, 479);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1097, 92);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(94, 50);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Location = new System.Drawing.Point(94, 23);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FRM_OTHER_EVALUATION_MST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gcData);
            this.Name = "FRM_OTHER_EVALUATION_MST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nội dung xác nhận";
            this.Load += new System.EventHandler(this.FRM_OTHER_EVALUATION_MST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetailPur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApproDisposal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeatailCalibration)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rspStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDetailPur;
        private DevExpress.XtraGrid.Columns.GridColumn PIC_SECTION;
        private DevExpress.XtraGrid.Columns.GridColumn DETAILED_CONTENTS;
        private DevExpress.XtraGrid.Columns.GridColumn MAIN_CONTENTS1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnApproDisposal;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDeatailCalibration;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn ApplyWith;
        private DevExpress.XtraGrid.Columns.GridColumn OnlyAPQP;
    }
}