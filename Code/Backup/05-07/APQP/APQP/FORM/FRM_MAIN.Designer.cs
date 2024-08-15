namespace APQP.FORM
{
    partial class FRM_MAIN
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MAIN));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNewMoldMST = new DevExpress.XtraBars.BarButtonItem();
            this.btnFeasibilityMST = new DevExpress.XtraBars.BarButtonItem();
            this.btnPreparationMST = new DevExpress.XtraBars.BarButtonItem();
            this.btnMassMST = new DevExpress.XtraBars.BarButtonItem();
            this.btnTrialMST = new DevExpress.XtraBars.BarButtonItem();
            this.btnOtherEvaluationMST = new DevExpress.XtraBars.BarButtonItem();
            this.btnOtherValuableEvaluationMST = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnHistoryNewMold = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdmin = new DevExpress.XtraBars.BarButtonItem();
            this.btnPreparationTry = new DevExpress.XtraBars.BarButtonItem();
            this.btnProductionPlan = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnUser = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnNewMoldMST,
            this.btnFeasibilityMST,
            this.btnPreparationMST,
            this.btnMassMST,
            this.btnTrialMST,
            this.btnOtherEvaluationMST,
            this.btnOtherValuableEvaluationMST,
            this.btnClose,
            this.btnHistoryNewMold,
            this.btnAdmin,
            this.btnPreparationTry,
            this.btnProductionPlan});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 13;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.QuickToolbarItemLinks.Add(this.btnAdmin);
            this.ribbon.Size = new System.Drawing.Size(1440, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar1;
            // 
            // btnNewMoldMST
            // 
            this.btnNewMoldMST.Caption = "New mold list";
            this.btnNewMoldMST.Id = 1;
            this.btnNewMoldMST.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewMoldMST.ImageOptions.SvgImage")));
            this.btnNewMoldMST.Name = "btnNewMoldMST";
            this.btnNewMoldMST.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewMoldMST_ItemClick);
            // 
            // btnFeasibilityMST
            // 
            this.btnFeasibilityMST.Caption = "Feasibility Master";
            this.btnFeasibilityMST.Enabled = false;
            this.btnFeasibilityMST.Id = 2;
            this.btnFeasibilityMST.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFeasibilityMST.ImageOptions.SvgImage")));
            this.btnFeasibilityMST.Name = "btnFeasibilityMST";
            this.btnFeasibilityMST.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFeasibilityMST_ItemClick);
            // 
            // btnPreparationMST
            // 
            this.btnPreparationMST.Caption = "Preparation Master";
            this.btnPreparationMST.Enabled = false;
            this.btnPreparationMST.Id = 3;
            this.btnPreparationMST.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPreparationMST.ImageOptions.SvgImage")));
            this.btnPreparationMST.Name = "btnPreparationMST";
            this.btnPreparationMST.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreparationMST_ItemClick);
            // 
            // btnMassMST
            // 
            this.btnMassMST.Caption = "Mass Production Master";
            this.btnMassMST.Enabled = false;
            this.btnMassMST.Id = 4;
            this.btnMassMST.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMassMST.ImageOptions.SvgImage")));
            this.btnMassMST.Name = "btnMassMST";
            this.btnMassMST.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMass_ItemClick);
            // 
            // btnTrialMST
            // 
            this.btnTrialMST.Caption = "Trial Master";
            this.btnTrialMST.Enabled = false;
            this.btnTrialMST.Id = 5;
            this.btnTrialMST.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTrialMST.ImageOptions.SvgImage")));
            this.btnTrialMST.Name = "btnTrialMST";
            this.btnTrialMST.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrialMST_ItemClick);
            // 
            // btnOtherEvaluationMST
            // 
            this.btnOtherEvaluationMST.Caption = "Other Evaluation MST";
            this.btnOtherEvaluationMST.Enabled = false;
            this.btnOtherEvaluationMST.Id = 6;
            this.btnOtherEvaluationMST.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOtherEvaluationMST.ImageOptions.LargeImage")));
            this.btnOtherEvaluationMST.Name = "btnOtherEvaluationMST";
            this.btnOtherEvaluationMST.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOtherEvaluationMST_ItemClick);
            // 
            // btnOtherValuableEvaluationMST
            // 
            this.btnOtherValuableEvaluationMST.Caption = "Other Valuable Evaluation MST";
            this.btnOtherValuableEvaluationMST.Enabled = false;
            this.btnOtherValuableEvaluationMST.Id = 7;
            this.btnOtherValuableEvaluationMST.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOtherValuableEvaluationMST.ImageOptions.Image")));
            this.btnOtherValuableEvaluationMST.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOtherValuableEvaluationMST.ImageOptions.LargeImage")));
            this.btnOtherValuableEvaluationMST.Name = "btnOtherValuableEvaluationMST";
            this.btnOtherValuableEvaluationMST.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOtherValuableEvaluationMST_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 8;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.LargeImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnHistoryNewMold
            // 
            this.btnHistoryNewMold.Caption = "New mold history";
            this.btnHistoryNewMold.Id = 9;
            this.btnHistoryNewMold.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHistoryNewMold.ImageOptions.SvgImage")));
            this.btnHistoryNewMold.Name = "btnHistoryNewMold";
            this.btnHistoryNewMold.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistoryNewMold_ItemClick);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Caption = "ADMIN";
            this.btnAdmin.Id = 10;
            this.btnAdmin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmin.ImageOptions.Image")));
            this.btnAdmin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAdmin.ImageOptions.LargeImage")));
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdmin_ItemClick);
            // 
            // btnPreparationTry
            // 
            this.btnPreparationTry.Caption = "Preparation Try Master";
            this.btnPreparationTry.Enabled = false;
            this.btnPreparationTry.Id = 11;
            this.btnPreparationTry.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPreparationTry.ImageOptions.Image")));
            this.btnPreparationTry.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPreparationTry.ImageOptions.LargeImage")));
            this.btnPreparationTry.Name = "btnPreparationTry";
            this.btnPreparationTry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreparationTry_ItemClick);
            // 
            // btnProductionPlan
            // 
            this.btnProductionPlan.Caption = "Production Plan";
            this.btnProductionPlan.Id = 12;
            this.btnProductionPlan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProductionPlan.ImageOptions.Image")));
            this.btnProductionPlan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProductionPlan.ImageOptions.LargeImage")));
            this.btnProductionPlan.Name = "btnProductionPlan";
            this.btnProductionPlan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProductionPlan_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewMoldMST);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnHistoryNewMold);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "New mold list";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnFeasibilityMST);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPreparationMST);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPreparationTry);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTrialMST);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnOtherEvaluationMST);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnOtherValuableEvaluationMST);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMassMST);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Master";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnProductionPlan);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Plan";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 745);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbon;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1440, 24);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnUser});
            this.menuStrip1.Location = new System.Drawing.Point(1322, 71);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(94, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnUser
            // 
            this.mnUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.mnUser.Image = global::APQP.Properties.Resources.BOUser_32x32;
            this.mnUser.Name = "mnUser";
            this.mnUser.Size = new System.Drawing.Size(86, 20);
            this.mnUser.Text = "Tài Khoản";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = global::APQP.Properties.Resources.AssignTo_32x32;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Log out";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Image = global::APQP.Properties.Resources.Action_ResetPassword_32x32;
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Change password";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Image = global::APQP.Properties.Resources.Action_Exit_32x32;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.thoátToolStripMenuItem.Text = "Exit";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // FRM_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 769);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbon);
            this.IconOptions.Image = global::APQP.Properties.Resources.iteration;
            this.IsMdiContainer = true;
            this.Name = "FRM_MAIN";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "APQP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_MAIN_FormClosed);
            this.Load += new System.EventHandler(this.FRM_MAIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNewMoldMST;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnFeasibilityMST;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnPreparationMST;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnUser;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private DevExpress.XtraBars.BarButtonItem btnMassMST;
        private DevExpress.XtraBars.BarButtonItem btnTrialMST;
        private DevExpress.XtraBars.BarButtonItem btnOtherEvaluationMST;
        private DevExpress.XtraBars.BarButtonItem btnOtherValuableEvaluationMST;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarButtonItem btnHistoryNewMold;
        private DevExpress.XtraBars.BarButtonItem btnAdmin;
        private DevExpress.XtraBars.BarButtonItem btnPreparationTry;
        private DevExpress.XtraBars.BarButtonItem btnProductionPlan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}