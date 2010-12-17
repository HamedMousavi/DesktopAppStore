using System;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Entities;



namespace DomainModel.Repository.Sql
{
    public class Discussions
    {

        public enum DiscussionFlags
        {
            Delete = 0,
            Abuse = 1
        }

        public static bool LoadProductDiscussions(ProductBase product, int startRow, int endRow)
        {
            bool res = false;

            try
            {
                // Initiate product forum
                // For all products discussions ForumId = 0
                product.Forum.ForumId = 0;
                product.Forum.UrlName = product.Catalog.UrlName;
                if (product.ProductId != null && product.ProductId.HasValue)
                    product.Forum.PageId = product.ProductId.Value;

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
                                    else
                                    {
                                        // This is a message inside a discussion
                                        // Or a root (a discussion) record so
                                        // Let's find discussion by it's id 
                                        discussion = product.Forum.FindDiscussion(discussionId);
                                    }
                                }

                                // If discussion not found, create and add it
                                if (discussion == null)
                                {
                                    discussion = new Discussion(discussionId, product.Forum);
                                    product.Forum.Add(discussion);

                                    if (messageId == discussionId)
                                    {
                                        // If this record is a discussion message
                                        message = discussion;
                                    }
                                    else
                                    {
                                        // This is a message inside a discussion that does not exist?!
                                        // An empty discussion created. Maybe filled later on
                                        // Let next step handle message related stuff
                                    }
                                }

                                // This is a message with an unknown parent inside a known discussion
                                if (parentId <= 0 && message == null)
                                {
                                    // Add it to the root of the discussion
                                    message = new DiscussionMessage();

                                    discussion.Replies.Add(message);
                                    message.Parent = discussion;
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
                                    message.Parent = parent;
                                }

                                message.Discussion = discussion;
                                // At this point message must be at the right position
                                // Try load it's data.

                                // load message
                                message.Id = messageId;
                                message.IsVisible = Repository.Utils.Convert.ToBool(reader["IsVisible"]);
                                message.IsAbuse = Repository.Utils.Convert.ToInt16(reader["IsAbuse"]);
                                message.Type = (Repository.Memory.Forums.MessageTypes)Repository.Utils.Convert.ToInt16(reader["MessageType"]);
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
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex.ToString()));
            }

            return res;
        }


        public static bool LoadMessageById(DiscussionMessage message)
        {
            bool res = false;

            try
            {
                string query = "MessageGetById";
                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MessageId", message.Id));

                        cnn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null && reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                // load message
                                message.IsVisible = Repository.Utils.Convert.ToBool(reader["IsVisible"]);
                                message.IsAbuse = Repository.Utils.Convert.ToInt16(reader["IsAbuse"]);
                                message.Type = (Repository.Memory.Forums.MessageTypes)Repository.Utils.Convert.ToInt16(reader["MessageType"]);
                                message.InsertTime = Repository.Utils.Convert.ToDateTime(reader["InsertTime"]);
                                message.UpdateTime = Repository.Utils.Convert.ToDateTime(reader["UpdateTime"]);
                                message.UserId = Repository.Utils.Convert.ToInt64(reader["UserId"]);
                                //message.UserName = Repository.Utils.Convert.ToString(reader["UserName"]);
                                message.UserIp = Repository.Utils.Convert.ToString(reader["UserIp"]);
                                message.Subject = Repository.Utils.Convert.ToString(reader["MessageSubject"]);
                                message.Body = Repository.Utils.Convert.ToString(reader["MessageBody"]);
                                
                                message.Discussion.Id = Repository.Utils.Convert.ToInt32(reader["DiscussionId"]);
                                message.Parent.Id = Repository.Utils.Convert.ToInt32(reader["ParentId"]);

                                message.IsParent = (message.Discussion.Id == message.Id);
                            }
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


        public static bool LoadMessageAndParent(DiscussionMessage message, DiscussionMessage parent)
        {
            bool res = false;

            try
            {
                string query = "MessageGetWithParentById";
                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MessageId", message.Id));

                        cnn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null && reader.HasRows)
                        {
                            DiscussionMessage msg = message;
                            while (reader.Read())
                            {
                                // load message
                                msg.IsVisible = Repository.Utils.Convert.ToBool(reader["IsVisible"]);
                                msg.IsAbuse = Repository.Utils.Convert.ToInt16(reader["IsAbuse"]);
                                msg.Type = (Repository.Memory.Forums.MessageTypes)Repository.Utils.Convert.ToInt16(reader["MessageType"]);
                                msg.InsertTime = Repository.Utils.Convert.ToDateTime(reader["InsertTime"]);
                                msg.UpdateTime = Repository.Utils.Convert.ToDateTime(reader["UpdateTime"]);
                                msg.UserId = Repository.Utils.Convert.ToInt64(reader["UserId"]);
                                //msg.UserName = Repository.Utils.Convert.ToString(reader["UserName"]);
                                msg.UserIp = Repository.Utils.Convert.ToString(reader["UserIp"]);
                                msg.Subject = Repository.Utils.Convert.ToString(reader["MessageSubject"]);
                                msg.Body = Repository.Utils.Convert.ToString(reader["MessageBody"]);

                                msg.Discussion.Id = Repository.Utils.Convert.ToInt32(reader["DiscussionId"]);
                                msg.Parent.Id = Repository.Utils.Convert.ToInt32(reader["ParentId"]);

                                msg.IsParent = (msg.Discussion.Id == msg.Id);

                                // If message has parent, switch to load parent otherwise break
                                if (msg == message)
                                {
                                    if (msg.IsParent) break;
                                    else
                                    {
                                        msg = parent;
                                        reader.NextResult();
                                    }
                                }
                                else break;
                            }
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


        public static bool Update(DiscussionMessage message)
        {
            bool res = false;

            try
            {
                string query = "MessageUpdateById";

                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MessageId", message.Id));
                        cmd.Parameters.Add(new SqlParameter("@MessageType", message.Type));
                        cmd.Parameters.Add(new SqlParameter("@UpdateTime", DateTime.UtcNow));
                        cmd.Parameters.Add(new SqlParameter("@UserId", message.UserId));
                        cmd.Parameters.Add(new SqlParameter("@UserIp", message.UserIp));
                        cmd.Parameters.Add(new SqlParameter("@MessageSubject", message.Subject));
                        cmd.Parameters.Add(new SqlParameter("@MessageBody", message.Body));

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
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex.ToString()));
            }

            return res;
        }


        public static bool Insert(DiscussionMessage message)
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

                        cmd.Parameters.Add(new SqlParameter("@ForumId", message.Discussion.Forum.ForumId));
                        cmd.Parameters.Add(new SqlParameter("@PageId", message.Discussion.Forum.PageId));
                        cmd.Parameters.Add(new SqlParameter("@DiscussionId", message.Discussion.Id));
                        cmd.Parameters.Add(new SqlParameter("@ParentId", message.Parent.Id));
                        cmd.Parameters.Add(new SqlParameter("@InsertTime", DateTime.UtcNow));
                        cmd.Parameters.Add(new SqlParameter("@UserId", message.UserId));
                        cmd.Parameters.Add(new SqlParameter("@UserIp", message.UserIp));
                        cmd.Parameters.Add(new SqlParameter("@MessageSubject", message.Subject));
                        cmd.Parameters.Add(new SqlParameter("@MessageBody", message.Body));
                        cmd.Parameters.Add(new SqlParameter("@UrlName", message.Discussion.Forum.UrlName));
                        cmd.Parameters.Add(new SqlParameter("@MessageType", message.Type));

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
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex.ToString()));
            }

            return res;
        }


        public static bool Delete(Int32 messageId, Int64 userId, string userIp)
        {
            bool res = false;

            try
            {
                string query = "DiscussionFlag";
                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MessageId", messageId));
                        cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                        cmd.Parameters.Add(new SqlParameter("@FlagId", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 
                            DiscussionFlags.Delete));
                        cmd.Parameters.Add(new SqlParameter("@FlagDate", DateTime.UtcNow));
                        cmd.Parameters.Add(new SqlParameter("@UserIp", userIp));

                        foreach (SqlParameter Parameter in cmd.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }

                        cnn.Open();

                        int affected = cmd.ExecuteNonQuery();
                        if (affected != 0)
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


        public static bool Report(Int32 messageId, Int64 userId, string userIp)
        {
            bool res = false;

            try
            {
                string query = "DiscussionFlag";
                using (SqlConnection cnn = new SqlConnection(Configurations.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@MessageId", messageId));
                        cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                        cmd.Parameters.Add(new SqlParameter("@FlagId", SqlDbType.TinyInt, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default,
                            DiscussionFlags.Abuse));
                        cmd.Parameters.Add(new SqlParameter("@FlagDate", DateTime.UtcNow));
                        cmd.Parameters.Add(new SqlParameter("@UserIp", userIp));

                        foreach (SqlParameter Parameter in cmd.Parameters)
                        {
                            if (Parameter.Value == null)
                            {
                                Parameter.Value = DBNull.Value;
                            }
                        }


                        cnn.Open();

                        int affected = cmd.ExecuteNonQuery();
                        if (affected != 0)
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
    }
}
