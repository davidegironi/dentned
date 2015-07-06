namespace DG.DentneD.Forms
{
    partial class FormTaxes
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
            System.Windows.Forms.Label taxes_idLabel;
            System.Windows.Forms.Label taxes_nameLabel;
            System.Windows.Forms.Label taxes_rateLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaxes));
            this.panel_filters = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.vTaxesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabTaxes = new System.Windows.Forms.TabPage();
            this.panel_tabTaxes_data = new System.Windows.Forms.Panel();
            this.taxes_isdefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.taxesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taxes_rateTextBox = new System.Windows.Forms.TextBox();
            this.taxes_nameTextBox = new System.Windows.Forms.TextBox();
            this.taxes_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabTaxes_updates = new System.Windows.Forms.Panel();
            this.button_tabTaxes_cancel = new System.Windows.Forms.Button();
            this.button_tabTaxes_save = new System.Windows.Forms.Button();
            this.panel_tabTaxes_actions = new System.Windows.Forms.Panel();
            this.button_tabTaxes_delete = new System.Windows.Forms.Button();
            this.button_tabTaxes_edit = new System.Windows.Forms.Button();
            this.button_tabTaxes_new = new System.Windows.Forms.Button();
            this.panel_data = new System.Windows.Forms.Panel();
            this.taxesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isdefaultDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            taxes_idLabel = new System.Windows.Forms.Label();
            taxes_nameLabel = new System.Windows.Forms.Label();
            taxes_rateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTaxesBindingSource)).BeginInit();
            this.panel_list.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabTaxes.SuspendLayout();
            this.panel_tabTaxes_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingSource)).BeginInit();
            this.panel_tabTaxes_updates.SuspendLayout();
            this.panel_tabTaxes_actions.SuspendLayout();
            this.panel_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // taxes_idLabel
            // 
            taxes_idLabel.AutoSize = true;
            taxes_idLabel.Location = new System.Drawing.Point(9, 9);
            taxes_idLabel.Name = "taxes_idLabel";
            taxes_idLabel.Size = new System.Drawing.Size(19, 13);
            taxes_idLabel.TabIndex = 0;
            taxes_idLabel.Text = "Id:";
            // 
            // taxes_nameLabel
            // 
            taxes_nameLabel.AutoSize = true;
            taxes_nameLabel.Location = new System.Drawing.Point(9, 48);
            taxes_nameLabel.Name = "taxes_nameLabel";
            taxes_nameLabel.Size = new System.Drawing.Size(38, 13);
            taxes_nameLabel.TabIndex = 2;
            taxes_nameLabel.Text = "Name:";
            // 
            // taxes_rateLabel
            // 
            taxes_rateLabel.AutoSize = true;
            taxes_rateLabel.Location = new System.Drawing.Point(9, 87);
            taxes_rateLabel.Name = "taxes_rateLabel";
            taxes_rateLabel.Size = new System.Drawing.Size(33, 13);
            taxes_rateLabel.TabIndex = 4;
            taxes_rateLabel.Text = "Rate:";
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 7;
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
            this.taxesidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.isdefaultDataGridViewCheckBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vTaxesBindingSource;
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
            // vTaxesBindingSource
            // 
            this.vTaxesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VTaxes);
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 60);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(284, 502);
            this.panel_list.TabIndex = 8;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabTaxes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabTaxes
            // 
            this.tabPage_tabTaxes.Controls.Add(this.panel_tabTaxes_data);
            this.tabPage_tabTaxes.Controls.Add(this.panel_tabTaxes_updates);
            this.tabPage_tabTaxes.Controls.Add(this.panel_tabTaxes_actions);
            this.tabPage_tabTaxes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabTaxes.Name = "tabPage_tabTaxes";
            this.tabPage_tabTaxes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabTaxes.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabTaxes.TabIndex = 0;
            this.tabPage_tabTaxes.Text = "Tax";
            this.tabPage_tabTaxes.UseVisualStyleBackColor = true;
            // 
            // panel_tabTaxes_data
            // 
            this.panel_tabTaxes_data.Controls.Add(this.taxes_isdefaultCheckBox);
            this.panel_tabTaxes_data.Controls.Add(taxes_rateLabel);
            this.panel_tabTaxes_data.Controls.Add(this.taxes_rateTextBox);
            this.panel_tabTaxes_data.Controls.Add(taxes_nameLabel);
            this.panel_tabTaxes_data.Controls.Add(this.taxes_nameTextBox);
            this.panel_tabTaxes_data.Controls.Add(taxes_idLabel);
            this.panel_tabTaxes_data.Controls.Add(this.taxes_idTextBox);
            this.panel_tabTaxes_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabTaxes_data.Name = "panel_tabTaxes_data";
            this.panel_tabTaxes_data.Size = new System.Drawing.Size(480, 132);
            this.panel_tabTaxes_data.TabIndex = 2;
            // 
            // taxes_isdefaultCheckBox
            // 
            this.taxes_isdefaultCheckBox.AutoSize = true;
            this.taxes_isdefaultCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.taxesBindingSource, "taxes_isdefault", true));
            this.taxes_isdefaultCheckBox.Location = new System.Drawing.Point(128, 48);
            this.taxes_isdefaultCheckBox.Name = "taxes_isdefaultCheckBox";
            this.taxes_isdefaultCheckBox.Size = new System.Drawing.Size(71, 17);
            this.taxes_isdefaultCheckBox.TabIndex = 7;
            this.taxes_isdefaultCheckBox.Text = "Is Default";
            this.taxes_isdefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // taxesBindingSource
            // 
            this.taxesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.taxes);
            // 
            // taxes_rateTextBox
            // 
            this.taxes_rateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesBindingSource, "taxes_rate", true));
            this.taxes_rateTextBox.Location = new System.Drawing.Point(12, 103);
            this.taxes_rateTextBox.Name = "taxes_rateTextBox";
            this.taxes_rateTextBox.Size = new System.Drawing.Size(50, 20);
            this.taxes_rateTextBox.TabIndex = 5;
            // 
            // taxes_nameTextBox
            // 
            this.taxes_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesBindingSource, "taxes_name", true));
            this.taxes_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.taxes_nameTextBox.Name = "taxes_nameTextBox";
            this.taxes_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.taxes_nameTextBox.TabIndex = 3;
            // 
            // taxes_idTextBox
            // 
            this.taxes_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesBindingSource, "taxes_id", true));
            this.taxes_idTextBox.Enabled = false;
            this.taxes_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.taxes_idTextBox.Name = "taxes_idTextBox";
            this.taxes_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.taxes_idTextBox.TabIndex = 1;
            // 
            // panel_tabTaxes_updates
            // 
            this.panel_tabTaxes_updates.Controls.Add(this.button_tabTaxes_cancel);
            this.panel_tabTaxes_updates.Controls.Add(this.button_tabTaxes_save);
            this.panel_tabTaxes_updates.Location = new System.Drawing.Point(6, 177);
            this.panel_tabTaxes_updates.Name = "panel_tabTaxes_updates";
            this.panel_tabTaxes_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabTaxes_updates.TabIndex = 1;
            // 
            // button_tabTaxes_cancel
            // 
            this.button_tabTaxes_cancel.Location = new System.Drawing.Point(403, 3);
            this.button_tabTaxes_cancel.Name = "button_tabTaxes_cancel";
            this.button_tabTaxes_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxes_cancel.TabIndex = 2;
            this.button_tabTaxes_cancel.Text = "Cancel";
            this.button_tabTaxes_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabTaxes_save
            // 
            this.button_tabTaxes_save.Location = new System.Drawing.Point(322, 3);
            this.button_tabTaxes_save.Name = "button_tabTaxes_save";
            this.button_tabTaxes_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxes_save.TabIndex = 1;
            this.button_tabTaxes_save.Text = "Save";
            this.button_tabTaxes_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabTaxes_actions
            // 
            this.panel_tabTaxes_actions.Controls.Add(this.button_tabTaxes_delete);
            this.panel_tabTaxes_actions.Controls.Add(this.button_tabTaxes_edit);
            this.panel_tabTaxes_actions.Controls.Add(this.button_tabTaxes_new);
            this.panel_tabTaxes_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabTaxes_actions.Name = "panel_tabTaxes_actions";
            this.panel_tabTaxes_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabTaxes_actions.TabIndex = 0;
            // 
            // button_tabTaxes_delete
            // 
            this.button_tabTaxes_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabTaxes_delete.Name = "button_tabTaxes_delete";
            this.button_tabTaxes_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxes_delete.TabIndex = 2;
            this.button_tabTaxes_delete.Text = "Delete";
            this.button_tabTaxes_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabTaxes_edit
            // 
            this.button_tabTaxes_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabTaxes_edit.Name = "button_tabTaxes_edit";
            this.button_tabTaxes_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxes_edit.TabIndex = 1;
            this.button_tabTaxes_edit.Text = "Edit";
            this.button_tabTaxes_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabTaxes_new
            // 
            this.button_tabTaxes_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabTaxes_new.Name = "button_tabTaxes_new";
            this.button_tabTaxes_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxes_new.TabIndex = 0;
            this.button_tabTaxes_new.Text = "New";
            this.button_tabTaxes_new.UseVisualStyleBackColor = true;
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.tabControl_main);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(284, 0);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(500, 562);
            this.panel_data.TabIndex = 6;
            // 
            // taxesidDataGridViewTextBoxColumn
            // 
            this.taxesidDataGridViewTextBoxColumn.DataPropertyName = "taxes_id";
            this.taxesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.taxesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.taxesidDataGridViewTextBoxColumn.Name = "taxesidDataGridViewTextBoxColumn";
            this.taxesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.taxesidDataGridViewTextBoxColumn.Width = 80;
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
            // isdefaultDataGridViewCheckBoxColumn
            // 
            this.isdefaultDataGridViewCheckBoxColumn.DataPropertyName = "isdefault";
            this.isdefaultDataGridViewCheckBoxColumn.HeaderText = "D";
            this.isdefaultDataGridViewCheckBoxColumn.MinimumWidth = 22;
            this.isdefaultDataGridViewCheckBoxColumn.Name = "isdefaultDataGridViewCheckBoxColumn";
            this.isdefaultDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isdefaultDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.isdefaultDataGridViewCheckBoxColumn.Width = 50;
            // 
            // FormTaxes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormTaxes";
            this.Text = "Taxes";
            this.Load += new System.EventHandler(this.FormTaxes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTaxesBindingSource)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabTaxes.ResumeLayout(false);
            this.panel_tabTaxes_data.ResumeLayout(false);
            this.panel_tabTaxes_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingSource)).EndInit();
            this.panel_tabTaxes_updates.ResumeLayout(false);
            this.panel_tabTaxes_actions.ResumeLayout(false);
            this.panel_data.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filters;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabTaxes;
        private System.Windows.Forms.Panel panel_tabTaxes_data;
        private System.Windows.Forms.Panel panel_tabTaxes_updates;
        private System.Windows.Forms.Button button_tabTaxes_cancel;
        private System.Windows.Forms.Button button_tabTaxes_save;
        private System.Windows.Forms.Panel panel_tabTaxes_actions;
        private System.Windows.Forms.Button button_tabTaxes_delete;
        private System.Windows.Forms.Button button_tabTaxes_edit;
        private System.Windows.Forms.Button button_tabTaxes_new;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TextBox taxes_rateTextBox;
        private System.Windows.Forms.BindingSource taxesBindingSource;
        private System.Windows.Forms.TextBox taxes_nameTextBox;
        private System.Windows.Forms.TextBox taxes_idTextBox;
        private System.Windows.Forms.BindingSource vTaxesBindingSource;
        private System.Windows.Forms.CheckBox taxes_isdefaultCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isdefaultDataGridViewCheckBoxColumn;
    }
}