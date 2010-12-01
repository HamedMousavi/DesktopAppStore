namespace DataAdministration
{
    partial class FrmWeblogEntryEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbxLanguages = new System.Windows.Forms.ComboBox();
            this.listLanguagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.persianSoftwareDataSet = new DataAdministration.PersianSoftwareDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.listLanguagesTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListLanguagesTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxBlogId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDateStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDateEnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxScore = new System.Windows.Forms.TextBox();
            this.tbxContent = new System.Windows.Forms.RichTextBox();
            this.tbxBrief = new System.Windows.Forms.RichTextBox();
            this.chbxIsAnnounce = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listLanguagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxLanguages
            // 
            this.cbxLanguages.DataSource = this.listLanguagesBindingSource;
            this.cbxLanguages.DisplayMember = "OptionName";
            this.cbxLanguages.FormattingEnabled = true;
            this.cbxLanguages.Location = new System.Drawing.Point(71, 29);
            this.cbxLanguages.Name = "cbxLanguages";
            this.cbxLanguages.Size = new System.Drawing.Size(172, 21);
            this.cbxLanguages.TabIndex = 1;
            this.cbxLanguages.ValueMember = "OptionId";
            this.cbxLanguages.SelectedIndexChanged += new System.EventHandler(this.cbxLanguages_SelectedIndexChanged);
            // 
            // listLanguagesBindingSource
            // 
            this.listLanguagesBindingSource.DataMember = "ListLanguages";
            this.listLanguagesBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // persianSoftwareDataSet
            // 
            this.persianSoftwareDataSet.DataSetName = "PersianSoftwareDataSet";
            this.persianSoftwareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Languages";
            // 
            // listLanguagesTableAdapter
            // 
            this.listLanguagesTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id";
            // 
            // tbxBlogId
            // 
            this.tbxBlogId.Location = new System.Drawing.Point(296, 30);
            this.tbxBlogId.Name = "tbxBlogId";
            this.tbxBlogId.Size = new System.Drawing.Size(164, 20);
            this.tbxBlogId.TabIndex = 3;
            this.tbxBlogId.Leave += new System.EventHandler(this.tbxBlogId_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "From";
            // 
            // tbxDateStart
            // 
            this.tbxDateStart.Location = new System.Drawing.Point(71, 56);
            this.tbxDateStart.Name = "tbxDateStart";
            this.tbxDateStart.Size = new System.Drawing.Size(172, 20);
            this.tbxDateStart.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "To";
            // 
            // tbxDateEnd
            // 
            this.tbxDateEnd.Location = new System.Drawing.Point(296, 56);
            this.tbxDateEnd.Name = "tbxDateEnd";
            this.tbxDateEnd.Size = new System.Drawing.Size(164, 20);
            this.tbxDateEnd.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Url";
            // 
            // tbxUrl
            // 
            this.tbxUrl.Location = new System.Drawing.Point(71, 82);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(172, 20);
            this.tbxUrl.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Title";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(71, 108);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(389, 20);
            this.tbxTitle.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Brief";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Content";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(255, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Score";
            // 
            // tbxScore
            // 
            this.tbxScore.Location = new System.Drawing.Point(296, 82);
            this.tbxScore.Name = "tbxScore";
            this.tbxScore.Size = new System.Drawing.Size(164, 20);
            this.tbxScore.TabIndex = 12;
            // 
            // tbxContent
            // 
            this.tbxContent.Location = new System.Drawing.Point(71, 236);
            this.tbxContent.Name = "tbxContent";
            this.tbxContent.Size = new System.Drawing.Size(389, 96);
            this.tbxContent.TabIndex = 18;
            this.tbxContent.Text = "";
            // 
            // tbxBrief
            // 
            this.tbxBrief.Location = new System.Drawing.Point(71, 134);
            this.tbxBrief.Name = "tbxBrief";
            this.tbxBrief.Size = new System.Drawing.Size(389, 96);
            this.tbxBrief.TabIndex = 16;
            this.tbxBrief.Text = "";
            // 
            // chbxIsAnnounce
            // 
            this.chbxIsAnnounce.AutoSize = true;
            this.chbxIsAnnounce.Location = new System.Drawing.Point(12, 6);
            this.chbxIsAnnounce.Name = "chbxIsAnnounce";
            this.chbxIsAnnounce.Size = new System.Drawing.Size(109, 17);
            this.chbxIsAnnounce.TabIndex = 4;
            this.chbxIsAnnounce.Text = "Is Announcement";
            this.chbxIsAnnounce.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(385, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(304, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.lblInfo.Location = new System.Drawing.Point(296, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(164, 18);
            this.lblInfo.TabIndex = 21;
            this.lblInfo.Text = "0 Entries Found";
            // 
            // FrmWeblogEntryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 371);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chbxIsAnnounce);
            this.Controls.Add(this.tbxBrief);
            this.Controls.Add(this.tbxContent);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxScore);
            this.Controls.Add(this.tbxDateEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxUrl);
            this.Controls.Add(this.tbxDateStart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxBlogId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxLanguages);
            this.Name = "FrmWeblogEntryEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmWeblogEntryEditor";
            this.Load += new System.EventHandler(this.FrmWeblogEntryEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listLanguagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxLanguages;
        private System.Windows.Forms.Label label1;
        private PersianSoftwareDataSet persianSoftwareDataSet;
        private System.Windows.Forms.BindingSource listLanguagesBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListLanguagesTableAdapter listLanguagesTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxBlogId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxDateStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDateEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxUrl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxScore;
        private System.Windows.Forms.RichTextBox tbxContent;
        private System.Windows.Forms.RichTextBox tbxBrief;
        private System.Windows.Forms.CheckBox chbxIsAnnounce;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInfo;
    }
}