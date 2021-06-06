using LWMS.DBContext;
using LWMS.Models;
using LWMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LWMS.Secure.Admin
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
                if (!Request.IsLocal)
                    this.txtUserName.Focus();
                else
                {
                    txtUserName.Text = "admin";
                    txtPassword.TextMode = TextBoxMode.SingleLine;
                    txtPassword.Text = "admin@123";
                }
                this.txtUserName.Focus();
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            List<User> users
                  = UserDAL.UsersSelectDynamic("UserName ='" + txtUserName.Text + "' AND IsDeleted = 'False'", "ID");
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
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
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
                Response.Redirect("~/Secure/Admin/Login.aspx");
            }

        }
        private void redirectToDashboard(User objUser)
        {
            Response.Redirect("~/Secure/Admin/WebPages/Default.aspx");
        }

        #endregion
    }
}