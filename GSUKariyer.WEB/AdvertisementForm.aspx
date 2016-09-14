<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdvertisementForm.aspx.cs" Inherits="GSUKariyer.WEB.AdvertisementForm" %>

<%@ Register src="~/UserControls/Firm/uAdvertisementForm.ascx" tagname="uAdvertisementForm" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uAdvertisementForm ID="uAdvertisementForm1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>