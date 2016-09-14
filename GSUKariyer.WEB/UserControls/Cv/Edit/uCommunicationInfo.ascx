<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCommunicationInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uCommunicationInfo" %>

<%@ Register src="../../Common/uPhoneNumber.ascx" tagname="uPhoneNumber" tagprefix="uc2" %>
<%@ Register src="../../SiteParamControls/uContactTypes.ascx" tagname="uContactTypes" tagprefix="uc3" %>

<div class="CvFormContent">

    <b>İLETİŞİM BİLGİLERİM</b>
    
    <br /><br />
    
    <div class="Form">
        <p><asp:Literal ID="ltrHomePhone" runat="server" Text="Ev Telefonu"></asp:Literal></p>
            <uc2:uPhoneNumber ID="uHomePhoneNumber" runat="server" ValidationGroup="vgContactInfo" ValidationRequired="true" />
            
        <p><asp:Literal ID="ltrMobilePhone1" runat="server" Text="Cep Telefonu 1"></asp:Literal></p>
            <uc2:uPhoneNumber ID="uMobileNumber1" runat="server" ValidationGroup="vgContactInfo" ValidationRequired="true" ValidationError="Lütfen Cep Telefonu 1 Bilgisini Giriniz"/>
            
        <p class="Free"><asp:Literal ID="ltrMobilePhone2" runat="server" Text="Cep Telefonu 2"></asp:Literal></p>
            <uc2:uPhoneNumber ID="uMobileNumber2" runat="server" ValidationRequired="false"/>
            
        <p><asp:Literal ID="ltrEmail" runat="server" Text="E-posta"></asp:Literal></p>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="Lütfen E-posta Bilginizi Giriniz" runat="server" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="vgContactInfo"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" 
            Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="vgContactInfo" 
            ErrorMessage="Lütfen Geçerli E-posta Bilgisi Giriniz" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            
        <p class="Free"><asp:Literal ID="ltrWebpage" runat="server" Text="Web Sayfası (Başına http:// eklemeyi unutmayın.)"></asp:Literal></p>
            <asp:TextBox ID="txtWebpage" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revWebPage" runat="server" 
            Display="Dynamic" ControlToValidate="txtWebpage" 
            ValidationGroup="vgContactInfo" 
            ErrorMessage="Lütfen Geçerli Web Sayfası Bilgisi Giriniz" 
            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
        <p><asp:Literal ID="ltrCommunicationType" runat="server" Text="Tercih Ettiğiniz İletişim Kanalı"></asp:Literal></p>
            <uc3:uContactTypes ID="uContactTypes1" runat="server" ValidationErrorMessage="Lütfen İletişim Kanalını Seçiniz" ValidationRequired="true" ValidationGroup="vgContactInfo" />
                 
         <br />
         
         <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgContactInfo" />           
           
    </div>
   
</div>








