<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uUsersImport.ascx.cs" Inherits="UC_Users_uUsersImport" %>

<%@ Register src="../Common/Error.ascx" tagname="Error" tagprefix="uc1" %>
<%@ Register src="../Common/Success.ascx" tagname="Success" tagprefix="uc2" %>

<div class="fW1">

    <uc1:Error ID="Error1" runat="server" Visible="false" Title="Hata!" />
    <uc2:Success ID="Success1" runat="server" Visible="false" Title="İşlem başarıyla tamamlanmıştır." />
   
<asp:Panel runat="server" ID="pnlForm">

        
<asp:RequiredFieldValidator ID="rqFile" runat="server" ErrorMessage="Dosya seçiniz!" ControlToValidate="fuUserList" SetFocusOnError="true" Display="None" ValidationGroup="vgUserImport" />

    <asp:ValidationSummary ID="ValSum" runat="server" CssClass="Validate" ShowSummary="true" ValidationGroup="vgUserImport" />
            
    <h2>YENİ ÜYE LİSTESİ YÜKLE</h2>
    
    <div class="Form">
    <p>
     Yükleme işlemi mevcut bütün kayıtları siler. <br /><asp:HyperLink id="hLinkUploadFile" runat="server" Text="Öncelikle mevcut kayıtları yüklemek için tıklayınız."></asp:HyperLink> <br /><br />
    
     Excel dosyası 2 kolondan oluşması gerekir. İlk satırı başlıkların bulunduğu satır olarak kabul eder ve aktarıma dahil etmez.<br /><br />
        Öğrenci No (Maks 15 karakter) <br />
        Email (Maks 1000 karakter, emailler arasına ";" koyunuz.)
        <br /><br />
    </p>

    <p>Excel dosyasını seçiniz</p>
    <asp:FileUpload ID="fuUserList" runat="server" />

    </div>
    
    <div class="FormFooter">
        <asp:Button id="btnUpload" runat="server" Text="Yükle" onclick="btnUpload_Click" ValidationGroup="vgUserImport" CssClass="Button"/>
    </div>
</asp:Panel>
</div>






