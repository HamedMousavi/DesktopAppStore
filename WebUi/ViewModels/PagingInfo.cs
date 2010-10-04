using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUi.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }

        public int ItemsPerPage 
        {
            get
            {
                // UNDONE: CONFIGURATION
                return 10;
            }
        }
    }
}