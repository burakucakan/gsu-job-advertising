<%@ Page Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="FirmManagement.aspx.cs" Inherits="FirmManagement" %>
<%@ Register src="~/UC/Firms/uFirmManagement.ascx" tagname="uFirmManagement" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uFirmManagement ID="uFirmManagement1" runat="server" />

</asp:Content>
