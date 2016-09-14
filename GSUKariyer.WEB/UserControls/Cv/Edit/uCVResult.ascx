<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCVResult.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uCVResult" %>
<div class="CvFormContent">
    <b>SONUÇ</b>
    <br />
    <br />
    <asp:Literal ID="ltrResult" runat="server"></asp:Literal> 
    <div class="Form" style="width:430px;">
        <br />
        <p>Unutmayın! İşverenler her zaman özgeçmişinizin en güncel halini görüntülerler. Güncel özgeçmişiniz, size her zaman avantaj sağlayacaktır.</p>
        <br />
     <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" ImageUrl="~/Images/Button/Save.jpg"
            OnClick="imgBtnSend_Click" ValidationGroup="vgResultInfo" />
        <asp:HyperLink id="hlClose" runat="server" Text="Kapat"></asp:HyperLink>
    </div>
     
</div>