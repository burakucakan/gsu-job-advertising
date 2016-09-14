<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="GSUKariyer.WEB.Search" %>

<%@ Register src="~/UserControls/Search/uSearch.ascx" tagname="uSearch" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uSearch ID="uSearch1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>