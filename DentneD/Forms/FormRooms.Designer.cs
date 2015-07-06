namespace DG.DentneD.Forms
{
    partial class FormRooms
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
            System.Windows.Forms.Label rooms_idLabel;
            System.Windows.Forms.Label rooms_nameLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRooms));
            this.panel_filters = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.roomsidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vRoomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel_list = new System.Windows.Forms.Panel();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_tabRooms = new System.Windows.Forms.TabPage();
            this.panel_tabRooms_data = new System.Windows.Forms.Panel();
            this.rooms_nameTextBox = new System.Windows.Forms.TextBox();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rooms_idTextBox = new System.Windows.Forms.TextBox();
            this.panel_tabRooms_updates = new System.Windows.Forms.Panel();
            this.button_tabRooms_cancel = new System.Windows.Forms.Button();
            this.button_tabRooms_save = new System.Windows.Forms.Button();
            this.panel_tabRooms_actions = new System.Windows.Forms.Panel();
            this.button_tabRooms_delete = new System.Windows.Forms.Button();
            this.button_tabRooms_edit = new System.Windows.Forms.Button();
            this.button_tabRooms_new = new System.Windows.Forms.Button();
            this.panel_data = new System.Windows.Forms.Panel();
            rooms_idLabel = new System.Windows.Forms.Label();
            rooms_nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRoomsBindingSource)).BeginInit();
            this.panel_list.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_tabRooms.SuspendLayout();
            this.panel_tabRooms_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            this.panel_tabRooms_updates.SuspendLayout();
            this.panel_tabRooms_actions.SuspendLayout();
            this.panel_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // rooms_idLabel
            // 
            rooms_idLabel.AutoSize = true;
            rooms_idLabel.Location = new System.Drawing.Point(9, 9);
            rooms_idLabel.Name = "rooms_idLabel";
            rooms_idLabel.Size = new System.Drawing.Size(19, 13);
            rooms_idLabel.TabIndex = 0;
            rooms_idLabel.Text = "Id:";
            // 
            // rooms_nameLabel
            // 
            rooms_nameLabel.AutoSize = true;
            rooms_nameLabel.Location = new System.Drawing.Point(9, 48);
            rooms_nameLabel.Name = "rooms_nameLabel";
            rooms_nameLabel.Size = new System.Drawing.Size(38, 13);
            rooms_nameLabel.TabIndex = 2;
            rooms_nameLabel.Text = "Name:";
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
            this.roomsidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.advancedDataGridView_main.DataSource = this.vRoomsBindingSource;
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
            // roomsidDataGridViewTextBoxColumn
            // 
            this.roomsidDataGridViewTextBoxColumn.DataPropertyName = "rooms_id";
            this.roomsidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.roomsidDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.roomsidDataGridViewTextBoxColumn.Name = "roomsidDataGridViewTextBoxColumn";
            this.roomsidDataGridViewTextBoxColumn.ReadOnly = true;
            this.roomsidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.roomsidDataGridViewTextBoxColumn.Width = 80;
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
            // vRoomsBindingSource
            // 
            this.vRoomsBindingSource.DataSource = typeof(DG.DentneD.Forms.Objects.VRooms);
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
            this.tabControl_main.Controls.Add(this.tabPage_tabRooms);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(500, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_tabRooms
            // 
            this.tabPage_tabRooms.Controls.Add(this.panel_tabRooms_data);
            this.tabPage_tabRooms.Controls.Add(this.panel_tabRooms_updates);
            this.tabPage_tabRooms.Controls.Add(this.panel_tabRooms_actions);
            this.tabPage_tabRooms.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tabRooms.Name = "tabPage_tabRooms";
            this.tabPage_tabRooms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tabRooms.Size = new System.Drawing.Size(492, 536);
            this.tabPage_tabRooms.TabIndex = 0;
            this.tabPage_tabRooms.Text = "Room";
            this.tabPage_tabRooms.UseVisualStyleBackColor = true;
            // 
            // panel_tabRooms_data
            // 
            this.panel_tabRooms_data.Controls.Add(rooms_nameLabel);
            this.panel_tabRooms_data.Controls.Add(this.rooms_nameTextBox);
            this.panel_tabRooms_data.Controls.Add(rooms_idLabel);
            this.panel_tabRooms_data.Controls.Add(this.rooms_idTextBox);
            this.panel_tabRooms_data.Location = new System.Drawing.Point(6, 42);
            this.panel_tabRooms_data.Name = "panel_tabRooms_data";
            this.panel_tabRooms_data.Size = new System.Drawing.Size(480, 91);
            this.panel_tabRooms_data.TabIndex = 2;
            // 
            // rooms_nameTextBox
            // 
            this.rooms_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "rooms_name", true));
            this.rooms_nameTextBox.Location = new System.Drawing.Point(12, 64);
            this.rooms_nameTextBox.Name = "rooms_nameTextBox";
            this.rooms_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.rooms_nameTextBox.TabIndex = 3;
            // 
            // roomsBindingSource
            // 
            this.roomsBindingSource.DataSource = typeof(DG.DentneD.Model.Entity.rooms);
            // 
            // rooms_idTextBox
            // 
            this.rooms_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "rooms_id", true));
            this.rooms_idTextBox.Enabled = false;
            this.rooms_idTextBox.Location = new System.Drawing.Point(12, 25);
            this.rooms_idTextBox.Name = "rooms_idTextBox";
            this.rooms_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.rooms_idTextBox.TabIndex = 1;
            // 
            // panel_tabRooms_updates
            // 
            this.panel_tabRooms_updates.Controls.Add(this.button_tabRooms_cancel);
            this.panel_tabRooms_updates.Controls.Add(this.button_tabRooms_save);
            this.panel_tabRooms_updates.Location = new System.Drawing.Point(6, 139);
            this.panel_tabRooms_updates.Name = "panel_tabRooms_updates";
            this.panel_tabRooms_updates.Size = new System.Drawing.Size(480, 30);
            this.panel_tabRooms_updates.TabIndex = 1;
            // 
            // button_tabRooms_cancel
            // 
            this.button_tabRooms_cancel.Location = new System.Drawing.Point(402, 3);
            this.button_tabRooms_cancel.Name = "button_tabRooms_cancel";
            this.button_tabRooms_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_tabRooms_cancel.TabIndex = 2;
            this.button_tabRooms_cancel.Text = "Cancel";
            this.button_tabRooms_cancel.UseVisualStyleBackColor = true;
            // 
            // button_tabRooms_save
            // 
            this.button_tabRooms_save.Location = new System.Drawing.Point(321, 3);
            this.button_tabRooms_save.Name = "button_tabRooms_save";
            this.button_tabRooms_save.Size = new System.Drawing.Size(75, 23);
            this.button_tabRooms_save.TabIndex = 1;
            this.button_tabRooms_save.Text = "Save";
            this.button_tabRooms_save.UseVisualStyleBackColor = true;
            // 
            // panel_tabRooms_actions
            // 
            this.panel_tabRooms_actions.Controls.Add(this.button_tabRooms_delete);
            this.panel_tabRooms_actions.Controls.Add(this.button_tabRooms_edit);
            this.panel_tabRooms_actions.Controls.Add(this.button_tabRooms_new);
            this.panel_tabRooms_actions.Location = new System.Drawing.Point(6, 6);
            this.panel_tabRooms_actions.Name = "panel_tabRooms_actions";
            this.panel_tabRooms_actions.Size = new System.Drawing.Size(480, 30);
            this.panel_tabRooms_actions.TabIndex = 0;
            // 
            // button_tabRooms_delete
            // 
            this.button_tabRooms_delete.Location = new System.Drawing.Point(165, 3);
            this.button_tabRooms_delete.Name = "button_tabRooms_delete";
            this.button_tabRooms_delete.Size = new System.Drawing.Size(75, 23);
            this.button_tabRooms_delete.TabIndex = 2;
            this.button_tabRooms_delete.Text = "Delete";
            this.button_tabRooms_delete.UseVisualStyleBackColor = true;
            // 
            // button_tabRooms_edit
            // 
            this.button_tabRooms_edit.Location = new System.Drawing.Point(84, 3);
            this.button_tabRooms_edit.Name = "button_tabRooms_edit";
            this.button_tabRooms_edit.Size = new System.Drawing.Size(75, 23);
            this.button_tabRooms_edit.TabIndex = 1;
            this.button_tabRooms_edit.Text = "Edit";
            this.button_tabRooms_edit.UseVisualStyleBackColor = true;
            // 
            // button_tabRooms_new
            // 
            this.button_tabRooms_new.Location = new System.Drawing.Point(3, 3);
            this.button_tabRooms_new.Name = "button_tabRooms_new";
            this.button_tabRooms_new.Size = new System.Drawing.Size(75, 23);
            this.button_tabRooms_new.TabIndex = 0;
            this.button_tabRooms_new.Text = "New";
            this.button_tabRooms_new.UseVisualStyleBackColor = true;
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
            // FormRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_filters);
            this.Controls.Add(this.panel_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormRooms";
            this.Text = "Rooms";
            this.Load += new System.EventHandler(this.FormRooms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRoomsBindingSource)).EndInit();
            this.panel_list.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_tabRooms.ResumeLayout(false);
            this.panel_tabRooms_data.ResumeLayout(false);
            this.panel_tabRooms_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            this.panel_tabRooms_updates.ResumeLayout(false);
            this.panel_tabRooms_actions.ResumeLayout(false);
            this.panel_data.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_filters;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_tabRooms;
        private System.Windows.Forms.Panel panel_tabRooms_data;
        private System.Windows.Forms.Panel panel_tabRooms_updates;
        private System.Windows.Forms.Button button_tabRooms_cancel;
        private System.Windows.Forms.Button button_tabRooms_save;
        private System.Windows.Forms.Panel panel_tabRooms_actions;
        private System.Windows.Forms.Button button_tabRooms_delete;
        private System.Windows.Forms.Button button_tabRooms_edit;
        private System.Windows.Forms.Button button_tabRooms_new;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.BindingSource roomsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomsidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vRoomsBindingSource;
        private System.Windows.Forms.TextBox rooms_nameTextBox;
        private System.Windows.Forms.TextBox rooms_idTextBox;
    }
}