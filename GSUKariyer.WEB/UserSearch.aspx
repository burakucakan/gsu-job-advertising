<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserSearch.aspx.cs" Inherits="GSUKariyer.WEB.UserSearch" %>

<%@ Register src="~/UserControls/Firm/uUserSearch.ascx" tagname="uUserSearch" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uUserSearch ID="uUserSearch1" runat="server" />
    
    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>