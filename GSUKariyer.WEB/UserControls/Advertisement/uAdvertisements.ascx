<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uAdvertisements.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Advertisement.uAdvertisements" %>

<%@ Register src="uAdvertisementList.ascx" tagname="uAdvertisementList" tagprefix="uc1" %>

<div class="SubPageWide">

    <h1>iş fırsatları</h1>
    
    <ins></ins>
        <asp:LinkButton CssClass="ReturnSearch" id="lbtnOpenSearchCriteria" runat="server" ToolTip="Arama kriterlerine geri dön"></asp:LinkButton>
    <input type="hidden" id="hfSearchForm" name="hfSearchForm" value="FromDetailedSearch" />
    <div style="text-align:left;">

        <input type="hidden" id="hfAdvertisementsForm" name="hfAdvertisementsForm" value="FromAdvertisements" />
        <asp:HiddenField ID="hfSearchCriteria" runat="server" />            
    
    </div>
    <ins></ins>
    
    <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
    <uc1:uAdvertisementList ID="uAdvertisementList1" runat="server" OnPageChanged="uAdvertisementList1_PageChanged" />
    
    <ins></ins>
    
</div>

