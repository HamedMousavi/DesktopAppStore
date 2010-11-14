using System;
using System.Collections.Generic;
using System.Configuration;



namespace DomainModel.Repository.Disk
{
    public class Configurations
    {
        public static string ProductResDirBase = ConfigurationManager.AppSettings["ProductResourcesDirPath"];
    }
}
