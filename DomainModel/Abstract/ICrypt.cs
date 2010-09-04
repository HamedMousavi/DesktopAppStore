using System;



namespace DomainModel.Abstract
{
    public interface ICrypt
    {
        string Encrypt(string rawStr);
        string Decrypt(string cipherStr);
    }
}
