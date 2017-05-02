namespace MastercraftWFA {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.professionsGridView = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.Label();
            this.insertButton = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Label();
            this.deselectAllButton = new System.Windows.Forms.Label();
            this.toolCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filter = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.professionsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // professionsGridView
            // 
            this.professionsGridView.AllowUserToResizeColumns = false;
            this.professionsGridView.AllowUserToResizeRows = false;
            this.professionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.professionsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filter,
            this.name,
            this.tool,
            this.toolCost});
            this.professionsGridView.Location = new System.Drawing.Point(12, 32);
            this.professionsGridView.Name = "professionsGridView";
            this.professionsGridView.RowHeadersVisible = false;
            this.professionsGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.professionsGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.professionsGridView.Size = new System.Drawing.Size(360, 267);
            this.professionsGridView.TabIndex = 0;
            this.professionsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProfessionsGridView_CellDoubleClick);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(92, 20);
            this.title.TabIndex = 1;
            this.title.Text = "Professions";
            // 
            // insertButton
            // 
            this.insertButton.AutoSize = true;
            this.insertButton.BackColor = System.Drawing.Color.Gray;
            this.insertButton.ForeColor = System.Drawing.Color.Black;
            this.insertButton.Location = new System.Drawing.Point(308, 16);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(33, 13);
            this.insertButton.TabIndex = 2;
            this.insertButton.Text = "Insert";
            this.insertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // editButton
            // 
            this.editButton.AutoSize = true;
            this.editButton.BackColor = System.Drawing.Color.Gray;
            this.editButton.Location = new System.Drawing.Point(347, 16);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(25, 13);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Edit";
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.AutoSize = true;
            this.selectAllButton.BackColor = System.Drawing.Color.Gray;
            this.selectAllButton.Location = new System.Drawing.Point(110, 16);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(51, 13);
            this.selectAllButton.TabIndex = 4;
            this.selectAllButton.Text = "Select All";
            // 
            // deselectAllButton
            // 
            this.deselectAllButton.AutoSize = true;
            this.deselectAllButton.BackColor = System.Drawing.Color.Gray;
            this.deselectAllButton.Location = new System.Drawing.Point(167, 16);
            this.deselectAllButton.Name = "deselectAllButton";
            this.deselectAllButton.Size = new System.Drawing.Size(63, 13);
            this.deselectAllButton.TabIndex = 5;
            this.deselectAllButton.Text = "Deselect All";
            // 
            // toolCost
            // 
            this.toolCost.DataPropertyName = "toolCost";
            this.toolCost.HeaderText = "Tool Cost";
            this.toolCost.Name = "toolCost";
            this.toolCost.ReadOnly = true;
            this.toolCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tool
            // 
            this.tool.DataPropertyName = "tool";
            this.tool.HeaderText = "Tool";
            this.tool.Name = "tool";
            this.tool.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tool.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tool.Width = 50;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Profession";
            this.name.Name = "name";
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.Width = 150;
            // 
            // filter
            // 
            this.filter.DataPropertyName = "filter";
            this.filter.HeaderText = "Filter";
            this.filter.Name = "filter";
            this.filter.ReadOnly = true;
            this.filter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.filter.Width = 40;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.deselectAllButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.professionsGridView);
            this.Name = "Main";
            this.Text = "Mastercrafter";
            ((System.ComponentModel.ISupportInitialize)(this.professionsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView professionsGridView;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label insertButton;
        private System.Windows.Forms.Label editButton;
        private System.Windows.Forms.Label selectAllButton;
        private System.Windows.Forms.Label deselectAllButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn filter;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn tool;
        private System.Windows.Forms.DataGridViewTextBoxColumn toolCost;
    }
}

