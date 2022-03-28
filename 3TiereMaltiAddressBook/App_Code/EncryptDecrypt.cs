using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EncryptDecrypt
/// </summary>
public class EncryptDecrypt
{
    public EncryptDecrypt()
    {
        //
        // TODO: Add constructor logic here
        //
    }

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