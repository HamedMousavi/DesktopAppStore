using System;




namespace DomainModel.Security
{
    public class InputController
    {
        public static int MaxInputLen = 256;


        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return true;
            else if (input.Length > MaxInputLen) return false;
            /*else if (input.Contains()) return false;*/

            return true;
        }

        public static bool IsValidEmail(string Email)
        {
            // UNDONE: ENFORCE EMAIL VALIDATIONS
            if (string.IsNullOrWhiteSpace(Email)) return false;

            return true;
        }

        public static object SafeText(object p)
        {
            throw new NotImplementedException();
        }
    }
}
