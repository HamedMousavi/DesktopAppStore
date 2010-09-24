namespace DataAdministration
{
    partial class FrmProductEditor
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
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxProductDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxProductWebsite = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxProductVolumeSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxProductVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxProductReleaseDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxProductPrice = new System.Windows.Forms.TextBox();
            this.btnProductResourceDirBrowse = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxProductPriceDetails = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxProductResourceDir = new System.Windows.Forms.TextBox();
            this.chbxProductMultiUser = new System.Windows.Forms.CheckBox();
            this.chbxProductMultiLanguage = new System.Windows.Forms.CheckBox();
            this.chbxProductLangExtendable = new System.Windows.Forms.CheckBox();
            this.btnCreateProduct = new System.Windows.Forms.Button();
            this.btnContacts = new System.Windows.Forms.Button();
            this.btnOwners = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.dgvBrands = new System.Windows.Forms.DataGridView();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxProductName
            // 
            this.tbxProductName.Location = new System.Drawing.Point(117, 3);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.Size = new System.Drawing.Size(155, 20);
            this.tbxProductName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ProductName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ProductWebsite";
            // 
            // tbxProductDescription
            // 
            this.tbxProductDescription.Location = new System.Drawing.Point(117, 31);
            this.tbxProductDescription.Name = "tbxProductDescription";
            this.tbxProductDescription.Size = new System.Drawing.Size(392, 20);
            this.tbxProductDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "BriefDescription";
            // 
            // tbxProductWebsite
            // 
            this.tbxProductWebsite.Location = new System.Drawing.Point(117, 59);
            this.tbxProductWebsite.Name = "tbxProductWebsite";
            this.tbxProductWebsite.Size = new System.Drawing.Size(155, 20);
            this.tbxProductWebsite.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ResourceDir";
            // 
            // tbxProductVolumeSize
            // 
            this.tbxProductVolumeSize.Location = new System.Drawing.Point(354, 115);
            this.tbxProductVolumeSize.Name = "tbxProductVolumeSize";
            this.tbxProductVolumeSize.Size = new System.Drawing.Size(155, 20);
            this.tbxProductVolumeSize.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ProductVersion";
            // 
            // tbxProductVersion
            // 
            this.tbxProductVersion.Location = new System.Drawing.Point(117, 87);
            this.tbxProductVersion.Name = "tbxProductVersion";
            this.tbxProductVersion.Size = new System.Drawing.Size(155, 20);
            this.tbxProductVersion.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "ProductReleaseDate";
            // 
            // tbxProductReleaseDate
            // 
            this.tbxProductReleaseDate.Location = new System.Drawing.Point(117, 115);
            this.tbxProductReleaseDate.Name = "tbxProductReleaseDate";
            this.tbxProductReleaseDate.Size = new System.Drawing.Size(155, 20);
            this.tbxProductReleaseDate.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "ProductPrice";
            // 
            // tbxProductPrice
            // 
            this.tbxProductPrice.Location = new System.Drawing.Point(354, 3);
            this.tbxProductPrice.Name = "tbxProductPrice";
            this.tbxProductPrice.Size = new System.Drawing.Size(155, 20);
            this.tbxProductPrice.TabIndex = 11;
            // 
            // btnProductResourceDirBrowse
            // 
            this.btnProductResourceDirBrowse.Location = new System.Drawing.Point(475, 85);
            this.btnProductResourceDirBrowse.Name = "btnProductResourceDirBrowse";
            this.btnProductResourceDirBrowse.Size = new System.Drawing.Size(34, 23);
            this.btnProductResourceDirBrowse.TabIndex = 16;
            this.btnProductResourceDirBrowse.Text = "...";
            this.btnProductResourceDirBrowse.UseVisualStyleBackColor = true;
            this.btnProductResourceDirBrowse.Click += new System.EventHandler(this.btnProductResourceDirBrowse_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "PriceDetails";
            // 
            // tbxProductPriceDetails
            // 
            this.tbxProductPriceDetails.Location = new System.Drawing.Point(354, 59);
            this.tbxProductPriceDetails.Name = "tbxProductPriceDetails";
            this.tbxProductPriceDetails.Size = new System.Drawing.Size(408, 20);
            this.tbxProductPriceDetails.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "VolumeSize";
            // 
            // tbxProductResourceDir
            // 
            this.tbxProductResourceDir.Location = new System.Drawing.Point(354, 87);
            this.tbxProductResourceDir.Name = "tbxProductResourceDir";
            this.tbxProductResourceDir.Size = new System.Drawing.Size(115, 20);
            this.tbxProductResourceDir.TabIndex = 15;
            // 
            // chbxProductMultiUser
            // 
            this.chbxProductMultiUser.AutoSize = true;
            this.chbxProductMultiUser.Location = new System.Drawing.Point(515, 2);
            this.chbxProductMultiUser.Name = "chbxProductMultiUser";
            this.chbxProductMultiUser.Size = new System.Drawing.Size(78, 17);
            this.chbxProductMultiUser.TabIndex = 19;
            this.chbxProductMultiUser.Text = "IsMultiUser";
            this.chbxProductMultiUser.UseVisualStyleBackColor = true;
            // 
            // chbxProductMultiLanguage
            // 
            this.chbxProductMultiLanguage.AutoSize = true;
            this.chbxProductMultiLanguage.Location = new System.Drawing.Point(515, 25);
            this.chbxProductMultiLanguage.Name = "chbxProductMultiLanguage";
            this.chbxProductMultiLanguage.Size = new System.Drawing.Size(104, 17);
            this.chbxProductMultiLanguage.TabIndex = 20;
            this.chbxProductMultiLanguage.Text = "IsMultiLanguage";
            this.chbxProductMultiLanguage.UseVisualStyleBackColor = true;
            // 
            // chbxProductLangExtendable
            // 
            this.chbxProductLangExtendable.AutoSize = true;
            this.chbxProductLangExtendable.Location = new System.Drawing.Point(627, 3);
            this.chbxProductLangExtendable.Name = "chbxProductLangExtendable";
            this.chbxProductLangExtendable.Size = new System.Drawing.Size(135, 17);
            this.chbxProductLangExtendable.TabIndex = 21;
            this.chbxProductLangExtendable.Text = "IsLanguageExtendable";
            this.chbxProductLangExtendable.UseVisualStyleBackColor = true;
            // 
            // btnCreateProduct
            // 
            this.btnCreateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateProduct.Location = new System.Drawing.Point(515, 85);
            this.btnCreateProduct.Name = "btnCreateProduct";
            this.btnCreateProduct.Size = new System.Drawing.Size(121, 55);
            this.btnCreateProduct.TabIndex = 22;
            this.btnCreateProduct.Text = "Create";
            this.btnCreateProduct.UseVisualStyleBackColor = true;
            this.btnCreateProduct.Click += new System.EventHandler(this.btnCreateProduct_Click);
            // 
            // btnContacts
            // 
            this.btnContacts.Location = new System.Drawing.Point(5, 3);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Size = new System.Drawing.Size(113, 23);
            this.btnContacts.TabIndex = 0;
            this.btnContacts.Text = "Contacts";
            this.btnContacts.UseVisualStyleBackColor = true;
            this.btnContacts.Click += new System.EventHandler(this.btnContacts_Click);
            // 
            // btnOwners
            // 
            this.btnOwners.Location = new System.Drawing.Point(124, 3);
            this.btnOwners.Name = "btnOwners";
            this.btnOwners.Size = new System.Drawing.Size(113, 23);
            this.btnOwners.TabIndex = 1;
            this.btnOwners.Text = "Owners";
            this.btnOwners.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(562, 477);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "HardwareRequirements";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(565, 493);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(120, 93);
            this.dataGridView1.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(688, 477);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Brands";
            // 
            // dgvBrands
            // 
            this.dgvBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrands.Location = new System.Drawing.Point(691, 493);
            this.dgvBrands.Name = "dgvBrands";
            this.dgvBrands.Size = new System.Drawing.Size(120, 93);
            this.dgvBrands.TabIndex = 5;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.btnUpdateProduct);
            this.splitMain.Panel1.Controls.Add(this.btnCreateProduct);
            this.splitMain.Panel1.Controls.Add(this.label1);
            this.splitMain.Panel1.Controls.Add(this.tbxProductName);
            this.splitMain.Panel1.Controls.Add(this.label2);
            this.splitMain.Panel1.Controls.Add(this.tbxProductDescription);
            this.splitMain.Panel1.Controls.Add(this.label3);
            this.splitMain.Panel1.Controls.Add(this.tbxProductWebsite);
            this.splitMain.Panel1.Controls.Add(this.chbxProductLangExtendable);
            this.splitMain.Panel1.Controls.Add(this.label4);
            this.splitMain.Panel1.Controls.Add(this.chbxProductMultiLanguage);
            this.splitMain.Panel1.Controls.Add(this.tbxProductVolumeSize);
            this.splitMain.Panel1.Controls.Add(this.chbxProductMultiUser);
            this.splitMain.Panel1.Controls.Add(this.label5);
            this.splitMain.Panel1.Controls.Add(this.btnProductResourceDirBrowse);
            this.splitMain.Panel1.Controls.Add(this.tbxProductVersion);
            this.splitMain.Panel1.Controls.Add(this.tbxProductResourceDir);
            this.splitMain.Panel1.Controls.Add(this.label6);
            this.splitMain.Panel1.Controls.Add(this.tbxProductPriceDetails);
            this.splitMain.Panel1.Controls.Add(this.tbxProductReleaseDate);
            this.splitMain.Panel1.Controls.Add(this.label7);
            this.splitMain.Panel1.Controls.Add(this.label8);
            this.splitMain.Panel1.Controls.Add(this.label9);
            this.splitMain.Panel1.Controls.Add(this.tbxProductPrice);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.btnContacts);
            this.splitMain.Panel2.Controls.Add(this.dgvBrands);
            this.splitMain.Panel2.Controls.Add(this.dataGridView1);
            this.splitMain.Panel2.Controls.Add(this.btnOwners);
            this.splitMain.Panel2.Controls.Add(this.label13);
            this.splitMain.Panel2.Controls.Add(this.label20);
            this.splitMain.Size = new System.Drawing.Size(820, 742);
            this.splitMain.SplitterDistance = 143;
            this.splitMain.TabIndex = 0;
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.Location = new System.Drawing.Point(641, 85);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(121, 55);
            this.btnUpdateProduct.TabIndex = 23;
            this.btnUpdateProduct.Text = "Update";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // FrmProductEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 742);
            this.Controls.Add(this.splitMain);
            this.Name = "FrmProductEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmProductEditor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxProductDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxProductWebsite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxProductVolumeSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxProductVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxProductReleaseDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxProductPrice;
        private System.Windows.Forms.Button btnProductResourceDirBrowse;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxProductPriceDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxProductResourceDir;
        private System.Windows.Forms.CheckBox chbxProductMultiUser;
        private System.Windows.Forms.CheckBox chbxProductMultiLanguage;
        private System.Windows.Forms.CheckBox chbxProductLangExtendable;
        private System.Windows.Forms.Button btnCreateProduct;
        private System.Windows.Forms.Button btnContacts;
        private System.Windows.Forms.Button btnOwners;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dgvBrands;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Button btnUpdateProduct;
    }
}