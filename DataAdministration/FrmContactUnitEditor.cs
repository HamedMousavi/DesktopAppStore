﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataAdministration
{
    public partial class FrmContactUnitEditor : Form
    {
        public FrmContactUnitEditor()
        {
            InitializeComponent();
        }

        private void FrmContactUnitEditor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'persianSoftwareDataSet.ListContactUnitTitles' table. You can move, or remove it, as needed.
            this.listContactUnitTitlesTableAdapter.Fill(this.persianSoftwareDataSet.ListContactUnitTitles);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.listContactUnitTitlesTableAdapter.Update(this.persianSoftwareDataSet.ListContactUnitTitles);
        }
    }
}
