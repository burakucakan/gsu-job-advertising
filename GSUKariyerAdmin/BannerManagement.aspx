<%@ Page Title="" Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="BannerManagement.aspx.cs" Inherits="BannerManagement" %>
<%@ Register src="~/UC/Banner/uBannerManagement.ascx" tagname="uBannerManagement" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uBannerManagement ID="uBannerManagement1" runat="server" />
    
</asp:Content>