<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFirmSignup.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uFirmSignup" %>

<%@ Register src="~/UserControls/SiteParamControls/uSectors.ascx" tagname="uSectors" tagprefix="uc1" %>
<%@ Register src="~/UserControls/SiteParamControls/uCountries.ascx" tagname="uCountries" tagprefix="uc2" %>
<%@ Register src="~/UserControls/SiteParamControls/uCities.ascx" tagname="uCities" tagprefix="uc3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<div class="SubPage">

    <h1>firma üyelik başvurusu</h1>
    
    <ins></ins>
    
    <div class="Panel">                

        <b>GSUKariyer.com ÜYELİĞİ HAKKINDA</b>
        <br />
        GSUKariyer.com’da  bir kariyer sitesinde bulabileceğiniz tüm özelliklerin yanı sıra şirketiniz ile  
        Galatasaray Üniversitesi öğrenci ve mezunları arasında köprü kurma ayrıcalığına erişirsiniz.  
        <br />
        GSUKariyer.com projesini şirketinizin üniversite içindeki gözü ve kulağı olarak değerlendirebilirsiniz. 
        <br />
        Sistemimizde açacağınız hesap vasıtasıyla dilediğiniz özelliklere göre stajyer ve eleman bulabilecek, 
        şirketinizdeki iş ve staj imkanlarını duyurabilecek ve ilan verebileceksiniz.
        <br />
        Üniversite içerisindeki etkinliklerden haberdar olacak, öğrencilerle iş dünyasını buluşturacak organizasyonlarda, 
        kariyer ve innovasyon günlerinde yer alma şansı kazanacaksınız. 
        <br />
        Dahası, sistemimiz sizden hiçbir ücret talep etmeksizin siz Türkiye’nin önde gelen şirketleriyle Galatasaray Üniversitesi 
        camiasını buluşturmak gayesiyle çalışmaktadır.
        <br />
        GSUKariyer.com, işinizi kolaylaştırmak için her şeyi düşündü. Gelin aramıza katılın; bu ayrıcalıklar dünyasında siz de 
        yerinizi alın!

    </div>
    
    <ins></ins>

    <asp:Panel runat="server" ID="succSave" CssClass="Success" Visible="false">
    
        ÜYELİK BAŞVURUNUZ TAMAMLANMIŞTIR.
        <br /><br />
        
        Galatasaray Üniversitesi "Öğrenci konseyi kariyer komitesi" bilgilerinizi kontrol edip sizinle iletişime geçecektir.
        
    </asp:Panel>

    <asp:Panel runat="server" ID="succUpdate" CssClass="Success" Visible="false">ÜYELİK BİLGİLERİNİZ GÜNCELLENMİŞTİR</asp:Panel>
    <asp:Panel runat="server" ID="succDelLogo" CssClass="Success" Visible="false">LOGO SİLİNMİŞTİR</asp:Panel>
    
    <asp:Panel runat="server" ID="errLogo" CssClass="Error" Visible="false">LOGO YÜKLENEMEDİ !</asp:Panel>
    <asp:Panel runat="server" ID="errDelLogo" CssClass="Error" Visible="false">LOGO SİLİNEMEDİ !</asp:Panel>

    <asp:Panel runat="server" ID="errHasUser" CssClass="Error" Visible="false">BU EMAIL ADRESİ İLE DAHA ÖNCE KAYIT YAPILMIŞ</asp:Panel>
    <asp:Panel runat="server" ID="errSave" CssClass="Error" Visible="false">HATA OLUŞTU ! BAŞVURUNUZ KAYIT EDİLEMEDİ</asp:Panel>

    <ins></ins>
    
                
    <asp:Panel runat="server" ID="pnlForm">
    
    <div class="SignupForm">
    
        <div class="Form">

            <b>FİRMA LOGOSU</b>
            
            <asp:Panel runat="server" ID="pnlLogo" Visible="false">
                <ins></ins>
                <asp:Image runat="server" ID="imgLogo" ImageUrl="#" />
                <br />
                <asp:LinkButton runat="server" ID="lnkDelLogo" Text="[ Logoyu Kaldır ]" OnClick="lnkDelLogo_Click"></asp:LinkButton>
                <br />
            </asp:Panel>
            
            <p>Logonuzu Yükleyin</p>
            <asp:FileUpload ID="fuLogo" runat="server" ValidationGroup="vgFirmSignup" />
            <asp:RegularExpressionValidator ID="rexLogo" runat="server"
                 ValidationExpression="(.*\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG])$)"
                 ControlToValidate="fuLogo"
                 Display="Dynamic"
                 SetFocusOnError="true"
                 ErrorMessage="Lütfen doğru bir resim seçiniz (JPG, GIF) !"
                 ValidationGroup="vgFirmSignup" />            
            
            <br /><br />
        
            <b>YETKİLİ BİLGİLERİ</b>

            <p>Adı</p>
            <asp:TextBox runat="server" ID="txtFirmUserName" ValidationGroup="vgFirmSignup" MaxLength="64"></asp:TextBox>        
            <asp:RequiredFieldValidator ID="reqFirmUserName" ErrorMessage="Lütfen yetkili adını giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtFirmUserName" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>

            <p>Soyadı</p>
            <asp:TextBox runat="server" ID="txtFirmUserSurname" ValidationGroup="vgFirmSignup" MaxLength="64"></asp:TextBox>        
            <asp:RequiredFieldValidator ID="reqFirmUserSurname" ErrorMessage="Lütfen yetkili soyadınızı giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtFirmUserSurname" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>

            <p>Şirketteki pozisyonu</p>
            <asp:TextBox runat="server" ID="txtPosition" ValidationGroup="vgFirmSignup" MaxLength="255"></asp:TextBox>        
            <asp:RequiredFieldValidator ID="reqPosition" ErrorMessage="Lütfen şirketteki pozisyonunu giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPosition" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>

            <p>Telefon</p>
            <asp:TextBox runat="server" ID="txtPhone" ValidationGroup="vgFirmSignup" MaxLength="13"></asp:TextBox>        
            <asp:RequiredFieldValidator ID="reqPhone" ErrorMessage="Lütfen telefon numarasını giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPhone" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>

            <p class="Free">Fax</p>
            <asp:TextBox runat="server" ID="txtFax" ValidationGroup="vgFirmSignup" MaxLength="13"></asp:TextBox>

            <p>Email</p>
            <asp:TextBox runat="server" ID="txtEmail" ValidationGroup="vgFirmSignup" MaxLength="120" />
            <asp:RequiredFieldValidator ID="reqEmail" ErrorMessage="Email adresinizi giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtEmail" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rglEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Geçerli bir email adresi giriniz !" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="vgFirmSignup" />
 
            <p>Şifreniz</p>
            <asp:TextBox runat="server" ID="txtPassword" MaxLength="20" TextMode="Password" ValidationGroup="vgFirmSignup" />
            <asp:RequiredFieldValidator ID="reqPassword" ErrorMessage="Şifrenizi giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPassword" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvPassword" runat="server" Display="Dynamic" ControlToValidate="txtPassword" ClientValidationFunction="cvPassCtrl" ErrorMessage="Şifreniz en az 5 karakter olmalıdır !" ValidationGroup="vgFirmSignup" />
            <asp:HiddenField runat="server" ID="hdPassword" />
            
            <p>Şifreniz(Tekrar)</p>
            <asp:TextBox runat="server" ID="txtPassword2" MaxLength="20" TextMode="Password" ValidationGroup="vgFirmSignup" />
            <asp:RequiredFieldValidator ID="reqPassword2" ErrorMessage="Şifre tekrarını giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPassword2" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Girdiğiniz şifreler birbirine uymuyor !" ControlToValidate="txtPassword" ControlToCompare="txtPassword2" Display="Dynamic" ValidationGroup="vgFirmSignup" />
                
            
            <br />

            <asp:ImageButton runat="server" ID="imgBtnSend" 
                ImageUrl="~/Images/Button/Send.jpg" ValidationGroup="vgFirmSignup" 
                onclick="imgBtnSend_Click" />        
        
        </div>
    
    </div>
    
    <div class="SignupForm">       
        
        <div class="Form">

            <asp:HiddenField runat="server" ID="hdFirmUserId" />

            <b>FİRMA BİLGİLERİ</b>
            
            <p>Firma ünvanı</p>
            <asp:TextBox runat="server" ID="txtName" ValidationGroup="vgFirmSignup" MaxLength="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqName" ErrorMessage="Lütfen firma ünvanını giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>

            <p>Sektör</p>
            <uc1:uSectors ID="USectors1" runat="server" ValidationRequired="true" ValidationGroup="vgFirmSignup" ValidationErrorMessage="Lütfen sektörü seçiniz" />

            <p>Çalışan sayısı</p>
            <asp:DropDownList runat="server" ID="ddlWorkerCount">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqWorkerCount" ErrorMessage="Lütfen çalışan sayısını seçiniz" runat="server" Display="Dynamic" SetFocusOnError="true" InitialValue="-1" ControlToValidate="ddlWorkerCount" ValidationGroup="vgFirmSignup"></asp:RequiredFieldValidator>

            <p class="Free">Adres</p>
            <asp:TextBox runat="server" ID="txtAddress" ValidationGroup="vgFirmSignup" MaxLength="255" TextMode="MultiLine" Height="40" />
 
            <p class="Free">Posta kodu</p>
            <asp:TextBox runat="server" ID="txtZipcode" MaxLength="6" ValidationGroup="vgFirmSignup" />
            
            <asp:UpdatePanel ID="upCountryCity" runat="server">
                <ContentTemplate>
            
            <p>Ülke</p>
            <uc2:uCountries ID="uCountries1" runat="server" ValidationErrorMessage="Lütfen ülke seçiniz" ValidationGroup="vgFirmSignup" ValidationRequired="true" ShowAll="false"/>
                
            <p>Şehir</p>
            <uc3:uCities ID="uCities1" runat="server" ValidationErrorMessage="Lütfen şehir seçiniz" ValidationGroup="vgFirmSignup" ValidationRequired="true" ShowAll="false"/>

                </ContentTemplate>
            </asp:UpdatePanel>

            <p class="Free">Web sayfası</p>
            <asp:TextBox runat="server" ID="txtWebPage" ValidationGroup="vgFirmSignup" MaxLength="128"></asp:TextBox>
            
            <p class="Free">Firmanız hakkında</p>
            <asp:TextBox runat="server" ID="txtDescription" ValidationGroup="vgFirmSignup" MaxLength="2000" TextMode="MultiLine" Height="170" />
            
        </div>
                                
    </div>
    
    </asp:Panel>

</div>