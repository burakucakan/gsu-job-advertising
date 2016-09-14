<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUserFrontPosts.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.User.uUserFrontPosts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<cc1:CollapsiblePanelExtender ID="CP1" runat="server"
    TargetControlID="pnlNewFrontPost"
    ExpandControlID="hlNewFrontPost"
    CollapseControlID="hlNewFrontPost"
    Collapsed="true"
    Enabled="True" />
    
<div class="SubPage">

    <h1>ön yazılarım</h1>
    
    <ins></ins>    

    » <asp:HyperLink runat="server" ID="hlNewFrontPost" CssClass="Und" NavigateUrl="javascript:;">Yeni ön yazı oluşturmak için tıklayınız...</asp:HyperLink>

    <asp:HiddenField runat="server" ID="hdSelectedUserFrontPostId" Value="0" />

    <asp:Panel runat="server" ID="pnlNewFrontPost" CssClass="Form">

        <b>YENİ ÖNYAZI OLUŞTURUN</b>

        <p>Ön yazı başlığı</p>
        <asp:TextBox runat="server" ID="txtFrontPostTitle" MaxLength="128" ValidationGroup="vgFrontPost"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqTitle" runat="server" ErrorMessage="Ön yazı başlığını giriniz" ControlToValidate="txtFrontPostTitle" ValidationGroup="vgFrontPostNew"></asp:RequiredFieldValidator>

        <p>Ön yazı metni</p>
        <asp:TextBox runat="server" ID="txtFrontPostContent" MaxLength="1024" TextMode="MultiLine" Height="60" ValidationGroup="vgFrontPostNew"></asp:TextBox>    
        
        <asp:ImageButton runat="server" ID="imgBtnNew" ImageUrl="~/Images/Button/Save.jpg" ToolTip="Kaydet" OnClick="imgBtnNew_Click" ValidationGroup="vgFrontPostNew" />
    <br />
    <asp:Panel runat="server" ID="succSave" CssClass="Success" Visible="false">ÖN YAZI EKLENMİŞTİR</asp:Panel>
    <asp:Panel runat="server" ID="errSave" CssClass="Error" Visible="false">ÖN YAZI EKLENEMEDİ</asp:Panel>   

    </asp:Panel>
    
    <ins></ins>
    
    <asp:Panel runat="server" ID="succDel" CssClass="Success" Visible="false">ÖN YAZI SİLNMİŞTİR</asp:Panel>
    <asp:Panel runat="server" ID="succUpdate" CssClass="Success" Visible="false">ÖN YAZI GÜNCELLENMİŞTİR</asp:Panel>

    <ins></ins>

    <asp:Repeater runat="server" ID="rptList" onitemcommand="rptList_ItemCommand" 
        onitemdatabound="rptList_ItemDataBound">
        <ItemTemplate>

        <asp:Panel runat="server" ID="pnlFrontPosts" CssClass="Panel">
            
            <asp:PlaceHolder runat="server" ID="phView">
            
                <b><asp:Literal runat="server" ID="ltlFrontPostTitle" Text='<%#Eval("Title") %>'></asp:Literal></b><br />
                <asp:Literal runat="server" ID="ltlContent" Text='<%#Eval("Content") %>'></asp:Literal>
            
            </asp:PlaceHolder>
            
            <asp:PlaceHolder runat="server" ID="phEdit" Visible="false">
            
                <asp:TextBox runat="server" ID="txtFrontPostTitle" MaxLength="128" ValidationGroup="vgUpdateFrontPost" Text='<%#Eval("Title") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqTitle" runat="server" ErrorMessage="Ön yazı başlığını giriniz" ControlToValidate="txtFrontPostTitle" ValidationGroup="vgUpdateFrontPost"></asp:RequiredFieldValidator>        
                
                <asp:TextBox runat="server" ID="txtFrontPostContent" MaxLength="1024" TextMode="MultiLine" Height="70" ValidationGroup="vgUpdateFrontPost" Text='<%#Eval("Content") %>'></asp:TextBox>    
                <br />
                <asp:ImageButton runat="server" ID="imgBtnUpdate" CommandName="Update" CommandArgument='<%#Eval("ID") %>' ImageUrl="~/Images/Button/Save.jpg" ToolTip="Kaydet" ValidationGroup="vgUpdateFrontPost" />

            </asp:PlaceHolder>

        <br /><br />
        <asp:LinkButton runat="server" ID="lnkDel" CssClass="aDel" CommandName="Del" OnClientClick="return confirm('Bu ön yazıyı silmek istediğinizden emin misiniz?')">Sil</asp:LinkButton>
        <asp:LinkButton runat="server" ID="lnkEdit" CssClass="aEdit" CommandName="Edit">Düzenle</asp:LinkButton>                

        </asp:Panel>

        </ItemTemplate>
        
        <SeparatorTemplate> <br /><br /> </SeparatorTemplate>
        
    </asp:Repeater>
    
    <ins></ins>
    
</div>