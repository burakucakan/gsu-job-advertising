<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFirmLogin.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uFirmLogin" %>

<div class="SubPage">

    <h1>firma girişi</h1>
    
    <ins></ins>        

    <div class="FirmLoginDesc">
    
        <div class="Panel">

            <b>GSUKariyer.com ÜYELİĞİ HAKKINDA</b>
            <br />
            GSUKariyer.com’da  bir kariyer sitesinde bulabileceğiniz tüm özelliklerin yanı sıra şirketiniz ile  
            Galatasaray Üniversitesi öğrenci ve mezunları arasında köprü kurma ayrıcalığına erişirsiniz.  
            <br />
            GSUKariyer.com projesini şirketinizin üniversite içindeki gözü ve kulağı olarak değerlendirebilirsiniz. 
            <br />
            Sistemimizde açacağınız hesap vasıtasıyla dilediğiniz özelliklere göre stajyer ve eleman bulabilecek, 
            şirketinizdeki iş ve staj imkanlarını duyurabilecek ve ilan verebileceksiniz...
        </div>
        
        <ins></ins>
        
        <asp:HyperLink runat="server" ID="hlFirmSignUp" NavigateUrl="#" ImageUrl="~/Images/Button/FirmSignUp.jpg"></asp:HyperLink>
        
    </div>

    <div class="FirmLogin">
    
        <asp:Panel runat="server" ID="errLogin" CssClass="Error" Visible="false">ÜYE GİRİŞ BİLGİLERİNİZİ KONTROL EDİNİZ !</asp:Panel>
        
        <asp:Panel runat="server" CssClass="Form" DefaultButton="imgBtnLogin">
        
            <p>Email adresiniz</p>
            <asp:TextBox runat="server" ID="txtEmail" ValidationGroup="vgFirmLogin" MaxLength="120" />
            <asp:RequiredFieldValidator ID="reqEmail" ErrorMessage="Email adresinizi giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtEmail" ValidationGroup="vgFirmLogin"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rglEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Geçerli bir email adresi giriniz !" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="vgFirmLogin" />

            <p>Şifreniz</p>
            <asp:TextBox runat="server" ID="txtPassword" MaxLength="20" TextMode="Password" ValidationGroup="vgFirmLogin" />
            <asp:RequiredFieldValidator ID="reqPass" ErrorMessage="Şifrenizi giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPassword" ValidationGroup="vgFirmLogin"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvPass" runat="server" Display="Dynamic" ControlToValidate="txtPassword" ClientValidationFunction="cvPassCtrl" ErrorMessage="Şifreniz en az 5 karakter olmalıdır !" ValidationGroup="vgFirmLogin" />
            
            <asp:ImageButton runat="server" ID="imgBtnLogin" 
                    ImageUrl="~/Images/Button/Login.jpg" ValidationGroup="vgFirmLogin" 
                    onclick="imgBtnLogin_Click" />
                    
            <ins></ins>

            <asp:HyperLink runat="server" ID="hlForgotPassword" NavigateUrl="#">
                Şifremi unuttum
            </asp:HyperLink>
            
        </asp:Panel>
    
        <asp:Panel runat="server" ID="FirmForgotPass" CssClass="FirmLogin Form" style="display: none;" DefaultButton="imgBtnForgotPassSend">
        
        <asp:UpdatePanel ID="upForgotPass" runat="server">
            <ContentTemplate>        
                
            <asp:UpdateProgress ID="upgrs1" runat="server" AssociatedUpdatePanelID="upForgotPass" DynamicLayout="true">
                <ProgressTemplate> <img alt="" src="Images/Global/Indicator.gif" /> </ProgressTemplate>                        
            </asp:UpdateProgress>
            
            <asp:Panel runat="server" ID="succPassword" CssClass="Success" Visible="false">ŞİFRENİZ EMAIL ADRESİNİZE GÖNDERİLMİŞTİR</asp:Panel>
            <asp:Panel runat="server" ID="errPassword" CssClass="Error" Visible="false">ŞİFRENİZ GÖNDERİLEMEDİ !</asp:Panel>
            <asp:Panel runat="server" ID="errHasFirms" CssClass="Error" Visible="false">Girdiğiniz email adresi ile kayıtlı firma bulunamadı!</asp:Panel>
        
            <p>Email</p>
            <asp:TextBox runat="server" ID="txtForgotPassEmail" ValidationGroup="vgFirmForgotPass" MaxLength="120" />
            <asp:RequiredFieldValidator ID="reqFirmForgotPass" ErrorMessage="Email adresinizi giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtForgotPassEmail" ValidationGroup="vgFirmForgotPass"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rglFirmForgotPass" runat="server" ControlToValidate="txtForgotPassEmail" ErrorMessage="Geçerli bir email adresi giriniz !" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="vgFirmForgotPass" />

            <asp:ImageButton runat="server" ID="imgBtnForgotPassSend" 
                    ImageUrl="~/Images/Button/Send.jpg" ValidationGroup="vgFirmForgotPass" 
                    onclick="imgBtnForgotPassSend_Click" />

            </ContentTemplate>
        </asp:UpdatePanel>
    
        </asp:Panel>
    
    </div>

</div>