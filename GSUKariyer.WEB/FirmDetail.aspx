<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FirmDetail.aspx.cs" Inherits="GSUKariyer.WEB.FirmDetail" %>

<%@ Register src="~/UserControls/Firm/uFirmDetail.ascx" tagname="uFirmDetail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uFirmDetail ID="uFirmDetail1" runat="server" />
        
</asp:Content>