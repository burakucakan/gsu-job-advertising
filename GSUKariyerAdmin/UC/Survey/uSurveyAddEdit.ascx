<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uSurveyAddEdit.ascx.cs" Inherits="UC_Survey_uSurveyAddEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UC/Common/Error.ascx" TagName="uError" TagPrefix="uc1" %>
<%@ Register Src="~/UC/Common/Success.ascx" TagName="uSuccess" TagPrefix="uc2" %>
<%@ Register Src="~/UC/Common/Languages.ascx" TagName="Languages" TagPrefix="uc3" %>
<%@ Register Src="~/UC/Common/BannerPositions.ascx" TagName="BannerPositions" TagPrefix="uc4" %>

<div class="fW1">
    
    <uc2:uSuccess ID="uSuccess1" runat="server" Visible="false" Title="YENİ BANNER EKLENDİ" Desc="Yeni banner eklenmiştir" />
    <uc1:uError ID="uError1" runat="server" Visible="false" Title="KAYIT EDİLMEDİ" Desc="Kayıt yapılırken hata oluştu" />
    
    <asp:Panel runat="server" ID="pnlForm">
        
        <asp:RequiredFieldValidator ID="rqSurveyName" runat="server" ErrorMessage="Anket adını giriniz !" ControlToValidate="txtSurveyName" SetFocusOnError="true" Display="None" ValidationGroup="vgBannerNew" />
        <asp:ValidationSummary ID="ValSum" runat="server" CssClass="Validate" ShowSummary="true" ValidationGroup="vgSurveyAddEdit" />
        
        <h2> ANKET BİLGİLERİ </h2>
        
        <div class="Form">
            
            <p> Anket Adı </p>
            <asp:TextBox CssClass="TextBox" ID="txtSurveyName" runat="server" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSurveyName" runat="server" Text="*" ErrorMessage="Anket adını boş bırakamazsınız." ControlToValidate="txtSurveyName" ValidationGroup="vgSurveyEdit"></asp:RequiredFieldValidator>
            
            <p> Açıklama </p>
            <asp:TextBox CssClass="TextBox" ID="txtDescription" runat="server" MaxLength="250"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Text="*" ErrorMessage="Anket adını boş bırakamazsınız." ControlToValidate="txtSurveyName" ValidationGroup="vgSurveyEdit"></asp:RequiredFieldValidator>
            
            <p> Soru </p>
            <asp:TextBox CssClass="TextBox" runat="server" ID="txtQuestion" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
            
            <p> Anket Durumu </p>
            <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
            
            <p> Yaratılma Tarihi </p>
            <asp:Literal ID="ltrCreateDate" runat="server" Text="-"></asp:Literal>                                                                                                                                                                    
            
            <asp:HiddenField runat="server" ID="hdSurveyID" Value="0" />
            
        </div>
        
        <div class="Clr"></div>
        
        <br /><br />       
        
        <h2>ANKET SEÇENEKLERİ</h2>
        
        <div class="Form">                                        
                       
            <table cellpadding="0" cellspacing="0" class="Grid fW2" style="width: 520px;">
            
                <tr>
                    <td colspan="4" style="padding-bottom: 10px;">
                        <asp:RequiredFieldValidator ID="rfvOptionText" runat="server" ErrorMessage="· Seçeneği giriniz" ControlToValidate="txtOptionText" ValidationGroup="AddSurveyItemGroup" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ErrorMessage="· Sıra bilgisini giriniz" ControlToValidate="txtOrder" ValidationGroup="AddSurveyItemGroup" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexOrderValidator" runat="server" EnableClientScript="true" ControlToValidate="txtOrder" ValidationExpression="^[0-9]*$" ErrorMessage="· Sıra bilgisini numerik girmelisiniz." ValidationGroup="AddSurveyItemGroup" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvVoteCount" runat="server" ErrorMessage="· Oy sayısını giriniz" ControlToValidate="txtVoteCount" ValidationGroup="AddSurveyItemGroup" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                            
                <tr id="tr0" >
                
                    <td> &nbsp;SEÇENEK </td>
                    <td> SIRA </td>
                    <td> OY </td>
                    
                </tr>                
                
                <tr>                    
                    <td>
                        <asp:TextBox ID="txtOptionText" CssClass="TextBox" MaxLength="100" runat="server" Width="350"></asp:TextBox>                        
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrder" CssClass="TextBox" Width="30" MaxLength="3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVoteCount" CssClass="TextBox" Width="40" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 50px;">&nbsp;</td>
                </tr>
                                
            </table>

            <div class="Clr"></div>
            <br />
            
            <asp:Button ID="btnAddSurvey" runat="server" Text="Ekle" CssClass="Button" OnClick="btnAddSurvey_Click" ValidationGroup="AddSurveyItemGroup" />
            <asp:Button ID="btnCancelSurvey" runat="server" Text="İptal" CssClass="Button" OnClick="btnCancelSurvey_Click" />                                
        
            <asp:Repeater ID="rptSurveyItems" runat="server">
                <HeaderTemplate>
                    <hr />
                    <table cellpadding="0" cellspacing="0" class="Grid fW2" style="width: 520px;">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td colspan="4" style="padding-bottom: 10px;">
                        
                            <asp:HiddenField ID="hfSurveyItemID" runat="server" Value='<%#Eval("ID") %>' />
                            
                            <asp:RequiredFieldValidator ID="rfvOptionText" runat="server" ErrorMessage="· Seçeneği giriniz" ControlToValidate="txtOptionText" Display="Dynamic" ValidationGroup="vgSurveyEdit" Font-Bold="true"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ErrorMessage="· Sıra bilgisini girniz" ControlToValidate="txtOrder" ValidationGroup="vgSurveyEdit" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexOrderValidator" runat="server" EnableClientScript="true" ControlToValidate="txtOrder" ValidationExpression="[0-9]" ErrorMessage="· Sıra bilgisini numerik girmelisiniz." ValidationGroup="vgSurveyEdit" Font-Bold="true" Display="Dynamic"></asp:RegularExpressionValidator>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>                            
                            <asp:TextBox ID="txtOptionText" CssClass="TextBox" MaxLength="250" runat="server" Text='<%#Eval("Description") %>' Width="350"></asp:TextBox>                            
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrder" CssClass="TextBox" Width="30" MaxLength="3" runat="server" Text='<%#Eval("Order") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVoteCount" CssClass="TextBox" Width="40" runat="server" Text='<%#Eval("VoteCount") %>' Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 50px;">
                            <asp:LinkButton ID="btnDelete" runat="server" Text="Sil" OnClick="btnDelete_Click" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
              
              <div class="Clr"></div>
                    
        </div>

        <div class="Clr"></div>
                
        <div class="FormFooter">
        <asp:Button runat="server" ID="btnSave" CssClass="Button" Text="KAYDET" ValidationGroup="vgSurveyEdit" OnClick="btnSave_Click" />
        </div>
        
    </asp:Panel>
    
</div>