<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFirmDetail.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uFirmDetail" %>

<%@ Register src="~/UserControls/Common/uSendCv.ascx" tagname="uSendCv" tagprefix="uc1" %>

<%@ Register src="../Advertisement/uAdvertisementList.ascx" tagname="uAdvertisementList" tagprefix="uc2" %>

<div class="SubPageWide">

    <h1>firmanın yayındaki ilanları</h1>
    
    <ins></ins>
    
    <asp:Literal runat="server" ID="ltlNoAdvs" Visible="false">Firmanın yayında ilanı bulunmamaktadır</asp:Literal>
    
    <uc2:uAdvertisementList ID="uAdvertisementList1" runat="server" />

    <ins></ins><ins></ins>    
  
    <h1>firma hakkında</h1>
  
    <ins></ins>
    
    <h2><asp:Literal runat="server" ID="ltlFirmName"></asp:Literal></h2>
    
    <ins></ins>
    
    <asp:Image runat="server" ID="imgLogo" ImageUrl="#" />                
    
    <ins></ins>                
    
    <p>                    
    
        <asp:Literal runat="server" ID="ltlDescription"></asp:Literal>
    
        <br /><br /><br />
    
        » <asp:HyperLink CssClass="Und" runat="server" ID="hlWebPage" NavigateUrl="#" Target="_blank">Firmanın web sitesine gitmek için tıklayınız...</asp:HyperLink>
        
    </p>

    <ins></ins>

    <div style="float: right;">
        <uc1:uSendCv ID="uSendCv1" runat="server"/>
    </div>
    
</div>


