using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DomainModel.Entities;

namespace DataAdministration
{
    public partial class FrmSearchContact : Form
    {
        public FrmSearchContact()
        {
            InitializeComponent();
        }



        public ProductContact SelectedContact { get; set; }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}
