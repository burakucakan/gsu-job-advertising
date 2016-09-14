<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="GSUKariyer.WEB._Users" %>

<%@ Register src="~/UserControls/Firm/uUsers.ascx" tagname="uUsers" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uUsers ID="uUsers1" runat="server" />
        
</asp:Content>