<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Cv.aspx.cs" Inherits="GSUKariyer.WEB.Cv" %>

<%@ Register src="~/UserControls/Cv/uCv.ascx" tagname="uCv" tagprefix="uc1" %>

<%@ Register src="UserControls/Common/uBanner.ascx" tagname="uBanner" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uCv ID="uCv1" runat="server" />
        
    <uc2:uBanner ID="uBanner1" runat="server" />
        
</asp:Content>