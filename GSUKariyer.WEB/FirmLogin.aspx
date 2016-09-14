<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FirmLogin.aspx.cs" Inherits="GSUKariyer.WEB.FirmLogin" %>

<%@ Register src="~/UserControls/Firm/uFirmLogin.ascx" tagname="uFirmLogin" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uFirmLogin ID="uFirmLogin1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />

</asp:Content>