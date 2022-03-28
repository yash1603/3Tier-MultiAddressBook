using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Default : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Event

    #region Button : Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        // Validate user Or not Validate user
        // UserName, Password
        #region Local Variable
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;

        #endregion Local Variable
        #region Server Side Validation
        String strErrorMessage = "";

        if (txtUserNameLogin.Text.Trim() == "")
        {
            strErrorMessage += "- Enter UserName <br/>";
        }

        if (txtPasswordLogin.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Password <br/>";
        }

        if (strErrorMessage != "")
        {
            lblMessage.Text = "Kindly solve following Error(s) <br/>" + strErrorMessage;
            return;
        }
        #endregion Server Side Validation
        entUser = balUser.SelectByNamePassword(txtUserNameLogin.Text.ToString().Trim(), txtPasswordLogin.Text.ToString().Trim());

        if (entUser != null)
        {
            if (!entUser.DisplayName.IsNull && !entUser.UserID.IsNull)
            {
                Session["DisplayName"] = entUser.DisplayName;
                Session["UserID"] = entUser.UserID;
                Response.Redirect("/AdminPanel/Home", true);
            }
            else
            {
                lblMessage.Text = "Please Create your account !";
            }

        }





    }
    #endregion Button : Login
}