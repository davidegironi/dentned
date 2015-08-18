namespace DG.DentneD.Forms
{
    partial class FormDoctors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoctors));
            this.doctors_idLabel = new System.Windows.Forms.Label();
            this.doctors_nameLabel = new System.Windows.Forms.Label();
            this.doctors_surnameLabel = new System.Windows.Forms.Label();
            this.doctors_doctextLabel = new System.Windows.Forms.Label();
            this.tabPage_tabDoctors = new System.Windows.Forms.TabPage();
            this.panel_tabDoctors_data = new System.Windows.Forms.Panel();
            this.doctors_doctextTextBox = new System.Windows.Forms.TextBox();
            this.doctorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doctors_surnameTextBox = new System.Windows.Forms.TextBox();
            this.doctors_nameTextBox = new System.Windows.Forms.TextBox();
            this.doctors_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabDoctors_updates = new System.Windows.Forms.Panel();
            this.button_tabDoctors_cancel = new System.Windows.Forms.Button();
            this.button_tabDoctors_save = new System.Windows.Forms.Button();
            this.panel_tabDoctors_actions = new System.Windows.Forms.Panel();
            this.button_tabDoctors_delete = new System.Windows.Forms.Button();
            this.button_tabDoctors_edit = new System.Windows.Forms.Button();
            this.button_tabDoctors_new = new System.Windows.Forms.Button();
            this.panel_data = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.doctorsidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vDoctorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_filters = new System.Windows.Forms.Panel();
            this.tabPage_tabDoctors.SuspendLayout();
            this.panel_tabDoctors_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsBindingSource)).BeginInit();
            this.panel_tabDoctors_updates.SuspendLayout();
            this.panel_tabDoctors_actions.SuspendLayout();
            this.panel_data.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDoctorsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // doctors_idLabel
            // 
            this.doctors_idLabel.AutoSize = true;
            this.doctors_idLabel.Location = new System.Drawing.Point(9, 9);
            this.doctors_idLabel.Name = "doctors_idLabel";
            this.doctors_idLabel.Size = new System.Drawing.Size(19, 13);
            this.doctors_idLabel.TabIndex = 0;
            this.doctors_idLabel.Text = "Id:";
            // 
            // doctors_nameLabel
            // 
            this.doctors_nameLabel.AutoSize = true;
            this.doctors_nameLabel.Location = new System.Drawing.Point(9, 48);
            this.doctors_nameLabel.Name = "doctors_nameLabel";
            this.doctors_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.doctors_nameLabel.TabIndex = 2;
            this.doctors_nameLabel.Text = "Name:";
            // 
            // doctors_surnameLabel
            // 
            this.doctors_surnameLabel.AutoSize = true;
            this.doctors_surnameLabel.Location = new System.Drawing.Point(9, 87);
            this.doctors_surnameLabel.Name = "doctors_surnameLabel";
            this.doctors_surnameLabel.Size = new System.Drawing.Size(52, 13);
            this.doctors_surnameLabel.TabIndex = 4;
            this.doctors_surnameLabel.Text = "Surname:";
            // 
            // doctors_doctextLabel
            // 
            this.doctors_doctextLabel.AutoSize = true;
            this.doctors_doctextLabel.Location = new System.Drawing.Point(9, 127);
            this.doctors_doctextLabel.Name = "doctors_doctextLabel";
            this.doctors_doctextLabel.Size = new System.Drawing.Size(54, 13);
            this.doctors_doctextLabel.TabIndex = 6;
            this.doctors_doctextLabel.Text = "Doc Text:";
            // 
            // tabPage_tabDoctors
            // 
            this.tabPage_tabDoctors.Controls.Add(this.panel_tabDoctors_data);
            this.tabPage_tabDoctors.Controls.Add(this.panel_tabDoctors_updates);
            this.tabPage_tabDoctors.Controls.Add(this.panel_tabDoctors_actions);
            this.tabPage_tabDoctors.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabDoctors.Name = "tabPage_tabDoctors";
            this.tabPage_tabDoctors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabDoctors.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabDoctors.TabIndex = 0;
            this.tabPage_tabDoctors.Text = "Doctor";
            this.tabPage_tabDoctors.UseVisualStyleBackColor = true;
            // 
            // panel_tabDoctors_data
            // 
            this.panel_tabDoctors_data.Controls.Add(this.doctors_doctextLabel);
            this.panel_tabDoctors_data.Controls.Add(this.doctors_doctextTextBox);
            this.panel_tabDoctors_data.Controls.Add(this.doctors_surnameLabel);
            this.panel_tabDoctors_data.Controls.Add(this.doctors_surnameTextBox);
            this.panel_tabDoctors_data.Controls.Add(this.doctors_nameLabel);
            this.panel_tabDoctors_data.Controls.Add(this.doctors_nameTextBox);
            this.panel_tabDoctors_data.Controls.Add(this.doctors_idLabel);
            this.panel_tabDoctors_data.Controls.Add(this.doctors_idTextBox);
            this.panel_tabDoctors_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabDoctors_data.Name = "panel_tabDoctors_data";
            this.panel_tabDoctors_data.Size = new System.Drawing.Size(480, 229);
            this.panel_tabDoctors_data.TabIndex = 2;
            // 
            // doctors_doctextTextBox
            // 
            this.doctors_doctextTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.doctorsBindingSource, "doctors_doctext", true));
            this.doctors_doctextTextBox.Location = new System.Drawing.Point(12, 143);
            this.doctors_doctextTextBox.Multiline = true;
            this.doctors_doctextTextBox.Name = "doctors_doctextTextBox";
            this.doctors_doctextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.doctors_doctextTextBox.Size = new System.Drawing.Size(430, 80);
            this.doctors_doctextTextBox.TabIndex = 7;
            this.doctors_doctextTextBox.WordWrap = false;
            // 
            // doctorsBindingSource
            // 
            this.doctorsBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.doctors);
            // 
            // doctors_surnameTextBox
            // 
            this.doctors_surnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.doctorsBindingSource, "doctors_surname", true));
            this.doctors_surnameTextBox.Location = new System.Drawing.Point(12, 104);
            this.doctors_surnameTextBox.Name = "doctors_surnameTextBox";
            this.doctors_surnameTextBox.Size = new System.Drawing.Size(430, 20);
            this.doctors_surnameTextBox.TabIndex = 5;
            // 
            // doctors_nameTextBox
            // 
            this.doctors_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.doctorsBindingSource, "doctors_name", true));
            this.doctors_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.doctors_nameTextBox.Name = "doctors_nameTextBox";
            this.doctors_nameTextBox.Size = new System.Drawing.Size(430, 20);
            this.doctors_nameTextBox.TabIndex = 3;
            // 
            // doctors_idTextBox
            // 
            this.doctors_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.doctorsBindingSource, "doctors_id", true));
            this.doctors_idTextBox.Enabled = false;
            this.doctors_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.doctors_idTextBox.Name = "doctors_idTextBox";
            this.doctors_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.doctors_idTextBox.TabIndex = 1;
            // 
            // panel_tabDoctors_updates
            // 
            this.panel_tabDoctors_updates.Controls.Add(this.button_tabDoctors_cancel);
            this.panel_tabDoctors_updates.Controls.Add(this.button_tabDoctors_save);
            this.panel_tabDoctors_updates.Location = new System.Drawing.Point(6, 277);
            this.panel_tabDoctors_updates.Name = "panel_tabDoctors_updates";
            this.panel_tabDoctors_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabDoctors_updates.TabIndex = 1;
            // 
            // button_tabDoctors_cancel
            // 
            this.button_tabDoctors_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabDoctors_cancel.Name = "button_tabDoctors_cancel";
            this.button_tabDoctors_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabDoctors_cancel.TabIndex = 2;
            this.button_tabDoctors_cancel.Text = "Cancel";
            this.button_tabDoctors_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabDoctors_save
            // 
            this.button_tabDoctors_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabDoctors_save.Name = "button_tabDoctors_save";
            this.button_tabDoctors_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabDoctors_save.TabIndex = 1;
            this.button_tabDoctors_save.Text = "Save";
            this.button_tabDoctors_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabDoctors_actions
            // 
            this.panel_tabDoctors_actions.Controls.Add(this.button_tabDoctors_delete);
            this.panel_tabDoctors_actions.Controls.Add(this.button_tabDoctors_edit);
            this.panel_tabDoctors_actions.Controls.Add(this.button_tabDoctors_new);
            this.panel_tabDoctors_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabDoctors_actions.Name = "panel_tabDoctors_actions";
            this.panel_tabDoctors_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabDoctors_actions.TabIndex = 0;
            // 
            // button_tabDoctors_delete
            // 
            this.button_tabDoctors_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabDoctors_delete.Name = "button_tabDoctors_delete";
            this.button_tabDoctors_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabDoctors_delete.TabIndex = 2;
            this.button_tabDoctors_delete.Text = "Delete";
            this.button_tabDoctors_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabDoctors_edit
            // 
            this.button_tabDoctors_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabDoctors_edit.Name = "button_tabDoctors_edit";
            this.button_tabDoctors_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabDoctors_edit.TabIndex = 1;
            this.button_tabDoctors_edit.Text = "Edit";
            this.button_tabDoctors_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabDoctors_new
            // 
            this.button_tabDoctors_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabDoctors_new.Name = "button_tabDoctors_new";
            this.button_tabDoctors_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabDoctors_new.TabIndex = 0;
            this.button_tabDoctors_new.Text = "New";
            this.button_tabDoctors_new.UseVisualStyleBackColor = true;
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.tabControl_main);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(284, 0);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(500, 562);
            this.panel_data.TabIndex = 3;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabDoctors);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 60);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(284, 502);
            this.panel_list.TabIndex = 5;
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
            this.doctorsidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vDoctorsBindingSource;
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
            // doctorsidDataGridViewTextBoxColumn
            // 
            this.doctorsidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.doctorsidDataGridViewTextBoxColumn.DataPropertyName = "doctors_id";
            this.doctorsidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.doctorsidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.doctorsidDataGridViewTextBoxColumn.Name = "doctorsidDataGridViewTextBoxColumn";
            this.doctorsidDataGridViewTextBoxColumn.ReadOnly = true;
            this.doctorsidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.doctorsidDataGridViewTextBoxColumn.Width = 80;
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
            // vDoctorsBindingSource
            // 
            this.vDoctorsBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VDoctors);
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 4;
            // 
            // FormDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormDoctors";
            this.Text = "Doctors";
            this.Load += new System.EventHandler(this.FormDoctors_Load);
            this.tabPage_tabDoctors.ResumeLayout(false);
            this.panel_tabDoctors_data.ResumeLayout(false);
            this.panel_tabDoctors_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsBindingSource)).EndInit();
            this.panel_tabDoctors_updates.ResumeLayout(false);
            this.panel_tabDoctors_actions.ResumeLayout(false);
            this.panel_data.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDoctorsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage_tabDoctors;
        private System.Windows.Forms.Panel panel_tabDoctors_data;
        private System.Windows.Forms.Panel panel_tabDoctors_updates;
        private System.Windows.Forms.Button button_tabDoctors_cancel;
        private System.Windows.Forms.Button button_tabDoctors_save;
        private System.Windows.Forms.Panel panel_tabDoctors_actions;
        private System.Windows.Forms.Button button_tabDoctors_delete;
        private System.Windows.Forms.Button button_tabDoctors_edit;
        private System.Windows.Forms.Button button_tabDoctors_new;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.BindingSource vDoctorsBindingSource;
        private System.Windows.Forms.TextBox doctors_doctextTextBox;
        private System.Windows.Forms.BindingSource doctorsBindingSource;
        private System.Windows.Forms.TextBox doctors_surnameTextBox;
        private System.Windows.Forms.TextBox doctors_nameTextBox;
        private System.Windows.Forms.TextBox doctors_idTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorsidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label doctors_idLabel;
        private System.Windows.Forms.Label doctors_nameLabel;
        private System.Windows.Forms.Label doctors_surnameLabel;
        private System.Windows.Forms.Label doctors_doctextLabel;
    }
}