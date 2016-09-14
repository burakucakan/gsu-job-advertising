<%@ Page Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="UserDetail" %>


<%@ Register src="UC/Users/uUserDetail.ascx" tagname="uUserDetail" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

<uc1:uUserDetail ID="uUserDetail1" runat="server" />
    
</asp:Content>
