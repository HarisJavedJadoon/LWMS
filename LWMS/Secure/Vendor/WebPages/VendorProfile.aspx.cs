using LWMS.DBContext;
using LWMS.Models;
using LWMS.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace LWMS.Secure.Vendor.WebPages
{
    public partial class VendorProfile : System.Web.UI.Page
    {
        #region Properties

        private Models.Vendor SelectedObject
        {
            get { return (Models.Vendor)ViewState["SelectedObject"]; }
            set { ViewState["SelectedObject"] = value; }
        }
        #endregion

        #region Control's Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null && Request.QueryString["Id"].ToString() != string.Empty)
                {
                    Models.Vendor objVendor
                        = VendorDAL.VendorSelect(new Models.Vendor() { ID = Convert.ToInt32(Request.QueryString["Id"].ToString()) });

                    if (objVendor != null)
                    {
                        fillForm(objVendor);
                    }
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Models.Vendor objVendor = new Models.Vendor();
            objVendor.Name = txtName.Text.Trim();
            objVendor.Group.ID = 2;
            objVendor.Email = txtEmail.Text.Trim();
            objVendor.Password = txtPassword.Text.Trim();
            objVendor.MobileNo = txtMobileNo.Text.Trim();
            objVendor.CNICNo = txtCNICNo.Text.Trim();
            objVendor.Landline = txtLandline.Text.Trim();
            objVendor.SalesTaxNo = txtSalesTaxNo.Text.Trim();

            objVendor.NTNNo = txtNTNNo.Text.Trim();
            objVendor.Description = txtDescription.Text.Trim();

            objVendor.OfficeAddress = txtOfficeAddress.Text;
            objVendor.Status = "A";
            if (SelectedObject != null)
            {
                string Ext = Path.GetExtension(fupImage.PostedFile.FileName);
                if ((Ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)) || (Ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                   || (Ext.Equals(".gif", StringComparison.OrdinalIgnoreCase)) || (Ext.Equals(".png", StringComparison.OrdinalIgnoreCase))
                   || (Ext.Equals(".bmp", StringComparison.OrdinalIgnoreCase)))
                {
                    string[] strNames = fupImage.FileName.Split('.');
                    string strFileName = Guid.NewGuid().ToString() + "." + strNames.Last();

                    string path = Server.MapPath("../../../WebsiteResources/Images/");
                    fupImage.SaveAs(path + strFileName);
                    objVendor.LogoUrl = "../../../WebsiteResources/Images/" + strFileName;
                }
                else
                {
                    if (SelectedObject == null)
                    {
                        objVendor.LogoUrl = hfvImageURL.Value;
                    }
                    else
                        return;
                }
            }
            else
            {
                if (SelectedObject == null)
                {
                    objVendor.LogoUrl = hfvImageURL.Value;
                }
                else
                    return;
            }
            if (SelectedObject != null)
            {
                objVendor.ID = SelectedObject.ID;
                objVendor.KeepTrack.LastModifiedBy = ApplicationConfig.CurrentVendor.Name;
                long result = VendorDAL.ModifyVendor(objVendor, DataOperation.Update);
                divMessages.InnerHtml = CommonMethods.ShowNotification("Updated Successfully", MessageOption.Success);
                //clearControls();
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        #endregion

        #region Utility Methods

        private void clearControls()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtCNICNo.Text = string.Empty;
            txtLandline.Text = string.Empty;
            txtSalesTaxNo.Text = string.Empty;
            txtNTNNo.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtOfficeAddress.Text = string.Empty;
            hfvImageURL.Value = string.Empty;
            imgpatient.Visible = false;
            imgpatient.Src = string.Empty;
        }
        private void fillForm(Models.Vendor objVendor)
        {
            SelectedObject = objVendor;

            txtName.Text = SelectedObject.Name;
            txtEmail.Text = SelectedObject.Email;
            txtPassword.Text = SelectedObject.Password;
            txtMobileNo.Text = SelectedObject.MobileNo;
            txtCNICNo.Text = SelectedObject.CNICNo;
            txtLandline.Text = SelectedObject.Landline;
            txtSalesTaxNo.Text = SelectedObject.SalesTaxNo;
            txtNTNNo.Text = SelectedObject.NTNNo;
            txtDescription.Text = SelectedObject.Description;
            txtOfficeAddress.Text = SelectedObject.OfficeAddress;
            if (SelectedObject.LogoUrl==null)
            {
                imgpatient.Src = "~/Assets/Vendor/images/users/test.jpg";
                hfvImageURL.Value = "~/Assets/Vendor/images/users/test.jpg";
            }
            else
            {
                hfvImageURL.Value = SelectedObject.LogoUrl;
                imgpatient.Src = SelectedObject.LogoUrl;

            }
            



            #endregion


        }
    }
}