<%@ Page Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserManagement" %>
<%@ Register src="~/UC/Users/uUserManagement.ascx" tagname="uUserManagement" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uUserManagement ID="uUserManagement1" runat="server" />

</asp:Content>
