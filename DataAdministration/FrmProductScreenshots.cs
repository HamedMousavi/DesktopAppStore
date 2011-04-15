using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DomainModel.Entities;
using System.Xml;

namespace DataAdministration
{
    public partial class FrmProductScreenshots : Form
    {
        protected ApplicationProduct product;

        protected readonly string MetaDataNodeImages = "screenshots/image";
        protected readonly string MetaDataNodeThumbnail = "thumbnail";
        protected readonly string MetaDataNodeFileName = "filename";
        protected readonly string MetaDataNodeWidth = "width";
        protected readonly string MetaDataNodeHeight = "height";
        protected readonly string MetaDataNodeDescription = "description";
        protected readonly string MetaDataNodeTitle = "title";

        protected readonly Size MAX_SCREENSHOT_SIZE = Properties.Settings.Default.MaxScreenshotSize;
        protected readonly Size THUMBNAIL_SIZE = Properties.Settings.Default.MaxThumbnailSize;


        protected string productScreenshotDirectory;
        protected BindingList<ProductImage> images;
        protected ProductImage selectedImage;


        public FrmProductScreenshots()
        {
            InitializeComponent();

            this.images = new BindingList<ProductImage>();
            this.lbxImages.DataBindings.Clear();
            this.lbxImages.DataSource = this.images;
            this.lbxImages.DisplayMember = "Url";
            this.lbxImages.ValueMember = "Url";
        }

        public FrmProductScreenshots(ApplicationProduct product)
            :this()
        {
            this.product = product;

            this.productScreenshotDirectory = 
                DataAdministration.Properties.Settings.Default.ProductResDirBase +
                this.product.Catalog.UrlName +
                DataAdministration.Properties.Settings.Default.ScreenshotDirName;
        }



        private void FrmProductScreenshots_Load(object sender, EventArgs e)
        {
            this.listLanguagesTableAdapter.Fill(this.persianSoftwareDataSet.ListLanguages);
        }



        private void SaveScreenshotChanges()
        {
            if (this.selectedImage != null)
            {
                // Save changes
                if (this.selectedImage.Description != this.tbxDescription.Text ||
                        this.selectedImage.Thumbnail.Title != this.tbxTitle.Text)
                {
                    this.selectedImage.Thumbnail.Title = this.tbxTitle.Text;
                    this.selectedImage.Description = this.tbxDescription.Text;
                }
            }

            // Update selected image
            this.selectedImage = this.lbxImages.SelectedItem as ProductImage;

            if (this.selectedImage != null)
            {
                // Update image details on screen
                this.tbxTitle.Text = this.selectedImage.Thumbnail.Title;
                this.tbxDescription.Text = this.selectedImage.Description;
            }
        }



        private void LoadImageListFromDirectoryStructure(string directory)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(directory);
            System.IO.FileInfo[] files = dir.GetFiles("*.jpg");

            this.images.Clear();

            foreach (System.IO.FileInfo file in files)
            {
                ProductImage img = new ProductImage();

                using (Image imagefile = Image.FromFile(file.FullName))
                {
                    img.ImageSize = new Size(imagefile.Size.Width, imagefile.Size.Height);
                }
                img.Description = "";
                img.Url = file.Name;

                if (System.IO.File.Exists(directory + Properties.Settings.Default.ThumbnailDirName + file.Name))
                {
                    img.Thumbnail.Title = "";
                    img.Thumbnail.Url = file.Name;
                }

                this.images.Add(img);
            }

            if (this.images.Count > 0)
            {
                this.selectedImage = this.images[0];
                this.tbxTitle.Text = this.selectedImage.Thumbnail.Title;
                this.tbxDescription.Text = this.selectedImage.Description;
            }
        }



