namespace APQP.FORM.ADMIN
{
    partial class FRM_UPDATE_ACCOUNT
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
            this.txtNhaMay = new System.Windows.Forms.ComboBox();
            this.txtBoPhan = new System.Windows.Forms.ComboBox();
            this.txtQuyen = new System.Windows.Forms.ComboBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDK = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNhaMay
            // 
            this.txtNhaMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtNhaMay.FormattingEnabled = true;
            this.txtNhaMay.Items.AddRange(new object[] {
            "F1",
            "F2"});
            this.txtNhaMay.Location = new System.Drawing.Point(176, 117);
            this.txtNhaMay.Name = "txtNhaMay";
            this.txtNhaMay.Size = new System.Drawing.Size(148, 21);
            this.txtNhaMay.TabIndex = 68;
            // 
            // txtBoPhan
            // 
            this.txtBoPhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBoPhan.FormattingEnabled = true;
            this.txtBoPhan.Location = new System.Drawing.Point(176, 90);
            this.txtBoPhan.Name = "txtBoPhan";
            this.txtBoPhan.Size = new System.Drawing.Size(148, 21);
            this.txtBoPhan.TabIndex = 67;
            // 
            // txtQuyen
            // 
            this.txtQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtQuyen.FormattingEnabled = true;
            this.txtQuyen.Location = new System.Drawing.Point(176, 144);
            this.txtQuyen.Name = "txtQuyen";
            this.txtQuyen.Size = new System.Drawing.Size(148, 21);
            this.txtQuyen.TabIndex = 63;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(267, 197);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 21);
            this.btnClose.TabIndex = 66;
            this.btnClose.Text = "Thoát";
            // 
            // btnDK
            // 
            this.btnDK.Location = new System.Drawing.Point(160, 197);
            this.btnDK.Name = "btnDK";
            this.btnDK.Size = new System.Drawing.Size(74, 21);
            this.btnDK.TabIndex = 65;
            this.btnDK.Text = "Lưu";
            this.btnDK.Click += new System.EventHandler(this.btnDK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 62;
            this.label4.Text = "Nhà máy:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 59;
            this.label5.Text = "Quyền:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "Bộ phận:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Tên nv:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "Mã NV:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(176, 63);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(148, 21);
            this.txtTen.TabIndex = 61;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(176, 36);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(148, 21);
            this.txtMaNV.TabIndex = 55;
            // 
            // FRM_UPDATE_ACCOUNT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 249);
            this.Controls.Add(this.txtNhaMay);
            this.Controls.Add(this.txtBoPhan);
            this.Controls.Add(this.txtQuyen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMaNV);
            this.MaximumSize = new System.Drawing.Size(428, 281);
            this.MinimumSize = new System.Drawing.Size(428, 281);
            this.Name = "FRM_UPDATE_ACCOUNT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi thông tin";
            this.Load += new System.EventHandler(this.FRM_UPDATE_ACCOUNT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox txtNhaMay;
        private System.Windows.Forms.ComboBox txtBoPhan;
        private System.Windows.Forms.ComboBox txtQuyen;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMaNV;
    }
}