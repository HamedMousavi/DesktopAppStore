using System;
using System.Security.Principal;



namespace DomainModel.Membership
{
    public class AnonymousIdentity : IIdentity
    {

        #region IIdentity Members

        public string AuthenticationType
        {
            get { return "Forms"; }
        }

        public bool IsAuthenticated
        {
            get { return false; }
        }

        public string Name
        {
            get { return string.Empty; }
        }

        #endregion
    }
}
