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
            List<User> users
                  = UserDAL.UsersSelectDynamic("Email ='" + txtEmail.Text + "' AND IsDeleted = 'False'", "ID");
            if (users != null && users.Count > 0)
            {
                if (users.FirstOrDefault().Status.Trim() == "I")
                {
                    divMessages.InnerHtml = CommonMethods.ShowNotification("User is Inactive", MessageOption.Error);
                    return;
                }
                if (users.FirstOrDefault().Password == txtPassword.Text.Trim())
                {
                    ApplicationConfig.CurrentUser = users.FirstOrDefault();
                    ApplicationConfig.CurrentUser.Group
                        = GroupDAL.GroupSelect(ApplicationConfig.CurrentUser.Group);

                    LoginUser();
                    
                }
                else
                {
                    divMessages.InnerHtml = CommonMethods.ShowNotification("Username or Password is Incorrect.", MessageOption.Error);
                }
            }
            else
            {
                divMessages.InnerHtml = CommonMethods.ShowNotification("Username or Password is Incorrect.", MessageOption.Error);
            }
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        

        #endregion

        #region Utility Methods

        private void LoginUser()
        {
            if (ApplicationConfig.CurrentUser != null)
            {
                redirectToDashboard(ApplicationConfig.CurrentUser);
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Login.aspx");
            }

        }
        private void redirectToDashboard(User objUser)
        {
            if (objUser.Group.ID == 2)
            {
                Response.Redirect("~/Secure/Vendor/WebPages/Default.aspx");
            }

        }

        #endregion
    }
}