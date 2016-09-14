<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="GSUKariyer.WEB.Contact" %>

<%@ Register src="~/UserControls/Contact/uContact.ascx" tagname="uContact" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uContact ID="uContact1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>