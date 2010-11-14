using System;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;




namespace DomainModel.Repository.Sql
{
    public class Catalog
    {
        public static bool Load(string productUrlName, string cultureId, ApplicationProduct product)
        {
            bool res = false;

            string userName = string.Empty;
            string query = "CatalogLoad";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UrlName", productUrlName));
                    cmd.Parameters.Add(new SqlParameter("@CultureId", cultureId));

                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        // Read first table: SoftwareProduct
                        if (reader.Read())
                        {
                            product.ProductId = Repository.Utils.Convert.ToInt64(reader[0]);
                            product.ProductWebsite = Repository.Utils.Convert.ToString(reader[1]);
                            product.ProductVersion = Repository.Utils.Convert.ToString(reader[2]);
                            product.ProductReleaseDate = Repository.Utils.Convert.ToDateTime(reader[3]);
                            product.Price = Repository.Utils.Convert.ToDecimal(reader[4]);
                            product.MinimumVolumeSize = Repository.Utils.Convert.ToFloat(reader[5]);
                            product.MultiUser = Repository.Utils.Convert.ToBool(reader[6]);
                            product.MultiLanguage = Repository.Utils.Convert.ToBool(reader[7]);
                            product.LanguageExtendable = Repository.Utils.Convert.ToBool(reader[8]);
                        }

                        // Read next table: Details
                        reader.NextResult();
                        while (reader.Read())
                        {
                            product.ProductName = Repository.Utils.Convert.ToString(reader[0]);
                            product.BriefDescription = Repository.Utils.Convert.ToString(reader[1]);
                            product.PriceDetails = Repository.Utils.Convert.ToString(reader[2]);
                            product.GuarantyDetails = Repository.Utils.Convert.ToString(reader[3]);
                        }

                        // Read next table: Brands
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductBrand brand = new ProductBrand();
                            //brand.BrandId = ;
                            brand.BrandName = Utils.Convert.ToString(reader[0]);

                            product.Brands.Add(brand);
                        }

                        // Read next table: Catalog
                        reader.NextResult();
                        if (reader.Read())
                        {
                            product.Catalog.SearchPriority = Repository.Utils.Convert.ToInt32(reader[0]);
                            product.Catalog.UserRating = Repository.Utils.Convert.ToDecimal(reader[1]);
                            product.Catalog.EditorRating = Repository.Utils.Convert.ToDecimal(reader[2]);
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader[3]);
                            product.Catalog.ViewsCount = Repository.Utils.Convert.ToInt32(reader[4]);
                            product.Catalog.UpdateDate = Repository.Utils.Convert.ToDateTime(reader[5]);
                            product.Catalog.InsertDate = Repository.Utils.Convert.ToDateTime(reader[6]);
                        }


                        // UNDONE:
                        // Read next table: Categories
                        reader.NextResult();

                        // Read next table: Contacts
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductContact contact = new ProductContact();
                            ContactUnit unit = new ContactUnit();
                            ContactMediaType media = new ContactMediaType();

                            contact.Unit = unit;
                            contact.MediaType = media;

                            contact.Id = Repository.Utils.Convert.ToInt64(reader[0]);
                            unit.Id = Repository.Utils.Convert.ToInt32(reader[1]);
                            unit.Name = Repository.Utils.Convert.ToString(reader[2]);
                            contact.ContactValue = Repository.Utils.Convert.ToString(reader[3]);
                            contact.ContactPerson = Repository.Utils.Convert.ToString(reader[4]);
                            media.Id = Repository.Utils.Convert.ToInt32(reader[5]);
                            media.Name = Repository.Utils.Convert.ToString(reader[6]);

                            product.ProductContacts.Add(contact);
                        }


                        // Read next table: Customization
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductCustomizationOption customize = new ProductCustomizationOption();

                            customize.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            customize.Name = Repository.Utils.Convert.ToString(reader[1]);

                            product.CustomizationOptions.Add(customize);
                        }



                        // Read next table: Backup
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductDataBackupOption backup = new ProductDataBackupOption();
                            backup.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            backup.Name = Repository.Utils.Convert.ToString(reader[1]); ;

                            product.BackupOptions.Add(backup);
                        }

                        // Read next table: Demo
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductDemoOption demo = new ProductDemoOption();

                            demo.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            demo.Name = Repository.Utils.Convert.ToString(reader[1]); ;

                            product.DemoOptions.Add(demo);
                        }

                        // Read next table: Environment
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductEnvironmentOption env = new ProductEnvironmentOption();
                            env.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            env.Name = Repository.Utils.Convert.ToString(reader[1]); ;

                            product.EnvironmentOptions.Add(env);
                        }

                        // Read next table: Extension
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductExtensionOptions ext = new ProductExtensionOptions();
                            ext.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            ext.Name = Repository.Utils.Convert.ToString(reader[1]); ;

                            product.ExtensionOptions.Add(ext);
                        }

                        // Read next table: Guaranty
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductGuarantyOption guaranty = new ProductGuarantyOption();
                            guaranty.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            guaranty.Name = Repository.Utils.Convert.ToString(reader[1]);

                            product.GuarantyOptions.Add(guaranty);
                        }

                        // Read next table: Requirements
                        reader.NextResult();
                        while (reader.Read())
                        {
                            product.HardwareRequirements.Add(Repository.Utils.Convert.ToString(reader[1]));
                        }


                        // Read next table: Installation
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductInstallationOption inst = new ProductInstallationOption();

                            inst.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            inst.Name = Repository.Utils.Convert.ToString(reader[1]);

                            product.InstallationOptions.Add(inst);
                        }


                        // Read next table: Languages
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductLanguage lang = new ProductLanguage();
                            lang.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            lang.Name = Repository.Utils.Convert.ToString(reader[1]);

                            product.SupportedLanguages.Add(lang);
                        }

                        // Read next table: Payment 
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductPaymentOption payment = new ProductPaymentOption();
                            payment.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            payment.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.PaymentOptions.Add(payment);
                        }

                        // Read next table: SoftwarePlatforms
                        reader.NextResult();
                        while (reader.Read())
                        {
                            SoftwarePlatform platform = new SoftwarePlatform();
                            platform.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            platform.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.SupportedPlatforms.Add(platform);
                        }

                        // Read next table: Publish
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductPublishOption publish = new ProductPublishOption();
                            publish.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            publish.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.PublishOptions.Add(publish);
                        }


                        // Read next table: Source
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductSourceOption source = new ProductSourceOption();
                            source.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            source.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.SourceOptions.Add(source);
                        }

                        // Read next table: Support
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductSupportOption support = new ProductSupportOption();
                            support.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            support.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.SupportOptions.Add(support);
                        }

                        // Read next table: SupportTypes
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductSupportType type = new ProductSupportType();
                            type.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            type.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.SupportTypes.Add(type);
                        }

                        // Read next table: Tags
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductTag tag = new ProductTag();
                            tag.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            tag.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.Tags.Add(tag);
                        }

                        // Read next table: Technologies
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductTechnology tech = new ProductTechnology();
                            tech.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            tech.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.ProductTechnologies.Add(tech);
                        }

                        // Read next table: Update
                        reader.NextResult();
                        while (reader.Read())
                        {
                            ProductUpdateOption update = new ProductUpdateOption();
                            update.Id = Repository.Utils.Convert.ToInt32(reader[0]);
                            update.Name = Repository.Utils.Convert.ToString(reader[1]);
                            product.UpdateOptions.Add(update);
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
