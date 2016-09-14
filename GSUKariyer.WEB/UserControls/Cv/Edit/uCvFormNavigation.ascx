<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCvFormNavigation.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uCvFormNavigation" %>
<%@ Register
Assembly="AjaxControlToolkit"
Namespace="AjaxControlToolkit"
TagPrefix="ajaxToolkit" %>

    <div class="CvFormNavigation">
    
<ajaxToolkit:Accordion ID="accCV" runat="server" SelectedIndex="1" FadeTransitions="true" 
FramesPerSecond="40" TransitionDuration="150" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="false">
   <Panes>
    
    <ajaxToolkit:AccordionPane ID="accCV_Welcome" runat="server">
        <Header>
            <asp:LinkButton ID="lbtnWelcome" Cssclass="aGroup" runat="server" Text="HOŞGELDİNİZ" OnClick="MenuItem_Click" CommandArgument="1"></asp:LinkButton>
        </Header>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accCV_PersonalInfo" runat="server">
        <Header>
            <a class="aGroup" href="javascript:;">KİŞİSEL BİLGİLER</a>
        </Header>
        <Content>
            <b><asp:LinkButton runat="server" ID="lbtnPersonalInfo" OnClick="MenuItem_Click" CommandArgument="2">Kişisel Bilgilerim</asp:LinkButton></b><br />
            <b><asp:LinkButton runat="server" ID="lbtnContactInfo" OnClick="MenuItem_Click" CommandArgument="3">İletişim Bilgilerim</asp:LinkButton></b><br />
            <b><asp:LinkButton runat="server" ID="lbtnCityCountryInfo" OnClick="MenuItem_Click" CommandArgument="4">Şehir/Ülke Tercihim</asp:LinkButton></b><br />
            <asp:LinkButton runat="server" ID="lbtnCigaretteUsage" OnClick="MenuItem_Click" CommandArgument="5">Sigara Kullanımı</asp:LinkButton><br />
            <asp:LinkButton runat="server" ID="lbtnSocialClubs" OnClick="MenuItem_Click" CommandArgument="6">Üye Olunan Topluluklar, Kulüpler</asp:LinkButton><br />
        </Content>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accCV_EducationInfo" runat="server">
        <Header>
            <a class="aGroup" href="javascript:;">EĞİTİM BİLGİLERİ</a>
        </Header>
        <Content>
            <b><asp:LinkButton runat="server" ID="lbtnEducationState" OnClick="MenuItem_Click" CommandArgument="7">Eğitim Durumu</asp:LinkButton></b><br />
            <b><asp:LinkButton runat="server" ID="lbtnMasterInfo" OnClick="MenuItem_Click" CommandArgument="8">Lisans Üstü Bilgileri</asp:LinkButton></b><br />
            <b><asp:LinkButton runat="server" ID="lbtnUniversityInfo" OnClick="MenuItem_Click" CommandArgument="9">Lisans Bilgileri</asp:LinkButton></b><br />
            <b><asp:LinkButton runat="server" ID="lbtnHighSchoolInfo" OnClick="MenuItem_Click" CommandArgument="10">Lise Bilgileri</asp:LinkButton></b><br />
            <b><asp:LinkButton runat="server" ID="lbtnLanguageInfo" OnClick="MenuItem_Click" CommandArgument="11">Yabancı Dil</asp:LinkButton></b><br />
            <asp:LinkButton runat="server" ID="lbtnComputerInfo" OnClick="MenuItem_Click" CommandArgument="12">Bilgisayar Bilgileri</asp:LinkButton><br />
            <asp:LinkButton runat="server" ID="lbtnCertificateInfo" OnClick="MenuItem_Click" CommandArgument="13">Sertifika Bilgileri</asp:LinkButton><br />
            <asp:LinkButton runat="server" ID="lbtnExamInfo" OnClick="MenuItem_Click" CommandArgument="14">Sınav Bilgileri</asp:LinkButton><br />
            <asp:LinkButton runat="server" ID="lbtnCourseInfo" OnClick="MenuItem_Click" CommandArgument="15">Alınan Eğitimler</asp:LinkButton><br />
            <b><asp:LinkButton runat="server" ID="lbtnDrivingLicense" OnClick="MenuItem_Click" CommandArgument="16">Sürücü Belgesi</asp:LinkButton></b><br />
        </Content>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accCV_WorkExperienceInfo" runat="server">
        <Header>
            <a class="aGroup" href="javascript:;">İŞ TECRÜBELERİ</a>
        </Header>
        <Content>
            <b><asp:LinkButton runat="server" ID="lbtnInterestedJobPositions" OnClick="MenuItem_Click" CommandArgument="17">İlgilendiğim Pozisyonlar</asp:LinkButton></b><br />
            <b><asp:LinkButton runat="server" ID="lbtnWorkExperiences" OnClick="MenuItem_Click" CommandArgument="18">İş Tecrübelerim</asp:LinkButton></b><br />
            <asp:LinkButton runat="server" ID="lbtnReferances" OnClick="MenuItem_Click" CommandArgument="19">Referanslar</asp:LinkButton><br />
        </Content>
    </ajaxToolkit:AccordionPane>

    <ajaxToolkit:AccordionPane ID="accCV_State" runat="server">
        <Header>
            <asp:LinkButton Cssclass="aGroup" ID="lbtnCvState" runat="server" Text="CV DURUMU" OnClick="MenuItem_Click" CommandArgument="20"></asp:LinkButton>
        </Header>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accCV_Photo" runat="server">
        <Header>
            <asp:LinkButton Cssclass="aGroup" ID="lbtnPhoto" runat="server" Text="FOTOĞRAF" OnClick="MenuItem_Click" CommandArgument="21"></asp:LinkButton>
        </Header>
    </ajaxToolkit:AccordionPane>
    
    </Panes>
</ajaxToolkit:Accordion>


<asp:HyperLink ID="hlCvDetail" runat="server" ImageUrl="~/Images/Button/CvView.jpg"></asp:HyperLink>

</div>