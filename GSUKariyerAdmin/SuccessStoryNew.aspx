﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Management.master" AutoEventWireup="true" CodeFile="SuccessStoryNew.aspx.cs" Inherits="SuccessStoryNew" %>
<%@ Register src="~/UC/Contents/uContentNew.ascx" tagname="uContentNew" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderManagement" Runat="Server">

    <uc1:uContentNew ID="uContentNew1" runat="server" _Type="SuccessStories" />

</asp:Content>