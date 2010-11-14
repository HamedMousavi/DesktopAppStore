using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataAdministration
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FrmProductEditor editor = new FrmProductEditor(new DomainModel.Entities.ApplicationProduct()))
            {
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                }
            }
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListSoftwarePlatforms' table. You can move, or remove it, as needed.
            this.listSoftwarePlatformsTableAdapter.Fill(this.persianSoftwareDataSet.ListSoftwarePlatforms);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListSourceOptions' table. You can move, or remove it, as needed.
            this.listSourceOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListSourceOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListProductTechnologies' table. You can move, or remove it, as needed.
            this.listProductTechnologiesTableAdapter.Fill(this.persianSoftwareDataSet.ListProductTechnologies);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListTags' table. You can move, or remove it, as needed.
            this.listTagsTableAdapter.Fill(this.persianSoftwareDataSet.ListTags);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListLanguages' table. You can move, or remove it, as needed.
            this.listLanguagesTableAdapter.Fill(this.persianSoftwareDataSet.ListLanguages);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListExtensionOptions' table. You can move, or remove it, as needed.
            this.listExtensionOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListExtensionOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListPaymentOptions' table. You can move, or remove it, as needed.
            this.listPaymentOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListPaymentOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListPublishOptions' table. You can move, or remove it, as needed.
            this.listPublishOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListPublishOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListDemoOptions' table. You can move, or remove it, as needed.
            this.listDemoOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListDemoOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListInstallationOptions' table. You can move, or remove it, as needed.
            this.listInstallationOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListInstallationOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListTrainingOptions' table. You can move, or remove it, as needed.
            this.listTrainingOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListTrainingOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListSupportTypes' table. You can move, or remove it, as needed.
            this.listSupportTypesTableAdapter.Fill(this.persianSoftwareDataSet.ListSupportTypes);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListSupportOptions' table. You can move, or remove it, as needed.
            this.listSupportOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListSupportOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListGuarantyOptions' table. You can move, or remove it, as needed.
            this.listGuarantyOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListGuarantyOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListEnvironmentOptions' table. You can move, or remove it, as needed.
            this.listEnvironmentOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListEnvironmentOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListCustomizationOptions' table. You can move, or remove it, as needed.
            this.listCustomizationOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListCustomizationOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListUpdateOptions' table. You can move, or remove it, as needed.
            this.listUpdateOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListUpdateOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListDataBackupOptions' table. You can move, or remove it, as needed.
            this.listDataBackupOptionsTableAdapter.Fill(this.persianSoftwareDataSet.ListDataBackupOptions);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListContactMedias' table. You can move, or remove it, as needed.
            this.listContactMediasTableAdapter.Fill(this.persianSoftwareDataSet.ListContactMedias);
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListContactUnitTitles' table. You can move, or remove it, as needed.
            this.listContactUnitTitlesTableAdapter.Fill(this.persianSoftwareDataSet.ListContactUnitTitles);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.listCustomizationOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListCustomizationOptions);
            this.listUpdateOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListUpdateOptions);
            this.listDataBackupOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListDataBackupOptions);
            this.listSupportOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListSupportOptions);
            this.listSupportTypesTableAdapter.Update(this.persianSoftwareDataSet.ListSupportTypes);
            this.listGuarantyOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListGuarantyOptions);
            this.listEnvironmentOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListEnvironmentOptions);
            this.listTrainingOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListTrainingOptions);
            this.listExtensionOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListExtensionOptions);
            this.listPaymentOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListPaymentOptions);
            this.listPublishOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListPublishOptions);
            this.listDemoOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListDemoOptions);
            this.listInstallationOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListInstallationOptions);
            this.listLanguagesTableAdapter.Update(this.persianSoftwareDataSet.ListLanguages);
            this.listTagsTableAdapter.Update(this.persianSoftwareDataSet.ListTags);
            this.listProductTechnologiesTableAdapter.Update(this.persianSoftwareDataSet.ListProductTechnologies);
            this.listSourceOptionsTableAdapter.Update(this.persianSoftwareDataSet.ListSourceOptions);
            this.listSoftwarePlatformsTableAdapter.Update(this.persianSoftwareDataSet.ListSoftwarePlatforms);
            this.listContactMediasTableAdapter.Update(this.persianSoftwareDataSet.ListContactMedias);
            this.listContactUnitTitlesTableAdapter.Update(this.persianSoftwareDataSet.ListContactUnitTitles);
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            DomainModel.Entities.ApplicationProduct product = null;

            Int64? productId = null;

            // Select language
            int languageId = Convert.ToInt32(cbxLanguageList.SelectedValue);

            // Find product
            if (!string.IsNullOrWhiteSpace(this.tbxUrlName.Text))
            {
                productId = Repository.Sql.Product.IdFromUrlName(this.tbxUrlName.Text);
            }
            else if (!string.IsNullOrWhiteSpace(this.tbxProductId.Text))
            {
                productId = Convert.ToInt64(this.tbxProductId.Text);
            }

            if (productId == null || languageId < 0)
            {
                MessageBox.Show("Produc not found");
                return;
            }

            product = Repository.Sql.Product.GetById(productId.Value, languageId);

            // Edit product
            if (product == null)
            {
                MessageBox.Show("Produc not found");
            }
            else
            {
                Repository.Sql.ProductOptions.Reload(product);
                Repository.Sql.ProductContacts.Reload(product);

                using (FrmProductEditor editor = new FrmProductEditor(product))
                {
                    if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // UNDONE : INSERT PRODUCT
                    }
                }
            }
        }
    }
}
