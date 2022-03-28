<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="~/contant/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="~/contant/css/bootstrap.min.css" rel="stylesheet" />
    <script src="~/contant/js/bootstrap.min.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12" align="center">
                <h1>EXISTING USER LOGIN ADDRESS BOOK</h1>
                <br />
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" id="lblMessage" EnableViewState="false" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <div class="row" >
            <div class="col-md-4">
               <asp:Label Text="User Name* :" runat="server" ID="lblUserName"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtUserNameLogin" ToolTip="Enter Your UserName"></asp:TextBox>
            </div>
            
                </div>
        <div class="row" =>
            <br />
            <div class="col-md-4">
               <asp:Label Text="Password* :" runat="server" ID="lblPassword"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox runat="server" ID="txtPasswordLogin" ToolTip="Enter Your Password" TextMode="Password"></asp:TextBox>
            </div>
            
        </div>
        <div class="row" >
            <br />
            <div class="col-md-4">
               
            </div>
            <div class="col-md-6">
                <asp:Button runat="server" id="btnLogin" Text="Login" OnClick="btnLogin_Click"/>
                <asp:HyperLink runat="server" id="hlCreateAccount" Text="Create Account" ToolTip="Create your account" NavigateUrl="~/AdminPanel/CreateAccount.aspx"></asp:HyperLink>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
