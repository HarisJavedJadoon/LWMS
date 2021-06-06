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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                List<User> objUsers
                       = UserDAL.UsersSelectDynamic("IsDeleted = 'False' AND Email = '" + txtEmail.Text.Trim() + "'", "");

                if (objUsers != null)
                {
                    divMessages.InnerHtml = CommonMethods.ShowNotification("Email already registered, Please contact system administrator for further information", MessageOption.Error);
                    return;
                }

                User objUser = new User();
                objUser.Name = txtName.Text.Trim();
                objUser.Email = txtEmail.Text.Trim();
                objUser.Password = txtPassword.Text.Trim();
                objUser.Group.ID = 2;
                objUser.Status = "A";
                objUser.KeepTrack.CreatedBy = "Online User";
                objUser.ID = UserDAL.ModifyUser(objUser, DataOperation.Insert);
                divMessages.InnerHtml = CommonMethods.ShowNotification("Register Successfully,Please Login", MessageOption.Success);

                txtName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
            }
            catch (Exception ex)
            {

                divMessages.InnerHtml = CommonMethods.ShowNotification(ex.Message, MessageOption.Error);
            }


        }

    }
}