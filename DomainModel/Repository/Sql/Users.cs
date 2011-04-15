using System;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Abstract;



namespace DomainModel.Repository.Sql
{
    public class Users
    {
        // UNDONE: MOST FUNCTIONS HERE NEED TO BE REWRITTEN

        public static bool Exists(string email)
        {
            bool exists = false;
            string query = "UserEmailExists";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@EmailAddress", email));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                    
                    cnn.Open();

                    object queryRes = cmd.ExecuteScalar();
                    if (queryRes != null)
                    {
                        if (Utils.Convert.ToInt32(queryRes) == 1) exists = true;
                    }

                    cnn.Close();
                }
            }

            return exists;
        }

        // Also loads a very minimum profile info that is required by
        // application to function properly
        internal static Membership.User GetUser(string email, string password)
        {
            Membership.User user = null;
            string query = "UserLogIn";

            try
            {
                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@EmailAddress", email));
                        cmd.Parameters.Add(new SqlParameter("@Password", password));
                        foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                        cnn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null && reader.HasRows)
                        {
                            // Read first table: SoftwareProduct
                            if (reader.Read())
                            {
                                user = new Membership.User();
                                //Users.UserId, MembershipDate, IsApproved, IsLocked, Points, AppCulture, DisplayName
                                user.EmailAddress = email;
                                user.Password = password;
                                user.Id = Utils.Convert.ToInt64(reader["UserId"]).Value;
                                user.MembershipDate = Utils.Convert.ToDateTime(reader["MembershipDate"]).Value;
                                
                                user.Profile = new Membership.UserProfile();
                                user.Profile.DislayName = Utils.Convert.ToString(reader["DisplayName"]);
                                user.Profile.Culture = Utils.Convert.ToString(reader["AppCulture"]);

                                //user.Name = Utils.Convert.ToString(reader["UserName"]);
                                //user. = Utils.Convert.ToDateTime(reader["MembershipDate"]);
                                //user. = Utils.Convert.ToBool(reader["IsApproved"]);
                                //user. = Utils.Convert.ToBool(reader["IsLocked"]);
                            }
                        }

                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex));
            }

            return user;
        }


        internal static bool Create(string email, string password, string culture)
        {
            bool bRes = false;

            string username = email.Substring(0, email.IndexOf("@"));

            string query = "UserCreate";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@EmailAddress", email));
                    cmd.Parameters.Add(new SqlParameter("@Password", password));
                    cmd.Parameters.Add(new SqlParameter("@MembershipDate", DateTime.UtcNow));
                    cmd.Parameters.Add(new SqlParameter("@AppCulture", culture));

                    SqlParameter retVal = new SqlParameter("@ReturnValue", SqlDbType.Int);
                    retVal.Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(retVal);
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    object queryRes = cmd.ExecuteNonQuery();
                    if (retVal != null)
                    {
                        if (Convert.ToInt32(retVal.Value) == 0) bRes = true;
                    }

                    cnn.Close();
                }
            }

            return bRes;
        }
    }
}
