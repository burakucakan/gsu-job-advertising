<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Contents.aspx.cs" Inherits="GSUKariyer.WEB.Contents" %>

<%@ Register src="~/UserControls/Content/uContents.ascx" tagname="uContents" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uContents ID="uContents1" runat="server" />
    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>