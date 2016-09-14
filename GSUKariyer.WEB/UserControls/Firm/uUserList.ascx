<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUserList.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uUserList" %>

<%@ Register src="~/UserControls/Common/uPaging.ascx" tagname="uPaging" tagprefix="Paging" %>

<asp:Literal ID="ltrNoRecord" runat="server"></asp:Literal>
<asp:Repeater ID="rptUsers" runat="server" 
    onitemdatabound="rptUsers_ItemDataBound">
<HeaderTemplate>
    <table cellpadding="0" cellspacing="0" class="Grid">
</HeaderTemplate>
<ItemTemplate>
    <tr> 
        <td style="height: 60px; width: 55px;">
            <asp:HyperLink runat="server" ID="hlimgUser" ImageUrl="~/Images/_U/Users/Square/1.jpg" NavigateUrl="#" />
        </td>
        <td>
            
            <asp:HyperLink runat="server" ID="hlUser" CssClass="Und" NavigateUrl="#"></asp:HyperLink><br /><br />
            <asp:Literal ID="ltrGender" runat="server"></asp:Literal> <dfn><asp:Literal id="ltrAge" runat="server"></asp:Literal></dfn>
            
        </td>
        <td>
            
            <br /><br />
            <asp:Literal ID="ltrUnivDepartment" runat="server"></asp:Literal> &nbsp; <dfn><asp:Literal ID="ltrEducationState" runat="server"></asp:Literal></dfn>
            
        </td>
        <td>
            <br /><br />
            <asp:Literal ID="ltrCity" runat="server"></asp:Literal> &nbsp; <dfn><asp:Literal ID="ltrCountry" runat="server"></asp:Literal></dfn>
        </td>
        <td></td>
    </tr>
</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>

<Paging:uPaging ID="uPaging" runat="server" />