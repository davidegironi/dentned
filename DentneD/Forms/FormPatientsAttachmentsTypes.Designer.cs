namespace DG.DentneD.Forms
{
    partial class FormPatientsAttachmentsTypes
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
            System.Windows.Forms.Label patientsattachmentstypes_idLabel;
            System.Windows.Forms.Label patientsattachmentstypes_nameLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatientsAttachmentsTypes));
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabPatientsAttachmentsTypes = new System.Windows.Forms.TabPage();
            this.panel_tabPatientsAttachmentsTypes_data = new System.Windows.Forms.Panel();
            this.patientsattachmentstypes_nameTextBox = new System.Windows.Forms.TextBox();
            this.patientsattachmentstypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientsattachmentstypes_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabPatientsAttachmentsTypes_updates = new System.Windows.Forms.Panel();
            this.button_tabPatientsAttachmentsTypes_cancel = new System.Windows.Forms.Button();
            this.button_tabPatientsAttachmentsTypes_save = new System.Windows.Forms.Button();
            this.panel_tabPatientsAttachmentsTypes_actions = new System.Windows.Forms.Panel();
            this.button_tabPatientsAttachmentsTypes_delete = new System.Windows.Forms.Button();
            this.button_tabPatientsAttachmentsTypes_edit = new System.Windows.Forms.Button();
            this.button_tabPatientsAttachmentsTypes_new = new System.Windows.Forms.Button();
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.patientsattachmentstypesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vPatientsAttachmentsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_filters = new System.Windows.Forms.Panel();
            patientsattachmentstypes_idLabel = new System.Windows.Forms.Label();
            patientsattachmentstypes_nameLabel = new System.Windows.Forms.Label();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabPatientsAttachmentsTypes.SuspendLayout();
            this.panel_tabPatientsAttachmentsTypes_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientsattachmentstypesBindingSource)).BeginInit();
            this.panel_tabPatientsAttachmentsTypes_updates.SuspendLayout();
            this.panel_tabPatientsAttachmentsTypes_actions.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vPatientsAttachmentsTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // patientsattachmentstypes_idLabel
            // 
            patientsattachmentstypes_idLabel.AutoSize = true;
            patientsattachmentstypes_idLabel.Location = new System.Drawing.Point(9, 9);
            patientsattachmentstypes_idLabel.Name = "patientsattachmentstypes_idLabel";
            patientsattachmentstypes_idLabel.Size = new System.Drawing.Size(19, 13);
            patientsattachmentstypes_idLabel.TabIndex = 0;
            patientsattachmentstypes_idLabel.Text = "Id:";
            // 
            // patientsattachmentstypes_nameLabel
            // 
            patientsattachmentstypes_nameLabel.AutoSize = true;
            patientsattachmentstypes_nameLabel.Location = new System.Drawing.Point(9, 48);
            patientsattachmentstypes_nameLabel.Name = "patientsattachmentstypes_nameLabel";
            patientsattachmentstypes_nameLabel.Size = new System.Drawing.Size(38, 13);
            patientsattachmentstypes_nameLabel.TabIndex = 2;
            patientsattachmentstypes_nameLabel.Text = "Name:";
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
            this.tabControl_main.Controls.Add(this.tabPage_tabPatientsAttachmentsTypes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabPatientsAttachmentsTypes
            // 
            this.tabPage_tabPatientsAttachmentsTypes.Controls.Add(this.panel_tabPatientsAttachmentsTypes_data);
            this.tabPage_tabPatientsAttachmentsTypes.Controls.Add(this.panel_tabPatientsAttachmentsTypes_updates);
            this.tabPage_tabPatientsAttachmentsTypes.Controls.Add(this.panel_tabPatientsAttachmentsTypes_actions);
            this.tabPage_tabPatientsAttachmentsTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabPatientsAttachmentsTypes.Name = "tabPage_tabPatientsAttachmentsTypes";
            this.tabPage_tabPatientsAttachmentsTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabPatientsAttachmentsTypes.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabPatientsAttachmentsTypes.TabIndex = 0;
            this.tabPage_tabPatientsAttachmentsTypes.Text = "Attachment Type";
            this.tabPage_tabPatientsAttachmentsTypes.UseVisualStyleBackColor = true;
            // 
            // panel_tabPatientsAttachmentsTypes_data
            // 
            this.panel_tabPatientsAttachmentsTypes_data.Controls.Add(patientsattachmentstypes_nameLabel);
            this.panel_tabPatientsAttachmentsTypes_data.Controls.Add(this.patientsattachmentstypes_nameTextBox);
            this.panel_tabPatientsAttachmentsTypes_data.Controls.Add(patientsattachmentstypes_idLabel);
            this.panel_tabPatientsAttachmentsTypes_data.Controls.Add(this.patientsattachmentstypes_idTextBox);
            this.panel_tabPatientsAttachmentsTypes_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabPatientsAttachmentsTypes_data.Name = "panel_tabPatientsAttachmentsTypes_data";
            this.panel_tabPatientsAttachmentsTypes_data.Size = new System.Drawing.Size(480, 91);
            this.panel_tabPatientsAttachmentsTypes_data.TabIndex = 2;
            // 
            // patientsattachmentstypes_nameTextBox
            // 
            this.patientsattachmentstypes_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patientsattachmentstypesBindingSource, "patientsattachmentstypes_name", true));
            this.patientsattachmentstypes_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.patientsattachmentstypes_nameTextBox.Name = "patientsattachmentstypes_nameTextBox";
            this.patientsattachmentstypes_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.patientsattachmentstypes_nameTextBox.TabIndex = 3;
            // 
            // patientsattachmentstypesBindingSource
            // 
            this.patientsattachmentstypesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.patientsattachmentstypes);
            // 
            // patientsattachmentstypes_idTextBox
            // 
            this.patientsattachmentstypes_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patientsattachmentstypesBindingSource, "patientsattachmentstypes_id", true));
            this.patientsattachmentstypes_idTextBox.Enabled = false;
            this.patientsattachmentstypes_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.patientsattachmentstypes_idTextBox.Name = "patientsattachmentstypes_idTextBox";
            this.patientsattachmentstypes_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.patientsattachmentstypes_idTextBox.TabIndex = 1;
            // 
            // panel_tabPatientsAttachmentsTypes_updates
            // 
            this.panel_tabPatientsAttachmentsTypes_updates.Controls.Add(this.button_tabPatientsAttachmentsTypes_cancel);
            this.panel_tabPatientsAttachmentsTypes_updates.Controls.Add(this.button_tabPatientsAttachmentsTypes_save);
            this.panel_tabPatientsAttachmentsTypes_updates.Location = new System.Drawing.Point(6, 139);
            this.panel_tabPatientsAttachmentsTypes_updates.Name = "panel_tabPatientsAttachmentsTypes_updates";
            this.panel_tabPatientsAttachmentsTypes_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabPatientsAttachmentsTypes_updates.TabIndex = 1;
            // 
            // button_tabPatientsAttachmentsTypes_cancel
            // 
            this.button_tabPatientsAttachmentsTypes_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabPatientsAttachmentsTypes_cancel.Name = "button_tabPatientsAttachmentsTypes_cancel";
            this.button_tabPatientsAttachmentsTypes_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttachmentsTypes_cancel.TabIndex = 2;
            this.button_tabPatientsAttachmentsTypes_cancel.Text = "Cancel";
            this.button_tabPatientsAttachmentsTypes_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabPatientsAttachmentsTypes_save
            // 
            this.button_tabPatientsAttachmentsTypes_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabPatientsAttachmentsTypes_save.Name = "button_tabPatientsAttachmentsTypes_save";
            this.button_tabPatientsAttachmentsTypes_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttachmentsTypes_save.TabIndex = 1;
            this.button_tabPatientsAttachmentsTypes_save.Text = "Save";
            this.button_tabPatientsAttachmentsTypes_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabPatientsAttachmentsTypes_actions
            // 
            this.panel_tabPatientsAttachmentsTypes_actions.Controls.Add(this.button_tabPatientsAttachmentsTypes_delete);
            this.panel_tabPatientsAttachmentsTypes_actions.Controls.Add(this.button_tabPatientsAttachmentsTypes_edit);
            this.panel_tabPatientsAttachmentsTypes_actions.Controls.Add(this.button_tabPatientsAttachmentsTypes_new);
            this.panel_tabPatientsAttachmentsTypes_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabPatientsAttachmentsTypes_actions.Name = "panel_tabPatientsAttachmentsTypes_actions";
            this.panel_tabPatientsAttachmentsTypes_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabPatientsAttachmentsTypes_actions.TabIndex = 0;
            // 
            // button_tabPatientsAttachmentsTypes_delete
            // 
            this.button_tabPatientsAttachmentsTypes_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabPatientsAttachmentsTypes_delete.Name = "button_tabPatientsAttachmentsTypes_delete";
            this.button_tabPatientsAttachmentsTypes_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttachmentsTypes_delete.TabIndex = 2;
            this.button_tabPatientsAttachmentsTypes_delete.Text = "Delete";
            this.button_tabPatientsAttachmentsTypes_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabPatientsAttachmentsTypes_edit
            // 
            this.button_tabPatientsAttachmentsTypes_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabPatientsAttachmentsTypes_edit.Name = "button_tabPatientsAttachmentsTypes_edit";
            this.button_tabPatientsAttachmentsTypes_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttachmentsTypes_edit.TabIndex = 1;
            this.button_tabPatientsAttachmentsTypes_edit.Text = "Edit";
            this.button_tabPatientsAttachmentsTypes_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabPatientsAttachmentsTypes_new
            // 
            this.button_tabPatientsAttachmentsTypes_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabPatientsAttachmentsTypes_new.Name = "button_tabPatientsAttachmentsTypes_new";
            this.button_tabPatientsAttachmentsTypes_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabPatientsAttachmentsTypes_new.TabIndex = 0;
            this.button_tabPatientsAttachmentsTypes_new.Text = "New";
            this.button_tabPatientsAttachmentsTypes_new.UseVisualStyleBackColor = true;
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
            this.patientsattachmentstypesidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vPatientsAttachmentsTypesBindingSource;
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
            // patientsattachmentstypesidDataGridViewTextBoxColumn
            // 
            this.patientsattachmentstypesidDataGridViewTextBoxColumn.DataPropertyName = "patientsattachmentstypes_id";
            this.patientsattachmentstypesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.patientsattachmentstypesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.patientsattachmentstypesidDataGridViewTextBoxColumn.Name = "patientsattachmentstypesidDataGridViewTextBoxColumn";
            this.patientsattachmentstypesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientsattachmentstypesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.patientsattachmentstypesidDataGridViewTextBoxColumn.Width = 80;
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
            // vPatientsAttachmentsTypesBindingSource
            // 
            this.vPatientsAttachmentsTypesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VPatientsAttachmentsTypes);
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 10;
            // 
            // FormPatientsAttachmentsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormPatientsAttachmentsTypes";
            this.Text = "Patient Attachment Types";
            this.Load += new System.EventHandler(this.FormPatientsAttachmentsTypes_Load);
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabPatientsAttachmentsTypes.ResumeLayout(false);
            this.panel_tabPatientsAttachmentsTypes_data.ResumeLayout(false);
            this.panel_tabPatientsAttachmentsTypes_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientsattachmentstypesBindingSource)).EndInit();
            this.panel_tabPatientsAttachmentsTypes_updates.ResumeLayout(false);
            this.panel_tabPatientsAttachmentsTypes_actions.ResumeLayout(false);
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vPatientsAttachmentsTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabPatientsAttachmentsTypes;
        private System.Windows.Forms.Panel panel_tabPatientsAttachmentsTypes_data;
        private System.Windows.Forms.Panel panel_tabPatientsAttachmentsTypes_updates;
        private System.Windows.Forms.Button button_tabPatientsAttachmentsTypes_cancel;
        private System.Windows.Forms.Button button_tabPatientsAttachmentsTypes_save;
        private System.Windows.Forms.Panel panel_tabPatientsAttachmentsTypes_actions;
        private System.Windows.Forms.Button button_tabPatientsAttachmentsTypes_delete;
        private System.Windows.Forms.Button button_tabPatientsAttachmentsTypes_edit;
        private System.Windows.Forms.Button button_tabPatientsAttachmentsTypes_new;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.BindingSource vPatientsAttachmentsTypesBindingSource;
        private System.Windows.Forms.TextBox patientsattachmentstypes_nameTextBox;
        private System.Windows.Forms.BindingSource patientsattachmentstypesBindingSource;
        private System.Windows.Forms.TextBox patientsattachmentstypes_idTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientsattachmentstypesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}