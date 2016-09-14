<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uUserList.ascx.cs" Inherits="UC_Users_uUserList" %>
<%@ Register src="~/UC/Common/Paging.ascx" tagname="uPaging" tagprefix="Paging" %>
<%@ Register src="~/UC/Common/Error.ascx" tagname="uError" tagprefix="Error" %>
<%@ Register src="~/UC/Common/Success.ascx" tagname="uSuccess" tagprefix="Success" %>

<Success:uSuccess ID="uSuccess1" runat="server" Visible="false" Title="SEÇİLEN KAYITLAR SİLİNMİŞTİR" Desc="Seçtiğiniz firmalar silinmiştir" />
<Error:uError ID="uError1" runat="server" Visible="false" Title="SEÇTİĞİNİZ KAYITLAR SİLİNİRKEN HATA OLUŞTU" Desc="Lütfen doğru seçimler yaptığınıza emin olunuz." />
        
<asp:Panel runat="server" ID="pnlList">
        
<table cellpadding="0" cellspacing="0" class="Grid fW2">

    <tr id="tr0" class="Head">
        <th class="tdCh"><asp:CheckBox runat="server" ID="chAll" AutoPostBack="true" oncheckedchanged="chAll_CheckedChanged" /></th>
        <td>ÖĞRENCİ NO</td>
        <td>ADI</td>        
        <td>SOYADI</td>
        <td>EMAIL</td>
        <td>AKTİVASYON/AKTİVASYON YOLLAMA T.</td>
        <td>AKTİF?</td>
    </tr>

<asp:Repeater runat="server" ID="rptList">
<ItemTemplate>
    <tr id='tr<%#Eval("ID") %>' class="Item" onmouseover="ClsChng(this.id, 'ItemOver');" onmouseout="ClsChng(this.id, 'Item');">
        <th><asp:CheckBox runat="server" ID="CheckBox1" CommandValue='<%# Eval("ID") %>' /></th>
        <td onclick="<%#Eval("ID", "go('UserDetail.aspx?j={0}');") %>"><%# Eval("StudentNumber")%></td>        
        <td onclick="<%#Eval("ID", "go('UserDetail.aspx?j={0}');") %>"><%# Eval("Name") %></td>
        <td onclick="<%#Eval("ID", "go('UserDetail.aspx?j={0}');") %>"><%# Eval("Surname")%></td>
        <td onclick="<%#Eval("ID", "go('UserDetail.aspx?j={0}');") %>"><%# Eval("Email")%></td>
        <td onclick="<%#Eval("ID", "go('UserDetail.aspx?j={0}');") %>"><%# ArrangeDate(Eval("ActivationDate"))
        %></td>
        <td onclick="<%#Eval("ID", "go('UserDetail.aspx?j={0}');") %>"><%# ArrangeIsActive(Eval("IsActive"))
        %></td>
    </tr>
</ItemTemplate>
</asp:Repeater>

</table>
    
<Paging:uPaging ID="Paging1" runat="server" />

<br />

<asp:Button CssClass="Button2" runat="server" ID="btnDelete" 
    Text="SİL" 
    OnClientClick="return confirm('Seçtiğiniz kayıtları silmek istiyor musunuz ?')" 
    onclick="btnDelete_Click" />
    
</asp:Panel>
    
<asp:Panel runat="server" ID="pnlNoData" Visible="false">
    <div class="Form Big">
        Üye bulunmamaktadır !..
    </div>
</asp:Panel>