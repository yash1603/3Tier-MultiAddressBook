
using AddressBook.BAL;
using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
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
            FillDropDownList();

            #region Edit Mode
            if (Page.RouteData.Values["ContactID"] != null)
            {
                lblHeading.Text = "<h2>Edit Mode</h2>";
                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString())));
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
        #region Local Variable
        String strPhysicalPath = "";
        ContactBAL balContact = new ContactBAL();
        ContactENT entContact = new ContactENT();
        ContactDAL dalContact = new ContactDAL();
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country <br/>";
        }

        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select State <br/>";
        }

        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select City <br/>";
        }

        if (ddlContactCategoryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select ContactCategory <br/>";
        }

        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Name <br/>";
        }

        if (txtContactNo.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Number <br/>";
        }

        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Email I'D <br/>";
        }

        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Your Address <br/>";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        //Gather the Information
        if (ddlCountryID.SelectedIndex > 0)
        {
            entContact.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

        }
        if (ddlStateID.SelectedIndex > 0)
        {
            entContact.StateID = Convert.ToInt32(ddlStateID.SelectedValue);

        }
        if (ddlCityID.SelectedIndex > 0)
        {
            entContact.CityID = Convert.ToInt32(ddlCityID.SelectedValue);

        }

        if (ddlContactCategoryID.SelectedIndex > 0)
        {
            entContact.ContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);

        }

        if (txtContactName.Text.Trim() != "")
        {
            entContact.ContactName = txtContactName.Text.Trim();
        }

        if (txtContactNo.Text.Trim() != "")
        {
            entContact.ContactNo = txtContactNo.Text.Trim();
        }

        if (txtEmail.Text.Trim() != "")
        {
            entContact.Email = txtEmail.Text.Trim();
        }

        if (txtAddress.Text.Trim() != "")
        {
            entContact.Address = txtAddress.Text.Trim();
        }
        if (txtWhatsAppNo.Text.Trim() != "")
        {
            entContact.WhatsAppNo = txtWhatsAppNo.Text.Trim();
        }
        if (txtBirthDate.Text.Trim() != "")
        {
            entContact.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
        }
        if (txtAge.Text.Trim() != "")
        {
            entContact.Age = Convert.ToInt32(txtAge.Text.Trim());
        }

       

        if (fuFileContactPhotoPath.HasFile)
        {
            entContact.ContactPhotoPath = Server.MapPath(strPhysicalPath);
        }
        if (hfAttribute.Value.Trim() != "")
        {
            entContact.PhotoAttribute = hfAttribute.Value.Trim();

        }
        if (Session["UserID"] != null)
        {
            entContact.UserID = Convert.ToInt32(Session["UserID"].ToString().Trim());
        }
        #endregion Gather Information


        #region File Upload
        if (fuFileContactPhotoPath.HasFile)
        {
            entContact.ContactPhotoPath = "~/UserContent/";
            strPhysicalPath = Server.MapPath(entContact.ContactPhotoPath.ToString());
            strPhysicalPath += fuFileContactPhotoPath.FileName;
            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuFileContactPhotoPath.SaveAs(strPhysicalPath);
            entContact.ContactPhotoPath += fuFileContactPhotoPath.FileName;

            Decimal Size = Math.Round(((decimal)fuFileContactPhotoPath.PostedFile.ContentLength / (decimal)1024), 2);
            string strExt = Path.GetExtension(entContact.ContactPhotoPath.ToString());

            entContact.PhotoAttribute = "File Size : " + Size + "KB" + " File Type : " + strExt;
        }
        #endregion File Upload

        if (Page.RouteData.Values["ContactID"] == null)
        {
            if (balContact.Insert(entContact))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
        }
        else
        {
            entContact.PhotoAttribute = "";
            entContact.ContactPhotoPath = "";
            entContact.ContactID = Convert.ToInt32(EncryptDecrypt.Base64Decode(Page.RouteData.Values["ContactID"].ToString().Trim()));
            if (balContact.Update(entContact))
            {
                Response.Redirect("~/AdminPanel/Contact/List");
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
        }

    }
    #endregion Button : Save

    #region ClearControls
    private void ClearControls()
    {
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        ddlContactCategoryID.SelectedIndex = 0;
        txtContactName.Text = "";
        txtContactNo.Text = "";
        txtWhatsAppNo.Text = "";
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
      
        ddlCountryID.Focus();
    }
    #endregion ClearControls

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Convert.ToInt32(Session["UserID"].ToString().Trim()));
        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlStateID, Convert.ToInt32(Session["UserID"].ToString().Trim()), SqlInt32.Parse(ddlCountryID.SelectedValue.ToString()));
        CommonDropDownFillMethods.FillDropDownListCityByStateID(ddlCityID, Convert.ToInt32(Session["UserID"].ToString().Trim()), SqlInt32.Parse(ddlStateID.SelectedValue.ToString()));
        CommonDropDownFillMethods.FillDropDownListContactCategory(ddlContactCategoryID, Convert.ToInt32(Session["UserID"].ToString().Trim()));
    }
    #endregion Fill DropDownList

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID)
    {
        PhotoUpload.Visible = false;
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(ContactID);

        if (!entContact.CountryID.IsNull)
        {
            ddlCountryID.SelectedValue = entContact.CountryID.Value.ToString();
        }
        if (!entContact.StateID.IsNull)
        {
            ddlStateID.SelectedValue = entContact.StateID.Value.ToString();
        }
        if (!entContact.CityID.IsNull)
        {
            ddlCityID.SelectedValue = entContact.CityID.Value.ToString();
        }
        if (!entContact.ContactCategoryID.IsNull)
        {
            ddlContactCategoryID.SelectedValue = entContact.ContactCategoryID.Value.ToString();

        }

        if (!entContact.ContactName.IsNull)
        {
            txtContactName.Text = entContact.ContactName.Value.ToString();
        }
        if (!entContact.ContactNo.IsNull)
        {
            txtContactNo.Text = entContact.ContactNo.Value.ToString();
        }
        if (!entContact.WhatsAppNo.IsNull)
        {
            txtWhatsAppNo.Text = entContact.WhatsAppNo.Value.ToString();
        }
        if (!entContact.BirthDate.IsNull)
        {
            txtBirthDate.Text = entContact.BirthDate.Value.ToString();
        }
        if (!entContact.Email.IsNull)
        {
            txtEmail.Text = entContact.Email.Value.ToString();
        }
        if (!entContact.Age.IsNull)
        {
            txtAge.Text = entContact.Age.Value.ToString();
        }
        if (!entContact.Address.IsNull)
        {
            txtAddress.Text = entContact.Address.Value.ToString();
        }
      
        FillDropDownList();

    }
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/List");
    }
    #endregion Button : Cancel

    #region ddlCountry - Selected Index Changed
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill State dropdown list
        if (ddlCountryID.SelectedIndex > 0)
        {
            CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlStateID, Convert.ToInt32(Session["UserID"].ToString().Trim()), SqlInt32.Parse(ddlCountryID.SelectedValue));
        }
        else
        {
            ddlStateID.Items.Clear();
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

            ddlCityID.Items.Clear();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
        }
    }
    #endregion ddlCountry - Selected Index Changed

    #region ddlState - Selected Index Changed
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Fill City DropDown List

        if (ddlStateID.SelectedIndex > 0)
        {
            CommonDropDownFillMethods.FillDropDownListCityByStateID(ddlCityID, Convert.ToInt32(Session["UserID"].ToString().Trim()), SqlInt32.Parse(ddlStateID.SelectedValue));
        }
        else
        {
            ddlCityID.Items.Clear();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));

        }
    }

    #endregion ddlState - Selected Index Changed

    
}