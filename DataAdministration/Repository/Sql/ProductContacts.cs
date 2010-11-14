using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DataAdministration.Repository.Sql
{
    public class ProductContacts
    {
        protected static ListContactMedia listContactMedia;
        protected static ListContactUnits listContactUnits;

        

        internal static bool Insert(ProductContact contact, ApplicationProduct product)
        {
            string query =
                "DECLARE @Id BIGINT " +
                "SET @Id = -1 " +
                "INSERT INTO Contacts " +
                "(ContactUnitTitleId, ContactMediaId, ContactValue, ContactPerson) " +
                "VALUES " +
                "(@ContactUnitTitleId, @ContactMediaId, @ContactValue, @ContactPerson);" +
                "SELECT @Id = SCOPE_IDENTITY(); " +
                "SELECT @Id; ";

            bool ok = false;

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    SqlTransaction transaction = null;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@ContactUnitTitleId", contact.Unit.Id));
                    cmd.Parameters.Add(new SqlParameter("@ContactMediaId", contact.MediaType.Id));
                    cmd.Parameters.Add(new SqlParameter("@ContactValue", contact.ContactValue));
                    cmd.Parameters.Add(new SqlParameter("@ContactPerson", contact.ContactPerson));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    try
                    {
                        cnn.Open();
                        transaction = cnn.BeginTransaction();
                        cmd.Transaction = transaction;

                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value)
                        {
                            contact.Id = Convert.ToInt64(res);
                            if (InsertProductContact(contact.Id, product.ProductId, cnn, transaction))
                            {
                                ok = true;
                            }
                        }

                        if (ok) transaction.Commit();
                        else transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }

                    cnn.Close();
                }
            }

            return ok;
        }



        private static bool InsertProductContact(Int64? contactId, Int64? productId,SqlConnection cnn, SqlTransaction transaction)
        {
            bool res = false;

            string query =
                "INSERT INTO ProductContacts " +
                "(ProductId, ContactId) " +
                "VALUES " +
                "(@ProductId, @ContactId);";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ProductId", productId));
                cmd.Parameters.Add(new SqlParameter("@ContactId", contactId));

                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    res = true;
                }
            }

            return res;
        }



        internal static bool Update(ProductContact contact)
        {
            string query =
                "UPDATE Contacts " +
                "SET ContactUnitTitleId=@ContactUnitTitleId, ContactMediaId=@ContactMediaId, ContactValue=@ContactValue, ContactPerson=@ContactPerson " +
                "WHERE ContactId=@ContactId; ";

            bool ok = false;

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ContactId", contact.Id));
                    cmd.Parameters.Add(new SqlParameter("@ContactUnitTitleId", contact.Unit.Id));
                    cmd.Parameters.Add(new SqlParameter("@ContactMediaId", contact.MediaType.Id));
                    cmd.Parameters.Add(new SqlParameter("@ContactValue", contact.ContactValue));
                    cmd.Parameters.Add(new SqlParameter("@ContactPerson", contact.ContactPerson));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        ok = true;
                    }

                    cnn.Close();
                }
            }

            return ok;
        }



        internal static void Delete(ProductContact contact, ApplicationProduct product)
        {
            string query =
                "DELETE FROM ProductContacts WHERE ContactId = @ContactId AND ProductId = @ProductId; " +
                "DELETE FROM Contacts WHERE ContactId = @ContactId; ";

            bool ok = false;

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                SqlTransaction transaction = null;
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@ContactId", contact.Id));

                    try
                    {
                        foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }
                        cnn.Open();
                        transaction = cnn.BeginTransaction();
                        cmd.Transaction = transaction;

                        int affected = cmd.ExecuteNonQuery();
                        if (affected >= 2)
                        {
                            ok = true;
                        }

                        if (ok) transaction.Commit();
                        else transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }

                    cnn.Close();
                }
            }
        }



        public static ListContactMedia GetMediaList(bool reload)
        {
            if (listContactMedia == null)
            {
                listContactMedia = new DataAdministration.ListContactMedia();
                reload = true;
            }

            if (reload)
            {
                listContactMedia.Clear();

                string query = "SELECT * FROM ListContactMedias";

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
                                while (reader.Read())
                                {
                                    if (reader[0] != null)
                                    {
                                        ContactMediaType item = new ContactMediaType();
                                        item.Id = Convert.ToInt32(reader[0]);
                                        item.Name = Convert.ToString(reader[1]);

                                        listContactMedia.Add(item);
                                    }
                                }

                                reader.Close();
                            }
                        }

                        cnn.Close();
                    }
                }
            }

            return listContactMedia;
        }



        public static ListContactUnits GetUnitList(bool reload)
        {
            if (listContactUnits == null)
            {
                listContactUnits = new DataAdministration.ListContactUnits();
                reload = true;
            }

            if (reload)
            {
                listContactUnits.Clear();

                string query = "SELECT * FROM ListContactUnitTitles";

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
                                while (reader.Read())
                                {
                                    if (reader[0] != null)
                                    {
                                        ContactUnit item = new ContactUnit();
                                        item.Id = Convert.ToInt32(reader[0]);
                                        item.Name = Convert.ToString(reader[1]);

                                        listContactUnits.Add(item);
                                    }
                                }

                                reader.Close();
                            }
                        }

                        cnn.Close();
                    }
                }
            }

            return listContactUnits;
        }



        internal static void Reload(ApplicationProduct product)
        {
            string query = string.Format(
                "SELECT Contacts.ContactId, ContactValue, ContactPerson, UnitTitleName, Contacts.ContactMediaId, ContactUnitTitleId, ListContactMedias.ContactMediaName " +
                "FROM Contacts, ListContactUnitTitles, ListContactMedias " +
                "WHERE Contacts.ContactId IN (SELECT ContactId FROM ProductContacts WHERE ProductId = {0}) " +
                "AND Contacts.ContactMediaId = ListContactMedias.ContactMediaId AND " +
                "ListContactUnitTitles.UnitTitleId = Contacts.ContactUnitTitleId AND" +
                " ListContactUnitTitles.LanguageId = {1} AND ListContactMedias.LanguageId = {1}", 
                product.ProductId, product.ArticleLanguage);

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
                            while (reader.Read())
                            {
                                ProductContact contact = new ProductContact();
                                contact.Id = Repository.Utils.Convert.ToInt64(reader[0]);
                                contact.ContactValue = Repository.Utils.Convert.ToString(reader[1]);
                                contact.ContactPerson = Repository.Utils.Convert.ToString(reader[2]);
                                contact.Unit.Name = Repository.Utils.Convert.ToString(reader[3]);
                                contact.MediaType.Id = Repository.Utils.Convert.ToInt32(reader[4]);
                                contact.Unit.Id = Repository.Utils.Convert.ToInt32(reader[5]);
                                contact.MediaType.Name = Repository.Utils.Convert.ToString(reader[6]);

                                product.ProductContacts.Add(contact);
                            }

                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }
        }
    }
}
