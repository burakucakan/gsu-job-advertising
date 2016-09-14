<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCigaretteUsage.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uCigaretteUsage" %>
<div class="CvFormContent">
    <b>SİGARA KULLANIMI</b>
    <br />
    <br />
    <div class="Form" style="width:430px;">
    
        <div class="Panel">
            Sigara kullanım alışkanlıklarınızla ilgili seçeneği işaretleyiniz.
        </div>
        
        <br />
        <p>
        <asp:RadioButtonList id="rblCigaretteUsage" runat="server">
        </asp:RadioButtonList>
        </p>
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgCigaretteUsage" /> 
    </div>
     
</div>