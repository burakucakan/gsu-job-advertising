<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Kariyer.aspx.cs" Inherits="GSUKariyer.WEB.Kariyer" %>

<%@ Register src="~/UserControls/Main/uMain.ascx" tagname="uMain" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uMain ID="uMain1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server"/>
        
</asp:Content>