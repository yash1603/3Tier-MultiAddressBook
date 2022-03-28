using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactDAl
/// </summary>
namespace AddressBook.DAL
{
    public class ContactDAL : DatabaseConfig
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
        public ContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation

        #region Insert Contact
        public Boolean Insert(ContactENT entContact)
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
                        objCmd.CommandText = "[dbo].[PR_Contact_Insert]";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entContact.UserID;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entContact.CountryID;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContact.ContactName;
                        objCmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = entContact.ContactNo;
                        objCmd.Parameters.Add("@WhatsAppNo", SqlDbType.VarChar).Value = entContact.WhatsAppNo;
                        objCmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = entContact.BirthDate;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.Add("@Age", SqlDbType.Int).Value = entContact.Age;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContact.Address;
                      
                        objCmd.Parameters.Add("@ContactPhotoPath", SqlDbType.VarChar).Value = entContact.ContactPhotoPath;
                        objCmd.Parameters.Add("@PhotoAttribute", SqlDbType.VarChar).Value = entContact.PhotoAttribute;
                        objCmd.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = entContact.CreationDate;
                        objCmd.Parameters.Add("@ModificationDate", SqlDbType.DateTime).Value = entContact.ModificationDate;
                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@ContactID"] != null)
                        {
                            entContact.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
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
        #endregion Insert Contact

        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactENT entContact)
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
                        objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";
                        objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", entContact.ContactCategoryID);
                        objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                        objCmd.Parameters.AddWithValue("@ContactNo", entContact.ContactNo);
                        objCmd.Parameters.AddWithValue("@WhatsAppNo", entContact.WhatsAppNo);
                        objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                        objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                      
                        objCmd.Parameters.AddWithValue("@CreationDate", entContact.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entContact.ModificationDate);
                        objCmd.Parameters.AddWithValue("@UserID", entContact.UserID);
                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
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
        #endregion Update Operation

        #region Delete Operation

        #region Delete Contact
        public Boolean Delete(SqlInt32 ContactID, SqlInt32 UserID)
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
                        objCmd.CommandText = "[dbo].[PR_Contact_DeleteByPK]";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
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
        #endregion Delete Contact

        #region DeleteProfilePic

        public Boolean DeleteProfilePic(SqlInt32 UserID, SqlInt32 ContactID)
        {
            #region Connection String
            ContactENT entContact = new ContactENT();
            SqlConnection ObjConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Connection String

            #region try | catch | finally

            try
            {
                #region ConnOpen | Command
                if (ObjConn.State != ConnectionState.Open)
                    ObjConn.Open();
                SqlCommand ObjCmd = ObjConn.CreateCommand();
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.CommandText = "PR_Contact_SelectImgPathByContactID";
                #endregion ConnOpen | Command

                #region Create Command
                ObjCmd.Parameters.AddWithValue("@UserID", UserID);
                ObjCmd.Parameters.AddWithValue("@ContactID", ContactID);
                #endregion Create Command

                #region Execute | Assigne | Close
                SqlDataReader objSDR = ObjCmd.ExecuteReader();
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                            entContact.ContactPhotoPath = objSDR["ContactPhotoPath"].ToString();
                    }
                }
                if (ObjConn.State != ConnectionState.Closed)
                    ObjConn.Close();

                String strPhysicalPath = System.Web.HttpContext.Current.Server.MapPath(entContact.ContactPhotoPath.ToString());
                if (File.Exists(strPhysicalPath))
                    File.Delete(strPhysicalPath);
                objSDR.Close();

                return true;
                #endregion Execute | Assigne | Close
            }
            catch (SqlException sqlex)
            {
                Message = sqlex.Message;
                return false;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
            finally
            {
                if (ObjConn.State != ConnectionState.Closed)
                    ObjConn.Close();
            }

            #endregion try | catch | finally
        }


        #endregion DeleteProfilePic

        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
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
                        objCmd.CommandText = "[dbo].[PR_Contact_SelectByUserID]";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
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
        #endregion SelectAll

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
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
                        objCmd.CommandText = "[dbo].[PR_Contact_SelectByPK]";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion Prepare Command

                        #region ReadData and set Controls
                        ContactENT entContact = new ContactENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                {
                                    entContact.ContactID = Convert.ToInt32(objSDR["ContactID"]);
                                }

                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entContact.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entContact.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                {
                                    entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);
                                }
                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                {
                                    entContact.ContactName = Convert.ToString(objSDR["ContactName"]);
                                }
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                {
                                    entContact.ContactNo = Convert.ToString(objSDR["ContactNo"]);
                                }
                                if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                                {
                                    entContact.WhatsAppNo = Convert.ToString(objSDR["WhatsAppNo"]);
                                }
                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                {
                                    entContact.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entContact.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["Age"].Equals(DBNull.Value))
                                {
                                    entContact.Age = Convert.ToInt32(objSDR["Age"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entContact.Address = Convert.ToString(objSDR["Address"]);
                                }
                               
                                if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                                {
                                    entContact.ContactPhotoPath = Convert.ToString(objSDR["ContactPhotoPath"]);
                                }
                                if (!objSDR["PhotoAttribute"].Equals(DBNull.Value))
                                {
                                    entContact.PhotoAttribute = Convert.ToString(objSDR["PhotoAttribute"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entContact.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entContact.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }
                            }
                        }
                        objConn.Close();
                        return entContact;
                        #endregion ReadData and set Controls
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
        #endregion SelectByPK

        #endregion Select Operation
    }
}