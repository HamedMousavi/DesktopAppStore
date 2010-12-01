using System;
using System.Configuration;



namespace DomainModel.Repository.Memory
{
    public static class Configurations
    {
        public static string MinMessageFetchInterval = ConfigurationManager.AppSettings["MinMessageFetchInterval"];
        public static Int32 MinCategoryFetchInterval = Convert.ToInt32( ConfigurationManager.AppSettings["MinCategoryFetchInterval"]);
    }
}
