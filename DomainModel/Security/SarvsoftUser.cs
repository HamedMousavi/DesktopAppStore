using System;
using System.Security.Principal;


namespace DomainModel.Security
{
    public class SarvsoftUser : IPrincipal
    {
        public Int64 Id { get; set; }
        public string RemoteIpAddresses { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Name { get { return this.EmailAddress; } }


        public SarvsoftUser()
        {
            this.identity = new SarvsoftUserIdentity();
        }


        #region IPrincipal Members

        protected IIdentity identity;

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
