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


        public static bool LoadAll(long userId, Membership.UserProfile profile, string culture)
        {
            bool res = false;

            profile.Ownership.UserId = userId;

            Entities.ProductOwnerDetails owner = profile.Ownership.Details[culture];
            if (owner == null)
            {
                owner = new Entities.ProductOwnerDetails();
                owner.Language = Repository.Memory.Languages.Instance.Items[culture];
                profile.Ownership.Details.Add(owner);
            }

            // UNDONE: USER EXISTS?!
            owner.LastLoaded = DateTime.UtcNow;

            // Load loggos
            profile.Logos = new System.Collections.Generic.List<Entities.Picture>();
            Repository.Disk.UserProfiles.LoadLogos(userId, profile.Logos);

            string query = "UserLoadCompleteProfile";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Culture", culture));
                    cmd.Parameters.Add(new SqlParameter("@UserId", userId));

                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {

                        // Owner Profile details
                        while (reader.Read())
                        {
                            owner.DisplayName = Utils.Convert.ToString(reader["DisplayName"]);
                        }

                        // Owner registered products
                        owner.Products.Clear();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            Entities.ProductBase product = new Entities.ProductBase();

                            product.ProductId = Repository.Utils.Convert.ToInt64(reader["ProductId"]);
                            product.ProductName = Repository.Utils.Convert.ToString(reader["ProductName"]);
                            product.Price = Repository.Utils.Convert.ToDecimal(reader["ProductPrice"]);
                            product.ProductReleaseDate = Repository.Utils.Convert.ToDateTime(reader["ProductReleaseDate"]);
                            product.BriefDescription = Repository.Utils.Convert.ToString(reader["BriefDescription"]);
                            product.MultiLanguage = Repository.Utils.Convert.ToBool(reader["IsMultiLanguage"]);
                            product.Catalog.EditorRating = Repository.Utils.Convert.ToDecimal(reader["EditorRating"]);
                            product.Catalog.UserRating = Repository.Utils.Convert.ToDecimal(reader["UserRating"]);
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader["UrlName"]);
                            product.ProductVersion = Repository.Utils.Convert.ToString(reader["ProductVersion"]);

                            product.Catalog.IsFeatured = Repository.Utils.Convert.ToBool(reader["IsFeatured"]);
                            product.Catalog.UpdateDate = Repository.Utils.Convert.ToDateTime(reader["UpdateDate"]);
                            product.Catalog.FeatureRating = Repository.Utils.Convert.ToDecimal(reader["FeatureRating"]);
                            product.Catalog.Popularity = Repository.Utils.Convert.ToDecimal(reader["Popularity"]);

                            owner.Products.Add(product);
                        }

                        // Owner branches
                        owner.Branches.Clear();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            Entities.OwnerBranch branch = new Entities.OwnerBranch();
                            branch.Owner = owner;

                            branch.Id = Repository.Utils.Convert.ToInt64(reader["BranchId"]);
                            branch.IsMainBranch = Repository.Utils.Convert.ToBool(reader["IsMainBranch"]);
                            branch.Name = Repository.Utils.Convert.ToString(reader["BranchName"]);

                            branch.Address.Country = Repository.Utils.Convert.ToString(reader["AddressCountry"]);
                            branch.Address.City = Repository.Utils.Convert.ToString(reader["AddressCity"]);
                            branch.Address.Street = Repository.Utils.Convert.ToString(reader["AddressStreet"]);
                            branch.Address.Bulavard = Repository.Utils.Convert.ToString(reader["AddressBulavard"]);
                            branch.Address.Avenue = Repository.Utils.Convert.ToString(reader["AddressAvenue"]);
                            branch.Address.Plate = Repository.Utils.Convert.ToString(reader["AddressPlate"]);

                            owner.Branches.Add(branch);
                        }

                        // Owner branch contacts
                        reader.NextResult();
                        while (reader.Read())
                        {
                            Int64? id = Repository.Utils.Convert.ToInt64(reader["BranchId"]);
                            Entities.OwnerBranch branch = owner.Branches[id];
                            if (branch != null)
                            {
                                Entities.ProductContact contact = new Entities.ProductContact();

                                Entities.ContactUnit unit = new Entities.ContactUnit();
                                Entities.ContactMediaType media = new Entities.ContactMediaType();

                                contact.Unit = unit;
                                contact.MediaType = media;

                                contact.Id = Repository.Utils.Convert.ToInt64(reader["ContactId"]);
                                unit.Id = Repository.Utils.Convert.ToInt32(reader["UnitTitleId"]);
                                unit.Name = Repository.Utils.Convert.ToString(reader["UnitTitleName"]);
                                contact.ContactValue = Repository.Utils.Convert.ToString(reader["ContactValue"]);
                                contact.ContactPerson = Repository.Utils.Convert.ToString(reader["ContactPerson"]);
                                media.Id = Repository.Utils.Convert.ToInt32(reader["ContactMediaId"]);
                                media.Name = Repository.Utils.Convert.ToString(reader["ContactMediaName"]);

                                branch.Contacts.Add(contact);
                            }
                        }

                        res = true;
                    }

                    cnn.Close();
                }
            }

            return res;
        }
    }
}
