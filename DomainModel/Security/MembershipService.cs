using System;
using DomainModel.Abstract;
using System.Web.Security;



namespace DomainModel.Security
{
    public class MembershipService : IMembership
    {
        #region IMembership Members

        public bool ValidateUser(string Email, string Password)
        {
            // Validate input
            if (String.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Value cannot be null or empty.", "username");
            if (String.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            // Remove unused space
            Email = Email.Trim();
            Password = Password.Trim();

            // Encrypt information
            ICrypt crypt = new SimpleCrypt();
            Email = crypt.Encrypt(Email);
            Password = crypt.Encrypt(Password);

            // Verify user existance
            return Membership.ValidateUser(Email, Password);
        }


        public void SignIn(string Email, bool CreatePersistentCookie)
        {
            if (String.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            string username = GetUserName(Email);

            FormsAuthentication.SetAuthCookie(username, CreatePersistentCookie);
        }


        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }


        private string GetUserName(string Email)
        {
            // Cleanup input
            Email = Email.Trim();

            // Encrypt email
            ICrypt crypt = new SimpleCrypt();
            Email = crypt.Encrypt(Email);
            
            return Membership.GetUserNameByEmail(Email);
        }


        public bool Exists(string Email)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentException("Argument cannot be null, empty or whitespace", "Email");
            }

            string username = Membership.GetUserNameByEmail(Email);
            return (!string.IsNullOrWhiteSpace(username));
        }


        public bool CreateUser(string Email)
        {
            // Validate input
            if (string.IsNullOrEmpty(Email))
            {
                throw new ArgumentException("Argument cannot be null or empty", "Email");
            }
            Email = Email.Trim();


            // Generate a password
            IPasswordGenerator passwordGenerator = new SimplePasswordGenerator();
            string password = passwordGenerator.Generate(7);

            // Encrypt information
            ICrypt crypt = new SimpleCrypt();
            Email = crypt.Encrypt(Email);
            password = crypt.Encrypt(password);

            MembershipUser user = Membership.CreateUser(
                Email,
                password);

            return (user != null);
        }

        #endregion
    }
}
