using System;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Entities;



namespace DomainModel.Repository.Sql
{
    public class Discussions
    {
        public static bool Insert(Forum forum, Discussion discussion, DiscussionMessage message)
        {
            bool res = false;

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
                        cmd.Parameters.Add(new SqlParameter("@DiscussionId", discussion == null ? 0 : discussion.Id));
                        cmd.Parameters.Add(new SqlParameter("@ParentId", message.Parent == null ? 0 : message.Parent.Id));
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
                                message.Id = Repository.Utils.Convert.ToInt32(reader["MessageId"]);
                                if (message.Id > 0)
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


        public static bool LoadProductDiscussions(ProductBase product, int startRow, int endRow)
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

                        cmd.Parameters.Add(new SqlParameter("@ForumId", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 0));
                        cmd.Parameters.Add(new SqlParameter("@ProductUrl", product.Catalog.UrlName));
                        cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                        cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));

                        foreach (SqlParameter Parameter in cmd.Parameters) 
                        { 
                            if (Parameter.Value == null) 
                            { 
                                Parameter.Value = DBNull.Value; 
                            }
                        }

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
                            Int32 messageId = 0;

                            while (reader.Read())
                            {
                                message = null;

                                discussionId = Repository.Utils.Convert.ToInt32(reader["DiscussionId"]);
                                parentId = Repository.Utils.Convert.ToInt32(reader["ParentId"]);
                                messageId = Repository.Utils.Convert.ToInt32(reader["MessageId"]);

                                // Update current discussion
                                if (discussion != null)
                                {
                                    // This message is in current discussion
                                    if (discussionId == discussion.Id)
                                    {
                                        // Do nothing. Current discussion is OK!
                                    }
                                    else if (discussionId <= 0)
                                    {
                                        // Discussion records don't have a DiscussionId
                                        // This is a new discussion
                                        // Let's find this discussion by it's id
                                        discussion = product.Forum.FindDiscussion(messageId);
                                    }
                                    else if (discussionId > 0)
                                    {
                                        // This is a message inside a discussion
                                        // Let's find it's discussion by it's id 
                                        discussion = product.Forum.FindDiscussion(discussionId);
                                    }
                                }

                                // If discussion not found, create and add it
                                if (discussion == null)
                                {
                                    // If this record is a discussion message
                                    if (discussionId <= 0)
                                    {
                                        discussion = new Discussion(messageId);
                                        message = discussion;
                                    }
                                    else if (parentId == discussionId)
                                    {
                                        // This is a message inside a discussion that does not exist?!
                                        discussion = new Discussion(discussionId);
                                        // Let next step handle message related stuff
                                    }

                                    product.Forum.Add(discussion);
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
                                message.Id = messageId;
                                message.Visibility = Repository.Utils.Convert.ToInt16(reader["Visibility"]);
                                message.IsAbuse = Repository.Utils.Convert.ToInt16(reader["IsAbuse"]);
                                message.InsertTime = Repository.Utils.Convert.ToDateTime(reader["InsertTime"]);
                                message.UpdateTime = Repository.Utils.Convert.ToDateTime(reader["UpdateTime"]);
                                message.UserId = Repository.Utils.Convert.ToInt64(reader["UserId"]);
                                message.UserName = Repository.Utils.Convert.ToString(reader["UserName"]);
                                message.UserIp = Repository.Utils.Convert.ToString(reader["UserIp"]);
                                message.Subject = Repository.Utils.Convert.ToString(reader["MessageSubject"]);
                                message.Body = Repository.Utils.Convert.ToString(reader["MessageBody"]);
                            }

                            reader.NextResult();
                            if (reader.Read())
                            {
                                product.Forum.TotalMessageCount = 
                                    Repository.Utils.Convert.ToInt32(reader["TotalRows"]);
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
