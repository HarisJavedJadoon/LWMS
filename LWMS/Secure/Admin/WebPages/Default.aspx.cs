using LWMS.DBContext;
using LWMS.Models;
using LWMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LWMS.Secure.Admin.WebPages
{
    public partial class Default : System.Web.UI.Page
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
            lsvMain.DataSource = VendorDAL.VendorsSelectDynamic("IsDeleted = 'False' AND Status = 'A'", "ID");
            lsvMain.DataBind();
        }
        private void commandActions(int id, string actionOption)
        {
            Models.Vendor objVendor
                = LWMS.DBContext.VendorDAL.VendorSelect(new Models.Vendor() { ID = id });
            if (objVendor != null)
                switch (actionOption)
                {
                    case "EditRecord":
                        Response.Redirect("VendorExperiences.aspx?Id=" + id);
                        break;
                    case "DeleteRecord":
                        deleteRecord(objVendor);
                        break;
                    case "ChangeStatus":
                        changeStatus(objVendor);
                        break;
                }
        }
        private void changeStatus(Models.Vendor objVendor)
        {
            if (objVendor.Status.ToString() == "A")
                SQLHelper.DynamicQuery("Update [Vendor] Set Status = 'I', LastModifiedBy = '" + ApplicationConfig.CurrentUser.UserName + "', LastModifiedDate = GetDate() Where ID = '" + objVendor.ID + "'");
            else
                SQLHelper.DynamicQuery("Update [Vendor] Set Status = 'A', LastModifiedBy = '" + ApplicationConfig.CurrentUser.UserName + "', LastModifiedDate = GetDate() Where ID = '" + objVendor.ID + "'");
            divMessages.InnerHtml = CommonMethods.ShowNotification("Updated Successfully", MessageOption.Success);
            bindMainList();
        }
        private void deleteRecord(Models.Vendor objVendor)
        {
            objVendor.IsDeleted = true;
            objVendor.KeepTrack.LastModifiedBy = ApplicationConfig.CurrentVendor.Name;

            long result =
                VendorDAL.ModifyVendor(objVendor, DataOperation.Delete);
            divMessages.InnerHtml = CommonMethods.ShowNotification("Deleted Successfully", MessageOption.Success);
            bindMainList();
        }

        #endregion
    }
}