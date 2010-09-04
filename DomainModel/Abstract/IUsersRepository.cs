using System;



namespace DomainModel.Abstract
{
    public interface IUsersRepository
    {
        bool Authenticate(string username, string password);
        bool Exists(string Email);
        bool CreateUser(string Email, string Password);
        string GetUserName(string Email);

    }
}
