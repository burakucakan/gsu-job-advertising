<%@ Page Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="FirmPending.aspx.cs" Inherits="FirmPending" %>
<%@ Register src="~/UC/Firms/uFirmPending.ascx" tagname="uFirmPending" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uFirmPending ID="uFirmPending1" runat="server" />

</asp:Content>
