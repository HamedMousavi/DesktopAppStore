using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class Forum: List<Discussion>
    {
        public Int16 ForumId { get; set; }
        public Int64 PageId { get; set; }
        public object UrlName { get; set; } // WHEN ForumId is NULL and forum is actually a discussion under an article


        internal static Discussion FindDiscussion(int discussionId)
        {
            throw new NotImplementedException();
        }
    }
}
