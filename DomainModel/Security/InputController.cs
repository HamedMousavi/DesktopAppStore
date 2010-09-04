using System;




namespace DomainModel.Security
{
    public class InputController
    {
        public static bool IsValid(string input)
        {
            // UNDONE: Check input
            return true;
        }

        public static bool IsValidEmail(string Email)
        {
            // UNDONE: ENFORCE EMAIL VALIDATIONS
            if (string.IsNullOrWhiteSpace(Email)) return false;

            return true;
        }
    }
}
