using System;



namespace DomainModel.Abstract
{
    public interface IPasswordGenerator
    {
        string Generate(int len);
    }
}
