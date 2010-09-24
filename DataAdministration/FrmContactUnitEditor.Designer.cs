namespace DataAdministration
{
    partial class FrmContactUnitEditor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.unitTitleIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitTitleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listContactUnitTitlesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.persianSoftwareDataSet = new DataAdministration.PersianSoftwareDataSet();
            this.listContactUnitTitlesTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ListContactUnitTitlesTableAdapter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listContactUnitTitlesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.unitTitleIdDataGridViewTextBoxColumn,
            this.unitTitleNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.listContactUnitTitlesBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(299, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // unitTitleIdDataGridViewTextBoxColumn
            // 
            this.unitTitleIdDataGridViewTextBoxColumn.DataPropertyName = "UnitTitleId";
            this.unitTitleIdDataGridViewTextBoxColumn.HeaderText = "UnitTitleId";
            this.unitTitleIdDataGridViewTextBoxColumn.Name = "unitTitleIdDataGridViewTextBoxColumn";
            this.unitTitleIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitTitleNameDataGridViewTextBoxColumn
            // 
            this.unitTitleNameDataGridViewTextBoxColumn.DataPropertyName = "UnitTitleName";
            this.unitTitleNameDataGridViewTextBoxColumn.HeaderText = "UnitTitleName";
            this.unitTitleNameDataGridViewTextBoxColumn.Name = "unitTitleNameDataGridViewTextBoxColumn";
            // 
            // listContactUnitTitlesBindingSource
            // 
            this.listContactUnitTitlesBindingSource.DataMember = "ListContactUnitTitles";
            this.listContactUnitTitlesBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // persianSoftwareDataSet
            // 
            this.persianSoftwareDataSet.DataSetName = "PersianSoftwareDataSet";
            this.persianSoftwareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listContactUnitTitlesTableAdapter
            // 
            this.listContactUnitTitlesTableAdapter.ClearBeforeFill = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(299, 338);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmContactUnitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 338);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmContactUnitEditor";
            this.Text = "FrmContactUnitEditor";
            this.Load += new System.EventHandler(this.FrmContactUnitEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listContactUnitTitlesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private PersianSoftwareDataSet persianSoftwareDataSet;
        private System.Windows.Forms.BindingSource listContactUnitTitlesBindingSource;
        private PersianSoftwareDataSetTableAdapters.ListContactUnitTitlesTableAdapter listContactUnitTitlesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitTitleIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitTitleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSave;
    }
}