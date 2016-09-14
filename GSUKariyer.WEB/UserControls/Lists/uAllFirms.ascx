<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uAllFirms.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Lists.uAllFirms" %>

<div class="SubPage">

    <h1>firmalar</h1>

    <ins></ins>
    
        <asp:DataList runat="server" ID="dlList" RepeatColumns="4" Width="100%" CellPadding="0" CellSpacing="0" OnItemDataBound="dlList_ItemDataBound">
            <ItemTemplate>
        
                <asp:Literal runat="server" ID="ltlFirmId" Visible="false" Text='<%#Eval("ID") %>'></asp:Literal>
                <asp:Literal runat="server" ID="ltlFirmName" Visible="false" Text='<%#Eval("Name") %>'></asp:Literal>
                        
                <asp:HyperLink CssClass="ttB" runat="server" ID="hlFirmDetail" NavigateUrl="#" ToolTip='<%#Eval("Name") %>' />                
            
            </ItemTemplate>
            <ItemStyle CssClass="AllFirmList" />
        </asp:DataList>
    
    

</div>