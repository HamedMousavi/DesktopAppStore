using System;
using DomainModel.Abstract;
using System.Web.Security;
using System.Web;



namespace DomainModel.Security
{
    public class MembershipService : IMembership
    {
        protected SarvsoftUser user;

        
        public MembershipService()
        {
            this.user = new SarvsoftUser();
        }


        private void SetFormsCookie(bool IsCookiePersistent)
        {
            // Create the authentication ticket
            FormsAuthenticationTicket authTicket = new 
                FormsAuthenticationTicket(1,
                                            user.Name,  // Currently = email address
                                            DateTime.UtcNow,
                                            DateTime.UtcNow.AddYears(1), //UNDONE: HOW LONG SHALL THIS BE VALID?
                                            IsCookiePersistent,
                                            this.user.Id.ToString());

            // Now encrypt the ticket.
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            // Create a cookie and add the encrypted ticket to the 
            // cookie as data.
            HttpCookie authCookie =
                        new HttpCookie(FormsAuthentication.FormsCookieName,
                                        encryptedTicket);
							  

            // Add the cookie to the outgoing cookies collection. 
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }


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

            this.user.EmailAddress = Email;
            this.user.Password = Password;

            // Retrieve user from persist
            DomainModel.Repository.Sql.Users.AuthenticateAndLoad(this.user);

            // Verify user existance
            return (this.user.Id > 0);
        }


        public void SignIn(string Email, bool CreatePersistentCookie)
        {
            if (String.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            if (string.Compare(this.user.EmailAddress, Email) == 0 && this.user.Id > 0)
            {
                SetFormsCookie(CreatePersistentCookie);
            }
        }


        public void SignOut()
        {
            FormsAuthentication.SignOut();
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
