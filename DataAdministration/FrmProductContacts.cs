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
    public partial class FrmProductContacts : Form
    {
        protected ApplicationProduct product;

        public FrmProductContacts(ApplicationProduct product)
        {
            InitializeComponent();

            this.product = product;
            this.dgvContacts.DataSource = this.product.ProductContacts;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (FrmContactEditor frm = new FrmContactEditor(new ProductContact()))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (Repository.Sql.ProductContacts.Insert(frm.Contact, this.product))
                    {
                        this.product.ProductContacts.Add(frm.Contact);
                    }
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            ProductContact selected = this.dgvContacts.SelectedItem as ProductContact;
            if (selected == null) throw new InvalidOperationException("Please selet a contact to edit");

            using (FrmContactEditor frm = new FrmContactEditor(selected))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Repository.Sql.ProductContacts.Update(frm.Contact);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductContact selected = this.dgvContacts.SelectedItem as ProductContact;
            if (selected == null) throw new InvalidOperationException("Please selet a contact to remove");

            if (MessageBox.Show("Are you sure you want to delete this record permanently?", "Confirm permanent remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Repository.Sql.ProductContacts.Delete(selected, this.product);
            }
        }
    }
}
