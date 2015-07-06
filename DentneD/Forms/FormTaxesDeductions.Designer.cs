namespace DG.DentneD.Forms
{
    partial class FormTaxesDeductions
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
            System.Windows.Forms.Label taxesdeductions_idLabel;
            System.Windows.Forms.Label taxesdeductions_nameLabel;
            System.Windows.Forms.Label taxesdeductions_rateLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaxesDeductions));
            this.panel_filters = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.vTaxesDeductionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabTaxesDeductions = new System.Windows.Forms.TabPage();
            this.panel_tabTaxesDeductions_data = new System.Windows.Forms.Panel();
            this.taxesdeductions_isdefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.taxesdeductionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taxesdeductions_rateTextBox = new System.Windows.Forms.TextBox();
            this.taxesdeductions_nameTextBox = new System.Windows.Forms.TextBox();
            this.taxesdeductions_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabTaxesDeductions_updates = new System.Windows.Forms.Panel();
            this.button_tabTaxesDeductions_cancel = new System.Windows.Forms.Button();
            this.button_tabTaxesDeductions_save = new System.Windows.Forms.Button();
            this.panel_tabTaxesDeductions_actions = new System.Windows.Forms.Panel();
            this.button_tabTaxesDeductions_delete = new System.Windows.Forms.Button();
            this.button_tabTaxesDeductions_edit = new System.Windows.Forms.Button();
            this.button_tabTaxesDeductions_new = new System.Windows.Forms.Button();
            this.panel_data = new System.Windows.Forms.Panel();
            this.taxesdeductionsidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isdefaultDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            taxesdeductions_idLabel = new System.Windows.Forms.Label();
            taxesdeductions_nameLabel = new System.Windows.Forms.Label();
            taxesdeductions_rateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTaxesDeductionsBindingSource)).BeginInit();
            this.panel_list.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabTaxesDeductions.SuspendLayout();
            this.panel_tabTaxesDeductions_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesdeductionsBindingSource)).BeginInit();
            this.panel_tabTaxesDeductions_updates.SuspendLayout();
            this.panel_tabTaxesDeductions_actions.SuspendLayout();
            this.panel_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // taxesdeductions_idLabel
            // 
            taxesdeductions_idLabel.AutoSize = true;
            taxesdeductions_idLabel.Location = new System.Drawing.Point(9, 9);
            taxesdeductions_idLabel.Name = "taxesdeductions_idLabel";
            taxesdeductions_idLabel.Size = new System.Drawing.Size(19, 13);
            taxesdeductions_idLabel.TabIndex = 0;
            taxesdeductions_idLabel.Text = "Id:";
            // 
            // taxesdeductions_nameLabel
            // 
            taxesdeductions_nameLabel.AutoSize = true;
            taxesdeductions_nameLabel.Location = new System.Drawing.Point(9, 48);
            taxesdeductions_nameLabel.Name = "taxesdeductions_nameLabel";
            taxesdeductions_nameLabel.Size = new System.Drawing.Size(38, 13);
            taxesdeductions_nameLabel.TabIndex = 2;
            taxesdeductions_nameLabel.Text = "Name:";
            // 
            // taxesdeductions_rateLabel
            // 
            taxesdeductions_rateLabel.AutoSize = true;
            taxesdeductions_rateLabel.Location = new System.Drawing.Point(9, 87);
            taxesdeductions_rateLabel.Name = "taxesdeductions_rateLabel";
            taxesdeductions_rateLabel.Size = new System.Drawing.Size(33, 13);
            taxesdeductions_rateLabel.TabIndex = 4;
            taxesdeductions_rateLabel.Text = "Rate:";
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
            this.taxesdeductionsidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.isdefaultDataGridViewCheckBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vTaxesDeductionsBindingSource;
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
            // vTaxesDeductionsBindingSource
            // 
            this.vTaxesDeductionsBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VTaxesDeductions);
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
            this.tabControl_main.Controls.Add(this.tabPage_tabTaxesDeductions);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabTaxesDeductions
            // 
            this.tabPage_tabTaxesDeductions.Controls.Add(this.panel_tabTaxesDeductions_data);
            this.tabPage_tabTaxesDeductions.Controls.Add(this.panel_tabTaxesDeductions_updates);
            this.tabPage_tabTaxesDeductions.Controls.Add(this.panel_tabTaxesDeductions_actions);
            this.tabPage_tabTaxesDeductions.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabTaxesDeductions.Name = "tabPage_tabTaxesDeductions";
            this.tabPage_tabTaxesDeductions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabTaxesDeductions.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabTaxesDeductions.TabIndex = 0;
            this.tabPage_tabTaxesDeductions.Text = "Tax Deduciton";
            this.tabPage_tabTaxesDeductions.UseVisualStyleBackColor = true;
            // 
            // panel_tabTaxesDeductions_data
            // 
            this.panel_tabTaxesDeductions_data.Controls.Add(this.taxesdeductions_isdefaultCheckBox);
            this.panel_tabTaxesDeductions_data.Controls.Add(taxesdeductions_rateLabel);
            this.panel_tabTaxesDeductions_data.Controls.Add(this.taxesdeductions_rateTextBox);
            this.panel_tabTaxesDeductions_data.Controls.Add(taxesdeductions_nameLabel);
            this.panel_tabTaxesDeductions_data.Controls.Add(this.taxesdeductions_nameTextBox);
            this.panel_tabTaxesDeductions_data.Controls.Add(taxesdeductions_idLabel);
            this.panel_tabTaxesDeductions_data.Controls.Add(this.taxesdeductions_idTextBox);
            this.panel_tabTaxesDeductions_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabTaxesDeductions_data.Name = "panel_tabTaxesDeductions_data";
            this.panel_tabTaxesDeductions_data.Size = new System.Drawing.Size(480, 132);
            this.panel_tabTaxesDeductions_data.TabIndex = 2;
            // 
            // taxesdeductions_isdefaultCheckBox
            // 
            this.taxesdeductions_isdefaultCheckBox.AutoSize = true;
            this.taxesdeductions_isdefaultCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.taxesdeductionsBindingSource, "taxesdeductions_isdefault", true));
            this.taxesdeductions_isdefaultCheckBox.Location = new System.Drawing.Point(128, 48);
            this.taxesdeductions_isdefaultCheckBox.Name = "taxesdeductions_isdefaultCheckBox";
            this.taxesdeductions_isdefaultCheckBox.Size = new System.Drawing.Size(71, 17);
            this.taxesdeductions_isdefaultCheckBox.TabIndex = 7;
            this.taxesdeductions_isdefaultCheckBox.Text = "Is Default";
            this.taxesdeductions_isdefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // taxesdeductionsBindingSource
            // 
            this.taxesdeductionsBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.taxesdeductions);
            // 
            // taxesdeductions_rateTextBox
            // 
            this.taxesdeductions_rateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesdeductionsBindingSource, "taxesdeductions_rate", true));
            this.taxesdeductions_rateTextBox.Location = new System.Drawing.Point(12, 103);
            this.taxesdeductions_rateTextBox.Name = "taxesdeductions_rateTextBox";
            this.taxesdeductions_rateTextBox.Size = new System.Drawing.Size(50, 20);
            this.taxesdeductions_rateTextBox.TabIndex = 5;
            // 
            // taxesdeductions_nameTextBox
            // 
            this.taxesdeductions_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesdeductionsBindingSource, "taxesdeductions_name", true));
            this.taxesdeductions_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.taxesdeductions_nameTextBox.Name = "taxesdeductions_nameTextBox";
            this.taxesdeductions_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.taxesdeductions_nameTextBox.TabIndex = 3;
            // 
            // taxesdeductions_idTextBox
            // 
            this.taxesdeductions_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesdeductionsBindingSource, "taxesdeductions_id", true));
            this.taxesdeductions_idTextBox.Enabled = false;
            this.taxesdeductions_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.taxesdeductions_idTextBox.Name = "taxesdeductions_idTextBox";
            this.taxesdeductions_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.taxesdeductions_idTextBox.TabIndex = 1;
            // 
            // panel_tabTaxesDeductions_updates
            // 
            this.panel_tabTaxesDeductions_updates.Controls.Add(this.button_tabTaxesDeductions_cancel);
            this.panel_tabTaxesDeductions_updates.Controls.Add(this.button_tabTaxesDeductions_save);
            this.panel_tabTaxesDeductions_updates.Location = new System.Drawing.Point(6, 177);
            this.panel_tabTaxesDeductions_updates.Name = "panel_tabTaxesDeductions_updates";
            this.panel_tabTaxesDeductions_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabTaxesDeductions_updates.TabIndex = 1;
            // 
            // button_tabTaxesDeductions_cancel
            // 
            this.button_tabTaxesDeductions_cancel.Location = new System.Drawing.Point(402, 4);
            this.button_tabTaxesDeductions_cancel.Name = "button_tabTaxesDeductions_cancel";
            this.button_tabTaxesDeductions_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxesDeductions_cancel.TabIndex = 2;
            this.button_tabTaxesDeductions_cancel.Text = "Cancel";
            this.button_tabTaxesDeductions_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabTaxesDeductions_save
            // 
            this.button_tabTaxesDeductions_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabTaxesDeductions_save.Name = "button_tabTaxesDeductions_save";
            this.button_tabTaxesDeductions_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxesDeductions_save.TabIndex = 1;
            this.button_tabTaxesDeductions_save.Text = "Save";
            this.button_tabTaxesDeductions_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabTaxesDeductions_actions
            // 
            this.panel_tabTaxesDeductions_actions.Controls.Add(this.button_tabTaxesDeductions_delete);
            this.panel_tabTaxesDeductions_actions.Controls.Add(this.button_tabTaxesDeductions_edit);
            this.panel_tabTaxesDeductions_actions.Controls.Add(this.button_tabTaxesDeductions_new);
            this.panel_tabTaxesDeductions_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabTaxesDeductions_actions.Name = "panel_tabTaxesDeductions_actions";
            this.panel_tabTaxesDeductions_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabTaxesDeductions_actions.TabIndex = 0;
            // 
            // button_tabTaxesDeductions_delete
            // 
            this.button_tabTaxesDeductions_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabTaxesDeductions_delete.Name = "button_tabTaxesDeductions_delete";
            this.button_tabTaxesDeductions_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxesDeductions_delete.TabIndex = 2;
            this.button_tabTaxesDeductions_delete.Text = "Delete";
            this.button_tabTaxesDeductions_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabTaxesDeductions_edit
            // 
            this.button_tabTaxesDeductions_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabTaxesDeductions_edit.Name = "button_tabTaxesDeductions_edit";
            this.button_tabTaxesDeductions_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxesDeductions_edit.TabIndex = 1;
            this.button_tabTaxesDeductions_edit.Text = "Edit";
            this.button_tabTaxesDeductions_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabTaxesDeductions_new
            // 
            this.button_tabTaxesDeductions_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabTaxesDeductions_new.Name = "button_tabTaxesDeductions_new";
            this.button_tabTaxesDeductions_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabTaxesDeductions_new.TabIndex = 0;
            this.button_tabTaxesDeductions_new.Text = "New";
            this.button_tabTaxesDeductions_new.UseVisualStyleBackColor = true;
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
            // taxesdeductionsidDataGridViewTextBoxColumn
            // 
            this.taxesdeductionsidDataGridViewTextBoxColumn.DataPropertyName = "taxesdeductions_id";
            this.taxesdeductionsidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.taxesdeductionsidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.taxesdeductionsidDataGridViewTextBoxColumn.Name = "taxesdeductionsidDataGridViewTextBoxColumn";
            this.taxesdeductionsidDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxesdeductionsidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.taxesdeductionsidDataGridViewTextBoxColumn.Width = 80;
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
            // FormTaxesDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormTaxesDeductions";
            this.Text = "Taxes Deductions";
            this.Load += new System.EventHandler(this.FormTaxesDeductions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTaxesDeductionsBindingSource)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabTaxesDeductions.ResumeLayout(false);
            this.panel_tabTaxesDeductions_data.ResumeLayout(false);
            this.panel_tabTaxesDeductions_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesdeductionsBindingSource)).EndInit();
            this.panel_tabTaxesDeductions_updates.ResumeLayout(false);
            this.panel_tabTaxesDeductions_actions.ResumeLayout(false);
            this.panel_data.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filters;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabTaxesDeductions;
        private System.Windows.Forms.Panel panel_tabTaxesDeductions_data;
        private System.Windows.Forms.Panel panel_tabTaxesDeductions_updates;
        private System.Windows.Forms.Button button_tabTaxesDeductions_cancel;
        private System.Windows.Forms.Button button_tabTaxesDeductions_save;
        private System.Windows.Forms.Panel panel_tabTaxesDeductions_actions;
        private System.Windows.Forms.Button button_tabTaxesDeductions_delete;
        private System.Windows.Forms.Button button_tabTaxesDeductions_edit;
        private System.Windows.Forms.Button button_tabTaxesDeductions_new;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TextBox taxesdeductions_rateTextBox;
        private System.Windows.Forms.BindingSource taxesdeductionsBindingSource;
        private System.Windows.Forms.TextBox taxesdeductions_nameTextBox;
        private System.Windows.Forms.TextBox taxesdeductions_idTextBox;
        private System.Windows.Forms.BindingSource vTaxesDeductionsBindingSource;
        private System.Windows.Forms.CheckBox taxesdeductions_isdefaultCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxesdeductionsidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isdefaultDataGridViewCheckBoxColumn;
    }
}