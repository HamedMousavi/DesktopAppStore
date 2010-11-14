using System;



namespace DomainModel.Repository.Sql
{
    public class Errors
    {
        internal static void Insert(string userName, string culture, string remoteIp, string url, string details)
        {
            System.Diagnostics.Debug.WriteLine("-------------------------------------------------------");
            System.Diagnostics.Debug.WriteLine(
                string.Format("Exception: [{0}] [{1}] [{2}] [{3}] \r\nDetails:{4}",
                userName, culture, remoteIp, url, details));
            System.Diagnostics.Debug.WriteLine("-------------------------------------------------------");
            
            throw new NotImplementedException();
        }
    }
}
