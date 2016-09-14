<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CvForm.aspx.cs" Inherits="GSUKariyer.WEB.CvForm" %>

<%@ Register src="~/UserControls/Cv/uCvForm.ascx" tagname="uCvForm" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:uCvForm ID="uCvForm1" runat="server" />
        
</asp:Content>