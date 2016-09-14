<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FirmApplications.aspx.cs" Inherits="GSUKariyer.WEB.FirmApplications" %>

<%@ Register src="~/UserControls/Firm/uFirmApplications.ascx" tagname="uFirmApplications" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uFirmApplications ID="uFirmApplications1" runat="server" />

</asp:Content>