using LWMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LWMS.DBContext
{
    public static class UserDAL
    {
        #region DML Methods

        public static int ModifyUser(User objUser, DataOperation action)
        {
            int result = 0;
            switch (action)
            {
                case DataOperation.Insert:
                    result = UserInsert(objUser);
                    break;
                case DataOperation.Update:
                    result = UserUpdate(objUser);
                    break;
                case DataOperation.Delete:
                    result = UserDelete(objUser);
                    break;
            }
            return result;
        }
        private static SqlParameter[] GetUserParameters(User objUser, DataOperation action)
        {
            SqlParameter[] prms = new SqlParameter[10];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objUser.ID);
            if (action == DataOperation.Insert) prms[0].Direction = ParameterDirection.Output;
            prms[1] = SQLHelper.CreateParameter("GroupID", SqlDbType.Int, objUser.Group.ID);
            //prms[2] = SQLHelper.CreateParameter("SecurityQuestionID", SqlDbType.Int, objUser.SecurityQuestionID);
            //prms[3] = SQLHelper.CreateParameter("SecurityQuestionAnswer", SqlDbType.NVarChar, objUser.SecurityQuestionAnswer);
            prms[2] = SQLHelper.CreateParameter("UserName", SqlDbType.NVarChar, objUser.UserName);
            prms[3] = SQLHelper.CreateParameter("Password", SqlDbType.NVarChar, objUser.Password);
            prms[4] = SQLHelper.CreateParameter("Name", SqlDbType.NVarChar, objUser.Name);
            prms[5] = SQLHelper.CreateParameter("Email", SqlDbType.NVarChar, objUser.Email);
            prms[6] = SQLHelper.CreateParameter("Status", SqlDbType.VarChar, objUser.Status);
            prms[7] = SQLHelper.CreateParameter("IsDeleted", SqlDbType.Bit, objUser.IsDeleted);
            prms[8] = SQLHelper.CreateParameter("CreatedBy", SqlDbType.NVarChar, objUser.KeepTrack.CreatedBy);
            prms[9] = SQLHelper.CreateParameter("LastModifiedBy", SqlDbType.NVarChar, objUser.KeepTrack.LastModifiedBy);
            return prms;
        }

        private static int UserInsert(User objUser)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlParameter[] prms = GetUserParameters(objUser, DataOperation.Insert);
                int noOfRowsAffected =
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UserInsert", prms);
                if (noOfRowsAffected == 0) throw new Exception("Insert Failed");

                objUser.ID = Convert.ToInt32(prms[0].Value);
                trans.Commit();
                return objUser.ID;
            }
            catch (Exception ex)
            {
                trans.Rollback(); throw ex;
            }
            finally { if (trans != null) trans.Dispose(); con.Close(); }
        }
        private static int UserUpdate(User objUser)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlParameter[] prms = GetUserParameters(objUser, DataOperation.Update);
                int noOfRowsAffected =
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UserUpdate", prms);
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
        private static int UserDelete(User objUser)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objUser.ID);
            prms[1] = SQLHelper.CreateParameter("IsDeleted", SqlDbType.Bit, objUser.IsDeleted);
            prms[2] = SQLHelper.CreateParameter("LastModifiedBy", SqlDbType.NVarChar, objUser.KeepTrack.LastModifiedBy);
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                int noOfRowsAffected =
                SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UserDelete", prms);
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

        private static List<User> SelectUserHelper(SqlParameter[] prms, string storedProcedureName)
        {
            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CON_STRING, CommandType.StoredProcedure, storedProcedureName, prms))
            {
                try
                {
                    List<User> objUsers = null;
                    if (dr.HasRows)
                    {
                        objUsers = new List<User>();
                        while (dr.Read())
                        {
                            User objUser = new User();
                            if (dr["ID"] != DBNull.Value)
                                objUser.ID = Convert.ToInt32(dr["ID"]);
                            if (dr["GroupID"] != DBNull.Value)
                                objUser.Group.ID = Convert.ToInt32(dr["GroupID"]);
                            //if (dr["SecurityQuestionID"] != DBNull.Value)
                            //    objUser.SecurityQuestion.ID = Convert.ToInt32(dr["SecurityQuestionID"]);
                            //if (dr["SecurityQuestionAnswer"] != DBNull.Value)
                            //    objUser.SecurityQuestionAnswer = Convert.ToString(dr["SecurityQuestionAnswer"]);
                            if (dr["UserName"] != DBNull.Value)
                                objUser.UserName = Convert.ToString(dr["UserName"]);
                            if (dr["Password"] != DBNull.Value)
                                objUser.Password = Convert.ToString(dr["Password"]);
                            if (dr["Name"] != DBNull.Value)
                                objUser.Name = Convert.ToString(dr["Name"]);
                            if (dr["Email"] != DBNull.Value)
                                objUser.Email = Convert.ToString(dr["Email"]);
                            if (dr["Status"] != DBNull.Value)
                                objUser.Status = Convert.ToString(dr["Status"]);
                            if (dr["IsDeleted"] != DBNull.Value)
                                objUser.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                            if (dr["CreatedBy"] != DBNull.Value)
                                objUser.KeepTrack.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                            if (dr["CreatedDate"] != DBNull.Value)
                                objUser.KeepTrack.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                            if (dr["LastModifiedBy"] != DBNull.Value)
                                objUser.KeepTrack.LastModifiedBy = Convert.ToString(dr["LastModifiedBy"]);
                            if (dr["LastModifiedDate"] != DBNull.Value)
                                objUser.KeepTrack.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                            objUsers.Add(objUser);
                        }
                    }
                    return objUsers;
                }
                catch (Exception ex) { throw ex; }
            }
        }
        public static User UserSelect(User objUser)
        {
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = SQLHelper.CreateParameter("ID", SqlDbType.Int, objUser.ID);

            List<User> objUsers = SelectUserHelper(prms, "UserSelect");
            return (objUsers == null) ? null : objUsers.FirstOrDefault<User>();
        }
        public static List<User> UsersSelectAll(bool includeDeletedRecords)
        {
            if (includeDeletedRecords)
            {
                return SelectUserHelper(null, "UsersSelectAll");
            }
            else
            {
                string whereCondition = "IsDeleted is null Or IsDeleted = 0";
                string oderByExpression = "ID ASC";
                return UsersSelectDynamic(whereCondition, oderByExpression);
            }
        }
        public static List<User> UsersSelectDynamic(string whereCondition, string orderByExpression)
        {
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = SQLHelper.CreateParameter("WhereCondition", SqlDbType.NVarChar, whereCondition);
            prms[1] = SQLHelper.CreateParameter("OrderByExpression", SqlDbType.NVarChar, orderByExpression);
            return SelectUserHelper(prms, "UsersSelectDynamic");
        }
        #endregion

        #region Utility Methods 

        #endregion
    }
}