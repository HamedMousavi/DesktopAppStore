using System;
using System.Web.Mvc;



namespace WebUi.ViewPages
{
    public class BaseViewPage<T> : ViewPage<T> where T : class
    {
        protected override void InitializeCulture()
        {
            base.InitializeCulture();

            string cuture = WebUi.Models.AppCulture.CurrentCulture.CultureId;
            
            this.Culture = cuture;
            this.UICulture = cuture;

        }
    }
}