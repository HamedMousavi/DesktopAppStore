namespace DataAdministration
{
    partial class FrmProductCatalog
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
            this.tbxUrlName = new System.Windows.Forms.TextBox();
            this.btnCanel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.lblUrlNameValidationStatus = new System.Windows.Forms.Label();
            this.tbxSearchPriority = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbxIsEnabled = new System.Windows.Forms.CheckBox();
            this.chbxIsFeatured = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UrlName";
            // 
            // tbxUrlName
            // 
            this.tbxUrlName.Location = new System.Drawing.Point(66, 12);
            this.tbxUrlName.Name = "tbxUrlName";
            this.tbxUrlName.Size = new System.Drawing.Size(151, 20);
            this.tbxUrlName.TabIndex = 1;
            // 
            // btnCanel
            // 
            this.btnCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanel.Location = new System.Drawing.Point(142, 118);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(75, 23);
            this.btnCanel.TabIndex = 9;
            this.btnCanel.Text = "Cancel";
            this.btnCanel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(222, 118);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Done";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(222, 10);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 2;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // lblUrlNameValidationStatus
            // 
            this.lblUrlNameValidationStatus.AutoSize = true;
            this.lblUrlNameValidationStatus.Location = new System.Drawing.Point(12, 39);
            this.lblUrlNameValidationStatus.Name = "lblUrlNameValidationStatus";
            this.lblUrlNameValidationStatus.Size = new System.Drawing.Size(0, 13);
            this.lblUrlNameValidationStatus.TabIndex = 3;
            // 
            // tbxSearchPriority
            // 
            this.tbxSearchPriority.Location = new System.Drawing.Point(90, 64);
            this.tbxSearchPriority.Name = "tbxSearchPriority";
            this.tbxSearchPriority.Size = new System.Drawing.Size(127, 20);
            this.tbxSearchPriority.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SearchPriority";
            // 
            // chbxIsEnabled
            // 
            this.chbxIsEnabled.AutoSize = true;
            this.chbxIsEnabled.Checked = true;
            this.chbxIsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxIsEnabled.Location = new System.Drawing.Point(15, 124);
            this.chbxIsEnabled.Name = "chbxIsEnabled";
            this.chbxIsEnabled.Size = new System.Drawing.Size(76, 17);
            this.chbxIsEnabled.TabIndex = 7;
            this.chbxIsEnabled.Text = "Is Enabled";
            this.chbxIsEnabled.UseVisualStyleBackColor = true;
            // 
            // chbxIsFeatured
            // 
            this.chbxIsFeatured.AutoSize = true;
            this.chbxIsFeatured.Location = new System.Drawing.Point(15, 101);
            this.chbxIsFeatured.Name = "chbxIsFeatured";
            this.chbxIsFeatured.Size = new System.Drawing.Size(79, 17);
            this.chbxIsFeatured.TabIndex = 6;
            this.chbxIsFeatured.Text = "Is Featured";
            this.chbxIsFeatured.UseVisualStyleBackColor = true;
            // 
            // FrmProductCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCanel;
            this.ClientSize = new System.Drawing.Size(309, 147);
            this.Controls.Add(this.chbxIsEnabled);
            this.Controls.Add(this.chbxIsFeatured);
            this.Controls.Add(this.lblUrlNameValidationStatus);
            this.Controls.Add(this.btnCanel);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSearchPriority);
            this.Controls.Add(this.tbxUrlName);
            this.Name = "FrmProductCatalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmProductCatalog";
            this.Load += new System.EventHandler(this.FrmProductCatalog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxUrlName;
        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label lblUrlNameValidationStatus;
        private System.Windows.Forms.TextBox tbxSearchPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbxIsEnabled;
        private System.Windows.Forms.CheckBox chbxIsFeatured;

    }
}