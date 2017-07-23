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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewProfessions = new System.Windows.Forms.DataGridView();
            this.titleProfessions = new System.Windows.Forms.Label();
            this.insertButton_Professions = new System.Windows.Forms.Label();
            this.editButton_Professions = new System.Windows.Forms.Label();
            this.dataGridViewResourcesConsumed = new System.Windows.Forms.DataGridView();
            this.resource_Consumed = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.amount_Consumed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewRecipes = new System.Windows.Forms.DataGridView();
            this.name_Recipes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier1profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier2profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier3profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier1reward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier2reward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier3reward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleRecipes = new System.Windows.Forms.Label();
            this.dataGridViewResources = new System.Windows.Forms.DataGridView();
            this.name_Resources = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_Resources = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updated_Resources = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewResourcesResults = new System.Windows.Forms.DataGridView();
            this.tier_Results = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.resource_Results = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.amount_Results = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleResources = new System.Windows.Forms.Label();
            this.titleResourcesConsumed = new System.Windows.Forms.Label();
            this.titleResourcesResults = new System.Windows.Forms.Label();
            this.grade = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.upgrade1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upgrade2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upgrade3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfessions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResourcesConsumed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecipes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResourcesResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProfessions
            // 
            this.dataGridViewProfessions.AllowUserToResizeColumns = false;
            this.dataGridViewProfessions.AllowUserToResizeRows = false;
            this.dataGridViewProfessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProfessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grade,
            this.upgrade1,
            this.upgrade2,
            this.upgrade3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProfessions.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProfessions.Location = new System.Drawing.Point(12, 32);
            this.dataGridViewProfessions.Name = "dataGridViewProfessions";
            this.dataGridViewProfessions.RowHeadersVisible = false;
            this.dataGridViewProfessions.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewProfessions.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProfessions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewProfessions.Size = new System.Drawing.Size(360, 267);
            this.dataGridViewProfessions.TabIndex = 0;
            this.dataGridViewProfessions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewProfessions_CellClick);
            this.dataGridViewProfessions.SelectionChanged += new System.EventHandler(this.DataGridViewProfessions_SelectionChanged);
            // 
            // titleProfessions
            // 
            this.titleProfessions.AutoSize = true;
            this.titleProfessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleProfessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleProfessions.ForeColor = System.Drawing.Color.White;
            this.titleProfessions.Location = new System.Drawing.Point(12, 9);
            this.titleProfessions.Name = "titleProfessions";
            this.titleProfessions.Size = new System.Drawing.Size(92, 20);
            this.titleProfessions.TabIndex = 1;
            this.titleProfessions.Text = "Professions";
            // 
            // insertButton_Professions
            // 
            this.insertButton_Professions.AutoSize = true;
            this.insertButton_Professions.BackColor = System.Drawing.Color.Gray;
            this.insertButton_Professions.ForeColor = System.Drawing.Color.Black;
            this.insertButton_Professions.Location = new System.Drawing.Point(308, 16);
            this.insertButton_Professions.Name = "insertButton_Professions";
            this.insertButton_Professions.Size = new System.Drawing.Size(33, 13);
            this.insertButton_Professions.TabIndex = 2;
            this.insertButton_Professions.Text = "Insert";
            this.insertButton_Professions.Visible = false;
            this.insertButton_Professions.Click += new System.EventHandler(this.InsertButtonProfessions_Click);
            // 
            // editButton_Professions
            // 
            this.editButton_Professions.AutoSize = true;
            this.editButton_Professions.BackColor = System.Drawing.Color.Gray;
            this.editButton_Professions.Location = new System.Drawing.Point(347, 16);
            this.editButton_Professions.Name = "editButton_Professions";
            this.editButton_Professions.Size = new System.Drawing.Size(25, 13);
            this.editButton_Professions.TabIndex = 3;
            this.editButton_Professions.Text = "Edit";
            this.editButton_Professions.Click += new System.EventHandler(this.EditButtonProfessions_Click);
            // 
            // dataGridViewResourcesConsumed
            // 
            this.dataGridViewResourcesConsumed.AllowUserToResizeColumns = false;
            this.dataGridViewResourcesConsumed.AllowUserToResizeRows = false;
            this.dataGridViewResourcesConsumed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResourcesConsumed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resource_Consumed,
            this.amount_Consumed});
            this.dataGridViewResourcesConsumed.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewResourcesConsumed.Location = new System.Drawing.Point(329, 359);
            this.dataGridViewResourcesConsumed.Name = "dataGridViewResourcesConsumed";
            this.dataGridViewResourcesConsumed.RowHeadersVisible = false;
            this.dataGridViewResourcesConsumed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewResourcesConsumed.Size = new System.Drawing.Size(210, 290);
            this.dataGridViewResourcesConsumed.TabIndex = 8;
            // 
            // resource_Consumed
            // 
            this.resource_Consumed.DataPropertyName = "resource";
            this.resource_Consumed.HeaderText = "Resource";
            this.resource_Consumed.Name = "resource_Consumed";
            this.resource_Consumed.ReadOnly = true;
            this.resource_Consumed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.resource_Consumed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.resource_Consumed.Width = 140;
            // 
            // amount_Consumed
            // 
            this.amount_Consumed.DataPropertyName = "amount";
            this.amount_Consumed.HeaderText = "Amount";
            this.amount_Consumed.Name = "amount_Consumed";
            this.amount_Consumed.ReadOnly = true;
            this.amount_Consumed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.amount_Consumed.Width = 65;
            // 
            // dataGridViewRecipes
            // 
            this.dataGridViewRecipes.AllowUserToResizeColumns = false;
            this.dataGridViewRecipes.AllowUserToResizeRows = false;
            this.dataGridViewRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewRecipes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name_Recipes,
            this.cost,
            this.profit,
            this.tier1profit,
            this.tier2profit,
            this.tier3profit,
            this.tier1reward,
            this.tier2reward,
            this.tier3reward});
            this.dataGridViewRecipes.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRecipes.Location = new System.Drawing.Point(402, 32);
            this.dataGridViewRecipes.Name = "dataGridViewRecipes";
            this.dataGridViewRecipes.RowHeadersVisible = false;
            this.dataGridViewRecipes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewRecipes.Size = new System.Drawing.Size(420, 267);
            this.dataGridViewRecipes.TabIndex = 9;
            this.dataGridViewRecipes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRecipes_CellClick);
            this.dataGridViewRecipes.SelectionChanged += new System.EventHandler(this.DataGridViewRecipes_SelectionChanged);
            // 
            // name_Recipes
            // 
            this.name_Recipes.DataPropertyName = "recipe";
            this.name_Recipes.HeaderText = "Recipe";
            this.name_Recipes.Name = "name_Recipes";
            this.name_Recipes.ReadOnly = true;
            this.name_Recipes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name_Recipes.Width = 120;
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
            // tier1reward
            // 
            this.tier1reward.DataPropertyName = "tier1reward";
            this.tier1reward.HeaderText = "Tier 1 (reward)";
            this.tier1reward.Name = "tier1reward";
            this.tier1reward.ReadOnly = true;
            this.tier1reward.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier1reward.Visible = false;
            this.tier1reward.Width = 60;
            // 
            // tier2reward
            // 
            this.tier2reward.DataPropertyName = "tier2reward";
            this.tier2reward.HeaderText = "Tier 2 (reward)";
            this.tier2reward.Name = "tier2reward";
            this.tier2reward.ReadOnly = true;
            this.tier2reward.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier2reward.Visible = false;
            this.tier2reward.Width = 60;
            // 
            // tier3reward
            // 
            this.tier3reward.DataPropertyName = "tier3reward";
            this.tier3reward.HeaderText = "Tier 3 (reward)";
            this.tier3reward.Name = "tier3reward";
            this.tier3reward.ReadOnly = true;
            this.tier3reward.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tier3reward.Visible = false;
            this.tier3reward.Width = 60;
            // 
            // titleRecipes
            // 
            this.titleRecipes.AutoSize = true;
            this.titleRecipes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleRecipes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleRecipes.ForeColor = System.Drawing.Color.White;
            this.titleRecipes.Location = new System.Drawing.Point(398, 9);
            this.titleRecipes.Name = "titleRecipes";
            this.titleRecipes.Size = new System.Drawing.Size(67, 20);
            this.titleRecipes.TabIndex = 10;
            this.titleRecipes.Text = "Recipes";
            // 
            // dataGridViewResources
            // 
            this.dataGridViewResources.AllowUserToResizeColumns = false;
            this.dataGridViewResources.AllowUserToResizeRows = false;
            this.dataGridViewResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name_Resources,
            this.price_Resources,
            this.updated_Resources});
            this.dataGridViewResources.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewResources.Location = new System.Drawing.Point(12, 359);
            this.dataGridViewResources.Name = "dataGridViewResources";
            this.dataGridViewResources.RowHeadersVisible = false;
            this.dataGridViewResources.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewResources.Size = new System.Drawing.Size(280, 290);
            this.dataGridViewResources.TabIndex = 11;
            // 
            // name_Resources
            // 
            this.name_Resources.DataPropertyName = "name";
            this.name_Resources.HeaderText = "Resource";
            this.name_Resources.Name = "name_Resources";
            this.name_Resources.ReadOnly = true;
            this.name_Resources.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name_Resources.Width = 140;
            // 
            // price_Resources
            // 
            this.price_Resources.DataPropertyName = "price";
            this.price_Resources.HeaderText = "Cost";
            this.price_Resources.Name = "price_Resources";
            this.price_Resources.ReadOnly = true;
            this.price_Resources.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.price_Resources.Width = 50;
            // 
            // updated_Resources
            // 
            this.updated_Resources.DataPropertyName = "updated";
            this.updated_Resources.HeaderText = "Updated";
            this.updated_Resources.Name = "updated_Resources";
            this.updated_Resources.ReadOnly = true;
            this.updated_Resources.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.updated_Resources.Width = 85;
            // 
            // dataGridViewResourcesResults
            // 
            this.dataGridViewResourcesResults.AllowUserToResizeColumns = false;
            this.dataGridViewResourcesResults.AllowUserToResizeRows = false;
            this.dataGridViewResourcesResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResourcesResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tier_Results,
            this.resource_Results,
            this.amount_Results});
            this.dataGridViewResourcesResults.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewResourcesResults.Location = new System.Drawing.Point(562, 359);
            this.dataGridViewResourcesResults.Name = "dataGridViewResourcesResults";
            this.dataGridViewResourcesResults.RowHeadersVisible = false;
            this.dataGridViewResourcesResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewResourcesResults.Size = new System.Drawing.Size(260, 290);
            this.dataGridViewResourcesResults.TabIndex = 12;
            // 
            // tier_Results
            // 
            this.tier_Results.DataPropertyName = "tier";
            this.tier_Results.HeaderText = "Tier";
            this.tier_Results.Name = "tier_Results";
            this.tier_Results.ReadOnly = true;
            this.tier_Results.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tier_Results.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tier_Results.Width = 50;
            // 
            // resource_Results
            // 
            this.resource_Results.DataPropertyName = "resource";
            this.resource_Results.HeaderText = "Resource";
            this.resource_Results.Name = "resource_Results";
            this.resource_Results.ReadOnly = true;
            this.resource_Results.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.resource_Results.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.resource_Results.Width = 140;
            // 
            // amount_Results
            // 
            this.amount_Results.DataPropertyName = "amount";
            this.amount_Results.HeaderText = "Amount";
            this.amount_Results.Name = "amount_Results";
            this.amount_Results.ReadOnly = true;
            this.amount_Results.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.amount_Results.Width = 65;
            // 
            // titleResources
            // 
            this.titleResources.AutoSize = true;
            this.titleResources.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleResources.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleResources.ForeColor = System.Drawing.Color.White;
            this.titleResources.Location = new System.Drawing.Point(12, 336);
            this.titleResources.Name = "titleResources";
            this.titleResources.Size = new System.Drawing.Size(86, 20);
            this.titleResources.TabIndex = 13;
            this.titleResources.Text = "Resources";
            // 
            // titleResourcesConsumed
            // 
            this.titleResourcesConsumed.AutoSize = true;
            this.titleResourcesConsumed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleResourcesConsumed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleResourcesConsumed.ForeColor = System.Drawing.Color.White;
            this.titleResourcesConsumed.Location = new System.Drawing.Point(325, 336);
            this.titleResourcesConsumed.Name = "titleResourcesConsumed";
            this.titleResourcesConsumed.Size = new System.Drawing.Size(86, 20);
            this.titleResourcesConsumed.TabIndex = 14;
            this.titleResourcesConsumed.Text = "Consumed";
            // 
            // titleResourcesResults
            // 
            this.titleResourcesResults.AutoSize = true;
            this.titleResourcesResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleResourcesResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleResourcesResults.ForeColor = System.Drawing.Color.White;
            this.titleResourcesResults.Location = new System.Drawing.Point(558, 336);
            this.titleResourcesResults.Name = "titleResourcesResults";
            this.titleResourcesResults.Size = new System.Drawing.Size(63, 20);
            this.titleResourcesResults.TabIndex = 15;
            this.titleResourcesResults.Text = "Results";
            // 
            // grade
            // 
            this.grade.DataPropertyName = "grade";
            this.grade.HeaderText = "Grade";
            this.grade.Name = "grade";
            this.grade.ReadOnly = true;
            this.grade.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grade.Width = 50;
            // 
            // upgrade1
            // 
            this.upgrade1.DataPropertyName = "upgrade1";
            this.upgrade1.HeaderText = "I";
            this.upgrade1.Name = "upgrade1";
            this.upgrade1.ReadOnly = true;
            this.upgrade1.Width = 60;
            // 
            // upgrade2
            // 
            this.upgrade2.DataPropertyName = "upgrade2";
            this.upgrade2.HeaderText = "II";
            this.upgrade2.Name = "upgrade2";
            this.upgrade2.ReadOnly = true;
            this.upgrade2.Width = 60;
            // 
            // upgrade3
            // 
            this.upgrade3.DataPropertyName = "upgrade3";
            this.upgrade3.HeaderText = "III";
            this.upgrade3.Name = "upgrade3";
            this.upgrade3.ReadOnly = true;
            this.upgrade3.Width = 60;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.titleResourcesResults);
            this.Controls.Add(this.titleResourcesConsumed);
            this.Controls.Add(this.titleResources);
            this.Controls.Add(this.dataGridViewResourcesResults);
            this.Controls.Add(this.dataGridViewResources);
            this.Controls.Add(this.titleRecipes);
            this.Controls.Add(this.dataGridViewRecipes);
            this.Controls.Add(this.dataGridViewResourcesConsumed);
            this.Controls.Add(this.editButton_Professions);
            this.Controls.Add(this.insertButton_Professions);
            this.Controls.Add(this.titleProfessions);
            this.Controls.Add(this.dataGridViewProfessions);
            this.Name = "Main";
            this.Text = "Mastercrafter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfessions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResourcesConsumed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecipes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResourcesResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewProfessions;
        private System.Windows.Forms.Label insertButton_Professions;
        private System.Windows.Forms.Label editButton_Professions;
        private System.Windows.Forms.Label titleProfessions;
        private System.Windows.Forms.DataGridView dataGridViewResourcesConsumed;
        private System.Windows.Forms.DataGridView dataGridViewRecipes;
        private System.Windows.Forms.Label titleRecipes;
        private System.Windows.Forms.DataGridView dataGridViewResources;
        private System.Windows.Forms.DataGridView dataGridViewResourcesResults;
        private System.Windows.Forms.Label titleResources;
        private System.Windows.Forms.Label titleResourcesConsumed;
        private System.Windows.Forms.Label titleResourcesResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_Resources;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_Resources;
        private System.Windows.Forms.DataGridViewTextBoxColumn updated_Resources;
        private System.Windows.Forms.DataGridViewComboBoxColumn resource_Consumed;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_Consumed;
        private System.Windows.Forms.DataGridViewComboBoxColumn tier_Results;
        private System.Windows.Forms.DataGridViewComboBoxColumn resource_Results;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_Results;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_Recipes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier1profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier2profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier3profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier1reward;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier2reward;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier3reward;
        private System.Windows.Forms.DataGridViewComboBoxColumn grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn upgrade1;
        private System.Windows.Forms.DataGridViewTextBoxColumn upgrade2;
        private System.Windows.Forms.DataGridViewTextBoxColumn upgrade3;
    }
}

