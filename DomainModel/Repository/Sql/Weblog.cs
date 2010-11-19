using System;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;



namespace DomainModel.Repository.Sql
{
    public static class Weblog
    {

        internal static bool Load(WeblogEntryCollection messages, DateTime messageTime, string cultureId)
        {
            bool res = false;
            string userName = string.Empty;

            messages.LastLoad = DateTime.Now;


            string query = "WeblogLoadByTime";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MessageTime", messageTime));
                    cmd.Parameters.Add(new SqlParameter("@CultureId", cultureId));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        // Read first table: SoftwareProduct
                        while (reader.Read())
                        {
                            WeblogEntry msg = new WeblogEntry();
                            msg.CultureId = cultureId;
                            msg.Url = Utils.Convert.ToString(reader["EntryUrl"]);
                            msg.UploadDate = Utils.Convert.ToDateTime(reader["EntryOnlineFrom"]);
                            msg.ExpirationDate = Utils.Convert.ToDateTime(reader["EntryOnlineTo"]);
                            msg.Title = Utils.Convert.ToString(reader["EntryTitle"]);
                            msg.Brief = Utils.Convert.ToString(reader["EntryBrief"]);
                            msg.Content = Utils.Convert.ToString(reader["EntryContent"]);
                            msg.Score = Utils.Convert.ToDecimal(reader["EntryScorePoints"]);

                            messages.Add(msg);

                            // Set minimum exp date as exp date of all messages in this cullture
                            // this causes the list to be updated at most after first exp datetime.
                            if (msg.ExpirationDate < messages.ExpirationDate)
                            {
                                messages.ExpirationDate = msg.ExpirationDate;
                            }

                            res = true;
                        }
                    }
                }
            }

            return res;
        }


        internal static bool GetMessages(string cultureId, string url, WeblogEntryCollection messages)
        {
            messages.Clear();
            bool res = false;

            string userName = string.Empty;
            string query = "WeblogGetByUrl";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MessageUrl", url));
                    cmd.Parameters.Add(new SqlParameter("@CultureId", cultureId));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        // Read first table: SoftwareProduct
                        while (reader.Read())
                        {
                            WeblogEntry message = new WeblogEntry();

                            message.CultureId = cultureId;
                            message.Url = Utils.Convert.ToString(reader["EntryUrl"]);
                            message.UploadDate = Utils.Convert.ToDateTime(reader["EntryOnlineFrom"]);
                            message.ExpirationDate = Utils.Convert.ToDateTime(reader["EntryOnlineTo"]);
                            message.Title = Utils.Convert.ToString(reader["EntryTitle"]);
                            message.Brief = Utils.Convert.ToString(reader["EntryBrief"]);
                            message.Content = Utils.Convert.ToString(reader["EntryContent"]);
                            message.Score = Utils.Convert.ToDecimal(reader["EntryScorePoints"]);

                            messages.Add(message);
                        }
                        res = true;
                    }
                }
            }

            return res;
        }
    }
}
