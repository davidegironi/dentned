namespace DG.DentneD.Forms
{
    partial class FormComputedLines
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
            System.Windows.Forms.Label computedlines_codeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComputedLines));
            this.computedlines_idLabel = new System.Windows.Forms.Label();
            this.computedlines_nameLabel = new System.Windows.Forms.Label();
            this.computedlines_rateLabel = new System.Windows.Forms.Label();
            this.taxes_idLabel = new System.Windows.Forms.Label();
            this.panel_filters = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.panel_list = new System.Windows.Forms.Panel();
            this.button_tabComputedLines_delete = new System.Windows.Forms.Button();
            this.button_tabComputedLines_edit = new System.Windows.Forms.Button();
            this.button_tabComputedLines_new = new System.Windows.Forms.Button();
            this.panel_tabComputedLines_actions = new System.Windows.Forms.Panel();
            this.button_tabComputedLines_cancel = new System.Windows.Forms.Button();
            this.button_tabComputedLines_save = new System.Windows.Forms.Button();
            this.panel_tabComputedLines_data = new System.Windows.Forms.Panel();
            this.button_tabComputedLines_unsettaxesid = new System.Windows.Forms.Button();
            this.taxes_idComboBox = new System.Windows.Forms.ComboBox();
            this.computedlinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.computedlines_rateTextBox = new System.Windows.Forms.TextBox();
            this.computedlines_nameTextBox = new System.Windows.Forms.TextBox();
            this.computedlines_idTextBox = new System.Windows.Forms.TextBox();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabComputedLines = new System.Windows.Forms.TabPage();
            this.panel_tabComputedLines_updates = new System.Windows.Forms.Panel();
            this.panel_data = new System.Windows.Forms.Panel();
            this.vComputedLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.computedlinesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computedlines_codeTextBox = new System.Windows.Forms.TextBox();
            computedlines_codeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            this.panel_list.SuspendLayout();
            this.panel_tabComputedLines_actions.SuspendLayout();
            this.panel_tabComputedLines_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computedlinesBindingSource)).BeginInit();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabComputedLines.SuspendLayout();
            this.panel_tabComputedLines_updates.SuspendLayout();
            this.panel_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vComputedLinesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // computedlines_idLabel
            // 
            this.computedlines_idLabel.AutoSize = true;
            this.computedlines_idLabel.Location = new System.Drawing.Point(9, 9);
            this.computedlines_idLabel.Name = "computedlines_idLabel";
            this.computedlines_idLabel.Size = new System.Drawing.Size(19, 13);
            this.computedlines_idLabel.TabIndex = 0;
            this.computedlines_idLabel.Text = "Id:";
            // 
            // computedlines_nameLabel
            // 
            this.computedlines_nameLabel.AutoSize = true;
            this.computedlines_nameLabel.Location = new System.Drawing.Point(74, 48);
            this.computedlines_nameLabel.Name = "computedlines_nameLabel";
            this.computedlines_nameLabel.Size = new System.Drawing.Size(38, 13);
            this.computedlines_nameLabel.TabIndex = 2;
            this.computedlines_nameLabel.Text = "Name:";
            // 
            // computedlines_rateLabel
            // 
            this.computedlines_rateLabel.AutoSize = true;
            this.computedlines_rateLabel.Location = new System.Drawing.Point(9, 87);
            this.computedlines_rateLabel.Name = "computedlines_rateLabel";
            this.computedlines_rateLabel.Size = new System.Drawing.Size(33, 13);
            this.computedlines_rateLabel.TabIndex = 4;
            this.computedlines_rateLabel.Text = "Rate:";
            // 
            // taxes_idLabel
            // 
            this.taxes_idLabel.AutoSize = true;
            this.taxes_idLabel.Location = new System.Drawing.Point(9, 126);
            this.taxes_idLabel.Name = "taxes_idLabel";
            this.taxes_idLabel.Size = new System.Drawing.Size(65, 13);
            this.taxes_idLabel.TabIndex = 6;
            this.taxes_idLabel.Text = "Default Tax:";
            // 
            // panel_filters
            // 
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filters.Location = new System.Drawing.Point(0, 0);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(284, 60);
            this.panel_filters.TabIndex = 12;
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
            this.computedlinesidDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vComputedLinesBindingSource;
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
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 60);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(284, 502);
            this.panel_list.TabIndex = 14;
            // 
            // button_tabComputedLines_delete
            // 
            this.button_tabComputedLines_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabComputedLines_delete.Name = "button_tabComputedLines_delete";
            this.button_tabComputedLines_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabComputedLines_delete.TabIndex = 2;
            this.button_tabComputedLines_delete.Text = "Delete";
            this.button_tabComputedLines_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabComputedLines_edit
            // 
            this.button_tabComputedLines_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabComputedLines_edit.Name = "button_tabComputedLines_edit";
            this.button_tabComputedLines_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabComputedLines_edit.TabIndex = 2;
            this.button_tabComputedLines_edit.Text = "Edit";
            this.button_tabComputedLines_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabComputedLines_new
            // 
            this.button_tabComputedLines_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabComputedLines_new.Name = "button_tabComputedLines_new";
            this.button_tabComputedLines_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabComputedLines_new.TabIndex = 1;
            this.button_tabComputedLines_new.Text = "New";
            this.button_tabComputedLines_new.UseVisualStyleBackColor = true;
            // 
            // panel_tabComputedLines_actions
            // 
            this.panel_tabComputedLines_actions.Controls.Add(this.button_tabComputedLines_delete);
            this.panel_tabComputedLines_actions.Controls.Add(this.button_tabComputedLines_edit);
            this.panel_tabComputedLines_actions.Controls.Add(this.button_tabComputedLines_new);
            this.panel_tabComputedLines_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabComputedLines_actions.Name = "panel_tabComputedLines_actions";
            this.panel_tabComputedLines_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabComputedLines_actions.TabIndex = 0;
            // 
            // button_tabComputedLines_cancel
            // 
            this.button_tabComputedLines_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabComputedLines_cancel.Name = "button_tabComputedLines_cancel";
            this.button_tabComputedLines_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabComputedLines_cancel.TabIndex = 1;
            this.button_tabComputedLines_cancel.Text = "Cancel";
            this.button_tabComputedLines_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabComputedLines_save
            // 
            this.button_tabComputedLines_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabComputedLines_save.Name = "button_tabComputedLines_save";
            this.button_tabComputedLines_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabComputedLines_save.TabIndex = 0;
            this.button_tabComputedLines_save.Text = "Save";
            this.button_tabComputedLines_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabComputedLines_data
            // 
            this.panel_tabComputedLines_data.Controls.Add(computedlines_codeLabel);
            this.panel_tabComputedLines_data.Controls.Add(this.computedlines_codeTextBox);
            this.panel_tabComputedLines_data.Controls.Add(this.button_tabComputedLines_unsettaxesid);
            this.panel_tabComputedLines_data.Controls.Add(this.taxes_idLabel);
            this.panel_tabComputedLines_data.Controls.Add(this.taxes_idComboBox);
            this.panel_tabComputedLines_data.Controls.Add(this.computedlines_rateLabel);
            this.panel_tabComputedLines_data.Controls.Add(this.computedlines_rateTextBox);
            this.panel_tabComputedLines_data.Controls.Add(this.computedlines_nameLabel);
            this.panel_tabComputedLines_data.Controls.Add(this.computedlines_nameTextBox);
            this.panel_tabComputedLines_data.Controls.Add(this.computedlines_idLabel);
            this.panel_tabComputedLines_data.Controls.Add(this.computedlines_idTextBox);
            this.panel_tabComputedLines_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabComputedLines_data.Name = "panel_tabComputedLines_data";
            this.panel_tabComputedLines_data.Size = new System.Drawing.Size(480, 171);
            this.panel_tabComputedLines_data.TabIndex = 2;
            // 
            // button_tabComputedLines_unsettaxesid
            // 
            this.button_tabComputedLines_unsettaxesid.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_tabComputedLines_unsettaxesid.Location = new System.Drawing.Point(118, 141);
            this.button_tabComputedLines_unsettaxesid.Name = "button_tabComputedLines_unsettaxesid";
            this.button_tabComputedLines_unsettaxesid.Size = new System.Drawing.Size(75, 23);
            this.button_tabComputedLines_unsettaxesid.TabIndex = 8;
            this.button_tabComputedLines_unsettaxesid.Text = "Unset";
            this.button_tabComputedLines_unsettaxesid.UseVisualStyleBackColor = true;
            this.button_tabComputedLines_unsettaxesid.Click += new System.EventHandler(this.button_tabComputedLines_unsettaxesid_Click);
            // 
            // taxes_idComboBox
            // 
            this.taxes_idComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.taxes_idComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.taxes_idComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.computedlinesBindingSource, "taxes_id", true));
            this.taxes_idComboBox.FormattingEnabled = true;
            this.taxes_idComboBox.Location = new System.Drawing.Point(12, 142);
            this.taxes_idComboBox.Name = "taxes_idComboBox";
            this.taxes_idComboBox.Size = new System.Drawing.Size(100, 21);
            this.taxes_idComboBox.TabIndex = 7;
            this.taxes_idComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.taxes_idComboBox_KeyPress);
            // 
            // computedlinesBindingSource
            // 
            this.computedlinesBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.computedlines);
            // 
            // computedlines_rateTextBox
            // 
            this.computedlines_rateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.computedlinesBindingSource, "computedlines_rate", true));
            this.computedlines_rateTextBox.Location = new System.Drawing.Point(12, 103);
            this.computedlines_rateTextBox.Name = "computedlines_rateTextBox";
            this.computedlines_rateTextBox.Size = new System.Drawing.Size(50, 20);
            this.computedlines_rateTextBox.TabIndex = 5;
            // 
            // computedlines_nameTextBox
            // 
            this.computedlines_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.computedlinesBindingSource, "computedlines_name", true));
            this.computedlines_nameTextBox.Location = new System.Drawing.Point(78, 64);
            this.computedlines_nameTextBox.Name = "computedlines_nameTextBox";
            this.computedlines_nameTextBox.Size = new System.Drawing.Size(150, 20);
            this.computedlines_nameTextBox.TabIndex = 3;
            // 
            // computedlines_idTextBox
            // 
            this.computedlines_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.computedlinesBindingSource, "computedlines_id", true));
            this.computedlines_idTextBox.Enabled = false;
            this.computedlines_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.computedlines_idTextBox.Name = "computedlines_idTextBox";
            this.computedlines_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.computedlines_idTextBox.TabIndex = 1;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_tabComputedLines);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabComputedLines
            // 
            this.tabPage_tabComputedLines.Controls.Add(this.panel_tabComputedLines_data);
            this.tabPage_tabComputedLines.Controls.Add(this.panel_tabComputedLines_updates);
            this.tabPage_tabComputedLines.Controls.Add(this.panel_tabComputedLines_actions);
            this.tabPage_tabComputedLines.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabComputedLines.Name = "tabPage_tabComputedLines";
            this.tabPage_tabComputedLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabComputedLines.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabComputedLines.TabIndex = 0;
            this.tabPage_tabComputedLines.Text = "Computed Line";
            this.tabPage_tabComputedLines.UseVisualStyleBackColor = true;
            // 
            // panel_tabComputedLines_updates
            // 
            this.panel_tabComputedLines_updates.Controls.Add(this.button_tabComputedLines_cancel);
            this.panel_tabComputedLines_updates.Controls.Add(this.button_tabComputedLines_save);
            this.panel_tabComputedLines_updates.Location = new System.Drawing.Point(6, 219);
            this.panel_tabComputedLines_updates.Name = "panel_tabComputedLines_updates";
            this.panel_tabComputedLines_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabComputedLines_updates.TabIndex = 1;
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.tabControl_main);
            this.panel_data.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_data.Location = new System.Drawing.Point(284, 0);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(500, 562);
            this.panel_data.TabIndex = 13;
            // 
            // vComputedLinesBindingSource
            // 
            this.vComputedLinesBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VComputedLines);
            // 
            // computedlinesidDataGridViewTextBoxColumn
            // 
            this.computedlinesidDataGridViewTextBoxColumn.DataPropertyName = "computedlines_id";
            this.computedlinesidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.computedlinesidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.computedlinesidDataGridViewTextBoxColumn.Name = "computedlinesidDataGridViewTextBoxColumn";
            this.computedlinesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.computedlinesidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.computedlinesidDataGridViewTextBoxColumn.Width = 80;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.codeDataGridViewTextBoxColumn.Width = 60;
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
            // computedlines_codeLabel
            // 
            computedlines_codeLabel.AutoSize = true;
            computedlines_codeLabel.Location = new System.Drawing.Point(9, 48);
            computedlines_codeLabel.Name = "computedlines_codeLabel";
            computedlines_codeLabel.Size = new System.Drawing.Size(35, 13);
            computedlines_codeLabel.TabIndex = 9;
            computedlines_codeLabel.Text = "Code:";
            // 
            // computedlines_codeTextBox
            // 
            this.computedlines_codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.computedlinesBindingSource, "computedlines_code", true));
            this.computedlines_codeTextBox.Location = new System.Drawing.Point(12, 64);
            this.computedlines_codeTextBox.Name = "computedlines_codeTextBox";
            this.computedlines_codeTextBox.Size = new System.Drawing.Size(50, 20);
            this.computedlines_codeTextBox.TabIndex = 10;
            // 
            // FormComputedLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormComputedLines";
            this.Text = "Document Computed Lines";
            this.Load += new System.EventHandler(this.FormComputedLines_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.panel_tabComputedLines_actions.ResumeLayout(false);
            this.panel_tabComputedLines_data.ResumeLayout(false);
            this.panel_tabComputedLines_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computedlinesBindingSource)).EndInit();
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabComputedLines.ResumeLayout(false);
            this.panel_tabComputedLines_updates.ResumeLayout(false);
            this.panel_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vComputedLinesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filters;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.Button button_tabComputedLines_delete;
        private System.Windows.Forms.Button button_tabComputedLines_edit;
        private System.Windows.Forms.Button button_tabComputedLines_new;
        private System.Windows.Forms.Panel panel_tabComputedLines_actions;
        private System.Windows.Forms.Button button_tabComputedLines_cancel;
        private System.Windows.Forms.Button button_tabComputedLines_save;
        private System.Windows.Forms.Panel panel_tabComputedLines_data;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabComputedLines;
        private System.Windows.Forms.Panel panel_tabComputedLines_updates;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.BindingSource vComputedLinesBindingSource;
        private System.Windows.Forms.TextBox computedlines_rateTextBox;
        private System.Windows.Forms.BindingSource computedlinesBindingSource;
        private System.Windows.Forms.TextBox computedlines_nameTextBox;
        private System.Windows.Forms.TextBox computedlines_idTextBox;
        private System.Windows.Forms.ComboBox taxes_idComboBox;
        private System.Windows.Forms.Button button_tabComputedLines_unsettaxesid;
        private System.Windows.Forms.Label computedlines_idLabel;
        private System.Windows.Forms.Label computedlines_nameLabel;
        private System.Windows.Forms.Label computedlines_rateLabel;
        private System.Windows.Forms.Label taxes_idLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn computedlinesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox computedlines_codeTextBox;
    }
}