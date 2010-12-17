using System;
using System.Data.SqlClient;
using System.Data;



namespace DomainModel.Repository.Sql
{
    public class Profiles
    {
        public static bool Update(Abstract.IUser user)
        {
            bool res = false;

            try
            {
                string query = "ProfileUpdateById";

                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@UserId", user.Id));
                        cmd.Parameters.Add(new SqlParameter("@AppCulture", user.Profile.Culture));
                        cmd.Parameters.Add(new SqlParameter("@DisplayName", user.Profile.DislayName));
                        cmd.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.UtcNow));

                        foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                        cnn.Open();

                        int affected = cmd.ExecuteNonQuery();
                        if (affected!=0)
                        {
                            res = true;
                        }

                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex.ToString()));
            }

            return res;
        }


        public static void LoadAll(long userId, Membership.UserProfile profile, string culture)
        {
            // UNDONE: USER EXISTS?!
            profile.Ownership.Details[culture].LastLoaded = DateTime.UtcNow;

            // Load loggos
            profile.Logos = new System.Collections.Generic.List<Entities.Picture>();
            Repository.Disk.UserProfiles.LoadLogos(userId, profile.Logos);

            // Load owner data
            // Only for current language: Load owner, products of owner, 
            // branches of owner, contacts of each branch
            //profile.Ownership.Details[culture].DisplayName;
            //profile.Ownership.Details[culture].Branches;
            //profile.Ownership.Details[culture].Branches[0].Contacts


/*
        if (Model.Profile.Logos != null && Model.Profile.Logos.Count > 0)
        {
        }
        else
        {
            uri = "/Content/Users/Common/Images/Logo.png";
        }
 
 */
            
            throw new NotImplementedException();
        }
    }
}

/*
  ۱۳۸۹/۰۹/۲۶ 
 */