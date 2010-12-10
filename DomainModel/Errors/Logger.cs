using System;



namespace DomainModel.Errors
{
    public class Logger
    {


        public static void LogException(Exception exception)
        {
            LogException(null, null, null, null, exception);
        }


        internal static void LogException(string userName, string culture, string remoteIp, string url, Exception exception)
        {
            try
            {
                Repository.Sql.Errors.Insert(userName, culture, remoteIp, url, exception.ToString());
            }
            catch (Exception ex)
            {
                try
                {
                    Repository.Disk.Errors.Insert(userName, culture, remoteIp, url, exception.ToString());
                    Repository.Disk.Errors.Insert(userName, culture, remoteIp, url, ex.ToString());
                }
                catch (Exception ex2)
                {
                    // WHAT NOW?
                    System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex2));
                }
            }
        }
    }
}
