using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class Discussion : DiscussionMessage
    {
        public Forum Forum { get; set; }

        public Discussion(int discussionId, Forum forum)
        {
            this.IsParent = true;
            this.Id = discussionId;
            this.Forum = forum;
        }
    }
}
