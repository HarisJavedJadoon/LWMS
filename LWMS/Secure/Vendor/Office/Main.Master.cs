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

            if (ApplicationConfig.CurrentUser == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                lblUserName.Text = ApplicationConfig.CurrentUser.Name;
                lblEmail.Text = ApplicationConfig.CurrentUser.Email;
            }
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            ApplicationConfig.CurrentUser = null;
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}