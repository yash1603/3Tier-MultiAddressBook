﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
       <div class="container">
        <div class="row">
            <div class="col-md-12" align="center">
                <h2>Contact Category List</h2>
                <hr />
                <br />
            </div>
            <div class="col-md-1">
                <asp:HyperLink runat="server" ID="hlContactCategoryAddEdit" Text="Add ContactCategory" ToolTip="ContactCategory -- Add" NavigateUrl="~/AdminPanel/ContactCategory/Add" CssClass="btn btn-success btn-sm"></asp:HyperLink>
            </div>
        </div>
        <asp:Label runat="server" ID="lblMessage" Text="" EnableViewState="false" ForeColor="Green"></asp:Label>
        <div class="row">
            <div class="col-md-12">
                <br />
                <asp:GridView ID="gvContactCategory" runat="server" AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand">
                    <Columns>
                    
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Category of Contact" />
                      
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>' OnClientClick="javascript:return confirm('Are you sure you want to delete record ?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-info btn-sm" CommandName="EditRecord" NavigateUrl='<%#"~/AdminPanel/ContactCategory/Edit/" +EncryptDecrypt.Base64Encode(Eval("ContactCategoryID").ToString().Trim()) %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

