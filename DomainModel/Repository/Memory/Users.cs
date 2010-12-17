using System;
using DomainModel.Membership;


namespace DomainModel.Repository.Memory
{
    public class Users
    {
        #region singleton

        protected static Users instance;
        protected static object instLock = new object();
        public static Users Instance
        {
            get
            {
                lock (instLock)
                {
                    if (instance == null)
                    {
                        instance = new Users();
                    }
                }

                return instance;
            }
        }

        #endregion


        protected SarvsoftUsers items;


        public Users()
        {
            this.items = new SarvsoftUsers();
        }


        public int AddUser(Membership.User user)
        {
            this.items.Add(user);

            // Try reverse search. This must be very fast since item is now probably
            // at the end of the list, unless ofcourse in heavy loads and concurrent
            // insertions
            int index = -1;
            int count = this.items.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (this.items[i] == user)
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
            {
                index = this.items.IndexOf(user);
            }

            user.Index = index;
            return index;
        }


        internal User Authenticate(string Email, string Password)
        {
            foreach (User item in this.items)
            {
                if (item.EmailAddress.Equals(Email, StringComparison.Ordinal) &&
                    item.Password.Equals(Password, StringComparison.Ordinal))
                {
                    return item;
                }
            }

            // Not in memory. Try loading it.
            User user = Repository.Sql.Users.GetUser(Email, Password);
            if (user != null) AddUser(user);

            return user;
        }


        internal User GetUser(int index)
        {
            if (index >= this.items.Count) return null;

            return this.items[index];
        }


        public DomainModel.Abstract.IUser GetUser(Int64 userId)
        {
            foreach (DomainModel.Abstract.IUser user in this.items)
            {
                if (user.Id == userId)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