        private void CreateThumbnail(System.IO.FileInfo file, string fileName)
        {
            using (Image imagefile = Image.FromFile(file.FullName))
            {
                using (Bitmap newImg = Repository.Utils.ImageHelpers.ResizeImage(imagefile, THUMBNAIL_SIZE))
                {
                    Repository.Utils.ImageHelpers.SaveJpeg(fileName, newImg, 16);
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveScreenshotChanges();
            GenerateMetaData();
        }



        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog frm = new FolderBrowserDialog())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.tbxImageSrcDir.Text = frm.SelectedPath;
                }
            }
        }


        
        private void GenerateMetaData()
        {
            string MetaDataFileName = string.Format("{0}.MetaData.xml", Convert.ToString(this.cbxLanguages.SelectedValue).Trim());
            string metadataFileFullName = productScreenshotDirectory + MetaDataFileName;

            XmlDocument doc = new System.Xml.XmlDocument();
            
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            
            // Create the root element
            XmlElement root = doc.CreateElement("screenshots");
            doc.AppendChild(root);


            foreach (ProductImage screenshot in this.images)
            {
                XmlElement filename = doc.CreateElement(MetaDataNodeFileName);
                filename.InnerText = screenshot.Url;

                XmlElement description = doc.CreateElement(MetaDataNodeDescription);
                description.InnerText = screenshot.Description;

                XmlElement width = doc.CreateElement(MetaDataNodeWidth);
                width.InnerText = screenshot.ImageSize.Width.ToString();

                XmlElement height = doc.CreateElement(MetaDataNodeHeight);
                height.InnerText = screenshot.ImageSize.Height.ToString();

                XmlElement thumbfilename = doc.CreateElement(MetaDataNodeFileName);
                thumbfilename.InnerText = screenshot.Thumbnail.Url;

                XmlElement thumbtitle = doc.CreateElement(MetaDataNodeTitle);
                thumbtitle.InnerText = screenshot.Thumbnail.Title;

                XmlElement thumbnail = doc.CreateElement(MetaDataNodeThumbnail);
                thumbnail.AppendChild(thumbfilename);
                thumbnail.AppendChild(thumbtitle);

                XmlElement image = doc.CreateElement("image");
                image.AppendChild(filename);
                image.AppendChild(description);
                image.AppendChild(width);
                image.AppendChild(height);
                image.AppendChild(thumbnail);

                root.AppendChild(image);
            }

            doc.Save(metadataFileFullName);
        }



        private void btnLoadMetaDataFile_Click(object sender, EventArgs e)
        {
            LoadImageListFromMetaDataFile();
        }



        private void LoadImageListFromMetaDataFile()
        {
            string MetaDataFileName = string.Format("{0}.MetaData.xml", Convert.ToString(this.cbxLanguages.SelectedValue).Trim());
            string metadataFileFullName = productScreenshotDirectory + MetaDataFileName;

            if (!System.IO.File.Exists(metadataFileFullName))
            {
                MessageBox.Show("No metadatafile exists for selected language and product.");
                return;
            }

            this.images.Clear();

            XmlDocument metadata = new XmlDocument();
            metadata.Load(metadataFileFullName);

            XmlNodeList imgs = metadata.SelectNodes(MetaDataNodeImages);
            foreach (XmlNode image in imgs)
            {
                ProductImage productImage = new ProductImage();

                productImage.Url = image.SelectSingleNode(MetaDataNodeFileName).InnerText;
                productImage.Description = image.SelectSingleNode(MetaDataNodeDescription).InnerText;
                productImage.ImageSize = new System.Drawing.Size(
                    Convert.ToInt32(image.SelectSingleNode(MetaDataNodeWidth).InnerText),
                    Convert.ToInt32(image.SelectSingleNode(MetaDataNodeHeight).InnerText));

                XmlNodeList thumb = image.SelectNodes(MetaDataNodeThumbnail);
                if (thumb.Count > 0)
                {
                    productImage.Thumbnail.Url = thumb[0].SelectSingleNode(MetaDataNodeFileName).InnerText;
                    productImage.Thumbnail.Title = thumb[0].SelectSingleNode(MetaDataNodeTitle).InnerText;
                }

                this.images.Add(productImage);
            }

            if (this.images.Count > 0)
            {
                this.selectedImage = this.images[0];
                this.tbxTitle.Text = this.selectedImage.Thumbnail.Title;
                this.tbxDescription.Text = this.selectedImage.Description;
            }
        }



        private void lbxImages_SelectedValueChanged(object sender, EventArgs e)
        {
            SaveScreenshotChanges();
        }



        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateMetaData();
        }



        private void btnCopyCreate_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(this.tbxImageSrcDir.Text);
            System.IO.FileInfo[] files = dir.GetFiles("*.jpg");

            int index = 1;
            string fileName;

            foreach (System.IO.FileInfo file in files)
            {
                fileName = string.Format("{0}{1:000}.jpg", this.productScreenshotDirectory, index);

                using (Image imagefile = Image.FromFile(file.FullName))
                {
                    if (imagefile.Size.Width > MAX_SCREENSHOT_SIZE.Width || imagefile.Size.Height > MAX_SCREENSHOT_SIZE.Height)
                    {
                        using (Bitmap newImg = Repository.Utils.ImageHelpers.ResizeImage(imagefile, MAX_SCREENSHOT_SIZE))
                        {
                            Repository.Utils.ImageHelpers.SaveJpeg(fileName, newImg, 16);
                        }
                    }
                    else
                    {
                        System.IO.File.Copy(file.FullName, fileName, true);
                    }
                }

                CreateThumbnail(file, string.Format("{0}{1}{2:000}.jpg", this.productScreenshotDirectory, DataAdministration.Properties.Settings.Default.ThumbnailDirName, index));

                index++;
            }

            LoadImageListFromDirectoryStructure(this.productScreenshotDirectory);
        }
    }
}
