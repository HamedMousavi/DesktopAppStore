namespace DataAdministration
{
    partial class FrmMain
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tpgArticle = new System.Windows.Forms.TabPage();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tpgUsers = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvBackup = new System.Windows.Forms.DataGridView();
            this.dgvUpdate = new System.Windows.Forms.DataGridView();
            this.dgvCustomization = new System.Windows.Forms.DataGridView();
            this.dgvEnvironment = new System.Windows.Forms.DataGridView();
            this.dgvGuaranty = new System.Windows.Forms.DataGridView();
            this.dgvSupportTypes = new System.Windows.Forms.DataGridView();
            this.dgvSupportOptions = new System.Windows.Forms.DataGridView();
            this.dgvTraining = new System.Windows.Forms.DataGridView();
            this.dgvInstallation = new System.Windows.Forms.DataGridView();
            this.dgvDemo = new System.Windows.Forms.DataGridView();
            this.dgvPublish = new System.Windows.Forms.DataGridView();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.dgvExtension = new System.Windows.Forms.DataGridView();
            this.dgvLanguages = new System.Windows.Forms.DataGridView();
            this.dgvCategoryTags = new System.Windows.Forms.DataGridView();
            this.dgvTechnologies = new System.Windows.Forms.DataGridView();
            this.dgvSource = new System.Windows.Forms.DataGridView();
            this.dgvPlatforms = new System.Windows.Forms.DataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.persianSoftwareDataSet = new DataAdministration.PersianSoftwareDataSet();
            this.listSoftwarePlatformsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listSoftwarePlatformsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListSoftwarePlatformsTableAdapter();
            this.platformIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platformNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listSourceOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listSourceOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListSourceOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listProductTechnologiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listProductTechnologiesTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListProductTechnologiesTableAdapter();
            this.technologyIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.technologyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listCategoryTagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listCategoryTagsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListCategoryTagsTableAdapter();
            this.tagIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listLanguagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listLanguagesTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListLanguagesTableAdapter();
            this.languageIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languageLocalNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listInstallationOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listInstallationOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListInstallationOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listDemoOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listDemoOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListDemoOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listPublishOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listPublishOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListPublishOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listPaymentOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listPaymentOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListPaymentOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listExtensionOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listExtensionOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListExtensionOptionsTableAdapter();
            this.extensionOptionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionOptionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listTrainingOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listTrainingOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListTrainingOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listEnvironmentOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listEnvironmentOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListEnvironmentOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listGuarantyOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listGuarantyOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListGuarantyOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listSupportTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listSupportTypesTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListSupportTypesTableAdapter();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listSupportOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listSupportOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListSupportOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listDataBackupOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listDataBackupOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListDataBackupOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listUpdateOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listUpdateOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListUpdateOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listCustomizationOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listCustomizationOptionsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListCustomizationOptionsTableAdapter();
            this.optionIdDataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionNameDataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlMain.SuspendLayout();
            this.tpgArticle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnvironment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuaranty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupportTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupportOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstallation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnologies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatforms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSoftwarePlatformsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSourceOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listProductTechnologiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listCategoryTagsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listLanguagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listInstallationOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDemoOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listPublishOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listPaymentOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listExtensionOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listTrainingOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEnvironmentOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listGuarantyOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSupportTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSupportOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDataBackupOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listUpdateOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listCustomizationOptionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tpgArticle);
            this.tabControlMain.Controls.Add(this.tpgUsers);
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(687, 605);
            this.tabControlMain.TabIndex = 0;
            // 
            // tpgArticle
            // 
            this.tpgArticle.Controls.Add(this.btnRemove);
            this.tpgArticle.Controls.Add(this.btnEdit);
            this.tpgArticle.Controls.Add(this.btnAdd);
            this.tpgArticle.Controls.Add(this.dataGridView1);
            this.tpgArticle.Location = new System.Drawing.Point(4, 22);
            this.tpgArticle.Name = "tpgArticle";
            this.tpgArticle.Padding = new System.Windows.Forms.Padding(3);
            this.tpgArticle.Size = new System.Drawing.Size(679, 579);
            this.tpgArticle.TabIndex = 0;
            this.tpgArticle.Text = "Products";
            this.tpgArticle.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(504, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(585, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(676, 541);
            this.dataGridView1.TabIndex = 2;
            // 
            // tpgUsers
            // 
            this.tpgUsers.Location = new System.Drawing.Point(4, 22);
            this.tpgUsers.Name = "tpgUsers";
            this.tpgUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpgUsers.Size = new System.Drawing.Size(679, 579);
            this.tpgUsers.TabIndex = 1;
            this.tpgUsers.Text = "Users";
            this.tpgUsers.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.dgvBackup);
            this.tabPage1.Controls.Add(this.dgvUpdate);
            this.tabPage1.Controls.Add(this.dgvCustomization);
            this.tabPage1.Controls.Add(this.dgvEnvironment);
            this.tabPage1.Controls.Add(this.dgvGuaranty);
            this.tabPage1.Controls.Add(this.dgvSupportTypes);
            this.tabPage1.Controls.Add(this.dgvSupportOptions);
            this.tabPage1.Controls.Add(this.dgvTraining);
            this.tabPage1.Controls.Add(this.dgvInstallation);
            this.tabPage1.Controls.Add(this.dgvDemo);
            this.tabPage1.Controls.Add(this.dgvPublish);
            this.tabPage1.Controls.Add(this.dgvPayment);
            this.tabPage1.Controls.Add(this.dgvExtension);
            this.tabPage1.Controls.Add(this.dgvLanguages);
            this.tabPage1.Controls.Add(this.dgvCategoryTags);
            this.tabPage1.Controls.Add(this.dgvTechnologies);
            this.tabPage1.Controls.Add(this.dgvSource);
            this.tabPage1.Controls.Add(this.dgvPlatforms);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 579);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Primary details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(596, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvBackup
            // 
            this.dgvBackup.AutoGenerateColumns = false;
            this.dgvBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn9,
            this.optionNameDataGridViewTextBoxColumn9});
            this.dgvBackup.DataSource = this.listDataBackupOptionsBindingSource;
            this.dgvBackup.Location = new System.Drawing.Point(288, 409);
            this.dgvBackup.Name = "dgvBackup";
            this.dgvBackup.RowHeadersVisible = false;
            this.dgvBackup.Size = new System.Drawing.Size(113, 90);
            this.dgvBackup.TabIndex = 48;
            // 
            // dgvUpdate
            // 
            this.dgvUpdate.AutoGenerateColumns = false;
            this.dgvUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn10,
            this.optionNameDataGridViewTextBoxColumn10});
            this.dgvUpdate.DataSource = this.listUpdateOptionsBindingSource;
            this.dgvUpdate.Location = new System.Drawing.Point(160, 409);
            this.dgvUpdate.Name = "dgvUpdate";
            this.dgvUpdate.RowHeadersVisible = false;
            this.dgvUpdate.Size = new System.Drawing.Size(113, 90);
            this.dgvUpdate.TabIndex = 48;
            // 
            // dgvCustomization
            // 
            this.dgvCustomization.AutoGenerateColumns = false;
            this.dgvCustomization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomization.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn11,
            this.optionNameDataGridViewTextBoxColumn11});
            this.dgvCustomization.DataSource = this.listCustomizationOptionsBindingSource;
            this.dgvCustomization.Location = new System.Drawing.Point(34, 409);
            this.dgvCustomization.Name = "dgvCustomization";
            this.dgvCustomization.RowHeadersVisible = false;
            this.dgvCustomization.Size = new System.Drawing.Size(113, 90);
            this.dgvCustomization.TabIndex = 48;
            // 
            // dgvEnvironment
            // 
            this.dgvEnvironment.AutoGenerateColumns = false;
            this.dgvEnvironment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnvironment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn6,
            this.optionNameDataGridViewTextBoxColumn6});
            this.dgvEnvironment.DataSource = this.listEnvironmentOptionsBindingSource;
            this.dgvEnvironment.Location = new System.Drawing.Point(541, 285);
            this.dgvEnvironment.Name = "dgvEnvironment";
            this.dgvEnvironment.RowHeadersVisible = false;
            this.dgvEnvironment.Size = new System.Drawing.Size(113, 90);
            this.dgvEnvironment.TabIndex = 48;
            // 
            // dgvGuaranty
            // 
            this.dgvGuaranty.AutoGenerateColumns = false;
            this.dgvGuaranty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuaranty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn7,
            this.optionNameDataGridViewTextBoxColumn7,
            this.limitationsDataGridViewTextBoxColumn});
            this.dgvGuaranty.DataSource = this.listGuarantyOptionsBindingSource;
            this.dgvGuaranty.Location = new System.Drawing.Point(412, 285);
            this.dgvGuaranty.Name = "dgvGuaranty";
            this.dgvGuaranty.RowHeadersVisible = false;
            this.dgvGuaranty.Size = new System.Drawing.Size(113, 90);
            this.dgvGuaranty.TabIndex = 48;
            // 
            // dgvSupportTypes
            // 
            this.dgvSupportTypes.AutoGenerateColumns = false;
            this.dgvSupportTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupportTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeIdDataGridViewTextBoxColumn,
            this.typeNameDataGridViewTextBoxColumn});
            this.dgvSupportTypes.DataSource = this.listSupportTypesBindingSource;
            this.dgvSupportTypes.Location = new System.Drawing.Point(288, 285);
            this.dgvSupportTypes.Name = "dgvSupportTypes";
            this.dgvSupportTypes.RowHeadersVisible = false;
            this.dgvSupportTypes.Size = new System.Drawing.Size(113, 90);
            this.dgvSupportTypes.TabIndex = 48;
            // 
            // dgvSupportOptions
            // 
            this.dgvSupportOptions.AutoGenerateColumns = false;
            this.dgvSupportOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupportOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn8,
            this.optionNameDataGridViewTextBoxColumn8});
            this.dgvSupportOptions.DataSource = this.listSupportOptionsBindingSource;
            this.dgvSupportOptions.Location = new System.Drawing.Point(160, 285);
            this.dgvSupportOptions.Name = "dgvSupportOptions";
            this.dgvSupportOptions.RowHeadersVisible = false;
            this.dgvSupportOptions.Size = new System.Drawing.Size(113, 90);
            this.dgvSupportOptions.TabIndex = 48;
            // 
            // dgvTraining
            // 
            this.dgvTraining.AutoGenerateColumns = false;
            this.dgvTraining.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraining.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn5,
            this.optionNameDataGridViewTextBoxColumn5});
            this.dgvTraining.DataSource = this.listTrainingOptionsBindingSource;
            this.dgvTraining.Location = new System.Drawing.Point(34, 285);
            this.dgvTraining.Name = "dgvTraining";
            this.dgvTraining.RowHeadersVisible = false;
            this.dgvTraining.Size = new System.Drawing.Size(113, 90);
            this.dgvTraining.TabIndex = 48;
            // 
            // dgvInstallation
            // 
            this.dgvInstallation.AutoGenerateColumns = false;
            this.dgvInstallation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstallation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn1,
            this.optionNameDataGridViewTextBoxColumn1});
            this.dgvInstallation.DataSource = this.listInstallationOptionsBindingSource;
            this.dgvInstallation.Location = new System.Drawing.Point(538, 161);
            this.dgvInstallation.Name = "dgvInstallation";
            this.dgvInstallation.RowHeadersVisible = false;
            this.dgvInstallation.Size = new System.Drawing.Size(113, 90);
            this.dgvInstallation.TabIndex = 48;
            // 
            // dgvDemo
            // 
            this.dgvDemo.AutoGenerateColumns = false;
            this.dgvDemo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn2,
            this.optionNameDataGridViewTextBoxColumn2});
            this.dgvDemo.DataSource = this.listDemoOptionsBindingSource;
            this.dgvDemo.Location = new System.Drawing.Point(412, 161);
            this.dgvDemo.Name = "dgvDemo";
            this.dgvDemo.RowHeadersVisible = false;
            this.dgvDemo.Size = new System.Drawing.Size(113, 90);
            this.dgvDemo.TabIndex = 48;
            // 
            // dgvPublish
            // 
            this.dgvPublish.AutoGenerateColumns = false;
            this.dgvPublish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn3,
            this.optionNameDataGridViewTextBoxColumn3});
            this.dgvPublish.DataSource = this.listPublishOptionsBindingSource;
            this.dgvPublish.Location = new System.Drawing.Point(286, 161);
            this.dgvPublish.Name = "dgvPublish";
            this.dgvPublish.RowHeadersVisible = false;
            this.dgvPublish.Size = new System.Drawing.Size(113, 90);
            this.dgvPublish.TabIndex = 48;
            // 
            // dgvPayment
            // 
            this.dgvPayment.AutoGenerateColumns = false;
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn4,
            this.optionNameDataGridViewTextBoxColumn4});
            this.dgvPayment.DataSource = this.listPaymentOptionsBindingSource;
            this.dgvPayment.Location = new System.Drawing.Point(160, 161);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.RowHeadersVisible = false;
            this.dgvPayment.Size = new System.Drawing.Size(113, 90);
            this.dgvPayment.TabIndex = 48;
            // 
            // dgvExtension
            // 
            this.dgvExtension.AutoGenerateColumns = false;
            this.dgvExtension.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtension.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.extensionOptionIdDataGridViewTextBoxColumn,
            this.extensionOptionNameDataGridViewTextBoxColumn});
            this.dgvExtension.DataSource = this.listExtensionOptionsBindingSource;
            this.dgvExtension.Location = new System.Drawing.Point(34, 161);
            this.dgvExtension.Name = "dgvExtension";
            this.dgvExtension.RowHeadersVisible = false;
            this.dgvExtension.Size = new System.Drawing.Size(113, 90);
            this.dgvExtension.TabIndex = 48;
            // 
            // dgvLanguages
            // 
            this.dgvLanguages.AutoGenerateColumns = false;
            this.dgvLanguages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanguages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.languageIdDataGridViewTextBoxColumn,
            this.languageNameDataGridViewTextBoxColumn,
            this.languageLocalNameDataGridViewTextBoxColumn});
            this.dgvLanguages.DataSource = this.listLanguagesBindingSource;
            this.dgvLanguages.Location = new System.Drawing.Point(538, 38);
            this.dgvLanguages.Name = "dgvLanguages";
            this.dgvLanguages.RowHeadersVisible = false;
            this.dgvLanguages.Size = new System.Drawing.Size(113, 90);
            this.dgvLanguages.TabIndex = 48;
            // 
            // dgvCategoryTags
            // 
            this.dgvCategoryTags.AutoGenerateColumns = false;
            this.dgvCategoryTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagIdDataGridViewTextBoxColumn,
            this.tagNameDataGridViewTextBoxColumn});
            this.dgvCategoryTags.DataSource = this.listCategoryTagsBindingSource;
            this.dgvCategoryTags.Location = new System.Drawing.Point(412, 38);
            this.dgvCategoryTags.Name = "dgvCategoryTags";
            this.dgvCategoryTags.RowHeadersVisible = false;
            this.dgvCategoryTags.Size = new System.Drawing.Size(113, 90);
            this.dgvCategoryTags.TabIndex = 48;
            // 
            // dgvTechnologies
            // 
            this.dgvTechnologies.AutoGenerateColumns = false;
            this.dgvTechnologies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTechnologies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.technologyIdDataGridViewTextBoxColumn,
            this.technologyNameDataGridViewTextBoxColumn});
            this.dgvTechnologies.DataSource = this.listProductTechnologiesBindingSource;
            this.dgvTechnologies.Location = new System.Drawing.Point(286, 38);
            this.dgvTechnologies.Name = "dgvTechnologies";
            this.dgvTechnologies.RowHeadersVisible = false;
            this.dgvTechnologies.Size = new System.Drawing.Size(113, 90);
            this.dgvTechnologies.TabIndex = 48;
            // 
            // dgvSource
            // 
            this.dgvSource.AutoGenerateColumns = false;
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionIdDataGridViewTextBoxColumn,
            this.optionNameDataGridViewTextBoxColumn});
            this.dgvSource.DataSource = this.listSourceOptionsBindingSource;
            this.dgvSource.Location = new System.Drawing.Point(160, 38);
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.RowHeadersVisible = false;
            this.dgvSource.Size = new System.Drawing.Size(113, 90);
            this.dgvSource.TabIndex = 48;
            // 
            // dgvPlatforms
            // 
            this.dgvPlatforms.AutoGenerateColumns = false;
            this.dgvPlatforms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlatforms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.platformIdDataGridViewTextBoxColumn,
            this.platformNameDataGridViewTextBoxColumn});
            this.dgvPlatforms.DataSource = this.listSoftwarePlatformsBindingSource;
            this.dgvPlatforms.Location = new System.Drawing.Point(34, 38);
            this.dgvPlatforms.Name = "dgvPlatforms";
            this.dgvPlatforms.RowHeadersVisible = false;
            this.dgvPlatforms.ShowCellToolTips = false;
            this.dgvPlatforms.Size = new System.Drawing.Size(113, 90);
            this.dgvPlatforms.TabIndex = 48;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(285, 393);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(44, 13);
            this.label28.TabIndex = 16;
            this.label28.Text = "Backup";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(283, 269);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(76, 13);
            this.label25.TabIndex = 15;
            this.label25.Text = "Support Types";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(409, 22);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(73, 13);
            this.label29.TabIndex = 17;
            this.label29.Text = "CategoryTags";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(535, 22);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(60, 13);
            this.label27.TabIndex = 19;
            this.label27.Text = "Languages";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(409, 145);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "Demo";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(157, 393);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 13);
            this.label24.TabIndex = 11;
            this.label24.Text = "Update";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(283, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Publish";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(535, 145);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 13);
            this.label23.TabIndex = 12;
            this.label23.Text = "Installation";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(157, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Payment";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(31, 393);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Customization";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(538, 269);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 13);
            this.label26.TabIndex = 27;
            this.label26.Text = "Environment";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Extension";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(409, 269);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "Guaranty";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(283, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Technologies";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(157, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Source";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(157, 269);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "SupportOptions";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(31, 269);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Training";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Platforms";
            // 
            // persianSoftwareDataSet
            // 
            this.persianSoftwareDataSet.DataSetName = "PersianSoftwareDataSet";
            this.persianSoftwareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listSoftwarePlatformsBindingSource
            // 
            this.listSoftwarePlatformsBindingSource.DataMember = "ListSoftwarePlatforms";
            this.listSoftwarePlatformsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listSoftwarePlatformsTableAdapter
            // 
            this.listSoftwarePlatformsTableAdapter.ClearBeforeFill = true;
            // 
            // platformIdDataGridViewTextBoxColumn
            // 
            this.platformIdDataGridViewTextBoxColumn.DataPropertyName = "PlatformId";
            this.platformIdDataGridViewTextBoxColumn.HeaderText = "PlatformId";
            this.platformIdDataGridViewTextBoxColumn.Name = "platformIdDataGridViewTextBoxColumn";
            this.platformIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // platformNameDataGridViewTextBoxColumn
            // 
            this.platformNameDataGridViewTextBoxColumn.DataPropertyName = "PlatformName";
            this.platformNameDataGridViewTextBoxColumn.HeaderText = "PlatformName";
            this.platformNameDataGridViewTextBoxColumn.Name = "platformNameDataGridViewTextBoxColumn";
            // 
            // listSourceOptionsBindingSource
            // 
            this.listSourceOptionsBindingSource.DataMember = "ListSourceOptions";
            this.listSourceOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listSourceOptionsTableAdapter
            // 
            this.listSourceOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn
            // 
            this.optionIdDataGridViewTextBoxColumn.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn.Name = "optionIdDataGridViewTextBoxColumn";
            this.optionIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn
            // 
            this.optionNameDataGridViewTextBoxColumn.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn.Name = "optionNameDataGridViewTextBoxColumn";
            // 
            // listProductTechnologiesBindingSource
            // 
            this.listProductTechnologiesBindingSource.DataMember = "ListProductTechnologies";
            this.listProductTechnologiesBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listProductTechnologiesTableAdapter
            // 
            this.listProductTechnologiesTableAdapter.ClearBeforeFill = true;
            // 
            // technologyIdDataGridViewTextBoxColumn
            // 
            this.technologyIdDataGridViewTextBoxColumn.DataPropertyName = "TechnologyId";
            this.technologyIdDataGridViewTextBoxColumn.HeaderText = "TechnologyId";
            this.technologyIdDataGridViewTextBoxColumn.Name = "technologyIdDataGridViewTextBoxColumn";
            this.technologyIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // technologyNameDataGridViewTextBoxColumn
            // 
            this.technologyNameDataGridViewTextBoxColumn.DataPropertyName = "TechnologyName";
            this.technologyNameDataGridViewTextBoxColumn.HeaderText = "TechnologyName";
            this.technologyNameDataGridViewTextBoxColumn.Name = "technologyNameDataGridViewTextBoxColumn";
            // 
            // listCategoryTagsBindingSource
            // 
            this.listCategoryTagsBindingSource.DataMember = "ListCategoryTags";
            this.listCategoryTagsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listCategoryTagsTableAdapter
            // 
            this.listCategoryTagsTableAdapter.ClearBeforeFill = true;
            // 
            // tagIdDataGridViewTextBoxColumn
            // 
            this.tagIdDataGridViewTextBoxColumn.DataPropertyName = "TagId";
            this.tagIdDataGridViewTextBoxColumn.HeaderText = "TagId";
            this.tagIdDataGridViewTextBoxColumn.Name = "tagIdDataGridViewTextBoxColumn";
            this.tagIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tagNameDataGridViewTextBoxColumn
            // 
            this.tagNameDataGridViewTextBoxColumn.DataPropertyName = "TagName";
            this.tagNameDataGridViewTextBoxColumn.HeaderText = "TagName";
            this.tagNameDataGridViewTextBoxColumn.Name = "tagNameDataGridViewTextBoxColumn";
            // 
            // listLanguagesBindingSource
            // 
            this.listLanguagesBindingSource.DataMember = "ListLanguages";
            this.listLanguagesBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listLanguagesTableAdapter
            // 
            this.listLanguagesTableAdapter.ClearBeforeFill = true;
            // 
            // languageIdDataGridViewTextBoxColumn
            // 
            this.languageIdDataGridViewTextBoxColumn.DataPropertyName = "LanguageId";
            this.languageIdDataGridViewTextBoxColumn.HeaderText = "LanguageId";
            this.languageIdDataGridViewTextBoxColumn.Name = "languageIdDataGridViewTextBoxColumn";
            this.languageIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // languageNameDataGridViewTextBoxColumn
            // 
            this.languageNameDataGridViewTextBoxColumn.DataPropertyName = "LanguageName";
            this.languageNameDataGridViewTextBoxColumn.HeaderText = "LanguageName";
            this.languageNameDataGridViewTextBoxColumn.Name = "languageNameDataGridViewTextBoxColumn";
            // 
            // languageLocalNameDataGridViewTextBoxColumn
            // 
            this.languageLocalNameDataGridViewTextBoxColumn.DataPropertyName = "LanguageLocalName";
            this.languageLocalNameDataGridViewTextBoxColumn.HeaderText = "LanguageLocalName";
            this.languageLocalNameDataGridViewTextBoxColumn.Name = "languageLocalNameDataGridViewTextBoxColumn";
            // 
            // listInstallationOptionsBindingSource
            // 
            this.listInstallationOptionsBindingSource.DataMember = "ListInstallationOptions";
            this.listInstallationOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listInstallationOptionsTableAdapter
            // 
            this.listInstallationOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn1
            // 
            this.optionIdDataGridViewTextBoxColumn1.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn1.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn1.Name = "optionIdDataGridViewTextBoxColumn1";
            this.optionIdDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn1
            // 
            this.optionNameDataGridViewTextBoxColumn1.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn1.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn1.Name = "optionNameDataGridViewTextBoxColumn1";
            // 
            // listDemoOptionsBindingSource
            // 
            this.listDemoOptionsBindingSource.DataMember = "ListDemoOptions";
            this.listDemoOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listDemoOptionsTableAdapter
            // 
            this.listDemoOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn2
            // 
            this.optionIdDataGridViewTextBoxColumn2.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn2.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn2.Name = "optionIdDataGridViewTextBoxColumn2";
            this.optionIdDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn2
            // 
            this.optionNameDataGridViewTextBoxColumn2.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn2.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn2.Name = "optionNameDataGridViewTextBoxColumn2";
            // 
            // listPublishOptionsBindingSource
            // 
            this.listPublishOptionsBindingSource.DataMember = "ListPublishOptions";
            this.listPublishOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listPublishOptionsTableAdapter
            // 
            this.listPublishOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn3
            // 
            this.optionIdDataGridViewTextBoxColumn3.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn3.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn3.Name = "optionIdDataGridViewTextBoxColumn3";
            this.optionIdDataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn3
            // 
            this.optionNameDataGridViewTextBoxColumn3.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn3.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn3.Name = "optionNameDataGridViewTextBoxColumn3";
            // 
            // listPaymentOptionsBindingSource
            // 
            this.listPaymentOptionsBindingSource.DataMember = "ListPaymentOptions";
            this.listPaymentOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listPaymentOptionsTableAdapter
            // 
            this.listPaymentOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn4
            // 
            this.optionIdDataGridViewTextBoxColumn4.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn4.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn4.Name = "optionIdDataGridViewTextBoxColumn4";
            this.optionIdDataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn4
            // 
            this.optionNameDataGridViewTextBoxColumn4.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn4.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn4.Name = "optionNameDataGridViewTextBoxColumn4";
            // 
            // listExtensionOptionsBindingSource
            // 
            this.listExtensionOptionsBindingSource.DataMember = "ListExtensionOptions";
            this.listExtensionOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listExtensionOptionsTableAdapter
            // 
            this.listExtensionOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // extensionOptionIdDataGridViewTextBoxColumn
            // 
            this.extensionOptionIdDataGridViewTextBoxColumn.DataPropertyName = "ExtensionOptionId";
            this.extensionOptionIdDataGridViewTextBoxColumn.HeaderText = "ExtensionOptionId";
            this.extensionOptionIdDataGridViewTextBoxColumn.Name = "extensionOptionIdDataGridViewTextBoxColumn";
            this.extensionOptionIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // extensionOptionNameDataGridViewTextBoxColumn
            // 
            this.extensionOptionNameDataGridViewTextBoxColumn.DataPropertyName = "ExtensionOptionName";
            this.extensionOptionNameDataGridViewTextBoxColumn.HeaderText = "ExtensionOptionName";
            this.extensionOptionNameDataGridViewTextBoxColumn.Name = "extensionOptionNameDataGridViewTextBoxColumn";
            // 
            // listTrainingOptionsBindingSource
            // 
            this.listTrainingOptionsBindingSource.DataMember = "ListTrainingOptions";
            this.listTrainingOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listTrainingOptionsTableAdapter
            // 
            this.listTrainingOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn5
            // 
            this.optionIdDataGridViewTextBoxColumn5.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn5.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn5.Name = "optionIdDataGridViewTextBoxColumn5";
            this.optionIdDataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn5
            // 
            this.optionNameDataGridViewTextBoxColumn5.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn5.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn5.Name = "optionNameDataGridViewTextBoxColumn5";
            // 
            // listEnvironmentOptionsBindingSource
            // 
            this.listEnvironmentOptionsBindingSource.DataMember = "ListEnvironmentOptions";
            this.listEnvironmentOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listEnvironmentOptionsTableAdapter
            // 
            this.listEnvironmentOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn6
            // 
            this.optionIdDataGridViewTextBoxColumn6.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn6.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn6.Name = "optionIdDataGridViewTextBoxColumn6";
            this.optionIdDataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn6
            // 
            this.optionNameDataGridViewTextBoxColumn6.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn6.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn6.Name = "optionNameDataGridViewTextBoxColumn6";
            // 
            // listGuarantyOptionsBindingSource
            // 
            this.listGuarantyOptionsBindingSource.DataMember = "ListGuarantyOptions";
            this.listGuarantyOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listGuarantyOptionsTableAdapter
            // 
            this.listGuarantyOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn7
            // 
            this.optionIdDataGridViewTextBoxColumn7.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn7.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn7.Name = "optionIdDataGridViewTextBoxColumn7";
            this.optionIdDataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn7
            // 
            this.optionNameDataGridViewTextBoxColumn7.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn7.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn7.Name = "optionNameDataGridViewTextBoxColumn7";
            // 
            // limitationsDataGridViewTextBoxColumn
            // 
            this.limitationsDataGridViewTextBoxColumn.DataPropertyName = "Limitations";
            this.limitationsDataGridViewTextBoxColumn.HeaderText = "Limitations";
            this.limitationsDataGridViewTextBoxColumn.Name = "limitationsDataGridViewTextBoxColumn";
            // 
            // listSupportTypesBindingSource
            // 
            this.listSupportTypesBindingSource.DataMember = "ListSupportTypes";
            this.listSupportTypesBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listSupportTypesTableAdapter
            // 
            this.listSupportTypesTableAdapter.ClearBeforeFill = true;
            // 
            // typeIdDataGridViewTextBoxColumn
            // 
            this.typeIdDataGridViewTextBoxColumn.DataPropertyName = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.HeaderText = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
            this.typeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            this.typeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName";
            this.typeNameDataGridViewTextBoxColumn.HeaderText = "TypeName";
            this.typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
            // 
            // listSupportOptionsBindingSource
            // 
            this.listSupportOptionsBindingSource.DataMember = "ListSupportOptions";
            this.listSupportOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listSupportOptionsTableAdapter
            // 
            this.listSupportOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn8
            // 
            this.optionIdDataGridViewTextBoxColumn8.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn8.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn8.Name = "optionIdDataGridViewTextBoxColumn8";
            this.optionIdDataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn8
            // 
            this.optionNameDataGridViewTextBoxColumn8.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn8.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn8.Name = "optionNameDataGridViewTextBoxColumn8";
            // 
            // listDataBackupOptionsBindingSource
            // 
            this.listDataBackupOptionsBindingSource.DataMember = "ListDataBackupOptions";
            this.listDataBackupOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listDataBackupOptionsTableAdapter
            // 
            this.listDataBackupOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn9
            // 
            this.optionIdDataGridViewTextBoxColumn9.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn9.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn9.Name = "optionIdDataGridViewTextBoxColumn9";
            this.optionIdDataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn9
            // 
            this.optionNameDataGridViewTextBoxColumn9.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn9.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn9.Name = "optionNameDataGridViewTextBoxColumn9";
            // 
            // listUpdateOptionsBindingSource
            // 
            this.listUpdateOptionsBindingSource.DataMember = "ListUpdateOptions";
            this.listUpdateOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listUpdateOptionsTableAdapter
            // 
            this.listUpdateOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn10
            // 
            this.optionIdDataGridViewTextBoxColumn10.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn10.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn10.Name = "optionIdDataGridViewTextBoxColumn10";
            this.optionIdDataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn10
            // 
            this.optionNameDataGridViewTextBoxColumn10.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn10.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn10.Name = "optionNameDataGridViewTextBoxColumn10";
            // 
            // listCustomizationOptionsBindingSource
            // 
            this.listCustomizationOptionsBindingSource.DataMember = "ListCustomizationOptions";
            this.listCustomizationOptionsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // listCustomizationOptionsTableAdapter
            // 
            this.listCustomizationOptionsTableAdapter.ClearBeforeFill = true;
            // 
            // optionIdDataGridViewTextBoxColumn11
            // 
            this.optionIdDataGridViewTextBoxColumn11.DataPropertyName = "OptionId";
            this.optionIdDataGridViewTextBoxColumn11.HeaderText = "OptionId";
            this.optionIdDataGridViewTextBoxColumn11.Name = "optionIdDataGridViewTextBoxColumn11";
            this.optionIdDataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // optionNameDataGridViewTextBoxColumn11
            // 
            this.optionNameDataGridViewTextBoxColumn11.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn11.HeaderText = "OptionName";
            this.optionNameDataGridViewTextBoxColumn11.Name = "optionNameDataGridViewTextBoxColumn11";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 605);
            this.Controls.Add(this.tabControlMain);
            this.Name = "FrmMain";
            this.Text = "Data administration";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tpgArticle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnvironment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuaranty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupportTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupportOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstallation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnologies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatforms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSoftwarePlatformsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSourceOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listProductTechnologiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listCategoryTagsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listLanguagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listInstallationOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDemoOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listPublishOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listPaymentOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listExtensionOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listTrainingOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEnvironmentOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listGuarantyOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSupportTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSupportOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDataBackupOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listUpdateOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listCustomizationOptionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tpgArticle;
        private System.Windows.Forms.TabPage tpgUsers;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvPlatforms;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvBackup;
        private System.Windows.Forms.DataGridView dgvUpdate;
        private System.Windows.Forms.DataGridView dgvCustomization;
        private System.Windows.Forms.DataGridView dgvEnvironment;
        private System.Windows.Forms.DataGridView dgvGuaranty;
        private System.Windows.Forms.DataGridView dgvSupportTypes;
        private System.Windows.Forms.DataGridView dgvSupportOptions;
        private System.Windows.Forms.DataGridView dgvTraining;
        private System.Windows.Forms.DataGridView dgvInstallation;
        private System.Windows.Forms.DataGridView dgvDemo;
        private System.Windows.Forms.DataGridView dgvPublish;
        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.DataGridView dgvExtension;
        private System.Windows.Forms.DataGridView dgvLanguages;
        private System.Windows.Forms.DataGridView dgvCategoryTags;
        private System.Windows.Forms.DataGridView dgvTechnologies;
        private System.Windows.Forms.DataGridView dgvSource;
        private System.Windows.Forms.Button btnSave;
        private PersianSoftwareDataSet persianSoftwareDataSet;
        private System.Windows.Forms.BindingSource listSoftwarePlatformsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListSoftwarePlatformsTableAdapter listSoftwarePlatformsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn platformIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn platformNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listSourceOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListSourceOptionsTableAdapter listSourceOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listProductTechnologiesBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListProductTechnologiesTableAdapter listProductTechnologiesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn technologyIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn technologyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listCategoryTagsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListCategoryTagsTableAdapter listCategoryTagsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listLanguagesBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListLanguagesTableAdapter listLanguagesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn languageIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn languageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn languageLocalNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listInstallationOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListInstallationOptionsTableAdapter listInstallationOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource listDemoOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListDemoOptionsTableAdapter listDemoOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource listPublishOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListPublishOptionsTableAdapter listPublishOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource listPaymentOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListPaymentOptionsTableAdapter listPaymentOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource listExtensionOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListExtensionOptionsTableAdapter listExtensionOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionOptionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionOptionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listTrainingOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListTrainingOptionsTableAdapter listTrainingOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource listEnvironmentOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListEnvironmentOptionsTableAdapter listEnvironmentOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource listGuarantyOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListGuarantyOptionsTableAdapter listGuarantyOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn limitationsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listSupportTypesBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListSupportTypesTableAdapter listSupportTypesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource listSupportOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListSupportOptionsTableAdapter listSupportOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn8;
        private System.Windows.Forms.BindingSource listDataBackupOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListDataBackupOptionsTableAdapter listDataBackupOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn9;
        private System.Windows.Forms.BindingSource listUpdateOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListUpdateOptionsTableAdapter listUpdateOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn10;
        private System.Windows.Forms.BindingSource listCustomizationOptionsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListCustomizationOptionsTableAdapter listCustomizationOptionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionIdDataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn11;
    }
}