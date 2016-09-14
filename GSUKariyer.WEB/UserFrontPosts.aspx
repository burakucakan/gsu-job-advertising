<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserFrontPosts.aspx.cs" Inherits="GSUKariyer.WEB.UserFrontPosts" %>

<%@ Register src="~/UserControls/User/uUserFrontPosts.ascx" tagname="uUserFrontPosts" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uUserFrontPosts ID="uUserFrontPosts1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>