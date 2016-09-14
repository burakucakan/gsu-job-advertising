<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uLogin.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uLogin" %>

<%@ Register 
    Assembly="AjaxControlToolkit" 
    Namespace="AjaxControlToolkit" 
    TagPrefix="ajaxToolkit" %>

<ajaxToolkit:ModalPopupExtender ID="MPE" runat="server" 
            TargetControlID=""
            PopupControlID="pnlModal" 
            BackgroundCssClass="ModalOverlay"
            CancelControlID="hlClose"
            BehaviorID="LoginModal"              
             />
             
<script type="text/javascript">

    function pageLoad(sender, args) {
        if (!args.get_isPartialLoad()) {
            $addHandler(document, "keydown", onKeyDown);
        }
    }

    function onKeyDown(e) {
        if (e && e.keyCode == Sys.UI.Key.esc) {
            $find('LoginModal').hide();
        }
    } 

</script>


<asp:Panel ID="pnlModal" runat="server" Style="display: none" CssClass="Modal">

    <asp:Panel runat="server" ID="pnlModalHeader" CssClass="ModalHeader">
        <span>ÜYE ÖĞRENCİ GİRİŞİ</span>
        <asp:HyperLink runat="server" ID="hlClose" ImageUrl="~/Images/Global/X.png" onclick="FormReset()" NavigateUrl="javascript:;" CssClass="ttL" ToolTip="Kapat (Esc)"></asp:HyperLink>
    </asp:Panel>
    
    <asp:UpdatePanel ID="upLogin" runat="server">
        <ContentTemplate>

        <div class="Form">

            <asp:UpdateProgress ID="upgrs1" runat="server" AssociatedUpdatePanelID="upLogin" DynamicLayout="true">
                <ProgressTemplate> <img alt="" src="Images/Global/Indicator.gif" /> </ProgressTemplate>                        
            </asp:UpdateProgress>
            
            <asp:Panel runat="server" ID="pnlLogin" DefaultButton="imgBtnSend">
                
                <p>Öğrenci Numaranız</p>
                <asp:TextBox runat="server" ID="txtStudentNumber" ValidationGroup="vgLogin" MaxLength="8" onkeyup="vNumber(this)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqStudentNumber" ErrorMessage="Öğrenci numaranızı giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtStudentNumber" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvStudentNumber" runat="server" Display="Dynamic" ControlToValidate="txtStudentNumber" ClientValidationFunction="cvStudentNumber" ErrorMessage="Öğrenci numaranız 8 karakter olmalıdır" ValidationGroup="vgLogin" />

                <p>Şifreniz</p>
                <asp:TextBox runat="server" ID="txtPassword" MaxLength="20" TextMode="Password" ValidationGroup="vgLogin" />
                <asp:RequiredFieldValidator ID="req5" ErrorMessage="Şifrenizi giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPassword" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvPass" runat="server" Display="Dynamic" ControlToValidate="txtPassword" ClientValidationFunction="cvPassCtrl" ErrorMessage="Şifreniz en az 5 karakter olmalıdır !" ValidationGroup="vgLogin" />
                
                <asp:HyperLink runat="server" ID="hlNewUser" NavigateUrl="~/Signup.aspx">· üye ol</asp:HyperLink>                
                <asp:LinkButton runat="server" ID="lnkForgotPassword" OnClick="PanelChange">· şifremi unuttum</asp:LinkButton>                
                <asp:ImageButton runat="server" ID="imgBtnSend" ImageUrl="~/Images/Button/Login.jpg" ValidationGroup="vgLogin" OnClick="imgBtnSend_Click" />                
                
            </asp:Panel>
            
            <asp:Panel runat="server" ID="pnlForgotPass" DefaultButton="imgBtnSendPassword" Visible="false">            
            
                <asp:Panel runat="server" ID="pnlForgotPasswordForm" Visible="true" DefaultButton="imgBtnSendPassword">

                    <strong>Şifreniz GSÜ veritabanında öğrenci numaranızla eşleşen email adresinize gönderilecektir.</strong>                                
                
                    <p>Öğrenci Numaranız</p>
                    <asp:TextBox runat="server" ID="txtForgotPassStudentNumber" ValidationGroup="vgForgotPass" MaxLength="8" onkeyup="vNumber(this)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqForgotPassStudentNumber" ErrorMessage="Öğrenci numaranızı giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtForgotPassStudentNumber" ValidationGroup="vgForgotPass"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvForgotPassStudentNumber" runat="server" Display="Dynamic" ControlToValidate="txtForgotPassStudentNumber" ClientValidationFunction="cvStudentNumber" ErrorMessage="Öğrenci numaranız 8 karakter olmalıdır" ValidationGroup="vgForgotPass" />
                    
                    <asp:ImageButton runat="server" ID="imgBtnSendPassword" ImageUrl="~/Images/Button/Send.jpg" ValidationGroup="vgForgotPass" OnClick="imgBtnSendPassword_Click" />
    
                </asp:Panel>
                <asp:LinkButton runat="server" ID="lnkLogin" OnClick="PanelChange">· üye girişi</asp:LinkButton>
            
            </asp:Panel>                                    

        </div>

        <asp:Panel runat="server" ID="succPassword" CssClass="Success" Visible="false">ŞİFRENİZ EMAIL ADRESİNİZE GÖNDERİLMİŞTİR</asp:Panel>
        <asp:Panel runat="server" ID="errPassword" CssClass="Error" Visible="false">ŞİFRENİZ GÖNDERİLEMEDİ !</asp:Panel>
        <asp:Panel runat="server" ID="errHasUser" CssClass="Error" Visible="false">ÜYE BULUNAMADI !</asp:Panel>        
        <asp:Panel runat="server" ID="Error" CssClass="Error" Visible="false">LÜTFEN BİLGİLERİNİZİ KONTROL EDİN</asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Panel>
