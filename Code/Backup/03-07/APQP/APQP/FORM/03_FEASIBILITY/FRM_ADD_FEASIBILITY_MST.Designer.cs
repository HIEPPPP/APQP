namespace APQP.FORM._03_FEASIBILITY
{
    partial class FRM_ADD_FEASIBILITY_MST
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
            this.txtReviewItems = new System.Windows.Forms.TextBox();
            this.txtSection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApplyWith = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtReviewItems
            // 
            this.txtReviewItems.Location = new System.Drawing.Point(160, 32);
            this.txtReviewItems.Name = "txtReviewItems";
            this.txtReviewItems.Size = new System.Drawing.Size(228, 21);
            this.txtReviewItems.TabIndex = 1;
            // 
            // txtSection
            // 
            this.txtSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSection.FormattingEnabled = true;
            this.txtSection.Location = new System.Drawing.Point(160, 111);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(228, 21);
            this.txtSection.TabIndex = 2;
            this.txtSection.SelectedValueChanged += new System.EventHandler(this.txtSection_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tiêu chí xem xét:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PIC:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(236, 154);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 23);
            this.btnSave.TabIndex = 70;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(315, 154);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 23);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Chỉ áp dụng với hàng:";
            // 
            // txtApplyWith
            // 
            this.txtApplyWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtApplyWith.FormattingEnabled = true;
            this.txtApplyWith.Items.AddRange(new object[] {
            "Assy",
            "All"});
            this.txtApplyWith.Location = new System.Drawing.Point(160, 71);
            this.txtApplyWith.Name = "txtApplyWith";
            this.txtApplyWith.Size = new System.Drawing.Size(228, 21);
            this.txtApplyWith.TabIndex = 2;
            this.txtApplyWith.SelectedValueChanged += new System.EventHandler(this.txtSection_SelectedValueChanged);
            // 
            // FRM_ADD_FEASIBILITY_MST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 199);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtApplyWith);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.txtReviewItems);
            this.MaximumSize = new System.Drawing.Size(420, 231);
            this.MinimumSize = new System.Drawing.Size(420, 231);
            this.Name = "FRM_ADD_FEASIBILITY_MST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nội dung ";
            this.Load += new System.EventHandler(this.FRM_ADD_FEASIBILITY_MST_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtReviewItems;
        private System.Windows.Forms.ComboBox txtSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtApplyWith;
    }
}