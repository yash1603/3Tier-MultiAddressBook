using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBAL
/// </summary>
namespace AddressBook.BAL
{
    public class StateBAL
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
        public StateBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Insert(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Update(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StateID, SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Delete(StateID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }

        #endregion Delete Operation

        #region Select Operation
        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownList(UserID);
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public StateENT SelectByPK(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByPK(StateID);
        }
        #endregion SelectByPK

        #region SelectForDropDownListByCountryID
        public DataTable SelectForDropDownListByCountryID(SqlInt32 UserID, SqlInt32 CountryID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownListByCountryID(UserID, CountryID);
        }
        #endregion SelectForDropDownListByCountryID
        #endregion Select Operation


    }
}