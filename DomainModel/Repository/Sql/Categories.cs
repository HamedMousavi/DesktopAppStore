using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Entities;



namespace DomainModel.Repository.Sql
{
    public class Categories
    {
        public static void Load(string culture, Entities.CategoryParent categories)
        {
            ProductLanguage language = Repository.Memory.Languages.Instance.Items[culture];

            string query =
                " SELECT CategoryId, CategoryName" +
                " FROM Categories" +
                " WHERE (ParentId<0 AND LanguageId=@LanguageId)" +
                " ORDER BY CategoryName";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", language.Id));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Entities.Category cat = new Entities.Category();
                            cat.CategoryId = Repository.Utils.Convert.ToInt32(reader[0]);
                            cat.CategoryName= Repository.Utils.Convert.ToString(reader[1]);

                            LoadSubCategories(cat.SubCategories, cat.CategoryId, language.Id);

                            categories.Add(cat);
                        }
                    }

                    cnn.Close();
                }
            }
        }



        private static void LoadSubCategories(Entities.CategoryCollection categories, int categoryId, int languageId)
        {
            string query =
                " SELECT CategoryId, CategoryName" +
                " FROM Categories" +
                " WHERE (ParentId=@ParentId AND LanguageId=@LanguageId)" +
                " ORDER BY CategoryName";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ParentId", categoryId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", languageId));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Entities.Category cat = new Entities.Category();
                            cat.CategoryId = Repository.Utils.Convert.ToInt32(reader[0]);
                            cat.CategoryName = Repository.Utils.Convert.ToString(reader[1]);

                            LoadSubCategories(cat.SubCategories, cat.CategoryId, languageId);

                            categories.Add(cat);
                        }
                    }

                    cnn.Close();
                }
            }
        }
    }
}
