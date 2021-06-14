using LWMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LWMS.DBContext
{
    public static class VendorDAL
    {
        #region DML Methods

        public static int ModifyVendor(Vendor objVendor, DataOperation action)
        {
            int result = 0;
            switch (action)
            {
                case DataOperation.Insert:
                    result = VendorInsert(objVendor);
                    break;
                case DataOperation.Update:
                    result = VendorUpdate(objVendor);
                    break;
                case DataOperation.Delete:
                    result = VendorDelete(objVendor);
                    break;
            }
            return result;
        }
        private static SqlParameter[] GetVendorParameters(Vendor objVendor, DataOperation action)
        {
            SqlParameter[] prms = new SqlParameter[17];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objVendor.ID);
            if (action == DataOperation.Insert) prms[0].Direction = ParameterDirection.Output;
            prms[1] = SQLHelper.CreateParameter("GroupID", SqlDbType.NVarChar, objVendor.Group.ID);
            prms[2] = SQLHelper.CreateParameter("Name", SqlDbType.NVarChar, objVendor.Name);
            prms[3] = SQLHelper.CreateParameter("Password", SqlDbType.NVarChar, objVendor.Password);
            prms[4] = SQLHelper.CreateParameter("Description", SqlDbType.NVarChar, objVendor.Description);
            prms[5] = SQLHelper.CreateParameter("Landline", SqlDbType.NVarChar, objVendor.Landline);
            prms[6] = SQLHelper.CreateParameter("Email", SqlDbType.NVarChar, objVendor.Email);
            prms[7] = SQLHelper.CreateParameter("MobileNo", SqlDbType.NVarChar, objVendor.MobileNo);
            prms[8] = SQLHelper.CreateParameter("CNICNo", SqlDbType.NVarChar, objVendor.CNICNo);
            prms[9] = SQLHelper.CreateParameter("SalesTaxNo", SqlDbType.NVarChar, objVendor.SalesTaxNo);
            prms[10] = SQLHelper.CreateParameter("NTNNo", SqlDbType.NVarChar, objVendor.NTNNo);
            prms[11] = SQLHelper.CreateParameter("OfficeAddress", SqlDbType.NVarChar, objVendor.OfficeAddress);
            prms[12] = SQLHelper.CreateParameter("LogoUrl", SqlDbType.NVarChar, objVendor.LogoUrl);
            prms[13] = SQLHelper.CreateParameter("Status", SqlDbType.VarChar, objVendor.Status);
            prms[14] = SQLHelper.CreateParameter("IsDeleted", SqlDbType.Bit, objVendor.IsDeleted);
            prms[15] = SQLHelper.CreateParameter("CreatedBy", SqlDbType.NVarChar, objVendor.KeepTrack.CreatedBy);
            prms[16] = SQLHelper.CreateParameter("LastModifiedBy", SqlDbType.NVarChar, objVendor.KeepTrack.LastModifiedBy);
            return prms;
        }
        private static int VendorInsert(Vendor objVendor)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlParameter[] prms = GetVendorParameters(objVendor, DataOperation.Insert);
                int noOfRowsAffected =
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "VendorInsert", prms);
                if (noOfRowsAffected == 0) throw new Exception("Insert Failed");

                objVendor.ID = Convert.ToInt32(prms[0].Value);
                trans.Commit();
                return objVendor.ID;
            }
            catch (Exception ex)
            {
                trans.Rollback(); throw ex;
            }
            finally { if (trans != null) trans.Dispose(); con.Close(); }
        }
        private static int VendorUpdate(Vendor objVendor)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlParameter[] prms = GetVendorParameters(objVendor, DataOperation.Update);
                int noOfRowsAffected =
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "VendorUpdate", prms);
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
        private static int VendorDelete(Vendor objVendor)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objVendor.ID);
            prms[1] = SQLHelper.CreateParameter("IsDeleted", SqlDbType.Bit, objVendor.IsDeleted);
            prms[2] = SQLHelper.CreateParameter("LastModifiedBy", SqlDbType.NVarChar, objVendor.KeepTrack.LastModifiedBy);
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                int noOfRowsAffected =
                SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "VendorDelete", prms);
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

        private static List<Vendor> SelectVendorHelper(SqlParameter[] prms, string storedProcedureName)
        {
            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CON_STRING, CommandType.StoredProcedure, storedProcedureName, prms))
            {
                try
                {
                    List<Vendor> objVendors = null;
                    if (dr.HasRows)
                    {
                        objVendors = new List<Vendor>();
                        while (dr.Read())
                        {
                            Vendor objVendor = new Vendor();
                            if (dr["ID"] != DBNull.Value)
                                objVendor.ID = Convert.ToInt32(dr["ID"]);
                            if (dr["GroupID"] != DBNull.Value)
                                objVendor.Group.ID = Convert.ToInt32(dr["GroupID"]);
                            if (dr["Name"] != DBNull.Value)
                                objVendor.Name = Convert.ToString(dr["Name"]);
                            if (dr["Password"] != DBNull.Value)
                                objVendor.Password = Convert.ToString(dr["Password"]);
                            if (dr["Description"] != DBNull.Value)
                                objVendor.Description = Convert.ToString(dr["Description"]);
                            if (dr["Landline"] != DBNull.Value)
                                objVendor.Landline = Convert.ToString(dr["Landline"]);
                            if (dr["Email"] != DBNull.Value)
                                objVendor.Email = Convert.ToString(dr["Email"]);
                            if (dr["MobileNo"] != DBNull.Value)
                                objVendor.MobileNo = Convert.ToString(dr["MobileNo"]);
                            if (dr["CNICNo"] != DBNull.Value)
                                objVendor.CNICNo = Convert.ToString(dr["CNICNo"]);
                            if (dr["SalesTaxNo"] != DBNull.Value)
                                objVendor.SalesTaxNo = Convert.ToString(dr["SalesTaxNo"]);
                            if (dr["NTNNo"] != DBNull.Value)
                                objVendor.NTNNo = Convert.ToString(dr["NTNNo"]);
                            if (dr["OfficeAddress"] != DBNull.Value)
                                objVendor.OfficeAddress = Convert.ToString(dr["OfficeAddress"]);
                            if (dr["LogoUrl"] != DBNull.Value)
                                objVendor.LogoUrl = Convert.ToString(dr["LogoUrl"]);
                            if (dr["Status"] != DBNull.Value)
                                objVendor.Status = Convert.ToString(dr["Status"]);
                            if (dr["IsDeleted"] != DBNull.Value)
                                objVendor.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                            if (dr["CreatedBy"] != DBNull.Value)
                                objVendor.KeepTrack.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                            if (dr["CreatedDate"] != DBNull.Value)
                                objVendor.KeepTrack.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                            if (dr["LastModifiedBy"] != DBNull.Value)
                                objVendor.KeepTrack.LastModifiedBy = Convert.ToString(dr["LastModifiedBy"]);
                            if (dr["LastModifiedDate"] != DBNull.Value)
                                objVendor.KeepTrack.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                            objVendors.Add(objVendor);
                        }
                    }
                    return objVendors;
                }
                catch (Exception ex) { throw ex; }
            }
        }
        public static Vendor VendorSelect(Vendor objVendor)
        {
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objVendor.ID);

            List<Vendor> objVendors = SelectVendorHelper(prms, "VendorSelect");
            return (objVendors == null) ? null : objVendors.FirstOrDefault<Vendor>();
        }
        public static List<Vendor> VendorsSelectAll(bool includeDeletedRecords)
        {
            if (includeDeletedRecords)
            {
                return SelectVendorHelper(null, "VendorsSelectAll");
            }
            else
            {
                string whereCondition = "IsDeleted is null Or IsDeleted = 0";
                string oderByExpression = "ID ASC";
                return VendorsSelectDynamic(whereCondition, oderByExpression);
            }
        }
        public static List<Vendor> VendorsSelectDynamic(string whereCondition, string orderByExpression)
        {
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = SQLHelper.CreateParameter("WhereCondition", SqlDbType.NVarChar, whereCondition);
            prms[1] = SQLHelper.CreateParameter("OrderByExpression", SqlDbType.NVarChar, orderByExpression);
            return SelectVendorHelper(prms, "VendorsSelectDynamic");
        }
        #endregion

        #region Utility Methods 

        #endregion
    }
}