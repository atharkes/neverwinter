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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewProfessions = new System.Windows.Forms.DataGridView();
            this.titleProfessions = new System.Windows.Forms.Label();
            this.insertButtonProfessions = new System.Windows.Forms.Label();
            this.editButtonProfessions = new System.Windows.Forms.Label();
            this.selectAllButtonProfessions = new System.Windows.Forms.Label();
            this.deselectAllButtonProfessions = new System.Windows.Forms.Label();
            this.dataGridViewResourcesConsumed = new System.Windows.Forms.DataGridView();
            this.resource = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewRecipes = new System.Windows.Forms.DataGridView();
            this.filterRecipe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier1profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier2profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier3profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleRecipes = new System.Windows.Forms.Label();
            this.dataGridViewResources = new System.Windows.Forms.DataGridView();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewResourcesResults = new System.Windows.Forms.DataGridView();
            this.tier = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleResources = new System.Windows.Forms.Label();
            this.titleResourcesConsumed = new System.Windows.Forms.Label();
            this.titleResourcesResults = new System.Windows.Forms.Label();
            this.filterProfessions = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.filterProfessions,
            this.name,
            this.tool,
            this.toolCost,
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
            this.dataGridViewProfessions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewProfessions_CellDoubleClick);
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
            // insertButtonProfessions
            // 
            this.insertButtonProfessions.AutoSize = true;
            this.insertButtonProfessions.BackColor = System.Drawing.Color.Gray;
            this.insertButtonProfessions.ForeColor = System.Drawing.Color.Black;
            this.insertButtonProfessions.Location = new System.Drawing.Point(308, 16);
            this.insertButtonProfessions.Name = "insertButtonProfessions";
            this.insertButtonProfessions.Size = new System.Drawing.Size(33, 13);
            this.insertButtonProfessions.TabIndex = 2;
            this.insertButtonProfessions.Text = "Insert";
            this.insertButtonProfessions.Click += new System.EventHandler(this.InsertButtonProfessions_Click);
            // 
            // editButtonProfessions
            // 
            this.editButtonProfessions.AutoSize = true;
            this.editButtonProfessions.BackColor = System.Drawing.Color.Gray;
            this.editButtonProfessions.Location = new System.Drawing.Point(347, 16);
            this.editButtonProfessions.Name = "editButtonProfessions";
            this.editButtonProfessions.Size = new System.Drawing.Size(25, 13);
            this.editButtonProfessions.TabIndex = 3;
            this.editButtonProfessions.Text = "Edit";
            this.editButtonProfessions.Click += new System.EventHandler(this.EditButtonProfessions_Click);
            // 
            // selectAllButtonProfessions
            // 
            this.selectAllButtonProfessions.AutoSize = true;
            this.selectAllButtonProfessions.BackColor = System.Drawing.Color.Gray;
            this.selectAllButtonProfessions.Location = new System.Drawing.Point(110, 16);
            this.selectAllButtonProfessions.Name = "selectAllButtonProfessions";
            this.selectAllButtonProfessions.Size = new System.Drawing.Size(51, 13);
            this.selectAllButtonProfessions.TabIndex = 4;
            this.selectAllButtonProfessions.Text = "Select All";
            // 
            // deselectAllButtonProfessions
            // 
            this.deselectAllButtonProfessions.AutoSize = true;
            this.deselectAllButtonProfessions.BackColor = System.Drawing.Color.Gray;
            this.deselectAllButtonProfessions.Location = new System.Drawing.Point(167, 16);
            this.deselectAllButtonProfessions.Name = "deselectAllButtonProfessions";
            this.deselectAllButtonProfessions.Size = new System.Drawing.Size(63, 13);
            this.deselectAllButtonProfessions.TabIndex = 5;
            this.deselectAllButtonProfessions.Text = "Deselect All";
            // 
            // dataGridViewResourcesConsumed
            // 
            this.dataGridViewResourcesConsumed.AllowUserToResizeColumns = false;
            this.dataGridViewResourcesConsumed.AllowUserToResizeRows = false;
            this.dataGridViewResourcesConsumed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResourcesConsumed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resource,
            this.amount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewResourcesConsumed.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewResourcesConsumed.Location = new System.Drawing.Point(329, 359);
            this.dataGridViewResourcesConsumed.Name = "dataGridViewResourcesConsumed";
            this.dataGridViewResourcesConsumed.RowHeadersVisible = false;
            this.dataGridViewResourcesConsumed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewResourcesConsumed.Size = new System.Drawing.Size(210, 290);
            this.dataGridViewResourcesConsumed.TabIndex = 8;
            // 
            // resource
            // 
            this.resource.DataPropertyName = "resource";
            this.resource.HeaderText = "Resource";
            this.resource.Name = "resource";
            this.resource.ReadOnly = true;
            this.resource.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.resource.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.resource.Width = 140;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.amount.Width = 65;
            // 
            // dataGridViewRecipes
            // 
            this.dataGridViewRecipes.AllowUserToResizeColumns = false;
            this.dataGridViewRecipes.AllowUserToResizeRows = false;
            this.dataGridViewRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewRecipes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filterRecipe,
            this.dataGridViewTextBoxColumn1,
            this.cost,
            this.profit,
            this.tier1profit,
            this.tier2profit,
            this.tier3profit,
            this.tier1,
            this.tier2,
            this.tier3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRecipes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewRecipes.Location = new System.Drawing.Point(402, 32);
            this.dataGridViewRecipes.Name = "dataGridViewRecipes";
            this.dataGridViewRecipes.RowHeadersVisible = false;
            this.dataGridViewRecipes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewRecipes.Size = new System.Drawing.Size(420, 267);
            this.dataGridViewRecipes.TabIndex = 9;
            // 
            // filterRecipe
            // 
            this.filterRecipe.DataPropertyName = "filterRecipe";
            this.filterRecipe.HeaderText = "Filter";
            this.filterRecipe.Name = "filterRecipe";
            this.filterRecipe.ReadOnly = true;
            this.filterRecipe.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "recipe";
            this.dataGridViewTextBoxColumn1.HeaderText = "Recipe";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 120;
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
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewResources.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewResources.Location = new System.Drawing.Point(12, 359);
            this.dataGridViewResources.Name = "dataGridViewResources";
            this.dataGridViewResources.RowHeadersVisible = false;
            this.dataGridViewResources.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewResources.Size = new System.Drawing.Size(280, 290);
            this.dataGridViewResources.TabIndex = 11;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "resource";
            this.dataGridViewComboBoxColumn1.HeaderText = "Resource";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewComboBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "price";
            this.dataGridViewTextBoxColumn3.HeaderText = "Cost";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "updated";
            this.dataGridViewTextBoxColumn4.HeaderText = "Updated";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 85;
            // 
            // dataGridViewResourcesResults
            // 
            this.dataGridViewResourcesResults.AllowUserToResizeColumns = false;
            this.dataGridViewResourcesResults.AllowUserToResizeRows = false;
            this.dataGridViewResourcesResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResourcesResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tier,
            this.dataGridViewComboBoxColumn2,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewResourcesResults.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewResourcesResults.Location = new System.Drawing.Point(562, 359);
            this.dataGridViewResourcesResults.Name = "dataGridViewResourcesResults";
            this.dataGridViewResourcesResults.RowHeadersVisible = false;
            this.dataGridViewResourcesResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewResourcesResults.Size = new System.Drawing.Size(260, 290);
            this.dataGridViewResourcesResults.TabIndex = 12;
            // 
            // tier
            // 
            this.tier.HeaderText = "Tier";
            this.tier.Name = "tier";
            this.tier.ReadOnly = true;
            this.tier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tier.Width = 50;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "resource";
            this.dataGridViewComboBoxColumn2.HeaderText = "Resource";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.ReadOnly = true;
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "amount";
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 65;
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
            // filterProfessions
            // 
            this.filterProfessions.DataPropertyName = "filterProfessions";
            this.filterProfessions.HeaderText = "Filter";
            this.filterProfessions.Name = "filterProfessions";
            this.filterProfessions.ReadOnly = true;
            this.filterProfessions.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.filterProfessions.Width = 40;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Profession";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.Width = 120;
            // 
            // tool
            // 
            this.tool.DataPropertyName = "tool";
            this.tool.HeaderText = "Tool";
            this.tool.Name = "tool";
            this.tool.ReadOnly = true;
            this.tool.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tool.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tool.Width = 50;
            // 
            // toolCost
            // 
            this.toolCost.DataPropertyName = "toolCost";
            this.toolCost.HeaderText = "Tool Cost";
            this.toolCost.Name = "toolCost";
            this.toolCost.ReadOnly = true;
            this.toolCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.toolCost.Width = 70;
            // 
            // upgrade3
            // 
            this.upgrade3.DataPropertyName = "upgrade3";
            this.upgrade3.HeaderText = "III";
            this.upgrade3.Name = "upgrade3";
            this.upgrade3.ReadOnly = true;
            this.upgrade3.Width = 75;
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
            this.Controls.Add(this.deselectAllButtonProfessions);
            this.Controls.Add(this.selectAllButtonProfessions);
            this.Controls.Add(this.editButtonProfessions);
            this.Controls.Add(this.insertButtonProfessions);
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
        private System.Windows.Forms.Label insertButtonProfessions;
        private System.Windows.Forms.Label editButtonProfessions;
        private System.Windows.Forms.Label selectAllButtonProfessions;
        private System.Windows.Forms.Label deselectAllButtonProfessions;
        private System.Windows.Forms.Label titleProfessions;
        private System.Windows.Forms.DataGridView dataGridViewResourcesConsumed;
        private System.Windows.Forms.DataGridView dataGridViewRecipes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn filterRecipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier1profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier2profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier3profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier3;
        private System.Windows.Forms.Label titleRecipes;
        private System.Windows.Forms.DataGridView dataGridViewResources;
        private System.Windows.Forms.DataGridView dataGridViewResourcesResults;
        private System.Windows.Forms.Label titleResources;
        private System.Windows.Forms.Label titleResourcesConsumed;
        private System.Windows.Forms.Label titleResourcesResults;
        private System.Windows.Forms.DataGridViewComboBoxColumn tier;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn filterProfessions;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn tool;
        private System.Windows.Forms.DataGridViewTextBoxColumn toolCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn upgrade3;
    }
}

