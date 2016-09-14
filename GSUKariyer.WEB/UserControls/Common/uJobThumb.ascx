<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uJobThumb.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uJobThumb" %>

<asp:HyperLink runat="server" ID="hlJobThumb1" NavigateUrl="#" CssClass="JobThumb">

    <asp:Image ID="imgCompany" runat="server" ImageUrl="#" />            <asp:Label runat="server" ID="lblCompanyName"></asp:Label>    <asp:Literal runat="server" ID="ltlDesc"></asp:Literal>    
</asp:HyperLink>