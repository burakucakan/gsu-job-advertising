<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uContentNew.ascx.cs" Inherits="UC_News_uNewsNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CalendarExtenderPlus" Namespace="AjaxControlToolkitPlus" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="HTMLEditor" %>

<%@ Register src="~/UC/Common/Error.ascx" tagname="uError" tagprefix="uc1" %>
<%@ Register src="~/UC/Common/Success.ascx" tagname="uSuccess" tagprefix="uc2" %>
<%@ Register src="~/UC/Common/Languages.ascx" tagname="Languages" tagprefix="uc3" %>
    
    <uc2:uSuccess ID="uSuccess1" runat="server" Visible="false" Title="KAYIT EDİLDİ" Desc="Kayıt başarıyla gerçekleşmiştir." />
    <uc1:uError ID="uError1" runat="server" Visible="false" Title="KAYIT EDİLMEDİ" Desc="Kayıt yapılırken hata oluştu" />       
            
<asp:Panel runat="server" ID="pnlForm" CssClass="fW">

<asp:RequiredFieldValidator ID="rqTitle" runat="server" ErrorMessage="İçerik başlığını giriniz !" ControlToValidate="txtTitle" SetFocusOnError="true" Display="None"  ValidationGroup="vgEdit" />
<asp:RequiredFieldValidator ID="rqShortContent" runat="server" ErrorMessage="İçerik özetini giriniz !" ControlToValidate="txtShortContent" SetFocusOnError="true" Display="None"  ValidationGroup="vgEdit" />
<asp:RequiredFieldValidator ID="rqPhoto" runat="server" ErrorMessage="İçerik fotoğrafını giriniz !" ControlToValidate="fuPhoto" SetFocusOnError="true" Display="None"  ValidationGroup="vgEdit" />
<asp:RegularExpressionValidator ID="rexPhoto" runat="server"
     ValidationExpression="(.*\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG])$)"
     ControlToValidate="fuPhoto"
     Display="Dynamic"
     SetFocusOnError="true"
     ErrorMessage="Lütfen doğru bir resim seçiniz (JPG, GIF) !"
     ValidationGroup="vgEdit" />

    <asp:ValidationSummary ID="ValSum" runat="server" CssClass="Validate" ShowSummary="true" ValidationGroup="vgEdit" />           
    
    <h2>
        <asp:Literal runat="server" ID="ltlTitleAnnouncement" Visible="false">DUYURU</asp:Literal>
        <asp:Literal runat="server" ID="ltlTitleInterview" Visible="false">RÖPORTAJ</asp:Literal>
        <asp:Literal runat="server" ID="ltlTitleSuccessStory" Visible="false">BAŞARI HİKAYESİ</asp:Literal>
        <asp:Literal runat="server" ID="ltlTitleArticle" Visible="false">MAKALE</asp:Literal>        
        KAYDI
    </h2>
        
    <div class="Form">

    <p>İçerik başlığı</p>
    <asp:TextBox CssClass="TextBox" runat="server" ID="txtTitle" ValidationGroup="vgEdit" MaxLength="255"></asp:TextBox>

    <p>İçerik özeti</p>
    <asp:TextBox CssClass="TextBox" runat="server" ID="txtShortContent" ValidationGroup="vgEdit" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
        
    <p>İçerik detayı</p>    
    <HTMLEditor:Editor runat="server" 
            ID="txtContentDetail"
            Height="300px" 
            Width="100%"
            AutoFocus="true"            
    />    

    <p>Ek Bilgi</p>
    <asp:TextBox CssClass="TextBox" runat="server" ID="txtAuthor" ValidationGroup="vgEdit" MaxLength="100"></asp:TextBox>

    <p>Fotoğraf</p>    
    <asp:FileUpload ID="fuPhoto" runat="server" ValidationGroup="vgEdit" />
                     
    
    <br /><br />

    </div>
    
    <div class="FormFooter">
        <asp:Button runat="server" ID="btnSend" CssClass="Button" Text="KAYDET"  
            ValidationGroup="vgEdit" onclick="btnSend_Click" />
    </div>
                        
</asp:Panel>