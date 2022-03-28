<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

      <div class="container">
        <div class="row">
            <div class="col-md-12" align="center">
                <h2>State List</h2>
                <hr />
                <br />
            </div>
            <div class="col-md-1">
                <asp:HyperLink runat="server" ID="hlStateAddEdit" Text="Add State" ToolTip="State -- Add" NavigateUrl="~/AdminPanel/State/Add" CssClass="btn btn-success btn-sm"></asp:HyperLink>
            </div>
        </div>
        <asp:Label runat="server" ID="lblMessage" Text="" EnableViewState="false" ForeColor="Green"></asp:Label>
        <div class="row">
            <div class="col-md-12">
                <br />
                <asp:GridView ID="gvState" runat="server" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
                    <Columns>
                      
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="StateCode" HeaderText="State Code" />
                      
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' OnClientClick="javascript:return confirm('Are you sure you want to delete record ?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-info btn-sm" CommandName="EditRecord" NavigateUrl='<%#"~/AdminPanel/State/Edit/" + EncryptDecrypt.Base64Encode(Eval("StateID").ToString().Trim()) %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

