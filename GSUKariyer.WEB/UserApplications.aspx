<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserApplications.aspx.cs" Inherits="GSUKariyer.WEB.UserApplications" %>

<%@ Register src="~/UserControls/User/uUserApplications.ascx" tagname="uUserApplications" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uUserApplications ID="uUserApplications1" runat="server" PagingShow="true" />
        
</asp:Content>