<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="AdminPanel_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="~/contant/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="~/contant/css/bootstrap.min.css" rel="stylesheet" />
    <script src="~/contant/js/bootstrap.min.js"></script>
</head>
<body>
   <form id="form1" runat="server">
        <div class="container">
            <div class="row" align="justify">
            <h2 align="center">Create Your Account</h2>
            <hr />
            <div class="row">
                <div class="col-md-7">
                    <asp:Label runat="server" ID="lblHeading" ></asp:Label>
                </div>
            </div>
            <asp:Label runat="server" ID="lblMessage" Text="" EnableViewState="false" ForeColor="Green"></asp:Label>
            <br />
            <div class="row" align="center">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="User Name*" ID="lblUserName"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
                </div>
                <div class="col-md-2">

                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Enter Unique Name" ForeColor="Red" ToolTip="UserName - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row" align="center">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Password*" ID="lblPassword"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
                </div>
                <div class="col-md-2">

                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Your Password" ForeColor="Red" ToolTip="Password - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row" align="center">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Name*" ID="lblName"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
                </div>
                <div class="col-md-2">

                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Enter Your Name" ForeColor="Red" ToolTip="Name - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row" align="center">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Address*" ID="lblAddress"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <br />
                </div>
                <div class="col-md-2">

                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Enter Your Address" ForeColor="Red" ToolTip="Address - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row" align="center">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Email*" ID="lblEmail"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
                </div>
                <div class="col-md-2">
                    <asp:RegularExpressionValidator ID="rgvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter a Valid email id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row" align="center">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="City*" ID="lblCity"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
                    <br />
                </div>
                <div class="col-md-2">
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="Enter Your City" ForeColor="Red" ToolTip="City - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row" align="center">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Mobile*" ID="lblMobile"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox><br />
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Enter Your Mobile Number" ForeColor="Red" ToolTip="Mobile Number - Error" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row" align="center">
                <div class="col-md-4"></div>
                <div class="col-md-8">
                    <asp:Button runat="server" ID="btnSave" ToolTip="Submit" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success" ValidationGroup="Save" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnCancel" ToolTip="Cancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
