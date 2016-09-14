<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Firm.aspx.cs" Inherits="GSUKariyer.WEB.Firm" %>

<%@ Register src="~/UserControls/Firm/uFirm.ascx" tagname="uFirm" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uFirm ID="uFirm1" runat="server" />

</asp:Content>