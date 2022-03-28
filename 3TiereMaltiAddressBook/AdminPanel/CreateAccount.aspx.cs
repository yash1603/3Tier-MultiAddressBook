using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
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

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";
        if (txtUserName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Unique Name <br/>";
        }

        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Password <br/>";
        }

        if (txtName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Your Name <br/>";
        }

        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Your Address <br/>";
        }
        if (txtCity.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Your City <br/>";
        }
        if (txtMobile.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Your Mobile Number <br/>";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        UserENT entUser = new UserENT();
        //Gather the Information

        if (txtUserName.Text.Trim() != "")
        {
            entUser.UserName = txtUserName.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "")
        {
            entUser.Email = txtEmail.Text.Trim();
        }

        if (txtPassword.Text.Trim() != "")
        {
            entUser.Password = txtPassword.Text.Trim();
        }

        if (txtName.Text.Trim() != "")
        {
            entUser.DisplayName = txtName.Text.Trim();
        }

        if (txtAddress.Text.Trim() != "")
        {
            entUser.Address = txtAddress.Text.Trim();
        }

        if (txtCity.Text.Trim() != "")
        {
            entUser.City = txtCity.Text.Trim();
        }
        if (txtMobile.Text.Trim() != "")
        {
            entUser.Mobile = txtMobile.Text.Trim();
        }

        #endregion Gather Information

        UserBAL balUser = new UserBAL();

        if (balUser.Insert(entUser))
        {
            ClearControls();
            lblMessage.Text = "Data Inserted Successfully";
        }
        else
        {
            lblMessage.Text = balUser.Message;
        }
    }
    #endregion Button : Save

    #region Clear Controls
    private void ClearControls()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtName.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtCity.Text = "";
        txtMobile.Text = "";
        txtUserName.Focus();
    }
    #endregion Clear Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Login", true);
    }
    #endregion Button : Cancel
}