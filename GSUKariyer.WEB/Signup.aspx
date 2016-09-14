<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="GSUKariyer.WEB.Signup"
Culture="auto" UICulture="auto"
 %>

<%@ Register src="~/UserControls/Signup/uSignup.ascx" tagname="uSignup" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uSignup ID="uSignup1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>