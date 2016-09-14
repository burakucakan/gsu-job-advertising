<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uBanner.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uBanner"  %>

<div class="Banner">
     <asp:Repeater ID="rptBanners" runat="server" 
         onitemdatabound="rptBanners_ItemDataBound">
     <ItemTemplate>
        <asp:HyperLink runat="server" ID="hlBanner" Target="_blank" ImageUrl='<%#ArrangeImageUrl(Eval("FileName").ToString()) %>'  ></asp:HyperLink> 
     </ItemTemplate>
     <SeparatorTemplate>
        <ins></ins><br />
     </SeparatorTemplate>
     </asp:Repeater>
        
</div>