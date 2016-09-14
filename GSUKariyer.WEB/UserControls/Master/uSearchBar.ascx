<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uSearchBar.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Master.uSearchBar" EnableViewState="true" %>

<%@ Register src="~/UserControls/SiteParamControls/uPositions.ascx" tagname="uPositions" tagprefix="uc1" %>
<%@ Register src="~/UserControls/SiteParamControls/uCityCountry.ascx" tagname="uCityCountry" tagprefix="uc2" %>

<div class="SearchBar">
    <div class="SearchBarLeft"></div>
    <div class="SearchBarContent">
        
        <div class="SearchBarContentTitle">hızlı iş arama</div>
        <div class="SearchBarContentForm">
        
            <asp:TextBox runat="server" ID="txtSearch" CssClass="TextBoxInit" Text="Anahtar Kelime ?" onclick="txtInitial(this.id, '', '');"></asp:TextBox>
            <uc2:uCityCountry ID="uCityCountry1" runat="server" />
            <uc1:uPositions ID="uSearchPosition" runat="server" />
            
            <div><asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/SearchBar/SearchButton.jpg" OnClick="btnSearch_Click" /></div>

        </div>
        
        <div class="SearchBarContentDetail">
            <asp:HyperLink runat="server" ID="hlDetailSearch" NavigateUrl="~/Search.aspx">» detaylı arama</asp:HyperLink>
        </div>
        
    </div>
    <div class="SearchBarRight"></div>
</div>




