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
    public partial class FrmWeblogEntryEditor : Form
    {
        private bool bUnsavedChangesExist;
        public DomainModel.Entities.WeblogEntry Entry { get; private set; }

        protected Int64? oldEntryId;
        protected int? oldLanguageId;
        public int EntryCulture
        {
            get
            {
                if (this.Entry == null || string.IsNullOrWhiteSpace(this.Entry.CultureId)) return 0;

                int? id = Repository.Sql.Languages.GetId(this.Entry.CultureId);
                return id == null ? 0 : id.Value;
            }

            set
            {
                if (value <= 0) return;

                this.Entry.CultureId = Repository.Sql.Languages.GetCulture(value);
            }
        }


        public FrmWeblogEntryEditor()
        {
            InitializeComponent();

            this.Entry = new DomainModel.Entities.WeblogEntry();

            this.tbxBlogId.DataBindings.Add(new Binding("Text", this.Entry, "EntryId", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxBrief.DataBindings.Add(new Binding("Text", this.Entry, "Brief", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxContent.DataBindings.Add(new Binding("Text", this.Entry, "Content", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxDateEnd.DataBindings.Add(new Binding("Text", this.Entry, "ExpirationDate", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxDateStart.DataBindings.Add(new Binding("Text", this.Entry, "UploadDate", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxScore.DataBindings.Add(new Binding("Text", this.Entry, "Score", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxTitle.DataBindings.Add(new Binding("Text", this.Entry, "Title", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxUrl.DataBindings.Add(new Binding("Text", this.Entry, "Url", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.chbxIsAnnounce.DataBindings.Add(new Binding("Checked", this.Entry, "IsAnnouncement", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.cbxLanguages.DataBindings.Add(new Binding("SelectedValue", this, "EntryCulture", true, DataSourceUpdateMode.OnPropertyChanged, ""));
        }


        private void FrmWeblogEntryEditor_Load(object sender, EventArgs e)
        {
            this.listLanguagesTableAdapter.Fill(this.persianSoftwareDataSet.ListLanguages);

            Int64? lastId = Repository.Sql.WebLog.LoadLastRow();
            this.lblInfo.Text = lastId != null ? lastId.Value.ToString() : string.Empty;
        }


        private bool UnsavedChangesExist()
        {
            if (this.oldEntryId != null) return true;
            
            return false;
        }


        private void cbxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEntry();
        }


        private void tbxBlogId_Leave(object sender, EventArgs e)
        {
            LoadEntry();
        }


        private void LoadEntry()
        {
            if (string.IsNullOrWhiteSpace(this.tbxBlogId.Text))
            {
                return;
            }

            if (this.cbxLanguages.SelectedValue == null)
            {
                return;
            }

            // If there is nothing to load, don't even try loading
            if (!Repository.Sql.WebLog.Exists(this.Entry)) return;

            // Save old entry
            if (UnsavedChangesExist())
            {
                SaveEntry(true);
            }

            // Load new Entry
            if (Repository.Sql.WebLog.Load(this.Entry))
            {
                UpdateTempEntry();
            }
        }


        private void UpdateTempEntry()
        {
            this.oldLanguageId = Repository.Sql.Languages.GetId(this.Entry.CultureId);
            this.oldEntryId = this.Entry.EntryId;
        }


        private void ClearTempEntry()
        {
            this.oldLanguageId = null;
            this.oldEntryId = null;
        }


        private bool SaveEntry(bool confirmSave)
        {
            bool res = false;

            if (confirmSave)
            {
                if (MessageBox.Show("There are unsaved changes. Do you want to save them?", "Confirm Save", MessageBoxButtons.YesNo) != 
                    System.Windows.Forms.DialogResult.Yes) return true;
            }

            if (!Repository.Sql.WebLog.Exists(this.Entry))
            {
                res = Repository.Sql.WebLog.Insert(this.Entry);
            }
            else
            {
                res = Repository.Sql.WebLog.Update(this.Entry);
            }

            if (res) ClearTempEntry();

            return res;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEntry(false);
        }
    }
}
