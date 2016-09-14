<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uEducationState.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uEducationState" %>
<div class="CvFormContent">
    <b>EĞİTİM DURUMU</b>
    <br />
    <br />
    <div class="Form" style="width:430px;">
    
        <div class="Panel">
            Lütfen eğitim dumunuzu şeçiniz.
        </div>
            
        <br />
        <p>
        <asp:RadioButtonList id="rblEducationState" runat="server">
        </asp:RadioButtonList>
        </p>
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgEducationState" /> 
    </div>
     
</div>