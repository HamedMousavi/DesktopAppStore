using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web.Security;



namespace DomainModel.Security
{
    public class SarvsoftUserIdentity : IIdentity
    {
        public FormsAuthenticationTicket Ticket { get; set; }

        public SarvsoftUserIdentity()
		{
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
