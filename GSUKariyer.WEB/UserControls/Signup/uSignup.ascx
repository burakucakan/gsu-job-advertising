<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uSignup.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Signup.uSignup" %>

<%@ Register Assembly="CalendarExtenderPlus" Namespace="AjaxControlToolkitPlus" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/UserControls/SiteParamControls/uCountries.ascx" tagname="uCountries" tagprefix="uc2" %>
<%@ Register src="~/UserControls/SiteParamControls/uCities.ascx" tagname="uCities" tagprefix="uc3" %>

<div class="SubPage">

    <h1>üyelik başvuru formu</h1>
    
    <ins></ins>
    
    <div class="SignupInfo">
        
        <img alt="" src="Images/Screen/NewUser.jpg" />
        
        <br /><br />

        <b>GSUKariyer.com ÜYELİĞİ HAKKINDA</b>
        <br />
        Galatasaray Üniversitesi Öğrenci Konseyi çatısı altında oluşturduğumuz GSUKariyer.com projesi, 
        Türkiye’nin önde gelen firmaları ve Galatasaray Üniversitesi öğrencileri arasında sağlam bir köprü kurmak amacıyla yola çıktı.
        <br /><br />
        GSUKariyer.com üzerinden şirketlerin staj, part time, full time ya da yurt dışı staj duyuruları yapılmaktadır. 
        <br /><br />
        Size özel olarak ayırdığımız hesabınız sayesinde şirketlerin ilanlarına direkt olarak başvurabilme veya dilediğiniz şirkete 
        cv gönderebilme imkanına sahipsiniz. 
        <br /><br />
        İş ve staj başvurusu yapmak hiç bu kadar kolay olmamıştı! Tek yapmanız gereken üyeliğinizi aktive etmek ve GSUKariyer.com'da 
        yerinizi almak!
        
        <br /><br /><br />
        
        <asp:Panel runat="server" ID="pnlLoginOff" CssClass="LoginAreaOff">

            <a class="aLogin" href="javascript:Login()">üye girişi</a>

        </asp:Panel>
        
    </div>
    
    <div class="SignupForm">
        
        <asp:Panel runat="server" ID="succSave" CssClass="Success" Visible="false">
        
            ÜYELİK BAŞVURUNUZ TAMAMLANMIŞTIR. <br /><br />
            
            Galatasaray Üniversitesi öğrenci veritabanında kayıtlı bulunan 
            <asp:HyperLink runat="server" ID="hlActivateEmail" NavigateUrl="mailto:">a@b.com</asp:HyperLink> 
            adresine aktivasyon maili gönderilmiştir. Aktivasyon linkine tıklayarak üyelik sürecini tamamlayabilirsiniz.
            
            <br /><br />
            ! Eğer kayıtlı mail hesabınıza erişemiyorsanız, lütfen "Öğrenci Konseyi Kariyer Komitesi" ile görüşünüz         
            
        </asp:Panel>         

        <asp:Panel runat="server" ID="succSaveEmailNotSend" CssClass="Success" Visible="false">
        
            ÜYELİK BAŞVURUNUZ KISMEN TAMAMLANDI. <br /><br />
            
            Üyeliğinizi aktifleştirmek için Galatasaray Üniversitesi öğrenci veritabanında kayıtlı bulunan 
            <asp:HyperLink runat="server" ID="hlActivateEmail2" NavigateUrl="mailto:">a@b.com</asp:HyperLink> 
            adresine aktivasyon maili gönderilemedi.
            
            <br /><br />
            <b>! Lütfen "Öğrenci Konseyi Kariyer Komitesi" ile görüşünüz</b>
            
        </asp:Panel>  

        <asp:Panel runat="server" ID="succUpdate" CssClass="Success" Visible="false">
        
            ÜYELİK BİLGİLERİNİZ GÜNCELLENMİŞTİR <br />
            
        </asp:Panel>  

        <asp:Panel runat="server" ID="errHasUser" CssClass="Error" Visible="false">BU ÖĞRENCİ NUMARASI İLE DAHA ÖNCE KAYIT YAPILMIŞ</asp:Panel>
        <asp:Panel runat="server" ID="errSave" CssClass="Error" Visible="false">HATA OLUŞTU ! ÜYE KAYIT EDİLEMEDİ</asp:Panel>
        <asp:Panel runat="server" ID="errGsuStudent" CssClass="Error" Visible="false">ÖĞRENCİ VERİTABANIMIZDA GİRDİĞİNİZ ÖĞRENCİ NUMARASINA AİT KAYIT BULUNAMADI</asp:Panel>
        
        <asp:Panel runat="server" ID="pnlForm" class="Form">                        

            <p>Adınız</p>
            <asp:TextBox runat="server" ID="txtName" ValidationGroup="vgSignup" MaxLength="64"></asp:TextBox>
            <asp:RequiredFieldValidator ID="req1" ErrorMessage="Lütfen adınızı giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="vgSignup"></asp:RequiredFieldValidator>

            <p>Soyadınız</p>
            <asp:TextBox runat="server" ID="txtSurname" ValidationGroup="vgSignup" MaxLength="64"></asp:TextBox>        
            <asp:RequiredFieldValidator ID="req2" ErrorMessage="Lütfen soyadınızı giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtSurname" ValidationGroup="vgSignup"></asp:RequiredFieldValidator>

            <p>TC Kimlik Numaranız</p>
            <asp:TextBox runat="server" ID="txtNationalId" ValidationGroup="vgSignup" MaxLength="11" onkeyup="vNumber(this)"></asp:TextBox>
            <asp:RequiredFieldValidator ID="req3" ErrorMessage="Lütfen TC Kimlik numaranızı giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtNationalId" ValidationGroup="vgSignup"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvNational" runat="server" Display="Dynamic" ControlToValidate="txtNationalId" ClientValidationFunction="cvNational" ErrorMessage="TC Kimlik numaranız 11 karakter olmalıdır" ValidationGroup="vgSignup" />

            <p>Email</p>
            <asp:TextBox runat="server" ID="txtEmail" ValidationGroup="vgSignup" MaxLength="120" />
            <asp:RequiredFieldValidator ID="req4" ErrorMessage="Email adresinizi giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtEmail" ValidationGroup="vgSignup"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rglEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Geçerli bir email adresi giriniz !" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ValidationGroup="vgSignup" EnableClientScript="true" />
 
            <p>Şifreniz</p>
            <asp:TextBox runat="server" ID="txtPassword" MaxLength="20" TextMode="Password" ValidationGroup="vgSignup" />
            <asp:RequiredFieldValidator ID="reqPass" ErrorMessage="Şifrenizi giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPassword" ValidationGroup="vgSignup"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvPass" runat="server" Display="Dynamic" ControlToValidate="txtPassword" ClientValidationFunction="cvPassCtrl" ErrorMessage="Şifreniz en az 5 karakter olmalıdır !" ValidationGroup="vgSignup" />
            <asp:HiddenField runat="server" ID="hdPassword" />
            
            <p>Şifreniz(Tekrar)</p>
            <asp:TextBox runat="server" ID="txtPassword2" MaxLength="20" TextMode="Password" ValidationGroup="vgSignup" />
            <asp:RequiredFieldValidator ID="reqPass2" ErrorMessage="Şifre tekrarını giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPassword2" ValidationGroup="vgSignup"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cpvPassword" runat="server" ErrorMessage="Girdiğiniz şifreler birbirine uymuyor !" ControlToValidate="txtPassword" ControlToCompare="txtPassword2" Display="Dynamic" ValidationGroup="vgSignup" />
                
            <p>Öğrenci Numaranız</p>
            <asp:TextBox runat="server" ID="txtStudentNumber" ValidationGroup="vgSignup" MaxLength="8" onkeyup="vNumber(this)"></asp:TextBox>
            <asp:RequiredFieldValidator ID="req7" ErrorMessage="Lütfen Öğrenci Numaranızı Giriniz" runat="server" Display="Dynamic" ControlToValidate="txtStudentNumber" ValidationGroup="vgSignup"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvStudentNumber" runat="server" Display="Dynamic" ControlToValidate="txtStudentNumber" ClientValidationFunction="cvStudentNumber" ErrorMessage="Öğrenci numaranız 8 karakter olmalıdır" ValidationGroup="vgSignup" />

            <p>Doğum tarihiniz</p>
            <asp:TextBox runat="server" ID="txtBirthdate" ValidationGroup="vgSignup" MaxLength="20" onkeydown="return false"></asp:TextBox>
            <ajaxToolkit:CalendarExtenderPlus runat="server" ID="ceBirthDate" TargetControlID="txtBirthdate" Format="d MMMM yyyy" ShowDdlHeader="true" DdlMaxNumberOfYears="30" />
            <asp:RequiredFieldValidator ValidationGroup="vgSignup" runat="server" ID="reqBirthDate" ErrorMessage="Lütfen doğum tarihinizi giriniz" ControlToValidate="txtBirthdate" />
        
            <asp:UpdatePanel ID="upCountryCity" runat="server" >
                <ContentTemplate>
            
            <p>Ülke</p>
            <uc2:uCountries ID="uCountries1" runat="server" ValidationErrorMessage="Lütfen ülke seçiniz" ValidationGroup="vgSignup" DropDownViewStateEnabled="false" ValidationRequired="true" ShowAll="false"/>
                
            <p>Şehir</p>
            <uc3:uCities ID="uCities1" runat="server" ValidationErrorMessage="Lütfen şehir seçiniz" ValidationGroup="vgSignup" DropDownViewStateEnabled="false" ValidationRequired="true" ShowAll="false"/>

                </ContentTemplate>
            </asp:UpdatePanel>
            
            <p>Adres</p>
            <asp:RequiredFieldValidator ID="reqAddress" ErrorMessage="Lütfen Adresinizi Giriniz" runat="server" Display="Dynamic" CssClass="errTextArea" ControlToValidate="txtAddress" ValidationGroup="vgSignup"></asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtAddress"  MaxLength="255" TextMode="MultiLine" Height="40" />            

            <p>Cinsiyet</p>
            <asp:RadioButton runat="server" ID="rdMale" GroupName="rdGender" Text="Erkek" Checked="true" />
            <asp:RadioButton runat="server" ID="rdFemale" GroupName="rdGender" Text="Kadın" />                        
                        
            <br /><br />

            <asp:ImageButton runat="server" ID="imgBtnSend" 
                ImageUrl="~/Images/Button/Send.jpg" ValidationGroup="vgSignup" 
                OnClick="imgBtnSend_Click"  />


        </asp:Panel>
                                
    </div>
          
</div>