using System;
using System.Security.Principal;



namespace DomainModel.Membership
{
    public class AnonymousUser : IPrincipal
    {

        protected AnonymousIdentity identity;


        public AnonymousUser()
        {
            this.identity = new AnonymousIdentity();
        }


        #region IPrincipal Members

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
