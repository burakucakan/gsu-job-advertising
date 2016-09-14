<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFirmApplications.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uFirmApplications" %>

<%@ Register src="uFirmApplicationList.ascx" tagname="uFirmApplicationList" tagprefix="uc1" %>

<div class="SubPageWide">
    
    <h1>ilan başvuruları</h1>

    <ins></ins>

    <asp:HiddenField runat="server" ID="hdAdvertisementId" Value="0" />

    <uc1:uFirmApplicationList ID="uFirmApplicationList1" runat="server" />

</div>