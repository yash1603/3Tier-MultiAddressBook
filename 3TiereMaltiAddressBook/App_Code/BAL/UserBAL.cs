using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBAL
/// </summary>
namespace AddressBook.BAL
{
    public class UserBAL
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
        public UserBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert
        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Insert

        #region SelectByNamePassword
        public UserENT SelectByNamePassword(SqlString UserName, SqlString Password)
        {
            UserDAL dalCity = new UserDAL();
            return dalCity.SelectByNamePassword(UserName, Password);
        }
        #endregion SelectByNamePassword
    }
}