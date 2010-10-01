using System;
using System.Collections.Generic;
using System.Configuration;



namespace DomainModel.Repository.Sql
{
    public class Configurations
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
    }
}
