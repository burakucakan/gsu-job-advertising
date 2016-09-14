<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uMainAnnouncements.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Main.uMainAnnouncements" %>

<div class="MainAnnouncements">

    <asp:Repeater runat="server" ID="rptMainAnnouncements">
        <ItemTemplate>
        <asp:HyperLink CssClass="Content" runat="server" ID="hlAnc" NavigateUrl='<%#ArrangeNavigateUrl(Eval("ID").ToString(),Eval("Title").ToString()) %>'>       
            <asp:Image Border="1" runat="server" ID="imgAnc" ImageUrl='<%#ArrangeImageUrl(Eval("ID").ToString()) %>' />
            <b><%#Eval("Title") %></b>            <p><%#Eval("ShortContent") %></p>
        </asp:HyperLink>
   
        </ItemTemplate>
    </asp:Repeater>      
   
</div>