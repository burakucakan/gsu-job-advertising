<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register src="~/UC/Default/uLogin.ascx" tagname="uLogin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style type="text/css">
        #Footer { display: none; }
    </style>

    <uc1:uLogin ID="uLogin1" runat="server" />
 
</asp:Content>