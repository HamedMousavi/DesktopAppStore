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
    public partial class FrmContactEditor : Form
    {
        public ProductContact Contact { get; set; }



        public FrmContactEditor(ProductContact contact)
        {
            this.Contact = contact;

            InitializeComponent();

            this.cbxListContactMedia.DataSource = Repository.Sql.ProductContacts.GetMediaList(false);
            this.cbxListContactMedia.DisplayMember = "Name";
            this.cbxListContactMedia.ValueMember = "Id";

            this.cbxListContactUnits.DataSource = Repository.Sql.ProductContacts.GetUnitList(false);
            this.cbxListContactUnits.DisplayMember = "Name";
            this.cbxListContactUnits.ValueMember = "Id";

            this.tbxContactPerson.DataBindings.Add(new Binding("Text", this.Contact, "ContactPerson"));
            this.tbxContactValue.DataBindings.Add(new Binding("Text", this.Contact, "ContactValue"));
            
            this.cbxListContactMedia.DataBindings.Add(new Binding("SelectedValue", this.Contact.MediaType, "Id"));
            this.cbxListContactUnits.DataBindings.Add(new Binding("SelectedValue", this.Contact.Unit, "Id"));

            this.rtnNewContact.Checked = true;
            UpdateControls();
        }



        private void btnSearchContacts_Click(object sender, EventArgs e)
        {
            using (FrmSearchContact frm = new FrmSearchContact())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh list of Medias
                    this.Contact.Copy(frm.SelectedContact);
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //Close();
        }



        private void btnAddContactMedia_Click(object sender, EventArgs e)
        {
            using (FrmContactMediaEditor frm = new FrmContactMediaEditor())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh list of Medias
                    Repository.Sql.ProductContacts.GetMediaList(true);
                }
            }
        }



        private void btnAddContactUnit_Click(object sender, EventArgs e)
        {
            using (FrmContactUnitEditor frm = new FrmContactUnitEditor())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh list of units
                    Repository.Sql.ProductContacts.GetUnitList(true);
                }
            }
        }



        private void rtnExisting_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }



        private void rtnNewContact_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }



        private void UpdateControls()
        {
            this.btnSearchContacts.Enabled = this.rtnExisting.Checked;
            this.grpNewContact.Enabled = !this.rtnExisting.Checked;
        }
    }
}
