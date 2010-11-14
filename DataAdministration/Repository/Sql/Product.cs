using System;
using System.Collections.Generic;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DataAdministration.Repository.Sql
{
    public class Product
    {
        public static Int64? Insert(ApplicationProduct product)
        {
            string query = string.Format(
                "DECLARE @productId BIGINT " +
                "SET @productId = -1 " +
                "INSERT INTO SoftwareProduct " +
                "(ProductWebsite, ProductVersion, ProductReleaseDate, ProductPrice, MinimumVolumeSize, IsMultiUser, IsMultiLanguage, IsLanguageExtendable) " +
                "VALUES " +
                "(@ProductWebsite, @ProductVersion, @ProductReleaseDate, @ProductPrice, @MinimumVolumeSize, @IsMultiUser, @IsMultiLanguage, @IsLanguageExtendable) " +
                "SELECT @productId = SCOPE_IDENTITY(); " +
                "SELECT @productId; "
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductWebsite", product.ProductWebsite));
                    cmd.Parameters.Add(new SqlParameter("@ProductVersion", product.ProductVersion));
                    cmd.Parameters.Add(new SqlParameter("@ProductReleaseDate", product.ProductReleaseDate));
                    cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.Price));
                    cmd.Parameters.Add(new SqlParameter("@MinimumVolumeSize", product.MinimumVolumeSize));
                    cmd.Parameters.Add(new SqlParameter("@IsMultiUser", product.MultiUser));
                    cmd.Parameters.Add(new SqlParameter("@IsMultiLanguage", product.MultiLanguage));
                    cmd.Parameters.Add(new SqlParameter("@IsLanguageExtendable", product.LanguageExtendable));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                    cnn.Open();

                    object res = cmd.ExecuteScalar();

                    if (res != null && res != DBNull.Value)
                    {
                        product.ProductId = Convert.ToInt64(res);
                    }


                    cnn.Close();
                }

                return product.ProductId;
            }
        }



        internal static bool Update(ApplicationProduct product)
        {
            bool res = false;

            string query = string.Format(
                "UPDATE SoftwareProduct SET " +
                "ProductWebsite = @ProductWebsite, " +
                "ProductVersion = @ProductVersion, ProductReleaseDate = @ProductReleaseDate, " +
                "ProductPrice = @ProductPrice, MinimumVolumeSize = @MinimumVolumeSize, " + 
                "IsMultiUser = @IsMultiUser, IsMultiLanguage = @IsMultiLanguage, IsLanguageExtendable = @IsLanguageExtendable " +
                "WHERE ProductId = @ProductId"
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@ProductWebsite", product.ProductWebsite));
                    cmd.Parameters.Add(new SqlParameter("@ProductVersion", product.ProductVersion));
                    cmd.Parameters.Add(new SqlParameter("@ProductReleaseDate", product.ProductReleaseDate));
                    cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.Price));
                    cmd.Parameters.Add(new SqlParameter("@MinimumVolumeSize", product.MinimumVolumeSize));
                    cmd.Parameters.Add(new SqlParameter("@IsMultiUser", product.MultiUser));
                    cmd.Parameters.Add(new SqlParameter("@IsMultiLanguage", product.MultiLanguage));
                    cmd.Parameters.Add(new SqlParameter("@IsLanguageExtendable", product.LanguageExtendable));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();

                    res = (affected > 0);

                    cnn.Close();
                }
            }

            return res;
        }



        public static bool UpdateDetails(ApplicationProduct product)
        {
            bool res = false;

            string query = string.Format(
                "UPDATE SoftwareProductDetails SET " +
                "ProductName = @ProductName, BriefDescription = @BriefDescription, " +
                "PriceDetails = @PriceDetails, GuarantyDetails = @GuarantyDetails " +
                "WHERE ProductId = @ProductId AND LanguageId=@LanguageId"
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", product.ArticleLanguage));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                    cmd.Parameters.Add(new SqlParameter("@BriefDescription", product.BriefDescription));
                    cmd.Parameters.Add(new SqlParameter("@PriceDetails", product.PriceDetails));
                    cmd.Parameters.Add(new SqlParameter("@GuarantyDetails", product.GuarantyDetails));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                    
                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();

                    res = (affected > 0);

                    cnn.Close();
                }
            }

            return res;
        }



        internal static ApplicationProduct GetById(Int64 ProductId, int LanguageId)
        {
            ApplicationProduct product = null;
            string query = string.Format(
                "SELECT * FROM SoftwareProduct WHERE ProductId = {0};" +
                "SELECT * FROM ProductCatalog WHERE ProductId = {0};" +
                "SELECT * FROM SoftwareProductDetails WHERE ProductId={0} AND LanguageId={1};" +
                "SELECT * FROM ProductArticles WHERE ProductId={0} AND LanguageId={1};" +
                "SELECT * FROM Categories WHERE CategoryId IN (SELECT CategoryId FROM ProductCategories WHERE ProductId={0} AND LanguageId={1});"
                ,  ProductId, LanguageId);

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                    {
                        if (reader.Read())
                        {
                            product = new ApplicationProduct();
                            
                            product.ProductId           = ProductId;
                            product.Price = Repository.Utils.Convert.ToDecimal(reader["ProductPrice"]);
                            product.ProductReleaseDate  = Repository.Utils.Convert.ToDateTime(reader["ProductReleaseDate"]);
                            product.ProductVersion      = Repository.Utils.Convert.ToString(reader["ProductVersion"]);
                            product.MinimumVolumeSize   = Repository.Utils.Convert.ToFloat(reader["MinimumVolumeSize"]);
                            product.ProductWebsite      = Repository.Utils.Convert.ToString(reader["ProductWebsite"]);
                            product.LanguageExtendable  = Repository.Utils.Convert.ToBool(reader["IsLanguageExtendable"]);
                            product.MultiLanguage       = Repository.Utils.Convert.ToBool(reader["IsMultiLanguage"]);
                            product.MultiUser           = Repository.Utils.Convert.ToBool(reader["IsMultiUser"]);
                        }

                        // Read next table: ProductCatalog
                        reader.NextResult();
                        if (reader.Read())
                        {
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader["UrlName"]);
                            product.Catalog.SearchPriority = Repository.Utils.Convert.ToInt32(reader["SearchPriority"]);
                            product.Catalog.IsEnabled = Repository.Utils.Convert.ToBool(reader["IsEnabled"]);
                            product.Catalog.IsFeatured = Repository.Utils.Convert.ToBool(reader["IsFeatured"]);
                        }

                        // Read next table: SoftwareProductDetails
                        reader.NextResult();
                        if (reader.Read())
                        {
                            product.ArticleLanguage     = LanguageId;
                            product.ProductName         = Repository.Utils.Convert.ToString(reader["ProductName"]);
                            product.BriefDescription    = Repository.Utils.Convert.ToString(reader["BriefDescription"]);
                            product.PriceDetails        = Repository.Utils.Convert.ToString(reader["PriceDetails"]);
                            product.GuarantyDetails     = Repository.Utils.Convert.ToString(reader["GuarantyDetails"]);
                        }

                        // Read next table: ProductArticles
                        reader.NextResult();
                        if (reader.Read())
                        {
                            product.Article.Content = Repository.Utils.Convert.ToString(reader["ArticleContent"]);
                        }

                        // Read next table: ProductCategories
                        reader.NextResult();
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Category category = new Category();
                                category.CategoryId = Repository.Utils.Convert.ToInt32(reader["CategoryId"]);
                                category.CategoryName = Repository.Utils.Convert.ToString(reader["CategoryName"]);
                                category.UrlName = Repository.Utils.Convert.ToString(reader["UrlName"]);

                                product.Categories.Add(category);
                                
                            }
                        }

                        reader.Close();
                    }


                    cnn.Close();
                }

                return product;
            }
        }



        internal static bool Exists(string urlName)
        {
            bool exists = false;
            string query = string.Format("SELECT ProductId FROM ProductCatalog WHERE UrlName='{0}'", urlName);

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            exists = true;
                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }

            return exists;
        }



        internal static Int64? IdFromUrlName(string urlName)
        {
            Int64? id = null;
            string query = string.Format("SELECT ProductId FROM ProductCatalog WHERE UrlName='{0}'", urlName);

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            reader.Read();
                            id = Repository.Utils.Convert.ToInt64(reader[0]);
                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }

            return id;
        }



        internal static bool LanguageExists(Int64 productId, int languageId)
        {
            bool exists = false;
            string query = string.Format("SELECT ProductId FROM SoftwareProductDetails WHERE ProductId={0} AND LanguageId={1}", productId, languageId);

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            exists = true;
                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }

            return exists;
        }



        internal static bool InsertCatalaog(ApplicationProduct product)
        {
            bool res = false;

            string query = string.Format(
                "INSERT INTO ProductCatalog " +
                "(ProductId, UrlName, SearchPriority, IsEnabled, IsFeatured) VALUES (@ProductId, @UrlName, @SearchPriority, 1, 0) "
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@UrlName", product.Catalog.UrlName));
                    cmd.Parameters.Add(new SqlParameter("@SearchPriority", product.Catalog.SearchPriority));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();

                    res = (affected > 0);

                    cnn.Close();
                }
            }

            return res;
        }



        internal static bool InsertDetail(ApplicationProduct product, int languageId, string ProductName, string ProductDescription, string PriceDetails, string GuarantyDetails)
        {
            bool res = false;

            string query = string.Format(
                "INSERT INTO SoftwareProductDetails " +
                "(ProductId, LanguageId, ProductName, BriefDescription, PriceDetails, GuarantyDetails) " +
                "VALUES " +
                "(@ProductId, @LanguageId, @ProductName, @BriefDescription, @PriceDetails, @GuarantyDetails) "
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", languageId));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", ProductName));
                    cmd.Parameters.Add(new SqlParameter("@BriefDescription", ProductDescription));
                    cmd.Parameters.Add(new SqlParameter("@PriceDetails", PriceDetails));
                    cmd.Parameters.Add(new SqlParameter("@GuarantyDetails", GuarantyDetails));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                    {
                        res = true;
                    }


                    cnn.Close();
                }
            }

            return res;
        }



        internal static bool UpdateArticle(ApplicationProduct product)
        {
            bool res = false;

            string query = string.Format(
                "IF EXISTS (SELECT ProductId FROM ProductArticles WHERE ProductId=@ProductId AND LanguageId=@LanguageId) BEGIN " +
                "UPDATE ProductArticles SET ArticleContent=@ArticleContent WHERE ProductId=@ProductId AND LanguageId=@LanguageId " +
                "END ELSE BEGIN " +
                "INSERT INTO ProductArticles " +
                "(ProductId, LanguageId, ArticleContent) " +
                "VALUES " +
                "(@ProductId, @LanguageId, @ArticleContent) " +
                "END"
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", product.ArticleLanguage));
                    cmd.Parameters.Add(new SqlParameter("@ArticleContent", product.Article.Content));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                    {
                        res = true;
                    }


                    cnn.Close();
                }
            }

            return res;
        }



        internal static bool UpdateCatalog(ApplicationProduct product)
        {
            bool res = false;

            string query = string.Format(
                "UPDATE ProductCatalog " +
                "SET UrlName=@UrlName, SearchPriority=@SearchPriority, IsEnabled=@IsEnabled, IsFeatured=@IsFeatured WHERE ProductId=@ProductId "
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@UrlName", product.Catalog.UrlName));
                    cmd.Parameters.Add(new SqlParameter("@SearchPriority", product.Catalog.SearchPriority));
                    cmd.Parameters.Add(new SqlParameter("@IsEnabled", product.Catalog.IsEnabled));
                    cmd.Parameters.Add(new SqlParameter("@IsFeatured", product.Catalog.IsFeatured));

                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();

                    res = (affected > 0);

                    cnn.Close();
                }
            }

            return res;
        }
    }
}
