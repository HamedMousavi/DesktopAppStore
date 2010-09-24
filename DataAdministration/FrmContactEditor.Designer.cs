namespace DataAdministration
{
    partial class FrmContactEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxListContactUnits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxContactValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxContactPerson = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxListContactMedia = new System.Windows.Forms.ComboBox();
            this.btnAddContactMedia = new System.Windows.Forms.Button();
            this.btnAddContactUnit = new System.Windows.Forms.Button();
            this.rtnNewContact = new System.Windows.Forms.RadioButton();
            this.rtnExisting = new System.Windows.Forms.RadioButton();
            this.btnSearchContacts = new System.Windows.Forms.Button();
            this.grpNewContact = new System.Windows.Forms.GroupBox();
            this.grpNewContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Media";
            // 
            // cbxListContactUnits
            // 
            this.cbxListContactUnits.FormattingEnabled = true;
            this.cbxListContactUnits.Location = new System.Drawing.Point(47, 39);
            this.cbxListContactUnits.Name = "cbxListContactUnits";
            this.cbxListContactUnits.Size = new System.Drawing.Size(170, 21);
            this.cbxListContactUnits.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unit";
            // 
            // tbxContactValue
            // 
            this.tbxContactValue.Location = new System.Drawing.Point(47, 66);
            this.tbxContactValue.Name = "tbxContactValue";
            this.tbxContactValue.Size = new System.Drawing.Size(206, 20);
            this.tbxContactValue.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value";
            // 
            // tbxContactPerson
            // 
            this.tbxContactPerson.Location = new System.Drawing.Point(47, 92);
            this.tbxContactPerson.Name = "tbxContactPerson";
            this.tbxContactPerson.Size = new System.Drawing.Size(206, 20);
            this.tbxContactPerson.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Person";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbxListContactMedia
            // 
            this.cbxListContactMedia.FormattingEnabled = true;
            this.cbxListContactMedia.Location = new System.Drawing.Point(47, 12);
            this.cbxListContactMedia.Name = "cbxListContactMedia";
            this.cbxListContactMedia.Size = new System.Drawing.Size(170, 21);
            this.cbxListContactMedia.TabIndex = 1;
            // 
            // btnAddContactMedia
            // 
            this.btnAddContactMedia.Location = new System.Drawing.Point(223, 11);
            this.btnAddContactMedia.Name = "btnAddContactMedia";
            this.btnAddContactMedia.Size = new System.Drawing.Size(30, 23);
            this.btnAddContactMedia.TabIndex = 8;
            this.btnAddContactMedia.Text = "+";
            this.btnAddContactMedia.UseVisualStyleBackColor = true;
            this.btnAddContactMedia.Click += new System.EventHandler(this.btnAddContactMedia_Click);
            // 
            // btnAddContactUnit
            // 
            this.btnAddContactUnit.Location = new System.Drawing.Point(223, 37);
            this.btnAddContactUnit.Name = "btnAddContactUnit";
            this.btnAddContactUnit.Size = new System.Drawing.Size(30, 23);
            this.btnAddContactUnit.TabIndex = 8;
            this.btnAddContactUnit.Text = "+";
            this.btnAddContactUnit.UseVisualStyleBackColor = true;
            this.btnAddContactUnit.Click += new System.EventHandler(this.btnAddContactUnit_Click);
            // 
            // rtnNewContact
            // 
            this.rtnNewContact.AutoSize = true;
            this.rtnNewContact.Location = new System.Drawing.Point(13, 68);
            this.rtnNewContact.Name = "rtnNewContact";
            this.rtnNewContact.Size = new System.Drawing.Size(86, 17);
            this.rtnNewContact.TabIndex = 10;
            this.rtnNewContact.TabStop = true;
            this.rtnNewContact.Text = "New contact";
            this.rtnNewContact.UseVisualStyleBackColor = true;
            this.rtnNewContact.CheckedChanged += new System.EventHandler(this.rtnNewContact_CheckedChanged);
            // 
            // rtnExisting
            // 
            this.rtnExisting.AutoSize = true;
            this.rtnExisting.Location = new System.Drawing.Point(13, 12);
            this.rtnExisting.Name = "rtnExisting";
            this.rtnExisting.Size = new System.Drawing.Size(100, 17);
            this.rtnExisting.TabIndex = 10;
            this.rtnExisting.TabStop = true;
            this.rtnExisting.Text = "Existing contact";
            this.rtnExisting.UseVisualStyleBackColor = true;
            this.rtnExisting.CheckedChanged += new System.EventHandler(this.rtnExisting_CheckedChanged);
            // 
            // btnSearchContacts
            // 
            this.btnSearchContacts.Location = new System.Drawing.Point(60, 35);
            this.btnSearchContacts.Name = "btnSearchContacts";
            this.btnSearchContacts.Size = new System.Drawing.Size(143, 23);
            this.btnSearchContacts.TabIndex = 8;
            this.btnSearchContacts.Text = "Search existing contacts";
            this.btnSearchContacts.UseVisualStyleBackColor = true;
            this.btnSearchContacts.Click += new System.EventHandler(this.btnSearchContacts_Click);
            // 
            // grpNewContact
            // 
            this.grpNewContact.Controls.Add(this.label1);
            this.grpNewContact.Controls.Add(this.cbxListContactUnits);
            this.grpNewContact.Controls.Add(this.cbxListContactMedia);
            this.grpNewContact.Controls.Add(this.label2);
            this.grpNewContact.Controls.Add(this.btnAddContactUnit);
            this.grpNewContact.Controls.Add(this.tbxContactValue);
            this.grpNewContact.Controls.Add(this.label3);
            this.grpNewContact.Controls.Add(this.btnAddContactMedia);
            this.grpNewContact.Controls.Add(this.tbxContactPerson);
            this.grpNewContact.Controls.Add(this.label4);
            this.grpNewContact.Location = new System.Drawing.Point(13, 91);
            this.grpNewContact.Name = "grpNewContact";
            this.grpNewContact.Size = new System.Drawing.Size(259, 122);
            this.grpNewContact.TabIndex = 11;
            this.grpNewContact.TabStop = false;
            // 
            // FrmContactEditor
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.grpNewContact);
            this.Controls.Add(this.rtnExisting);
            this.Controls.Add(this.rtnNewContact);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearchContacts);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmContactEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmContactEditor";
            this.grpNewContact.ResumeLayout(false);
            this.grpNewContact.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxListContactUnits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxContactValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxContactPerson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxListContactMedia;
        private System.Windows.Forms.Button btnAddContactMedia;
        private System.Windows.Forms.Button btnAddContactUnit;
        private System.Windows.Forms.RadioButton rtnNewContact;
        private System.Windows.Forms.RadioButton rtnExisting;
        private System.Windows.Forms.Button btnSearchContacts;
        private System.Windows.Forms.GroupBox grpNewContact;
    }
}