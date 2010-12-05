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

        protected static string DemoDirName             = "/DemoVersions/";
        protected static string CommonDemoDirName       = "common/";

        protected static decimal BDB                      = 1024M;
        protected static decimal KBDB                     = 1048576M;
        protected static decimal MBDB                     = 1073741824M;
        protected static decimal GBDB                     = 1099511627776M;

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



        public static void LoadDemoVersions(ApplicationProduct product, string cultureId)
        {
            try
            {
                // Load product screenshots
                if (!string.IsNullOrWhiteSpace(product.Catalog.UrlName))
                {
                    // Product resource directory is base dir + UrlName
                    string demoDir =
                        Configurations.ProductResDirBase +
                        product.Catalog.UrlName +
                        DemoDirName;

                    // Find Common demo file
                    string dirPath = demoDir + CommonDemoDirName;
                    System.IO.FileInfo fi = GetLatestDemoFile(dirPath);
                    string fileUrl = string.Format("{0}{1}", dirPath, fi.Name);

                    if (!string.IsNullOrWhiteSpace(fileUrl))
                    {
                        product.Demo.CommonVersion = new ProductDemo();
                        product.Demo.CommonVersion.Url = fileUrl;
                        product.Demo.CommonVersion.Size = FormatFileSize(fi.Length);
                    }

                    // Find latest in culture file
                    dirPath = demoDir + cultureId + "/";
                    fi = GetLatestDemoFile(dirPath);
                    fileUrl = string.Format("{0}{1}", dirPath, fi.Name);
                    if (!string.IsNullOrWhiteSpace(fileUrl))
                    {
                        ProductDemo demo = product.Demo[cultureId];
                        if (demo == null)
                        {
                            demo = new ProductDemo();
                            product.Demo.Add(demo);
                        }
                        
                        demo.Url = fileUrl;
                        demo.Size = FormatFileSize(fi.Length);
                        demo.Language = Repository.Memory.Languages.Instance.Items[cultureId];
                    }
                }
            }
            catch (Exception)
            {
            }
        }



        private static System.IO.FileInfo GetLatestDemoFile(string dirPath)
        {
            System.IO.DirectoryInfo di = 
                new System.IO.DirectoryInfo(
                    System.Web.HttpContext.Current.Server.MapPath(dirPath));

            System.IO.FileInfo[] files = di.GetFiles(
                "*.*", System.IO.SearchOption.TopDirectoryOnly);

            if (files.Length > 0)
            {
                Array.Sort(files, new ByDateFileComparer());
                return files[0];
            }

            return null;
        }



        private static string FormatFileSize(decimal len)
        {
            if (len < BDB)
            {
                return string.Format(" {0:0.0} Bytes", len);
            }
            else if (len < KBDB)
            {
                return string.Format(" {0:0.0} KB", len / BDB);
            }
            else if (len < MBDB)
            {
                return string.Format(" {0:0.0} MB", len / KBDB);
            }
            else if (len < GBDB)
            {
                return string.Format(" {0:0.0} GB", len / MBDB);
            }
            else
            {
                return string.Format(" {0:0.0} GB", len / GBDB);
            }
        }
    }
}
