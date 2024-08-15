using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using APQP.DB;
using APQP.FORM.NEW_MOLD_MST;
using APQP.FORM._03._FEASIBILITY;
using APQP.FORM._04._PREPARATION;
using APQP.FORM._06._MASS_PRODUCTION;
using APQP.FORM._05_TRIAL_PRODUCTION;
using APQP.FORM._01_NEW_MOLD_MST;
using APQP.FORM.ADMIN;

namespace APQP.FORM
{
    public partial class FRM_MAIN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FRM_MAIN()
        {
            InitializeComponent();
        }
        private Form CheckForm(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }
        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_NEW_MOLD_LIST));
            if (frm == null)
            {
                FRM_NEW_MOLD_LIST f = new FRM_NEW_MOLD_LIST();
                f.MdiParent = this;
                f.Show();
                mnUser.Text = Constaint._nameUser;
                if (Constaint._access != "01")
                {
                    btnAdmin.Enabled = false;
                }
                if (Constaint._access == "01" || Constaint._sectionShort == "QA")
                {
                    btnFeasibilityMST.Enabled = true;
                    btnOtherEvaluationMST.Enabled = true;
                    btnPreparationMST.Enabled = true;
                    btnOtherValuableEvaluationMST.Enabled = true;
                    btnTrialMST.Enabled = true;
                    btnMassMST.Enabled = true;
                    btnPreparationTry.Enabled = true;
                }
            }
            else
            {
                frm.Activate();
            }
        }

        private void FRM_MAIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnFeasibilityMST_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_FEASIBILITY_MST f = new FRM_FEASIBILITY_MST();
            f.Show();
        }

        private void btnPreparationMST_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_PREPARATION_MST f = new FRM_PREPARATION_MST();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN f = new FRM_LOGIN();
            f.Show();
            this.Hide();
        }

        private void btnMass_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_MASS_PRODUCTION_MST f = new FRM_MASS_PRODUCTION_MST();
            f.Show();
        }

        private void btnTrialMST_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_TRIAL_PRODUCTION_MST f = new FRM_TRIAL_PRODUCTION_MST();
            f.Show();
        }

        private void btnOtherEvaluationMST_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_OTHER_EVALUATION_MST f = new FRM_OTHER_EVALUATION_MST();
            f.Show();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnOtherValuableEvaluationMST_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_OTHER_VALUABLE_EVALUATION_MST f = new FRM_OTHER_VALUABLE_EVALUATION_MST();
            f.Show();
        }

        private void btnHistoryNewMold_ItemClick(object sender, ItemClickEventArgs e)
        {

            Form frm = CheckForm(typeof(FRM_HISTORY_NEW_MOLD));
            if (frm == null)
            {
                FRM_HISTORY_NEW_MOLD f = new FRM_HISTORY_NEW_MOLD();
                f.MdiParent = this;
                f.Show();
                mnUser.Text = Constaint._nameUser;
            }
            else
            {
                frm.Activate();
            }

        }

        private void btnAdmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_ACCOUNT_LIST f = new FRM_ACCOUNT_LIST();
            f.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USER_CHANGE_PASSWORD f = new FRM_USER_CHANGE_PASSWORD();
            f.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNewMoldMST_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_NEW_MOLD_LIST));
            if (frm == null)
            {
                FRM_NEW_MOLD_LIST f = new FRM_NEW_MOLD_LIST();
                f.MdiParent = this;
                f.Show();
                mnUser.Text = Constaint._nameUser;
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnPreparationTry_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_PREPARATION_TRY_MST f = new FRM_PREPARATION_TRY_MST();
            f.ShowDialog();
        }

        private void btnProductionPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_PRODUCTION_PLAN));
            if (frm == null)
            {
                FRM_PRODUCTION_PLAN f = new FRM_PRODUCTION_PLAN();
                f.MdiParent = this;
                f.Show();
                mnUser.Text = Constaint._nameUser;
            }
            else
            {
                frm.Activate();
            }
        }
    }
}