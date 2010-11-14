using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DomainModel.Entities;

namespace DataAdministration
{
    public partial class FrmProductCatalog : Form
    {
        private ApplicationProduct product;
        

        public FrmProductCatalog(ApplicationProduct product)
        {
            InitializeComponent();
            this.product = product;

            this.tbxUrlName.DataBindings.Add(new Binding("Text", this.product.Catalog, "UrlName", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxSearchPriority.DataBindings.Add(new Binding("Text", this.product.Catalog, "SearchPriority", true, DataSourceUpdateMode.OnPropertyChanged, ""));

            this.chbxIsEnabled.DataBindings.Add(new Binding("Checked", this.product.Catalog, "IsEnabled"));
            this.chbxIsFeatured.DataBindings.Add(new Binding("Checked", this.product.Catalog, "IsFeatured"));
        }


        private void FrmProductCatalog_Load(object sender, EventArgs e)
        {
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!VerifyUrlName() && this.product.ProductId <= 0)
            {
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }


        private void btnVerify_Click(object sender, EventArgs e)
        {
            VerifyUrlName();
        }


        private bool VerifyUrlName()
        {
            bool ret;

            try
            {
                if (!Repository.Sql.Product.Exists(this.product.Catalog.UrlName))
                {
                    ret = true;
                    this.lblUrlNameValidationStatus.BackColor = Color.Green;
                    this.lblUrlNameValidationStatus.ForeColor = Color.White;
                    this.lblUrlNameValidationStatus.Text = "[OK]";
                }
                else
                {
                    ret = false;
                    this.lblUrlNameValidationStatus.BackColor = Color.Red;
                    this.lblUrlNameValidationStatus.ForeColor = Color.White;
                    this.lblUrlNameValidationStatus.Text = "[ALREADY EXISTS]";
                }
            }
            catch (Exception ex)
            {
                ret = false;
                this.lblUrlNameValidationStatus.BackColor = Color.Red;
                this.lblUrlNameValidationStatus.ForeColor = Color.White;
                this.lblUrlNameValidationStatus.Text = ex.ToString();
            }
            return ret;
        }
    }
}
