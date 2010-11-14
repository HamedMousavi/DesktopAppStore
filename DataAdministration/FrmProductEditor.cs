using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DomainModel.Entities;

namespace DataAdministration
{
    public partial class FrmProductEditor : Form
    {

        public ApplicationProduct Product { get; set; }

        protected ProductCategoriesCheckedListBox chbxCategories;
        protected Label lblCategories;

        protected OptionCheckedListBox[] chbxOptions;
        protected Label[] lblOptions;
        protected string[] optionCheckedListBoxNames;

        // 5 Columns. Width and heights of options is by default
        // defined in main class
        protected readonly int OptionBoxColumnCount = 5;
        private Point topLeft = new Point(10, 100);


        public FrmProductEditor(ApplicationProduct product)
        {
            this.Product = product;

            InitializeComponent();

            InitializeOptionBoxes();

            EnableControls();

            BindProduct();
        }


        private void EnableControls()
        {
            if (this.Product.ProductId <= 0 || this.Product.ProductId == null)
            {
                this.splitMain.Panel2.Enabled = false;
            }
            else
            {
                this.splitMain.Panel2.Enabled = true;
            }

            this.btnCreateProduct.Enabled = !this.splitMain.Panel2.Enabled;
            this.btnUpdateProduct.Enabled = this.splitMain.Panel2.Enabled;
        }


       
        private void BindProduct()
        {
            this.tbxProductPrice.DataBindings.Add(new Binding("Text", this.Product, "Price", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxProductReleaseDate.DataBindings.Add(new Binding("Text", this.Product, "ProductReleaseDate", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxProductVersion.DataBindings.Add(new Binding("Text", this.Product, "ProductVersion", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxProductVolumeSize.DataBindings.Add(new Binding("Text", this.Product, "MinimumVolumeSize", true, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.tbxProductWebsite.DataBindings.Add(new Binding("Text", this.Product, "ProductWebsite", true, DataSourceUpdateMode.OnPropertyChanged, ""));

            this.chbxProductLangExtendable.DataBindings.Add(new Binding("Checked", this.Product, "LanguageExtendable"));
            this.chbxProductMultiLanguage.DataBindings.Add(new Binding("Checked", this.Product, "MultiLanguage"));
            this.chbxProductMultiUser.DataBindings.Add(new Binding("Checked", this.Product, "MultiUser"));
        }



        // WARNING: THIS FUNCTION USES NAMES DEFINED IN optionCheckedListBoxNames 
        // TO ASSOSIATE INDEX TO AN OPTION MEMBER VARIABLE OF A PRODUCT
        private void BindProductOptions()
        {
            this.chbxOptions[0].SelectedDataSource = this.Product.SupportedPlatforms;
            this.chbxOptions[1].SelectedDataSource = this.Product.SourceOptions;
            this.chbxOptions[2].SelectedDataSource = this.Product.ProductTechnologies;
            this.chbxOptions[3].SelectedDataSource = this.Product.Tags;
            this.chbxOptions[4].SelectedDataSource = this.Product.SupportedLanguages;
            this.chbxOptions[5].SelectedDataSource = this.Product.ExtensionOptions;
            this.chbxOptions[6].SelectedDataSource = this.Product.PaymentOptions;
            this.chbxOptions[7].SelectedDataSource = this.Product.PublishOptions;
            this.chbxOptions[8].SelectedDataSource = this.Product.DemoOptions;
            this.chbxOptions[9].SelectedDataSource = this.Product.InstallationOptions;
            this.chbxOptions[10].SelectedDataSource = this.Product.TrainingOptions;
            this.chbxOptions[11].SelectedDataSource = this.Product.SupportOptions;
            this.chbxOptions[12].SelectedDataSource = this.Product.SupportTypes;
            this.chbxOptions[13].SelectedDataSource = this.Product.GuarantyOptions;
            this.chbxOptions[14].SelectedDataSource = this.Product.EnvironmentOptions;
            this.chbxOptions[15].SelectedDataSource = this.Product.CustomizationOptions;
            this.chbxOptions[16].SelectedDataSource = this.Product.UpdateOptions;
            this.chbxOptions[17].SelectedDataSource = this.Product.BackupOptions;
            this.chbxCategories.SelectedDataSource = this.Product.Categories;
        }



        private void InitializeOptionBoxes()
        {
            this.optionCheckedListBoxNames = new string[] 
            { 
                "ListSoftwarePlatforms", 
                "ListSourceOptions", 
                "ListProductTechnologies", 
                "ListTags",
                "ListLanguages", 
                "ListExtensionOptions", 
                "ListPaymentOptions", 
                "ListPublishOptions", 
                "ListDemoOptions", 
                "ListInstallationOptions", 
                "ListTrainingOptions", 
                "ListSupportOptions", 
                "ListSupportTypes", 
                "ListGuarantyOptions", 
                "ListEnvironmentOptions", 
                "ListCustomizationOptions", 
                "ListUpdateOptions", 
                "ListDataBackupOptions"
            };

            int i;
            Point ptLocation;

            int itemCount = this.optionCheckedListBoxNames.GetLength(0);
            this.chbxOptions = new OptionCheckedListBox[itemCount];
            this.lblOptions = new Label[itemCount];

            for (i = 0; i < itemCount; i++)
            {
                ptLocation = GetChbxLocation(i);

                this.lblOptions[i] = new Label();
                this.lblOptions[i].Location = ptLocation; this.lblOptions[i].Top -= 15;
                this.lblOptions[i].Text = optionCheckedListBoxNames[i];

                this.chbxOptions[i] = new OptionCheckedListBox(this.Product);
                this.chbxOptions[i].TabIndex = i + 7;
                this.chbxOptions[i].Name = "chbx" + optionCheckedListBoxNames[i];
                this.chbxOptions[i].Location = ptLocation;
                this.chbxOptions[i].AllDataSource = Repository.Sql.Options.GetOptions(optionCheckedListBoxNames[i], this.Product.ArticleLanguage);

                this.chbxOptions[i].AddAction = Repository.Sql.ProductOptions.Insert;
                this.chbxOptions[i].RemoveAction = Repository.Sql.ProductOptions.Remove;
            }

            CreateProductCategories(i);


            this.splitMain.Panel2.Controls.AddRange(this.chbxOptions);
            this.splitMain.Panel2.Controls.AddRange(this.lblOptions);

            this.Width = OptionBoxColumnCount * (this.chbxOptions[itemCount - 1].Width + 5) + topLeft.X + 20;
            this.Height = (itemCount / OptionBoxColumnCount + 1) * (this.chbxOptions[itemCount - 1].Height + 20) + this.splitMain.Panel1.Height + topLeft.Y + 20;

            // WARNING: THIS FUNCTION USES NAMES DEFINED IN optionCheckedListBoxNames 
            // TO ASSOSIATE INDEX TO AN OPTION MEMBER VARIABLE OF A PRODUCT
            BindProductOptions();
        }



        private void CreateProductCategories(int i)
        {
            Point ptLocation = GetChbxLocation(i);
            
            this.lblCategories = new Label();
            this.lblCategories.Location = ptLocation; this.lblCategories.Top -= 15;
            this.lblCategories.Text = "Products Categories";

            this.chbxCategories = new ProductCategoriesCheckedListBox(this.Product);
            this.chbxCategories.TabIndex = i + 7;
            this.chbxCategories.Name = "chbxProductsCategories";
            this.chbxCategories.Location = ptLocation;
            this.chbxCategories.AllDataSource = Repository.Sql.ProductCategories.GetAll(this.Product.ArticleLanguage);

            this.chbxCategories.AddAction = Repository.Sql.ProductCategories.Insert;
            this.chbxCategories.RemoveAction = Repository.Sql.ProductCategories.Remove;

            this.splitMain.Panel2.Controls.Add(this.chbxCategories);
            this.splitMain.Panel2.Controls.Add(this.lblCategories);
        }



        private Point GetChbxLocation(int index)
        {
            int col = index % OptionBoxColumnCount;
            int row = index / OptionBoxColumnCount;

            return new Point(col * 185 + topLeft.X, row * 145 + topLeft.Y);
        }



        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            if (this.Product.ProductId > 0) throw new InvalidOperationException("This product already exists.");

            Repository.Sql.Product.Insert(this.Product);

            if (this.Product.ProductId > 0)
            {
                using (FrmProductCatalog frm = new FrmProductCatalog(this.Product))
                {
                    frm.ShowDialog();
                }

                Repository.Sql.Product.InsertCatalaog(this.Product);

                // Create resource directories
                System.IO.Directory.CreateDirectory(DataAdministration.Properties.Settings.Default.ProductResDirBase + this.Product.Catalog.UrlName);
                System.IO.Directory.CreateDirectory(DataAdministration.Properties.Settings.Default.ProductResDirBase + this.Product.Catalog.UrlName + DataAdministration.Properties.Settings.Default.ScreenshotDirName);
                System.IO.Directory.CreateDirectory(DataAdministration.Properties.Settings.Default.ProductResDirBase + this.Product.Catalog.UrlName + DataAdministration.Properties.Settings.Default.ScreenshotDirName + Properties.Settings.Default.ThumbnailDirName);

                EnableControls();
            }
        }



        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (!(this.Product.ProductId > 0)) throw new InvalidOperationException("Product does not exist.");

            Repository.Sql.Product.Update(this.Product);

            EnableControls();
        }



        private void btnContacts_Click(object sender, EventArgs e)
        {
            using (FrmProductContacts frm = new FrmProductContacts(this.Product))
            {
                frm.ShowDialog();
            }
        }




        private void btnHardwareRequirements_Click(object sender, EventArgs e)
        {
            using (FrmHardwareRequirements frm = new FrmHardwareRequirements(this.Product))
            {
                frm.ShowDialog();
            }
        }



        private void btnBrands_Click(object sender, EventArgs e)
        {
            using (FrmBrands frm = new FrmBrands(this.Product))
            {
                frm.ShowDialog();
            }
        }



        private void btnCatalog_Click(object sender, EventArgs e)
        {
            using (FrmProductCatalog frm = new FrmProductCatalog(this.Product))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Repository.Sql.Product.UpdateCatalog(this.Product);
                }
            }
        }



        private void btnDetails_Click(object sender, EventArgs e)
        {
            using (FrmProductDetails frm = new FrmProductDetails(this.Product))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Repository.Sql.Product.UpdateDetails(this.Product);
                }
            }
        }


        private void btnSupportNewLanguage_Click(object sender, EventArgs e)
        {
            int languageId = 1;
            using (FrmLanguageSelector frm = new FrmLanguageSelector())
            {
                frm.ShowDialog();
                languageId = frm.SelectedLanguage;

                if (Repository.Sql.Product.LanguageExists(this.Product.ProductId.Value, languageId))
                {
                    MessageBox.Show("Language already exists. Nothing added.");
                    return;
                }
            }

            using (FrmProductDetails frm = new FrmProductDetails(null))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Repository.Sql.Product.InsertDetail(
                        this.Product,
                        languageId,
                        frm.ProductName,
                        frm.ProductDescription,
                        frm.PriceDetails,
                        frm.GuarantyDetails);

                    if (this.Product.ArticleLanguage <= 0)
                    {
                        this.Product.ArticleLanguage = languageId;
                        this.Product.ProductName = frm.ProductName;
                        this.Product.BriefDescription = frm.ProductDescription;
                        this.Product.PriceDetails = frm.PriceDetails;
                        this.Product.GuarantyDetails = frm.GuarantyDetails;
                    }
                }
            }
        }



        private void btnArticle_Click(object sender, EventArgs e)
        {
            using (FrmProductArticle frm = new FrmProductArticle(this.Product))
            {
                frm.ShowDialog();
            }
        }



        private void btnScreenshots_Click(object sender, EventArgs e)
        {
            using (FrmProductScreenshots frm = new FrmProductScreenshots(this.Product))
            {
                frm.ShowDialog();
            }
        }



        private void btnOwners_Click(object sender, EventArgs e)
        {
            using (FrmProductScreenshots frm = new FrmProductScreenshots(this.Product))
            {
                frm.ShowDialog();
            }
        }
    }
}
