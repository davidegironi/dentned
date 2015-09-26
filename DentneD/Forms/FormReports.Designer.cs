namespace DG.DentneD.Forms
{
    partial class FormReports
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
            System.Windows.Forms.Label reports_infotextLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReports));
            this.reports_idLabel = new System.Windows.Forms.Label();
            this.reports_nameLabel = new System.Windows.Forms.Label();
            this.reports_queryLabel = new System.Windows.Forms.Label();
            this.panel_filters = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.panel_list = new System.Windows.Forms.Panel();
            this.button_tabReports_delete = new System.Windows.Forms.Button();
            this.button_tabReports_edit = new System.Windows.Forms.Button();
            this.button_tabReports_new = new System.Windows.Forms.Button();
            this.panel_tabReports_actions = new System.Windows.Forms.Panel();
            this.button_tabReports_cancel = new System.Windows.Forms.Button();
            this.button_tabReports_save = new System.Windows.Forms.Button();
            this.panel_tabReports_data = new System.Windows.Forms.Panel();
            this.reports_ispasswordprotectedCheckBox = new System.Windows.Forms.CheckBox();
            this.reportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reports_infotextTextBox = new System.Windows.Forms.TextBox();
            this.reports_queryTextBox = new System.Windows.Forms.TextBox();
            this.reports_nameTextBox = new System.Windows.Forms.TextBox();
            this.reports_idTextBox = new System.Windows.Forms.TextBox();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabReports = new System.Windows.Forms.TabPage();
            this.panel_tabReports_updates = new System.Windows.Forms.Panel();
            this.panel_data = new System.Windows.Forms.Panel();
            this.addressestypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportsidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vAddressesTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            reports_infotextLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            this.panel_list.SuspendLayout();
            this.panel_tabReports_actions.SuspendLayout();
            this.panel_tabReports_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).BeginInit();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabReports.SuspendLayout();
            this.panel_tabReports_updates.SuspendLayout();
            this.panel_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressestypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vReportsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vAddressesTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reports_infotextLabel
            // 
            reports_infotextLabel.AutoSize = true;
            reports_infotextLabel.Location = new System.Drawing.Point(9, 306);
            reports_infotextLabel.Name = "reports_infotextLabel";
            reports_infotextLabel.Size = new System.Drawing.Size(52, 13);
            reports_infotextLabel.TabIndex = 6;
            reports_infotextLabel.Text = "Info Text:";
            // 
            // reports_idLabel
            // 
            this.reports_idLabel.AutoSize = true;
            this.reports_idLabel.Location = new System.Drawing.Point(9, 9);
            this.reports_idLabel.Name = "reports_idLabel";
            this.reports_idLabel.Size = new System.Drawing.Size(19, 13);
            this.reports_idLabel.TabIndex = 0;
            this.reports_idLabel.Text = "Id:";
            // 
            // reports_nameLabel
            // 
            this.reports_nameLabel.AutoSize = true;
            this.reports_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.reports_nameLabel.Name = "reports_nameLabel";
            this.reports_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.reports_nameLabel.TabIndex = 2;
            this.reports_nameLabel.Text = "Name:";
            // 
            // reports_queryLabel
            // 
            this.reports_queryLabel.AutoSize = true;
            this.reports_queryLabel.Location = new System.Drawing.Point(9, 87);
            this.reports_queryLabel.Name = "reports_queryLabel";
            this.reports_queryLabel.Size = new System.Drawing.Size(38, 13);
            this.reports_queryLabel.TabIndex = 4;
            this.reports_queryLabel.Text = "Query:";
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 13;
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToAddRows = false;
            this.advancedDataGridView_main.AllowUserToDeleteRows = false;
            this.advancedDataGridView_main.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView_main.AutoGenerateColumns = false;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reportsidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vReportsBindingSource;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.MultiSelect = false;
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(284, 502);
            this.advancedDataGridView_main.TabIndex = 0;
            this.advancedDataGridView_main.SortStringChanged += new System.EventHandler(this.advancedDataGridView_main_SortStringChanged);
            this.advancedDataGridView_main.FilterStringChanged += new System.EventHandler(this.advancedDataGridView_main_FilterStringChanged);
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 60);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(284, 502);
            this.panel_list.TabIndex = 14;
            // 
            // button_tabReports_delete
            // 
            this.button_tabReports_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabReports_delete.Name = "button_tabReports_delete";
            this.button_tabReports_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabReports_delete.TabIndex = 2;
            this.button_tabReports_delete.Text = "Delete";
            this.button_tabReports_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabReports_edit
            // 
            this.button_tabReports_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabReports_edit.Name = "button_tabReports_edit";
            this.button_tabReports_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabReports_edit.TabIndex = 1;
            this.button_tabReports_edit.Text = "Edit";
            this.button_tabReports_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabReports_new
            // 
            this.button_tabReports_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabReports_new.Name = "button_tabReports_new";
            this.button_tabReports_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabReports_new.TabIndex = 0;
            this.button_tabReports_new.Text = "New";
            this.button_tabReports_new.UseVisualStyleBackColor = true;
            // 
            // panel_tabReports_actions
            // 
            this.panel_tabReports_actions.Controls.Add(this.button_tabReports_delete);
            this.panel_tabReports_actions.Controls.Add(this.button_tabReports_edit);
            this.panel_tabReports_actions.Controls.Add(this.button_tabReports_new);
            this.panel_tabReports_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabReports_actions.Name = "panel_tabReports_actions";
            this.panel_tabReports_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabReports_actions.TabIndex = 0;
            // 
            // button_tabReports_cancel
            // 
            this.button_tabReports_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabReports_cancel.Name = "button_tabReports_cancel";
            this.button_tabReports_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabReports_cancel.TabIndex = 2;
            this.button_tabReports_cancel.Text = "Cancel";
            this.button_tabReports_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabReports_save
            // 
            this.button_tabReports_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabReports_save.Name = "button_tabReports_save";
            this.button_tabReports_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabReports_save.TabIndex = 1;
            this.button_tabReports_save.Text = "Save";
            this.button_tabReports_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabReports_data
            // 
            this.panel_tabReports_data.Controls.Add(this.reports_ispasswordprotectedCheckBox);
            this.panel_tabReports_data.Controls.Add(reports_infotextLabel);
            this.panel_tabReports_data.Controls.Add(this.reports_infotextTextBox);
            this.panel_tabReports_data.Controls.Add(this.reports_queryLabel);
            this.panel_tabReports_data.Controls.Add(this.reports_queryTextBox);
            this.panel_tabReports_data.Controls.Add(this.reports_nameLabel);
            this.panel_tabReports_data.Controls.Add(this.reports_nameTextBox);
            this.panel_tabReports_data.Controls.Add(this.reports_idLabel);
            this.panel_tabReports_data.Controls.Add(this.reports_idTextBox);
            this.panel_tabReports_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabReports_data.Name = "panel_tabReports_data";
            this.panel_tabReports_data.Size = new System.Drawing.Size(480, 431);
            this.panel_tabReports_data.TabIndex = 2;
            // 
            // reports_ispasswordprotectedCheckBox
            // 
            this.reports_ispasswordprotectedCheckBox.AutoSize = true;
            this.reports_ispasswordprotectedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.reportsBindingSource, "reports_ispasswordprotected", true));
            this.reports_ispasswordprotectedCheckBox.Location = new System.Drawing.Point(221, 27);
            this.reports_ispasswordprotectedCheckBox.Name = "reports_ispasswordprotectedCheckBox";
            this.reports_ispasswordprotectedCheckBox.Size = new System.Drawing.Size(130, 17);
            this.reports_ispasswordprotectedCheckBox.TabIndex = 9;
            this.reports_ispasswordprotectedCheckBox.Text = "Is password protected";
            this.reports_ispasswordprotectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // reportsBindingSource
            // 
            this.reportsBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.reports);
            // 
            // reports_infotextTextBox
            // 
            this.reports_infotextTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "reports_infotext", true));
            this.reports_infotextTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reports_infotextTextBox.Location = new System.Drawing.Point(12, 322);
            this.reports_infotextTextBox.Multiline = true;
            this.reports_infotextTextBox.Name = "reports_infotextTextBox";
            this.reports_infotextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.reports_infotextTextBox.Size = new System.Drawing.Size(430, 100);
            this.reports_infotextTextBox.TabIndex = 7;
            // 
            // reports_queryTextBox
            // 
            this.reports_queryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "reports_query", true));
            this.reports_queryTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reports_queryTextBox.Location = new System.Drawing.Point(12, 103);
            this.reports_queryTextBox.Multiline = true;
            this.reports_queryTextBox.Name = "reports_queryTextBox";
            this.reports_queryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.reports_queryTextBox.Size = new System.Drawing.Size(430, 200);
            this.reports_queryTextBox.TabIndex = 5;
            this.reports_queryTextBox.WordWrap = false;
            // 
            // reports_nameTextBox
            // 
            this.reports_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "reports_name", true));
            this.reports_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.reports_nameTextBox.Name = "reports_nameTextBox";
            this.reports_nameTextBox.Size = new System.Drawing.Size(430, 20);
            this.reports_nameTextBox.TabIndex = 3;
            // 
            // reports_idTextBox
            // 
            this.reports_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "reports_id", true));
            this.reports_idTextBox.Enabled = false;
            this.reports_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.reports_idTextBox.Name = "reports_idTextBox";
            this.reports_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.reports_idTextBox.TabIndex = 1;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabReports);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabReports
            // 
            this.tabPage_tabReports.Controls.Add(this.panel_tabReports_data);
            this.tabPage_tabReports.Controls.Add(this.panel_tabReports_updates);
            this.tabPage_tabReports.Controls.Add(this.panel_tabReports_actions);
            this.tabPage_tabReports.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabReports.Name = "tabPage_tabReports";
            this.tabPage_tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabReports.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabReports.TabIndex = 0;
            this.tabPage_tabReports.Text = "Report";
            this.tabPage_tabReports.UseVisualStyleBackColor = true;
            // 
            // panel_tabReports_updates
            // 
            this.panel_tabReports_updates.Controls.Add(this.button_tabReports_cancel);
            this.panel_tabReports_updates.Controls.Add(this.button_tabReports_save);
            this.panel_tabReports_updates.Location = new System.Drawing.Point(6, 479);
            this.panel_tabReports_updates.Name = "panel_tabReports_updates";
            this.panel_tabReports_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabReports_updates.TabIndex = 1;
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.tabControl_main);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(284, 0);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(500, 562);
            this.panel_data.TabIndex = 12;
            // 
            // addressestypesBindingSource
            // 
            this.addressestypesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.addressestypes);
            // 
            // reportsidDataGridViewTextBoxColumn
            // 
            this.reportsidDataGridViewTextBoxColumn.DataPropertyName = "reports_id";
            this.reportsidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.reportsidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.reportsidDataGridViewTextBoxColumn.Name = "reportsidDataGridViewTextBoxColumn";
            this.reportsidDataGridViewTextBoxColumn.ReadOnly = true;
            this.reportsidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.reportsidDataGridViewTextBoxColumn.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // vReportsBindingSource
            // 
            this.vReportsBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VReports);
            // 
            // vAddressesTypesBindingSource
            // 
            this.vAddressesTypesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VAddressesTypes);
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormReports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.FormReports_Load);
            this.Shown += new System.EventHandler(this.FormReports_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.panel_tabReports_actions.ResumeLayout(false);
            this.panel_tabReports_data.ResumeLayout(false);
            this.panel_tabReports_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).EndInit();
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabReports.ResumeLayout(false);
            this.panel_tabReports_updates.ResumeLayout(false);
            this.panel_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addressestypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vReportsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vAddressesTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filters;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.BindingSource vAddressesTypesBindingSource;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.Button button_tabReports_delete;
        private System.Windows.Forms.Button button_tabReports_edit;
        private System.Windows.Forms.Button button_tabReports_new;
        private System.Windows.Forms.Panel panel_tabReports_actions;
        private System.Windows.Forms.Button button_tabReports_cancel;
        private System.Windows.Forms.Button button_tabReports_save;
        private System.Windows.Forms.BindingSource addressestypesBindingSource;
        private System.Windows.Forms.Panel panel_tabReports_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabReports;
        private System.Windows.Forms.Panel panel_tabReports_updates;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TextBox reports_queryTextBox;
        private System.Windows.Forms.BindingSource reportsBindingSource;
        private System.Windows.Forms.TextBox reports_nameTextBox;
        private System.Windows.Forms.TextBox reports_idTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportsidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vReportsBindingSource;
        private System.Windows.Forms.Label reports_idLabel;
        private System.Windows.Forms.Label reports_nameLabel;
        private System.Windows.Forms.Label reports_queryLabel;
        private System.Windows.Forms.TextBox reports_infotextTextBox;
        private System.Windows.Forms.CheckBox reports_ispasswordprotectedCheckBox;

    }
}