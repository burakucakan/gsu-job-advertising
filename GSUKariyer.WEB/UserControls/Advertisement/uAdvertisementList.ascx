<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uAdvertisementList.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Advertisement.uAdvertisementList" %>



<%@ Register src="../Common/uPagingPostback.ascx" tagname="uPagingPostback" tagprefix="uc1" %>



<asp:Literal runat="server" ID="ltlNoData" Visible="false">
    <br />
    <h4>İlan bulunmamaktadır...</h4>
</asp:Literal>

<asp:Repeater ID="rptAdvertisements" runat="server" OnItemDataBound="rptAdvertisements_ItemDataBound" >
    <HeaderTemplate>
        <table class="Grid" cellpadding="0" cellspacing="0">
            <tr class="GridHeader">
                <td>Tarih</td>
                <td>İlan Başlığı</td>
                <td>Şehir</td>
                <td>Firma</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><dfn><asp:Literal ID="ltrDateDefinition" runat="server"></asp:Literal></dfn></td>
            <td>
                <asp:HyperLink CssClass="Und" runat="server" ID="hlJobDetail"></asp:HyperLink>
            </td>
            <td><dfn><asp:Literal ID="ltrCityCountry" runat="server"></asp:Literal></dfn></td>
            <td>
                <asp:HyperLink CssClass="Und" runat="server" ID="hlCompanyDetail"></asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table> 
    </FooterTemplate>
</asp:Repeater>

<uc1:uPagingPostback ID="uPagingPostback1" runat="server" OnPageChanged="uPagingPostback1_PageChanged" />











