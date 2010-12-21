﻿using System;



namespace DomainModel.Repository.Memory
{
    public static class Forums
    {
        public enum MessageTypes
        {
            General = 0,
            Question = 1,
            Answer = 2,
            Joke = 3
        }

        public enum ForumType
        {
            Product = 0,
            UserProfile = 1,
            Weblog = 2
        }
    }
}
