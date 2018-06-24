namespace DG.DentneD.Forms
{
    partial class FormMedicalrecordsTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMedicalrecordsTypes));
            this.medicalrecordstypes_idLabel = new System.Windows.Forms.Label();
            this.medicalrecordstypes_nameLabel = new System.Windows.Forms.Label();
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabMedicalrecordsTypes = new System.Windows.Forms.TabPage();
            this.panel_tabMedicalrecordsTypes_data = new System.Windows.Forms.Panel();
            this.medicalrecordstypes_nameTextBox = new System.Windows.Forms.TextBox();
            this.medicalrecordstypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicalrecordstypes_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabMedicalrecordsTypes_updates = new System.Windows.Forms.Panel();
            this.button_tabMedicalrecordsTypes_cancel = new System.Windows.Forms.Button();
            this.button_tabMedicalrecordsTypes_save = new System.Windows.Forms.Button();
            this.panel_tabMedicalrecordsTypes_actions = new System.Windows.Forms.Panel();
            this.button_tabMedicalrecordsTypes_delete = new System.Windows.Forms.Button();
            this.button_tabMedicalrecordsTypes_edit = new System.Windows.Forms.Button();
            this.button_tabMedicalrecordsTypes_new = new System.Windows.Forms.Button();
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.medicalrecordstypesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vMedicalrecordsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_filters = new System.Windows.Forms.Panel();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabMedicalrecordsTypes.SuspendLayout();
            this.panel_tabMedicalrecordsTypes_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicalrecordstypesBindingSource)).BeginInit();
            this.panel_tabMedicalrecordsTypes_updates.SuspendLayout();
            this.panel_tabMedicalrecordsTypes_actions.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMedicalrecordsTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // medicalrecordstypes_idLabel
            // 
            this.medicalrecordstypes_idLabel.AutoSize = true;
            this.medicalrecordstypes_idLabel.Location = new System.Drawing.Point(9, 9);
            this.medicalrecordstypes_idLabel.Name = "medicalrecordstypes_idLabel";
            this.medicalrecordstypes_idLabel.Size = new System.Drawing.Size(19, 13);
            this.medicalrecordstypes_idLabel.TabIndex = 0;
            this.medicalrecordstypes_idLabel.Text = "Id:";
            // 
            // medicalrecordstypes_nameLabel
            // 
            this.medicalrecordstypes_nameLabel.AutoSize = true;
            this.medicalrecordstypes_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.medicalrecordstypes_nameLabel.Name = "medicalrecordstypes_nameLabel";
            this.medicalrecordstypes_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.medicalrecordstypes_nameLabel.TabIndex = 2;
            this.medicalrecordstypes_nameLabel.Text = "Name:";
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
            this.tabControl_main.Controls.Add(this.tabPage_tabMedicalrecordsTypes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabMedicalrecordsTypes
            // 
            this.tabPage_tabMedicalrecordsTypes.Controls.Add(this.panel_tabMedicalrecordsTypes_data);
            this.tabPage_tabMedicalrecordsTypes.Controls.Add(this.panel_tabMedicalrecordsTypes_updates);
            this.tabPage_tabMedicalrecordsTypes.Controls.Add(this.panel_tabMedicalrecordsTypes_actions);
            this.tabPage_tabMedicalrecordsTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabMedicalrecordsTypes.Name = "tabPage_tabMedicalrecordsTypes";
            this.tabPage_tabMedicalrecordsTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabMedicalrecordsTypes.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabMedicalrecordsTypes.TabIndex = 0;
            this.tabPage_tabMedicalrecordsTypes.Text = "Medical Record Type";
            this.tabPage_tabMedicalrecordsTypes.UseVisualStyleBackColor = true;
            // 
            // panel_tabMedicalrecordsTypes_data
            // 
            this.panel_tabMedicalrecordsTypes_data.Controls.Add(this.medicalrecordstypes_nameLabel);
            this.panel_tabMedicalrecordsTypes_data.Controls.Add(this.medicalrecordstypes_nameTextBox);
            this.panel_tabMedicalrecordsTypes_data.Controls.Add(this.medicalrecordstypes_idLabel);
            this.panel_tabMedicalrecordsTypes_data.Controls.Add(this.medicalrecordstypes_idTextBox);
            this.panel_tabMedicalrecordsTypes_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabMedicalrecordsTypes_data.Name = "panel_tabMedicalrecordsTypes_data";
            this.panel_tabMedicalrecordsTypes_data.Size = new System.Drawing.Size(480, 91);
            this.panel_tabMedicalrecordsTypes_data.TabIndex = 2;
            // 
            // medicalrecordstypes_nameTextBox
            // 
            this.medicalrecordstypes_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.medicalrecordstypesBindingSource, "medicalrecordstypes_name", true));
            this.medicalrecordstypes_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.medicalrecordstypes_nameTextBox.Name = "medicalrecordstypes_nameTextBox";
            this.medicalrecordstypes_nameTextBox.Size = new System.Drawing.Size(150, 20);
            this.medicalrecordstypes_nameTextBox.TabIndex = 3;
            // 
            // medicalrecordstypesBindingSource
            // 
            this.medicalrecordstypesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.medicalrecordstypes);
            // 
            // medicalrecordstypes_idTextBox
            // 
            this.medicalrecordstypes_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.medicalrecordstypesBindingSource, "medicalrecordstypes_id", true));
            this.medicalrecordstypes_idTextBox.Enabled = false;
            this.medicalrecordstypes_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.medicalrecordstypes_idTextBox.Name = "medicalrecordstypes_idTextBox";
            this.medicalrecordstypes_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.medicalrecordstypes_idTextBox.TabIndex = 1;
            // 
            // panel_tabMedicalrecordsTypes_updates
            // 
            this.panel_tabMedicalrecordsTypes_updates.Controls.Add(this.button_tabMedicalrecordsTypes_cancel);
            this.panel_tabMedicalrecordsTypes_updates.Controls.Add(this.button_tabMedicalrecordsTypes_save);
            this.panel_tabMedicalrecordsTypes_updates.Location = new System.Drawing.Point(6, 139);
            this.panel_tabMedicalrecordsTypes_updates.Name = "panel_tabMedicalrecordsTypes_updates";
            this.panel_tabMedicalrecordsTypes_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabMedicalrecordsTypes_updates.TabIndex = 1;
            // 
            // button_tabMedicalrecordsTypes_cancel
            // 
            this.button_tabMedicalrecordsTypes_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabMedicalrecordsTypes_cancel.Name = "button_tabMedicalrecordsTypes_cancel";
            this.button_tabMedicalrecordsTypes_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabMedicalrecordsTypes_cancel.TabIndex = 2;
            this.button_tabMedicalrecordsTypes_cancel.Text = "Cancel";
            this.button_tabMedicalrecordsTypes_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabMedicalrecordsTypes_save
            // 
            this.button_tabMedicalrecordsTypes_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabMedicalrecordsTypes_save.Name = "button_tabMedicalrecordsTypes_save";
            this.button_tabMedicalrecordsTypes_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabMedicalrecordsTypes_save.TabIndex = 1;
            this.button_tabMedicalrecordsTypes_save.Text = "Save";
            this.button_tabMedicalrecordsTypes_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabMedicalrecordsTypes_actions
            // 
            this.panel_tabMedicalrecordsTypes_actions.Controls.Add(this.button_tabMedicalrecordsTypes_delete);
            this.panel_tabMedicalrecordsTypes_actions.Controls.Add(this.button_tabMedicalrecordsTypes_edit);
            this.panel_tabMedicalrecordsTypes_actions.Controls.Add(this.button_tabMedicalrecordsTypes_new);
            this.panel_tabMedicalrecordsTypes_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabMedicalrecordsTypes_actions.Name = "panel_tabMedicalrecordsTypes_actions";
            this.panel_tabMedicalrecordsTypes_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabMedicalrecordsTypes_actions.TabIndex = 0;
            // 
            // button_tabMedicalrecordsTypes_delete
            // 
            this.button_tabMedicalrecordsTypes_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabMedicalrecordsTypes_delete.Name = "button_tabMedicalrecordsTypes_delete";
            this.button_tabMedicalrecordsTypes_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabMedicalrecordsTypes_delete.TabIndex = 2;
            this.button_tabMedicalrecordsTypes_delete.Text = "Delete";
            this.button_tabMedicalrecordsTypes_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabMedicalrecordsTypes_edit
            // 
            this.button_tabMedicalrecordsTypes_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabMedicalrecordsTypes_edit.Name = "button_tabMedicalrecordsTypes_edit";
            this.button_tabMedicalrecordsTypes_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabMedicalrecordsTypes_edit.TabIndex = 1;
            this.button_tabMedicalrecordsTypes_edit.Text = "Edit";
            this.button_tabMedicalrecordsTypes_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabMedicalrecordsTypes_new
            // 
            this.button_tabMedicalrecordsTypes_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabMedicalrecordsTypes_new.Name = "button_tabMedicalrecordsTypes_new";
            this.button_tabMedicalrecordsTypes_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabMedicalrecordsTypes_new.TabIndex = 0;
            this.button_tabMedicalrecordsTypes_new.Text = "New";
            this.button_tabMedicalrecordsTypes_new.UseVisualStyleBackColor = true;
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
            this.medicalrecordstypesidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vMedicalrecordsTypesBindingSource;
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
            // medicalrecordstypesidDataGridViewTextBoxColumn
            // 
            this.medicalrecordstypesidDataGridViewTextBoxColumn.DataPropertyName = "medicalrecordstypes_id";
            this.medicalrecordstypesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.medicalrecordstypesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.medicalrecordstypesidDataGridViewTextBoxColumn.Name = "medicalrecordstypesidDataGridViewTextBoxColumn";
            this.medicalrecordstypesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.medicalrecordstypesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.medicalrecordstypesidDataGridViewTextBoxColumn.Width = 80;
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
            // vMedicalrecordsTypesBindingSource
            // 
            this.vMedicalrecordsTypesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VMedicalrecordsTypes);
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 10;
            // 
            // FormMedicalrecordsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMedicalrecordsTypes";
            this.Text = "Medial Records Types";
            this.Load += new System.EventHandler(this.FormMedicalrecordsTypes_Load);
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabMedicalrecordsTypes.ResumeLayout(false);
            this.panel_tabMedicalrecordsTypes_data.ResumeLayout(false);
            this.panel_tabMedicalrecordsTypes_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicalrecordstypesBindingSource)).EndInit();
            this.panel_tabMedicalrecordsTypes_updates.ResumeLayout(false);
            this.panel_tabMedicalrecordsTypes_actions.ResumeLayout(false);
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMedicalrecordsTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabMedicalrecordsTypes;
        private System.Windows.Forms.Panel panel_tabMedicalrecordsTypes_data;
        private System.Windows.Forms.Panel panel_tabMedicalrecordsTypes_updates;
        private System.Windows.Forms.Button button_tabMedicalrecordsTypes_cancel;
        private System.Windows.Forms.Button button_tabMedicalrecordsTypes_save;
        private System.Windows.Forms.Panel panel_tabMedicalrecordsTypes_actions;
        private System.Windows.Forms.Button button_tabMedicalrecordsTypes_delete;
        private System.Windows.Forms.Button button_tabMedicalrecordsTypes_edit;
        private System.Windows.Forms.Button button_tabMedicalrecordsTypes_new;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicalrecordstypesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vMedicalrecordsTypesBindingSource;
        private System.Windows.Forms.TextBox medicalrecordstypes_nameTextBox;
        private System.Windows.Forms.BindingSource medicalrecordstypesBindingSource;
        private System.Windows.Forms.TextBox medicalrecordstypes_idTextBox;
        private System.Windows.Forms.Label medicalrecordstypes_idLabel;
        private System.Windows.Forms.Label medicalrecordstypes_nameLabel;
    }
}