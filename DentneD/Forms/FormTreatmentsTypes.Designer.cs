namespace DG.DentneD.Forms
{
    partial class FormTreatmentsTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTreatmentsTypes));
            this.treatmentstypes_idLabel = new System.Windows.Forms.Label();
            this.treatmentstypes_nameLabel = new System.Windows.Forms.Label();
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabTreatmentsTypes = new System.Windows.Forms.TabPage();
            this.panel_tabTreatmentsTypes_data = new System.Windows.Forms.Panel();
            this.treatmentstypes_nameTextBox = new System.Windows.Forms.TextBox();
            this.treatmentstypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treatmentstypes_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabTreatmentsTypes_updates = new System.Windows.Forms.Panel();
            this.button_tabTreatmentsTypes_cancel = new System.Windows.Forms.Button();
            this.button_tabTreatmentsTypes_save = new System.Windows.Forms.Button();
            this.panel_tabTreatmentsTypes_actions = new System.Windows.Forms.Panel();
            this.button_tabTreatmentsTypes_delete = new System.Windows.Forms.Button();
            this.button_tabTreatmentsTypes_edit = new System.Windows.Forms.Button();
            this.button_tabTreatmentsTypes_new = new System.Windows.Forms.Button();
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.treatmentstypesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vTreatmentsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_filters = new System.Windows.Forms.Panel();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabTreatmentsTypes.SuspendLayout();
            this.panel_tabTreatmentsTypes_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentstypesBindingSource)).BeginInit();
            this.panel_tabTreatmentsTypes_updates.SuspendLayout();
            this.panel_tabTreatmentsTypes_actions.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTreatmentsTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treatmentstypes_idLabel
            // 
            this.treatmentstypes_idLabel.AutoSize = true;
            this.treatmentstypes_idLabel.Location = new System.Drawing.Point(9, 9);
            this.treatmentstypes_idLabel.Name = "treatmentstypes_idLabel";
            this.treatmentstypes_idLabel.Size = new System.Drawing.Size(19, 13);
            this.treatmentstypes_idLabel.TabIndex = 0;
            this.treatmentstypes_idLabel.Text = "Id:";
            // 
            // treatmentstypes_nameLabel
            // 
            this.treatmentstypes_nameLabel.AutoSize = true;
            this.treatmentstypes_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.treatmentstypes_nameLabel.Name = "treatmentstypes_nameLabel";
            this.treatmentstypes_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.treatmentstypes_nameLabel.TabIndex = 2;
            this.treatmentstypes_nameLabel.Text = "Name:";
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
            this.tabControl_main.Controls.Add(this.tabPage_tabTreatmentsTypes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabTreatmentsTypes
            // 
            this.tabPage_tabTreatmentsTypes.Controls.Add(this.panel_tabTreatmentsTypes_data);
            this.tabPage_tabTreatmentsTypes.Controls.Add(this.panel_tabTreatmentsTypes_updates);
            this.tabPage_tabTreatmentsTypes.Controls.Add(this.panel_tabTreatmentsTypes_actions);
            this.tabPage_tabTreatmentsTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabTreatmentsTypes.Name = "tabPage_tabTreatmentsTypes";
            this.tabPage_tabTreatmentsTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabTreatmentsTypes.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabTreatmentsTypes.TabIndex = 0;
            this.tabPage_tabTreatmentsTypes.Text = "Type";
            this.tabPage_tabTreatmentsTypes.UseVisualStyleBackColor = true;
            // 
            // panel_tabTreatmentsTypes_data
            // 
            this.panel_tabTreatmentsTypes_data.Controls.Add(this.treatmentstypes_nameLabel);
            this.panel_tabTreatmentsTypes_data.Controls.Add(this.treatmentstypes_nameTextBox);
            this.panel_tabTreatmentsTypes_data.Controls.Add(this.treatmentstypes_idLabel);
            this.panel_tabTreatmentsTypes_data.Controls.Add(this.treatmentstypes_idTextBox);
            this.panel_tabTreatmentsTypes_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabTreatmentsTypes_data.Name = "panel_tabTreatmentsTypes_data";
            this.panel_tabTreatmentsTypes_data.Size = new System.Drawing.Size(480, 94);
            this.panel_tabTreatmentsTypes_data.TabIndex = 2;
            // 
            // treatmentstypes_nameTextBox
            // 
            this.treatmentstypes_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentstypesBindingSource, "treatmentstypes_name", true));
            this.treatmentstypes_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.treatmentstypes_nameTextBox.Name = "treatmentstypes_nameTextBox";
            this.treatmentstypes_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.treatmentstypes_nameTextBox.TabIndex = 3;
            // 
            // treatmentstypesBindingSource
            // 
            this.treatmentstypesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.treatmentstypes);
            // 
            // treatmentstypes_idTextBox
            // 
            this.treatmentstypes_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentstypesBindingSource, "treatmentstypes_id", true));
            this.treatmentstypes_idTextBox.Enabled = false;
            this.treatmentstypes_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.treatmentstypes_idTextBox.Name = "treatmentstypes_idTextBox";
            this.treatmentstypes_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.treatmentstypes_idTextBox.TabIndex = 1;
            // 
            // panel_tabTreatmentsTypes_updates
            // 
            this.panel_tabTreatmentsTypes_updates.Controls.Add(this.button_tabTreatmentsTypes_cancel);
            this.panel_tabTreatmentsTypes_updates.Controls.Add(this.button_tabTreatmentsTypes_save);
            this.panel_tabTreatmentsTypes_updates.Location = new System.Drawing.Point(6, 142);
            this.panel_tabTreatmentsTypes_updates.Name = "panel_tabTreatmentsTypes_updates";
            this.panel_tabTreatmentsTypes_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabTreatmentsTypes_updates.TabIndex = 1;
            // 
            // button_tabTreatmentsTypes_cancel
            // 
            this.button_tabTreatmentsTypes_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabTreatmentsTypes_cancel.Name = "button_tabTreatmentsTypes_cancel";
            this.button_tabTreatmentsTypes_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabTreatmentsTypes_cancel.TabIndex = 2;
            this.button_tabTreatmentsTypes_cancel.Text = "Cancel";
            this.button_tabTreatmentsTypes_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabTreatmentsTypes_save
            // 
            this.button_tabTreatmentsTypes_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabTreatmentsTypes_save.Name = "button_tabTreatmentsTypes_save";
            this.button_tabTreatmentsTypes_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabTreatmentsTypes_save.TabIndex = 1;
            this.button_tabTreatmentsTypes_save.Text = "Save";
            this.button_tabTreatmentsTypes_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabTreatmentsTypes_actions
            // 
            this.panel_tabTreatmentsTypes_actions.Controls.Add(this.button_tabTreatmentsTypes_delete);
            this.panel_tabTreatmentsTypes_actions.Controls.Add(this.button_tabTreatmentsTypes_edit);
            this.panel_tabTreatmentsTypes_actions.Controls.Add(this.button_tabTreatmentsTypes_new);
            this.panel_tabTreatmentsTypes_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabTreatmentsTypes_actions.Name = "panel_tabTreatmentsTypes_actions";
            this.panel_tabTreatmentsTypes_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabTreatmentsTypes_actions.TabIndex = 0;
            // 
            // button_tabTreatmentsTypes_delete
            // 
            this.button_tabTreatmentsTypes_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabTreatmentsTypes_delete.Name = "button_tabTreatmentsTypes_delete";
            this.button_tabTreatmentsTypes_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabTreatmentsTypes_delete.TabIndex = 2;
            this.button_tabTreatmentsTypes_delete.Text = "Delete";
            this.button_tabTreatmentsTypes_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabTreatmentsTypes_edit
            // 
            this.button_tabTreatmentsTypes_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabTreatmentsTypes_edit.Name = "button_tabTreatmentsTypes_edit";
            this.button_tabTreatmentsTypes_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabTreatmentsTypes_edit.TabIndex = 1;
            this.button_tabTreatmentsTypes_edit.Text = "Edit";
            this.button_tabTreatmentsTypes_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabTreatmentsTypes_new
            // 
            this.button_tabTreatmentsTypes_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabTreatmentsTypes_new.Name = "button_tabTreatmentsTypes_new";
            this.button_tabTreatmentsTypes_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabTreatmentsTypes_new.TabIndex = 0;
            this.button_tabTreatmentsTypes_new.Text = "New";
            this.button_tabTreatmentsTypes_new.UseVisualStyleBackColor = true;
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
            this.treatmentstypesidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vTreatmentsTypesBindingSource;
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
            // treatmentstypesidDataGridViewTextBoxColumn
            // 
            this.treatmentstypesidDataGridViewTextBoxColumn.DataPropertyName = "treatmentstypes_id";
            this.treatmentstypesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.treatmentstypesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.treatmentstypesidDataGridViewTextBoxColumn.Name = "treatmentstypesidDataGridViewTextBoxColumn";
            this.treatmentstypesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.treatmentstypesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.treatmentstypesidDataGridViewTextBoxColumn.Width = 80;
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
            // vTreatmentsTypesBindingSource
            // 
            this.vTreatmentsTypesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VTreatmentsTypes);
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 10;
            // 
            // FormTreatmentsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormTreatmentsTypes";
            this.Text = "Treatment Types";
            this.Load += new System.EventHandler(this.FormTreatmentsTypes_Load);
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabTreatmentsTypes.ResumeLayout(false);
            this.panel_tabTreatmentsTypes_data.ResumeLayout(false);
            this.panel_tabTreatmentsTypes_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentstypesBindingSource)).EndInit();
            this.panel_tabTreatmentsTypes_updates.ResumeLayout(false);
            this.panel_tabTreatmentsTypes_actions.ResumeLayout(false);
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTreatmentsTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabTreatmentsTypes;
        private System.Windows.Forms.Panel panel_tabTreatmentsTypes_data;
        private System.Windows.Forms.Panel panel_tabTreatmentsTypes_updates;
        private System.Windows.Forms.Button button_tabTreatmentsTypes_cancel;
        private System.Windows.Forms.Button button_tabTreatmentsTypes_save;
        private System.Windows.Forms.Panel panel_tabTreatmentsTypes_actions;
        private System.Windows.Forms.Button button_tabTreatmentsTypes_delete;
        private System.Windows.Forms.Button button_tabTreatmentsTypes_edit;
        private System.Windows.Forms.Button button_tabTreatmentsTypes_new;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.TextBox treatmentstypes_nameTextBox;
        private System.Windows.Forms.BindingSource treatmentstypesBindingSource;
        private System.Windows.Forms.TextBox treatmentstypes_idTextBox;
        private System.Windows.Forms.BindingSource vTreatmentsTypesBindingSource;
        private System.Windows.Forms.Label treatmentstypes_idLabel;
        private System.Windows.Forms.Label treatmentstypes_nameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentstypesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}