using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAL
/// </summary>

namespace AddressBook.DAL
{
    public class UserDAL : DatabaseConfig
    {
        #region Local Variables
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local Variables

        #region Constructor
        public UserDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert
        public Boolean Insert(UserENT entUser)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                       
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = entUser.UserName;
                     
                        objCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = entUser.Password;
                        objCmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = entUser.DisplayName;
                        objCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = entUser.Address;
                        objCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = entUser.Email;
                        objCmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = entUser.City;
                        objCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = entUser.Mobile;

                        objCmd.CommandText = "[dbo].[PR_User_Insert]";

                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@UserID"] != null)
                        {
                            entUser.UserID = Convert.ToInt32(objCmd.Parameters["@UserID"].Value);
                        }
                        return true;

                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Insert

        #region SelectByNamePassword
        public UserENT SelectByNamePassword(SqlString UserName, SqlString Password)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "[dbo].[PR_User_SelectByUserNamePassword]";
                        objCmd.Parameters.AddWithValue("@UserName", UserName);
                        objCmd.Parameters.AddWithValue("@Password", Password);
                        #endregion Prepare Command

                        #region ReadData and set Controls
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }

                                if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                {
                                    entUser.DisplayName = Convert.ToString(objSDR["DisplayName"]);
                                }

                            }
                        }
                        return entUser;
                        #endregion ReadData and set Controls

                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }

                }
            }
        }
        #endregion SelectByNamePassword
    }
}