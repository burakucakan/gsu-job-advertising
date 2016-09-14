<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFooter.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Master.uFooter" %>

<div class="Footer">
    
    <p class="fLeft">
        Copyright © 2010 GSUKariyer.com &nbsp;&nbsp; | &nbsp;&nbsp; GSÜ Öğrenci Konseyi
    </p>
    
    <p class="fRight">
        <asp:HyperLink runat="server" ID="hlFooterMainPage" NavigateUrl="#">ana sayfa</asp:HyperLink>&nbsp;&nbsp;|&nbsp;&nbsp;
        <asp:HyperLink runat="server" ID="hlFooterAbout" NavigateUrl="#">hakkımızda</asp:HyperLink>&nbsp;&nbsp;|&nbsp;&nbsp;
        <asp:HyperLink runat="server" ID="hlFooterTerms" NavigateUrl="#">kullanım şartları</asp:HyperLink>&nbsp;&nbsp;|&nbsp;&nbsp;
        <asp:HyperLink runat="server" ID="hlFooterContact" NavigateUrl="#">iletişim</asp:HyperLink>
    </p>
    
</div>