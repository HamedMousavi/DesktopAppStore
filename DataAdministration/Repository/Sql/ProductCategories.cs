using System;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Collections;


namespace DataAdministration.Repository.Sql
{
    public class ProductCategories
    {

        internal static IEnumerable GetAll(int languageId)
        {
            CategoryCollection list = null;

            string query = string.Format("SELECT * FROM Categories WHERE LanguageId = {0}", 
                languageId);

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
                            list = new CategoryCollection();

                            while (reader.Read())
                            {
                                if (reader[0] != null)
                                {
                                    Category option = new Category();
                                    option.CategoryId = Convert.ToInt32(reader[0]);
                                    option.CategoryName = Convert.ToString(reader[3]);
                                    option.UrlName = Convert.ToString(reader[4]);

                                    list.Add(option);
                                }
                            }

                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }

            return list;
        }


        public static void Remove(Category option, ApplicationProduct Product)
        {
            string query = string.Format(
                "DELETE FROM dbo.ProductCategories WHERE " +
                "ProductId = @ProductId AND CategoryId = @CategoryId AND LanguageId = @LanguageId");
            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", Product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", option.CategoryId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", Product.ArticleLanguage));
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


        public static void Insert(Category option, ApplicationProduct Product)
        {
            string query = string.Format(
                "INSERT INTO ProductCategories (ProductId, CategoryId, LanguageId) " +
                "VALUES (@ProductId, @CategoryId, @LanguageId)");

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", Product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", option.CategoryId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", Product.ArticleLanguage));
                    
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
    }
}
