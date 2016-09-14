<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uComputerInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uComputerInfo" %>
<div class="CvFormContent">
    <b>BİLGİSAYAR BİLGİLERİ</b>
    <br />
    <br />
    <div class="Form" style="width:430px;">
    
        <div class="Panel">    
            Bilgisayar teknolojisinin yaygınlaşması, her adayın belirli bir seviyede bilgisayar bilgisine sahip olması gerekliliğini ortaya çıkarmıştır. Kısaca bildiğiniz paket programları ve diğer teknolojileri aşağıda sıralayabilirsiniz.
        </div>
        
        <br /><br /> 
        <asp:TextBox ID="txtComputerInfo" runat="server" TextMode="MultiLine" Rows="7"></asp:TextBox>
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgComputerInfo" /> 
    </div>
     
</div>