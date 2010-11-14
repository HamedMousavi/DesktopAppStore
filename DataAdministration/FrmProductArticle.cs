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
    public partial class FrmProductArticle : Form
    {
        private DomainModel.Entities.ApplicationProduct product;


        public FrmProductArticle()
        {
            InitializeComponent();
        }


        public FrmProductArticle(DomainModel.Entities.ApplicationProduct product)
            :this()
        {
            this.product = product;
            this.tbxArticle.DataBindings.Add(new Binding("Text", this.product.Article, "Content", true, DataSourceUpdateMode.OnPropertyChanged, ""));
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(product.Article.Content))
            {
                Repository.Sql.Product.UpdateArticle(product);
            }
        }
    }
}
