using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
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
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        dtCity = balCity.SelectAll(UserID);
        gvCity.DataSource = dtCity;
        gvCity.DataBind();

    }
    #endregion Fill Grid View Function

    #region gvCity : RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // Which command is clicked | e.CommandName
        // Which Row is clicked | Get the ID of that Row | e.CommandArgument
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                CityBAL balCity = new CityBAL();
                if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"].ToString().Trim())))
                {
                    FillGridView(Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    lblMessage.Text = "Deleted Successfully";
                }
                else
                {
                    lblMessage.Text = balCity.Message;
                }

            }
        }


    }
    #endregion gvCity : RowCommand

}