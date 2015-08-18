namespace DG.DentneD.Forms
{
    partial class FormEstimatesFooters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstimatesFooters));
            this.estimatesfooters_idLabel = new System.Windows.Forms.Label();
            this.estimatesfooters_nameLabel = new System.Windows.Forms.Label();
            this.estimatesfooters_doctextLabel = new System.Windows.Forms.Label();
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabEstimatesFooters = new System.Windows.Forms.TabPage();
            this.panel_tabEstimatesFooters_data = new System.Windows.Forms.Panel();
            this.estimatesfooters_isdefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.estimatesfootersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estimatesfooters_doctextTextBox = new System.Windows.Forms.TextBox();
            this.estimatesfooters_nameTextBox = new System.Windows.Forms.TextBox();
            this.estimatesfooters_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabEstimatesFooters_updates = new System.Windows.Forms.Panel();
            this.button_tabEstimatesFooters_cancel = new System.Windows.Forms.Button();
            this.button_tabEstimatesFooters_save = new System.Windows.Forms.Button();
            this.panel_tabEstimatesFooters_actions = new System.Windows.Forms.Panel();
            this.button_tabEstimatesFooters_delete = new System.Windows.Forms.Button();
            this.button_tabEstimatesFooters_edit = new System.Windows.Forms.Button();
            this.button_tabEstimatesFooters_new = new System.Windows.Forms.Button();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.estimatesfootersidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isdefaultDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vEstimatesFootersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.panel_filters = new System.Windows.Forms.Panel();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabEstimatesFooters.SuspendLayout();
            this.panel_tabEstimatesFooters_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimatesfootersBindingSource)).BeginInit();
            this.panel_tabEstimatesFooters_updates.SuspendLayout();
            this.panel_tabEstimatesFooters_actions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEstimatesFootersBindingSource)).BeginInit();
            this.panel_list.SuspendLayout();
            this.SuspendLayout();
            // 
            // estimatesfooters_idLabel
            // 
            this.estimatesfooters_idLabel.AutoSize = true;
            this.estimatesfooters_idLabel.Location = new System.Drawing.Point(9, 9);
            this.estimatesfooters_idLabel.Name = "estimatesfooters_idLabel";
            this.estimatesfooters_idLabel.Size = new System.Drawing.Size(19, 13);
            this.estimatesfooters_idLabel.TabIndex = 0;
            this.estimatesfooters_idLabel.Text = "Id:";
            // 
            // estimatesfooters_nameLabel
            // 
            this.estimatesfooters_nameLabel.AutoSize = true;
            this.estimatesfooters_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.estimatesfooters_nameLabel.Name = "estimatesfooters_nameLabel";
            this.estimatesfooters_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.estimatesfooters_nameLabel.TabIndex = 2;
            this.estimatesfooters_nameLabel.Text = "Name:";
            // 
            // estimatesfooters_doctextLabel
            // 
            this.estimatesfooters_doctextLabel.AutoSize = true;
            this.estimatesfooters_doctextLabel.Location = new System.Drawing.Point(9, 87);
            this.estimatesfooters_doctextLabel.Name = "estimatesfooters_doctextLabel";
            this.estimatesfooters_doctextLabel.Size = new System.Drawing.Size(54, 13);
            this.estimatesfooters_doctextLabel.TabIndex = 4;
            this.estimatesfooters_doctextLabel.Text = "Doc Text:";
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
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabEstimatesFooters);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabEstimatesFooters
            // 
            this.tabPage_tabEstimatesFooters.AutoScroll = true;
            this.tabPage_tabEstimatesFooters.Controls.Add(this.panel_tabEstimatesFooters_data);
            this.tabPage_tabEstimatesFooters.Controls.Add(this.panel_tabEstimatesFooters_updates);
            this.tabPage_tabEstimatesFooters.Controls.Add(this.panel_tabEstimatesFooters_actions);
            this.tabPage_tabEstimatesFooters.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabEstimatesFooters.Name = "tabPage_tabEstimatesFooters";
            this.tabPage_tabEstimatesFooters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabEstimatesFooters.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabEstimatesFooters.TabIndex = 0;
            this.tabPage_tabEstimatesFooters.Text = "Estimate Footer";
            this.tabPage_tabEstimatesFooters.UseVisualStyleBackColor = true;
            // 
            // panel_tabEstimatesFooters_data
            // 
            this.panel_tabEstimatesFooters_data.Controls.Add(this.estimatesfooters_isdefaultCheckBox);
            this.panel_tabEstimatesFooters_data.Controls.Add(this.estimatesfooters_doctextLabel);
            this.panel_tabEstimatesFooters_data.Controls.Add(this.estimatesfooters_doctextTextBox);
            this.panel_tabEstimatesFooters_data.Controls.Add(this.estimatesfooters_nameLabel);
            this.panel_tabEstimatesFooters_data.Controls.Add(this.estimatesfooters_nameTextBox);
            this.panel_tabEstimatesFooters_data.Controls.Add(this.estimatesfooters_idLabel);
            this.panel_tabEstimatesFooters_data.Controls.Add(this.estimatesfooters_idTextBox);
            this.panel_tabEstimatesFooters_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabEstimatesFooters_data.Name = "panel_tabEstimatesFooters_data";
            this.panel_tabEstimatesFooters_data.Size = new System.Drawing.Size(480, 191);
            this.panel_tabEstimatesFooters_data.TabIndex = 2;
            // 
            // estimatesfooters_isdefaultCheckBox
            // 
            this.estimatesfooters_isdefaultCheckBox.AutoSize = true;
            this.estimatesfooters_isdefaultCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.estimatesfootersBindingSource, "estimatesfooters_isdefault", true));
            this.estimatesfooters_isdefaultCheckBox.Location = new System.Drawing.Point(128, 48);
            this.estimatesfooters_isdefaultCheckBox.Name = "estimatesfooters_isdefaultCheckBox";
            this.estimatesfooters_isdefaultCheckBox.Size = new System.Drawing.Size(71, 17);
            this.estimatesfooters_isdefaultCheckBox.TabIndex = 7;
            this.estimatesfooters_isdefaultCheckBox.Text = "Is Default";
            this.estimatesfooters_isdefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // estimatesfootersBindingSource
            // 
            this.estimatesfootersBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.estimatesfooters);
            // 
            // estimatesfooters_doctextTextBox
            // 
            this.estimatesfooters_doctextTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesfootersBindingSource, "estimatesfooters_doctext", true));
            this.estimatesfooters_doctextTextBox.Location = new System.Drawing.Point(12, 103);
            this.estimatesfooters_doctextTextBox.Multiline = true;
            this.estimatesfooters_doctextTextBox.Name = "estimatesfooters_doctextTextBox";
            this.estimatesfooters_doctextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.estimatesfooters_doctextTextBox.Size = new System.Drawing.Size(430, 80);
            this.estimatesfooters_doctextTextBox.TabIndex = 5;
            this.estimatesfooters_doctextTextBox.WordWrap = false;
            // 
            // estimatesfooters_nameTextBox
            // 
            this.estimatesfooters_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesfootersBindingSource, "estimatesfooters_name", true));
            this.estimatesfooters_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.estimatesfooters_nameTextBox.Name = "estimatesfooters_nameTextBox";
            this.estimatesfooters_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.estimatesfooters_nameTextBox.TabIndex = 3;
            // 
            // estimatesfooters_idTextBox
            // 
            this.estimatesfooters_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estimatesfootersBindingSource, "estimatesfooters_id", true));
            this.estimatesfooters_idTextBox.Enabled = false;
            this.estimatesfooters_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.estimatesfooters_idTextBox.Name = "estimatesfooters_idTextBox";
            this.estimatesfooters_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.estimatesfooters_idTextBox.TabIndex = 1;
            // 
            // panel_tabEstimatesFooters_updates
            // 
            this.panel_tabEstimatesFooters_updates.Controls.Add(this.button_tabEstimatesFooters_cancel);
            this.panel_tabEstimatesFooters_updates.Controls.Add(this.button_tabEstimatesFooters_save);
            this.panel_tabEstimatesFooters_updates.Location = new System.Drawing.Point(6, 239);
            this.panel_tabEstimatesFooters_updates.Name = "panel_tabEstimatesFooters_updates";
            this.panel_tabEstimatesFooters_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabEstimatesFooters_updates.TabIndex = 1;
            // 
            // button_tabEstimatesFooters_cancel
            // 
            this.button_tabEstimatesFooters_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabEstimatesFooters_cancel.Name = "button_tabEstimatesFooters_cancel";
            this.button_tabEstimatesFooters_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesFooters_cancel.TabIndex = 2;
            this.button_tabEstimatesFooters_cancel.Text = "Cancel";
            this.button_tabEstimatesFooters_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabEstimatesFooters_save
            // 
            this.button_tabEstimatesFooters_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabEstimatesFooters_save.Name = "button_tabEstimatesFooters_save";
            this.button_tabEstimatesFooters_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesFooters_save.TabIndex = 1;
            this.button_tabEstimatesFooters_save.Text = "Save";
            this.button_tabEstimatesFooters_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabEstimatesFooters_actions
            // 
            this.panel_tabEstimatesFooters_actions.Controls.Add(this.button_tabEstimatesFooters_delete);
            this.panel_tabEstimatesFooters_actions.Controls.Add(this.button_tabEstimatesFooters_edit);
            this.panel_tabEstimatesFooters_actions.Controls.Add(this.button_tabEstimatesFooters_new);
            this.panel_tabEstimatesFooters_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabEstimatesFooters_actions.Name = "panel_tabEstimatesFooters_actions";
            this.panel_tabEstimatesFooters_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabEstimatesFooters_actions.TabIndex = 0;
            // 
            // button_tabEstimatesFooters_delete
            // 
            this.button_tabEstimatesFooters_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabEstimatesFooters_delete.Name = "button_tabEstimatesFooters_delete";
            this.button_tabEstimatesFooters_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesFooters_delete.TabIndex = 2;
            this.button_tabEstimatesFooters_delete.Text = "Delete";
            this.button_tabEstimatesFooters_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabEstimatesFooters_edit
            // 
            this.button_tabEstimatesFooters_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabEstimatesFooters_edit.Name = "button_tabEstimatesFooters_edit";
            this.button_tabEstimatesFooters_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesFooters_edit.TabIndex = 1;
            this.button_tabEstimatesFooters_edit.Text = "Edit";
            this.button_tabEstimatesFooters_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabEstimatesFooters_new
            // 
            this.button_tabEstimatesFooters_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabEstimatesFooters_new.Name = "button_tabEstimatesFooters_new";
            this.button_tabEstimatesFooters_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabEstimatesFooters_new.TabIndex = 0;
            this.button_tabEstimatesFooters_new.Text = "New";
            this.button_tabEstimatesFooters_new.UseVisualStyleBackColor = true;
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
            this.estimatesfootersidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.isdefaultDataGridViewCheckBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vEstimatesFootersBindingSource;
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
            // estimatesfootersidDataGridViewTextBoxColumn
            // 
            this.estimatesfootersidDataGridViewTextBoxColumn.DataPropertyName = "estimatesfooters_id";
            this.estimatesfootersidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.estimatesfootersidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.estimatesfootersidDataGridViewTextBoxColumn.Name = "estimatesfootersidDataGridViewTextBoxColumn";
            this.estimatesfootersidDataGridViewTextBoxColumn.ReadOnly = true;
            this.estimatesfootersidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.estimatesfootersidDataGridViewTextBoxColumn.Width = 80;
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
            // vEstimatesFootersBindingSource
            // 
            this.vEstimatesFootersBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VEstimatesFooters);
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
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 13;
            // 
            // FormEstimatesFooters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormEstimatesFooters";
            this.Text = "Estimates Footers";
            this.Load += new System.EventHandler(this.FormEstimatesFooters_Load);
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabEstimatesFooters.ResumeLayout(false);
            this.panel_tabEstimatesFooters_data.ResumeLayout(false);
            this.panel_tabEstimatesFooters_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimatesfootersBindingSource)).EndInit();
            this.panel_tabEstimatesFooters_updates.ResumeLayout(false);
            this.panel_tabEstimatesFooters_actions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEstimatesFootersBindingSource)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabEstimatesFooters;
        private System.Windows.Forms.Panel panel_tabEstimatesFooters_data;
        private System.Windows.Forms.Panel panel_tabEstimatesFooters_updates;
        private System.Windows.Forms.Button button_tabEstimatesFooters_cancel;
        private System.Windows.Forms.Button button_tabEstimatesFooters_save;
        private System.Windows.Forms.Panel panel_tabEstimatesFooters_actions;
        private System.Windows.Forms.Button button_tabEstimatesFooters_delete;
        private System.Windows.Forms.Button button_tabEstimatesFooters_edit;
        private System.Windows.Forms.Button button_tabEstimatesFooters_new;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.TextBox estimatesfooters_doctextTextBox;
        private System.Windows.Forms.BindingSource estimatesfootersBindingSource;
        private System.Windows.Forms.TextBox estimatesfooters_nameTextBox;
        private System.Windows.Forms.TextBox estimatesfooters_idTextBox;
        private System.Windows.Forms.BindingSource vEstimatesFootersBindingSource;
        private System.Windows.Forms.CheckBox estimatesfooters_isdefaultCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn estimatesfootersidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isdefaultDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Label estimatesfooters_idLabel;
        private System.Windows.Forms.Label estimatesfooters_nameLabel;
        private System.Windows.Forms.Label estimatesfooters_doctextLabel;
    }
}