using System;



namespace DomainModel.Abstract
{
    public interface IMembership
    {
        bool ValidateUser(string Email, string Password);
        bool Exists(string Email);
        bool CreateUser(string Email);

        void SignIn(string Email, bool CreatePersistentCookie);
        void SignOut();
    }
}
