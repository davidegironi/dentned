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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvoices));
            this.invoices_idLabel = new System.Windows.Forms.Label();
            this.invoices_numberLabel = new System.Windows.Forms.Label();
            this.invoices_doctorLabel = new System.Windows.Forms.Label();
            this.invoices_patientLabel = new System.Windows.Forms.Label();
            this.invoices_dateLabel = new System.Windows.Forms.Label();
            this.invoices_paymentLabel = new System.Windows.Forms.Label();
            this.invoices_footerLabel = new System.Windows.Forms.Label();
            this.invoices_deductiontaxrateLabel = new System.Windows.Forms.Label();
            this.invoiceslines_idLabel = new System.Windows.Forms.Label();
            this.invoiceslines_codeLabel = new System.Windows.Forms.Label();
            this.invoiceslines_descriptionLabel = new System.Windows.Forms.Label();
            this.invoiceslines_quantityLabel = new System.Windows.Forms.Label();
            this.invoiceslines_taxrateLabel = new System.Windows.Forms.Label();
            this.invoiceslines_unitpriceLabel = new System.Windows.Forms.Label();
            this.treatments_idLabel = new System.Windows.Forms.Label();
            this.patientstreatments_idLabel = new System.Windows.Forms.Label();
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabInvoices = new System.Windows.Forms.TabPage();
            this.panel_tabInvoices_data = new System.Windows.Forms.Panel();
            this.invoices_totalgrossLabel = new System.Windows.Forms.Label();
            this.invoices_totalgrossTextBox = new System.Windows.Forms.TextBox();
            this.invoicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoices_totaldueLabel = new System.Windows.Forms.Label();
            this.invoices_totaldueTextBox = new System.Windows.Forms.TextBox();
            this.invoices_totalnetLabel = new System.Windows.Forms.Label();
            this.invoices_totalnetTextBox = new System.Windows.Forms.TextBox();
            this.patients_idComboBox = new System.Windows.Forms.ComboBox();
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
            this.button_tabInvoices_setpaid = new System.Windows.Forms.Button();
            this.button_tabInvoices_delete = new System.Windows.Forms.Button();
            this.button_tabInvoices_edit = new System.Windows.Forms.Button();
            this.button_tabInvoices_new = new System.Windows.Forms.Button();
            this.tabPage_tabInvoicesLines = new System.Windows.Forms.TabPage();
            this.panel_tabInvoicesLines_data = new System.Windows.Forms.Panel();
            this.invoiceslines_istaxesdeductionsableCheckBox = new System.Windows.Forms.CheckBox();
            this.invoiceslinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox_tabInvoicesLines_filler = new System.Windows.Forms.GroupBox();
            this.computedlines_idLabel = new System.Windows.Forms.Label();
            this.computedlines_idComboBox = new System.Windows.Forms.ComboBox();
            this.treatments_idComboBox = new System.Windows.Forms.ComboBox();
            this.invoiceslines_taxrateComboBox = new System.Windows.Forms.ComboBox();
            this.patientstreatments_idComboBox = new System.Windows.Forms.ComboBox();
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
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vInvoicesLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ispaidDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vInvoicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_listtotal = new System.Windows.Forms.Panel();
            this.totalgrossTextBox = new System.Windows.Forms.TextBox();
            this.totalgrossLabel = new System.Windows.Forms.Label();
            this.totalnetTextBox = new System.Windows.Forms.TextBox();
            this.totalnetLabel = new System.Windows.Forms.Label();
            this.totalduepaidTextBox = new System.Windows.Forms.TextBox();
            this.totalduepaidLabel = new System.Windows.Forms.Label();
            this.totaldueTextBox = new System.Windows.Forms.TextBox();
            this.totaldueLabel = new System.Windows.Forms.Label();
            this.panel_filters = new System.Windows.Forms.Panel();
            this.label_filterYears = new System.Windows.Forms.Label();
            this.comboBox_filterYears = new System.Windows.Forms.ComboBox();
            this.comboBox_filterDoctors = new System.Windows.Forms.ComboBox();
            this.label_filterDoctors = new System.Windows.Forms.Label();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabInvoices.SuspendLayout();
            this.panel_tabInvoices_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesBindingSource)).BeginInit();
            this.panel_tabInvoices_updates.SuspendLayout();
            this.panel_tabInvoices_actions.SuspendLayout();
            this.tabPage_tabInvoicesLines.SuspendLayout();
            this.panel_tabInvoicesLines_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceslinesBindingSource)).BeginInit();
            this.groupBox_tabInvoicesLines_filler.SuspendLayout();
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
            this.invoices_idLabel.AutoSize = true;
            this.invoices_idLabel.Location = new System.Drawing.Point(9, 9);
            this.invoices_idLabel.Name = "invoices_idLabel";
            this.invoices_idLabel.Size = new System.Drawing.Size(19, 13);
            this.invoices_idLabel.TabIndex = 0;
            this.invoices_idLabel.Text = "Id:";
            // 
            // invoices_numberLabel
            // 
            this.invoices_numberLabel.AutoSize = true;
            this.invoices_numberLabel.Location = new System.Drawing.Point(9, 48);
            this.invoices_numberLabel.Name = "invoices_numberLabel";
            this.invoices_numberLabel.Size = new System.Drawing.Size(47, 13);
            this.invoices_numberLabel.TabIndex = 2;
            this.invoices_numberLabel.Text = "Number:";
            // 
            // invoices_doctorLabel
            // 
            this.invoices_doctorLabel.AutoSize = true;
            this.invoices_doctorLabel.Location = new System.Drawing.Point(9, 98);
            this.invoices_doctorLabel.Name = "invoices_doctorLabel";
            this.invoices_doctorLabel.Size = new System.Drawing.Size(42, 13);
            this.invoices_doctorLabel.TabIndex = 4;
            this.invoices_doctorLabel.Text = "Doctor:";
            // 
            // invoices_patientLabel
            // 
            this.invoices_patientLabel.AutoSize = true;
            this.invoices_patientLabel.Location = new System.Drawing.Point(9, 201);
            this.invoices_patientLabel.Name = "invoices_patientLabel";
            this.invoices_patientLabel.Size = new System.Drawing.Size(43, 13);
            this.invoices_patientLabel.TabIndex = 6;
            this.invoices_patientLabel.Text = "Patient:";
            // 
            // invoices_dateLabel
            // 
            this.invoices_dateLabel.AutoSize = true;
            this.invoices_dateLabel.Location = new System.Drawing.Point(125, 48);
            this.invoices_dateLabel.Name = "invoices_dateLabel";
            this.invoices_dateLabel.Size = new System.Drawing.Size(33, 13);
            this.invoices_dateLabel.TabIndex = 8;
            this.invoices_dateLabel.Text = "Date:";
            // 
            // invoices_paymentLabel
            // 
            this.invoices_paymentLabel.AutoSize = true;
            this.invoices_paymentLabel.Location = new System.Drawing.Point(9, 304);
            this.invoices_paymentLabel.Name = "invoices_paymentLabel";
            this.invoices_paymentLabel.Size = new System.Drawing.Size(51, 13);
            this.invoices_paymentLabel.TabIndex = 12;
            this.invoices_paymentLabel.Text = "Payment:";
            // 
            // invoices_footerLabel
            // 
            this.invoices_footerLabel.AutoSize = true;
            this.invoices_footerLabel.Location = new System.Drawing.Point(229, 304);
            this.invoices_footerLabel.Name = "invoices_footerLabel";
            this.invoices_footerLabel.Size = new System.Drawing.Size(40, 13);
            this.invoices_footerLabel.TabIndex = 15;
            this.invoices_footerLabel.Text = "Footer:";
            // 
            // invoices_deductiontaxrateLabel
            // 
            this.invoices_deductiontaxrateLabel.AutoSize = true;
            this.invoices_deductiontaxrateLabel.Location = new System.Drawing.Point(9, 399);
            this.invoices_deductiontaxrateLabel.Name = "invoices_deductiontaxrateLabel";
            this.invoices_deductiontaxrateLabel.Size = new System.Drawing.Size(106, 13);
            this.invoices_deductiontaxrateLabel.TabIndex = 18;
            this.invoices_deductiontaxrateLabel.Text = "Deduction Tax Rate:";
            // 
            // invoiceslines_idLabel
            // 
            this.invoiceslines_idLabel.AutoSize = true;
            this.invoiceslines_idLabel.Location = new System.Drawing.Point(9, 9);
            this.invoiceslines_idLabel.Name = "invoiceslines_idLabel";
            this.invoiceslines_idLabel.Size = new System.Drawing.Size(19, 13);
            this.invoiceslines_idLabel.TabIndex = 0;
            this.invoiceslines_idLabel.Text = "Id:";
            // 
            // invoiceslines_codeLabel
            // 
            this.invoiceslines_codeLabel.AutoSize = true;
            this.invoiceslines_codeLabel.Location = new System.Drawing.Point(9, 89);
            this.invoiceslines_codeLabel.Name = "invoiceslines_codeLabel";
            this.invoiceslines_codeLabel.Size = new System.Drawing.Size(35, 13);
            this.invoiceslines_codeLabel.TabIndex = 2;
            this.invoiceslines_codeLabel.Text = "Code:";
            // 
            // invoiceslines_descriptionLabel
            // 
            this.invoiceslines_descriptionLabel.AutoSize = true;
            this.invoiceslines_descriptionLabel.Location = new System.Drawing.Point(9, 128);
            this.invoiceslines_descriptionLabel.Name = "invoiceslines_descriptionLabel";
            this.invoiceslines_descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.invoiceslines_descriptionLabel.TabIndex = 4;
            this.invoiceslines_descriptionLabel.Text = "Description:";
            // 
            // invoiceslines_quantityLabel
            // 
            this.invoiceslines_quantityLabel.AutoSize = true;
            this.invoiceslines_quantityLabel.Location = new System.Drawing.Point(9, 166);
            this.invoiceslines_quantityLabel.Name = "invoiceslines_quantityLabel";
            this.invoiceslines_quantityLabel.Size = new System.Drawing.Size(49, 13);
            this.invoiceslines_quantityLabel.TabIndex = 6;
            this.invoiceslines_quantityLabel.Text = "Quantity:";
            // 
            // invoiceslines_taxrateLabel
            // 
            this.invoiceslines_taxrateLabel.AutoSize = true;
            this.invoiceslines_taxrateLabel.Location = new System.Drawing.Point(141, 166);
            this.invoiceslines_taxrateLabel.Name = "invoiceslines_taxrateLabel";
            this.invoiceslines_taxrateLabel.Size = new System.Drawing.Size(54, 13);
            this.invoiceslines_taxrateLabel.TabIndex = 8;
            this.invoiceslines_taxrateLabel.Text = "Tax Rate:";
            // 
            // invoiceslines_unitpriceLabel
            // 
            this.invoiceslines_unitpriceLabel.AutoSize = true;
            this.invoiceslines_unitpriceLabel.Location = new System.Drawing.Point(65, 166);
            this.invoiceslines_unitpriceLabel.Name = "invoiceslines_unitpriceLabel";
            this.invoiceslines_unitpriceLabel.Size = new System.Drawing.Size(34, 13);
            this.invoiceslines_unitpriceLabel.TabIndex = 10;
            this.invoiceslines_unitpriceLabel.Text = "Price:";
            // 
            // treatments_idLabel
            // 
            this.treatments_idLabel.AutoSize = true;
            this.treatments_idLabel.Location = new System.Drawing.Point(6, 16);
            this.treatments_idLabel.Name = "treatments_idLabel";
            this.treatments_idLabel.Size = new System.Drawing.Size(58, 13);
            this.treatments_idLabel.TabIndex = 13;
            this.treatments_idLabel.Text = "Treatment:";
            // 
            // patientstreatments_idLabel
            // 
            this.patientstreatments_idLabel.AutoSize = true;
            this.patientstreatments_idLabel.Location = new System.Drawing.Point(9, 49);
            this.patientstreatments_idLabel.Name = "patientstreatments_idLabel";
            this.patientstreatments_idLabel.Size = new System.Drawing.Size(94, 13);
            this.patientstreatments_idLabel.TabIndex = 15;
            this.patientstreatments_idLabel.Text = "Patient Treatment:";
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
            this.panel_tabInvoices_data.Controls.Add(this.invoices_totalgrossLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_totalgrossTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_totaldueLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_totaldueTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_totalnetLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_totalnetTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.patients_idComboBox);
            this.panel_tabInvoices_data.Controls.Add(this.doctors_idComboBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_deductiontaxrateComboBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_ispaidCheckBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_deductiontaxrateLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_deductiontaxrateTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_footerComboBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_footerLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_footerTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_paymentComboBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_paymentLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_paymentTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_patientTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_doctorTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_dateLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_dateDateTimePicker);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_patientLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_doctorLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_numberLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_numberTextBox);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_idLabel);
            this.panel_tabInvoices_data.Controls.Add(this.invoices_idTextBox);
            this.panel_tabInvoices_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabInvoices_data.Name = "panel_tabInvoices_data";
            this.panel_tabInvoices_data.Size = new System.Drawing.Size(480, 442);
            this.panel_tabInvoices_data.TabIndex = 2;
            // 
            // invoices_totalgrossLabel
            // 
            this.invoices_totalgrossLabel.AutoSize = true;
            this.invoices_totalgrossLabel.Location = new System.Drawing.Point(313, 48);
            this.invoices_totalgrossLabel.Name = "invoices_totalgrossLabel";
            this.invoices_totalgrossLabel.Size = new System.Drawing.Size(37, 13);
            this.invoices_totalgrossLabel.TabIndex = 26;
            this.invoices_totalgrossLabel.Text = "Gross:";
            // 
            // invoices_totalgrossTextBox
            // 
            this.invoices_totalgrossTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_totalgross", true));
            this.invoices_totalgrossTextBox.Enabled = false;
            this.invoices_totalgrossTextBox.Location = new System.Drawing.Point(316, 64);
            this.invoices_totalgrossTextBox.Name = "invoices_totalgrossTextBox";
            this.invoices_totalgrossTextBox.Size = new System.Drawing.Size(60, 20);
            this.invoices_totalgrossTextBox.TabIndex = 27;
            // 
            // invoicesBindingSource
            // 
            this.invoicesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.invoices);
            // 
            // invoices_totaldueLabel
            // 
            this.invoices_totaldueLabel.AutoSize = true;
            this.invoices_totaldueLabel.Location = new System.Drawing.Point(379, 48);
            this.invoices_totaldueLabel.Name = "invoices_totaldueLabel";
            this.invoices_totaldueLabel.Size = new System.Drawing.Size(30, 13);
            this.invoices_totaldueLabel.TabIndex = 25;
            this.invoices_totaldueLabel.Text = "Due:";
            // 
            // invoices_totaldueTextBox
            // 
            this.invoices_totaldueTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_totaldue", true));
            this.invoices_totaldueTextBox.Enabled = false;
            this.invoices_totaldueTextBox.Location = new System.Drawing.Point(382, 64);
            this.invoices_totaldueTextBox.Name = "invoices_totaldueTextBox";
            this.invoices_totaldueTextBox.Size = new System.Drawing.Size(60, 20);
            this.invoices_totaldueTextBox.TabIndex = 26;
            // 
            // invoices_totalnetLabel
            // 
            this.invoices_totalnetLabel.AutoSize = true;
            this.invoices_totalnetLabel.Location = new System.Drawing.Point(247, 48);
            this.invoices_totalnetLabel.Name = "invoices_totalnetLabel";
            this.invoices_totalnetLabel.Size = new System.Drawing.Size(27, 13);
            this.invoices_totalnetLabel.TabIndex = 24;
            this.invoices_totalnetLabel.Text = "Net:";
            // 
            // invoices_totalnetTextBox
            // 
            this.invoices_totalnetTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_totalnet", true));
            this.invoices_totalnetTextBox.Enabled = false;
            this.invoices_totalnetTextBox.Location = new System.Drawing.Point(250, 64);
            this.invoices_totalnetTextBox.Name = "invoices_totalnetTextBox";
            this.invoices_totalnetTextBox.Size = new System.Drawing.Size(60, 20);
            this.invoices_totalnetTextBox.TabIndex = 25;
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
            this.invoices_deductiontaxrateComboBox.Location = new System.Drawing.Point(88, 414);
            this.invoices_deductiontaxrateComboBox.Name = "invoices_deductiontaxrateComboBox";
            this.invoices_deductiontaxrateComboBox.Size = new System.Drawing.Size(100, 21);
            this.invoices_deductiontaxrateComboBox.TabIndex = 22;
            this.invoices_deductiontaxrateComboBox.SelectedIndexChanged += new System.EventHandler(this.invoices_deductiontaxrateComboBox_SelectedIndexChanged);
            this.invoices_deductiontaxrateComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoices_deductiontaxrateComboBox_KeyPress);
            this.invoices_deductiontaxrateComboBox.Leave += new System.EventHandler(this.invoices_deductiontaxrateComboBox_Leave);
            // 
            // invoices_ispaidCheckBox
            // 
            this.invoices_ispaidCheckBox.AutoSize = true;
            this.invoices_ispaidCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.invoicesBindingSource, "invoices_ispaid", true));
            this.invoices_ispaidCheckBox.Location = new System.Drawing.Point(382, 25);
            this.invoices_ispaidCheckBox.Name = "invoices_ispaidCheckBox";
            this.invoices_ispaidCheckBox.Size = new System.Drawing.Size(58, 17);
            this.invoices_ispaidCheckBox.TabIndex = 21;
            this.invoices_ispaidCheckBox.Text = "Is Paid";
            this.invoices_ispaidCheckBox.UseVisualStyleBackColor = true;
            // 
            // invoices_deductiontaxrateTextBox
            // 
            this.invoices_deductiontaxrateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_deductiontaxrate", true));
            this.invoices_deductiontaxrateTextBox.Location = new System.Drawing.Point(12, 415);
            this.invoices_deductiontaxrateTextBox.Name = "invoices_deductiontaxrateTextBox";
            this.invoices_deductiontaxrateTextBox.Size = new System.Drawing.Size(70, 20);
            this.invoices_deductiontaxrateTextBox.TabIndex = 19;
            // 
            // invoices_footerComboBox
            // 
            this.invoices_footerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.invoices_footerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.invoices_footerComboBox.FormattingEnabled = true;
            this.invoices_footerComboBox.Location = new System.Drawing.Point(286, 296);
            this.invoices_footerComboBox.Name = "invoices_footerComboBox";
            this.invoices_footerComboBox.Size = new System.Drawing.Size(121, 21);
            this.invoices_footerComboBox.TabIndex = 17;
            this.invoices_footerComboBox.SelectedIndexChanged += new System.EventHandler(this.invoices_footerComboBox_SelectedIndexChanged);
            this.invoices_footerComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoices_footerComboBox_KeyPress);
            this.invoices_footerComboBox.Leave += new System.EventHandler(this.invoices_footerComboBox_Leave);
            // 
            // invoices_footerTextBox
            // 
            this.invoices_footerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_footer", true));
            this.invoices_footerTextBox.Location = new System.Drawing.Point(232, 323);
            this.invoices_footerTextBox.Multiline = true;
            this.invoices_footerTextBox.Name = "invoices_footerTextBox";
            this.invoices_footerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.invoices_footerTextBox.Size = new System.Drawing.Size(210, 70);
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
            this.invoices_paymentComboBox.Leave += new System.EventHandler(this.invoices_paymentComboBox_Leave);
            // 
            // invoices_paymentTextBox
            // 
            this.invoices_paymentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoicesBindingSource, "invoices_payment", true));
            this.invoices_paymentTextBox.Location = new System.Drawing.Point(12, 323);
            this.invoices_paymentTextBox.Multiline = true;
            this.invoices_paymentTextBox.Name = "invoices_paymentTextBox";
            this.invoices_paymentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.invoices_paymentTextBox.Size = new System.Drawing.Size(210, 70);
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
            this.panel_tabInvoices_updates.Location = new System.Drawing.Point(6, 492);
            this.panel_tabInvoices_updates.Name = "panel_tabInvoices_updates";
            this.panel_tabInvoices_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabInvoices_updates.TabIndex = 1;
            // 
            // button_tabInvoices_cancel
            // 
            this.button_tabInvoices_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabInvoices_cancel.Name = "button_tabInvoices_cancel";
            this.button_tabInvoices_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_cancel.TabIndex = 2;
            this.button_tabInvoices_cancel.Text = "Cancel";
            this.button_tabInvoices_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabInvoices_save
            // 
            this.button_tabInvoices_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabInvoices_save.Name = "button_tabInvoices_save";
            this.button_tabInvoices_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_save.TabIndex = 1;
            this.button_tabInvoices_save.Text = "Save";
            this.button_tabInvoices_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabInvoices_actions
            // 
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_print);
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_setpaid);
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_delete);
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_edit);
            this.panel_tabInvoices_actions.Controls.Add(this.button_tabInvoices_new);
            this.panel_tabInvoices_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabInvoices_actions.Name = "panel_tabInvoices_actions";
            this.panel_tabInvoices_actions.Size = new System.Drawing.Size(480, 30);
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
            this.button_tabInvoices_print.Click += new System.EventHandler(this.button_tabInvoices_print_Click);
            // 
            // button_tabInvoices_setpaid
            // 
            this.button_tabInvoices_setpaid.Location = new System.Drawing.Point(402, 3);
            this.button_tabInvoices_setpaid.Name = "button_tabInvoices_setpaid";
            this.button_tabInvoices_setpaid.Size = new System.Drawing.Size(75, 23);
            this.button_tabInvoices_setpaid.TabIndex = 3;
            this.button_tabInvoices_setpaid.Text = "Paid";
            this.button_tabInvoices_setpaid.UseVisualStyleBackColor = true;
            this.button_tabInvoices_setpaid.Click += new System.EventHandler(this.button_tabInvoices_setpaid_Click);
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
            this.tabPage_tabInvoicesLines.AutoScroll = true;
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
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_istaxesdeductionsableCheckBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.groupBox_tabInvoicesLines_filler);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_taxrateComboBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.patientstreatments_idLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.patientstreatments_idComboBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_unitpriceLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_unitpriceTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_taxrateLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_taxrateTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_quantityLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_quantityTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_descriptionLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_descriptionTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_codeLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_codeTextBox);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_idLabel);
            this.panel_tabInvoicesLines_data.Controls.Add(this.invoiceslines_idTextBox);
            this.panel_tabInvoicesLines_data.Location = new System.Drawing.Point(6, 249);
            this.panel_tabInvoicesLines_data.Name = "panel_tabInvoicesLines_data";
            this.panel_tabInvoicesLines_data.Size = new System.Drawing.Size(480, 211);
            this.panel_tabInvoicesLines_data.TabIndex = 9;
            // 
            // invoiceslines_istaxesdeductionsableCheckBox
            // 
            this.invoiceslines_istaxesdeductionsableCheckBox.AutoSize = true;
            this.invoiceslines_istaxesdeductionsableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.invoiceslinesBindingSource, "invoiceslines_istaxesdeductionsable", true));
            this.invoiceslines_istaxesdeductionsableCheckBox.Location = new System.Drawing.Point(312, 183);
            this.invoiceslines_istaxesdeductionsableCheckBox.Name = "invoiceslines_istaxesdeductionsableCheckBox";
            this.invoiceslines_istaxesdeductionsableCheckBox.Size = new System.Drawing.Size(130, 17);
            this.invoiceslines_istaxesdeductionsableCheckBox.TabIndex = 19;
            this.invoiceslines_istaxesdeductionsableCheckBox.Text = "Is deduction tax abled";
            this.invoiceslines_istaxesdeductionsableCheckBox.UseVisualStyleBackColor = true;
            // 
            // invoiceslinesBindingSource
            // 
            this.invoiceslinesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.invoiceslines);
            // 
            // groupBox_tabInvoicesLines_filler
            // 
            this.groupBox_tabInvoicesLines_filler.Controls.Add(this.computedlines_idLabel);
            this.groupBox_tabInvoicesLines_filler.Controls.Add(this.computedlines_idComboBox);
            this.groupBox_tabInvoicesLines_filler.Controls.Add(this.treatments_idLabel);
            this.groupBox_tabInvoicesLines_filler.Controls.Add(this.treatments_idComboBox);
            this.groupBox_tabInvoicesLines_filler.Location = new System.Drawing.Point(267, 33);
            this.groupBox_tabInvoicesLines_filler.Name = "groupBox_tabInvoicesLines_filler";
            this.groupBox_tabInvoicesLines_filler.Size = new System.Drawing.Size(172, 101);
            this.groupBox_tabInvoicesLines_filler.TabIndex = 18;
            this.groupBox_tabInvoicesLines_filler.TabStop = false;
            this.groupBox_tabInvoicesLines_filler.Text = "Autofill from";
            // 
            // computedlines_idLabel
            // 
            this.computedlines_idLabel.AutoSize = true;
            this.computedlines_idLabel.Location = new System.Drawing.Point(6, 56);
            this.computedlines_idLabel.Name = "computedlines_idLabel";
            this.computedlines_idLabel.Size = new System.Drawing.Size(81, 13);
            this.computedlines_idLabel.TabIndex = 16;
            this.computedlines_idLabel.Text = "Computed Line:";
            // 
            // computedlines_idComboBox
            // 
            this.computedlines_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.computedlines_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.computedlines_idComboBox.FormattingEnabled = true;
            this.computedlines_idComboBox.Location = new System.Drawing.Point(9, 72);
            this.computedlines_idComboBox.Name = "computedlines_idComboBox";
            this.computedlines_idComboBox.Size = new System.Drawing.Size(150, 21);
            this.computedlines_idComboBox.TabIndex = 15;
            this.computedlines_idComboBox.SelectedIndexChanged += new System.EventHandler(this.computedlines_idComboBox_SelectedIndexChanged);
            this.computedlines_idComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.computedlines_idComboBox_KeyPress);
            this.computedlines_idComboBox.Leave += new System.EventHandler(this.computedlines_idComboBox_Leave);
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
            this.treatments_idComboBox.Leave += new System.EventHandler(this.treatments_idComboBox_Leave);
            // 
            // invoiceslines_taxrateComboBox
            // 
            this.invoiceslines_taxrateComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.invoiceslines_taxrateComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.invoiceslines_taxrateComboBox.FormattingEnabled = true;
            this.invoiceslines_taxrateComboBox.Location = new System.Drawing.Point(200, 181);
            this.invoiceslines_taxrateComboBox.Name = "invoiceslines_taxrateComboBox";
            this.invoiceslines_taxrateComboBox.Size = new System.Drawing.Size(100, 21);
            this.invoiceslines_taxrateComboBox.TabIndex = 12;
            this.invoiceslines_taxrateComboBox.SelectedIndexChanged += new System.EventHandler(this.invoiceslines_taxrateComboBox_SelectedIndexChanged);
            this.invoiceslines_taxrateComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoiceslines_taxrateComboBox_KeyPress);
            this.invoiceslines_taxrateComboBox.Leave += new System.EventHandler(this.invoiceslines_taxrateComboBox_Leave);
            // 
            // patientstreatments_idComboBox
            // 
            this.patientstreatments_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.patientstreatments_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.patientstreatments_idComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.invoiceslinesBindingSource, "patientstreatments_id", true));
            this.patientstreatments_idComboBox.FormattingEnabled = true;
            this.patientstreatments_idComboBox.Location = new System.Drawing.Point(12, 65);
            this.patientstreatments_idComboBox.Name = "patientstreatments_idComboBox";
            this.patientstreatments_idComboBox.Size = new System.Drawing.Size(249, 21);
            this.patientstreatments_idComboBox.TabIndex = 16;
            this.patientstreatments_idComboBox.SelectedIndexChanged += new System.EventHandler(this.patientstreatments_idComboBox_SelectedIndexChanged);
            this.patientstreatments_idComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.patientstreatments_idComboBox_KeyPress);
            // 
            // invoiceslines_unitpriceTextBox
            // 
            this.invoiceslines_unitpriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_unitprice", true));
            this.invoiceslines_unitpriceTextBox.Location = new System.Drawing.Point(68, 182);
            this.invoiceslines_unitpriceTextBox.Name = "invoiceslines_unitpriceTextBox";
            this.invoiceslines_unitpriceTextBox.Size = new System.Drawing.Size(70, 20);
            this.invoiceslines_unitpriceTextBox.TabIndex = 11;
            // 
            // invoiceslines_taxrateTextBox
            // 
            this.invoiceslines_taxrateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_taxrate", true));
            this.invoiceslines_taxrateTextBox.Location = new System.Drawing.Point(144, 182);
            this.invoiceslines_taxrateTextBox.Name = "invoiceslines_taxrateTextBox";
            this.invoiceslines_taxrateTextBox.Size = new System.Drawing.Size(50, 20);
            this.invoiceslines_taxrateTextBox.TabIndex = 9;
            // 
            // invoiceslines_quantityTextBox
            // 
            this.invoiceslines_quantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_quantity", true));
            this.invoiceslines_quantityTextBox.Location = new System.Drawing.Point(12, 182);
            this.invoiceslines_quantityTextBox.Name = "invoiceslines_quantityTextBox";
            this.invoiceslines_quantityTextBox.Size = new System.Drawing.Size(50, 20);
            this.invoiceslines_quantityTextBox.TabIndex = 7;
            // 
            // invoiceslines_descriptionTextBox
            // 
            this.invoiceslines_descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_description", true));
            this.invoiceslines_descriptionTextBox.Location = new System.Drawing.Point(12, 144);
            this.invoiceslines_descriptionTextBox.Name = "invoiceslines_descriptionTextBox";
            this.invoiceslines_descriptionTextBox.Size = new System.Drawing.Size(430, 20);
            this.invoiceslines_descriptionTextBox.TabIndex = 5;
            // 
            // invoiceslines_codeTextBox
            // 
            this.invoiceslines_codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.invoiceslinesBindingSource, "invoiceslines_code", true));
            this.invoiceslines_codeTextBox.Location = new System.Drawing.Point(12, 105);
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
            this.panel_tabInvoicesLines_updates.Location = new System.Drawing.Point(6, 466);
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
            dataGridViewCellStyle2.Format = "0.00";
            this.totalpriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.advancedDataGridView_main.AutoGenerateColumns = false;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.patientDataGridViewTextBoxColumn,
            this.ispaidDataGridViewCheckBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vInvoicesBindingSource;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.MultiSelect = false;
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(284, 390);
            this.advancedDataGridView_main.TabIndex = 0;
            this.advancedDataGridView_main.SortStringChanged += new System.EventHandler(this.advancedDataGridView_main_SortStringChanged);
            this.advancedDataGridView_main.FilterStringChanged += new System.EventHandler(this.advancedDataGridView_main_FilterStringChanged);
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
            dataGridViewCellStyle4.Format = "d";
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
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
            // ispaidDataGridViewCheckBoxColumn
            // 
            this.ispaidDataGridViewCheckBoxColumn.DataPropertyName = "ispaid";
            this.ispaidDataGridViewCheckBoxColumn.HeaderText = "P";
            this.ispaidDataGridViewCheckBoxColumn.MinimumWidth = 22;
            this.ispaidDataGridViewCheckBoxColumn.Name = "ispaidDataGridViewCheckBoxColumn";
            this.ispaidDataGridViewCheckBoxColumn.ReadOnly = true;
            this.ispaidDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ispaidDataGridViewCheckBoxColumn.Width = 50;
            // 
            // vInvoicesBindingSource
            // 
            this.vInvoicesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VInvoices);
            // 
            // panel_listtotal
            // 
            this.panel_listtotal.Controls.Add(this.totalgrossTextBox);
            this.panel_listtotal.Controls.Add(this.totalgrossLabel);
            this.panel_listtotal.Controls.Add(this.totalnetTextBox);
            this.panel_listtotal.Controls.Add(this.totalnetLabel);
            this.panel_listtotal.Controls.Add(this.totalduepaidTextBox);
            this.panel_listtotal.Controls.Add(this.totalduepaidLabel);
            this.panel_listtotal.Controls.Add(this.totaldueTextBox);
            this.panel_listtotal.Controls.Add(this.totaldueLabel);
            this.panel_listtotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_listtotal.Location = new System.Drawing.Point(0, 390);
            this.panel_listtotal.Name = "panel_listtotal";
            this.panel_listtotal.Size = new System.Drawing.Size(284, 112);
            this.panel_listtotal.TabIndex = 2;
            // 
            // totalgrossTextBox
            // 
            this.totalgrossTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalgrossTextBox.Location = new System.Drawing.Point(188, 32);
            this.totalgrossTextBox.Name = "totalgrossTextBox";
            this.totalgrossTextBox.ReadOnly = true;
            this.totalgrossTextBox.Size = new System.Drawing.Size(90, 20);
            this.totalgrossTextBox.TabIndex = 15;
            this.totalgrossTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalgrossLabel
            // 
            this.totalgrossLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalgrossLabel.Location = new System.Drawing.Point(32, 35);
            this.totalgrossLabel.Name = "totalgrossLabel";
            this.totalgrossLabel.Size = new System.Drawing.Size(150, 13);
            this.totalgrossLabel.TabIndex = 14;
            this.totalgrossLabel.Text = "Total Gross:";
            this.totalgrossLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalnetTextBox
            // 
            this.totalnetTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalnetTextBox.Location = new System.Drawing.Point(188, 6);
            this.totalnetTextBox.Name = "totalnetTextBox";
            this.totalnetTextBox.ReadOnly = true;
            this.totalnetTextBox.Size = new System.Drawing.Size(90, 20);
            this.totalnetTextBox.TabIndex = 13;
            this.totalnetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalnetLabel
            // 
            this.totalnetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalnetLabel.Location = new System.Drawing.Point(32, 9);
            this.totalnetLabel.Name = "totalnetLabel";
            this.totalnetLabel.Size = new System.Drawing.Size(150, 13);
            this.totalnetLabel.TabIndex = 12;
            this.totalnetLabel.Text = "Total Net:";
            this.totalnetLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalduepaidTextBox
            // 
            this.totalduepaidTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalduepaidTextBox.Location = new System.Drawing.Point(188, 85);
            this.totalduepaidTextBox.Name = "totalduepaidTextBox";
            this.totalduepaidTextBox.ReadOnly = true;
            this.totalduepaidTextBox.Size = new System.Drawing.Size(90, 20);
            this.totalduepaidTextBox.TabIndex = 11;
            this.totalduepaidTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalduepaidLabel
            // 
            this.totalduepaidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalduepaidLabel.Location = new System.Drawing.Point(32, 87);
            this.totalduepaidLabel.Name = "totalduepaidLabel";
            this.totalduepaidLabel.Size = new System.Drawing.Size(150, 13);
            this.totalduepaidLabel.TabIndex = 10;
            this.totalduepaidLabel.Text = "Total Due Paid:";
            this.totalduepaidLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totaldueTextBox
            // 
            this.totaldueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldueTextBox.Location = new System.Drawing.Point(188, 58);
            this.totaldueTextBox.Name = "totaldueTextBox";
            this.totaldueTextBox.ReadOnly = true;
            this.totaldueTextBox.Size = new System.Drawing.Size(90, 20);
            this.totaldueTextBox.TabIndex = 9;
            this.totaldueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totaldueLabel
            // 
            this.totaldueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totaldueLabel.Location = new System.Drawing.Point(32, 61);
            this.totaldueLabel.Name = "totaldueLabel";
            this.totaldueLabel.Size = new System.Drawing.Size(150, 13);
            this.totaldueLabel.TabIndex = 8;
            this.totaldueLabel.Text = "Total Due:";
            this.totaldueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel_filters
            // 
            this.panel_filters.Controls.Add(this.label_filterYears);
            this.panel_filters.Controls.Add(this.comboBox_filterYears);
            this.panel_filters.Controls.Add(this.comboBox_filterDoctors);
            this.panel_filters.Controls.Add(this.label_filterDoctors);
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 10;
            // 
            // label_filterYears
            // 
            this.label_filterYears.AutoSize = true;
            this.label_filterYears.Location = new System.Drawing.Point(170, 9);
            this.label_filterYears.Name = "label_filterYears";
            this.label_filterYears.Size = new System.Drawing.Size(32, 13);
            this.label_filterYears.TabIndex = 7;
            this.label_filterYears.Text = "Year:";
            // 
            // comboBox_filterYears
            // 
            this.comboBox_filterYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterYears.FormattingEnabled = true;
            this.comboBox_filterYears.Location = new System.Drawing.Point(173, 25);
            this.comboBox_filterYears.Name = "comboBox_filterYears";
            this.comboBox_filterYears.Size = new System.Drawing.Size(70, 21);
            this.comboBox_filterYears.TabIndex = 6;
            this.comboBox_filterYears.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterYear_SelectedIndexChanged);
            // 
            // comboBox_filterDoctors
            // 
            this.comboBox_filterDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterDoctors.FormattingEnabled = true;
            this.comboBox_filterDoctors.Location = new System.Drawing.Point(6, 25);
            this.comboBox_filterDoctors.Name = "comboBox_filterDoctors";
            this.comboBox_filterDoctors.Size = new System.Drawing.Size(150, 21);
            this.comboBox_filterDoctors.TabIndex = 5;
            this.comboBox_filterDoctors.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterDoctors_SelectedIndexChanged);
            // 
            // label_filterDoctors
            // 
            this.label_filterDoctors.AutoSize = true;
            this.label_filterDoctors.Location = new System.Drawing.Point(3, 9);
            this.label_filterDoctors.Name = "label_filterDoctors";
            this.label_filterDoctors.Size = new System.Drawing.Size(42, 13);
            this.label_filterDoctors.TabIndex = 4;
            this.label_filterDoctors.Text = "Doctor:";
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
            ((System.ComponentModel.ISupportInitialize)(this.invoiceslinesBindingSource)).EndInit();
            this.groupBox_tabInvoicesLines_filler.ResumeLayout(false);
            this.groupBox_tabInvoicesLines_filler.PerformLayout();
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
        private System.Windows.Forms.Button button_tabInvoices_setpaid;
        private System.Windows.Forms.Button button_tabInvoices_print;
        private System.Windows.Forms.TabPage tabPage_tabInvoicesLines;
        private System.Windows.Forms.BindingSource vInvoicesBindingSource;
        private System.Windows.Forms.ComboBox comboBox_filterDoctors;
        private System.Windows.Forms.Label label_filterDoctors;
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
        private System.Windows.Forms.GroupBox groupBox_tabInvoicesLines_filler;
        private System.Windows.Forms.ComboBox comboBox_filterYears;
        private System.Windows.Forms.Label label_filterYears;
        private System.Windows.Forms.Label invoices_idLabel;
        private System.Windows.Forms.Label invoices_numberLabel;
        private System.Windows.Forms.Label invoices_doctorLabel;
        private System.Windows.Forms.Label invoices_patientLabel;
        private System.Windows.Forms.Label invoices_dateLabel;
        private System.Windows.Forms.Label invoices_paymentLabel;
        private System.Windows.Forms.Label invoices_footerLabel;
        private System.Windows.Forms.Label invoices_deductiontaxrateLabel;
        private System.Windows.Forms.Label invoiceslines_idLabel;
        private System.Windows.Forms.Label invoiceslines_codeLabel;
        private System.Windows.Forms.Label invoiceslines_descriptionLabel;
        private System.Windows.Forms.Label invoiceslines_quantityLabel;
        private System.Windows.Forms.Label invoiceslines_taxrateLabel;
        private System.Windows.Forms.Label invoiceslines_unitpriceLabel;
        private System.Windows.Forms.Label treatments_idLabel;
        private System.Windows.Forms.Label patientstreatments_idLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ispaidDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxrateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox invoices_totalgrossTextBox;
        private System.Windows.Forms.TextBox invoices_totaldueTextBox;
        private System.Windows.Forms.TextBox invoices_totalnetTextBox;
        private System.Windows.Forms.Label invoices_totalgrossLabel;
        private System.Windows.Forms.Label invoices_totaldueLabel;
        private System.Windows.Forms.Label invoices_totalnetLabel;
        private System.Windows.Forms.CheckBox invoiceslines_istaxesdeductionsableCheckBox;
        private System.Windows.Forms.Label computedlines_idLabel;
        private System.Windows.Forms.ComboBox computedlines_idComboBox;
        private System.Windows.Forms.TextBox totalgrossTextBox;
        private System.Windows.Forms.Label totalgrossLabel;
        private System.Windows.Forms.TextBox totalnetTextBox;
        private System.Windows.Forms.Label totalnetLabel;
        private System.Windows.Forms.TextBox totalduepaidTextBox;
        private System.Windows.Forms.Label totalduepaidLabel;
        private System.Windows.Forms.TextBox totaldueTextBox;
        private System.Windows.Forms.Label totaldueLabel;
    }
}