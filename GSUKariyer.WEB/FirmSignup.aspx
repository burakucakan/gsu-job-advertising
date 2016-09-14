<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FirmSignup.aspx.cs" Inherits="GSUKariyer.WEB.FirmSignup" %>

<%@ Register src="~/UserControls/Firm/uFirmSignup.ascx" tagname="uFirmSignup" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uFirmSignup ID="uFirmSignup1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>