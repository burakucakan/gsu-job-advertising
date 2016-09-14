<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uMyPhoto.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uMyPhoto" %>
<div class="CvFormContent">
    <b>FOTOĞRAF</b>
    <br />
    <br />
    <div class="Form" style="width:430px;">
    
    <div class="Panel">
        Özgeçmişinize güncel bir fotoğrafınızı eklemeniz özgeçmişinizin daha profesyonel bir görünüme ulaşmasını ve 
        özgeçmişinizin hatırda kalmasını sağlayacaktır. <br />
        
        Fotoğrafın sizin gerçek görüntünüzü yansıttığına emin olun ve eski fotoğraflarınızı kullanmayın.
    </div>
    
        <br />
        
        <asp:Panel runat="server" ID="errUpload" CssClass="Error" Visible="false">Fotoğraf yüklenemedi !..</asp:Panel>
        <asp:Panel runat="server" ID="succDel" CssClass="Success" Visible="false">Fotoğrafınız silinmiştir!..</asp:Panel>
        <asp:Panel runat="server" ID="errDel" CssClass="Error" Visible="false">Fotoğrafınız silinirken hata oluştu!..</asp:Panel>
        
        <asp:Panel runat="server" ID="pnlPhoto" Visible="false">
            <ins></ins>
            <asp:Image runat="server" ID="imgPhoto" ImageUrl="#" />
            <br />
            <asp:LinkButton runat="server" ID="lnkDelPhoto" Text="[ Fotoğrafı Kaldır ]" OnClientClick="return confirm('Fotoğrafınızı silmek istediğinizden emin misiniz?')" OnClick="lnkDelPhoto_Click"></asp:LinkButton>
            <br />
        </asp:Panel>
        
        <p>Fotoğrafınızı Yükleyin</p>
        <asp:FileUpload ID="fuPhoto" runat="server" ValidationGroup="vgMyPhoto" />
        <asp:RegularExpressionValidator ID="rexPhoto" runat="server"
             ValidationExpression="(.*\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG])$)"
             ControlToValidate="fuPhoto"
             Display="Dynamic"
             SetFocusOnError="true"
             ErrorMessage="Lütfen doğru bir fotoğraf seçiniz (JPG, GIF) !"
             ValidationGroup="vgMyPhoto" />          
        
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgMyPhoto" />
        
    </div>
     
</div>