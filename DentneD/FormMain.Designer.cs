namespace DG.DentneD
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estimatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.setReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressesTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentComputedLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estimatesFootersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalRecordTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicesFootersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientAttachmentsTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxesDeductionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treatmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treatments1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.treatmentsTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treatmentsPricesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanDatadirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientsToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.documentsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(784, 24);
            this.menuStrip_main.TabIndex = 1;
            this.menuStrip_main.Text = "menuStrip_main";
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.patientsToolStripMenuItem.Text = "Patients";
            this.patientsToolStripMenuItem.Click += new System.EventHandler(this.patientsToolStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            this.appointmentsToolStripMenuItem.Click += new System.EventHandler(this.appointmentsToolStripMenuItem_Click);
            // 
            // documentsToolStripMenuItem
            // 
            this.documentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoicesToolStripMenuItem,
            this.estimatesToolStripMenuItem});
            this.documentsToolStripMenuItem.Name = "documentsToolStripMenuItem";
            this.documentsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.documentsToolStripMenuItem.Text = "Documents";
            // 
            // invoicesToolStripMenuItem
            // 
            this.invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            this.invoicesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.invoicesToolStripMenuItem.Text = "Invoices";
            this.invoicesToolStripMenuItem.Click += new System.EventHandler(this.invoicesToolStripMenuItem_Click);
            // 
            // estimatesToolStripMenuItem
            // 
            this.estimatesToolStripMenuItem.Name = "estimatesToolStripMenuItem";
            this.estimatesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.estimatesToolStripMenuItem.Text = "Estimates";
            this.estimatesToolStripMenuItem.Click += new System.EventHandler(this.estimatesToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runReportsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.setReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // runReportsToolStripMenuItem
            // 
            this.runReportsToolStripMenuItem.Name = "runReportsToolStripMenuItem";
            this.runReportsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.runReportsToolStripMenuItem.Text = "Run Reports";
            this.runReportsToolStripMenuItem.Click += new System.EventHandler(this.runReportsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 6);
            // 
            // setReportsToolStripMenuItem
            // 
            this.setReportsToolStripMenuItem.Name = "setReportsToolStripMenuItem";
            this.setReportsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.setReportsToolStripMenuItem.Text = "Set Reports";
            this.setReportsToolStripMenuItem.Click += new System.EventHandler(this.setReportsToolStripMenuItem_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addressesTypesToolStripMenuItem,
            this.contactTypesToolStripMenuItem,
            this.doctorsToolStripMenuItem,
            this.documentComputedLinesToolStripMenuItem,
            this.estimatesFootersToolStripMenuItem,
            this.medicalRecordTypesToolStripMenuItem,
            this.invoicesFootersToolStripMenuItem,
            this.patientAttachmentsTypesToolStripMenuItem,
            this.paymentTypesToolStripMenuItem,
            this.roomsToolStripMenuItem,
            this.taxesToolStripMenuItem,
            this.taxesDeductionsToolStripMenuItem,
            this.treatmentsToolStripMenuItem});
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tablesToolStripMenuItem.Text = "Tables";
            // 
            // addressesTypesToolStripMenuItem
            // 
            this.addressesTypesToolStripMenuItem.Name = "addressesTypesToolStripMenuItem";
            this.addressesTypesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.addressesTypesToolStripMenuItem.Text = "Addresses Types";
            this.addressesTypesToolStripMenuItem.Click += new System.EventHandler(this.addressesTypesToolStripMenuItem_Click);
            // 
            // contactTypesToolStripMenuItem
            // 
            this.contactTypesToolStripMenuItem.Name = "contactTypesToolStripMenuItem";
            this.contactTypesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.contactTypesToolStripMenuItem.Text = "Contact Types";
            this.contactTypesToolStripMenuItem.Click += new System.EventHandler(this.contactTypesToolStripMenuItem_Click);
            // 
            // doctorsToolStripMenuItem
            // 
            this.doctorsToolStripMenuItem.Name = "doctorsToolStripMenuItem";
            this.doctorsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.doctorsToolStripMenuItem.Text = "Doctors";
            this.doctorsToolStripMenuItem.Click += new System.EventHandler(this.doctorsToolStripMenuItem_Click);
            // 
            // documentComputedLinesToolStripMenuItem
            // 
            this.documentComputedLinesToolStripMenuItem.Name = "documentComputedLinesToolStripMenuItem";
            this.documentComputedLinesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.documentComputedLinesToolStripMenuItem.Text = "Document Computed Lines";
            this.documentComputedLinesToolStripMenuItem.Click += new System.EventHandler(this.documentComputedLinesToolStripMenuItem_Click);
            // 
            // estimatesFootersToolStripMenuItem
            // 
            this.estimatesFootersToolStripMenuItem.Name = "estimatesFootersToolStripMenuItem";
            this.estimatesFootersToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.estimatesFootersToolStripMenuItem.Text = "Estimates Footers";
            this.estimatesFootersToolStripMenuItem.Click += new System.EventHandler(this.estimatesFootersToolStripMenuItem_Click);
            // 
            // medicalRecordTypesToolStripMenuItem
            // 
            this.medicalRecordTypesToolStripMenuItem.Name = "medicalRecordTypesToolStripMenuItem";
            this.medicalRecordTypesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.medicalRecordTypesToolStripMenuItem.Text = "Medical Record Types";
            this.medicalRecordTypesToolStripMenuItem.Click += new System.EventHandler(this.medicalRecordTypesToolStripMenuItem_Click);
            // 
            // invoicesFootersToolStripMenuItem
            // 
            this.invoicesFootersToolStripMenuItem.Name = "invoicesFootersToolStripMenuItem";
            this.invoicesFootersToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.invoicesFootersToolStripMenuItem.Text = "Invoices Footers";
            this.invoicesFootersToolStripMenuItem.Click += new System.EventHandler(this.invoicesFootersToolStripMenuItem_Click);
            // 
            // patientAttachmentsTypesToolStripMenuItem
            // 
            this.patientAttachmentsTypesToolStripMenuItem.Name = "patientAttachmentsTypesToolStripMenuItem";
            this.patientAttachmentsTypesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.patientAttachmentsTypesToolStripMenuItem.Text = "Patient Attachments Types";
            this.patientAttachmentsTypesToolStripMenuItem.Click += new System.EventHandler(this.patientAttachmentsTypesToolStripMenuItem_Click);
            // 
            // paymentTypesToolStripMenuItem
            // 
            this.paymentTypesToolStripMenuItem.Name = "paymentTypesToolStripMenuItem";
            this.paymentTypesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.paymentTypesToolStripMenuItem.Text = "Payment Types";
            this.paymentTypesToolStripMenuItem.Click += new System.EventHandler(this.paymentTypesToolStripMenuItem_Click);
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.roomsToolStripMenuItem.Text = "Rooms";
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // taxesToolStripMenuItem
            // 
            this.taxesToolStripMenuItem.Name = "taxesToolStripMenuItem";
            this.taxesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.taxesToolStripMenuItem.Text = "Taxes";
            this.taxesToolStripMenuItem.Click += new System.EventHandler(this.taxesToolStripMenuItem_Click);
            // 
            // taxesDeductionsToolStripMenuItem
            // 
            this.taxesDeductionsToolStripMenuItem.Name = "taxesDeductionsToolStripMenuItem";
            this.taxesDeductionsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.taxesDeductionsToolStripMenuItem.Text = "Taxes Deductions";
            this.taxesDeductionsToolStripMenuItem.Click += new System.EventHandler(this.taxesDeductionsToolStripMenuItem_Click);
            // 
            // treatmentsToolStripMenuItem
            // 
            this.treatmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treatments1ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.treatmentsTypesToolStripMenuItem,
            this.treatmentsPricesListToolStripMenuItem});
            this.treatmentsToolStripMenuItem.Name = "treatmentsToolStripMenuItem";
            this.treatmentsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.treatmentsToolStripMenuItem.Text = "Treatments";
            // 
            // treatments1ToolStripMenuItem
            // 
            this.treatments1ToolStripMenuItem.Name = "treatments1ToolStripMenuItem";
            this.treatments1ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.treatments1ToolStripMenuItem.Text = "Treatments";
            this.treatments1ToolStripMenuItem.Click += new System.EventHandler(this.treatments1ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // treatmentsTypesToolStripMenuItem
            // 
            this.treatmentsTypesToolStripMenuItem.Name = "treatmentsTypesToolStripMenuItem";
            this.treatmentsTypesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.treatmentsTypesToolStripMenuItem.Text = "Treatments Types";
            this.treatmentsTypesToolStripMenuItem.Click += new System.EventHandler(this.treatmentsTypesToolStripMenuItem_Click);
            // 
            // treatmentsPricesListToolStripMenuItem
            // 
            this.treatmentsPricesListToolStripMenuItem.Name = "treatmentsPricesListToolStripMenuItem";
            this.treatmentsPricesListToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.treatmentsPricesListToolStripMenuItem.Text = "Treatments Prices List";
            this.treatmentsPricesListToolStripMenuItem.Click += new System.EventHandler(this.treatmentsPricesListToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.cleanDatadirToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // cleanDatadirToolStripMenuItem
            // 
            this.cleanDatadirToolStripMenuItem.Name = "cleanDatadirToolStripMenuItem";
            this.cleanDatadirToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.cleanDatadirToolStripMenuItem.Text = "Clean Datadir";
            this.cleanDatadirToolStripMenuItem.Click += new System.EventHandler(this.cleanDatadirToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeAllToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // minimizeAllToolStripMenuItem
            // 
            this.minimizeAllToolStripMenuItem.Name = "minimizeAllToolStripMenuItem";
            this.minimizeAllToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.minimizeAllToolStripMenuItem.Text = "Minimize All";
            this.minimizeAllToolStripMenuItem.Click += new System.EventHandler(this.minimizeAllToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.menuStrip_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip_main;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DentneD";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxesDeductionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoicesFootersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treatmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treatments1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem treatmentsTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treatmentsPricesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressesTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicalRecordTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estimatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientAttachmentsTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estimatesFootersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem setReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanDatadirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentComputedLinesToolStripMenuItem;
    }
}

