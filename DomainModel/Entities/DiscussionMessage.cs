using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class DiscussionMessage
    {
        public Int32? Id { get; set; }
        public Int16? Visibility { get; set; }
        public Int16? IsAbuse { get; set; }
        public DomainModel.Repository.Memory.Forums.MessageTypes Type { get; set; }
        public DateTime? InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public Int64? UserId { get; set; }
        public string UserIp { get; set; }
        public string UserName { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsParent { get; set; }

        public DiscussionMessage Parent { get; set; }
        public Discussion   Discussion { get; set; }
        public List<DiscussionMessage> Replies { get; set; }


        public DiscussionMessage()
        {
            this.Parent = null;
            this.Replies = new List<DiscussionMessage>();
        }


        internal DiscussionMessage FindMessage(int id)
        {
            if (this.Id == id) return this;

            DiscussionMessage res;
            foreach (DiscussionMessage message in this.Replies)
            {
                res = message.FindMessage(id);
                if (res != null) return res;
            }

            return null;
        }
    }
}
