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
    public partial class FrmLanguageSelector : Form
    {
        public int SelectedLanguage { get; private set; }

        public FrmLanguageSelector()
        {
            InitializeComponent();
        }


        private void FrmLanguageSelector_Load(object sender, EventArgs e)
        {
            this.listLanguagesTableAdapter.Fill(this.persianSoftwareDataSet.ListLanguages);

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SelectedLanguage = Convert.ToInt32(this.cbxLanguages.SelectedValue);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
