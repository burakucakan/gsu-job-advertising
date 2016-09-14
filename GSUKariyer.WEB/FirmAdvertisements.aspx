<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FirmAdvertisements.aspx.cs" Inherits="GSUKariyer.WEB.FirmAdvertisements" %>

<%@ Register src="~/UserControls/Firm/uFirmAdvertisements.ascx" tagname="uFirmAdvertisements" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uFirmAdvertisements ID="uFirmAdvertisements1" runat="server" />

</asp:Content>