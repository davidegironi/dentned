#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Forms;
using DG.DentneD.Model;
using DG.UI.GHF;
using System;
using System.Windows.Forms;

namespace DG.DentneD
{
    public partial class FormMain : DGUIGHFFormMain
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            Initialize(Program.uighfApplication);
        }
        
        /// <summary>
        /// Load handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Perform the first connection
            try
            {
                DentneDModel dentnedModel = new DentneDModel();
                dentnedModel.Doctors.Find(-1);
            }
            catch
            {
                MessageBox.Show("Database connection error. This application will be closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Add components language
        /// </summary>
        public override void AddLanguageComponents()
        {
            //main ToolStripMenuItem
            LanguageHelper.AddComponent(patientsToolStripMenuItem);
            LanguageHelper.AddComponent(appointmentsToolStripMenuItem);
            LanguageHelper.AddComponent(documentsToolStripMenuItem);
            LanguageHelper.AddComponent(reportsToolStripMenuItem);
            LanguageHelper.AddComponent(tablesToolStripMenuItem);
            LanguageHelper.AddComponent(toolsToolStripMenuItem);
            LanguageHelper.AddComponent(windowsToolStripMenuItem);
            LanguageHelper.AddComponent(exitToolStripMenuItem);
            LanguageHelper.AddComponent(aboutToolStripMenuItem);
            //sub ToolStripMenuItem
            LanguageHelper.AddComponent(estimatesToolStripMenuItem);
            LanguageHelper.AddComponent(invoicesToolStripMenuItem);
            LanguageHelper.AddComponent(runReportsToolStripMenuItem);
            LanguageHelper.AddComponent(setReportsToolStripMenuItem);
            LanguageHelper.AddComponent(addressesTypesToolStripMenuItem);
            LanguageHelper.AddComponent(contactTypesToolStripMenuItem);
            LanguageHelper.AddComponent(doctorsToolStripMenuItem);
            LanguageHelper.AddComponent(estimatesFootersToolStripMenuItem);
            LanguageHelper.AddComponent(medicalRecordTypesToolStripMenuItem);
            LanguageHelper.AddComponent(invoicesFootersToolStripMenuItem);
            LanguageHelper.AddComponent(patientAttachmentsTypesToolStripMenuItem);
            LanguageHelper.AddComponent(paymentTypesToolStripMenuItem);
            LanguageHelper.AddComponent(roomsToolStripMenuItem);
            LanguageHelper.AddComponent(taxesToolStripMenuItem);
            LanguageHelper.AddComponent(taxesDeductionsToolStripMenuItem);
            LanguageHelper.AddComponent(treatmentsToolStripMenuItem);
            LanguageHelper.AddComponent(treatments1ToolStripMenuItem);
            LanguageHelper.AddComponent(treatmentsTypesToolStripMenuItem);
            LanguageHelper.AddComponent(treatmentsPricesListToolStripMenuItem);
            LanguageHelper.AddComponent(backupToolStripMenuItem);
            LanguageHelper.AddComponent(minimizeAllToolStripMenuItem);
            LanguageHelper.AddComponent(closeAllToolStripMenuItem);
        }

        /// <summary>
        /// Add additional language
        /// </summary>
        public override void SetAdditionalLanguage()
        {
            DentneDModel dentnedModel = new DentneDModel();
            dentnedModel.LanguageHelper.LoadFromFile(Program.uighfApplication.LanguageFilename);
            LanguageHelper.AddAdditionalLanguage(dentnedModel.LanguageHelper.Get());
        }
        /// <summary>
        /// Minimize All click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizeAllToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MinimizeAllForms(this);
        }

        /// <summary>
        /// Close All click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeAllToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            CloseAllForms(this);
        }

        /// <summary>
        /// Exit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ExitApplication(this);
        }

        /// <summary>
        /// About click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DisplayAbout();
        }

        /// <summary>
        /// Doctors form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormDoctors));
        }

        /// <summary>
        /// Rooms form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormRooms));
        }

        /// <summary>
        /// Taxes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormTaxes));
        }

        /// <summary>
        /// TaxesDeductions form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taxesDeductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormTaxesDeductions));
        }

        /// <summary>
        /// InvoiesFooters form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoicesFootersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormInvoicesFooters));
        }

        /// <summary>
        /// EstimatesFooters form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimatesFootersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormEstimatesFooters));
        }

        /// <summary>
        /// PaymentsTypes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paymentTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormPaymentsTypes));
        }

        /// <summary>
        /// Treatments form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormTreatments));
        }

        /// <summary>
        /// TreatmentsTypes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatmentsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormTreatmentsTypes));
        }

        /// <summary>
        /// TreatmentsPricesLists form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatmentsPricesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormTreatmentsPricesLists));
        }

        /// <summary>
        /// AddressesTypes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addressesTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormAddressesTypes));
        }

        /// <summary>
        /// ContactsTypes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contactTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormContactsTypes));
        }

        /// <summary>
        /// MedicalrecordsTypes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void medicalRecordTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormMedicalrecordsTypes));
        }

        /// <summary>
        /// PatientsAttachmentsTypes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientAttachmentsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormPatientsAttachmentsTypes));
        }
        
        /// <summary>
        /// Patients form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormPatients));
        }

        /// <summary>
        /// Appointments form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormAppointments));
        }

        /// <summary>
        /// Invoices form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormInvoices));
        }

        /// <summary>
        /// Estimates form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormEstimates));
        }

        /// <summary>
        /// Reportsrun form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormReportsrun));
        }

        /// <summary>
        /// Reports form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(this, typeof(FormReports));
        }
        
                
    }
}
