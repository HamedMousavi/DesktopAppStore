using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class Discussion : DiscussionMessage
    {
        public Forum forum { get; set; }

        public Discussion(int discussionId, Forum forum)
        {
            this.IsParent = true;
            this.Id = discussionId;
            this.forum = forum;
        }
    }
}
