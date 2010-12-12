using System;
using System.Security.Principal;
using System.Web.Security;



namespace DomainModel.Membership
{
    public class SarvsoftPrincipal : IPrincipal
    {
        public SarvsoftPrincipal(FormsAuthenticationTicket ticket, DomainModel.Abstract.IUser owner)
        {
            this.identity = new SarvsoftIdentity(ticket);
            this.owner = owner;
        }

        protected DomainModel.Abstract.IUser owner;
        public DomainModel.Abstract.IUser Owner { get { return this.owner; } }

        #region IPrincipal Members

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


        internal void SetTicket(FormsAuthenticationTicket authTicket)
        {
            if (this.identity.Ticket != authTicket)
            {
                this.identity.Ticket = authTicket;
            }
        }
    }
}
