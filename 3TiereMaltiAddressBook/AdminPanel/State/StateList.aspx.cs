using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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

    #region Fill Gried View
    private void FillGridView(SqlInt32 UserID)
    {
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();

        dtState = balState.SelectAll(UserID);

        gvState.DataSource = dtState;
        gvState.DataBind();

    }
    #endregion Fill Gried View

    #region gvState : RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // Which command is clicked | e.CommandName
        // Which Row is clicked | Get the ID of that Row | e.CommandArgument
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                StateBAL balState = new StateBAL();
                if (balState.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"].ToString().Trim())))
                {
                    FillGridView(Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    lblMessage.Text = "Deleted Successfully";
                }
                else
                {
                    lblMessage.Text = balState.Message;
                }
            }
        }


    }
    #endregion gvState : RowCommand

}