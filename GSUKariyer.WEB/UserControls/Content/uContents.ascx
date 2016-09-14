<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uContents.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Content.uContents" %>

<%@ Register src="~/UserControls/Common/uPaging.ascx" tagname="uPaging" tagprefix="Paging" %>

<div class="SubPage">

    <h1><asp:Literal runat="server" ID="ltlTitle"></asp:Literal></h1>
    
    <ins></ins>
    
    <div class="List">
    
    <asp:Repeater runat="server" ID="rptList" OnItemDataBound="rptList_ItemDataBound">
        <ItemTemplate>            
    
            <asp:HiddenField runat="server" ID="hdID" Value='<%#Eval("ID") %>' />
            <asp:HiddenField runat="server" ID="hdContentType" Value='<%#Eval("ContentType") %>' />
            
            <asp:HyperLink CssClass="Content" runat="server" ID="hlContent" NavigateUrl='#'>       
                <asp:Image Border="1" runat="server" ID="img" ImageUrl='#' />
                <b> <asp:Literal runat="server" ID="ltlTitle" Text='<%#Eval("Title") %>' /> </b>
                <p> <%#Eval("ShortContent") %> </p>
            </asp:HyperLink>
    
        </ItemTemplate>
    </asp:Repeater>

    <Paging:uPaging ID="uPaging" runat="server" />
    
    </div>
    
</div>