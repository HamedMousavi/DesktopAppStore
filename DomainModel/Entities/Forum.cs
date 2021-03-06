﻿using System;
using System.Collections.Generic;



namespace DomainModel.Entities
{
    public class Forum: List<Discussion>
    {
        public Int32 TotalMessageCount { get; set; }

        public Int16 ForumId { get; set; }
        public Int64 PageId { get; set; }
        public string UrlName { get; set; } // WHEN ForumId is NULL and forum is actually a discussion under an article
        public string ForumPageUrl { get; set; }   // Url of the page where forum is located


        internal Discussion FindDiscussion(int discussionId)
        {
            foreach (Discussion discussion in this)
            {
                if (discussion.Id == discussionId)
                {
                    return discussion;
                }
            }

            return null;
        }
    }
}
