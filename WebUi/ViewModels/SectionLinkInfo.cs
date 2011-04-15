using System.Web.Routing;

namespace WebUi.ViewModels
{
    public class SectionLinkInfo
    {

        public SectionLinkInfo(string controller, string action, string text, string section)
        {
            this.Controller = controller;
            this.Action = action;
            this.Text = text;
            this.SectionName = section;
        }


        public SectionLinkInfo(string controller, string action, object routeValues, string text, string section)
        {
            this.Controller = controller;
            this.Action = action;
            this.Text = text;
            this.SectionName = section;
            this.RouteValues = routeValues;
        }


        public string Controller { get; set; }
        public string Action { get; set; }
        public object RouteValues { get; set; }

        public bool IsSelected { get; set; }

        public string Text { get; set; }
        public string SectionName { get; set; }
    }
}