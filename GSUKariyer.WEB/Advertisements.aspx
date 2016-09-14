<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Advertisements.aspx.cs" Inherits="GSUKariyer.WEB.Advertisements" %>

<%@ Register src="~/UserControls/Advertisement/uAdvertisements.ascx" tagname="uAdvertisements" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uAdvertisements ID="uAdvertisements1" runat="server" />
         
</asp:Content>