<%@ Page Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="UsersImport.aspx.cs" Inherits="UsersImport" %>
<%@ Register src="~/UC/Users/uUsersImport.ascx" tagname="uUsersImport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uUsersImport ID="uUsersImport1" runat="server" />

</asp:Content>