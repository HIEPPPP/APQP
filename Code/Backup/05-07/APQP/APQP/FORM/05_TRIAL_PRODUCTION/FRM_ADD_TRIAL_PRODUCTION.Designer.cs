namespace APQP.FORM._05_TRIAL_PRODUCTION
{
    partial class FRM_ADD_TRIAL_PRODUCTION
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.ComboBox();
            this.txtMainContents = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDetailsContents = new System.Windows.Forms.TextBox();
            this.txtStage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSortNumber = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(314, 177);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 23);
            this.btnClose.TabIndex = 78;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(235, 177);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 23);
            this.btnSave.TabIndex = 79;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "PIC:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Nội dung chính:";
            // 
            // txtSection
            // 
            this.txtSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSection.FormattingEnabled = true;
            this.txtSection.Location = new System.Drawing.Point(159, 110);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(228, 21);
            this.txtSection.TabIndex = 75;
            // 
            // txtMainContents
            // 
            this.txtMainContents.Location = new System.Drawing.Point(159, 15);
            this.txtMainContents.Name = "txtMainContents";
            this.txtMainContents.Size = new System.Drawing.Size(228, 21);
            this.txtMainContents.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "Nội dung chi tiết:";
            // 
            // txtDetailsContents
            // 
            this.txtDetailsContents.Location = new System.Drawing.Point(159, 45);
            this.txtDetailsContents.Name = "txtDetailsContents";
            this.txtDetailsContents.Size = new System.Drawing.Size(228, 21);
            this.txtDetailsContents.TabIndex = 81;
            // 
            // txtStage
            // 
            this.txtStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtStage.FormattingEnabled = true;
            this.txtStage.Items.AddRange(new object[] {
            "IM",
            "ASSY",
            "PK",
            "MP"});
            this.txtStage.Location = new System.Drawing.Point(159, 142);
            this.txtStage.Name = "txtStage";
            this.txtStage.Size = new System.Drawing.Size(228, 21);
            this.txtStage.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "Công đoạn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Số thứ tự sắp xếp:";
            // 
            // txtSortNumber
            // 
            this.txtSortNumber.FormattingEnabled = true;
            this.txtSortNumber.Items.AddRange(new object[] {
            "Assy",
            "All"});
            this.txtSortNumber.Location = new System.Drawing.Point(159, 78);
            this.txtSortNumber.Name = "txtSortNumber";
            this.txtSortNumber.Size = new System.Drawing.Size(228, 21);
            this.txtSortNumber.TabIndex = 83;
            // 
            // FRM_ADD_TRIAL_PRODUCTION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 227);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSortNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDetailsContents);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStage);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.txtMainContents);
            this.Name = "FRM_ADD_TRIAL_PRODUCTION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nội dung chạy thử";
            this.Load += new System.EventHandler(this.FRM_ADD_TRIAL_PRODUCTION_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtSection;
        private System.Windows.Forms.TextBox txtMainContents;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDetailsContents;
        private System.Windows.Forms.ComboBox txtStage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtSortNumber;
    }
}