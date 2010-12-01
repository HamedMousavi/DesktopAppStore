using System;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Entities;




namespace DomainModel.Repository.Sql
{
    public static class Tags
    {
        public static Entities.ProductTag GetById(int tagId, int languageId)
        {
            ProductTag tag = null;
            string query = "TagGetById";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@tagId", tagId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", languageId));
                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            tag = new ProductTag();
                            tag.Id = Repository.Utils.Convert.ToInt32(reader["OptionId"]);
                            tag.Name = Repository.Utils.Convert.ToString(reader["OptionName"]);
                        }
                    }

                    cnn.Close();
                }
            }

            return tag;
        }
    }
}
