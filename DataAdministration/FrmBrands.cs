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
    public partial class FrmBrands : Form
    {

        private ApplicationProduct product;


        public FrmBrands(ApplicationProduct product)
        {
            InitializeComponent();

            this.product = product;

            BindList();
        }



        private void BindList()
        {
            Repository.Sql.ProductBrands.Reload(this.product);

            if (this.product.Brands.Count > 0 && this.lbxBrands.DataSource == null)
            {
                this.lbxBrands.DataSource = this.product.Brands;
                this.lbxBrands.DisplayMember = "BrandName";
                this.lbxBrands.ValueMember = "BrandId";
            }


            ((CurrencyManager)this.lbxBrands.BindingContext[this.lbxBrands.DataSource]).Refresh();

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductBrand brand = new ProductBrand();
            brand.BrandName = this.tbxNewBrandName.Text;

            if (Repository.Sql.ProductBrands.Add(this.product, brand))
            {
                BindList();
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductBrand brand = (ProductBrand)this.lbxBrands.SelectedItem;
            brand.BrandName = this.tbxBrandName.Text;

            if (Repository.Sql.ProductBrands.Update(brand))
            {
                BindList();
            }
        }



        private void btnRemove_Click(object sender, EventArgs e)
        {
            ProductBrand brand = (ProductBrand)this.lbxBrands.SelectedItem;
            if (Repository.Sql.ProductBrands.Remove(this.product, brand))
            {
                BindList();
            }
        }



        private void lbxBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductBrand brand = (ProductBrand)this.lbxBrands.SelectedItem;
            if (brand !=null)
            {
                this.tbxBrandName.Text = brand.BrandName;
            }
        }



        private void btnExistingBrand_Click(object sender, EventArgs e)
        {

        }
    }
}
