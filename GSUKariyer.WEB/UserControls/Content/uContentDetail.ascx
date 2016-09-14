<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uContentDetail.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Content.uContentDetail" EnableViewState="false" %>

<div class="SubPage ContentDetail">

    <h1><asp:Literal id="ltrContentCategory" runat="server"></asp:Literal></h1>
    
    <ins></ins><ins></ins>
    
    <h2> 
        <asp:Literal ID="ltrContentTitle" runat="server"></asp:Literal>        
    </h2>
    
    <ins></ins>

    <div id="divImage" runat="server">
        <asp:Image runat="server" ID="imgContent"/>
        <ins></ins>
        <dfn><asp:Literal id="ltrImageDesc" runat="server"></asp:Literal></dfn>
    </div>

    <p>
        <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
    </p>

</div>