namespace APQP.FORM._04_PREPARATION
{
    partial class FRM_ADD_PREPARATION_MST
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
            this.txtDetailContents = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApplyWith = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSortNumber = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(443, 187);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 23);
            this.btnClose.TabIndex = 75;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(352, 187);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 23);
            this.btnSave.TabIndex = 76;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 73;
            this.label2.Text = "PIC:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 74;
            this.label1.Text = "Nội dung chính:";
            // 
            // txtSection
            // 
            this.txtSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSection.FormattingEnabled = true;
            this.txtSection.Location = new System.Drawing.Point(173, 136);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(152, 21);
            this.txtSection.TabIndex = 72;
            // 
            // txtMainContents
            // 
            this.txtMainContents.Location = new System.Drawing.Point(173, 23);
            this.txtMainContents.Name = "txtMainContents";
            this.txtMainContents.Size = new System.Drawing.Size(343, 21);
            this.txtMainContents.TabIndex = 1;
            // 
            // txtDetailContents
            // 
            this.txtDetailContents.Location = new System.Drawing.Point(173, 60);
            this.txtDetailContents.Name = "txtDetailContents";
            this.txtDetailContents.Size = new System.Drawing.Size(343, 21);
            this.txtDetailContents.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 14);
            this.label3.TabIndex = 74;
            this.label3.Text = "Nội dung chi tiết:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 14);
            this.label4.TabIndex = 78;
            this.label4.Text = "Loại hàng áp dụng:";
            // 
            // txtApplyWith
            // 
            this.txtApplyWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtApplyWith.FormattingEnabled = true;
            this.txtApplyWith.Items.AddRange(new object[] {
            "Assy",
            "Unit",
            "All"});
            this.txtApplyWith.Location = new System.Drawing.Point(173, 98);
            this.txtApplyWith.Name = "txtApplyWith";
            this.txtApplyWith.Size = new System.Drawing.Size(152, 21);
            this.txtApplyWith.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Số thứ tự sắp xếp:";
            // 
            // txtSortNumber
            // 
            this.txtSortNumber.FormattingEnabled = true;
            this.txtSortNumber.Items.AddRange(new object[] {
            "Assy",
            "All"});
            this.txtSortNumber.Location = new System.Drawing.Point(443, 100);
            this.txtSortNumber.Name = "txtSortNumber";
            this.txtSortNumber.Size = new System.Drawing.Size(74, 21);
            this.txtSortNumber.TabIndex = 85;
            // 
            // FRM_ADD_PREPARATION_MST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 230);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSortNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApplyWith);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.txtDetailContents);
            this.Controls.Add(this.txtMainContents);
            this.MaximumSize = new System.Drawing.Size(548, 262);
            this.MinimumSize = new System.Drawing.Size(548, 262);
            this.Name = "FRM_ADD_PREPARATION_MST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nội dung chuẩn bị";
            this.Load += new System.EventHandler(this.FRM_ADD_PREPARATION_MST_Load);
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
        private System.Windows.Forms.TextBox txtDetailContents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtApplyWith;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtSortNumber;
    }
}