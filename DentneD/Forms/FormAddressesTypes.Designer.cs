namespace DG.DentneD.Forms
{
    partial class FormAddressesTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddressesTypes));
            this.addressestypes_idLabel = new System.Windows.Forms.Label();
            this.addressestypes_nameLabel = new System.Windows.Forms.Label();
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabAddressesTypes = new System.Windows.Forms.TabPage();
            this.panel_tabAddressesTypes_data = new System.Windows.Forms.Panel();
            this.addressestypes_nameTextBox = new System.Windows.Forms.TextBox();
            this.addressestypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addressestypes_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabAddressesTypes_updates = new System.Windows.Forms.Panel();
            this.button_tabAddressesTypes_cancel = new System.Windows.Forms.Button();
            this.button_tabAddressesTypes_save = new System.Windows.Forms.Button();
            this.panel_tabAddressesTypes_actions = new System.Windows.Forms.Panel();
            this.button_tabAddressesTypes_delete = new System.Windows.Forms.Button();
            this.button_tabAddressesTypes_edit = new System.Windows.Forms.Button();
            this.button_tabAddressesTypes_new = new System.Windows.Forms.Button();
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.addressestypesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vAddressesTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_filters = new System.Windows.Forms.Panel();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabAddressesTypes.SuspendLayout();
            this.panel_tabAddressesTypes_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressestypesBindingSource)).BeginInit();
            this.panel_tabAddressesTypes_updates.SuspendLayout();
            this.panel_tabAddressesTypes_actions.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vAddressesTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addressestypes_idLabel
            // 
            this.addressestypes_idLabel.AutoSize = true;
            this.addressestypes_idLabel.Location = new System.Drawing.Point(9, 9);
            this.addressestypes_idLabel.Name = "addressestypes_idLabel";
            this.addressestypes_idLabel.Size = new System.Drawing.Size(19, 13);
            this.addressestypes_idLabel.TabIndex = 0;
            this.addressestypes_idLabel.Text = "Id:";
            // 
            // addressestypes_nameLabel
            // 
            this.addressestypes_nameLabel.AutoSize = true;
            this.addressestypes_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.addressestypes_nameLabel.Name = "addressestypes_nameLabel";
            this.addressestypes_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.addressestypes_nameLabel.TabIndex = 2;
            this.addressestypes_nameLabel.Text = "Name:";
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
            this.tabControl_main.Controls.Add(this.tabPage_tabAddressesTypes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabAddressesTypes
            // 
            this.tabPage_tabAddressesTypes.Controls.Add(this.panel_tabAddressesTypes_data);
            this.tabPage_tabAddressesTypes.Controls.Add(this.panel_tabAddressesTypes_updates);
            this.tabPage_tabAddressesTypes.Controls.Add(this.panel_tabAddressesTypes_actions);
            this.tabPage_tabAddressesTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabAddressesTypes.Name = "tabPage_tabAddressesTypes";
            this.tabPage_tabAddressesTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabAddressesTypes.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabAddressesTypes.TabIndex = 0;
            this.tabPage_tabAddressesTypes.Text = "Address Type";
            this.tabPage_tabAddressesTypes.UseVisualStyleBackColor = true;
            // 
            // panel_tabAddressesTypes_data
            // 
            this.panel_tabAddressesTypes_data.Controls.Add(this.addressestypes_nameLabel);
            this.panel_tabAddressesTypes_data.Controls.Add(this.addressestypes_nameTextBox);
            this.panel_tabAddressesTypes_data.Controls.Add(this.addressestypes_idLabel);
            this.panel_tabAddressesTypes_data.Controls.Add(this.addressestypes_idTextBox);
            this.panel_tabAddressesTypes_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabAddressesTypes_data.Name = "panel_tabAddressesTypes_data";
            this.panel_tabAddressesTypes_data.Size = new System.Drawing.Size(480, 94);
            this.panel_tabAddressesTypes_data.TabIndex = 2;
            // 
            // addressestypes_nameTextBox
            // 
            this.addressestypes_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressestypesBindingSource, "addressestypes_name", true));
            this.addressestypes_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.addressestypes_nameTextBox.Name = "addressestypes_nameTextBox";
            this.addressestypes_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.addressestypes_nameTextBox.TabIndex = 1;
            // 
            // addressestypesBindingSource
            // 
            this.addressestypesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.addressestypes);
            // 
            // addressestypes_idTextBox
            // 
            this.addressestypes_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressestypesBindingSource, "addressestypes_id", true));
            this.addressestypes_idTextBox.Enabled = false;
            this.addressestypes_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.addressestypes_idTextBox.Name = "addressestypes_idTextBox";
            this.addressestypes_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.addressestypes_idTextBox.TabIndex = 0;
            // 
            // panel_tabAddressesTypes_updates
            // 
            this.panel_tabAddressesTypes_updates.Controls.Add(this.button_tabAddressesTypes_cancel);
            this.panel_tabAddressesTypes_updates.Controls.Add(this.button_tabAddressesTypes_save);
            this.panel_tabAddressesTypes_updates.Location = new System.Drawing.Point(6, 142);
            this.panel_tabAddressesTypes_updates.Name = "panel_tabAddressesTypes_updates";
            this.panel_tabAddressesTypes_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabAddressesTypes_updates.TabIndex = 1;
            // 
            // button_tabAddressesTypes_cancel
            // 
            this.button_tabAddressesTypes_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabAddressesTypes_cancel.Name = "button_tabAddressesTypes_cancel";
            this.button_tabAddressesTypes_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabAddressesTypes_cancel.TabIndex = 1;
            this.button_tabAddressesTypes_cancel.Text = "Cancel";
            this.button_tabAddressesTypes_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabAddressesTypes_save
            // 
            this.button_tabAddressesTypes_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabAddressesTypes_save.Name = "button_tabAddressesTypes_save";
            this.button_tabAddressesTypes_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabAddressesTypes_save.TabIndex = 0;
            this.button_tabAddressesTypes_save.Text = "Save";
            this.button_tabAddressesTypes_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabAddressesTypes_actions
            // 
            this.panel_tabAddressesTypes_actions.Controls.Add(this.button_tabAddressesTypes_delete);
            this.panel_tabAddressesTypes_actions.Controls.Add(this.button_tabAddressesTypes_edit);
            this.panel_tabAddressesTypes_actions.Controls.Add(this.button_tabAddressesTypes_new);
            this.panel_tabAddressesTypes_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabAddressesTypes_actions.Name = "panel_tabAddressesTypes_actions";
            this.panel_tabAddressesTypes_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabAddressesTypes_actions.TabIndex = 0;
            // 
            // button_tabAddressesTypes_delete
            // 
            this.button_tabAddressesTypes_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabAddressesTypes_delete.Name = "button_tabAddressesTypes_delete";
            this.button_tabAddressesTypes_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabAddressesTypes_delete.TabIndex = 2;
            this.button_tabAddressesTypes_delete.Text = "Delete";
            this.button_tabAddressesTypes_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabAddressesTypes_edit
            // 
            this.button_tabAddressesTypes_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabAddressesTypes_edit.Name = "button_tabAddressesTypes_edit";
            this.button_tabAddressesTypes_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabAddressesTypes_edit.TabIndex = 2;
            this.button_tabAddressesTypes_edit.Text = "Edit";
            this.button_tabAddressesTypes_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabAddressesTypes_new
            // 
            this.button_tabAddressesTypes_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabAddressesTypes_new.Name = "button_tabAddressesTypes_new";
            this.button_tabAddressesTypes_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabAddressesTypes_new.TabIndex = 1;
            this.button_tabAddressesTypes_new.Text = "New";
            this.button_tabAddressesTypes_new.UseVisualStyleBackColor = true;
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView_main.AutoGenerateColumns = false;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressestypesidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vAddressesTypesBindingSource;
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
            // 
            // addressestypesidDataGridViewTextBoxColumn
            // 
            this.addressestypesidDataGridViewTextBoxColumn.DataPropertyName = "addressestypes_id";
            this.addressestypesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.addressestypesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.addressestypesidDataGridViewTextBoxColumn.Name = "addressestypesidDataGridViewTextBoxColumn";
            this.addressestypesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressestypesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.addressestypesidDataGridViewTextBoxColumn.Width = 80;
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
            // vAddressesTypesBindingSource
            // 
            this.vAddressesTypesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VAddressesTypes);
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 1;
            // 
            // FormAddressesTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormAddressesTypes";
            this.Text = "Address Types";
            this.Load += new System.EventHandler(this.FormAddressesTypes_Load);
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabAddressesTypes.ResumeLayout(false);
            this.panel_tabAddressesTypes_data.ResumeLayout(false);
            this.panel_tabAddressesTypes_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressestypesBindingSource)).EndInit();
            this.panel_tabAddressesTypes_updates.ResumeLayout(false);
            this.panel_tabAddressesTypes_actions.ResumeLayout(false);
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vAddressesTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabAddressesTypes;
        private System.Windows.Forms.Panel panel_tabAddressesTypes_data;
        private System.Windows.Forms.Panel panel_tabAddressesTypes_updates;
        private System.Windows.Forms.Button button_tabAddressesTypes_cancel;
        private System.Windows.Forms.Button button_tabAddressesTypes_save;
        private System.Windows.Forms.Panel panel_tabAddressesTypes_actions;
        private System.Windows.Forms.Button button_tabAddressesTypes_delete;
        private System.Windows.Forms.Button button_tabAddressesTypes_edit;
        private System.Windows.Forms.Button button_tabAddressesTypes_new;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressestypesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vAddressesTypesBindingSource;
        private System.Windows.Forms.TextBox addressestypes_nameTextBox;
        private System.Windows.Forms.BindingSource addressestypesBindingSource;
        private System.Windows.Forms.TextBox addressestypes_idTextBox;
        private System.Windows.Forms.Label addressestypes_idLabel;
        private System.Windows.Forms.Label addressestypes_nameLabel;
    }
}