<%@ Page Title="" Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="BannerNew.aspx.cs" Inherits="BannerNew" %>
<%@ Register src="~/UC/Banner/uBannerNew.ascx" tagname="uBannerNew" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uBannerNew ID="uBannerNew1" runat="server" />

</asp:Content>