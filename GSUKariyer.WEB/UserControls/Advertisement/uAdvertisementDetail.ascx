<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uAdvertisementDetail.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Advertisement.uAdvertisementDetail" %>

<%@ Register src="~/UserControls/Common/uSendCv.ascx" tagname="uSendCv" tagprefix="uc1" %>

<div class="SubPage">

    <h1> <asp:Literal ID="ltrTitle" runat="server"></asp:Literal> </h1>
    
    <ins></ins>            
    
    <div class="JobDetailHeader">
    
        <asp:HyperLink runat="server" ID="hlCompany" NavigateUrl="#" ImageUrl="#"></asp:HyperLink>
        
        <dfn>Tarih:</dfn>
        <b> <asp:Literal ID="ltrAdvertisementDate" runat="server"></asp:Literal> </b>
        <br /><br />

        <dfn>Şehir / Ülke:</dfn>
        <b> <asp:Literal ID="ltrCityCountry" runat="server"></asp:Literal> </b>
        <br /><br />

        <dfn>Personel Sayısı:</dfn>
        <b> <asp:Literal ID="ltrEmployeesCount" runat="server"></asp:Literal> </b>
        <br /><br />

        <dfn>Pozisyon:</dfn>
        <b> <asp:Literal ID="ltrPosition" runat="server"></asp:Literal> </b>
        <br /><br />            
    
    </div>
    
    <ins></ins>   
    
    <div id="dvJobDetail">
    
    <div class="Panel">
        
        <h2><asp:Literal ID="ltrFirmName" runat="server"></asp:Literal></h2>
    
        <ins></ins>
        
        <b>Genel Nitelikler</b><br />
        <asp:Literal ID="ltlDetail" runat="server"></asp:Literal>
        <ins></ins>
        <b>İş Tanımı</b><br />
        <asp:Literal ID="ltlDescription" runat="server"></asp:Literal>
        
        <ins></ins>
        
        » <asp:HyperLink runat="server" ID="hlFirmDetail" NavigateUrl="#">Firma hakkında detaylı bilgi ve tüm ilanlarını görmek için tıklayınız</asp:HyperLink>
        
        <ins></ins>
        
        <uc1:uSendCv ID="uSendCv1" runat="server"/>
            
    </div>
    
    <ins></ins>
    
    <div class="JobDetailContent">
        <asp:HyperLink runat="server" ID="hlApply" ImageUrl="~/Images/Button/JobJoin.jpg" ToolTip="İlana Başvur" NavigateUrl="javascript:ShowHideChng('dvJobApply', 'dvJobDetail')"></asp:HyperLink>
    </div>

    </div>

    <asp:Panel CssClass="Panel" runat="server" ID="pnlJobHasApply" Visible="false" Style="display: none;">

        <h2>BAŞVURU DURUMU</h2>
    
        <ins></ins>
        
        Sayın <b><asp:Literal runat="server" ID="ltlName"></asp:Literal> <asp:Literal runat="server" ID="ltlSurname"></asp:Literal></b>
        <br /><br />
        Bu pozisyona daha önce 
            <b><asp:Literal runat="server" ID="ltlApplyDate"></asp:Literal></b>
         tarihinde 
            <b><asp:Literal runat="server" ID="ltlCvName"></asp:Literal></b>
          isimli özgeçmişinizle başvuru yapmışsınız! 
        <br /><br />
        Özgeçmişinizde yaptığınız değişiklikler daha önce başvurduğunuz firmalar tarafından da görülebilmektedir. 
        <br /><br />
        Yaptığınız başvuruları ve cevaplarını 
            <asp:HyperLink CssClass="Und" runat="server" ID="hlUserApplications" NavigateUrl="#">Başvurularım</asp:HyperLink> sayfasından takip edebilirsiniz.
        
    </asp:Panel>
    
    <div id="dvJobApply" class="Panel" style="display: none;">
        
        <h2>ONLINE BAŞVURU</h2>
    
        <ins></ins>
        
        <asp:UpdatePanel ID="upApply" runat="server">
            <ContentTemplate>
        
        <asp:UpdateProgress ID="uprgsApply" runat="server" AssociatedUpdatePanelID="upApply" DynamicLayout="true">
            <ProgressTemplate> <img alt="" src="Images/Global/Indicator.gif" /> </ProgressTemplate>
        </asp:UpdateProgress>
        
        <asp:PlaceHolder runat="server" ID="PHJobApplyForm">
        
        <div class="Form">
            
            <p>Önyazı</p>
            <asp:DropDownList runat="server" ID="ddlFrontPosts" AutoPostBack="true" OnSelectedIndexChanged="ddlFrontPosts_SelectedIndexChanged"></asp:DropDownList>
            
            <p>Ön yazı başlığı</p>
            <asp:TextBox runat="server" ID="txtFrontPostTitle" MaxLength="128" ValidationGroup="vgApply"></asp:TextBox>
            
            <p>Ön yazı metni</p>
            <asp:TextBox runat="server" ID="txtFrontPost" TextMode="MultiLine" Rows="5" MaxLength="1024" ValidationGroup="vgApply""></asp:TextBox>
            
            <dfn>Önyazılarım sayfasından kayıtlı ön yazı şablonlarından birini seçip üzerinde düzeltme yapabilir ya da ön yazınızı bu sayfada oluşturabilirsiniz.</dfn>
            
            <br /><br />
            
            <p>Özgeçmiş Seçimi</p>
            
            <asp:PlaceHolder runat="server" ID="phCvSelect">
                <asp:DropDownList runat="server" ID="ddlCvs" ValidationGroup="vgApply"></asp:DropDownList>            
                <dfn>Bu ilana başvurmak için kullanacağınız özgeçmişinizi seçmelisiniz. Şu anda kullanmakta olduğunuz özgeçmişiniz seçili olarak gelecektir.</dfn>
            </asp:PlaceHolder>
            
            <asp:Panel runat="server" ID="pnlNoCv" CssClass="Error" Visible="false">
                KAYITLI ÖZGEÇMİŞİNİZ BULUNMAMAKTADIR !                                
            </asp:Panel>
            <br />
            <asp:HyperLink CssClass="CvCreate" ID="hlCvCreate" runat="server" ToolTip="Yeni Cv oluştur" Visible="false"></asp:HyperLink>
            
        </div>
        
        <ins></ins>        
        
        <asp:ImageButton runat="server" ID="imgBtnApply1" ImageUrl="~/Images/Button/JobJoin.jpg" OnClick="imgBtnApply_Click" ToolTip="İlana Başvur" ValidationGroup="vgApply" />
        
        <ins></ins><ins></ins>
        
        « <asp:HyperLink runat="server" ID="hlBackJobDetail" NavigateUrl="javascript:ShowHideChng('dvJobDetail', 'dvJobApply')">İlana geri dön</asp:HyperLink>
                
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="PHJobApplyFinish" Visible="false">
        
            <asp:Panel runat="server" ID="succApply" CssClass="Success">
                İLANA BAŞVURUNUZ YAPILMIŞTIR.
                <br />
                Başvurunuz gönderilmiştir. Başvurunuzun sonucunu "<asp:HyperLink CssClass="Und" runat="server" ID="hlUserApplication2" NavigateUrl="#">Başvurularım</asp:HyperLink>" sayfasından takip edebilirsiniz.
            </asp:Panel>
            
            <asp:Panel runat="server" ID="errApply" CssClass="Error">BAŞVURU YAPILAMADI !</asp:Panel>
        
        </asp:PlaceHolder>
        
            </ContentTemplate>
        </asp:UpdatePanel>        
        
        <ins></ins>
        
    </div>        
    
</div>
