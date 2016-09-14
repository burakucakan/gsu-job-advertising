<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uContentManagement.ascx.cs" Inherits="UC_News_uNewsManagement" %>
<%@ Register src="~/UC/Common/Paging.ascx" tagname="uPaging" tagprefix="Paging" %>
<%@ Register src="~/UC/Common/Error.ascx" tagname="uError" tagprefix="Error" %>
<%@ Register src="~/UC/Common/Success.ascx" tagname="uSuccess" tagprefix="Success" %>

    <h1>
        <asp:Literal runat="server" ID="ltlTitleAnnouncement" Visible="false">DUYURULAR</asp:Literal>
        <asp:Literal runat="server" ID="ltlTitleInterview" Visible="false">RÖPORTAJLAR</asp:Literal>
        <asp:Literal runat="server" ID="ltlTitleSuccessStory" Visible="false">BAŞARI HİKAYELERİ</asp:Literal>
        <asp:Literal runat="server" ID="ltlTitleArticle" Visible="false">MAKALELER</asp:Literal>        
    </h1>

<Success:uSuccess ID="uSuccess1" runat="server" Visible="false" Title="SEÇİLEN KAYITLAR SİLİNMİŞTİR" Desc="Seçtiğiniz kayıtlar silinmiştir" />
<Error:uError ID="uError1" runat="server" Visible="false" Title="SEÇTİĞİNİZ KAYITLAR SİLİNİRKEN HATA OLUŞTU" Desc="Lütfen doğru seçimler yaptığınıza emin olunuz." />
        
<table cellpadding="0" cellspacing="0" class="Grid fW2">

    <tr id="tr0" class="Head">
        <th class="tdCh"><asp:CheckBox runat="server" ID="chAll" AutoPostBack="true" oncheckedchanged="chAll_CheckedChanged" /></th>
        <td>İÇERİK BAŞLIĞI</td>
    </tr>

<asp:Repeater runat="server" ID="rptList" onitemdatabound="rptList_ItemDataBound">
<ItemTemplate>
    <tr id='tr<%#Eval("ID") %>' class="Item" onmouseover="ClsChng(this.id, 'ItemOver');" onmouseout="ClsChng(this.id, 'Item');">
        <th><asp:CheckBox runat="server" ID="CheckBox1" CommandValue='<%# Eval("ID") %>' /></th>
        <asp:Literal runat="server" ID="ltlRow"></asp:Literal>
        
        <asp:Literal runat="server" ID="ltlID" Text='<%# Eval("ID") %>' Visible="false"></asp:Literal>
        <%# Eval("Title")%>
        </td>
        
    </tr>
</ItemTemplate>
</asp:Repeater>

</table>
    
<Paging:uPaging ID="Paging1" runat="server" />

<br />

<asp:Button CssClass="Button2" runat="server" ID="btnDelete" 
    Text="KAYITLARI SİL" 
    OnClientClick="return confirm('Seçtiğiniz kayıtları silmek istiyor musunuz ?')" 
    onclick="btnDelete_Click" />