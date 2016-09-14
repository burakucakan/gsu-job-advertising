<%@ Page Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="SurveyNew.aspx.cs" Inherits="SurveyNew" %>
<%@ Register src="~/UC/Survey/uSurveyNew.ascx" tagname="uSurveyNew" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uSurveyNew ID="uSurvey1" runat="server" />

</asp:Content>