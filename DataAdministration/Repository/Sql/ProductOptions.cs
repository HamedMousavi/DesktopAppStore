using System;
using System.Collections.Generic;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DataAdministration.Repository.Sql
{
    class ProductOptions
    {
        private static Dictionary<string, string> tables = new Dictionary<string, string>() 
        { 
            {"ListSoftwarePlatforms", "ProductPlatforms"}, 
            {"ListSourceOptions", "ProductSourceOptions"},  
            {"ListProductTechnologies", "ProductTechnologies"},  
            {"ListTags", "ProductTags"}, 
            {"ListLanguages", "ProductLanguages"},  
            {"ListExtensionOptions", "ProductExtensionOptions"},  
            {"ListPaymentOptions", "ProductPaymentOptions"},  
            {"ListPublishOptions", "ProductPublishOptions"},  
            {"ListDemoOptions", "ProductDemoOptions"},  
            {"ListInstallationOptions", "ProductInstallationOptions"},  
            {"ListTrainingOptions", "ProductTrainingOptions"},  
            {"ListSupportOptions", "ProductSupportOptions"},  
            {"ListSupportTypes", "ProductSupportTypes"},  
            {"ListGuarantyOptions", "ProductGuarantyOptions"},  
            {"ListEnvironmentOptions", "ProductEnvironmentOptions"},  
            {"ListCustomizationOptions", "ProductCustomizationOptions"},  
            {"ListUpdateOptions", "ProductUpdateOptions"}, 
            {"ListDataBackupOptions" ,"ProductDataBackupOptions"}
        };


        public static void Insert(ProductOptionBase option, ApplicationProduct Product, string table)
        {
            string query = string.Format("INSERT INTO {0} (ProductId, OptionId) VALUES (@ProductId, @OptionId)", tables[table]);
            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", Product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@OptionId", option.Id));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();
                    /*
                    if (affected == 0)
                    {
                    }
                    */

                    cnn.Close();
                }
            }
        }


        public static void Remove(ProductOptionBase option, ApplicationProduct Product, string table)
        {
            string query = string.Format("DELETE FROM {0} WHERE ProductId = @ProductId AND OptionId = @OptionId", tables[table]);
            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", Product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@OptionId", option.Id));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();
                    /*
                    if (affected == 0)
                    {
                    }
                    */

                    cnn.Close();
                }
            }
        }


        internal static void Reload(ApplicationProduct product)
        {
            Reload(product.SupportedPlatforms, typeof(SoftwarePlatform), "ListSoftwarePlatforms", product.ProductId, product.ArticleLanguage);
            Reload(product.BackupOptions, typeof(ProductDataBackupOption), "ListDataBackupOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.CustomizationOptions, typeof(ProductCustomizationOption),"ListCustomizationOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.DemoOptions, typeof(ProductDemoOption), "ListDemoOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.EnvironmentOptions, typeof(ProductEnvironmentOption), "ListEnvironmentOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.ExtensionOptions, typeof(ProductExtensionOptions), "ListExtensionOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.GuarantyOptions, typeof(ProductGuarantyOption), "ListGuarantyOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.InstallationOptions, typeof(ProductInstallationOption), "ListInstallationOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.PaymentOptions, typeof(ProductPaymentOption), "ListPaymentOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.PublishOptions, typeof(ProductPublishOption), "ListPublishOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.SourceOptions, typeof(ProductSourceOption), "ListSourceOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.SupportOptions, typeof(ProductSupportOption), "ListSupportOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.TrainingOptions, typeof(ProductTrainingOption), "ListTrainingOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.UpdateOptions, typeof(ProductUpdateOption), "ListUpdateOptions", product.ProductId, product.ArticleLanguage);
            Reload(product.SupportTypes, typeof(ProductSupportType), "ListSupportTypes", product.ProductId, product.ArticleLanguage);
            Reload(product.SupportedLanguages, typeof(ProductLanguage), "ListLanguages", product.ProductId, -1);
            Reload(product.ProductTechnologies, typeof(ProductTechnology), "ListProductTechnologies", product.ProductId, product.ArticleLanguage);
            Reload(product.Tags, typeof(ProductTag), "ListTags", product.ProductId, product.ArticleLanguage);
        }


        private static void Reload(IList list, Type type, string listTable, Int64? productId, int languageId)
        {
            string query;
            query = string.Format(
                "SELECT {0}.OptionId, {0}.OptionName FROM {0}, {1} WHERE " +
                "{0}.OptionId = {1}.OptionId AND ProductId = {2}",
                listTable, tables[listTable], productId);

            if (languageId>0)
            {
                query += string.Format(" AND {0}.LanguageId={1}", listTable, languageId);
            }

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            object inst = Activator.CreateInstance(type);
                            
                            ((ProductOptionBase)inst).Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            ((ProductOptionBase)inst).Name = Repository.Utils.Convert.ToString(reader[1]);

                            list.Add(inst);
                        }
                    }
                    

                    cnn.Close();
                }
            }
        }
    }
}
