<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uPositions.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uPositions" %>
<%@ Register src="../../SiteParamControls/uAdvertisementTypes.ascx" tagname="uAdvertisementTypes" tagprefix="uc1" %>
<div class="CvFormContent">
    <b>İLGİLENDİĞİM POZİSYONLAR</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplPositions" runat="server">
        <ContentTemplate>
            <div class="Form">
                <asp:UpdateProgress ID="upPositions" runat="server" AssociatedUpdatePanelID="uplPositions"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                
    <div class="Form" style="width:430px;">
    
        <div class="Panel">
            Lütfen çalışmak istediğiniz pozisyonların tümünü belirtiniz.
        </div>
        
        <br />
        <p>İlan Tipi</p>
        <uc1:uAdvertisementTypes ID="uAdvertisementTypes1" runat="server" ValidationRequired="true" ValidationGroup="vgPositions" ValidationErrorMessage="Lütfen İlgilendiğiniz İlan Tipini Giriniz"/>
        
        <table cellpadding="1" cellspacing="1" border="0">
        <tr>
            <td><p>Pozisyonlar</p></td>
        </tr>
        <tr>
            <td><asp:ListBox ID="lbPositions" runat="server" Width="400" Rows="12" SelectionMode="Multiple"></asp:ListBox></td>
        </tr>
        <tr>
            <td>
                <div class="fLeft" style="width: 47px;">
                    <img alt="" src="Images/Global/ArrowDown.png" style="text-align: left; margin-right: 10px;" />
                    <asp:LinkButton ID="lbtnAddSelected" runat="server" Text="Ekle" OnClick="lbtnAddSelected_Click"></asp:LinkButton>                    
                </div>
                
                <div class="fLeft" style="width: 47px;">
                    <img alt="" src="Images/Global/ArrowUp.png" style="text-align: left; margin-right: 10px;" />
                    <asp:LinkButton ID="lbtnRemoveSelected" runat="server" Text="Çıkar" OnClick="lbtnRemoveSelected_Click"></asp:LinkButton> 
                </div>
                
            </td>
        </tr>
        <tr>
            <td><p>İlgilendiğim Pozisyonlar</p></td>
        </tr>
        <tr>
            <td><asp:ListBox ID="lbMyPositions" runat="server" Width="400" Rows="12" SelectionMode="Multiple"></asp:ListBox></td>
        </tr>
        </table>
        
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgPositions" /> 
    </div>
    
     </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgBtnSend" />
        </Triggers>
    </asp:UpdatePanel>
</div>