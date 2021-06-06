using LWMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LWMS.DBContext
{
    public static class GroupDAL
    {
        #region DML Methods

        public static int ModifyGroup(Group objGroup, DataOperation action)
        {
            int result = 0;
            switch (action)
            {
                case DataOperation.Insert:
                    result = GroupInsert(objGroup);
                    break;
                case DataOperation.Update:
                    result = GroupUpdate(objGroup);
                    break;
                case DataOperation.Delete:
                    result = GroupDelete(objGroup);
                    break;
            }
            return result;
        }
        private static SqlParameter[] GetGroupParameters(Group objGroup, DataOperation action)
        {
            SqlParameter[] prms = new SqlParameter[6];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objGroup.ID);
            if (action == DataOperation.Insert) prms[0].Direction = ParameterDirection.Output;
            prms[1] = SQLHelper.CreateParameter("Description", SqlDbType.NVarChar, objGroup.Description);
            prms[2] = SQLHelper.CreateParameter("Status", SqlDbType.VarChar, objGroup.Status);
            prms[3] = SQLHelper.CreateParameter("IsDeleted", SqlDbType.Bit, objGroup.IsDeleted);
            prms[4] = SQLHelper.CreateParameter("CreatedBy", SqlDbType.NVarChar, objGroup.KeepTrack.CreatedBy);
            prms[5] = SQLHelper.CreateParameter("LastModifiedBy", SqlDbType.NVarChar, objGroup.KeepTrack.LastModifiedBy);
            return prms;
        }

        private static int GroupInsert(Group objGroup)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlParameter[] prms = GetGroupParameters(objGroup, DataOperation.Insert);
                int noOfRowsAffected =
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "GroupInsert", prms);
                if (noOfRowsAffected == 0) throw new Exception("Insert Failed");

                objGroup.ID = Convert.ToInt32(prms[0].Value);
                trans.Commit();
                return objGroup.ID;
            }
            catch (Exception ex)
            {
                trans.Rollback(); throw ex;
            }
            finally { if (trans != null) trans.Dispose(); con.Close(); }
        }
        private static int GroupUpdate(Group objGroup)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlParameter[] prms = GetGroupParameters(objGroup, DataOperation.Update);
                int noOfRowsAffected =
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "GroupUpdate", prms);
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
        private static int GroupDelete(Group objGroup)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objGroup.ID);
            prms[1] = SQLHelper.CreateParameter("IsDeleted", SqlDbType.Bit, objGroup.IsDeleted);
            prms[2] = SQLHelper.CreateParameter("LastModifiedBy", SqlDbType.NVarChar, objGroup.KeepTrack.LastModifiedBy);
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                int noOfRowsAffected =
                SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "GroupDelete", prms);
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

        private static List<Group> SelectGroupHelper(SqlParameter[] prms, string storedProcedureName)
        {
            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CON_STRING, CommandType.StoredProcedure, storedProcedureName, prms))
            {
                try
                {
                    List<Group> objGroups = null;
                    if (dr.HasRows)
                    {
                        objGroups = new List<Group>();
                        while (dr.Read())
                        {
                            Group objGroup = new Group();
                            if (dr["ID"] != DBNull.Value)
                                objGroup.ID = Convert.ToInt32(dr["ID"]);
                            if (dr["Description"] != DBNull.Value)
                                objGroup.Description = Convert.ToString(dr["Description"]);
                            if (dr["Status"] != DBNull.Value)
                                objGroup.Status = Convert.ToString(dr["Status"]);
                            if (dr["IsDeleted"] != DBNull.Value)
                                objGroup.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                            if (dr["CreatedBy"] != DBNull.Value)
                                objGroup.KeepTrack.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                            if (dr["CreatedDate"] != DBNull.Value)
                                objGroup.KeepTrack.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                            if (dr["LastModifiedBy"] != DBNull.Value)
                                objGroup.KeepTrack.LastModifiedBy = Convert.ToString(dr["LastModifiedBy"]);
                            if (dr["LastModifiedDate"] != DBNull.Value)
                                objGroup.KeepTrack.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                            objGroups.Add(objGroup);
                        }
                    }
                    return objGroups;
                }
                catch (Exception ex) { throw ex; }
            }
        }
        public static Group GroupSelect(Group objGroup)
        {
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objGroup.ID);

            List<Group> objGroups = SelectGroupHelper(prms, "GroupSelect");
            return (objGroups == null) ? null : objGroups.FirstOrDefault<Group>();
        }
        public static List<Group> GroupsSelectAll(bool includeDeletedRecords)
        {
            if (includeDeletedRecords)
            {
                return SelectGroupHelper(null, "GroupsSelectAll");
            }
            else
            {
                string whereCondition = "IsDeleted is null Or IsDeleted = 0";
                string oderByExpression = "ID ASC";
                return GroupsSelectDynamic(whereCondition, oderByExpression);
            }
        }
        public static List<Group> GroupsSelectDynamic(string whereCondition, string orderByExpression)
        {
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = SQLHelper.CreateParameter("WhereCondition", SqlDbType.NVarChar, whereCondition);
            prms[1] = SQLHelper.CreateParameter("OrderByExpression", SqlDbType.NVarChar, orderByExpression);
            return SelectGroupHelper(prms, "GroupsSelectDynamic");
        }
        #endregion

        #region Utility Methods 

        #endregion
    }
}