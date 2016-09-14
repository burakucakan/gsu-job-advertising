<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCareerPlaningThumb.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uCareerPlaningThumb" %>

<div class="CareerPlanning">
        
    <h1> <asp:Literal runat="server" ID="ltlSiteContentType"></asp:Literal> </h1>
    
    <ins></ins>
    
    <br />
    
    <asp:HyperLink runat="server" ID="hlCareerDetail" NavigateUrl="#">
        <asp:Image ID="imgThumb" runat="server" ImageUrl="#" />
        
        <b> <asp:Literal runat="server" ID="ltlTitle"></asp:Literal> </b>
        <br />
        <dfn> <asp:Literal runat="server" ID="ltlName"></asp:Literal> </dfn>
        
        <ins></ins>
                
        <asp:Literal runat="server" ID="ltlDesc"></asp:Literal>
        »»
    </asp:HyperLink>
    
</div>