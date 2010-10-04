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
                "(ProductName, ProductWebsite, BriefDescription, ProductVersion, ProductReleaseDate, ProductPrice, PriceDetails, MinimumVolumeSize, IsMultiUser, IsMultiLanguage, IsLanguageExtendable) " +
                "VALUES " +
                "(@ProductName, @ProductWebsite, @BriefDescription, @ProductVersion, @ProductReleaseDate, @ProductPrice, @PriceDetails, @MinimumVolumeSize, @IsMultiUser, @IsMultiLanguage, @IsLanguageExtendable) " +
                "SELECT @productId = SCOPE_IDENTITY(); " +
                "SELECT @productId; "
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductName", Repository.Utils.Convert.ToString(product.ProductName) ));
                    cmd.Parameters.Add(new SqlParameter("@ProductWebsite", Repository.Utils.Convert.ToString(product.ProductWebsite)));
                    cmd.Parameters.Add(new SqlParameter("@BriefDescription", Repository.Utils.Convert.ToString(product.BriefDescription)));
                    //cmd.Parameters.Add(new SqlParameter("@ResourceDir", Repository.Utils.Convert.ToString(product.ResourceDir)));
                    cmd.Parameters.Add(new SqlParameter("@ProductVersion", product.ProductVersion));
                    cmd.Parameters.Add(new SqlParameter("@ProductReleaseDate", product.ProductReleaseDate));
                    cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.Price));
                    cmd.Parameters.Add(new SqlParameter("@PriceDetails", Repository.Utils.Convert.ToString(product.PriceDetails)));
                    cmd.Parameters.Add(new SqlParameter("@MinimumVolumeSize", product.MinimumVolumeSize));
                    cmd.Parameters.Add(new SqlParameter("@IsMultiUser", Repository.Utils.Convert.ToBool(product.MultiUser)));
                    cmd.Parameters.Add(new SqlParameter("@IsMultiLanguage", Repository.Utils.Convert.ToBool(product.MultiLanguage)));
                    cmd.Parameters.Add(new SqlParameter("@IsLanguageExtendable", Repository.Utils.Convert.ToBool(product.LanguageExtendable)));
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
                "ProductName = @ProductName, ProductWebsite = @ProductWebsite, BriefDescription = @BriefDescription, " +
                "ProductVersion = @ProductVersion, ProductReleaseDate = @ProductReleaseDate, " +
                "ProductPrice = @ProductPrice, PriceDetails = @PriceDetails, MinimumVolumeSize = @MinimumVolumeSize, " + 
                "IsMultiUser = @IsMultiUser, IsMultiLanguage = @IsMultiLanguage, IsLanguageExtendable = @IsLanguageExtendable " +
                "WHERE ProductId = @ProductId"
                );

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                    cmd.Parameters.Add(new SqlParameter("@ProductWebsite", product.ProductWebsite));
                    cmd.Parameters.Add(new SqlParameter("@BriefDescription", product.BriefDescription));
                    //cmd.Parameters.Add(new SqlParameter("@ResourceDir", product.ResourceDir));
                    cmd.Parameters.Add(new SqlParameter("@ProductVersion", product.ProductVersion));
                    cmd.Parameters.Add(new SqlParameter("@ProductReleaseDate", product.ProductReleaseDate));
                    cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.Price));
                    cmd.Parameters.Add(new SqlParameter("@PriceDetails", product.PriceDetails));
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



        internal static ApplicationProduct GetById(Int64 ProductId)
        {
            ApplicationProduct product = null;
            string query = string.Format(
                "SELECT * FROM SoftwareProduct " +
                "WHERE ProductId = {0}",  ProductId);

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null && reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            product = new ApplicationProduct();
                            
                            product.ProductId           = ProductId;
                            product.ProductName         = Repository.Utils.Convert.ToString(reader["ProductName"]);
                            product.BriefDescription    = Repository.Utils.Convert.ToString(reader["BriefDescription"]);
                            product.Price               = Repository.Utils.Convert.ToDecimal(reader["ProductPrice"]);
                            product.PriceDetails        = Repository.Utils.Convert.ToString(reader["PriceDetails"]);
                            product.ProductReleaseDate  = Repository.Utils.Convert.ToDateTime(reader["ProductReleaseDate"]);
                            product.Catalog.ResourceDir = Repository.Utils.Convert.ToString(reader["ResourceDir"]);
                            product.ProductVersion      = Repository.Utils.Convert.ToString(reader["ProductVersion"]);
                            product.MinimumVolumeSize   = Repository.Utils.Convert.ToFloat(reader["MinimumVolumeSize"]);
                            product.ProductWebsite      = Repository.Utils.Convert.ToString(reader["ProductWebsite"]);
                            product.LanguageExtendable  = Repository.Utils.Convert.ToBool(reader["IsLanguageExtendable"]);
                            product.MultiLanguage       = Repository.Utils.Convert.ToBool(reader["IsMultiLanguage"]);
                            product.MultiUser           = Repository.Utils.Convert.ToBool(reader["IsMultiUser"]);

                        }
                    }


                    cnn.Close();
                }

                return product;
            }
        }
    }
}
