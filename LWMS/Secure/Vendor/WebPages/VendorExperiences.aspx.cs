using LWMS.DBContext;
using LWMS.Models;
using LWMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LWMS.Secure.Vendor.WebPages
{
    public partial class VendorExperiences : System.Web.UI.Page
    {
        #region Properties

        private VendorExperience SelectedObject
        {
            get { return (VendorExperience)ViewState["SelectedObject"]; }
            set { ViewState["SelectedObject"] = value; }
        }

        #endregion

        #region Control's Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonMethods.BindVendors(ddlVendor);
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    VendorExperience objVendorExperience
                        = VendorExperienceDAL.VendorExperienceSelect(new VendorExperience() { ID = Convert.ToInt32(Request.QueryString["Id"].ToString()) });
                    if (objVendorExperience != null)
                        fillForm(objVendorExperience);
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            VendorExperience objVendorExperience = new VendorExperience();
            objVendorExperience.Vendor.ID = Convert.ToInt32(ddlVendor.SelectedValue);
            objVendorExperience.CompanyName = txtCompanyName.Text.Trim();
            objVendorExperience.CompanyType = ddlCompanyType.SelectedValue;
            objVendorExperience.Description = txtDescription.Text.Trim();
            objVendorExperience.CompanyAddress = txtCompanyAddress.Text.Trim();
            objVendorExperience.CompanyContactNumber = txtCompanyContactNumber.Text.Trim();
            objVendorExperience.TenderAmount = txtTenderAmount.Text.Trim();
            if (objVendorExperience.DateFrom != DateTime.MinValue)
                objVendorExperience.DateFrom = Convert.ToDateTime(txtFromDate.Text.Trim());
            if (objVendorExperience.DateTo != DateTime.MinValue)
                objVendorExperience.DateTo = Convert.ToDateTime(txtToDate.Text.Trim());
            objVendorExperience.Status = ddlStatus.SelectedValue;

            if (SelectedObject != null)
            {
                objVendorExperience.ID = SelectedObject.ID;
                objVendorExperience.KeepTrack.LastModifiedBy = ApplicationConfig.CurrentVendor.Name;
                long result = VendorExperienceDAL.ModifyVendorExperience(objVendorExperience, DataOperation.Update);
                divMessages.InnerHtml = CommonMethods.ShowNotification("Updated Successfully", MessageOption.Success);
            }
            else
            {
                objVendorExperience.KeepTrack.CreatedBy = ApplicationConfig.CurrentVendor.Name;
                objVendorExperience.ID = VendorExperienceDAL.ModifyVendorExperience(objVendorExperience, DataOperation.Insert);
                divMessages.InnerHtml = CommonMethods.ShowNotification("Saved Successfully", MessageOption.Success);
            }
            clearControls();

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearControls();
        }
        #endregion

        #region Utility Methods

        private void clearControls()
        {
            ddlVendor.SelectedValue = "0";
            ddlCompanyType.SelectedValue = "0";
            txtCompanyName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtCompanyAddress.Text = string.Empty;
            txtCompanyContactNumber.Text = string.Empty;
            txtTenderAmount.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            ddlStatus.SelectedValue = "A";
            SelectedObject = null;
        }

        private void fillForm(VendorExperience objVendorExperience)
        {
            SelectedObject = objVendorExperience;

            ddlVendor.SelectedValue = SelectedObject.Vendor.ID.ToString();
            ddlCompanyType.SelectedValue = SelectedObject.CompanyType.ToString();
            txtCompanyName.Text = SelectedObject.CompanyName.ToString();
            txtDescription.Text = SelectedObject.Description.ToString(); ;
            txtCompanyAddress.Text = SelectedObject.CompanyAddress.ToString();
            txtCompanyContactNumber.Text = SelectedObject.CompanyContactNumber.ToString();
            txtTenderAmount.Text = SelectedObject.TenderAmount.ToString();
            if (SelectedObject.DateFrom != DateTime.MinValue)
                txtFromDate.Text = SelectedObject.DateFrom.ToString("dd/MM/yyyy");
            if (SelectedObject.DateTo != DateTime.MinValue)
                txtToDate.Text = SelectedObject.DateTo.ToString("dd/MM/yyyy");
            ddlStatus.SelectedValue = SelectedObject.Status.ToString();
        }

        #endregion
    }
}