<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdvertisementDetail.aspx.cs" Inherits="GSUKariyer.WEB.AdvertisementDetail" %>

<%@ Register src="~/UserControls/Advertisement/uAdvertisementDetail.ascx" tagname="uAdvertisementDetail" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uAdvertisementDetail ID="uAdvertisementDetail1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>