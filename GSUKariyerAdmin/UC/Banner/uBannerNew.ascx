<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uBannerNew.ascx.cs" Inherits="UC_Banner_uBannerNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UC/Common/Error.ascx" tagname="uError" tagprefix="uc1" %>
<%@ Register src="~/UC/Common/Success.ascx" tagname="uSuccess" tagprefix="uc2" %>
<%@ Register src="~/UC/Common/Languages.ascx" tagname="Languages" tagprefix="uc3" %>
<%@ Register src="~/UC/Common/BannerPositions.ascx" tagname="BannerPositions" tagprefix="uc4" %>

<div class="fW1">

    <uc2:uSuccess ID="uSuccess1" runat="server" Visible="false" Title="YENİ BANNER EKLENDİ" Desc="Yeni banner eklenmiştir" />
    <uc2:uSuccess ID="uSuccess2" runat="server" Visible="false" Title="Banner güncellenmiştir" Desc="Banner güncellenmiştir" />    

    <uc1:uError ID="uError1" runat="server" Visible="false" Title="KAYIT EDİLMEDİ" Desc="Kayıt yapılırken hata oluştu" />

<asp:Panel runat="server" ID="pnlForm">

    <asp:RequiredFieldValidator ID="rqBannerTitle" runat="server" ErrorMessage="Banner başlığını giriniz !" ControlToValidate="txtBannerTitle" SetFocusOnError="true" Display="None"  ValidationGroup="vgBannerNew" />
    <asp:RequiredFieldValidator ID="rqBannerURL" runat="server" ErrorMessage="URL giriniz !" ControlToValidate="txtURL" SetFocusOnError="true" Display="None"  ValidationGroup="vgBannerNew" />
    <asp:RequiredFieldValidator ID="rqBannerStartDate" runat="server" ErrorMessage="Gösterime başlama tarihini giriniz !" ControlToValidate="txtStartDate" SetFocusOnError="true" Display="None"  ValidationGroup="vgBannerNew" />
    <asp:RequiredFieldValidator ID="rqBannerEndDate" runat="server" ErrorMessage="Gösterim bitiş tarihini giriniz !" ControlToValidate="txtEndDate" SetFocusOnError="true" Display="None"  ValidationGroup="vgBannerNew" />
    
<asp:RequiredFieldValidator ID="rqFile" runat="server" ErrorMessage="Dosya seçiniz!" ControlToValidate="fuFile" SetFocusOnError="true" Display="None" ValidationGroup="vgBannerNew" />
<asp:RegularExpressionValidator ID="rexFile" runat="server"
                 ValidationExpression="(.*\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG]|[pP][nN][gG]|[sS][wW][fF])$)"
                 ControlToValidate="fuFile"
                 Display="None"
                 SetFocusOnError="true"
                 ErrorMessage="Lütfen geçerli bir dosya seçiniz !"
                 ValidationGroup="vgBannerNew" />    
    
    <asp:ValidationSummary ID="ValSum" runat="server" CssClass="Validate" ShowSummary="true" ValidationGroup="vgBannerNew" />
            
    <h2>BANNER KAYDI</h2>
    
    <div class="Form">

    <asp:Panel runat="server" ID="pnlFilePreview" Visible="false">
        
        <asp:Image runat="server" ID="imgFile" Visible="false" ImageUrl="#" />        
        
        <div id="flSpotBanner"></div>
        <script type="text/javascript">
            var bannerSwfPath = '<%=this.bannerSwfPath %>';
            var fo = new SWFObject(bannerSwfPath, "flNews", "500", "280", "8", "#000000", true);
            fo.addParam("wmode", "transparent");
            fo.addParam('allowScriptAccess', 'always');
            fo.addVariable("hostURL", "http://www.yapikredi.com.az/");
            if(bannerSwfPath != "") fo.write("flSpotBanner");
        </script>
        
        <br /><br />
        
    </asp:Panel>        

    Banner dilini seçiniz
    <uc3:Languages ID="Languages1" runat="server" />

    <p>Banner pozisyonunu seçiniz</p>
    <uc4:BannerPositions ID="BannerPositions" runat="server" />

    <p>Banner başlığını giriniz</p>
    <asp:TextBox CssClass="TextBox" runat="server" ID="txtBannerTitle" MaxLength="128"></asp:TextBox>

    <p>URL</p>
    <asp:TextBox CssClass="TextBox" runat="server" ID="txtURL" MaxLength="512"></asp:TextBox>
    
    <p>Gösterime başlangıç tarihi</p>
    <cc1:CalendarExtender ID="ajBannerStarDate" runat="server" TargetControlID="txtStartDate" Format="dd/MM/yyyy" Animated="false"></cc1:CalendarExtender>
    <asp:TextBox ID="txtStartDate" runat="server" CssClass="TextBox" ValidationGroup="vgBannerNew" />
    
    <p>Gösterim bitiş tarihi</p>
    <cc1:CalendarExtender  ID="ajBannerEndDate" runat="server" TargetControlID="txtEndDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
    <asp:TextBox CssClass="TextBox" runat="server" ID="txtEndDate" />

    <p>Dosyayı Seçiniz</p>
    <asp:FileUpload ID="fuFile" runat="server" CssClass="TextBox" />

    <br />
    
    <asp:RadioButton runat="server" ID="rdIsNewPage" GroupName="rdGrIsNewPage" Text="Aynı sayfada aç" Checked="true" />
    <asp:RadioButton runat="server" ID="rdNoIsNewPage" GroupName="rdGrIsNewPage" Text="Yeni sayfada aç" />
    
    <br /><br />
    
    <asp:RadioButton runat="server" ID="rdActive" GroupName="rdGrActive" Text="Gösterimde" Checked="true" />
    <asp:RadioButton runat="server" ID="rdInactive" GroupName="rdGrActive" Text="Beklemede" />

    <asp:HiddenField runat="server" ID="hdBannerID" Value="0" />
    <asp:HiddenField runat="server" ID="hdBannerFileName" Value="" />

    </div>
    
    <div class="FormFooter">
        <asp:Button runat="server" ID="btnSend" CssClass="Button" Text="KAYDET" ValidationGroup="vgBannerNew" onclick="btnSend_Click" />
    </div>
                        
</asp:Panel>

</div>