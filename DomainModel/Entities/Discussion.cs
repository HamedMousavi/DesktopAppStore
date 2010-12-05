using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class Discussion : DiscussionMessage
    {
        public Discussion(Int32 discussionId)
        {
            this.IsParent = true;
            this.Id = discussionId;
        }
    }
}
