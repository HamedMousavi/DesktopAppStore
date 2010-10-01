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
    public partial class FrmHardwareRequirements : Form
    {
        private ApplicationProduct product;


        public FrmHardwareRequirements(ApplicationProduct product)
        {
            this.product = product;

            InitializeComponent();
        }



        private void FrmHardwareRequirements_Load(object sender, EventArgs e)
        {
            this.productHardwareRequirementsTableAdapter.FillByProductId(
                this.persianSoftwareDataSet.ProductHardwareRequirements, 
                this.product.ProductId.Value);
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            this.productHardwareRequirementsTableAdapter.Update(this.persianSoftwareDataSet.ProductHardwareRequirements);
        }
    }
}
