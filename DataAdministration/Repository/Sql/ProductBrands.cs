using System;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;



namespace DataAdministration.Repository.Sql
{
    class ProductBrands
    {
        internal static void Reload(ApplicationProduct product)
        {
            product.Brands.Clear();

            string query = string.Format(
                "SELECT BrandId, BrandName, ResourceUrl " +
                "FROM dbo.ListBrands " +
                "WHERE BrandId IN (SELECT BrandId FROM dbo.ProductBrands WHERE ProductId = {0})", 
                product.ProductId);

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
                                ProductBrand brand = new ProductBrand();

                                brand.BrandId = Repository.Utils.Convert.ToInt32(reader[0]);
                                brand.BrandName = Repository.Utils.Convert.ToString(reader[1]);
                                brand.ResourceUrl = Repository.Utils.Convert.ToString(reader[2]);

                                product.Brands.Add(brand);
                            }

                            reader.Close();
                        }
                    }

                    cnn.Close();
                }
            }
        }



        internal static bool Add(ApplicationProduct product, ProductBrand brand)
        {
            string query =
                "DECLARE @Id BIGINT " +
                "SET @Id = -1 " +
                "INSERT INTO dbo.ListBrands " +
                "(BrandName, ResourceUrl) " +
                "VALUES " +
                "(@BrandName, @ResourceUrl);" +
                "SELECT @Id = SCOPE_IDENTITY(); " +
                "SELECT @Id; ";

            bool ok = false;

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    SqlTransaction transaction = null;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@BrandName", brand.BrandName));
                    cmd.Parameters.Add(new SqlParameter("@ResourceUrl", brand.ResourceUrl));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    try
                    {
                        cnn.Open();
                        transaction = cnn.BeginTransaction();
                        cmd.Transaction = transaction;

                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value)
                        {
                            brand.BrandId = Convert.ToInt64(res);
                            if (InsertProductBrand(brand.BrandId, product.ProductId.Value, cnn, transaction))
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



        private static bool InsertProductBrand(long brandId, long productId, SqlConnection cnn, SqlTransaction transaction)
        {
            bool res = false;

            string query =
                "INSERT INTO dbo.ProductBrands " +
                "(ProductId, BrandId) " +
                "VALUES " +
                "(@ProductId, @BrandId);";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ProductId", productId));
                cmd.Parameters.Add(new SqlParameter("@BrandId", brandId));

                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    res = true;
                }
            }

            return res;
        }



        internal static bool Update(ProductBrand brand)
        {
            string query =
                "UPDATE ListBrands " +
                "SET BrandName=@BrandName, ResourceUrl=@ResourceUrl " +
                "WHERE BrandId=@BrandId; ";

            bool ok = false;

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@BrandId", brand.BrandId));
                    cmd.Parameters.Add(new SqlParameter("@BrandName", brand.BrandName));
                    cmd.Parameters.Add(new SqlParameter("@ResourceUrl", brand.ResourceUrl));
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



        internal static bool Remove(ApplicationProduct product, ProductBrand brand)
        {
            string query =
                "DELETE FROM ProductBrands WHERE BrandId = @BrandId AND ProductId = @ProductId; " +
                "DELETE FROM ListBrands WHERE BrandId = @BrandId; ";

            bool ok = false;

            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.PersianSoftwareConnectionString))
            {
                SqlTransaction transaction = null;
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@BrandId", brand.BrandId));

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

            return ok;
        }
    }
}
