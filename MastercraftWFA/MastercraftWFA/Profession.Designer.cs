namespace MastercraftWFA {
    partial class Profession {
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier1profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier2profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier3profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.cost,
            this.profit,
            this.tier1profit,
            this.tier2profit,
            this.tier3profit,
            this.tier1,
            this.tier2,
            this.tier3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(410, 437);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // name
            // 
            this.name.DataPropertyName = "recipe";
            this.name.HeaderText = "Recipe";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.Width = 160;
            // 
            // cost
            // 
            this.cost.DataPropertyName = "cost";
            this.cost.HeaderText = "Cost";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            this.cost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cost.Visible = false;
            this.cost.Width = 50;
            // 
            // profit
            // 
            this.profit.DataPropertyName = "profit";
            this.profit.HeaderText = "Profit";
            this.profit.Name = "profit";
            this.profit.ReadOnly = true;
            this.profit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.profit.Width = 60;
            // 
            // tier1profit
            // 
            this.tier1profit.DataPropertyName = "tier1profit";
            this.tier1profit.HeaderText = "Tier 1";
            this.tier1profit.Name = "tier1profit";
            this.tier1profit.ReadOnly = true;
            this.tier1profit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier1profit.Width = 60;
            // 
            // tier2profit
            // 
            this.tier2profit.DataPropertyName = "tier2profit";
            this.tier2profit.HeaderText = "Tier 2";
            this.tier2profit.Name = "tier2profit";
            this.tier2profit.ReadOnly = true;
            this.tier2profit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier2profit.Width = 60;
            // 
            // tier3profit
            // 
            this.tier3profit.DataPropertyName = "tier3profit";
            this.tier3profit.HeaderText = "Tier 3";
            this.tier3profit.Name = "tier3profit";
            this.tier3profit.ReadOnly = true;
            this.tier3profit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier3profit.Width = 60;
            // 
            // tier1
            // 
            this.tier1.DataPropertyName = "tier1";
            this.tier1.HeaderText = "Tier 1 (reward)";
            this.tier1.Name = "tier1";
            this.tier1.ReadOnly = true;
            this.tier1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier1.Visible = false;
            this.tier1.Width = 60;
            // 
            // tier2
            // 
            this.tier2.DataPropertyName = "tier2";
            this.tier2.HeaderText = "Tier 2 (reward)";
            this.tier2.Name = "tier2";
            this.tier2.ReadOnly = true;
            this.tier2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier2.Visible = false;
            this.tier2.Width = 60;
            // 
            // tier3
            // 
            this.tier3.DataPropertyName = "tier3";
            this.tier3.HeaderText = "Tier 3 (reward)";
            this.tier3.Name = "tier3";
            this.tier3.ReadOnly = true;
            this.tier3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier3.Visible = false;
            this.tier3.Width = 60;
            // 
            // Profession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(434, 461);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Profession";
            this.Text = "*Profession*";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier1profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier2profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier3profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier3;
    }
}