using System;
using System.Reflection;
using System.Resources;



namespace WebUi.Models
{
    public static class DynamicResources
    {
        private static Assembly res = Assembly.Load("UiResources");
        private static ResourceManager resMon = new ResourceManager("UiResources.UiTexts", res);

        public static string GetText(string resourceName)
        {
            return resMon.GetObject(resourceName) as string;
        }
    }
}