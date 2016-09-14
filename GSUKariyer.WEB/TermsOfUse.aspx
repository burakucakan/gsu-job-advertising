<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="TermsOfUse.aspx.cs" Inherits="GSUKariyer.WEB.TermsOfUse" %>

<%@ Register src="~/UserControls/TermsOfuse/uTermsOfuse.ascx" tagname="uTermsOfuse" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uTermsOfuse ID="uTermsOfuse1" runat="server" />

    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>