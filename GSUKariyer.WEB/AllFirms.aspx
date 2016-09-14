<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AllFirms.aspx.cs" Inherits="GSUKariyer.WEB.AllFirms" %>

<%@ Register src="~/UserControls/Lists/uAllFirms.ascx" tagname="uAllFirms" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uAllFirms ID="uAllFirms1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>