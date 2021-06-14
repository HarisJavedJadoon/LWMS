using LWMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LWMS.DBContext
{
    public static class VendorExperienceDAL
    {
        #region DML Methods

        public static int ModifyVendorExperience(VendorExperience objVendorExperience, DataOperation action)
        {
            int result = 0;
            switch (action)
            {
                case DataOperation.Insert:
                    result = VendorExperienceInsert(objVendorExperience);
                    break;
                case DataOperation.Update:
                    result = VendorExperienceUpdate(objVendorExperience);
                    break;
                case DataOperation.Delete:
                    result = VendorExperienceDelete(objVendorExperience);
                    break;
            }
            return result;
        }
        private static SqlParameter[] GetVendorExperienceParameters(VendorExperience objVendorExperience, DataOperation action)
        {
            SqlParameter[] prms = new SqlParameter[14];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objVendorExperience.ID);
            if (action == DataOperation.Insert) prms[0].Direction = ParameterDirection.Output;
            prms[1] = SQLHelper.CreateParameter("VendorID", SqlDbType.Int, objVendorExperience.Vendor.ID);
            prms[2] = SQLHelper.CreateParameter("CompanyName", SqlDbType.NVarChar, objVendorExperience.CompanyName);
            prms[3] = SQLHelper.CreateParameter("CompanyType", SqlDbType.NVarChar, objVendorExperience.CompanyType);
            prms[4] = SQLHelper.CreateParameter("Description", SqlDbType.NVarChar, objVendorExperience.Description);
            prms[5] = SQLHelper.CreateParameter("CompanyAddress", SqlDbType.NVarChar, objVendorExperience.CompanyAddress);
            prms[6] = SQLHelper.CreateParameter("CompanyContactNumber", SqlDbType.NVarChar, objVendorExperience.CompanyContactNumber);
            prms[7] = SQLHelper.CreateParameter("TenderAmount", SqlDbType.NVarChar, objVendorExperience.TenderAmount);
            if (objVendorExperience.DateFrom != DateTime.MinValue)
                prms[8] = SQLHelper.CreateParameter("DateFrom", SqlDbType.DateTime, objVendorExperience.DateFrom);
            else
                prms[8] = SQLHelper.CreateParameter("DateFrom", SqlDbType.DateTime, DBNull.Value);
            if (objVendorExperience.DateTo != DateTime.MinValue)
                prms[9] = SQLHelper.CreateParameter("DateTo", SqlDbType.DateTime, objVendorExperience.DateTo);
            else
                prms[9] = SQLHelper.CreateParameter("DateTo", SqlDbType.DateTime, DBNull.Value);
            prms[10] = SQLHelper.CreateParameter("Status", SqlDbType.VarChar, objVendorExperience.Status);
            prms[11] = SQLHelper.CreateParameter("IsDeleted", SqlDbType.Bit, objVendorExperience.IsDeleted);
            prms[12] = SQLHelper.CreateParameter("CreatedBy", SqlDbType.NVarChar, objVendorExperience.KeepTrack.CreatedBy);
            prms[13] = SQLHelper.CreateParameter("LastModifiedBy", SqlDbType.NVarChar, objVendorExperience.KeepTrack.LastModifiedBy);
            return prms;
        }

        private static int VendorExperienceInsert(VendorExperience objVendorExperience)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlParameter[] prms = GetVendorExperienceParameters(objVendorExperience, DataOperation.Insert);
                int noOfRowsAffected =
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "VendorExperienceInsert", prms);
                if (noOfRowsAffected == 0) throw new Exception("Insert Failed");

                objVendorExperience.ID = Convert.ToInt32(prms[0].Value);
                trans.Commit();
                return objVendorExperience.ID;
            }
            catch (Exception ex)
            {
                trans.Rollback(); throw ex;
            }
            finally { if (trans != null) trans.Dispose(); con.Close(); }
        }
        private static int VendorExperienceUpdate(VendorExperience objVendorExperience)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlParameter[] prms = GetVendorExperienceParameters(objVendorExperience, DataOperation.Update);
                int noOfRowsAffected =
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "VendorExperienceUpdate", prms);
                if (noOfRowsAffected == 0) throw new Exception("Update Failed");

                trans.Commit();
                return noOfRowsAffected;
            }
            catch (Exception ex)
            {
                trans.Rollback(); throw ex;
            }
            finally { if (trans != null) trans.Dispose(); con.Close(); }
        }
        private static int VendorExperienceDelete(VendorExperience objVendorExperience)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objVendorExperience.ID);
            prms[1] = SQLHelper.CreateParameter("IsDeleted", SqlDbType.Bit, objVendorExperience.IsDeleted);
            prms[2] = SQLHelper.CreateParameter("LastModifiedBy", SqlDbType.NVarChar, objVendorExperience.KeepTrack.LastModifiedBy);
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                int noOfRowsAffected =
                SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "VendorExperienceDelete", prms);
                if (noOfRowsAffected == 0) throw new Exception("Delete Failed");

                trans.Commit();
                return noOfRowsAffected;
            }
            catch (Exception ex)
            {
                trans.Rollback(); throw ex;
            }
            finally { if (trans != null) trans.Dispose(); con.Close(); }
        }

        #endregion

        #region Select Methods

        private static List<VendorExperience> SelectVendorExperienceHelper(SqlParameter[] prms, string storedProcedureName)
        {
            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CON_STRING, CommandType.StoredProcedure, storedProcedureName, prms))
            {
                try
                {
                    List<VendorExperience> objVendorExperiences = null;
                    if (dr.HasRows)
                    {
                        objVendorExperiences = new List<VendorExperience>();
                        while (dr.Read())
                        {
                            VendorExperience objVendorExperience = new VendorExperience();
                            if (dr["ID"] != DBNull.Value)
                                objVendorExperience.ID = Convert.ToInt32(dr["ID"]);
                            if (dr["VendorID"] != DBNull.Value)
                                objVendorExperience.Vendor.ID = Convert.ToInt32(dr["VendorID"]);
                            if (dr["CompanyName"] != DBNull.Value)
                                objVendorExperience.CompanyName = Convert.ToString(dr["CompanyName"]);
                            if (dr["CompanyType"] != DBNull.Value)
                                objVendorExperience.CompanyType = Convert.ToString(dr["CompanyType"]);
                            if (dr["Description"] != DBNull.Value)
                                objVendorExperience.Description = Convert.ToString(dr["Description"]);
                            if (dr["CompanyAddress"] != DBNull.Value)
                                objVendorExperience.CompanyAddress = Convert.ToString(dr["CompanyAddress"]);
                            if (dr["CompanyContactNumber"] != DBNull.Value)
                                objVendorExperience.CompanyContactNumber = Convert.ToString(dr["CompanyContactNumber"]);
                            if (dr["TenderAmount"] != DBNull.Value)
                                objVendorExperience.TenderAmount = Convert.ToString(dr["TenderAmount"]);
                            if (dr["DateFrom"] != DBNull.Value)
                                objVendorExperience.DateFrom = Convert.ToDateTime(dr["DateFrom"]);
                            if (dr["DateTo"] != DBNull.Value)
                                objVendorExperience.DateTo = Convert.ToDateTime(dr["DateTo"]);
                            if (dr["Status"] != DBNull.Value)
                                objVendorExperience.Status = Convert.ToString(dr["Status"]);
                            if (dr["IsDeleted"] != DBNull.Value)
                                objVendorExperience.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                            if (dr["CreatedBy"] != DBNull.Value)
                                objVendorExperience.KeepTrack.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                            if (dr["CreatedDate"] != DBNull.Value)
                                objVendorExperience.KeepTrack.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                            if (dr["LastModifiedBy"] != DBNull.Value)
                                objVendorExperience.KeepTrack.LastModifiedBy = Convert.ToString(dr["LastModifiedBy"]);
                            if (dr["LastModifiedDate"] != DBNull.Value)
                                objVendorExperience.KeepTrack.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                            objVendorExperiences.Add(objVendorExperience);
                        }
                    }
                    return objVendorExperiences;
                }
                catch (Exception ex) { throw ex; }
            }
        }
        public static VendorExperience VendorExperienceSelect(VendorExperience objVendorExperience)
        {
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objVendorExperience.ID);

            List<VendorExperience> objVendorExperiences = SelectVendorExperienceHelper(prms, "VendorExperienceSelect");
            return (objVendorExperiences == null) ? null : objVendorExperiences.FirstOrDefault<VendorExperience>();
        }
        public static List<VendorExperience> VendorExperiencesSelectAll(bool includeDeletedRecords)
        {
            if (includeDeletedRecords)
            {
                return SelectVendorExperienceHelper(null, "VendorExperiencesSelectAll");
            }
            else
            {
                string whereCondition = "IsDeleted is null Or IsDeleted = 0";
                string oderByExpression = "ID ASC";
                return VendorExperiencesSelectDynamic(whereCondition, oderByExpression);
            }
        }
        public static List<VendorExperience> VendorExperiencesSelectDynamic(string whereCondition, string orderByExpression)
        {
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = SQLHelper.CreateParameter("WhereCondition", SqlDbType.NVarChar, whereCondition);
            prms[1] = SQLHelper.CreateParameter("OrderByExpression", SqlDbType.NVarChar, orderByExpression);
            return SelectVendorExperienceHelper(prms, "VendorExperiencesSelectDynamic");
        }
        #endregion

        #region Utility Methods 

        #endregion
    }
}