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
    public partial class FrmProductDetails : Form
    {
        private ApplicationProduct product;
        

        public new string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string PriceDetails { get; set; }
        public string GuarantyDetails { get; set; }


        public FrmProductDetails()
        {
            InitializeComponent();
        }


        public FrmProductDetails(ApplicationProduct product)
            : this()
        {
            this.product = product;

            if (product == null)
            {
                this.tbxProductName.DataBindings.Add(new Binding("Text", this, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged, ""));
                this.tbxProductDescription.DataBindings.Add(new Binding("Text", this, "ProductDescription", true, DataSourceUpdateMode.OnPropertyChanged, ""));
                this.tbxProductPriceDetails.DataBindings.Add(new Binding("Text", this, "PriceDetails", true, DataSourceUpdateMode.OnPropertyChanged, ""));
                this.tbxGuarantyDetails.DataBindings.Add(new Binding("Text", this, "GuarantyDetails", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            }
            else
            {
                this.tbxProductName.DataBindings.Add(new Binding("Text", this.product, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged, ""));
                this.tbxProductDescription.DataBindings.Add(new Binding("Text", this.product, "BriefDescription", true, DataSourceUpdateMode.OnPropertyChanged, ""));
                this.tbxProductPriceDetails.DataBindings.Add(new Binding("Text", this.product, "PriceDetails", true, DataSourceUpdateMode.OnPropertyChanged, ""));
                this.tbxGuarantyDetails.DataBindings.Add(new Binding("Text", this.product, "GuarantyDetails", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            }
        }


        private void FrmProductDetails_Load(object sender, EventArgs e)
        {
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
