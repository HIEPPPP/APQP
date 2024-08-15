namespace APQP.FORM._06_MASS_PRODUCTION
{
    partial class FRM_ADD_MASS_PRODUCTION
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
            this.cbAPQP = new System.Windows.Forms.CheckBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.ComboBox();
            this.txtDetailContents = new System.Windows.Forms.TextBox();
            this.txtMainContents = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbAPQP
            // 
            this.cbAPQP.AutoSize = true;
            this.cbAPQP.Location = new System.Drawing.Point(334, 101);
            this.cbAPQP.Name = "cbAPQP";
            this.cbAPQP.Size = new System.Drawing.Size(179, 17);
            this.cbAPQP.TabIndex = 100;
            this.cbAPQP.Text = "Chỉ áp dụng với sản phẩm APQP";
            this.cbAPQP.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(440, 146);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 23);
            this.btnClose.TabIndex = 98;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(361, 146);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 23);
            this.btnSave.TabIndex = 99;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 14);
            this.label2.TabIndex = 93;
            this.label2.Text = "PIC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 14);
            this.label3.TabIndex = 94;
            this.label3.Text = "Nội dung chi tiết:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 95;
            this.label1.Text = "Nội dung chính:";
            // 
            // txtSection
            // 
            this.txtSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSection.FormattingEnabled = true;
            this.txtSection.Location = new System.Drawing.Point(170, 99);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(114, 21);
            this.txtSection.TabIndex = 92;
            // 
            // txtDetailContents
            // 
            this.txtDetailContents.Location = new System.Drawing.Point(170, 59);
            this.txtDetailContents.Name = "txtDetailContents";
            this.txtDetailContents.Size = new System.Drawing.Size(343, 21);
            this.txtDetailContents.TabIndex = 91;
            // 
            // txtMainContents
            // 
            this.txtMainContents.Location = new System.Drawing.Point(170, 22);
            this.txtMainContents.Name = "txtMainContents";
            this.txtMainContents.Size = new System.Drawing.Size(343, 21);
            this.txtMainContents.TabIndex = 90;
            // 
            // FRM_ADD_MASS_PRODUCTION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 190);
            this.Controls.Add(this.cbAPQP);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.txtDetailContents);
            this.Controls.Add(this.txtMainContents);
            this.MaximumSize = new System.Drawing.Size(544, 222);
            this.MinimumSize = new System.Drawing.Size(544, 222);
            this.Name = "FRM_ADD_MASS_PRODUCTION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_ADD_MASS_PRODUCTION";
            this.Load += new System.EventHandler(this.FRM_ADD_MASS_PRODUCTION_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAPQP;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtSection;
        private System.Windows.Forms.TextBox txtDetailContents;
        private System.Windows.Forms.TextBox txtMainContents;
    }
}