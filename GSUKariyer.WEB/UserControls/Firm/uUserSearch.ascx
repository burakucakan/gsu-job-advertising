<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUserSearch.ascx.cs"
    Inherits="GSUKariyer.WEB.UserControls.Firm.uUserSearch" %>
<%@ Register Src="~/UserControls/Common/HelperControls/uNumericDropdown.ascx" TagName="uNumericDropdown"
    TagPrefix="uc2" %>
<%@ Register src="../SiteParamControls/uWorkingExperiences.ascx" tagname="uWorkingExperiences" tagprefix="uc1" %>
<%@ Register src="../SiteParamControls/uWorkingStatus.ascx" tagname="uWorkingStatus" tagprefix="uc3" %>
<%@ Register src="uUsers.ascx" tagname="uUsers" tagprefix="uc4" %>
<%@ Register src="../SiteParamControls/uEducationStates.ascx" tagname="uEducationStates" tagprefix="uc5" %>
<div id="divSearch" class="SubPage" runat="server" visible="true">
    <h1>
        eleman arama</h1>
    <ins></ins>
    <br />
    <asp:UpdatePanel ID="uplSearchCriteria" runat="server">
        <ContentTemplate>
            <div class="SearchNavigation">
                <asp:LinkButton ID="lbtnGeneralCriteria" Text="· GENEL KRİTERLER" runat="server" CommandArgument="divGeneral" onclick="lbtnSearchCriteria_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbtnGsuInstuteAndDepartments" Text="· ÜNİVERSİTE BÖLÜMLERİ" 
                    runat="server" CommandArgument="divUniversityDepartments" 
                    onclick="lbtnSearchCriteria_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbtnLanguages" Text="· YABANCI DİL BİLGİSİ" runat="server" CommandArgument="divLanguages" onclick="lbtnSearchCriteria_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbtnClubs" Text="· ÜYE OLUNAN KULÜPLER" runat="server" CommandArgument="divGsClubs" onclick="lbtnSearchCriteria_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbtnCertificates" Text="· SERTİFİKALAR" runat="server" CommandArgument="divCertificates" onclick="lbtnSearchCriteria_Click"></asp:LinkButton>
                <asp:LinkButton ID="lbtnInterestedPositions" Text="· İLGİLENİLEN POSİZYONLAR" runat="server" CommandArgument="divInterestedPositions" onclick="lbtnSearchCriteria_Click"></asp:LinkButton>
            </div>
            <div class="SearchContent">
                <asp:UpdateProgress ID="upSearchCriteria" runat="server" AssociatedUpdatePanelID="uplSearchCriteria"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div id="divGeneral" runat="server" visible="true" class="Panel">
                    <b>GENEL KRİTERLER</b> <ins></ins>
                    Eğitim Durumu
                    <uc5:uEducationStates ID="uEducationStates1" runat="server" />
                    Yaş
                    <asp:DropDownList ID="ddlAges" runat="server"></asp:DropDownList>
                    Toplam İş ve/veya Staj Tecrübesi
                    <uc1:uWorkingExperiences ID="uWorkingExperiences2" runat="server" />                    
                    Çalışma Durumu
                    <uc3:uWorkingStatus ID="uWorkingStatus2" runat="server" />
                    <ins></ins>
                </div>
                <div id="divUniversityDepartments" runat="server" visible="false" class="Panel">
                    <b>ÜNİVERSİTE BÖLÜMLERİ</b> <ins></ins>
                    <asp:ListBox runat="server" ID="lbUniversityDepartments" Rows="20" SelectionMode="Multiple"
                        Width="300" OnSelectedIndexChanged="lb_OnSelectedIndexChanged"></asp:ListBox>
                    <ins></ins>'CTRL' tuşunu basılı tutarak en fazla 5 adet 'ÜNİVERSİTE BÖLÜMÜ' seçimi yapabilirsiniz.
                </div>
                <div id="divLanguages" runat="server" visible="false" class="Panel">
                    <b>YABANCI DİL BİLGİSİ</b> <ins></ins>
                    <table cellpadding="1" cellspacing="1" border="0">
                        <tr>
                            <td style="padding-right: 30px;">
                                Dil
                            </td>
                            <td style="padding-right: 30px;">
                                Okuma
                            </td>
                            <td style="padding-right: 30px;">
                                Yazma
                            </td>
                            <td style="padding-right: 30px;">
                                Konuşma
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlLanguages1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uReadGrade1" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uWriteGrade1" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uTalkGrade1" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlLanguages2" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uReadGrade2" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uWriteGrade2" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uTalkGrade2" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlLanguages3" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uReadGrade3" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uWriteGrade3" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                            <td>
                                <uc2:uNumericDropdown ID="uTalkGrade3" runat="server" ValidationGroup="vgLanguageInfo"
                                    ValidationMessage="*" ClientValidationEnabled="false" />
                            </td>
                        </tr>
                    </table>
                    <ins></ins>Derecelendirmede 1 başlangıç seviyesini, 10 ise en üst seviyeyi göstermektedir.
                </div>
                <div id="divGsClubs" runat="server" visible="false" class="Panel">
                    <b>ÜYE OLUNAN KULÜPLER</b> <ins></ins>
                    <asp:ListBox runat="server" ID="lbGsClubs" Rows="20" SelectionMode="Multiple"
                        Width="300" OnSelectedIndexChanged="lb_OnSelectedIndexChanged"></asp:ListBox>
                    <ins></ins>'CTRL' tuşunu basılı tutarak en fazla 5 adet 'KULÜP' seçimi yapabilirsiniz.
                </div>
                <div id="divCertificates" runat="server" visible="false" class="Panel">
                    <b>SERTİFİKALAR</b> <ins></ins>
                    <asp:ListBox runat="server" ID="lbCertificateCategories" Rows="20" SelectionMode="Multiple"
                        Width="300" OnSelectedIndexChanged="lb_OnSelectedIndexChanged"></asp:ListBox>
                    <ins></ins>'CTRL' tuşunu basılı tutarak en fazla 5 adet 'SERTİFİKA KATEGORİSİ' seçimi yapabilirsiniz.
                </div>
                <div id="divInterestedPositions" runat="server" visible="false" class="Panel">
                    <b>İLGİLENİLEN POZİSYONLAR</b> <ins></ins>
                    <asp:ListBox runat="server" ID="lbInterestedPositions" Rows="20" SelectionMode="Multiple"
                        Width="300" OnSelectedIndexChanged="lb_OnSelectedIndexChanged"></asp:ListBox>
                    <ins></ins>'CTRL' tuşunu basılı tutarak en fazla 5 adet 'POZİSYON' seçimi yapabilirsiniz.
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <ins></ins>
    <asp:ImageButton runat="server" ID="imgBtnSearch" 
        ImageUrl="~/Images/Button/Search.jpg" onclick="imgBtnSearch_Click" />
    
</div>

<uc4:uUsers ID="uUsers1" runat="server" visible="false" ShowBackButton="true" OnBackClick="uUsers1_BackClick"/>





