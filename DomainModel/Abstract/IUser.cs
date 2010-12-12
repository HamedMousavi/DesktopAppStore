using System;


namespace DomainModel.Abstract
{
    public interface IUser
    {
        Int64 Id { get; set; }
        string EmailAddress { get; set; }
        string Password { get; set; }
        string RemoteIpAddresses { get; set; }
        DateTime MembershipDate { get; set; }
        DomainModel.Membership.UserProfile Profile { get; set; }
    }
}
