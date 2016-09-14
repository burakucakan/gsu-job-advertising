<%@ Page Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="FirmDetail.aspx.cs" Inherits="FirmDetail" %>
<%@ Register src="~/UC/Firms/uFirmDetail.ascx" tagname="uFirmDetail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uFirmDetail ID="uFirmDetail1" runat="server" />

</asp:Content>