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
                List<Vendor> objVendors
                       = VendorDAL.VendorsSelectDynamic("IsDeleted = 'False' AND Email = '" + txtEmail.Text.Trim() + "'", "");

                if (objVendors != null)
                {
                    divMessages.InnerHtml = CommonMethods.ShowNotification("Email already registered, Please contact system administrator for further information", MessageOption.Error);
                    return;
                }

                Vendor objVendor = new Vendor();
                objVendor.Name = txtName.Text.Trim();
                objVendor.Email = txtEmail.Text.Trim();
                objVendor.MobileNo = txtMobileNo.Text.Trim();
                objVendor.Password = txtPassword.Text.Trim();
                objVendor.Group.ID = 2;
                objVendor.Status = "A";
                objVendor.KeepTrack.CreatedBy = "Online Vendor";
                objVendor.ID = VendorDAL.ModifyVendor(objVendor, DataOperation.Insert);
                divMessages.InnerHtml = CommonMethods.ShowNotification("Register Successfully,Please Login", MessageOption.Success);

                txtName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
            }
            catch (Exception ex)
            {

                divMessages.InnerHtml = CommonMethods.ShowNotification(ex.Message, MessageOption.Error);
            }


        }

    }
}