<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uMain.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Main.uMain" %>

<%@ Register src="~/UserControls/Common/uJobThumb.ascx" tagname="uJobThumb" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Main/uMainAnnouncements.ascx" tagname="uMainAnnouncements" tagprefix="uc2" %>
<%@ Register src="~/UserControls/Common/uCareerPlaningThumb.ascx" tagname="uCareerPlaningThumb" tagprefix="uc3" %>

<%@ Register src="../Advertisement/uAdvertisementThumbList.ascx" tagname="uAdvertisementThumbList" tagprefix="uc4" %>

<div class="SubPage">

    <span class="TopDesc">Galatasaray Üniversitesi <dfn>Öğrenci ve Mezunları için</dfn> <asp:Literal ID="ltrFirmsCount" runat="server"></asp:Literal> <dfn>firmaya ait</dfn> <asp:Literal ID="ltrAdvertisementCount" runat="server"></asp:Literal><dfn> iş fırsatı !..</dfn></span>
    
    <h1>vitrindeki ilanlar</h1>

    <ins></ins>

    <uc4:uAdvertisementThumbList ID="uAdvertisementThumbList1" runat="server" />
    
    <ins></ins>
    
    <uc2:uMainAnnouncements ID="uMainAnnouncements1" runat="server" />
    
    <ins></ins>
    
    <br /><br />

    <asp:Repeater runat="server" ID="rptCareerPlanings">
        <ItemTemplate>
        
        <uc3:uCareerPlaningThumb ID="uCareerPlaningThumb1" runat="server" 
            SiteContentID = '<%#Eval("ID") %>'
            ContentTypeTitle = '<%#Eval("Description").ToString() %>'
            Title = '<%#Eval("Title") %>'
            Name = '<%#Eval("Author") %>'
            Desc = '<%#Eval("ShortContent")%>' 
            ContentType = '<%#ArrangeContentTypeDesc(Eval("ContentType").ToString())%>'
            />
    
        </ItemTemplate>
    </asp:Repeater>
    
    
    <ins></ins>
    <br /><br /><br /><br /><br /><br />
    
</div>