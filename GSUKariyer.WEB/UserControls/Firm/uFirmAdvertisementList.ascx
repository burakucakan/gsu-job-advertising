<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFirmAdvertisementList.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uFirmAdvertisementList" %>

<%@ Register src="~/UserControls/Common/uPaging.ascx" tagname="uPaging" tagprefix="Paging" %>

<asp:Literal runat="server" ID="ltlNoData" Visible="false">
    <br />
    <h4>İlan bulunmamaktadır...</h4>
</asp:Literal>

<asp:Panel runat="server" ID="pnlSuccDel" CssClass="Success" Visible="false">İLAN SİLİNMİŞTİR</asp:Panel>
<asp:Panel runat="server" ID="pnlSuccPassive" CssClass="Success" Visible="false">İLAN YAYINDAN KALDIRILMIŞTIR</asp:Panel>
<asp:Panel runat="server" ID="pnlSuccActive" CssClass="Success" Visible="false">İLAN YAYINA ALINMIŞTIR</asp:Panel>

<asp:Repeater runat="server" ID="rpt" OnItemDataBound="rpt_ItemDataBound" OnItemCommand="rpt_ItemCommand">
    <HeaderTemplate>                        
        <table cellpadding="0" cellspacing="0" class="Grid">
            <tr class="GridHeader">
                <td>Tarih</td>
                <td>İlan Başlığı</td>
                <td>Şehir</td>
                <td>Başvuru</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HiddenField runat="server" ID="hdId" Value='<%#Eval("ID") %>' />
         <tr> 
            <td>            
                <dfn> 
                    <%#Convert.ToDateTime(Eval("StartDate")).ToShortDateString() %> - 
                    <%#Convert.ToDateTime(Eval("EndDate")).ToShortDateString() %> 
                </dfn                
            </td> 
            <td>                 
                <asp:HyperLink runat="server" ID="hlTitle" CssClass="Und" NavigateUrl="#" ToolTip='<%#Eval("Title") %>'><%#GSUKariyer.COMMON.Util.Left(Eval("Title").ToString(), 50) %> </asp:HyperLink>
            </td> 
            <td>
                <asp:Literal runat="server" ID="ltlCity" Text='<%#Eval("City") %>'></asp:Literal>                
            </td>
            <td> 
                <asp:HyperLink runat="server" ID="hlApplications" CssClass="Und" NavigateUrl="#"
                ToolTip='<%#Eval("NewAppCount", "Yeni Başvuru: {0}") %>'
                >[ <%#Eval("NewAppCount") %> / <%#Eval("ApplicationCount") %> ]</asp:HyperLink>
            </td>
            <td>                        
                 <asp:HyperLink runat="server" ID="hlEdit" CssClass="ttT" ToolTip="Düzenle" ImageUrl="~/Images/Global/Edit.png" NavigateUrl="#"></asp:HyperLink> 
            </td>
            <td>
                <asp:Literal runat="server" ID="ltlState" Text='<%# Eval("State") %>' Visible="false"></asp:Literal>
                <asp:LinkButton CommandName="Passive" Visible="false" CommandArgument='<%#Eval("ID") %>' runat="server" ID="lnkPassive" OnClientClick="return confirm('İlanı yayından kaldırmak istediğinizden emin misiniz ?')" CssClass="ttT" ToolTip="Pasif yap">
                    <asp:Image runat="server" ImageUrl="~/Images/Global/Error.gif" />
                </asp:LinkButton>
                <asp:LinkButton CommandName="Active" Visible="false" CommandArgument='<%#Eval("ID") %>' runat="server" ID="lnkActive" OnClientClick="return confirm('İlanı yayına almak istediğinizden emin misiniz ?')" CssClass="ttT" ToolTip="Aktif yap">
                    <asp:Image ID="imgActive" runat="server" ImageUrl="~/Images/Global/Success.gif" />
                </asp:LinkButton>                                
            </td>
            <td>
                <asp:LinkButton CommandName="Del" CommandArgument='<%#Eval("ID") %>' runat="server" ID="lnkDel" OnClientClick="return confirm('İlanı silmek istediğinizden emin misiniz ?')" CssClass="ttT" ToolTip="İlanı Sil">
                    <asp:Image runat="server" ImageUrl="~/Images/Global/X.png" />
                </asp:LinkButton>             
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

<Paging:uPaging ID="uPaging" runat="server" />