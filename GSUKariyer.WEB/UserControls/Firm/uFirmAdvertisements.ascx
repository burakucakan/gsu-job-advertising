<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFirmAdvertisements.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uFirmAdvertisements" %>

<%@ Register src="uFirmAdvertisementList.ascx" tagname="uFirmAdvertisementList" tagprefix="uc1" %>

<div class="SubPageWide">

    <h1>ilanlarım</h1>

    <ins></ins>
    
    » 
    <asp:LinkButton runat="server" ID="lnkArchive" CssClass="Und" OnClick="lnkArchive_Click">Arşivdeki ilanlarınız için tıklayınız</asp:LinkButton>
    <asp:LinkButton runat="server" ID="lnkLive" CssClass="Und" OnClick="lnkLive_Click" Visible="false">Yayındaki ilanlarınız için tıklayınız</asp:LinkButton>
    
    <ins></ins>

    <uc1:uFirmAdvertisementList ID="uFirmAdvertisementList1" runat="server" />

</div>