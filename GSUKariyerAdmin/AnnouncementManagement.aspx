<%@ Page Title="" Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="AnnouncementManagement.aspx.cs" Inherits="AnnouncementManagement" %>
<%@ Register src="~/UC/Contents/uContentManagement.ascx" tagname="uContentManagement" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uContentManagement ID="uContentManagement1" runat="server" _Type="Announcements" />
    
</asp:Content>