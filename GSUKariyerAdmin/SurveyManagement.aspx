<%@ Page Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="SurveyManagement.aspx.cs" Inherits="SurveyManagement" %>
<%@ Register src="~/UC/Survey/uSurveyManagement.ascx" tagname="uSurveyManagement" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uSurveyManagement ID="uSurveyManagement1" runat="server" />

</asp:Content>