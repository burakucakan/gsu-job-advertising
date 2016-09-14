<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCVState.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uCVState" %>
<div class="CvFormContent">
    <b>CV DURUMU</b>
    <br />
    <br />
    <div class="Form" style="width:430px;">
    
        <div class="Panel">    
            Özgeçmişinizin Aktif ya da Pasif olmasını bu bölümden belirleyebilirsiniz.        
        </div>
        
        <br />
        <p>
        <asp:RadioButtonList id="rblCvState" runat="server">
        </asp:RadioButtonList>
        </p>
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgCVState" /> 
    </div>
     
</div>