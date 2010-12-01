using System;
using System.Data.SqlClient;
using System.Data;



namespace DataAdministration.Repository.Sql
{
    class Languages
    {
        internal static int? GetId(string cultureId)
        {
            int? id = null;

            string query = string.Format(
                "SELECT OptionId FROM ListLanguages WHERE CultureId = '{0}'",
                cultureId);

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
                            if (reader.Read())
                            {
                                id = Utils.Convert.ToInt32(reader["OptionId"]);
                            }

                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }

            return id;
        }

        internal static string GetCulture(int id)
        {
            string culture = string.Empty;

            string query = string.Format(
                "SELECT CultureId FROM ListLanguages WHERE OptionId = {0}",
                id);

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
                            if (reader.Read())
                            {
                                culture = Utils.Convert.ToString(reader["CultureId"]);
                            }

                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }

            return culture;
        }
    }
}
