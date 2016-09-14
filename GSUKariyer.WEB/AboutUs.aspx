<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="GSUKariyer.WEB.AboutUs" %>

<%@ Register src="~/UserControls/AboutUs/uAboutUs.ascx" tagname="uAboutUs" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uAboutUs ID="uAboutUs1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
 
</asp:Content>