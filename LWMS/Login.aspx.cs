using LWMS.DBContext;
using LWMS.Models;
using LWMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LWMS
{
    public partial class Login : System.Web.UI.Page
    {
        #region Properties

        #endregion

        #region Control's Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            List<Vendor> Vendors
                  = VendorDAL.VendorsSelectDynamic("Email ='" + txtEmail.Text + "' AND IsDeleted = 'False'", "ID");
            if (Vendors != null && Vendors.Count > 0)
            {
                if (Vendors.FirstOrDefault().Status.Trim() == "I")
                {
                    divMessages.InnerHtml = CommonMethods.ShowNotification("Vendor is Inactive", MessageOption.Error);
                    return;
                }
                if (Vendors.FirstOrDefault().Password == txtPassword.Text.Trim())
                {
                    ApplicationConfig.CurrentVendor = Vendors.FirstOrDefault();
                    ApplicationConfig.CurrentVendor.Group
                        = GroupDAL.GroupSelect(ApplicationConfig.CurrentVendor.Group);

                    LoginVendor();
                    
                }
                else
                {
                    divMessages.InnerHtml = CommonMethods.ShowNotification("Email or Password is Incorrect.", MessageOption.Error);
                }
            }
            else
            {
                divMessages.InnerHtml = CommonMethods.ShowNotification("Email or Password is Incorrect.", MessageOption.Error);
            }
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        

        #endregion

        #region Utility Methods

        private void LoginVendor()
        {
            if (ApplicationConfig.CurrentVendor != null)
            {
                redirectToDashboard(ApplicationConfig.CurrentVendor);
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Login.aspx");
            }

        }
        private void redirectToDashboard(Vendor objVendor)
        {
            if (objVendor.Group.ID == 2)
            {
                Response.Redirect("~/Secure/Vendor/WebPages/Default.aspx");
            }

        }

        #endregion
    }
}