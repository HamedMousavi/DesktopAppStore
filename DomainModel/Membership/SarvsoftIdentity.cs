using System;
using System.Security.Principal;
using System.Web.Security;



namespace DomainModel.Membership
{
    public class SarvsoftIdentity : IIdentity
    {
        public FormsAuthenticationTicket Ticket { get; set; }

        public SarvsoftIdentity(FormsAuthenticationTicket ticket)
        {
            this.Ticket = ticket;
        }

        #region IIdentity Members

        public string AuthenticationType
        {
            get { return "Forms"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return this.Ticket.Name; }
        }

        #endregion
    }
}
