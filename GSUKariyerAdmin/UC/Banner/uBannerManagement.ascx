﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uBannerManagement.ascx.cs" Inherits="UC_Banner_uBannerManagement" %>
<%@ Register src="~/UC/Common/Paging.ascx" tagname="uPaging" tagprefix="Paging" %>
<%@ Register src="~/UC/Common/Error.ascx" tagname="uError" tagprefix="Error" %>
<%@ Register src="~/UC/Common/Success.ascx" tagname="uSuccess" tagprefix="Success" %>

<h1>BANNERLAR</h1>

<Success:uSuccess ID="uSuccess1" runat="server" Visible="false" Title="SEÇİLEN KAYITLAR SİLİNMİŞTİR" Desc="Seçtiğiniz bannerlar silinmiştir" />
<Error:uError ID="uError1" runat="server" Visible="false" Title="SEÇTİĞİNİZ KAYITLAR SİLİNİRKEN HATA OLUŞTU" Desc="Lütfen doğru seçimler yaptığınıza emin olunuz." />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
<table cellpadding="0" cellspacing="0" class="Grid fW2">

    <tr id="tr0" class="Head">
        <th class="tdCh"><asp:CheckBox runat="server" ID="chAll" AutoPostBack="true" oncheckedchanged="chAll_CheckedChanged" /></th>
        <td>BANNER</td>
        <td>START DATE</td>
        <td>END DATE</td>
    </tr>

<asp:Repeater runat="server" ID="rptList">
<ItemTemplate>
    <tr id='tr<%#Eval("BannerID") %>' class="Item" onmouseover="ClsChng(this.id, 'ItemOver');" onmouseout="ClsChng(this.id, 'Item');">
        <th><asp:CheckBox runat="server" ID="CheckBox1" CommandValue='<%# Eval("BannerID") %>' /></th>
        <td onclick="<%#Eval("BannerID", "go('BannerNew.aspx?j={0}');") %>"><%# Eval("BannerTitle")%></td>        
        <td onclick="<%#Eval("BannerID", "go('BannerNew.aspx?j={0}');") %>"><%# Convert.ToDateTime(Eval("StartDate")).ToShortDateString() %></td>
        <td onclick="<%#Eval("BannerID", "go('BannerNew.aspx?j={0}');") %>"><%# Convert.ToDateTime(Eval("EndDate")).ToShortDateString() %></td>
    </tr>
</ItemTemplate>
</asp:Repeater>

</table>

    </ContentTemplate>
</asp:UpdatePanel>
    
<Paging:uPaging ID="Paging1" runat="server" />

<br />

<asp:Button CssClass="Button2" runat="server" ID="btnDelete" 
    Text="BANNERLARI SİL" 
    OnClientClick="return confirm('Seçtiğiniz kayıtları silmek istiyor musunuz ?')" 
    onclick="btnDelete_Click" />