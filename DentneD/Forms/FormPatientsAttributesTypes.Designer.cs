namespace DG.DentneD.Forms
{
    partial class FormPatientsAttributesTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatientsAttributesTypes));
            this.panel_filters = new System.Windows.Forms.Panel();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientsattributestypesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.vPatientsAttributesTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.panel_tabPatientsAttributesTypes_data = new System.Windows.Forms.Panel();
            this.patientsattributestypes_nameLabel = new System.Windows.Forms.Label();
            this.patientsattributestypes_nameTextBox = new System.Windows.Forms.TextBox();
            this.patientsattributestypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientsattributestypes_idLabel = new System.Windows.Forms.Label();
            this.patientsattributestypes_idTextBox = new System.Windows.Forms.TextBox();
            this.button_tabPatientsAttributesTypes_delete = new System.Windows.Forms.Button();
            this.button_tabPatientsAttributesTypes_edit = new System.Windows.Forms.Button();
            this.button_tabPatientsAttributesTypes_new = new System.Windows.Forms.Button();
            this.button_tabPatientsAttributesTypes_cancel = new System.Windows.Forms.Button();
            this.button_tabPatientsAttributesTypes_save = new System.Windows.Forms.Button();
            this.panel_tabPatientsAttributesTypes_updates = new System.Windows.Forms.Panel();
            this.panel_tabPatientsAttributesTypes_actions = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabPatientsAttributesTypes = new System.Windows.Forms.TabPage();
            this.panel_data = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vPatientsAttributesTypesBindingSource)).BeginInit();
            this.panel_list.SuspendLayout();
            this.panel_tabPatientsAttributesTypes_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientsattributestypesBindingSource)).BeginInit();
            this.panel_tabPatientsAttributesTypes_updates.SuspendLayout();
            this.panel_tabPatientsAttributesTypes_actions.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabPatientsAttributesTypes.SuspendLayout();
            this.panel_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 13;
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
            // patientsattributestypesidDataGridViewTextBoxColumn
            // 
            this.patientsattributestypesidDataGridViewTextBoxColumn.DataPropertyName = "patientsattributestypes_id";
            this.patientsattributestypesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.patientsattributestypesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.patientsattributestypesidDataGridViewTextBoxColumn.Name = "patientsattributestypesidDataGridViewTextBoxColumn";
            this.patientsattributestypesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientsattributestypesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.patientsattributestypesidDataGridViewTextBoxColumn.Width = 80;
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
            this.patientsattributestypesidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vPatientsAttributesTypesBindingSource;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.MultiSelect = false;
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(284, 501);
            this.advancedDataGridView_main.TabIndex = 0;
            // 
            // vPatientsAttributesTypesBindingSource
            // 
            this.vPatientsAttributesTypesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VPatientsAttributesTypes);
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 60);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(284, 501);
            this.panel_list.TabIndex = 14;
            // 
            // panel_tabPatientsAttributesTypes_data
            // 
            this.panel_tabPatientsAttributesTypes_data.Controls.Add(this.patientsattributestypes_nameLabel);
            this.panel_tabPatientsAttributesTypes_data.Controls.Add(this.patientsattributestypes_nameTextBox);
            this.panel_tabPatientsAttributesTypes_data.Controls.Add(this.patientsattributestypes_idLabel);
            this.panel_tabPatientsAttributesTypes_data.Controls.Add(this.patientsattributestypes_idTextBox);
            this.panel_tabPatientsAttributesTypes_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabPatientsAttributesTypes_data.Name = "panel_tabPatientsAttributesTypes_data";
            this.panel_tabPatientsAttributesTypes_data.Size = new System.Drawing.Size(480, 94);
            this.panel_tabPatientsAttributesTypes_data.TabIndex = 2;
            // 
            // patientsattributestypes_nameLabel
            // 
            this.patientsattributestypes_nameLabel.AutoSize = true;
            this.patientsattributestypes_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.patientsattributestypes_nameLabel.Name = "patientsattributestypes_nameLabel";
            this.patientsattributestypes_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.patientsattributestypes_nameLabel.TabIndex = 2;
            this.patientsattributestypes_nameLabel.Text = "Name:";
            // 
            // patientsattributestypes_nameTextBox
            // 
            this.patientsattributestypes_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patientsattributestypesBindingSource, "patientsattributestypes_name", true));
            this.patientsattributestypes_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.patientsattributestypes_nameTextBox.Name = "patientsattributestypes_nameTextBox";
            this.patientsattributestypes_nameTextBox.Size = new System.Drawing.Size(200, 20);
            this.patientsattributestypes_nameTextBox.TabIndex = 3;
            // 
            // patientsattributestypesBindingSource
            // 
            this.patientsattributestypesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.patientsattributestypes);
            // 
            // patientsattributestypes_idLabel
            // 
            this.patientsattributestypes_idLabel.AutoSize = true;
            this.patientsattributestypes_idLabel.Location = new System.Drawing.Point(9, 9);
            this.patientsattributestypes_idLabel.Name = "patientsattributestypes_idLabel";
            this.patientsattributestypes_idLabel.Size = new System.Drawing.Size(19, 13);
            this.patientsattributestypes_idLabel.TabIndex = 0;
            this.patientsattributestypes_idLabel.Text = "Id:";
            // 
            // patientsattributestypes_idTextBox
            // 
            this.patientsattributestypes_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patientsattributestypesBindingSource, "patientsattributestypes_id", true));
            this.patientsattributestypes_idTextBox.Enabled = false;
            this.patientsattributestypes_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.patientsattributestypes_idTextBox.Name = "patientsattributestypes_idTextBox";
            this.patientsattributestypes_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.patientsattributestypes_idTextBox.TabIndex = 1;
            // 
            // button_tabPatientsAttributesTypes_delete
            // 
            this.button_tabPatientsAttributesTypes_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabPatientsAttributesTypes_delete.Name = "button_tabPatientsAttributesTypes_delete";
            this.button_tabPatientsAttributesTypes_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttributesTypes_delete.TabIndex = 2;
            this.button_tabPatientsAttributesTypes_delete.Text = "Delete";
            this.button_tabPatientsAttributesTypes_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabPatientsAttributesTypes_edit
            // 
            this.button_tabPatientsAttributesTypes_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabPatientsAttributesTypes_edit.Name = "button_tabPatientsAttributesTypes_edit";
            this.button_tabPatientsAttributesTypes_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttributesTypes_edit.TabIndex = 1;
            this.button_tabPatientsAttributesTypes_edit.Text = "Edit";
            this.button_tabPatientsAttributesTypes_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabPatientsAttributesTypes_new
            // 
            this.button_tabPatientsAttributesTypes_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabPatientsAttributesTypes_new.Name = "button_tabPatientsAttributesTypes_new";
            this.button_tabPatientsAttributesTypes_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttributesTypes_new.TabIndex = 0;
            this.button_tabPatientsAttributesTypes_new.Text = "New";
            this.button_tabPatientsAttributesTypes_new.UseVisualStyleBackColor = true;
            // 
            // button_tabPatientsAttributesTypes_cancel
            // 
            this.button_tabPatientsAttributesTypes_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabPatientsAttributesTypes_cancel.Name = "button_tabPatientsAttributesTypes_cancel";
            this.button_tabPatientsAttributesTypes_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttributesTypes_cancel.TabIndex = 2;
            this.button_tabPatientsAttributesTypes_cancel.Text = "Cancel";
            this.button_tabPatientsAttributesTypes_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabPatientsAttributesTypes_save
            // 
            this.button_tabPatientsAttributesTypes_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabPatientsAttributesTypes_save.Name = "button_tabPatientsAttributesTypes_save";
            this.button_tabPatientsAttributesTypes_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttributesTypes_save.TabIndex = 1;
            this.button_tabPatientsAttributesTypes_save.Text = "Save";
            this.button_tabPatientsAttributesTypes_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabPatientsAttributesTypes_updates
            // 
            this.panel_tabPatientsAttributesTypes_updates.Controls.Add(this.button_tabPatientsAttributesTypes_cancel);
            this.panel_tabPatientsAttributesTypes_updates.Controls.Add(this.button_tabPatientsAttributesTypes_save);
            this.panel_tabPatientsAttributesTypes_updates.Location = new System.Drawing.Point(6, 142);
            this.panel_tabPatientsAttributesTypes_updates.Name = "panel_tabPatientsAttributesTypes_updates";
            this.panel_tabPatientsAttributesTypes_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabPatientsAttributesTypes_updates.TabIndex = 1;
            // 
            // panel_tabPatientsAttributesTypes_actions
            // 
            this.panel_tabPatientsAttributesTypes_actions.Controls.Add(this.button_tabPatientsAttributesTypes_delete);
            this.panel_tabPatientsAttributesTypes_actions.Controls.Add(this.button_tabPatientsAttributesTypes_edit);
            this.panel_tabPatientsAttributesTypes_actions.Controls.Add(this.button_tabPatientsAttributesTypes_new);
            this.panel_tabPatientsAttributesTypes_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabPatientsAttributesTypes_actions.Name = "panel_tabPatientsAttributesTypes_actions";
            this.panel_tabPatientsAttributesTypes_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabPatientsAttributesTypes_actions.TabIndex = 0;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabPatientsAttributesTypes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 561);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabPatientsAttributesTypes
            // 
            this.tabPage_tabPatientsAttributesTypes.Controls.Add(this.panel_tabPatientsAttributesTypes_data);
            this.tabPage_tabPatientsAttributesTypes.Controls.Add(this.panel_tabPatientsAttributesTypes_updates);
            this.tabPage_tabPatientsAttributesTypes.Controls.Add(this.panel_tabPatientsAttributesTypes_actions);
            this.tabPage_tabPatientsAttributesTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabPatientsAttributesTypes.Name = "tabPage_tabPatientsAttributesTypes";
            this.tabPage_tabPatientsAttributesTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabPatientsAttributesTypes.Size = new System.Drawing.Size(492, 535);
            this.tabPage_tabPatientsAttributesTypes.TabIndex = 0;
            this.tabPage_tabPatientsAttributesTypes.Text = "Attribute Type";
            this.tabPage_tabPatientsAttributesTypes.UseVisualStyleBackColor = true;
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.tabControl_main);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(284, 0);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(500, 561);
            this.panel_data.TabIndex = 12;
            // 
            // FormPatientsAttributesTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormPatientsAttributesTypes";
            this.Text = "Patient Attribute Types";
            this.Load += new System.EventHandler(this.FormPatientsAttributesTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vPatientsAttributesTypesBindingSource)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.panel_tabPatientsAttributesTypes_data.ResumeLayout(false);
            this.panel_tabPatientsAttributesTypes_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientsattributestypesBindingSource)).EndInit();
            this.panel_tabPatientsAttributesTypes_updates.ResumeLayout(false);
            this.panel_tabPatientsAttributesTypes_actions.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabPatientsAttributesTypes.ResumeLayout(false);
            this.panel_data.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientsattributestypesidDataGridViewTextBoxColumn;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.BindingSource vPatientsAttributesTypesBindingSource;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.Panel panel_tabPatientsAttributesTypes_data;
        private System.Windows.Forms.BindingSource patientsattributestypesBindingSource;
        private System.Windows.Forms.Label patientsattributestypes_nameLabel;
        private System.Windows.Forms.TextBox patientsattributestypes_nameTextBox;
        private System.Windows.Forms.Label patientsattributestypes_idLabel;
        private System.Windows.Forms.TextBox patientsattributestypes_idTextBox;
        private System.Windows.Forms.Button button_tabPatientsAttributesTypes_delete;
        private System.Windows.Forms.Button button_tabPatientsAttributesTypes_edit;
        private System.Windows.Forms.Button button_tabPatientsAttributesTypes_new;
        private System.Windows.Forms.Button button_tabPatientsAttributesTypes_cancel;
        private System.Windows.Forms.Button button_tabPatientsAttributesTypes_save;
        private System.Windows.Forms.Panel panel_tabPatientsAttributesTypes_updates;
        private System.Windows.Forms.Panel panel_tabPatientsAttributesTypes_actions;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabPatientsAttributesTypes;
        private System.Windows.Forms.Panel panel_data;
    }
}