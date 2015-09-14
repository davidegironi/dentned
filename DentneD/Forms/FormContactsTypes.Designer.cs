namespace DG.DentneD.Forms
{
    partial class FormContactsTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContactsTypes));
            this.contactstypes_idLabel = new System.Windows.Forms.Label();
            this.contactstypes_nameLabel = new System.Windows.Forms.Label();
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabContactsTypes = new System.Windows.Forms.TabPage();
            this.panel_tabContactsTypes_data = new System.Windows.Forms.Panel();
            this.contactstypes_nameTextBox = new System.Windows.Forms.TextBox();
            this.contactstypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactstypes_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabContactsTypes_updates = new System.Windows.Forms.Panel();
            this.button_tabContactsTypes_cancel = new System.Windows.Forms.Button();
            this.button_tabContactsTypes_save = new System.Windows.Forms.Button();
            this.panel_tabContactsTypes_actions = new System.Windows.Forms.Panel();
            this.button_tabContactsTypes_delete = new System.Windows.Forms.Button();
            this.button_tabContactsTypes_edit = new System.Windows.Forms.Button();
            this.button_tabContactsTypes_new = new System.Windows.Forms.Button();
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.contactstypesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vContactsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_filters = new System.Windows.Forms.Panel();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabContactsTypes.SuspendLayout();
            this.panel_tabContactsTypes_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactstypesBindingSource)).BeginInit();
            this.panel_tabContactsTypes_updates.SuspendLayout();
            this.panel_tabContactsTypes_actions.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vContactsTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // contactstypes_idLabel
            // 
            this.contactstypes_idLabel.AutoSize = true;
            this.contactstypes_idLabel.Location = new System.Drawing.Point(9, 9);
            this.contactstypes_idLabel.Name = "contactstypes_idLabel";
            this.contactstypes_idLabel.Size = new System.Drawing.Size(19, 13);
            this.contactstypes_idLabel.TabIndex = 0;
            this.contactstypes_idLabel.Text = "Id:";
            // 
            // contactstypes_nameLabel
            // 
            this.contactstypes_nameLabel.AutoSize = true;
            this.contactstypes_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.contactstypes_nameLabel.Name = "contactstypes_nameLabel";
            this.contactstypes_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.contactstypes_nameLabel.TabIndex = 2;
            this.contactstypes_nameLabel.Text = "Name:";
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
            this.tabControl_main.Controls.Add(this.tabPage_tabContactsTypes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabContactsTypes
            // 
            this.tabPage_tabContactsTypes.Controls.Add(this.panel_tabContactsTypes_data);
            this.tabPage_tabContactsTypes.Controls.Add(this.panel_tabContactsTypes_updates);
            this.tabPage_tabContactsTypes.Controls.Add(this.panel_tabContactsTypes_actions);
            this.tabPage_tabContactsTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabContactsTypes.Name = "tabPage_tabContactsTypes";
            this.tabPage_tabContactsTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabContactsTypes.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabContactsTypes.TabIndex = 0;
            this.tabPage_tabContactsTypes.Text = "Contact Type";
            this.tabPage_tabContactsTypes.UseVisualStyleBackColor = true;
            // 
            // panel_tabContactsTypes_data
            // 
            this.panel_tabContactsTypes_data.Controls.Add(this.contactstypes_nameLabel);
            this.panel_tabContactsTypes_data.Controls.Add(this.contactstypes_nameTextBox);
            this.panel_tabContactsTypes_data.Controls.Add(this.contactstypes_idLabel);
            this.panel_tabContactsTypes_data.Controls.Add(this.contactstypes_idTextBox);
            this.panel_tabContactsTypes_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabContactsTypes_data.Name = "panel_tabContactsTypes_data";
            this.panel_tabContactsTypes_data.Size = new System.Drawing.Size(480, 94);
            this.panel_tabContactsTypes_data.TabIndex = 2;
            // 
            // contactstypes_nameTextBox
            // 
            this.contactstypes_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactstypesBindingSource, "contactstypes_name", true));
            this.contactstypes_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.contactstypes_nameTextBox.Name = "contactstypes_nameTextBox";
            this.contactstypes_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactstypes_nameTextBox.TabIndex = 3;
            // 
            // contactstypesBindingSource
            // 
            this.contactstypesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.contactstypes);
            // 
            // contactstypes_idTextBox
            // 
            this.contactstypes_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactstypesBindingSource, "contactstypes_id", true));
            this.contactstypes_idTextBox.Enabled = false;
            this.contactstypes_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.contactstypes_idTextBox.Name = "contactstypes_idTextBox";
            this.contactstypes_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactstypes_idTextBox.TabIndex = 1;
            // 
            // panel_tabContactsTypes_updates
            // 
            this.panel_tabContactsTypes_updates.Controls.Add(this.button_tabContactsTypes_cancel);
            this.panel_tabContactsTypes_updates.Controls.Add(this.button_tabContactsTypes_save);
            this.panel_tabContactsTypes_updates.Location = new System.Drawing.Point(6, 142);
            this.panel_tabContactsTypes_updates.Name = "panel_tabContactsTypes_updates";
            this.panel_tabContactsTypes_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabContactsTypes_updates.TabIndex = 1;
            // 
            // button_tabContactsTypes_cancel
            // 
            this.button_tabContactsTypes_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabContactsTypes_cancel.Name = "button_tabContactsTypes_cancel";
            this.button_tabContactsTypes_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabContactsTypes_cancel.TabIndex = 2;
            this.button_tabContactsTypes_cancel.Text = "Cancel";
            this.button_tabContactsTypes_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabContactsTypes_save
            // 
            this.button_tabContactsTypes_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabContactsTypes_save.Name = "button_tabContactsTypes_save";
            this.button_tabContactsTypes_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabContactsTypes_save.TabIndex = 1;
            this.button_tabContactsTypes_save.Text = "Save";
            this.button_tabContactsTypes_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabContactsTypes_actions
            // 
            this.panel_tabContactsTypes_actions.Controls.Add(this.button_tabContactsTypes_delete);
            this.panel_tabContactsTypes_actions.Controls.Add(this.button_tabContactsTypes_edit);
            this.panel_tabContactsTypes_actions.Controls.Add(this.button_tabContactsTypes_new);
            this.panel_tabContactsTypes_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabContactsTypes_actions.Name = "panel_tabContactsTypes_actions";
            this.panel_tabContactsTypes_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabContactsTypes_actions.TabIndex = 0;
            // 
            // button_tabContactsTypes_delete
            // 
            this.button_tabContactsTypes_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabContactsTypes_delete.Name = "button_tabContactsTypes_delete";
            this.button_tabContactsTypes_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabContactsTypes_delete.TabIndex = 2;
            this.button_tabContactsTypes_delete.Text = "Delete";
            this.button_tabContactsTypes_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabContactsTypes_edit
            // 
            this.button_tabContactsTypes_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabContactsTypes_edit.Name = "button_tabContactsTypes_edit";
            this.button_tabContactsTypes_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabContactsTypes_edit.TabIndex = 1;
            this.button_tabContactsTypes_edit.Text = "Edit";
            this.button_tabContactsTypes_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabContactsTypes_new
            // 
            this.button_tabContactsTypes_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabContactsTypes_new.Name = "button_tabContactsTypes_new";
            this.button_tabContactsTypes_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabContactsTypes_new.TabIndex = 0;
            this.button_tabContactsTypes_new.Text = "New";
            this.button_tabContactsTypes_new.UseVisualStyleBackColor = true;
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
            this.contactstypesidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vContactsTypesBindingSource;
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
            // contactstypesidDataGridViewTextBoxColumn
            // 
            this.contactstypesidDataGridViewTextBoxColumn.DataPropertyName = "contactstypes_id";
            this.contactstypesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.contactstypesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.contactstypesidDataGridViewTextBoxColumn.Name = "contactstypesidDataGridViewTextBoxColumn";
            this.contactstypesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.contactstypesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.contactstypesidDataGridViewTextBoxColumn.Width = 80;
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
            // vContactsTypesBindingSource
            // 
            this.vContactsTypesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VContactsTypes);
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 10;
            // 
            // FormContactsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormContactsTypes";
            this.Text = "Contact Types";
            this.Load += new System.EventHandler(this.FormContactsTypes_Load);
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabContactsTypes.ResumeLayout(false);
            this.panel_tabContactsTypes_data.ResumeLayout(false);
            this.panel_tabContactsTypes_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactstypesBindingSource)).EndInit();
            this.panel_tabContactsTypes_updates.ResumeLayout(false);
            this.panel_tabContactsTypes_actions.ResumeLayout(false);
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vContactsTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabContactsTypes;
        private System.Windows.Forms.Panel panel_tabContactsTypes_data;
        private System.Windows.Forms.Panel panel_tabContactsTypes_updates;
        private System.Windows.Forms.Button button_tabContactsTypes_cancel;
        private System.Windows.Forms.Button button_tabContactsTypes_save;
        private System.Windows.Forms.Panel panel_tabContactsTypes_actions;
        private System.Windows.Forms.Button button_tabContactsTypes_delete;
        private System.Windows.Forms.Button button_tabContactsTypes_edit;
        private System.Windows.Forms.Button button_tabContactsTypes_new;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactstypesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vContactsTypesBindingSource;
        private System.Windows.Forms.TextBox contactstypes_nameTextBox;
        private System.Windows.Forms.BindingSource contactstypesBindingSource;
        private System.Windows.Forms.TextBox contactstypes_idTextBox;
        private System.Windows.Forms.Label contactstypes_idLabel;
        private System.Windows.Forms.Label contactstypes_nameLabel;
    }
}