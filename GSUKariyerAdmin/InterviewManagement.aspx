<%@ Page Title="" Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="InterviewManagement.aspx.cs" Inherits="InterviewManagement" %>
<%@ Register src="~/UC/Contents/uContentManagement.ascx" tagname="uContentManagement" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uContentManagement ID="uContentManagement1" runat="server" _Type="Interview" />
    
</asp:Content>