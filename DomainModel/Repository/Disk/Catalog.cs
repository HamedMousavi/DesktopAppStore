using System;
using DomainModel.Entities;
using System.Xml;
using System.Collections.Generic;



namespace DomainModel.Repository.Disk
{
    public class Catalog
    {
        protected static string ScreenshotDirName       = "/Screenshots/";
        protected static string ThumbnailDirName        = "Thumbnails/";
        protected static string MetaDataNodeImages      = "screenshots/image";
        protected static string MetaDataNodeThumbnail   = "thumbnail";
        protected static string MetaDataNodeFileName    = "filename";
        protected static string MetaDataNodeWidth       = "width";
        protected static string MetaDataNodeHeight      = "height";
        protected static string MetaDataNodeDescription = "description";
        protected static string MetaDataNodeTitle       = "title";


        public static void LoadScreenshots(ApplicationProduct product, string cultureId, bool loadAll)
        {
            GetScreenShots(product.Catalog.UrlName, cultureId, product.Screenshots, loadAll);
        }


        public static void GetScreenShots(string productUrlName, string cultureId, List<ProductImage> screenshots, bool loadAll)
        {
            try
            {
                // Load product screenshots
                if (!string.IsNullOrWhiteSpace(productUrlName))
                {

                    // Product resource directory is base dir + UrlName
                    string imageDir =
                        Configurations.ProductResDirBase +
                        productUrlName +
                        ScreenshotDirName;

                    string MetaDataFileName = string.Format("{0}.MetaData.xml", cultureId);

                    string metadataFile =
                        System.Web.HttpContext.Current.Server.MapPath("~" + imageDir + MetaDataFileName);

                    XmlDocument metadata = new XmlDocument();
                    metadata.Load(metadataFile);

                    XmlNodeList images = metadata.SelectNodes(MetaDataNodeImages);
                    foreach (XmlNode image in images)
                    {
                        ProductImage productImage = new ProductImage();
                        screenshots.Add(productImage);

                        productImage.Url = imageDir + image.SelectSingleNode(MetaDataNodeFileName).InnerText;
                        productImage.Description = image.SelectSingleNode(MetaDataNodeDescription).InnerText;
                        productImage.ImageSize = new System.Drawing.Size(
                            Convert.ToInt32(image.SelectSingleNode(MetaDataNodeWidth).InnerText),
                            Convert.ToInt32(image.SelectSingleNode(MetaDataNodeHeight).InnerText));

                        XmlNodeList thumb = image.SelectNodes(MetaDataNodeThumbnail);
                        if (thumb.Count > 0)
                        {
                            productImage.Thumbnail.Url = imageDir + ThumbnailDirName + thumb[0].SelectSingleNode(MetaDataNodeFileName).InnerText;
                            productImage.Thumbnail.Title = thumb[0].SelectSingleNode(MetaDataNodeTitle).InnerText;
                        }

                        if (!loadAll) break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }


    }
}
