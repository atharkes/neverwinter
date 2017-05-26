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
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grade = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.upgrade1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upgrade2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upgrade3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleProfessions = new System.Windows.Forms.Label();
            this.insertButton_Professions = new System.Windows.Forms.Label();
            this.editButton_Professions = new System.Windows.Forms.Label();
            this.selectAllButtonProfessions = new System.Windows.Forms.Label();
            this.deselectAllButtonProfessions = new System.Windows.Forms.Label();
            this.dataGridViewResourcesConsumed = new System.Windows.Forms.DataGridView();
            this.resource_Consumed = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.amount_Consumed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewRecipes = new System.Windows.Forms.DataGridView();
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
            this.editButton_Recipes = new System.Windows.Forms.Label();
            this.insertButton_Recipes = new System.Windows.Forms.Label();
            this.editButton_Resources = new System.Windows.Forms.Label();
            this.insertButton_Resources = new System.Windows.Forms.Label();
            this.editButton_Consumed = new System.Windows.Forms.Label();
            this.insertButton_Consumed = new System.Windows.Forms.Label();
            this.editButton_Results = new System.Windows.Forms.Label();
            this.insertButton_Results = new System.Windows.Forms.Label();
            this.name_Recipes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier1profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier2profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier3profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier1reward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier2reward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tier3reward = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.name,
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
            this.dataGridViewProfessions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewProfessions_CellDoubleClick);
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
            this.resource_Consumed,
            this.amount_Consumed});
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
            this.dataGridViewRecipes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRecipes_CellDoubleClick);
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
            // editButton_Recipes
            // 
            this.editButton_Recipes.AutoSize = true;
            this.editButton_Recipes.BackColor = System.Drawing.Color.Gray;
            this.editButton_Recipes.Location = new System.Drawing.Point(797, 16);
            this.editButton_Recipes.Name = "editButton_Recipes";
            this.editButton_Recipes.Size = new System.Drawing.Size(25, 13);
            this.editButton_Recipes.TabIndex = 16;
            this.editButton_Recipes.Text = "Edit";
            this.editButton_Recipes.Click += new System.EventHandler(this.EditButton_Recipes_Click);
            // 
            // insertButton_Recipes
            // 
            this.insertButton_Recipes.AutoSize = true;
            this.insertButton_Recipes.BackColor = System.Drawing.Color.Gray;
            this.insertButton_Recipes.ForeColor = System.Drawing.Color.Black;
            this.insertButton_Recipes.Location = new System.Drawing.Point(758, 16);
            this.insertButton_Recipes.Name = "insertButton_Recipes";
            this.insertButton_Recipes.Size = new System.Drawing.Size(33, 13);
            this.insertButton_Recipes.TabIndex = 17;
            this.insertButton_Recipes.Text = "Insert";
            this.insertButton_Recipes.Visible = false;
            this.insertButton_Recipes.Click += new System.EventHandler(this.InsertButton_Recipes_Click);
            // 
            // editButton_Resources
            // 
            this.editButton_Resources.AutoSize = true;
            this.editButton_Resources.BackColor = System.Drawing.Color.Gray;
            this.editButton_Resources.Location = new System.Drawing.Point(267, 343);
            this.editButton_Resources.Name = "editButton_Resources";
            this.editButton_Resources.Size = new System.Drawing.Size(25, 13);
            this.editButton_Resources.TabIndex = 18;
            this.editButton_Resources.Text = "Edit";
            this.editButton_Resources.Click += new System.EventHandler(this.EditButton_Resources_Click);
            // 
            // insertButton_Resources
            // 
            this.insertButton_Resources.AutoSize = true;
            this.insertButton_Resources.BackColor = System.Drawing.Color.Gray;
            this.insertButton_Resources.ForeColor = System.Drawing.Color.Black;
            this.insertButton_Resources.Location = new System.Drawing.Point(228, 343);
            this.insertButton_Resources.Name = "insertButton_Resources";
            this.insertButton_Resources.Size = new System.Drawing.Size(33, 13);
            this.insertButton_Resources.TabIndex = 19;
            this.insertButton_Resources.Text = "Insert";
            this.insertButton_Resources.Visible = false;
            this.insertButton_Resources.Click += new System.EventHandler(this.InsertButton_Resources_Click);
            // 
            // editButton_Consumed
            // 
            this.editButton_Consumed.AutoSize = true;
            this.editButton_Consumed.BackColor = System.Drawing.Color.Gray;
            this.editButton_Consumed.Location = new System.Drawing.Point(514, 343);
            this.editButton_Consumed.Name = "editButton_Consumed";
            this.editButton_Consumed.Size = new System.Drawing.Size(25, 13);
            this.editButton_Consumed.TabIndex = 20;
            this.editButton_Consumed.Text = "Edit";
            // 
            // insertButton_Consumed
            // 
            this.insertButton_Consumed.AutoSize = true;
            this.insertButton_Consumed.BackColor = System.Drawing.Color.Gray;
            this.insertButton_Consumed.ForeColor = System.Drawing.Color.Black;
            this.insertButton_Consumed.Location = new System.Drawing.Point(475, 343);
            this.insertButton_Consumed.Name = "insertButton_Consumed";
            this.insertButton_Consumed.Size = new System.Drawing.Size(33, 13);
            this.insertButton_Consumed.TabIndex = 21;
            this.insertButton_Consumed.Text = "Insert";
            this.insertButton_Consumed.Visible = false;
            // 
            // editButton_Results
            // 
            this.editButton_Results.AutoSize = true;
            this.editButton_Results.BackColor = System.Drawing.Color.Gray;
            this.editButton_Results.Location = new System.Drawing.Point(797, 343);
            this.editButton_Results.Name = "editButton_Results";
            this.editButton_Results.Size = new System.Drawing.Size(25, 13);
            this.editButton_Results.TabIndex = 22;
            this.editButton_Results.Text = "Edit";
            // 
            // insertButton_Results
            // 
            this.insertButton_Results.AutoSize = true;
            this.insertButton_Results.BackColor = System.Drawing.Color.Gray;
            this.insertButton_Results.ForeColor = System.Drawing.Color.Black;
            this.insertButton_Results.Location = new System.Drawing.Point(758, 343);
            this.insertButton_Results.Name = "insertButton_Results";
            this.insertButton_Results.Size = new System.Drawing.Size(33, 13);
            this.insertButton_Results.TabIndex = 23;
            this.insertButton_Results.Text = "Insert";
            this.insertButton_Results.Visible = false;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.insertButton_Results);
            this.Controls.Add(this.editButton_Results);
            this.Controls.Add(this.insertButton_Consumed);
            this.Controls.Add(this.editButton_Consumed);
            this.Controls.Add(this.insertButton_Resources);
            this.Controls.Add(this.editButton_Resources);
            this.Controls.Add(this.insertButton_Recipes);
            this.Controls.Add(this.editButton_Recipes);
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
        private System.Windows.Forms.Label selectAllButtonProfessions;
        private System.Windows.Forms.Label deselectAllButtonProfessions;
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
        private System.Windows.Forms.Label editButton_Recipes;
        private System.Windows.Forms.Label insertButton_Recipes;
        private System.Windows.Forms.Label editButton_Resources;
        private System.Windows.Forms.Label insertButton_Resources;
        private System.Windows.Forms.Label editButton_Consumed;
        private System.Windows.Forms.Label insertButton_Consumed;
        private System.Windows.Forms.Label editButton_Results;
        private System.Windows.Forms.Label insertButton_Results;
        private System.Windows.Forms.DataGridViewComboBoxColumn tier_Results;
        private System.Windows.Forms.DataGridViewComboBoxColumn resource_Results;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_Results;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn upgrade1;
        private System.Windows.Forms.DataGridViewTextBoxColumn upgrade2;
        private System.Windows.Forms.DataGridViewTextBoxColumn upgrade3;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_Recipes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier1profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier2profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier3profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier1reward;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier2reward;
        private System.Windows.Forms.DataGridViewTextBoxColumn tier3reward;
    }
}

