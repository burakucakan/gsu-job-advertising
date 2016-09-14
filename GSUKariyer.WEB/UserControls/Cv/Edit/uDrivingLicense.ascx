<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uDrivingLicense.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uDrivingLicense" %>
<div class="CvFormContent">
    <b>SÜRÜCÜ BELGESİ</b>
    <br />
    <br />
    <div class="Form" style="width:430px;">
    
        <div class="Panel">    
            Lütfen ehliyetiniz olup olmadığını giriniz.
        </div>
        
        <br />
        <p>
        <asp:RadioButtonList id="rblDrivingLicense" runat="server">
        </asp:RadioButtonList>
        </p>
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgDrivingLicense" /> 
    </div>
     
</div>