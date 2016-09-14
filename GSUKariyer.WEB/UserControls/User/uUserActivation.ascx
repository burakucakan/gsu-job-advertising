<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUserActivation.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.User.uUserActivation" %>

<div class="SubPage">
    
    <h1>üyelik aktivasyonu</h1>

    <ins></ins>
    
    <asp:Panel runat="server" ID="succ" CssClass="Success" Visible="false">
        ÜYELİK AKTİVASYONUNUZ YAPILMIŞTIR.
        <br /><br />
        
        Kullanıcı bilgileriniz ile sitemize üye girişi yapabilirsiniz.
        
    </asp:Panel>
    
    <asp:Panel runat="server" ID="err" CssClass="Error" Visible="false">
        ÜYELİK AKTİVASYONUNUZ YAPILAMADI.
        <br /><br />
        Üyeliğiniz zaten aktif ya da aktivasyon sürecinde hata oluştu <br /><br />
        Lütfen "Öğrenci konseyi kariyer komitesi" ile görüşünüz.
        
    </asp:Panel>    
    
</div>