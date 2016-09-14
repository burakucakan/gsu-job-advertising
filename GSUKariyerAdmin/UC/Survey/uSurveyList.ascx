<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uSurveyList.ascx.cs" Inherits="UC_Survey_uSurveyList" %>
<%@ Register src="~/UC/Common/Paging.ascx" tagname="uPaging" tagprefix="Paging" %>
<%@ Register src="~/UC/Common/Error.ascx" tagname="uError" tagprefix="Error" %>
<%@ Register src="~/UC/Common/Success.ascx" tagname="uSuccess" tagprefix="Success" %>

<Success:uSuccess ID="uSuccess1" runat="server" Visible="false" Title="SEÇİLEN KAYITLAR SİLİNMİŞTİR" Desc="Seçtiğiniz kayıtlar silinmiştir" />
<Error:uError ID="uError1" runat="server" Visible="false" Title="SEÇTİĞİNİZ KAYITLAR SİLİNİRKEN HATA OLUŞTU" Desc="Lütfen doğru seçimler yaptığınıza emin olunuz." />
        
<asp:Panel runat="server" ID="pnlList">
        
<table cellpadding="0" cellspacing="0" class="Grid fW2">

    <tr id="tr0" class="Head">
        <th class="tdCh"><asp:CheckBox runat="server" ID="chAll" AutoPostBack="true" oncheckedchanged="chAll_CheckedChanged" /></th>
        <td>ANKET ADI</td>
        <td>SORUSU</td>        
        <td>OY SAYISI</td>
        <td>YARATILMA TARİHİ</td>
        <td>DURUMU</td>
    </tr>

<asp:Repeater runat="server" ID="rptList">
<ItemTemplate>
    <tr id='tr<%#Eval("ID") %>' class="Item" onmouseover="ClsChng(this.id, 'ItemOver');" onmouseout="ClsChng(this.id, 'Item');">
        <th><asp:CheckBox runat="server" ID="CheckBox1" CommandValue='<%# Eval("ID") %>' /></th>
        <td onclick="<%#Eval("ID", "go('SurveyDetail.aspx?j={0}');") %>"><%# ArrangeLength(Eval("Name").ToString(),100)%></td>        
        <td onclick="<%#Eval("ID", "go('SurveyDetail.aspx?j={0}');") %>"><%# ArrangeLength(Eval("Question").ToString(),150)%></td>
        <td onclick="<%#Eval("ID", "go('SurveyDetail.aspx?j={0}');") %>"><%# Eval("VoteCount")%></td>
        <td onclick="<%#Eval("ID", "go('SurveyDetail.aspx?j={0}');") %>"><%# ArrangeDate(Eval("CreateDate"))
        %></td>
        <td onclick="<%#Eval("ID", "go('SurveyDetail.aspx?j={0}');") %>"><%# ArrangeState(Eval("State").ToString()) %></td>
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