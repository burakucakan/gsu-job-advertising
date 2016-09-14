<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ContentDetail.aspx.cs" Inherits="GSUKariyer.WEB.ContentDetail" %>

<%@ Register src="~/UserControls/Content/uContentDetail.ascx" tagname="uContentDetail" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uContentDetail ID="uContentDetail1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>