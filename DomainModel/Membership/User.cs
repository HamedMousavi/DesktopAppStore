using System;
using DomainModel.Abstract;
using System.Security.Principal;



namespace DomainModel.Membership
{
    public class User : IUser, IPrincipal
    {
        public enum Personhoods
        {
            Mr,
            Mrs,
            LLC,
            Corp,
            Unknown
        }

        
        public Int64 Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string RemoteIpAddresses { get; set; }
        public DateTime MembershipDate { get; set; }
        public UserProfile Profile { get; set; }
        public Personhoods Personhood { get; set; }

        // These will be used by website security service
        public Int32 Index { get; set; }


        public User()
        {
            this.identity = new SarvsoftIdentity(null);
        }


        #region IPrincipal Members

        public SarvsoftIdentity Identitiy { get { return this.identity; } }

        protected SarvsoftIdentity identity;

        public IIdentity Identity
        {
            get { return this.identity; }
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        #endregion
    }
}
