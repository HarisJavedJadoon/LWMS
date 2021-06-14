using LWMS.DBContext;
using LWMS.Models;
using LWMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LWMS.Secure.Vendor.WebPages
{
    public partial class VendorExperiencesList : System.Web.UI.Page
    {
        #region Properties

        #endregion

        #region Control's Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindMainList();
            }
        }

        protected void lsvMain_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                commandActions(Convert.ToInt32(e.CommandArgument), e.CommandName);
            }
        }

        #endregion

        #region Utility Methods

        private void bindMainList()
        {
            //if (!string.IsNullOrEmpty(txtDateRange.Text))
            //{
            //    strWhereCondition += " AND VendorExperience.ClinicDate >= '" + CommonMethods.ConvertToDateTimeRange(txtDateRange.Text.Split('-').First().Trim()).ToString("MM/dd/yyyy") + " 12:00 AM' ";
            //    strWhereCondition += " AND VendorExperience.ClinicDate <= '" + CommonMethods.ConvertToDateTimeRange(txtDateRange.Text.Split('-').Last().Trim()).ToString("MM/dd/yyyy") + " 11:49 PM' ";
            //}
            lsvMain.DataSource = VendorExperienceDAL.VendorExperiencesSelectDynamic("IsDeleted = 'False' AND Status = 'A' AND VendorID ='" + ApplicationConfig.CurrentVendor.ID + "'", "ID");
            lsvMain.DataBind();
        }
        private void commandActions(int id, string actionOption)
        {
            VendorExperience objVendorExperience
                = VendorExperienceDAL.VendorExperienceSelect(new VendorExperience() { ID = id });
            if (objVendorExperience != null)
                switch (actionOption)
                {
                    case "EditRecord":
                        Response.Redirect("VendorExperiences.aspx?Id=" + id);
                        break;
                    case "DeleteRecord":
                        deleteRecord(objVendorExperience);
                        break;
                    case "ChangeStatus":
                        changeStatus(objVendorExperience);
                        break;
                }
        }
        private void changeStatus(VendorExperience objVendorExperience)
        {
            if (objVendorExperience.Status.ToString() == "A")
                SQLHelper.DynamicQuery("Update [VendorExperience] Set Status = 'I', LastModifiedBy = '" + ApplicationConfig.CurrentUser.UserName + "', LastModifiedDate = GetDate() Where ID = '" + objVendorExperience.ID + "'");
            else
                SQLHelper.DynamicQuery("Update [VendorExperience] Set Status = 'A', LastModifiedBy = '" + ApplicationConfig.CurrentUser.UserName + "', LastModifiedDate = GetDate() Where ID = '" + objVendorExperience.ID + "'");
            divMessages.InnerHtml = CommonMethods.ShowNotification("Updated Successfully", MessageOption.Success);
            bindMainList();
        }
        private void deleteRecord(VendorExperience objVendorExperience)
        {
            objVendorExperience.IsDeleted = true;
            objVendorExperience.KeepTrack.LastModifiedBy = ApplicationConfig.CurrentVendor.Name;

            long result =
                VendorExperienceDAL.ModifyVendorExperience(objVendorExperience, DataOperation.Delete);
            divMessages.InnerHtml = CommonMethods.ShowNotification("Deleted Successfully", MessageOption.Success);
            bindMainList();
        }

        #endregion
    }
}