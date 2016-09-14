<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uItem.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.HelperControls.uItem" %>

<div class="Item">

    <asp:Label runat="server" ID="lblText">İstanbul</asp:Label>

    <asp:LinkButton CssClass="ItemEdit ttR" runat="server" ID="lbtnEdit" ToolTip="Düzenle" OnClick="lbtnEdit_OnClick"></asp:LinkButton>
    <asp:HyperLink CssClass="ItemView ttT" runat="server" ID="hlView" ToolTip="Görüntüle" NavigateUrl="#" Visible="false"></asp:HyperLink>
    <asp:LinkButton CssClass="ItemRemove ttL" runat="server" ID="lbtnRemove" ToolTip="Sil" OnClick="lbtnRemove_OnClick" OnClientClick="return confirm('Silmek istediğinize emin misiniz?')"></asp:LinkButton>    

</div>