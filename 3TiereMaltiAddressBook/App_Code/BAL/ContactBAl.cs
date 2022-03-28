using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactBAl
/// </summary>
namespace AddressBook.BAL
{
    public class ContactBAL
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
        public ContactBAL()
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
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Insert(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion Insert Contact

        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Update(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation

        #region Delete Contact
        public Boolean Delete(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Delete(ContactID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion Delete Contact

        #region DeletePicture
        public Boolean DeleteProfilePic(SqlInt32 UserID, SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.DeleteProfilePic(ContactID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion DelegePicture

        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByPK(ContactID);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}