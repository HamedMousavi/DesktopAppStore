using System;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Entities;



namespace DomainModel.Repository.Sql
{
    public class Discussions
    {
        private static int discussionId = 0;


        protected static int NewDiscussionId
        {
            get
            {
                return System.Threading.Interlocked.Increment(ref discussionId);
            }
        }


        public static void Init()
        {
            // DiscussionId is used to sort database and retrieve
            // all messages of a given forum with just one query.
            // But it must be unique for every new message group in
            // database. We load last one from inserted items here
            // and during lifetime of the application we increment
            // it for each insert.
            LoadLastDiscussionId();
        }


        private static void LoadLastDiscussionId()
        {
            discussionId = 0;
            
            string query = "SELECT MAX(DiscussionId) AS DiscussionId FROM Discussions";

            using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;

                    cnn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            discussionId = Repository.Utils.Convert.ToInt32(reader["DiscussionId"]);
                        }
                    }

                    cnn.Close();
                }
            }
        }


        public static bool Insert(Forum forum, Discussion discussion, DiscussionMessage message)
        {
            bool res = false;
            if (message.IsParent && discussion == null)
            {
                discussion.DiscussionId = NewDiscussionId;
            }

            try
            {
                string query = "MessageInsert";

                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@ForumId", forum.ForumId));
                        cmd.Parameters.Add(new SqlParameter("@PageId", forum.PageId));
                        cmd.Parameters.Add(new SqlParameter("@DiscussionId", discussion.DiscussionId));
		                cmd.Parameters.Add(new SqlParameter("@ParentId", message.Parent.MessageId ));
		                cmd.Parameters.Add(new SqlParameter("@InsertTime", DateTime.UtcNow ));
		                cmd.Parameters.Add(new SqlParameter("@UserId", message.UserId ));
		                cmd.Parameters.Add(new SqlParameter("@UserIp", message.UserIp ));
		                cmd.Parameters.Add(new SqlParameter("@MessageSubject", message.Subject ));
		                cmd.Parameters.Add(new SqlParameter("@MessageBody", message.Body ));
                        cmd.Parameters.Add(new SqlParameter("@UrlName", forum.UrlName));

                        foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                        cnn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null && reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                message.MessageId = Repository.Utils.Convert.ToInt32(reader["MessageId"]);
                                if (message.MessageId > 0)
                                {
                                    res = true;
                                }
                                // If MessageId <= 0 ERROR
                            }
                        }

                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }


        public static bool GetProductDiscussions(ProductBase product, int startRow, int endRow)
        {
            bool res = false;

            try
            {
                string query = "MessagesList";

                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@ForumId", 0));
                        cmd.Parameters.Add(new SqlParameter("@ProductUrl", product.Catalog.UrlName));
                        cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                        cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));

                        foreach (SqlParameter Parameter in cmd.Parameters) { if (Parameter.Value == null) { Parameter.Value = DBNull.Value; } }

                        cnn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null && reader.HasRows)
                        {
                            // Initiate product forum
                            // For all products discussions ForumId = 0
                            product.Forum.ForumId = 0;
                            product.Forum.UrlName = product.Catalog.UrlName;
                            if (product.ProductId != null && product.ProductId.HasValue)
                                product.Forum.PageId = product.ProductId.Value;

                            // Every message belongs to a discussion in a forum
                            Discussion discussion = null;
                            DiscussionMessage message = null;
                            DiscussionMessage parent = null;

                            Int32 parentId = 0;
                            Int32 discussionId = 0;

                            while (reader.Read())
                            {
                                message = null;

                                discussionId = Repository.Utils.Convert.ToInt32(reader["DiscussionId"]);
                                parentId = Repository.Utils.Convert.ToInt32(reader["ParentId"]);

                                // Change current discussion
                                if (discussionId != discussion.DiscussionId)
                                {
                                    discussion = Forum.FindDiscussion(discussionId);
                                }

                                // If discussion with this id does not exists create and add it
                                if (discussion == null)
                                {
                                    discussion = new Discussion(discussionId);
                                    product.Forum.Add(discussion);
                                    message = discussion;
                                }

                                // This is a message with an unknown parent inside a known discussion
                                if (parentId <= 0 && message == null)
                                {
                                    // Add it to the root of the discussion
                                    message = new DiscussionMessage();

                                    discussion.Replies.Add(message);
                                }
                                else if (parentId > 0)// A new message
                                {
                                    message = new DiscussionMessage();

                                    // Find parent
                                    if (parent == null || parent.Id != parentId)
                                    {
                                        parent = discussion.FindMessage(parentId);
                                    }

                                    // Parent not found? Add it to the root of discussion
                                    if (parent == null) parent = discussion;

                                    parent.Replies.Add(message);
                                }

                                // At this point message must be at the right position
                                // Try load it's data.

                                // load message

                                //MessageId, ParentId, UpdateTime, ForumMessages.UserId, UserName, UserIp, MessageSubject, MessageBody
                            }
                        }

                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }
    }
}
