using System;
using System.Data.SqlClient;
using System.Data;



namespace DomainModel.Repository.Sql
{
    public class ProductRatings
    {

        public static bool Insert(long? UserName, long? ProductId, short? VoteValue)
        {
            bool res = false;

            string query = "ProductVote";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", ProductId.Value));
                    cmd.Parameters.Add(new SqlParameter("@UserId", UserName.Value));
                    cmd.Parameters.Add(new SqlParameter("@Rating", VoteValue.Value));
                    cmd.Parameters.Add(new SqlParameter("@InsertTime", DateTime.UtcNow));

                    foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                    cnn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    cnn.Close();

                    if (affected <= 0)
                    {
                        // UNDONE: WHAT TO DO? UNABLE TO VOTE. USER MUST KNOW
                    }
                }
            }

            return res;
        }
    }
}
