<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uLoginArea.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Master.uLoginArea" %>

<%@ Register src="~/UserControls/Common/uLogin.ascx" tagname="uLogin" tagprefix="uc1" %>

<div class="LoginArea">

<asp:Panel runat="server" ID="pnlLoginOff" CssClass="LoginAreaOff" Visible="true">
        
    <asp:HyperLink runat="server" ID="hlFirmLogin" Text="firma girişi" CssClass="aCompany" NavigateUrl="#"></asp:HyperLink>
    <ins></ins>
    <asp:HyperLink runat="server" ID="hlNewUser" Text="üye ol"></asp:HyperLink>
    <asp:HyperLink runat="server" ID="hlUserLogin" Text="üye girişi" CssClass="aLogin" NavigateUrl="javascript:;"></asp:HyperLink>    

    <uc1:uLogin ID="uLogin1" runat="server" TargetControlID="hlUserLogin" />

</asp:Panel>

<asp:Panel runat="server" ID="pnlLoginOn" CssClass="LoginAreaOn" Visible="false">

        <asp:Image BorderWidth="1" runat="server" ID="img" ImageUrl="" />

        <div>                                <div class="LoginAreaOnInfo"> <dfn>Giriş Zamanı:</dfn> <asp:Literal runat="server" ID="ltlLoginTime"></asp:Literal> </div>            <div class="LoginAreaOnInfo"> <dfn><asp:Literal runat="server" ID="ltlInfo"></asp:Literal></dfn> <asp:Literal runat="server" ID="ltlName"></asp:Literal> </div>                    <ins></ins>                   <asp:LinkButton runat="server" ID="lnkLogOut" onclick="lnkLogOut_Click">Güvenli Çıkış</asp:LinkButton>
            <asp:HyperLink runat="server" ID="hlApplications" NavigateUrl="#">
                <dfn>Başvuru:</dfn> <asp:Literal runat="server" ID="ltlApplicationCount"></asp:Literal> &nbsp;&nbsp;&nbsp;
                <dfn>Yeni Mesaj:</dfn> <asp:Literal runat="server" ID="ltlUnreadAnswerCount"></asp:Literal>
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="hlFirmApplications" NavigateUrl="#" Visible="false">
                <dfn>Başvurular:</dfn> <asp:Literal runat="server" ID="ltlFirmApplicationCount"></asp:Literal> &nbsp;&nbsp;&nbsp;
            </asp:HyperLink>

        </div>                
        
</asp:Panel>

</div>