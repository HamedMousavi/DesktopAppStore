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
    public partial class FrmContactMediaEditor : Form
    {
        public FrmContactMediaEditor()
        {
            InitializeComponent();
        }

        private void FrmContactMediaEditor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListContactMedias' table. You can move, or remove it, as needed.
            this.listContactMediasTableAdapter.Fill(this.persianSoftwareDataSet.ListContactMedias);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.listContactMediasTableAdapter.Update(this.persianSoftwareDataSet.ListContactMedias);
        }
    }
}
