using System;
using DomainModel.Abstract;



namespace DomainModel.Security
{
    public class SimpleCrypt : ICrypt
    {
        #region ICrypt Members

        public string Encrypt(string rawStr)
        {
            // UNDONE: ENCRYPT
            return rawStr;
        }

        public string Decrypt(string cipherStr)
        {
            // UNDONE: DECRYPT
            return cipherStr;
        }

        #endregion
    }
}
