using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Entities;



namespace DomainModel.Repository.Sql
{
    class Languages
    {
        internal static void Load(ProductLanguageCollection languages)
        {
            string query =
                " SELECT OptionId, OptionName, LocalName, CultureId" +
                " FROM ListLanguages WHERE WebsiteSupport = 1";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
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
                            ProductLanguage language = new ProductLanguage();
                            language.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            language.Name = Repository.Utils.Convert.ToString(reader[1]);
                            // reader[2]
                            language.CultureId = Repository.Utils.Convert.ToString(reader[3]);

                            languages.Add(language);
                        }
                    }

                    cnn.Close();
                }
            }
        }
    }
}
