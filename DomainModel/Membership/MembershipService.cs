using System;
using DomainModel.Abstract;
using DomainModel.Security;



namespace DomainModel.Membership
{
    public class MembershipService
    {
        public static DomainModel.Membership.User ValidateUser(string Email, string Password)
        {
            // Validate input
            if (String.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Value cannot be null or empty.", "username");
            if (String.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            // Remove unused space
            Email = Email.Trim();
            Password = Password.Trim();

            // Encrypt information
            ICrypt crypt = new DomainModel.Security.SimpleCrypt();
            Email = crypt.Encrypt(Email);
            Password = crypt.Encrypt(Password);

            User user = Repository.Memory.Users.Instance.Authenticate(Email, Password);

            return user;
        }


        public static void SignIn(DomainModel.Membership.User user, bool isCookiePersistent)
        {
            if (user == null) throw new ArgumentException("Value cannot be null or empty.", "user");

            SetFormsCookie(user, isCookiePersistent);
        }


        public static void SignOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();
        }


        public static bool Exists(string Email)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentException("Argument cannot be null, empty or whitespace", "Email");
            }

            return DomainModel.Repository.Sql.Users.Exists(Email);
        }


        public static bool CreateUser(string Email, string culture)
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

            return DomainModel.Repository.Sql.Users.Create(Email, password, culture);
        }


        private static void SetFormsCookie(User user, bool isCookiePersistent)
        {
            // Create the authentication ticket
            System.Web.Security.FormsAuthenticationTicket authTicket = new
                System.Web.Security.FormsAuthenticationTicket(1,
                                            user.EmailAddress,  // Currently name = email address
                                            DateTime.UtcNow,
                                            DateTime.UtcNow.AddYears(1), //UNDONE: HOW LONG SHALL THIS BE VALID?
                                            isCookiePersistent,
                                            user.Index.ToString() + "|" + user.Id.ToString());

            // Now encrypt the ticket.
            string encryptedTicket = System.Web.Security.FormsAuthentication.Encrypt(authTicket);

            // Create a cookie and add the encrypted ticket to the 
            // cookie as data.
            System.Web.HttpCookie authCookie =
                        new System.Web.HttpCookie(
                                System.Web.Security.FormsAuthentication.FormsCookieName,
                                encryptedTicket);


            // Add the cookie to the outgoing cookies collection. 
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
        }


        public static void AuthenticateRequest(System.Web.HttpContext context, System.Web.HttpRequest request)
        {
            try
            {
                System.Web.HttpCookie authCookie = context.Request.Cookies[
                    System.Web.Security.FormsAuthentication.FormsCookieName];
                
                if (authCookie != null)
                {
                    System.Web.Security.FormsAuthenticationTicket authTicket = 
                        System.Web.Security.FormsAuthentication.Decrypt(authCookie.Value);
                    
                    // Extract data, find authenticated user and attach it to context
                    string[] userInfo = authTicket.UserData.Split('|');
                    if (userInfo.Length == 2)
                    {
                        int index = Convert.ToInt32(userInfo[0]);
                        Membership.User user = Repository.Memory.Users.Instance.GetUser(index);
                        if (user != null && user.Id > 0 && Convert.ToInt32(userInfo[1]) == user.Id)
                        {
                            if (user.Principal == null)
                            {
                                user.Principal = new SarvsoftPrincipal(authTicket, user);
                            }
                            else
                            {
                                user.Principal.SetTicket(authTicket);
                            }

                            context.User = user.Principal;
                            System.Threading.Thread.CurrentPrincipal = user.Principal;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex.ToString()));
            }
        }
    
    }
}
