using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public class CommonDropDownFillMethods
{
    #region FillDropDownListCountry
    public static void FillDropDownListCountry(DropDownList ddlCountryID, SqlInt32 UserID)
    {
        CountryBAL balCountry = new CountryBAL();
        ddlCountryID.DataSource = balCountry.SelectForDropDownList(UserID);
        ddlCountryID.DataValueField = "CountryID";
        ddlCountryID.DataTextField = "CountryName";
        ddlCountryID.DataBind();
        ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
    }
    #endregion FillDropDownListCountry

    #region FillDropDownListState
    public static void FillDropDownListState(DropDownList ddlStateID, SqlInt32 UserID)
    {
        StateBAL balState = new StateBAL();
        ddlStateID.DataSource = balState.SelectForDropDownList(UserID);
        ddlStateID.DataValueField = "StateID";
        ddlStateID.DataTextField = "StateName";
        ddlStateID.DataBind();
        ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
    }
    #endregion FillDropDownListState

    #region FillDropDownListCity
    public static void FillDropDownListCity(DropDownList ddlCityID, SqlInt32 UserID)
    {
        CityBAL balCity = new CityBAL();
        ddlCityID.DataSource = balCity.SelectForDropDownList(UserID);
        ddlCityID.DataValueField = "CityID";
        ddlCityID.DataTextField = "CityName";
        ddlCityID.DataBind();
        ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
    }
    #endregion FillDropDownListCity

    #region FillDropDownListContactCategory
    public static void FillDropDownListContactCategory(DropDownList ddlContactCategoryID, SqlInt32 UserID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        ddlContactCategoryID.DataSource = balContactCategory.SelectForDropDownList(UserID);
        ddlContactCategoryID.DataValueField = "ContactCategoryID";
        ddlContactCategoryID.DataTextField = "ContactCategoryName";
        ddlContactCategoryID.DataBind();
        ddlContactCategoryID.Items.Insert(0, new ListItem("Select Contact Category", "-1"));
    }
    #endregion FillDropDownListContactCategory

    #region FillDropDownListStateByCountryID
    public static void FillDropDownListStateByCountryID(DropDownList ddlStateID, SqlInt32 UserID, SqlInt32 CountryID)
    {
        StateBAL balState = new StateBAL();
        ddlStateID.DataSource = balState.SelectForDropDownListByCountryID(UserID, CountryID);
        ddlStateID.DataValueField = "StateID";
        ddlStateID.DataTextField = "StateName";
        ddlStateID.DataBind();
        ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
    }
    #endregion FillDropDownListStateByCountryID

    #region FillDropDownListCityByStateID
    public static void FillDropDownListCityByStateID(DropDownList ddlCityID, SqlInt32 UserID, SqlInt32 StateID)
    {
        CityBAL balCity = new CityBAL();
        ddlCityID.DataSource = balCity.SelectForDropDownListByStateID(UserID, StateID);
        ddlCityID.DataValueField = "CityID";
        ddlCityID.DataTextField = "CityName";
        ddlCityID.DataBind();
        ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
    }
    #endregion FillDropDownListCityByStateID

    #region Base64Encode
    public static string Base64Encode(String PlainText)
    {

        var PlainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainText);
        return System.Convert.ToBase64String(PlainTextBytes);

    }
    #endregion Base64Encode

    #region Base64Decode
    public static string Base64Decode(String Base64Encodeddata)
    {

        var Base64EncodeddataBytes = System.Convert.FromBase64String(Base64Encodeddata);
        return System.Text.Encoding.UTF8.GetString(Base64EncodeddataBytes);
    }
    #endregion Base64Decode
}