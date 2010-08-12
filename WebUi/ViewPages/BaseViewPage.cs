using System;
using System.Web.Mvc;



namespace WebUi.ViewPages
{
    public class BaseViewPage<T> : ViewPage<T> where T : class
    {
        protected override void InitializeCulture()
        {
            string cuture = WebUi.Models.AppCulture.CurrentCulture.Culture;
            
            this.Culture = cuture;
            this.UICulture = cuture;

            base.InitializeCulture();
        }
    }
}