namespace DataAdministration
{
    partial class FrmProductScreenshots
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
            this.lbxImages = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.cbxLanguages = new System.Windows.Forms.ComboBox();
            this.listLanguagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.persianSoftwareDataSet = new DataAdministration.PersianSoftwareDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.listLanguagesTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListLanguagesTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbxImageSrcDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCopyCreate = new System.Windows.Forms.Button();
            this.btnLoadMetaDataFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listLanguagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxImages
            // 
            this.lbxImages.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbxImages.FormattingEnabled = true;
            this.lbxImages.Location = new System.Drawing.Point(0, 0);
            this.lbxImages.Name = "lbxImages";
            this.lbxImages.Size = new System.Drawing.Size(144, 396);
            this.lbxImages.TabIndex = 0;
            this.lbxImages.SelectedValueChanged += new System.EventHandler(this.lbxImages_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Title";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(153, 179);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(242, 20);
            this.tbxTitle.TabIndex = 10;
            // 
            // cbxLanguages
            // 
            this.cbxLanguages.DataSource = this.listLanguagesBindingSource;
            this.cbxLanguages.DisplayMember = "OptionName";
            this.cbxLanguages.FormattingEnabled = true;
            this.cbxLanguages.Location = new System.Drawing.Point(211, 6);
            this.cbxLanguages.Name = "cbxLanguages";
            this.cbxLanguages.Size = new System.Drawing.Size(134, 21);
            this.cbxLanguages.TabIndex = 2;
            this.cbxLanguages.ValueMember = "CultureId";
            // 
            // listLanguagesBindingSource
            // 
            this.listLanguagesBindingSource.DataMember = "ListLanguages";
            this.listLanguagesBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // persianSoftwareDataSet
            // 
            this.persianSoftwareDataSet.DataSetName = "PersianSoftwareDataSet";
            this.persianSoftwareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Language";
            // 
            // listLanguagesTableAdapter
            // 
            this.listLanguagesTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(153, 228);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(242, 127);
            this.tbxDescription.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 361);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(242, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(153, 110);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(242, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate Metadata File";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbxImageSrcDir
            // 
            this.tbxImageSrcDir.Location = new System.Drawing.Point(211, 52);
            this.tbxImageSrcDir.Name = "tbxImageSrcDir";
            this.tbxImageSrcDir.Size = new System.Drawing.Size(134, 20);
            this.tbxImageSrcDir.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Images";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(351, 50);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(44, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCopyCreate
            // 
            this.btnCopyCreate.Location = new System.Drawing.Point(153, 81);
            this.btnCopyCreate.Name = "btnCopyCreate";
            this.btnCopyCreate.Size = new System.Drawing.Size(242, 23);
            this.btnCopyCreate.TabIndex = 7;
            this.btnCopyCreate.Text = "Copy && Generate";
            this.btnCopyCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyCreate.UseVisualStyleBackColor = true;
            this.btnCopyCreate.Click += new System.EventHandler(this.btnCopyCreate_Click);
            // 
            // btnLoadMetaDataFile
            // 
            this.btnLoadMetaDataFile.Location = new System.Drawing.Point(351, 4);
            this.btnLoadMetaDataFile.Name = "btnLoadMetaDataFile";
            this.btnLoadMetaDataFile.Size = new System.Drawing.Size(44, 23);
            this.btnLoadMetaDataFile.TabIndex = 3;
            this.btnLoadMetaDataFile.Text = "Load";
            this.btnLoadMetaDataFile.UseVisualStyleBackColor = true;
            this.btnLoadMetaDataFile.Click += new System.EventHandler(this.btnLoadMetaDataFile_Click);
            // 
            // FrmProductScreenshots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 396);
            this.Controls.Add(this.btnLoadMetaDataFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnCopyCreate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxLanguages);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxImageSrcDir);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxImages);
            this.Name = "FrmProductScreenshots";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmProductScreenshots";
            this.Load += new System.EventHandler(this.FrmProductScreenshots_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listLanguagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.ComboBox cbxLanguages;
        private System.Windows.Forms.Label label2;
        private PersianSoftwareDataSet persianSoftwareDataSet;
        private System.Windows.Forms.BindingSource listLanguagesBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListLanguagesTableAdapter listLanguagesTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox tbxImageSrcDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCopyCreate;
        private System.Windows.Forms.Button btnLoadMetaDataFile;
    }
}