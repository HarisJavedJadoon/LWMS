using LWMS.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace LWMS.Utils
{
    public class CommonMethods
    {
        public static String EncryptPassword(String pwd)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "SHA1");

        }
        public static string ShowNotification(string message, MessageOption option)
        {
            switch (option)
            {
                case MessageOption.Warning:
                    return @"<div class='alert alert-warning alert-dismissible'>
                                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>
                              <i class='icon fa fa-warning'></i>
                            " + message + "</div>";
                case MessageOption.Info:
                    return @"<div class='alert alert-info alert-dismissible'>
                                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>
                              <i class='icon fa fa-info'></i>
                            " + message + "</div>";
                case MessageOption.Success:
                    return @"<div class='alert alert-success alert-dismissible'>
                                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>
                              <i class='icon fa fa-check'></i>
                            " + message + "</div>";
                case MessageOption.Error:
                    return @"<div class='alert alert-danger alert-dismissible'>
                                <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>
                              <i class='icon fa fa-ban'></i>
                            " + message + "</div>";
                default:
                    return "";
            }
        }


        public static void BindVendors(DropDownList ddlVendor, string initialString = "")
        {
            ddlVendor.DataSource = VendorDAL.VendorsSelectDynamic("IsDeleted = 'False' AND Status = 'A'  ", "Name");
            ddlVendor.DataTextField = "Name";
            ddlVendor.DataValueField = "ID";
            ddlVendor.DataBind();
            if (!string.IsNullOrEmpty(initialString))
                ddlVendor.Items.Insert(0, new ListItem(initialString, "0"));
            else
                ddlVendor.Items.Insert(0, new ListItem("Please Select", "0"));
        }
        

    }
}