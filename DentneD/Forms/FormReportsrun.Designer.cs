namespace DG.DentneD.Forms
{
    partial class FormReportsrun
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportsrun));
            this.panel_filter = new System.Windows.Forms.Panel();
            this.panel_left_fill = new System.Windows.Forms.Panel();
            this.panel_left_right_fill = new System.Windows.Forms.Panel();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.panel_left_right_top = new System.Windows.Forms.Panel();
            this.panel_filter_left = new System.Windows.Forms.Panel();
            this.label_reports = new System.Windows.Forms.Label();
            this.button_execute = new System.Windows.Forms.Button();
            this.dataGridView_reportsparameters = new System.Windows.Forms.DataGridView();
            this.comboBox_reports = new System.Windows.Forms.ComboBox();
            this.panel_list = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.panel_filter.SuspendLayout();
            this.panel_left_fill.SuspendLayout();
            this.panel_left_right_fill.SuspendLayout();
            this.panel_filter_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reportsparameters)).BeginInit();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_filter
            // 
            this.panel_filter.Controls.Add(this.panel_left_fill);
            this.panel_filter.Controls.Add(this.panel_filter_left);
            this.panel_filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filter.Location = new System.Drawing.Point(0, 0);
            this.panel_filter.Name = "panel_filter";
            this.panel_filter.Size = new System.Drawing.Size(784, 160);
            this.panel_filter.TabIndex = 2;
            // 
            // panel_left_fill
            // 
            this.panel_left_fill.Controls.Add(this.panel_left_right_fill);
            this.panel_left_fill.Controls.Add(this.panel_left_right_top);
            this.panel_left_fill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_left_fill.Location = new System.Drawing.Point(401, 0);
            this.panel_left_fill.Name = "panel_left_fill";
            this.panel_left_fill.Size = new System.Drawing.Size(383, 160);
            this.panel_left_fill.TabIndex = 6;
            // 
            // panel_left_right_fill
            // 
            this.panel_left_right_fill.Controls.Add(this.textBox_info);
            this.panel_left_right_fill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_left_right_fill.Location = new System.Drawing.Point(0, 48);
            this.panel_left_right_fill.Name = "panel_left_right_fill";
            this.panel_left_right_fill.Padding = new System.Windows.Forms.Padding(5, 5, 12, 8);
            this.panel_left_right_fill.Size = new System.Drawing.Size(383, 112);
            this.panel_left_right_fill.TabIndex = 6;
            // 
            // textBox_info
            // 
            this.textBox_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_info.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_info.Location = new System.Drawing.Point(5, 5);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_info.Size = new System.Drawing.Size(366, 99);
            this.textBox_info.TabIndex = 0;
            // 
            // panel_left_right_top
            // 
            this.panel_left_right_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_left_right_top.Location = new System.Drawing.Point(0, 0);
            this.panel_left_right_top.Name = "panel_left_right_top";
            this.panel_left_right_top.Size = new System.Drawing.Size(383, 48);
            this.panel_left_right_top.TabIndex = 5;
            // 
            // panel_filter_left
            // 
            this.panel_filter_left.Controls.Add(this.label_reports);
            this.panel_filter_left.Controls.Add(this.button_execute);
            this.panel_filter_left.Controls.Add(this.dataGridView_reportsparameters);
            this.panel_filter_left.Controls.Add(this.comboBox_reports);
            this.panel_filter_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_filter_left.Location = new System.Drawing.Point(0, 0);
            this.panel_filter_left.Name = "panel_filter_left";
            this.panel_filter_left.Size = new System.Drawing.Size(401, 160);
            this.panel_filter_left.TabIndex = 5;
            // 
            // label_reports
            // 
            this.label_reports.AutoSize = true;
            this.label_reports.Location = new System.Drawing.Point(9, 9);
            this.label_reports.Name = "label_reports";
            this.label_reports.Size = new System.Drawing.Size(42, 13);
            this.label_reports.TabIndex = 1;
            this.label_reports.Text = "Report:";
            // 
            // button_execute
            // 
            this.button_execute.Location = new System.Drawing.Point(318, 23);
            this.button_execute.Name = "button_execute";
            this.button_execute.Size = new System.Drawing.Size(75, 23);
            this.button_execute.TabIndex = 0;
            this.button_execute.Text = "Execute";
            this.button_execute.UseVisualStyleBackColor = true;
            this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
            // 
            // dataGridView_reportsparameters
            // 
            this.dataGridView_reportsparameters.AllowUserToAddRows = false;
            this.dataGridView_reportsparameters.AllowUserToDeleteRows = false;
            this.dataGridView_reportsparameters.AllowUserToResizeColumns = false;
            this.dataGridView_reportsparameters.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView_reportsparameters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_reportsparameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reportsparameters.Location = new System.Drawing.Point(12, 52);
            this.dataGridView_reportsparameters.MultiSelect = false;
            this.dataGridView_reportsparameters.Name = "dataGridView_reportsparameters";
            this.dataGridView_reportsparameters.RowHeadersVisible = false;
            this.dataGridView_reportsparameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_reportsparameters.Size = new System.Drawing.Size(381, 100);
            this.dataGridView_reportsparameters.TabIndex = 3;
            // 
            // comboBox_reports
            // 
            this.comboBox_reports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_reports.FormattingEnabled = true;
            this.comboBox_reports.Location = new System.Drawing.Point(12, 25);
            this.comboBox_reports.Name = "comboBox_reports";
            this.comboBox_reports.Size = new System.Drawing.Size(300, 21);
            this.comboBox_reports.TabIndex = 2;
            this.comboBox_reports.SelectedIndexChanged += new System.EventHandler(this.comboBox_reports_SelectedIndexChanged);
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.advancedDataGridView_main);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 160);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(784, 402);
            this.panel_list.TabIndex = 3;
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToAddRows = false;
            this.advancedDataGridView_main.AllowUserToDeleteRows = false;
            this.advancedDataGridView_main.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(784, 402);
            this.advancedDataGridView_main.TabIndex = 1;
            // 
            // FormReportsrun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormReportsrun";
            this.Text = "Reports Run";
            this.Load += new System.EventHandler(this.FormReportsrun_Load);
            this.Shown += new System.EventHandler(this.FormReportsrun_Shown);
            this.panel_filter.ResumeLayout(false);
            this.panel_left_fill.ResumeLayout(false);
            this.panel_left_right_fill.ResumeLayout(false);
            this.panel_left_right_fill.PerformLayout();
            this.panel_filter_left.ResumeLayout(false);
            this.panel_filter_left.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reportsparameters)).EndInit();
            this.panel_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filter;
        private System.Windows.Forms.DataGridView dataGridView_reportsparameters;
        private System.Windows.Forms.ComboBox comboBox_reports;
        private System.Windows.Forms.Label label_reports;
        private System.Windows.Forms.Button button_execute;
        private System.Windows.Forms.Panel panel_list;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_left_fill;
        private System.Windows.Forms.Panel panel_left_right_fill;
        private System.Windows.Forms.Panel panel_left_right_top;
        private System.Windows.Forms.Panel panel_filter_left;
        private System.Windows.Forms.TextBox textBox_info;
    }
}