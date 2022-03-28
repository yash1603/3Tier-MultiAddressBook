using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
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
            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                lblHeading.Text = "<h2>Edit Mode</h2>";
                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString())));
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

        if (txtContactCategoryName.Text.Trim() == "")
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
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        //Save the Country Data
        if (txtContactCategoryName.Text.Trim() != "")
        {
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim();
        }
        if (Session["UserID"] != null)
        {
            entContactCategory.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
        }
        #endregion Gather Information

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        if (Page.RouteData.Values["ContactCategoryID"] == null)
        {
            if (balContactCategory.Insert(entContactCategory))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
        }
        else
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim()));
            if (balContactCategory.Update(entContactCategory))
            {
                Response.Redirect("~/AdminPanel/ContactCategory/List");
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
        }
    }
    #endregion Button : Save

    #region ClearControls
    private void ClearControls()
    {
        txtContactCategoryName.Text = "";
        txtContactCategoryName.Focus();
    }
    #endregion ClearControls

    #region Fill Controls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID);

        if (!entContactCategory.ContactCategoryName.IsNull)
        {
            txtContactCategoryName.Text = entContactCategory.ContactCategoryName.Value.ToString();
        }


    }
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/List");
    }
    #endregion Button : Cancel
}