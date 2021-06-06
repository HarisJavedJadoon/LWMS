using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LWMS.DBContext
{
    public class SQLHelper
    {
        public static readonly string CON_STRING;
        //public static readonly SqlConnectionStringBuilder CON_STRING;
        /// <summary>
        /// 
        /// Database connection strings
        /// </summary>

        static SQLHelper()
        {
            CON_STRING = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection.ClearAllPools();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="Params"></param>
        /// <param name="DS"></param>
        /// <returns></returns>
        /// 
        static public DataTable GetFromDB(string SPName, SqlParameter[] Params, DataTable DS)
        {
            SqlConnection Con = new SqlConnection();
            try
            {
                Con = default(SqlConnection);

                Con = new SqlConnection(SQLHelper.CON_STRING);
                Con.Open();

                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = SPName;
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Clear();
                Cmd.Connection = Con;
                if (Params != null)
                {
                    foreach (SqlParameter parameter in Params)
                        Cmd.Parameters.Add(parameter);
                }
                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                Adapter.Fill(DS);
                Con.Close();
                return DS;
            }
            catch (Exception)
            {
                Con.Close();
                throw;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="Params"></param>
        /// <param name="DS"></param>
        /// <returns></returns>
        /// 
        static public DataSet GetFromDB(string SPName, SqlParameter[] Params, DataSet DS)
        {
            SqlConnection Con = new SqlConnection();
            try
            {
                Con = default(SqlConnection);

                Con = new SqlConnection(SQLHelper.CON_STRING);
                Con.Open();

                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = SPName;
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Clear();
                Cmd.Connection = Con;
                if (Params != null)
                {
                    foreach (SqlParameter parameter in Params)
                        Cmd.Parameters.Add(parameter);
                }
                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                Adapter.Fill(DS);
                Con.Close();
                return DS;
            }
            catch (Exception)
            {
                Con.Close();
                throw;
            }
        }

        static public DataTable GetFromDB(string text, CommandType type)
        {
            DataTable DT = new DataTable();
            SqlConnection Con = default(SqlConnection);
            Con = new SqlConnection(SQLHelper.CON_STRING);
            Con.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = text;
            if (type == CommandType.StoredProcedure)
                Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = Con;
            try
            {
                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                Adapter.Fill(DT);
                Con.Close();
                return DT;
            }
            catch (Exception)
            {
                Con.Close();
                throw;
            }
        }

        static public DataSet GetFromDB(string text, CommandType type, DataSet objDS = null)
        {
            DataSet DS = new DataSet();
            SqlConnection Con = default(SqlConnection);
            Con = new SqlConnection(SQLHelper.CON_STRING);
            Con.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = text;
            if (type == CommandType.StoredProcedure)
                Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = Con;
            try
            {
                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                Adapter.Fill(DS);
                Con.Close();
                return DS;
            }
            catch (Exception)
            {
                Con.Close();
                throw;
            }
        }


        static public SqlParameter[] CreateSqlParameters(String fields, String table, String whereCondition, String orderBy = "")
        {
            SqlParameter[] prms = new SqlParameter[4];
            prms[0] = new SqlParameter("fields", fields);
            prms[1] = new SqlParameter("table", table);
            prms[2] = new SqlParameter("whereCondition", whereCondition);
            prms[3] = new SqlParameter("orderBy", orderBy);

            return prms;
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored patientLabTest, text, etc.)</param>
        /// <param name="commandText">the stored patientLabTest name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {

                    PrepareCommand(cmd, conn, null, commandType, commandText, commandParameters);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored patientLabTest, text, etc.)</param>
        /// <param name="commandText">the stored patientLabTest name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlConnection conn, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, conn, null, commandType, commandText, commandParameters);
            try
            {
                int val = cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="commandType">the CommandType (stored patientLabTest, text, etc.)</param>
        /// <param name="commandText">the stored patientLabTest name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, trans.Connection, trans, commandType, commandText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored patientLabTest, text, etc.)</param>
        /// <param name="commandText">the stored patientLabTest name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, commandType, commandText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored patientLabTest, text, etc.)</param>
        /// <param name="commandText">the stored patientLabTest name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, commandType, commandText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }


        public static object ExecuteScalar(string CommandText)
        {
            Object val = new Object();
            using (SqlConnection con = new SqlConnection(SQLHelper.CON_STRING))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(CommandText, con))
                {
                    val = cmd.ExecuteScalar();
                }
            }
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored patientLabTest, text, etc.)</param>
        /// <param name="commandText">the stored patientLabTest name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlConnection conn, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, conn, null, commandType, commandText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        ///Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters./// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="commandType">the CommandType (stored patientLabTest, text, etc.)</param>
        /// <param name="commandText">the stored patientLabTest name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlTransaction trans, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, trans.Connection, trans, commandType, commandText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored patientLabTest or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            cmd.Parameters.Clear();
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            //cmd.CommandType = 
            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// Create new SqlParameter and set value.
        /// </summary>
        /// <param name="name">name of the parameter. Don't use @ sign with Parameters</param>
        /// <param name="dbType">type of parameter</param>
        /// <param name="value">value of the parameter</param>
        /// <returns></returns>
        public static SqlParameter CreateParameter(System.String name, System.Data.SqlDbType dbType, System.Object value)
        {
            SqlParameter prm = new SqlParameter(string.Format("@{0}", name), dbType);
            {
                prm.Value = value == null ? DBNull.Value : value;
            }
            return prm;
        }

        private static void WriteEncryptedConnectionStringSection(
           string name, string constring, string provider)
        {
            // Get the configuration file for the current application. Specify 
            // the ConfigurationUserLevel.None argument so that we get the 
            // configuration settings that apply to all users. 
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

            // Get the connectionStrings section from the configuration file. 
            ConnectionStringsSection section = config.ConnectionStrings;

            // If the connectionString section does not exist, create it. 
            if (section == null)
            {
                section = new ConnectionStringsSection();
                config.Sections.Add("connectionSettings", section);
            }

            // If it is not already encrypted, configure the connectionStrings  
            // section to be encrypted using the standard RSA Proected  
            // Configuration Provider. 
            if (!section.SectionInformation.IsProtected)
            {
                // Remove this statement to write the connection string in clear  
                // text for the purpose of testing. 
                section.SectionInformation.ProtectSection(
                    "RsaProtectedConfigurationProvider");
            }

            // Create a new connection string element and add it to the  
            // connection string configuration section. 
            ConnectionStringSettings cs =
                new ConnectionStringSettings(name, constring, provider);
            section.ConnectionStrings.Add(cs);



            // Force the connection string section to be saved. 
            section.SectionInformation.ForceSave = true;

            // Save the updated configuration file. 
            config.Save(ConfigurationSaveMode.Full);
        }

        public static int DynamicQuery(string sqlQuery)
        {
            SqlConnection con = new SqlConnection(SQLHelper.CON_STRING); SqlTransaction trans = null;
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = SQLHelper.CreateParameter("SQLQuery", SqlDbType.NVarChar, sqlQuery);

            try
            {
                con.Open();
                trans = con.BeginTransaction();
                int noOfRowsAffected =
                SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UserDynamicQuery", prms);
                if (noOfRowsAffected == 0) throw new Exception("Operation Failed");
                trans.Commit();
                return noOfRowsAffected;
            }
            catch (Exception ex)
            {
                trans.Rollback(); throw ex;
            }
            finally { if (trans != null) trans.Dispose(); con.Close(); }
        }

    }
}