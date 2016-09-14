<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uWelcome.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uWelcome" %>
<%@ Register Src="~/UserControls/Common/HelperControls/uItem.ascx" TagName="uItem"
    TagPrefix="uc1" %>
<div class="CvFormContent">
    <b>HOŞGELDİNİZ</b>
    <div class="Form" style="width:430px;">

        <br /><br />    
    
        <div class="Panel">
        
            Özgeçmiş hazırlama sihirbazına hoşgeldiniz!
            <br /><br />        
                
            Özgeçmişinizin görüntülenmesini istediğiniz dili seçiniz.
        </div>
        
        <br />
        <p>
        <asp:RadioButtonList id="rblCvLanguages" runat="server">
        </asp:RadioButtonList>
        </p>
        <br />
        Özgeçmişinize vermek istediğiniz adı yazınız.
        <br />
        <asp:TextBox ID="txtName" runat="server" MaxLength=255></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Lütfen Cv Adını Giriniz"
                    ValidationGroup="vgWelcome" Display="Dynamic" ControlToValidate="txtName" ></asp:RequiredFieldValidator>
        <%--Varsayılan CV mi?
        <br />
        <asp:RadioButtonList id="rblIsDefault" runat="server">
        </asp:RadioButtonList>--%>
        
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgWelcome" /> 
    </div>
     
</div>
