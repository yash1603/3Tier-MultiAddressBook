using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
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

            #region Edit Mode
            if (Page.RouteData.Values["CountryID"] != null)
            {
                lblHeading.Text += "<h2>Edit Mode</h2>";
                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim())));
            }
            #endregion Edit Mode
            #region Add Mode
            else
            {
                lblHeading.Text = "<h2>Add Mode</h2>";
            }
            #endregion Add Mode


        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        //Validate the Data
        String strErrorMessage = "";

        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Country Name <br/>";
        }


        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        CountryENT entCountry = new CountryENT();
        //Save the Country Data
        if (txtCountryName.Text.Trim() != "")
        {
            entCountry.CountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            entCountry.CountryCode = txtCountryCode.Text.Trim();
        }
        if (Session["UserID"] != null)
        {
            entCountry.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
        }
        #endregion Gather Information

        CountryBAL balCountry = new CountryBAL();
        if (Page.RouteData.Values["CountryID"] == null)
        {
            if (balCountry.Insert(entCountry))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["CountryID"].ToString().Trim()));
            if (balCountry.Update(entCountry))
            {
                Response.Redirect("~/AdminPanel/Country/List");
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
        }
    }
    #endregion Button : Save

    #region ClearControls
    private void ClearControls()
    {
        txtCountryName.Text = "";
        txtCountryCode.Text = "";
        txtCountryName.Focus();
    }
    #endregion ClearControls

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();

        entCountry = balCountry.SelectByPK(CountryID);



        if (!entCountry.CountryName.IsNull)
        {
            txtCountryName.Text = entCountry.CountryName.Value.ToString();
        }
        if (!entCountry.CountryCode.IsNull)
        {
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();
        }

    }
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/AdminPanel/Country/List", true);
    }
    #endregion Button : Cancel
}