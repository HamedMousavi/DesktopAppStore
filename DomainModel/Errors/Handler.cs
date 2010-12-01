using System;



namespace DomainModel.Errors
{
    public static class Handler
    {
        private static bool handling;
        private static object instLock = new object();



        public static void HandleException(System.Web.Mvc.ControllerBase controller, System.Web.HttpContextBase context, string culture, Exception exception)
        {
            try
            {
                lock (instLock)
                {
                    if (handling) return;
                    handling = true;
                }

                //System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();

                DomainModel.Errors.Logger.LogException(
                    null,
                    culture,
                    context.Request.UserHostAddress,
                    context.Request.Url.AbsoluteUri,
                    exception
                    );

            }
            catch (Exception)
            {
                // No more error handling
            }

            lock (instLock)
            {
                handling = false;
            }
        }




        public static void HandleException(Exception ex)
        {
            try
            {
                // Most probably a critical error
                DomainModel.Errors.Logger.LogException(ex);
            }
            catch (Exception)
            {
                // No more error handling
            }
        }

        public static void HandleError(string p)
        {
            throw new NotImplementedException();
        }
    }
}
