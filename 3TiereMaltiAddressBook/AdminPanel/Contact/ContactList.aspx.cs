using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login", true);
        }
        #endregion check Valid User
        if (!Page.IsPostBack)
        {
            FillGridView(Convert.ToInt32(Session["UserID"].ToString().Trim()));
        }
    }
    #endregion Load Event

    #region Fill Grid View
    private void FillGridView(SqlInt32 UserID)
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dtContact = new DataTable();

        dtContact = balContact.SelectAll(UserID);


        gvContact.DataSource = dtContact;
        gvContact.DataBind();

    }
    #endregion Fill Grid View

    #region gvContact : RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // Which command is clicked | e.CommandName
        // Which Row is clicked | Get the ID of that Row | e.CommandArgument
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                ContactENT entContact = new ContactENT();
                ContactBAL balContact = new ContactBAL();
                if (!balContact.DeleteProfilePic(SqlInt32.Parse(e.CommandArgument.ToString().Trim()), SqlInt32.Parse(Session["UserID"].ToString())))
                {
                    lblMessage.Text = balContact.Message;
                }

                if (balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"].ToString().Trim())))
                {
                    FillGridView(Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    lblMessage.Text = "Deleted Successfully";
                }
                else
                {
                    lblMessage.Text = balContact.Message;
                }
            }
        }


    }
    #endregion gvContact : RowCommand

}