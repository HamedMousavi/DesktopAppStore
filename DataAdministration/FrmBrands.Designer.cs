namespace DataAdministration
{
    partial class FrmBrands
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbxBrandName = new System.Windows.Forms.TextBox();
            this.tbxNewBrandName = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbxBrands = new System.Windows.Forms.ListBox();
            this.btnExistingBrand = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbxBrandName);
            this.splitContainer1.Panel1.Controls.Add(this.tbxNewBrandName);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnExistingBrand);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbxBrands);
            this.splitContainer1.Size = new System.Drawing.Size(241, 262);
            this.splitContainer1.SplitterDistance = 52;
            this.splitContainer1.TabIndex = 0;
            // 
            // tbxBrandName
            // 
            this.tbxBrandName.Location = new System.Drawing.Point(3, 30);
            this.tbxBrandName.Name = "tbxBrandName";
            this.tbxBrandName.Size = new System.Drawing.Size(100, 20);
            this.tbxBrandName.TabIndex = 1;
            // 
            // tbxNewBrandName
            // 
            this.tbxNewBrandName.Location = new System.Drawing.Point(3, 4);
            this.tbxNewBrandName.Name = "tbxNewBrandName";
            this.tbxNewBrandName.Size = new System.Drawing.Size(100, 20);
            this.tbxNewBrandName.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DarkGray;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Location = new System.Drawing.Point(167, 27);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(71, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "- Delete";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(109, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Update";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkGray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Location = new System.Drawing.Point(109, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+ New";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbxBrands
            // 
            this.lbxBrands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxBrands.FormattingEnabled = true;
            this.lbxBrands.Location = new System.Drawing.Point(0, 0);
            this.lbxBrands.Name = "lbxBrands";
            this.lbxBrands.Size = new System.Drawing.Size(241, 206);
            this.lbxBrands.TabIndex = 0;
            this.lbxBrands.SelectedIndexChanged += new System.EventHandler(this.lbxBrands_SelectedIndexChanged);
            // 
            // btnExistingBrand
            // 
            this.btnExistingBrand.BackColor = System.Drawing.Color.DarkGray;
            this.btnExistingBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExistingBrand.Location = new System.Drawing.Point(167, 2);
            this.btnExistingBrand.Name = "btnExistingBrand";
            this.btnExistingBrand.Size = new System.Drawing.Size(71, 23);
            this.btnExistingBrand.TabIndex = 0;
            this.btnExistingBrand.Text = "+ Existing";
            this.btnExistingBrand.UseVisualStyleBackColor = false;
            this.btnExistingBrand.Click += new System.EventHandler(this.btnExistingBrand_Click);
            // 
            // FrmBrands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 262);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmBrands";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmBrands";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbxBrandName;
        private System.Windows.Forms.TextBox tbxNewBrandName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbxBrands;
        private System.Windows.Forms.Button btnExistingBrand;
    }
}