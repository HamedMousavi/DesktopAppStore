using System;
using System.Configuration;



namespace DomainModel.Repository.Memory
{
    public static class Configurations
    {
        public static string MinMessageFetchInterval = ConfigurationManager.AppSettings["MinMessageFetchInterval"];
    }
}
