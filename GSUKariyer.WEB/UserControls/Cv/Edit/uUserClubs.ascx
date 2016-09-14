<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUserClubs.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uUserClubs" %>
<div class="CvFormContent">
    <b>ÜYE OLUNAN TOPLULUKLAR, KULÜPLER</b>
    <br />
    <br />
    <div class="Form" style="width:430px;">
        
        <div class="Panel">
            Üye olduğunuz üniversite kulüplerini seçiniz.
        </div>
        
        <br />
        <p>
        <table cellpadding="2" cellspacing="0" border="0">
        <tr>
            <td><b>Akademik Kulüpler</b></td>
            <td><b>Spor Kulüpleri</b></td>
        </tr>
        <tr>
            <td valign="top">
                <table cellpadding="0" border="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:CheckBoxList id="cblAcademicClubs" runat="server"></asp:CheckBoxList>    
                    </td>
                </tr>
                <tr>
                    <td><b>Kültürel Kulüpler</b></td>
                </tr>
                <tr>
                    <td><asp:CheckBoxList id="cblCulturelClubs" runat="server"></asp:CheckBoxList></td>
                </tr>
                </table>
                
            </td>
            <td valign="top">
            <asp:CheckBoxList id="cblSporClubs" runat="server"></asp:CheckBoxList>
            </td>
        </tr>
        </table>
        </p class="Free">
        Kulüplerde aldığınız görevler
        <p>
            <asp:TextBox ID="txtOtherUniversityClubs" runat="server" MaxLength="500" Rows="5" TextMode="MultiLine"></asp:TextBox>        
        </p>
        Üye olduğunuz diğer kulüpler
        <p class="Free">
            <asp:TextBox ID="txtOtherClubs" runat="server" MaxLength="250" Rows="5" TextMode="MultiLine"></asp:TextBox>        
        </p>
        
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgUserClubs" /> 
    </div>
     
</div>