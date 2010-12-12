using System;
using DomainModel.Abstract;



namespace DomainModel.Membership
{
    public class User : IUser
    {
        public Int64 Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string RemoteIpAddresses { get; set; }
        public DateTime MembershipDate { get; set; }
        public UserProfile Profile { get; set; }

        // These will be used by website security service
        public Int32 Index { get; set; }
        public SarvsoftPrincipal Principal { get; set; }
    }
}
