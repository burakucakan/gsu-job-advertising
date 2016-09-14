<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserActivation.aspx.cs" Inherits="GSUKariyer.WEB.UserActivation1"  %>

<%@ Register src="~/UserControls/User/uUserActivation.ascx" tagname="uUserActivation" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uUserActivation ID="uUserActivation1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>