namespace DataAdministration
{
    partial class FrmHardwareRequirements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHardwareRequirements));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fillByProductIdToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.requirementIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productHardwareRequirementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.persianSoftwareDataSet = new DataAdministration.PersianSoftwareDataSet();
            this.productHardwareRequirementsTableAdapter = new DataAdministration.PersianSoftwareDataSetTableAdapters.ProductHardwareRequirementsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.fillByProductIdToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productHardwareRequirementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.fillByProductIdToolStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(441, 344);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // fillByProductIdToolStrip
            // 
            this.fillByProductIdToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.fillByProductIdToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByProductIdToolStrip.Name = "fillByProductIdToolStrip";
            this.fillByProductIdToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.fillByProductIdToolStrip.Size = new System.Drawing.Size(441, 25);
            this.fillByProductIdToolStrip.TabIndex = 1;
            this.fillByProductIdToolStrip.Text = "fillByProductIdToolStrip";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Blue;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requirementIdDataGridViewTextBoxColumn,
            this.productIdDataGridViewTextBoxColumn,
            this.requirementDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productHardwareRequirementsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(441, 315);
            this.dataGridView1.TabIndex = 0;
            // 
            // requirementIdDataGridViewTextBoxColumn
            // 
            this.requirementIdDataGridViewTextBoxColumn.DataPropertyName = "RequirementId";
            this.requirementIdDataGridViewTextBoxColumn.HeaderText = "RequirementId";
            this.requirementIdDataGridViewTextBoxColumn.Name = "requirementIdDataGridViewTextBoxColumn";
            this.requirementIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "ProductId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "ProductId";
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            // 
            // requirementDataGridViewTextBoxColumn
            // 
            this.requirementDataGridViewTextBoxColumn.DataPropertyName = "Requirement";
            this.requirementDataGridViewTextBoxColumn.HeaderText = "Requirement";
            this.requirementDataGridViewTextBoxColumn.Name = "requirementDataGridViewTextBoxColumn";
            // 
            // productHardwareRequirementsBindingSource
            // 
            this.productHardwareRequirementsBindingSource.DataMember = "ProductHardwareRequirements";
            this.productHardwareRequirementsBindingSource.DataSource = this.persianSoftwareDataSet;
            // 
            // persianSoftwareDataSet
            // 
            this.persianSoftwareDataSet.DataSetName = "PersianSoftwareDataSet";
            this.persianSoftwareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productHardwareRequirementsTableAdapter
            // 
            this.productHardwareRequirementsTableAdapter.ClearBeforeFill = true;
            // 
            // FrmHardwareRequirements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 344);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmHardwareRequirements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmHardwareRequirements";
            this.Load += new System.EventHandler(this.FrmHardwareRequirements_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.fillByProductIdToolStrip.ResumeLayout(false);
            this.fillByProductIdToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productHardwareRequirementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianSoftwareDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private PersianSoftwareDataSet persianSoftwareDataSet;
        private System.Windows.Forms.BindingSource productHardwareRequirementsBindingSource;
        private PersianSoftwareDataSetTableAdapters.ProductHardwareRequirementsTableAdapter productHardwareRequirementsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip fillByProductIdToolStrip;
        private System.Windows.Forms.ToolStripButton btnSave;
    }
}