using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class Discussion : DiscussionMessage
    {
        public Int32 DiscussionId { get; set; }

        public Discussion(Int32 discussionId)
        {
            this.IsParent = true;
            this.DiscussionId = discussionId;
        }


        internal DiscussionMessage FindMessage(int parentId)
        {
            throw new NotImplementedException();
        }
    }
}
