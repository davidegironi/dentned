namespace DG.DentneD.Forms
{
    partial class FormInvoices
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
            System.Windows.Forms.Label invoices_idLabel;
            System.Windows.Forms.Label invoices_numberLabel;
            System.Windows.Forms.Label invoices_doctorLabel;
            System.Windows.Forms.Label invoices_patientLabel;
            System.Windows.Forms.Label invoices_dateLabel;
            System.Windows.Forms.Label invoices_paymentLabel;
            System.Windows.Forms.Label invoices_footerLabel;
            System.Windows.Forms.Label invoices_deductiontaxrateLabel;
            System.Windows.Forms.Label invoiceslines_idLabel;
            System.Windows.Forms.Label invoiceslines_codeLabel;
            System.Windows.Forms.Label invoiceslines_descriptionLabel;
            System.Windows.Forms.Label invoiceslines_quantityLabel;
            System.Windows.Forms.Label invoiceslines_taxrateLabel;
            System.Windows.Forms.Label invoiceslines_unitpriceLabel;
            System.Windows.Forms.Label treatments_idLabel;
            System.Windows.Forms.Label patientstreatments_idLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvoices));
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabInvoices = new System.Windows.Forms.TabPage();
            this.panel_tabInvoices_data = new System.Windows.Forms.Panel();
            this.patients_idComboBox = new System.Windows.Forms.ComboBox();
            this.invoicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doctors_idComboBox = new System.Windows.Forms.ComboBox();
            this.invoices_deductiontaxrateComboBox = new System.Windows.Forms.ComboBox();
            this.invoices_ispaidCheckBox = new System.Windows.Forms.CheckBox();
            this.invoices_deductiontaxrateTextBox = new System.Windows.Forms.TextBox();
            this.invoices_footerComboBox = new System.Windows.Forms.ComboBox();
            this.invoices_footerTextBox = new System.Windows.Forms.TextBox();
            this.invoices_paymentComboBox = new System.Windows.Forms.ComboBox();
            this.invoices_paymentTextBox = new System.Windows.Forms.TextBox();
            this.invoices_patientTextBox = new System.Windows.Forms.TextBox();
            this.invoices_doctorTextBox = new System.Windows.Forms.TextBox();
            this.invoices_dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.invoices_numberTextBox = new System.Windows.Forms.TextBox();
            this.invoices_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabInvoices_updates = new System.Windows.Forms.Panel();
            this.button_tabInvoices_cancel = new System.Windows.Forms.Button();
            this.button_tabInvoices_save = new System.Windows.Forms.Button();
            this.panel_tabInvoices_actions = new System.Windows.Forms.Panel();
            this.button_tabInvoices_print = new System.Windows.Forms.Button();
            this.button_tabInvoices_setpayed = new System.Windows.Forms.Button();
            this.button_tabInvoices_delete = new System.Windows.Forms.Button();
            this.button_tabInvoices_edit = new System.Windows.Forms.Button();
            this.button_tabInvoices_new = new System.Windows.Forms.Button();
            this.tabPage_tabInvoicesLines = new System.Windows.Forms.TabPage();
            this.panel_tabInvoicesLines_data = new System.Windows.Forms.Panel();
            this.groupBox_tabInvoicesLines_filler = new System.Windows.Forms.GroupBox();
            this.treatments_idComboBox = new System.Windows.Forms.ComboBox();
            this.patientstreatments_idComboBox = new System.Windows.Forms.ComboBox();
            this.invoiceslinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientstreatmentsTextBox = new System.Windows.Forms.TextBox();
            this.invoiceslines_taxrateComboBox = new System.Windows.Forms.ComboBox();
            this.invoiceslines_unitpriceTextBox = new System.Windows.Forms.TextBox();
            this.invoiceslines_taxrateTextBox = new System.Windows.Forms.TextBox();
            this.invoiceslines_quantityTextBox = new System.Windows.Forms.TextBox();
            this.invoiceslines_descriptionTextBox = new System.Windows.Forms.TextBox();
            this.invoiceslines_codeTextBox = new System.Windows.Forms.TextBox();
            this.invoiceslines_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabInvoicesLines_updates = new System.Windows.Forms.Panel();
            this.button_tabInvoicesLines_cancel = new System.Windows.Forms.Button();
            this.button_tabInvoicesLines_save = new System.Windows.Forms.Button();
            this.panel_tabInvoicesLines_actions = new System.Windows.Forms.Panel();
            this.button_tabInvoicesLines_delete = new System.Windows.Forms.Button();
            this.button_tabInvoicesLines_edit = new System.Windows.Forms.Button();
            this.button_tabInvoicesLines_new = new System.Windows.Forms.Button();
            this.panel_tabInvoicesLines_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_tabInvoicesLines_list = new Zuby.ADGV.AdvancedDataGridView();
            this.invoiceslinesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vInvoicesLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.invoicesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ispayedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vInvoicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_listtotal = new System.Windows.Forms.Panel();
            this.totalpaiedTextBox = new System.Windows.Forms.TextBox();
            this.totalpaiedLabel = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.panel_filters = new System.Windows.Forms.Panel();
            this.comboBox_filterDoctors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            invoices_idLabel = new System.Windows.Forms.Label();
            invoices_numberLabel = new System.Windows.Forms.Label();
            invoices_doctorLabel = new System.Windows.Forms.Label();
            invoices_patientLabel = new System.Windows.Forms.Label();
            invoices_dateLabel = new System.Windows.Forms.Label();
            invoices_paymentLabel = new System.Windows.Forms.Label();
            invoices_footerLabel = new System.Windows.Forms.Label();
            invoices_deductiontaxrateLabel = new System.Windows.Forms.Label();
            invoiceslines_idLabel = new System.Windows.Forms.Label();
            invoiceslines_codeLabel = new System.Windows.Forms.Label();
            invoiceslines_descriptionLabel = new System.Windows.Forms.Label();
            invoiceslines_quantityLabel = new System.Windows.Forms.Label();
            invoiceslines_taxrateLabel = new System.Windows.Forms.Label();
            invoiceslines_unitpriceLabel = new System.Windows.Forms.Label();
            treatments_idLabel = new System.Windows.Forms.Label();
            patientstreatments_idLabel = new System.Windows.Forms.Label();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabInvoices.SuspendLayout();
            this.panel_tabInvoices_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesBindingSource)).BeginInit();
            this.panel_tabInvoices_updates.SuspendLayout();
            this.panel_tabInvoices_actions.SuspendLayout();
            this.tabPage_tabInvoicesLines.SuspendLayout();
            this.panel_tabInvoicesLines_data.SuspendLayout();
            this.groupBox_tabInvoicesLines_filler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceslinesBindingSource)).BeginInit();
            this.panel_tabInvoicesLines_updates.SuspendLayout();
            this.panel_tabInvoicesLines_actions.SuspendLayout();
            this.panel_tabInvoicesLines_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_tabInvoicesLines_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInvoicesLinesBindingSource)).BeginInit();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInvoicesBindingSource)).BeginInit();
            this.panel_listtotal.SuspendLayout();
            this.panel_filters.SuspendLayout();
            this.SuspendLayout();
            // 
            // invoices_idLabel
            // 
            invoices_idLabel.AutoSize = true;
            invoices_idLabel.Location = new System.Drawing.Point(9, 9);
            invoices_idLabel.Name = "invoices_idLabel";
            invoices_idLabel.Size = new System.Drawing.Size(19, 13);
            invoices_idLabel.TabIndex = 0;
            invoices_idLabel.Text = "Id:";
            // 
            // invoices_numberLabel
            // 
            invoices_numberLabel.AutoSize = true;
            invoices_numberLabel.Location = new System.Drawing.Point(9, 48);
            invoices_numberLabel.Name = "invoices_numberLabel";
            invoices_numberLabel.Size = new System.Drawing.Size(47, 13);
            invoices_numberLabel.TabIndex = 2;
            invoices_numberLabel.Text = "Number:";
            // 
            // invoices_doctorLabel
            // 
            invoices_doctorLabel.AutoSize = true;
            invoices_doctorLabel.Location = new System.Drawing.Point(11, 98);
            invoices_doctorLabel.Name = "invoices_doctorLabel";
            invoices_doctorLabel.Size = new System.Drawing.Size(42, 13);
            invoices_doctorLabel.TabIndex = 4;
            invoices_doctorLabel.Text = "Doctor:";
            // 
            // invoices_patientLabel
            // 
            invoices_patientLabel.AutoSize = true;
            invoices_patientLabel.Location = new System.Drawing.Point(11, 201);
            invoices_patientLabel.Name = "invoices_patientLabel";
            invoices_patientLabel.Size = new System.Drawing.Size(43, 13);
            invoices_patientLabel.TabIndex = 6;
            invoices_patientLabel.Text = "Patient:";
            // 
            // invoices_dateLabel
            // 
            invoices_dateLabel.AutoSize = true;
            invoices_dateLabel.Location = new System.Drawing.Point(125, 48);
            invoices_dateLabel.Name = "invoices_dateLabel";
            invoices_dateLabel.Size = new System.Drawing.Size(33, 13);
            invoices_dateLabel.TabIndex = 8;
            invoices_dateLabel.Text = "Date:";
            // 
            // invoices_paymentLabel
            // 
            invoices_paymentLabel.AutoSize = true;
            invoices_paymentLabel.Location = new System.Drawing.Point(11, 304);
            invoices_paymentLabel.Name = "invoices_paymentLabel";
            invoices_paymentLabel.Size = new System.Drawing.Size(51, 13);
            invoices_paymentLabel.TabIndex = 12;
            invoices_paymentLabel.Text = "Payment:";
            // 
            // invoices_footerLabel
            // 
            invoices_footerLabel.AutoSize = true;
            invoices_footerLabel.Location = new System.Drawing.Point(14, 407);
            invoices_footerLabel.Name = "invoices_footerLabel";
            invoices_footerLabel.Size = new System.Drawing.Size(40, 13);
            invoices_footerLabel.TabIndex = 15;
            invoices_footerLabel.Text = "Footer:";
            // 
            // invoices_deductiontaxrateLabel
            // 
            invoices_deductiontaxrateLabel.AutoSize = true;
            invoices_deductiontaxrateLabel.Location = new System.Drawing.Point(11, 502);
            invoices_deductiontaxrateLabel.Name = "invoices_deductiontaxrateLabel";
            invoices_deductiontaxrateLabel.Size = new System.Drawing.Size(106, 13);
            invoices_deductiontaxrateLabel.TabIndex = 18;
            invoices_deductiontaxrateLabel.Text = "Deduction Tax Rate:";
            // 
            // invoiceslines_idLabel
            // 
            invoiceslines_idLabel.AutoSize = true;
            invoiceslines_idLabel.Location = new System.Drawing.Point(9, 9);
            invoiceslines_idLabel.Name = "invoiceslines_idLabel";
            invoiceslines_idLabel.Size = new System.Drawing.Size(19, 13);
            invoiceslines_idLabel.TabIndex = 0;
            invoiceslines_idLabel.Text = "Id:";
            // 
            // invoiceslines_codeLabel
            // 
            invoiceslines_codeLabel.AutoSize = true;
            invoiceslines_codeLabel.Location = new System.Drawing.Point(9, 114);
            invoiceslines_codeLabel.Name = "invoiceslines_codeLabel";
            invoiceslines_codeLabel.Size = new System.Drawing.Size(35, 13);
            invoiceslines_codeLabel.TabIndex = 2;
            invoiceslines_codeLabel.Text = "Code:";
            // 
            // invoiceslines_descriptionLabel
            // 
            invoiceslines_descriptionLabel.AutoSize = true;
            invoiceslines_descriptionLabel.Location = new System.Drawing.Point(9, 153);
            invoiceslines_descriptionLabel.Name = "invoiceslines_descriptionLabel";
            invoiceslines_descriptionLabel.Size = new System.Drawing.Size(63, 13);
            invoiceslines_descriptionLabel.TabIndex = 4;
            invoiceslines_descriptionLabel.Text = "Description:";
            // 
            // invoiceslines_quantityLabel
            // 
            invoiceslines_quantityLabel.AutoSize = true;
            invoiceslines_quantityLabel.Location = new System.Drawing.Point(100, 114);
            invoiceslines_quantityLabel.Name = "invoiceslines_quantityLabel";
            invoiceslines_quantityLabel.Size = new System.Drawing.Size(49, 13);
            invoiceslines_quantityLabel.TabIndex = 6;
            invoiceslines_quantityLabel.Text = "Quantity:";
            // 
            // invoiceslines_taxrateLabel
            // 
            invoiceslines_taxrateLabel.AutoSize = true;
            invoiceslines_taxrateLabel.Location = new System.Drawing.Point(282, 114);
            invoiceslines_taxrateLabel.Name = "invoiceslines_taxrateLabel";
            invoiceslines_taxrateLabel.Size = new System.Drawing.Size(54, 13);
            invoiceslines_taxrateLabel.TabIndex = 8;
            invoiceslines_taxrateLabel.Text = "Tax Rate:";
            // 
            // invoiceslines_unitpriceLabel
            // 
            invoiceslines_unitpriceLabel.AutoSize = true;
            invoiceslines_unitpriceLabel.Location = new System.Drawing.Point(180, 114);
            invoiceslines_unitpriceLabel.Name = "invoiceslines_unitpriceLabel";
            invoiceslines_unitpriceLabel.Size = new System.Drawing.Size(34, 13);
            invoiceslines_unitpriceLabel.TabIndex = 10;
            invoiceslines_unitpriceLabel.Text = "Price:";
            // 
            // treatments_idLabel
            // 
            treatments_idLabel.AutoSize = true;
            treatments_idLabel.Location = new System.Drawing.Point(6, 16);
            treatments_idLabel.Name = "treatments_idLabel";
            treatments_idLabel.Size = new System.Drawing.Size(58, 13);
            treatments_idLabel.TabIndex = 13;
            treatments_idLabel.Text = "Treatment:";
            // 
            // patientstreatments_idLabel
            // 
            patientstreatments_idLabel.AutoSize = true;
            patientstreatments_idLabel.Location = new System.Drawing.Point(172, 16);
            patientstreatments_idLabel.Name = "patientstreatments_idLabel";
            patientstreatments_idLabel.Size = new System.Drawing.Size(94, 13);
            patientstreatments_idLabel.TabIndex = 15;
            patientstreatments_idLabel.Text = "Patient Treatment:";
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.tabControl_main);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(284, 0);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(500, 562);
            this.panel_data.TabIndex = 9;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabInvoices);
            this.tabControl_main.Controls.Add(this.tabPage_tabInvoicesLines);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabInvoices
            // 
            this.tabPage_tabInvoices.AutoScroll = true;
            this.tabPage_tabInvoices.Controls.Add(this.panel_tabInvoices_data);
            this.tabPage_tabInvoices.Controls.Add(this.panel_tabInvoices_updates);
            this.tabPage_tabInvoices.Controls.Add(this.panel_tabInvoices_actions);
            this.tabPage_tabInvoices.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabInvoices.Name = "tabPage_tabInvoices";
            this.tabPage_tabInvoices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabInvoices.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabInvoices.TabIndex = 0;
            this.tabPage_tabInvoices.Text = "Invoices";
            this.tabPage_tabInvoices.UseVisualStyleBackColor = true;
            // 
            // panel_tabInvoices_data
            // 
            this.panel_tabInvoices_data.Controls.Add(this.patients_idComboBox);
            this.panel_tabInvoices_data.Controls.Add(this.doctors_idComboBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_deductiontaxrateComboBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_ispaidCheckBox);
            this.panel_tabInvoices_data.Controls.Add(invoices_deductiontaxrateLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_deductiontaxrateTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_footerComboBox);
            this.panel_tabInvoices_data.Controls.Add(invoices_footerLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_footerTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_paymentComboBox);
            this.panel_tabInvoices_data.Controls.Add(invoices_paymentLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_paymentTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_patientTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_doctorTextBox);
            this.panel_tabInvoices_data.Controls.Add(invoices_dateLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_dateDateTimePicker);
            this.panel_tabInvoices_data.Controls.Add(invoices_patientLabel);
            this.panel_tabInvoices_data.Controls.Add(invoices_doctorLabel);
            this.panel_tabInvoices_data.Controls.Add(invoices_numberLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_numberTextBox);
            this.panel_tabInvoices_data.Controls.Add(invoices_idLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_idTextBox);
            this.panel_tabInvoices_data.Location = new System.Drawing.Point(6, 44);
            this.panel_tabInvoices_data.Name = "panel_tabInvoices_data";
            this.panel_tabInvoices_data.Size = new System.Drawing.Size(462, 542);
            this.panel_tabInvoices_data.TabIndex = 2;
            // 
            // patients_idComboBox
            // 
            this.patients_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.patients_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patients_idComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.invoicesBindingSource, "patients_id", true));
            this.patients_idComboBox.FormattingEnabled = true;
            this.patients_idComboBox.Location = new System.Drawing.Point(67, 193);
            this.patients_idComboBox.Name = "patients_idComboBox";
            this.patients_idComboBox.Size = new System.Drawing.Size(121, 21);
            this.patients_idComboBox.TabIndex = 24;
            this.patients_idComboBox.SelectedIndexChanged += new System.EventHandler(this.patients_idComboBox_SelectedIndexChanged);
            this.patients_idComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.patients_idComboBox_KeyPress);
            // 
            // invoicesBindingSource
            // 
            this.invoicesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.invoices);
            // 
            // doctors_idComboBox
            // 
            this.doctors_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.doctors_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.doctors_idComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.invoicesBindingSource, "doctors_id", true));
            this.doctors_idComboBox.FormattingEnabled = true;
            this.doctors_idComboBox.Location = new System.Drawing.Point(68, 90);
            this.doctors_idComboBox.Name = "doctors_idComboBox";
            this.doctors_idComboBox.Size = new System.Drawing.Size(121, 21);
            this.doctors_idComboBox.TabIndex = 23;
            this.doctors_idComboBox.SelectedIndexChanged += new System.EventHandler(this.doctors_idComboBox_SelectedIndexChanged);
            this.doctors_idComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.doctors_idComboBox_KeyPress);
            // 
            // invoices_deductiontaxrateComboBox
            // 
            this.invoices_deductiontaxrateComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.invoices_deductiontaxrateComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.invoices_deductiontaxrateComboBox.FormattingEnabled = true;
            this.invoices_deductiontaxrateComboBox.Location = new System.Drawing.Point(88, 517);
            this.invoices_deductiontaxrateComboBox.Name = "invoices_deductiontaxrateComboBox";
            this.invoices_deductiontaxrateComboBox.Size = new System.Drawing.Size(100, 21);
            this.invoices_deductiontaxrateComboBox.TabIndex = 22;
            this.invoices_deductiontaxrateComboBox.SelectedIndexChanged += new System.EventHandler(this.invoices_deductiontaxrateComboBox_SelectedIndexChanged);
            this.invoices_deductiontaxrateComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoices_deductiontaxrateComboBox_KeyPress);
            // 
            // invoices_ispaidCheckBox
            // 
            this.invoices_ispaidCheckBox.AutoSize = true;
            this.invoices_ispaidCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.invoicesBindingSource, "invoices_ispaid", true));
            this.invoices_ispaidCheckBox.Location = new System.Drawing.Point(375, 66);
            this.invoices_ispaidCheckBox.Name = "invoices_ispaidCheckBox";
            this.invoices_ispaidCheckBox.Size = new System.Drawing.Size(67, 17);
            this.invoices_ispaidCheckBox.TabIndex = 21;
            this.invoices_ispaidCheckBox.Text = "Is Payed";
            this.invoices_ispaidCheckBox.UseVisualStyleBackColor = true;
            // 
            // invoices_deductiontaxrateTextBox
            // 
            this.invoices_deductiontaxrateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_deductiontaxrate", true));
            this.invoices_deductiontaxrateTextBox.Location = new System.Drawing.Point(12, 518);
            this.invoices_deductiontaxrateTextBox.Name = "invoices_deductiontaxrateTextBox";
            this.invoices_deductiontaxrateTextBox.Size = new System.Drawing.Size(70, 20);
            this.invoices_deductiontaxrateTextBox.TabIndex = 19;
            // 
            // invoices_footerComboBox
            // 
            this.invoices_footerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.invoices_footerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.invoices_footerComboBox.FormattingEnabled = true;
            this.invoices_footerComboBox.Location = new System.Drawing.Point(68, 399);
            this.invoices_footerComboBox.Name = "invoices_footerComboBox";
            this.invoices_footerComboBox.Size = new System.Drawing.Size(121, 21);
            this.invoices_footerComboBox.TabIndex = 17;
            this.invoices_footerComboBox.SelectedIndexChanged += new System.EventHandler(this.invoices_footerComboBox_SelectedIndexChanged);
            this.invoices_footerComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoices_footerComboBox_KeyPress);
            // 
            // invoices_footerTextBox
            // 
            this.invoices_footerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_footer", true));
            this.invoices_footerTextBox.Location = new System.Drawing.Point(12, 426);
            this.invoices_footerTextBox.Multiline = true;
            this.invoices_footerTextBox.Name = "invoices_footerTextBox";
            this.invoices_footerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.invoices_footerTextBox.Size = new System.Drawing.Size(430, 70);
            this.invoices_footerTextBox.TabIndex = 16;
            this.invoices_footerTextBox.WordWrap = false;
            // 
            // invoices_paymentComboBox
            // 
            this.invoices_paymentComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.invoices_paymentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.invoices_paymentComboBox.FormattingEnabled = true;
            this.invoices_paymentComboBox.Location = new System.Drawing.Point(68, 296);
            this.invoices_paymentComboBox.Name = "invoices_paymentComboBox";
            this.invoices_paymentComboBox.Size = new System.Drawing.Size(121, 21);
            this.invoices_paymentComboBox.TabIndex = 14;
            this.invoices_paymentComboBox.SelectedIndexChanged += new System.EventHandler(this.invoices_paymentComboBox_SelectedIndexChanged);
            this.invoices_paymentComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoices_paymentComboBox_KeyPress);
            // 
            // invoices_paymentTextBox
            // 
            this.invoices_paymentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_payment", true));
            this.invoices_paymentTextBox.Location = new System.Drawing.Point(12, 323);
            this.invoices_paymentTextBox.Multiline = true;
            this.invoices_paymentTextBox.Name = "invoices_paymentTextBox";
            this.invoices_paymentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.invoices_paymentTextBox.Size = new System.Drawing.Size(430, 70);
            this.invoices_paymentTextBox.TabIndex = 13;
            this.invoices_paymentTextBox.WordWrap = false;
            // 
            // invoices_patientTextBox
            // 
            this.invoices_patientTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_patient", true));
            this.invoices_patientTextBox.Location = new System.Drawing.Point(12, 220);
            this.invoices_patientTextBox.Multiline = true;
            this.invoices_patientTextBox.Name = "invoices_patientTextBox";
            this.invoices_patientTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.invoices_patientTextBox.Size = new System.Drawing.Size(430, 70);
            this.invoices_patientTextBox.TabIndex = 12;
            this.invoices_patientTextBox.WordWrap = false;
            // 
            // invoices_doctorTextBox
            // 
            this.invoices_doctorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_doctor", true));
            this.invoices_doctorTextBox.Location = new System.Drawing.Point(12, 117);
            this.invoices_doctorTextBox.Multiline = true;
            this.invoices_doctorTextBox.Name = "invoices_doctorTextBox";
            this.invoices_doctorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.invoices_doctorTextBox.Size = new System.Drawing.Size(430, 70);
            this.invoices_doctorTextBox.TabIndex = 11;
            this.invoices_doctorTextBox.WordWrap = false;
            // 
            // invoices_dateDateTimePicker
            // 
            this.invoices_dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.invoicesBindingSource, "invoices_date", true));
            this.invoices_dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.invoices_dateDateTimePicker.Location = new System.Drawing.Point(128, 64);
            this.invoices_dateDateTimePicker.Name = "invoices_dateDateTimePicker";
            this.invoices_dateDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.invoices_dateDateTimePicker.TabIndex = 9;
            // 
            // invoices_numberTextBox
            // 
            this.invoices_numberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_number", true));
            this.invoices_numberTextBox.Location = new System.Drawing.Point(12, 64);
            this.invoices_numberTextBox.Name = "invoices_numberTextBox";
            this.invoices_numberTextBox.Size = new System.Drawing.Size(100, 20);
            this.invoices_numberTextBox.TabIndex = 3;
            // 
            // invoices_idTextBox
            // 
            this.invoices_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_id", true));
            this.invoices_idTextBox.Enabled = false;
            this.invoices_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.invoices_idTextBox.Name = "invoices_idTextBox";
            this.invoices_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.invoices_idTextBox.TabIndex = 1;
            // 
            // panel_tabInvoices_updates
            // 
            this.panel_tabInvoices_updates.Controls.Add(this.button_tabInvoices_cancel);
            this.panel_tabInvoices_updates.Controls.Add(this.button_tabInvoices_save);
            this.panel_tabInvoices_updates.Location = new System.Drawing.Point(6, 592);
            this.panel_tabInvoices_updates.Name = "panel_tabInvoices_updates";
            this.panel_tabInvoices_updates.Size = new System.Drawing.Size(462, 30);
            this.panel_tabInvoices_updates.TabIndex = 1;
            // 
            // button_tabInvoices_cancel
            // 
            this.button_tabInvoices_cancel.Location = new System.Drawing.Point(384, 3);
            this.button_tabInvoices_cancel.Name = "button_tabInvoices_cancel";
            this.button_tabInvoices_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_cancel.TabIndex = 2;
            this.button_tabInvoices_cancel.Text = "Cancel";
            this.button_tabInvoices_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabInvoices_save
            // 
            this.button_tabInvoices_save.Location = new System.Drawing.Point(303, 3);
            this.button_tabInvoices_save.Name = "button_tabInvoices_save";
            this.button_tabInvoices_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_save.TabIndex = 1;
            this.button_tabInvoices_save.Text = "Save";
            this.button_tabInvoices_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabInvoices_actions
            // 
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_print);
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_setpayed);
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_delete);
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_edit);
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_new);
            this.panel_tabInvoices_actions.Location = new System.Drawing.Point(6, 8);
            this.panel_tabInvoices_actions.Name = "panel_tabInvoices_actions";
            this.panel_tabInvoices_actions.Size = new System.Drawing.Size(450, 30);
            this.panel_tabInvoices_actions.TabIndex = 0;
            // 
            // button_tabInvoices_print
            // 
            this.button_tabInvoices_print.Location = new System.Drawing.Point(246, 3);
            this.button_tabInvoices_print.Name = "button_tabInvoices_print";
            this.button_tabInvoices_print.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_print.TabIndex = 4;
            this.button_tabInvoices_print.Text = "Print";
            this.button_tabInvoices_print.UseVisualStyleBackColor = true;
            // 
            // button_tabInvoices_setpayed
            // 
            this.button_tabInvoices_setpayed.Location = new System.Drawing.Point(372, 3);
            this.button_tabInvoices_setpayed.Name = "button_tabInvoices_setpayed";
            this.button_tabInvoices_setpayed.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_setpayed.TabIndex = 3;
            this.button_tabInvoices_setpayed.Text = "Payed";
            this.button_tabInvoices_setpayed.UseVisualStyleBackColor = true;
            this.button_tabInvoices_setpayed.Click += new System.EventHandler(this.button_tabInvoices_setpayed_Click);
            // 
            // button_tabInvoices_delete
            // 
            this.button_tabInvoices_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabInvoices_delete.Name = "button_tabInvoices_delete";
            this.button_tabInvoices_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_delete.TabIndex = 2;
            this.button_tabInvoices_delete.Text = "Delete";
            this.button_tabInvoices_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabInvoices_edit
            // 
            this.button_tabInvoices_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabInvoices_edit.Name = "button_tabInvoices_edit";
            this.button_tabInvoices_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_edit.TabIndex = 1;
            this.button_tabInvoices_edit.Text = "Edit";
            this.button_tabInvoices_edit.UseVisualStyleBackColor = true;
            this.button_tabInvoices_edit.Click += new System.EventHandler(this.button_tabInvoices_edit_Click);
            // 
            // button_tabInvoices_new
            // 
            this.button_tabInvoices_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabInvoices_new.Name = "button_tabInvoices_new";
            this.button_tabInvoices_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_new.TabIndex = 0;
            this.button_tabInvoices_new.Text = "New";
            this.button_tabInvoices_new.UseVisualStyleBackColor = true;
            this.button_tabInvoices_new.Click += new System.EventHandler(this.button_tabInvoices_new_Click);
            // 
            // tabPage_tabInvoicesLines
            // 
            this.tabPage_tabInvoicesLines.Controls.Add(this.panel_tabInvoicesLines_data);
            this.tabPage_tabInvoicesLines.Controls.Add(this.panel_tabInvoicesLines_updates);
            this.tabPage_tabInvoicesLines.Controls.Add(this.panel_tabInvoicesLines_actions);
            this.tabPage_tabInvoicesLines.Controls.Add(this.panel_tabInvoicesLines_list);
            this.tabPage_tabInvoicesLines.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabInvoicesLines.Name = "tabPage_tabInvoicesLines";
            this.tabPage_tabInvoicesLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabInvoicesLines.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabInvoicesLines.TabIndex = 1;
            this.tabPage_tabInvoicesLines.Text = "Lines";
            this.tabPage_tabInvoicesLines.UseVisualStyleBackColor = true;
            // 
            // panel_tabInvoicesLines_data
            // 
            this.panel_tabInvoicesLines_data.Controls.Add(this.groupBox_tabInvoicesLines_filler);
            this.panel_tabInvoicesLines_data.Controls.Add(this.patientstreatmentsTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_taxrateComboBox);
            this.panel_tabInvoicesLines_data.Controls.Add(invoiceslines_unitpriceLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_unitpriceTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(invoiceslines_taxrateLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_taxrateTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(invoiceslines_quantityLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_quantityTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(invoiceslines_descriptionLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_descriptionTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(invoiceslines_codeLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_codeTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(invoiceslines_idLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_idTextBox);
            this.panel_tabInvoicesLines_data.Location = new System.Drawing.Point(6, 249);
            this.panel_tabInvoicesLines_data.Name = "panel_tabInvoicesLines_data";
            this.panel_tabInvoicesLines_data.Size = new System.Drawing.Size(480, 195);
            this.panel_tabInvoicesLines_data.TabIndex = 9;
            // 
            // groupBox_tabInvoicesLines_filler
            // 
            this.groupBox_tabInvoicesLines_filler.Controls.Add(treatments_idLabel);
            this.groupBox_tabInvoicesLines_filler.Controls.Add(this.treatments_idComboBox);
            this.groupBox_tabInvoicesLines_filler.Controls.Add(patientstreatments_idLabel);
            this.groupBox_tabInvoicesLines_filler.Controls.Add(this.patientstreatments_idComboBox);
            this.groupBox_tabInvoicesLines_filler.Location = new System.Drawing.Point(12, 51);
            this.groupBox_tabInvoicesLines_filler.Name = "groupBox_tabInvoicesLines_filler";
            this.groupBox_tabInvoicesLines_filler.Size = new System.Drawing.Size(336, 60);
            this.groupBox_tabInvoicesLines_filler.TabIndex = 18;
            this.groupBox_tabInvoicesLines_filler.TabStop = false;
            this.groupBox_tabInvoicesLines_filler.Text = "Autofill from";
            // 
            // treatments_idComboBox
            // 
            this.treatments_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.treatments_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.treatments_idComboBox.FormattingEnabled = true;
            this.treatments_idComboBox.Location = new System.Drawing.Point(9, 32);
            this.treatments_idComboBox.Name = "treatments_idComboBox";
            this.treatments_idComboBox.Size = new System.Drawing.Size(150, 21);
            this.treatments_idComboBox.TabIndex = 14;
            this.treatments_idComboBox.SelectedIndexChanged += new System.EventHandler(this.treatments_idComboBox_SelectedIndexChanged);
            this.treatments_idComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treatments_idComboBox_KeyPress);
            // 
            // patientstreatments_idComboBox
            // 
            this.patientstreatments_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.patientstreatments_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patientstreatments_idComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.invoiceslinesBindingSource, "patientstreatments_id", true));
            this.patientstreatments_idComboBox.FormattingEnabled = true;
            this.patientstreatments_idComboBox.Location = new System.Drawing.Point(175, 32);
            this.patientstreatments_idComboBox.Name = "patientstreatments_idComboBox";
            this.patientstreatments_idComboBox.Size = new System.Drawing.Size(150, 21);
            this.patientstreatments_idComboBox.TabIndex = 16;
            this.patientstreatments_idComboBox.SelectedIndexChanged += new System.EventHandler(this.patientstreatments_idComboBox_SelectedIndexChanged);
            this.patientstreatments_idComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.patientstreatments_idComboBox_KeyPress);
            // 
            // invoiceslinesBindingSource
            // 
            this.invoiceslinesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.invoiceslines);
            // 
            // patientstreatmentsTextBox
            // 
            this.patientstreatmentsTextBox.Location = new System.Drawing.Point(187, 25);
            this.patientstreatmentsTextBox.Name = "patientstreatmentsTextBox";
            this.patientstreatmentsTextBox.Size = new System.Drawing.Size(255, 20);
            this.patientstreatmentsTextBox.TabIndex = 17;
            // 
            // invoiceslines_taxrateComboBox
            // 
            this.invoiceslines_taxrateComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.invoiceslines_taxrateComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.invoiceslines_taxrateComboBox.FormattingEnabled = true;
            this.invoiceslines_taxrateComboBox.Location = new System.Drawing.Point(342, 129);
            this.invoiceslines_taxrateComboBox.Name = "invoiceslines_taxrateComboBox";
            this.invoiceslines_taxrateComboBox.Size = new System.Drawing.Size(100, 21);
            this.invoiceslines_taxrateComboBox.TabIndex = 12;
            this.invoiceslines_taxrateComboBox.SelectedIndexChanged += new System.EventHandler(this.invoiceslines_taxrateComboBox_SelectedIndexChanged);
            this.invoiceslines_taxrateComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoiceslines_taxrateComboBox_KeyPress);
            // 
            // invoiceslines_unitpriceTextBox
            // 
            this.invoiceslines_unitpriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_unitprice", true));
            this.invoiceslines_unitpriceTextBox.Location = new System.Drawing.Point(184, 130);
            this.invoiceslines_unitpriceTextBox.Name = "invoiceslines_unitpriceTextBox";
            this.invoiceslines_unitpriceTextBox.Size = new System.Drawing.Size(70, 20);
            this.invoiceslines_unitpriceTextBox.TabIndex = 11;
            // 
            // invoiceslines_taxrateTextBox
            // 
            this.invoiceslines_taxrateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_taxrate", true));
            this.invoiceslines_taxrateTextBox.Location = new System.Drawing.Point(285, 130);
            this.invoiceslines_taxrateTextBox.Name = "invoiceslines_taxrateTextBox";
            this.invoiceslines_taxrateTextBox.Size = new System.Drawing.Size(50, 20);
            this.invoiceslines_taxrateTextBox.TabIndex = 9;
            // 
            // invoiceslines_quantityTextBox
            // 
            this.invoiceslines_quantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_quantity", true));
            this.invoiceslines_quantityTextBox.Location = new System.Drawing.Point(103, 130);
            this.invoiceslines_quantityTextBox.Name = "invoiceslines_quantityTextBox";
            this.invoiceslines_quantityTextBox.Size = new System.Drawing.Size(50, 20);
            this.invoiceslines_quantityTextBox.TabIndex = 7;
            // 
            // invoiceslines_descriptionTextBox
            // 
            this.invoiceslines_descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_description", true));
            this.invoiceslines_descriptionTextBox.Location = new System.Drawing.Point(12, 169);
            this.invoiceslines_descriptionTextBox.Name = "invoiceslines_descriptionTextBox";
            this.invoiceslines_descriptionTextBox.Size = new System.Drawing.Size(430, 20);
            this.invoiceslines_descriptionTextBox.TabIndex = 5;
            // 
            // invoiceslines_codeTextBox
            // 
            this.invoiceslines_codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_code", true));
            this.invoiceslines_codeTextBox.Location = new System.Drawing.Point(12, 130);
            this.invoiceslines_codeTextBox.Name = "invoiceslines_codeTextBox";
            this.invoiceslines_codeTextBox.Size = new System.Drawing.Size(60, 20);
            this.invoiceslines_codeTextBox.TabIndex = 3;
            // 
            // invoiceslines_idTextBox
            // 
            this.invoiceslines_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_id", true));
            this.invoiceslines_idTextBox.Enabled = false;
            this.invoiceslines_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.invoiceslines_idTextBox.Name = "invoiceslines_idTextBox";
            this.invoiceslines_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.invoiceslines_idTextBox.TabIndex = 1;
            // 
            // panel_tabInvoicesLines_updates
            // 
            this.panel_tabInvoicesLines_updates.Controls.Add(this.button_tabInvoicesLines_cancel);
            this.panel_tabInvoicesLines_updates.Controls.Add(this.button_tabInvoicesLines_save);
            this.panel_tabInvoicesLines_updates.Location = new System.Drawing.Point(6, 450);
            this.panel_tabInvoicesLines_updates.Name = "panel_tabInvoicesLines_updates";
            this.panel_tabInvoicesLines_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabInvoicesLines_updates.TabIndex = 8;
            // 
            // button_tabInvoicesLines_cancel
            // 
            this.button_tabInvoicesLines_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabInvoicesLines_cancel.Name = "button_tabInvoicesLines_cancel";
            this.button_tabInvoicesLines_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoicesLines_cancel.TabIndex = 2;
            this.button_tabInvoicesLines_cancel.Text = "Cancel";
            this.button_tabInvoicesLines_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabInvoicesLines_save
            // 
            this.button_tabInvoicesLines_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabInvoicesLines_save.Name = "button_tabInvoicesLines_save";
            this.button_tabInvoicesLines_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoicesLines_save.TabIndex = 1;
            this.button_tabInvoicesLines_save.Text = "Save";
            this.button_tabInvoicesLines_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabInvoicesLines_actions
            // 
            this.panel_tabInvoicesLines_actions.Controls.Add(this.button_tabInvoicesLines_delete);
            this.panel_tabInvoicesLines_actions.Controls.Add(this.button_tabInvoicesLines_edit);
            this.panel_tabInvoicesLines_actions.Controls.Add(this.button_tabInvoicesLines_new);
            this.panel_tabInvoicesLines_actions.Location = new System.Drawing.Point(6, 213);
            this.panel_tabInvoicesLines_actions.Name = "panel_tabInvoicesLines_actions";
            this.panel_tabInvoicesLines_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabInvoicesLines_actions.TabIndex = 7;
            // 
            // button_tabInvoicesLines_delete
            // 
            this.button_tabInvoicesLines_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabInvoicesLines_delete.Name = "button_tabInvoicesLines_delete";
            this.button_tabInvoicesLines_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoicesLines_delete.TabIndex = 2;
            this.button_tabInvoicesLines_delete.Text = "Delete";
            this.button_tabInvoicesLines_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabInvoicesLines_edit
            // 
            this.button_tabInvoicesLines_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabInvoicesLines_edit.Name = "button_tabInvoicesLines_edit";
            this.button_tabInvoicesLines_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoicesLines_edit.TabIndex = 1;
            this.button_tabInvoicesLines_edit.Text = "Edit";
            this.button_tabInvoicesLines_edit.UseVisualStyleBackColor = true;
            this.button_tabInvoicesLines_edit.Click += new System.EventHandler(this.button_tabInvoicesLines_edit_Click);
            // 
            // button_tabInvoicesLines_new
            // 
            this.button_tabInvoicesLines_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabInvoicesLines_new.Name = "button_tabInvoicesLines_new";
            this.button_tabInvoicesLines_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoicesLines_new.TabIndex = 0;
            this.button_tabInvoicesLines_new.Text = "New";
            this.button_tabInvoicesLines_new.UseVisualStyleBackColor = true;
            this.button_tabInvoicesLines_new.Click += new System.EventHandler(this.button_tabInvoicesLines_new_Click);
            // 
            // panel_tabInvoicesLines_list
            // 
            this.panel_tabInvoicesLines_list.Controls.Add(this.advancedDataGridView_tabInvoicesLines_list);
            this.panel_tabInvoicesLines_list.Location = new System.Drawing.Point(6, 6);
            this.panel_tabInvoicesLines_list.Name = "panel_tabInvoicesLines_list";
            this.panel_tabInvoicesLines_list.Size = new System.Drawing.Size(480, 200);
            this.panel_tabInvoicesLines_list.TabIndex = 6;
            // 
            // advancedDataGridView_tabInvoicesLines_list
            // 
            this.advancedDataGridView_tabInvoicesLines_list.AllowUserToAddRows = false;
            this.advancedDataGridView_tabInvoicesLines_list.AllowUserToDeleteRows = false;
            this.advancedDataGridView_tabInvoicesLines_list.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_tabInvoicesLines_list.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView_tabInvoicesLines_list.AutoGenerateColumns = false;
            this.advancedDataGridView_tabInvoicesLines_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_tabInvoicesLines_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceslinesidDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.unitpriceDataGridViewTextBoxColumn,
            this.taxrateDataGridViewTextBoxColumn,
            this.totalpriceDataGridViewTextBoxColumn});
            this.advancedDataGridView_tabInvoicesLines_list.DataSource = this.vInvoicesLinesBindingSource;
            this.advancedDataGridView_tabInvoicesLines_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_tabInvoicesLines_list.FilterAndSortEnabled = true;
            this.advancedDataGridView_tabInvoicesLines_list.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_tabInvoicesLines_list.MultiSelect = false;
            this.advancedDataGridView_tabInvoicesLines_list.Name = "advancedDataGridView_tabInvoicesLines_list";
            this.advancedDataGridView_tabInvoicesLines_list.ReadOnly = true;
            this.advancedDataGridView_tabInvoicesLines_list.RowHeadersVisible = false;
            this.advancedDataGridView_tabInvoicesLines_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_tabInvoicesLines_list.Size = new System.Drawing.Size(480, 200);
            this.advancedDataGridView_tabInvoicesLines_list.TabIndex = 1;
            this.advancedDataGridView_tabInvoicesLines_list.SortStringChanged += new System.EventHandler(this.advancedDataGridView_tabInvoicesLines_list_SortStringChanged);
            this.advancedDataGridView_tabInvoicesLines_list.FilterStringChanged += new System.EventHandler(this.advancedDataGridView_tabInvoicesLines_list_FilterStringChanged);
            // 
            // invoiceslinesidDataGridViewTextBoxColumn
            // 
            this.invoiceslinesidDataGridViewTextBoxColumn.DataPropertyName = "invoiceslines_id";
            this.invoiceslinesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.invoiceslinesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.invoiceslinesidDataGridViewTextBoxColumn.Name = "invoiceslinesidDataGridViewTextBoxColumn";
            this.invoiceslinesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceslinesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.invoiceslinesidDataGridViewTextBoxColumn.Width = 80;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.codeDataGridViewTextBoxColumn.Width = 60;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.quantityDataGridViewTextBoxColumn.Width = 50;
            // 
            // unitpriceDataGridViewTextBoxColumn
            // 
            this.unitpriceDataGridViewTextBoxColumn.DataPropertyName = "unitprice";
            this.unitpriceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.unitpriceDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.unitpriceDataGridViewTextBoxColumn.Name = "unitpriceDataGridViewTextBoxColumn";
            this.unitpriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitpriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.unitpriceDataGridViewTextBoxColumn.Width = 70;
            // 
            // taxrateDataGridViewTextBoxColumn
            // 
            this.taxrateDataGridViewTextBoxColumn.DataPropertyName = "taxrate";
            this.taxrateDataGridViewTextBoxColumn.HeaderText = "Tax";
            this.taxrateDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.taxrateDataGridViewTextBoxColumn.Name = "taxrateDataGridViewTextBoxColumn";
            this.taxrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxrateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.taxrateDataGridViewTextBoxColumn.Width = 60;
            // 
            // totalpriceDataGridViewTextBoxColumn
            // 
            this.totalpriceDataGridViewTextBoxColumn.DataPropertyName = "totalprice";
            this.totalpriceDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalpriceDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.totalpriceDataGridViewTextBoxColumn.Name = "totalpriceDataGridViewTextBoxColumn";
            this.totalpriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalpriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.totalpriceDataGridViewTextBoxColumn.Width = 70;
            // 
            // vInvoicesLinesBindingSource
            // 
            this.vInvoicesLinesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VInvoicesLines);
            this.vInvoicesLinesBindingSource.CurrentChanged += new System.EventHandler(this.vInvoicesLinesBindingSource_CurrentChanged);
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Controls.Add(this.panel_listtotal);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 60);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(284, 502);
            this.panel_list.TabIndex = 11;
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToAddRows = false;
            this.advancedDataGridView_main.AllowUserToDeleteRows = false;
            this.advancedDataGridView_main.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridView_main.AutoGenerateColumns = false;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoicesidDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.patientDataGridViewTextBoxColumn,
            this.ispayedDataGridViewCheckBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vInvoicesBindingSource;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.MultiSelect = false;
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(284, 446);
            this.advancedDataGridView_main.TabIndex = 0;
            // 
            // invoicesidDataGridViewTextBoxColumn
            // 
            this.invoicesidDataGridViewTextBoxColumn.DataPropertyName = "invoices_id";
            this.invoicesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.invoicesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.invoicesidDataGridViewTextBoxColumn.Name = "invoicesidDataGridViewTextBoxColumn";
            this.invoicesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoicesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.invoicesidDataGridViewTextBoxColumn.Visible = false;
            this.invoicesidDataGridViewTextBoxColumn.Width = 80;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.numberDataGridViewTextBoxColumn.Width = 80;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            dataGridViewCellStyle3.Format = "d";
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dateDataGridViewTextBoxColumn.Width = 80;
            // 
            // patientDataGridViewTextBoxColumn
            // 
            this.patientDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.patientDataGridViewTextBoxColumn.DataPropertyName = "patient";
            this.patientDataGridViewTextBoxColumn.HeaderText = "Patient";
            this.patientDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.patientDataGridViewTextBoxColumn.Name = "patientDataGridViewTextBoxColumn";
            this.patientDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ispayedDataGridViewCheckBoxColumn
            // 
            this.ispayedDataGridViewCheckBoxColumn.DataPropertyName = "ispayed";
            this.ispayedDataGridViewCheckBoxColumn.HeaderText = "P";
            this.ispayedDataGridViewCheckBoxColumn.MinimumWidth = 22;
            this.ispayedDataGridViewCheckBoxColumn.Name = "ispayedDataGridViewCheckBoxColumn";
            this.ispayedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.ispayedDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ispayedDataGridViewCheckBoxColumn.Width = 40;
            // 
            // vInvoicesBindingSource
            // 
            this.vInvoicesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VInvoices);
            this.vInvoicesBindingSource.CurrentChanged += new System.EventHandler(this.vInvoicesBindingSource_CurrentChanged);
            // 
            // panel_listtotal
            // 
            this.panel_listtotal.Controls.Add(this.totalpaiedTextBox);
            this.panel_listtotal.Controls.Add(this.totalpaiedLabel);
            this.panel_listtotal.Controls.Add(this.totalTextBox);
            this.panel_listtotal.Controls.Add(this.totalLabel);
            this.panel_listtotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_listtotal.Location = new System.Drawing.Point(0, 446);
            this.panel_listtotal.Name = "panel_listtotal";
            this.panel_listtotal.Size = new System.Drawing.Size(284, 56);
            this.panel_listtotal.TabIndex = 2;
            // 
            // totalpaiedTextBox
            // 
            this.totalpaiedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalpaiedTextBox.Location = new System.Drawing.Point(208, 32);
            this.totalpaiedTextBox.Name = "totalpaiedTextBox";
            this.totalpaiedTextBox.ReadOnly = true;
            this.totalpaiedTextBox.Size = new System.Drawing.Size(70, 20);
            this.totalpaiedTextBox.TabIndex = 3;
            // 
            // totalpaiedLabel
            // 
            this.totalpaiedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalpaiedLabel.Location = new System.Drawing.Point(52, 35);
            this.totalpaiedLabel.Name = "totalpaiedLabel";
            this.totalpaiedLabel.Size = new System.Drawing.Size(150, 13);
            this.totalpaiedLabel.TabIndex = 2;
            this.totalpaiedLabel.Text = "Total Payed:";
            this.totalpaiedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalTextBox
            // 
            this.totalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalTextBox.Location = new System.Drawing.Point(208, 6);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(70, 20);
            this.totalTextBox.TabIndex = 1;
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLabel.Location = new System.Drawing.Point(52, 9);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(150, 13);
            this.totalLabel.TabIndex = 0;
            this.totalLabel.Text = "Total:";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel_filters
            // 
            this.panel_filters.Controls.Add(this.comboBox_filterDoctors);
            this.panel_filters.Controls.Add(this.label1);
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 10;
            // 
            // comboBox_filterDoctors
            // 
            this.comboBox_filterDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterDoctors.FormattingEnabled = true;
            this.comboBox_filterDoctors.Location = new System.Drawing.Point(6, 25);
            this.comboBox_filterDoctors.Name = "comboBox_filterDoctors";
            this.comboBox_filterDoctors.Size = new System.Drawing.Size(121, 21);
            this.comboBox_filterDoctors.TabIndex = 5;
            this.comboBox_filterDoctors.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterDoctors_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Doctors:";
            // 
            // FormInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormInvoices";
            this.Text = "Invoices";
            this.Load += new System.EventHandler(this.FormInvoices_Load);
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabInvoices.ResumeLayout(false);
            this.panel_tabInvoices_data.ResumeLayout(false);
            this.panel_tabInvoices_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesBindingSource)).EndInit();
            this.panel_tabInvoices_updates.ResumeLayout(false);
            this.panel_tabInvoices_actions.ResumeLayout(false);
            this.tabPage_tabInvoicesLines.ResumeLayout(false);
            this.panel_tabInvoicesLines_data.ResumeLayout(false);
            this.panel_tabInvoicesLines_data.PerformLayout();
            this.groupBox_tabInvoicesLines_filler.ResumeLayout(false);
            this.groupBox_tabInvoicesLines_filler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceslinesBindingSource)).EndInit();
            this.panel_tabInvoicesLines_updates.ResumeLayout(false);
            this.panel_tabInvoicesLines_actions.ResumeLayout(false);
            this.panel_tabInvoicesLines_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_tabInvoicesLines_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInvoicesLinesBindingSource)).EndInit();
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vInvoicesBindingSource)).EndInit();
            this.panel_listtotal.ResumeLayout(false);
            this.panel_listtotal.PerformLayout();
            this.panel_filters.ResumeLayout(false);
            this.panel_filters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabInvoices;
        private System.Windows.Forms.Panel panel_tabInvoices_data;
        private System.Windows.Forms.Panel panel_tabInvoices_updates;
        private System.Windows.Forms.Button button_tabInvoices_cancel;
        private System.Windows.Forms.Button button_tabInvoices_save;
        private System.Windows.Forms.Panel panel_tabInvoices_actions;
        private System.Windows.Forms.Button button_tabInvoices_delete;
        private System.Windows.Forms.Button button_tabInvoices_edit;
        private System.Windows.Forms.Button button_tabInvoices_new;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.TextBox invoices_doctorTextBox;
        private System.Windows.Forms.BindingSource invoicesBindingSource;
        private System.Windows.Forms.DateTimePicker invoices_dateDateTimePicker;
        private System.Windows.Forms.TextBox invoices_numberTextBox;
        private System.Windows.Forms.TextBox invoices_idTextBox;
        private System.Windows.Forms.TextBox invoices_patientTextBox;
        private System.Windows.Forms.ComboBox invoices_paymentComboBox;
        private System.Windows.Forms.TextBox invoices_paymentTextBox;
        private System.Windows.Forms.TextBox invoices_footerTextBox;
        private System.Windows.Forms.ComboBox invoices_footerComboBox;
        private System.Windows.Forms.ComboBox invoices_deductiontaxrateComboBox;
        private System.Windows.Forms.CheckBox invoices_ispaidCheckBox;
        private System.Windows.Forms.TextBox invoices_deductiontaxrateTextBox;
        private System.Windows.Forms.Button button_tabInvoices_setpayed;
        private System.Windows.Forms.Button button_tabInvoices_print;
        private System.Windows.Forms.TabPage tabPage_tabInvoicesLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ispayedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource vInvoicesBindingSource;
        private System.Windows.Forms.ComboBox comboBox_filterDoctors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_tabInvoicesLines_data;
        private System.Windows.Forms.Panel panel_tabInvoicesLines_updates;
        private System.Windows.Forms.Button button_tabInvoicesLines_cancel;
        private System.Windows.Forms.Button button_tabInvoicesLines_save;
        private System.Windows.Forms.Panel panel_tabInvoicesLines_actions;
        private System.Windows.Forms.Button button_tabInvoicesLines_delete;
        private System.Windows.Forms.Button button_tabInvoicesLines_edit;
        private System.Windows.Forms.Button button_tabInvoicesLines_new;
        private System.Windows.Forms.Panel panel_tabInvoicesLines_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_tabInvoicesLines_list;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceslinesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxrateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vInvoicesLinesBindingSource;
        private System.Windows.Forms.TextBox invoiceslines_unitpriceTextBox;
        private System.Windows.Forms.BindingSource invoiceslinesBindingSource;
        private System.Windows.Forms.TextBox invoiceslines_taxrateTextBox;
        private System.Windows.Forms.TextBox invoiceslines_quantityTextBox;
        private System.Windows.Forms.TextBox invoiceslines_descriptionTextBox;
        private System.Windows.Forms.TextBox invoiceslines_codeTextBox;
        private System.Windows.Forms.TextBox invoiceslines_idTextBox;
        private System.Windows.Forms.ComboBox invoiceslines_taxrateComboBox;
        private System.Windows.Forms.ComboBox patientstreatments_idComboBox;
        private System.Windows.Forms.ComboBox treatments_idComboBox;
        private System.Windows.Forms.ComboBox patients_idComboBox;
        private System.Windows.Forms.ComboBox doctors_idComboBox;
        private System.Windows.Forms.Panel panel_listtotal;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.TextBox totalpaiedTextBox;
        private System.Windows.Forms.Label totalpaiedLabel;
        private System.Windows.Forms.TextBox patientstreatmentsTextBox;
        private System.Windows.Forms.GroupBox groupBox_tabInvoicesLines_filler;
    }
}