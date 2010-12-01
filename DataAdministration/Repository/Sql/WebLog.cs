using System;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;




namespace DataAdministration.Repository.Sql
{
    public static class WebLog
    {
        internal static bool Load(WeblogEntry weblogEntry)
        {
            bool res = false;

            string query = string.Format(
                "SELECT * FROM Weblog WHERE EntryId = {0} AND LanguageId = {1}",
                weblogEntry.EntryId, Sql.Languages.GetId(weblogEntry.CultureId).Value);

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
                                weblogEntry.Brief = Utils.Convert.ToString(reader["EntryBrief"]);
                                weblogEntry.Content = Utils.Convert.ToString(reader["EntryContent"]);
                                weblogEntry.CultureId = Sql.Languages.GetCulture(Utils.Convert.ToInt32(reader["LanguageId"]));
                                weblogEntry.EntryId = Utils.Convert.ToInt64(reader["EntryId"]);
                                weblogEntry.ExpirationDate = Utils.Convert.ToDateTime(reader["EntryOnlineTo"]);
                                weblogEntry.IsAnnouncement = Utils.Convert.ToBool(reader["EntryIsAnnouncement"]);
                                weblogEntry.Score = Utils.Convert.ToDecimal(reader["EntryScorePoints"]);
                                weblogEntry.Title = Utils.Convert.ToString(reader["EntryTitle"]);
                                weblogEntry.UploadDate = Utils.Convert.ToDateTime(reader["EntryOnlineFrom"]);
                                weblogEntry.Url = Utils.Convert.ToString(reader["EntryUrl"]);
                            }

                            reader.Close();
                        }
                    }

                    cnn.Close();
                    res = true;
                }
            }

            return res;
        }

        
        internal static bool Insert(WeblogEntry weblogEntry)
        {
            bool res = false;

            string query = 
                "INSERT INTO Weblog " + 
                "(EntryId, LanguageId, EntryOnlineFrom, EntryOnlineTo, EntryUrl, EntryTitle, EntryBrief, EntryContent, EntryScorePoints, EntryIsAnnouncement) " + 
                "VALUES " +
                "(@EntryId, @LanguageId, @EntryOnlineFrom, @EntryOnlineTo, @EntryUrl, @EntryTitle, @EntryBrief, @EntryContent, @EntryScorePoints, @EntryIsAnnouncement)";

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@EntryId", weblogEntry.EntryId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", Sql.Languages.GetId(weblogEntry.CultureId)));
                    cmd.Parameters.Add(new SqlParameter("@EntryOnlineFrom", weblogEntry.UploadDate));
                    cmd.Parameters.Add(new SqlParameter("@EntryOnlineTo", weblogEntry.ExpirationDate));
                    cmd.Parameters.Add(new SqlParameter("@EntryUrl", weblogEntry.Url));
                    cmd.Parameters.Add(new SqlParameter("@EntryTitle", weblogEntry.Title));
                    cmd.Parameters.Add(new SqlParameter("@EntryBrief", weblogEntry.Brief));
                    cmd.Parameters.Add(new SqlParameter("@EntryContent", weblogEntry.Content));
                    cmd.Parameters.Add(new SqlParameter("@EntryScorePoints", weblogEntry.Score));
                    cmd.Parameters.Add(new SqlParameter("@EntryIsAnnouncement", weblogEntry.IsAnnouncement));

                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();

                    if (affected>0)
                    {
                        res = true;
                    }

                    cnn.Close();
                }
            }

            return res;
        }

        
        internal static bool Update(WeblogEntry weblogEntry)
        {
            bool res = false;

            string query = 
                "UPDATE Weblog " +
                "SET EntryOnlineFrom=@EntryOnlineFrom, EntryOnlineTo=@EntryOnlineTo, " +
                "EntryUrl=@EntryUrl, EntryTitle=@EntryTitle, EntryBrief=@EntryBrief, EntryContent=@EntryContent, " + 
                "EntryScorePoints=@EntryScorePoints, EntryIsAnnouncement=@EntryIsAnnouncement " +
                "WHERE EntryId=@EntryId AND LanguageId=@LanguageId";

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@EntryId", weblogEntry.EntryId));
                    cmd.Parameters.Add(new SqlParameter("@LanguageId", Sql.Languages.GetId(weblogEntry.CultureId)));
                    cmd.Parameters.Add(new SqlParameter("@EntryOnlineFrom", weblogEntry.UploadDate));
                    cmd.Parameters.Add(new SqlParameter("@EntryOnlineTo", weblogEntry.ExpirationDate));
                    cmd.Parameters.Add(new SqlParameter("@EntryUrl", weblogEntry.Url));
                    cmd.Parameters.Add(new SqlParameter("@EntryTitle", weblogEntry.Title));
                    cmd.Parameters.Add(new SqlParameter("@EntryBrief", weblogEntry.Brief));
                    cmd.Parameters.Add(new SqlParameter("@EntryContent", weblogEntry.Content));
                    cmd.Parameters.Add(new SqlParameter("@EntryScorePoints", weblogEntry.Score));
                    cmd.Parameters.Add(new SqlParameter("@EntryIsAnnouncement", weblogEntry.IsAnnouncement));

                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                    {
                        res = true;
                    }

                    cnn.Close();
                }
            }

            return res;
        }


        internal static bool Exists(WeblogEntry weblogEntry)
        {
            bool res = false;

            string query = string.Format(
                "IF EXISTS (SELECT EntryId FROM Weblog WHERE EntryId = {0} AND LanguageId = {1}) SELECT 1",
                weblogEntry.EntryId, Sql.Languages.GetId(weblogEntry.CultureId).Value);

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
                                if (Utils.Convert.ToInt32(reader[0]) == 1)
                                {
                                    res = true;
                                }
                            }

                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }

            return res;
        }


        internal static Int64? LoadLastRow()
        {
            Int64? res = null;

            string query = string.Format("SELECT TOP(1) EntryId FROM Weblog ORDER BY EntryId DESC");

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
                                res = Utils.Convert.ToInt64(reader[0]);
                            }

                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }

            return res;
        }
    }
}
