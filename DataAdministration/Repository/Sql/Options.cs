using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Entities;
using System.Collections;



namespace DataAdministration.Repository.Sql
{
    class Options
    {
        internal static IEnumerable GetOptions(string tableName)
        {
            List<ProductOptionBase> list = null;

            string query = string.Format("SELECT * FROM {0}", tableName);

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
                            list = new List<ProductOptionBase>();

                            while (reader.Read())
                            {
                                if (reader[0] != null)
                                {
                                    ProductOptionBase option = new ProductOptionBase();
                                    option.Id = Convert.ToInt32(reader[0]);
                                    option.Name = Convert.ToString(reader[1]);

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
    }
}
