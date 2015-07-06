namespace DG.DentneD.Forms
{
    partial class FormPaymentsTypes
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
            System.Windows.Forms.Label paymentstypes_idLabel;
            System.Windows.Forms.Label paymentstypes_nameLabel;
            System.Windows.Forms.Label paymentstypes_doctextLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaymentsTypes));
            this.button_tabPaymentsTypes_delete = new System.Windows.Forms.Button();
            this.button_tabPaymentsTypes_edit = new System.Windows.Forms.Button();
            this.button_tabPaymentsTypes_new = new System.Windows.Forms.Button();
            this.panel_tabPaymentsTypes_actions = new System.Windows.Forms.Panel();
            this.button_tabPaymentsTypes_cancel = new System.Windows.Forms.Button();
            this.button_tabPaymentsTypes_save = new System.Windows.Forms.Button();
            this.panel_tabPaymentsTypes_updates = new System.Windows.Forms.Panel();
            this.panel_tabPaymentsTypes_data = new System.Windows.Forms.Panel();
            this.paymentstypes_isdefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.paymentstypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentstypes_doctextTextBox = new System.Windows.Forms.TextBox();
            this.paymentstypes_nameTextBox = new System.Windows.Forms.TextBox();
            this.paymentstypes_idTextBox = new System.Windows.Forms.TextBox();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabPaymentsTypes = new System.Windows.Forms.TabPage();
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.vPaymentsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_filters = new System.Windows.Forms.Panel();
            this.panel_data = new System.Windows.Forms.Panel();
            this.paymentstypesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isdefaultDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            paymentstypes_idLabel = new System.Windows.Forms.Label();
            paymentstypes_nameLabel = new System.Windows.Forms.Label();
            paymentstypes_doctextLabel = new System.Windows.Forms.Label();
            this.panel_tabPaymentsTypes_actions.SuspendLayout();
            this.panel_tabPaymentsTypes_updates.SuspendLayout();
            this.panel_tabPaymentsTypes_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentstypesBindingSource)).BeginInit();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabPaymentsTypes.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vPaymentsTypesBindingSource)).BeginInit();
            this.panel_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // paymentstypes_idLabel
            // 
            paymentstypes_idLabel.AutoSize = true;
            paymentstypes_idLabel.Location = new System.Drawing.Point(9, 9);
            paymentstypes_idLabel.Name = "paymentstypes_idLabel";
            paymentstypes_idLabel.Size = new System.Drawing.Size(19, 13);
            paymentstypes_idLabel.TabIndex = 0;
            paymentstypes_idLabel.Text = "Id:";
            // 
            // paymentstypes_nameLabel
            // 
            paymentstypes_nameLabel.AutoSize = true;
            paymentstypes_nameLabel.Location = new System.Drawing.Point(9, 48);
            paymentstypes_nameLabel.Name = "paymentstypes_nameLabel";
            paymentstypes_nameLabel.Size = new System.Drawing.Size(38, 13);
            paymentstypes_nameLabel.TabIndex = 2;
            paymentstypes_nameLabel.Text = "Name:";
            // 
            // paymentstypes_doctextLabel
            // 
            paymentstypes_doctextLabel.AutoSize = true;
            paymentstypes_doctextLabel.Location = new System.Drawing.Point(9, 87);
            paymentstypes_doctextLabel.Name = "paymentstypes_doctextLabel";
            paymentstypes_doctextLabel.Size = new System.Drawing.Size(54, 13);
            paymentstypes_doctextLabel.TabIndex = 4;
            paymentstypes_doctextLabel.Text = "Doc Text:";
            // 
            // button_tabPaymentsTypes_delete
            // 
            this.button_tabPaymentsTypes_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabPaymentsTypes_delete.Name = "button_tabPaymentsTypes_delete";
            this.button_tabPaymentsTypes_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabPaymentsTypes_delete.TabIndex = 2;
            this.button_tabPaymentsTypes_delete.Text = "Delete";
            this.button_tabPaymentsTypes_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabPaymentsTypes_edit
            // 
            this.button_tabPaymentsTypes_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabPaymentsTypes_edit.Name = "button_tabPaymentsTypes_edit";
            this.button_tabPaymentsTypes_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabPaymentsTypes_edit.TabIndex = 1;
            this.button_tabPaymentsTypes_edit.Text = "Edit";
            this.button_tabPaymentsTypes_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabPaymentsTypes_new
            // 
            this.button_tabPaymentsTypes_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabPaymentsTypes_new.Name = "button_tabPaymentsTypes_new";
            this.button_tabPaymentsTypes_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabPaymentsTypes_new.TabIndex = 0;
            this.button_tabPaymentsTypes_new.Text = "New";
            this.button_tabPaymentsTypes_new.UseVisualStyleBackColor = true;
            // 
            // panel_tabPaymentsTypes_actions
            // 
            this.panel_tabPaymentsTypes_actions.Controls.Add(this.button_tabPaymentsTypes_delete);
            this.panel_tabPaymentsTypes_actions.Controls.Add(this.button_tabPaymentsTypes_edit);
            this.panel_tabPaymentsTypes_actions.Controls.Add(this.button_tabPaymentsTypes_new);
            this.panel_tabPaymentsTypes_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabPaymentsTypes_actions.Name = "panel_tabPaymentsTypes_actions";
            this.panel_tabPaymentsTypes_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabPaymentsTypes_actions.TabIndex = 0;
            // 
            // button_tabPaymentsTypes_cancel
            // 
            this.button_tabPaymentsTypes_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabPaymentsTypes_cancel.Name = "button_tabPaymentsTypes_cancel";
            this.button_tabPaymentsTypes_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabPaymentsTypes_cancel.TabIndex = 2;
            this.button_tabPaymentsTypes_cancel.Text = "Cancel";
            this.button_tabPaymentsTypes_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabPaymentsTypes_save
            // 
            this.button_tabPaymentsTypes_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabPaymentsTypes_save.Name = "button_tabPaymentsTypes_save";
            this.button_tabPaymentsTypes_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabPaymentsTypes_save.TabIndex = 1;
            this.button_tabPaymentsTypes_save.Text = "Save";
            this.button_tabPaymentsTypes_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabPaymentsTypes_updates
            // 
            this.panel_tabPaymentsTypes_updates.Controls.Add(this.button_tabPaymentsTypes_cancel);
            this.panel_tabPaymentsTypes_updates.Controls.Add(this.button_tabPaymentsTypes_save);
            this.panel_tabPaymentsTypes_updates.Location = new System.Drawing.Point(6, 239);
            this.panel_tabPaymentsTypes_updates.Name = "panel_tabPaymentsTypes_updates";
            this.panel_tabPaymentsTypes_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabPaymentsTypes_updates.TabIndex = 1;
            // 
            // panel_tabPaymentsTypes_data
            // 
            this.panel_tabPaymentsTypes_data.Controls.Add(this.paymentstypes_isdefaultCheckBox);
            this.panel_tabPaymentsTypes_data.Controls.Add(paymentstypes_doctextLabel);
            this.panel_tabPaymentsTypes_data.Controls.Add(this.paymentstypes_doctextTextBox);
            this.panel_tabPaymentsTypes_data.Controls.Add(paymentstypes_nameLabel);
            this.panel_tabPaymentsTypes_data.Controls.Add(this.paymentstypes_nameTextBox);
            this.panel_tabPaymentsTypes_data.Controls.Add(paymentstypes_idLabel);
            this.panel_tabPaymentsTypes_data.Controls.Add(this.paymentstypes_idTextBox);
            this.panel_tabPaymentsTypes_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabPaymentsTypes_data.Name = "panel_tabPaymentsTypes_data";
            this.panel_tabPaymentsTypes_data.Size = new System.Drawing.Size(478, 191);
            this.panel_tabPaymentsTypes_data.TabIndex = 2;
            // 
            // paymentstypes_isdefaultCheckBox
            // 
            this.paymentstypes_isdefaultCheckBox.AutoSize = true;
            this.paymentstypes_isdefaultCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.paymentstypesBindingSource, "paymentstypes_isdefault", true));
            this.paymentstypes_isdefaultCheckBox.Location = new System.Drawing.Point(128, 48);
            this.paymentstypes_isdefaultCheckBox.Name = "paymentstypes_isdefaultCheckBox";
            this.paymentstypes_isdefaultCheckBox.Size = new System.Drawing.Size(71, 17);
            this.paymentstypes_isdefaultCheckBox.TabIndex = 7;
            this.paymentstypes_isdefaultCheckBox.Text = "Is Default";
            this.paymentstypes_isdefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // paymentstypesBindingSource
            // 
            this.paymentstypesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.paymentstypes);
            // 
            // paymentstypes_doctextTextBox
            // 
            this.paymentstypes_doctextTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.paymentstypesBindingSource, "paymentstypes_doctext", true));
            this.paymentstypes_doctextTextBox.Location = new System.Drawing.Point(12, 103);
            this.paymentstypes_doctextTextBox.Multiline = true;
            this.paymentstypes_doctextTextBox.Name = "paymentstypes_doctextTextBox";
            this.paymentstypes_doctextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.paymentstypes_doctextTextBox.Size = new System.Drawing.Size(430, 80);
            this.paymentstypes_doctextTextBox.TabIndex = 5;
            this.paymentstypes_doctextTextBox.WordWrap = false;
            // 
            // paymentstypes_nameTextBox
            // 
            this.paymentstypes_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.paymentstypesBindingSource, "paymentstypes_name", true));
            this.paymentstypes_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.paymentstypes_nameTextBox.Name = "paymentstypes_nameTextBox";
            this.paymentstypes_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.paymentstypes_nameTextBox.TabIndex = 3;
            // 
            // paymentstypes_idTextBox
            // 
            this.paymentstypes_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.paymentstypesBindingSource, "paymentstypes_id", true));
            this.paymentstypes_idTextBox.Enabled = false;
            this.paymentstypes_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.paymentstypes_idTextBox.Name = "paymentstypes_idTextBox";
            this.paymentstypes_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.paymentstypes_idTextBox.TabIndex = 1;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabPaymentsTypes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabPaymentsTypes
            // 
            this.tabPage_tabPaymentsTypes.Controls.Add(this.panel_tabPaymentsTypes_data);
            this.tabPage_tabPaymentsTypes.Controls.Add(this.panel_tabPaymentsTypes_updates);
            this.tabPage_tabPaymentsTypes.Controls.Add(this.panel_tabPaymentsTypes_actions);
            this.tabPage_tabPaymentsTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabPaymentsTypes.Name = "tabPage_tabPaymentsTypes";
            this.tabPage_tabPaymentsTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabPaymentsTypes.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabPaymentsTypes.TabIndex = 0;
            this.tabPage_tabPaymentsTypes.Text = "Payment Type";
            this.tabPage_tabPaymentsTypes.UseVisualStyleBackColor = true;
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
            this.paymentstypesidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.isdefaultDataGridViewCheckBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vPaymentsTypesBindingSource;
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
            // vPaymentsTypesBindingSource
            // 
            this.vPaymentsTypesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VPaymentsTypes);
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 10;
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
            // paymentstypesidDataGridViewTextBoxColumn
            // 
            this.paymentstypesidDataGridViewTextBoxColumn.DataPropertyName = "paymentstypes_id";
            this.paymentstypesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.paymentstypesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.paymentstypesidDataGridViewTextBoxColumn.Name = "paymentstypesidDataGridViewTextBoxColumn";
            this.paymentstypesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentstypesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.paymentstypesidDataGridViewTextBoxColumn.Width = 80;
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
            // FormPaymentsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormPaymentsTypes";
            this.Text = "Payment Types";
            this.Load += new System.EventHandler(this.FormPaymentsTypes_Load);
            this.panel_tabPaymentsTypes_actions.ResumeLayout(false);
            this.panel_tabPaymentsTypes_updates.ResumeLayout(false);
            this.panel_tabPaymentsTypes_data.ResumeLayout(false);
            this.panel_tabPaymentsTypes_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentstypesBindingSource)).EndInit();
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabPaymentsTypes.ResumeLayout(false);
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vPaymentsTypesBindingSource)).EndInit();
            this.panel_data.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_tabPaymentsTypes_delete;
        private System.Windows.Forms.Button button_tabPaymentsTypes_edit;
        private System.Windows.Forms.Button button_tabPaymentsTypes_new;
        private System.Windows.Forms.Panel panel_tabPaymentsTypes_actions;
        private System.Windows.Forms.Button button_tabPaymentsTypes_cancel;
        private System.Windows.Forms.Button button_tabPaymentsTypes_save;
        private System.Windows.Forms.Panel panel_tabPaymentsTypes_updates;
        private System.Windows.Forms.Panel panel_tabPaymentsTypes_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabPaymentsTypes;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TextBox paymentstypes_doctextTextBox;
        private System.Windows.Forms.BindingSource paymentstypesBindingSource;
        private System.Windows.Forms.TextBox paymentstypes_nameTextBox;
        private System.Windows.Forms.TextBox paymentstypes_idTextBox;
        private System.Windows.Forms.BindingSource vPaymentsTypesBindingSource;
        private System.Windows.Forms.CheckBox paymentstypes_isdefaultCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentstypesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isdefaultDataGridViewCheckBoxColumn;
    }
}