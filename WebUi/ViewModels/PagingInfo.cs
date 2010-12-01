using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUi.ViewModels
{
    public class PagingInfo
    {
        public string listTitle { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentSortOption { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }

        public int ItemsPerPage 
        {
            get
            {
                return Convert.ToInt32(
                System.Web.Configuration.WebConfigurationManager.AppSettings["ListItemsPerPage"]);
            }
        }
    }
}