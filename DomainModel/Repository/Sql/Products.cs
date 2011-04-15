using System;
using System.Collections.Generic;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;



namespace DomainModel.Repository.Sql
{
    public class Products
    {
        public static GeneralDatabaseList GetByCategory(string cultureId, int? categoryId, int? parentId, int startRow, int endRow, int sortOrder)
        {
            GeneralDatabaseList ret = new GeneralDatabaseList();
            List<ProductBase> products = null;
            string query = "CatalogList";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CultureId", cultureId));
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
                    cmd.Parameters.Add(new SqlParameter("@ParentId", parentId));
                    cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                    cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));
                    cmd.Parameters.Add(new SqlParameter("@SortOrder", sortOrder));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    products = new List<ProductBase>();

                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductBase product = new ProductBase();

                            product.ProductId = Repository.Utils.Convert.ToInt64(reader["ProductId"]);
                            product.ProductName = Repository.Utils.Convert.ToString(reader["ProductName"]);
                            product.Price = Repository.Utils.Convert.ToDecimal(reader["ProductPrice"]);
                            product.ProductReleaseDate = Repository.Utils.Convert.ToDateTime(reader["ProductReleaseDate"]);
                            product.BriefDescription = Repository.Utils.Convert.ToString(reader["BriefDescription"]);
                            product.MultiLanguage = Repository.Utils.Convert.ToBool(reader["IsMultiLanguage"]);
                            product.Catalog.EditorRating = Repository.Utils.Convert.ToDecimal(reader["EditorRating"]);
                            product.Catalog.UserRating = Repository.Utils.Convert.ToDecimal(reader["UserRating"]);
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader["UrlName"]);
                            product.ProductVersion = Repository.Utils.Convert.ToString(reader["ProductVersion"]);

                            product.Catalog.IsFeatured = Repository.Utils.Convert.ToBool(reader["IsFeatured"]);
                            product.Catalog.UpdateDate = Repository.Utils.Convert.ToDateTime(reader["UpdateDate"]);
                            product.Catalog.FeatureRating = Repository.Utils.Convert.ToDecimal(reader["FeatureRating"]);
                            product.Catalog.Popularity = Repository.Utils.Convert.ToDecimal(reader["Popularity"]);
                            
                            //, MinimumVolumeSize
                            products.Add(product);
                        }
                    }

                    reader.NextResult();
                    if (reader != null && reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            ret.TotalCount = Repository.Utils.Convert.ToInt32(reader["TotalRows"]);
                        }
                    }

                    cnn.Close();
                }
            }

            ret.List = products;
            return ret;
        }

        public static GeneralDatabaseList GetFeatured(string cultureId)
        {
            GeneralDatabaseList ret = new GeneralDatabaseList();
            List<ProductBase> products = null;
            string query = "FeaturedList";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CultureId", cultureId));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    products = new List<ProductBase>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductBase product = new ProductBase();

                            product.ProductId = Repository.Utils.Convert.ToInt64(reader[1]);
                            product.ProductName = Repository.Utils.Convert.ToString(reader[2]);
                            product.Price = Repository.Utils.Convert.ToDecimal(reader[3]);
                            product.ProductReleaseDate = Repository.Utils.Convert.ToDateTime(reader[4]);
                            product.BriefDescription = Repository.Utils.Convert.ToString(reader[5]);
                            product.MultiLanguage = Repository.Utils.Convert.ToBool(reader[6]);
                            product.Catalog.EditorRating = Repository.Utils.Convert.ToDecimal(reader[7]);
                            product.Catalog.UserRating = Repository.Utils.Convert.ToDecimal(reader[8]);
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader[9]);
                            product.ProductVersion = Repository.Utils.Convert.ToString(reader[10]);
                            product.Catalog.IsFeatured = Repository.Utils.Convert.ToBool(reader["IsFeatured"]);
                            product.Catalog.UpdateDate = Repository.Utils.Convert.ToDateTime(reader["UpdateDate"]);
                            product.Catalog.FeatureRating = Repository.Utils.Convert.ToDecimal(reader["FeatureRating"]);
                            product.Catalog.Popularity = Repository.Utils.Convert.ToDecimal(reader["Popularity"]);

                            products.Add(product);

                            ret.TotalCount++;
                        }
                    }

                    cnn.Close();
                }
            }

            ret.List = products;
            return ret;
        }

        public static GeneralDatabaseList GetPopular(string cultureId)
        {
            GeneralDatabaseList ret = new GeneralDatabaseList();
            List<ProductBase> products = null;
            string query = "PopularList";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CultureId", cultureId));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    products = new List<ProductBase>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductBase product = new ProductBase();

                            product.ProductId = Repository.Utils.Convert.ToInt64(reader[1]);
                            product.ProductName = Repository.Utils.Convert.ToString(reader[2]);
                            product.Price = Repository.Utils.Convert.ToDecimal(reader[3]);
                            product.ProductReleaseDate = Repository.Utils.Convert.ToDateTime(reader[4]);
                            product.BriefDescription = Repository.Utils.Convert.ToString(reader[5]);
                            product.MultiLanguage = Repository.Utils.Convert.ToBool(reader[6]);
                            product.Catalog.EditorRating = Repository.Utils.Convert.ToDecimal(reader[7]);
                            product.Catalog.UserRating = Repository.Utils.Convert.ToDecimal(reader[8]);
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader[9]);
                            product.ProductVersion = Repository.Utils.Convert.ToString(reader[10]);
                            product.Catalog.IsFeatured = Repository.Utils.Convert.ToBool(reader["IsFeatured"]);
                            product.Catalog.UpdateDate = Repository.Utils.Convert.ToDateTime(reader["UpdateDate"]);
                            product.Catalog.FeatureRating = Repository.Utils.Convert.ToDecimal(reader["FeatureRating"]);
                            product.Catalog.Popularity = Repository.Utils.Convert.ToDecimal(reader["Popularity"]);

                            products.Add(product);

                            ret.TotalCount++;
                        }
                    }

                    cnn.Close();
                }
            }

            ret.List = products;
            return ret;
        }

        public static GeneralDatabaseList GetByTagId(int LanguageId, int tagId, int startRow, int endRow, int sortOrder)
        {
            GeneralDatabaseList ret = new GeneralDatabaseList();
            List<ProductBase> products = null;
            string query = "CatalogListByTag";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", LanguageId));
                    cmd.Parameters.Add(new SqlParameter("@TagId", tagId));
                    cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                    cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));
                    cmd.Parameters.Add(new SqlParameter("@SortOrder", sortOrder));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    products = new List<ProductBase>();

                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductBase product = new ProductBase();

                            product.ProductId = Repository.Utils.Convert.ToInt64(reader[1]);
                            product.ProductName = Repository.Utils.Convert.ToString(reader[2]);
                            product.Price = Repository.Utils.Convert.ToDecimal(reader[3]);
                            product.ProductReleaseDate = Repository.Utils.Convert.ToDateTime(reader[4]);
                            product.BriefDescription = Repository.Utils.Convert.ToString(reader[5]);
                            product.MultiLanguage = Repository.Utils.Convert.ToBool(reader[6]);
                            product.Catalog.EditorRating = Repository.Utils.Convert.ToDecimal(reader[7]);
                            product.Catalog.UserRating = Repository.Utils.Convert.ToDecimal(reader[8]);
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader[9]);
                            product.ProductVersion = Repository.Utils.Convert.ToString(reader[10]);
                            product.Catalog.IsFeatured = Repository.Utils.Convert.ToBool(reader["IsFeatured"]);
                            product.Catalog.UpdateDate = Repository.Utils.Convert.ToDateTime(reader["UpdateDate"]);
                            product.Catalog.FeatureRating = Repository.Utils.Convert.ToDecimal(reader["FeatureRating"]);
                            product.Catalog.Popularity = Repository.Utils.Convert.ToDecimal(reader["Popularity"]);

                            products.Add(product);
                        }
                    }

                    reader.NextResult();
                    if (reader != null && reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            ret.TotalCount = Repository.Utils.Convert.ToInt32(reader[0]);
                        }
                    }

                    cnn.Close();
                }
            }

            ret.List = products;
            return ret;
        }

        public static GeneralDatabaseList GetAll(string cultureId, int startRow, int endRow, int sortOrder)
        {
            GeneralDatabaseList ret = new GeneralDatabaseList();
            List<ProductBase> products = null;
            string query = "CatalogListAll";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CultureId", cultureId));
                    cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                    cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));
                    cmd.Parameters.Add(new SqlParameter("@SortOrder", sortOrder));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    products = new List<ProductBase>();

                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductBase product = new ProductBase();

                            product.ProductId = Repository.Utils.Convert.ToInt64(reader["ProductId"]);
                            product.ProductName = Repository.Utils.Convert.ToString(reader["ProductName"]);
                            product.Price = Repository.Utils.Convert.ToDecimal(reader["ProductPrice"]);
                            product.ProductReleaseDate = Repository.Utils.Convert.ToDateTime(reader["ProductReleaseDate"]);
                            product.BriefDescription = Repository.Utils.Convert.ToString(reader["BriefDescription"]);
                            product.MultiLanguage = Repository.Utils.Convert.ToBool(reader["IsMultiLanguage"]);
                            product.Catalog.EditorRating = Repository.Utils.Convert.ToDecimal(reader["EditorRating"]);
                            product.Catalog.UserRating = Repository.Utils.Convert.ToDecimal(reader["UserRating"]);
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader["UrlName"]);
                            product.ProductVersion = Repository.Utils.Convert.ToString(reader["ProductVersion"]);

                            product.Catalog.IsFeatured = Repository.Utils.Convert.ToBool(reader["IsFeatured"]);
                            product.Catalog.UpdateDate = Repository.Utils.Convert.ToDateTime(reader["UpdateDate"]);
                            product.Catalog.FeatureRating = Repository.Utils.Convert.ToDecimal(reader["FeatureRating"]);
                            product.Catalog.Popularity = Repository.Utils.Convert.ToDecimal(reader["Popularity"]);

                            //, MinimumVolumeSize
                            products.Add(product);
                        }
                    }

                    reader.NextResult();
                    if (reader != null && reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            ret.TotalCount = Repository.Utils.Convert.ToInt32(reader["TotalRows"]);
                        }
                    }

                    cnn.Close();
                }
            }

            ret.List = products;
            return ret;
        }

        public static string GetName(string cultureId, string urlName)
        {
            string ret = string.Empty;
            string query = "GetNameByUrl";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CultureId", cultureId));
                    cmd.Parameters.Add(new SqlParameter("@UrlName", urlName));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            ret = Repository.Utils.Convert.ToString(reader[0]);
                        }
                    }

                    cnn.Close();
                }
            }

            return ret;
        }
    }
}
