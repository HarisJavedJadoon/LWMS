using LWMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LWMS.Utils
{
    public  class ApplicationConfig
    {
        public static Vendor CurrentVendor
        {
            get { return (Vendor)HttpContext.Current.Session["CurrentVendor"]; }
            set { HttpContext.Current.Session["CurrentVendor"] = value; }

        }
        public static User CurrentUser
        {
            get { return (User)HttpContext.Current.Session["CurrentUser"]; }
            set { HttpContext.Current.Session["CurrentUser"] = value; }

        }
    }
}