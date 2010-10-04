using System;
using System.Collections.Generic;
using DomainModel.Entities;
using System.Data.SqlClient;
using System.Data;



namespace DomainModel.Repository.Sql
{
    public class Products
    {
        public static GeneralDatabaseList GetByCategory(int? categoryId, int? parentId, int startRow, int endRow)
        {
            GeneralDatabaseList ret = new GeneralDatabaseList();
            List<ProductBase> products = null;
            string query = "SELECT COUNT(ProductId) FROM ProductCategories WHERE CategoryId IN (SELECT CategoryId FROM Categories WHERE CategoryId = @CategoryId OR ParentId = @ParentId GROUP BY CategoryId)";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
                    cmd.Parameters.Add(new SqlParameter("@ParentId", parentId));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();

                    object queryRes = cmd.ExecuteScalar();
                    if (queryRes != null)
                    {
                        ret.TotalCount = Convert.ToInt32(queryRes);
                    }

                    cnn.Close();
                }
            }

            query = 
                "SELECT * " +
                "FROM " +
                "( " +
                "    SELECT	row_number() OVER(ORDER BY SearchPriority DESC, EditorRating DESC, UserRating DESC, ProductReleaseDate DESC) as RowNumber, " +
                     "SoftwareProduct.ProductId, ProductName, ProductPrice, ProductReleaseDate, BriefDescription, IsMultiLanguage, " +
                     "EditorRating, UserRating, UrlName, ProductVersion " +
                "    FROM	SoftwareProduct, ProductCatalog " +
                "    WHERE	SoftwareProduct.ProductId IN (SELECT ProductId FROM ProductCategories WHERE CategoryId IN " +
                "       (SELECT CategoryId FROM Categories WHERE CategoryId = @CategoryId OR ParentId = @ParentId GROUP BY CategoryId)) " +
                "			AND ProductCatalog.ProductId = SoftwareProduct.ProductId " +
                ") T " +
                "WHERE RowNumber BETWEEN @startRow AND @endRow";


            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
                    cmd.Parameters.Add(new SqlParameter("@ParentId", parentId));
                    cmd.Parameters.Add(new SqlParameter("@startRow", startRow));
                    cmd.Parameters.Add(new SqlParameter("@endRow", endRow));
                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        products = new List<ProductBase>();

                        while (reader.Read())
                        {
                            ProductBase product = new ProductBase();
                            
                            product.ProductId = Repository.Utils.Convert.ToInt64(reader[1]);
                            product.ProductName = Repository.Utils.Convert.ToString(reader[2]);
                            product.Price = Repository.Utils.Convert.ToDecimal(reader[3]);
                            product.ProductReleaseDate = Repository.Utils.Convert.ToDateTime(reader[4]);
                            product.BriefDescription = Repository.Utils.Convert.ToString(reader[5]);
                            product.MultiLanguage = Repository.Utils.Convert.ToBool(reader[6]);
                            product.Catalog.EditorRating = Repository.Utils.Convert.ToDecimal(reader[7]);
                            product.Catalog.UserRating = Repository.Utils.Convert.ToDecimal(reader[8]);
                            product.Catalog.UrlName = Repository.Utils.Convert.ToString(reader[9]);
                            product.ProductVersion = Repository.Utils.Convert.ToString(reader[10]);

                            products.Add(product);
                        }
                    }

                    cnn.Close();
                }
            }

            ret.List = products;
            return ret;
        }
    }
}
