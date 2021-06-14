using LWMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LWMS.Secure.Vendor.Office
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (ApplicationConfig.CurrentVendor == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    lblUserName.Text = ApplicationConfig.CurrentVendor.Name;
                    lblEmail.Text = ApplicationConfig.CurrentVendor.Email;
                    if (ApplicationConfig.CurrentVendor.LogoUrl==null)
                    {
                        imgVendor.Src = "~/Assets/Vendor/images/users/test.jpg";
                        imgVendorMin.Src = "~/Assets/Vendor/images/users/test.jpg";
                    }
                    else
                    {
                        imgVendor.Src = ApplicationConfig.CurrentVendor.LogoUrl;
                        imgVendorMin.Src = ApplicationConfig.CurrentVendor.LogoUrl;
                    }                  

                }
            }
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            ApplicationConfig.CurrentVendor = null;
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
        #region Profile
        protected void lnkViewProfile_Click(object sender, EventArgs e)
        {
            hfId.Value = ApplicationConfig.CurrentVendor.ID.ToString();
            Response.Redirect("../WebPages/VendorProfile.aspx?Id=" + hfId.Value);
        }
        #endregion



        protected void lnkVendorExperience_Click(object sender, EventArgs e)
        { Response.Redirect("../WebPages/VendorExperiencesList.aspx"); }


    }
}