<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uMasterInfo.ascx.cs"
    Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uMasterInfo" %>

<%@ Register src="../../Common/HelperControls/uDateDropDown.ascx" tagname="uDateDropDown" tagprefix="uc1" %>

<%@ Register src="../../SiteParamControls/uUniversityInstitute.ascx" tagname="uUniversityInstitute" tagprefix="uc2" %>

<%@ Register src="../../SiteParamControls/uUniversityDepartments.ascx" tagname="uUniversityDepartments" tagprefix="uc3" %>

<%@ Register src="../../SiteParamControls/uEducationGradeSystem.ascx" tagname="uEducationGradeSystem" tagprefix="uc4" %>

<%@ Register src="../../SiteParamControls/uUniversities.ascx" tagname="uUniversities" tagprefix="uc5" %>

<div class="CvFormContent">
    <b>LİSANS ÜSTÜ BİLGİLERİ</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplMasterInfo" runat="server">
        <ContentTemplate>
            <div class="Form">
                <asp:UpdateProgress ID="upMasterInfo" runat="server" AssociatedUpdatePanelID="uplMasterInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                
                <div class="Panel">
                    Lisans Üstü yapmadıysanız bu bölümü boş bırakınız. <br />Öğrenciyseniz mezuniyet tarihi olarak, yüksek lisansı tamamlayacağınız tarihi girebilirsiniz.
                </div>
                
                <p><asp:Literal ID="ltrStartDate" runat="server" Text="Başlangıç Tarihi"></asp:Literal></p>
                <asp:Label ID="lblErrorStartDate" runat="server" Visible="false" Text="Lütfen Başlangıç Tarihini Giriniz" ForeColor="Red" CssClass="errCustom"></asp:Label>
                <uc1:uDateDropDown ID="uStartDate" runat="server" />
                
                <p class="Free"><asp:Literal ID="ltrEndDate" runat="server" Text="Bitiş Tarihi"></asp:Literal></p>             
                <uc1:uDateDropDown ID="uEndDate" runat="server" />
                <p><asp:Literal ID="ltrUniversity" runat="server" Text="Üniversite"></asp:Literal></p>
                <asp:Label ID="lblErrorUniversity" runat="server" Visible="false" Text="Lütfen Üniversite Bilgisini Giriniz" ForeColor="Red" CssClass="errSiteParams"></asp:Label>
                <uc5:uUniversities ID="uUniversities1" runat="server" HasFreeValue="true"/>
                <p><asp:Literal ID="ltrMasterInstitude" runat="server" Text="Fakülte Adı"></asp:Literal></p>
                <asp:Label ID="lblErrorInstitute" runat="server" Visible="false" Text="Lütfen Fakülte Bilgisini Giriniz" ForeColor="Red" CssClass="errSiteParams"></asp:Label>
                <uc2:uUniversityInstitute ID="uUniversityInstitute1" runat="server"/>
                <p><asp:Literal ID="ltrMasterDepartment" runat="server" Text="Bölümüm"></asp:Literal></p>
                <asp:Label ID="lblErrorDepartments" runat="server" Visible="false" Text="Lütfen Departman Bilgisini Giriniz" ForeColor="Red" CssClass="errSiteParams"></asp:Label>
                <uc3:uUniversityDepartments ID="uUniversityDepartments1" runat="server" HasFreeValue="true"/>
                <p class="Free"><asp:Literal ID="ltrMasterGradeSystem" runat="server" Text="Diploma Not Sistemi"></asp:Literal></p>
                <uc4:uEducationGradeSystem ID="uEducationGradeSystem1" runat="server" />            
                <p class="Free"><asp:Literal ID="ltrGraduationGrade" runat="server" Text="Mezuniyet Derecesi"></asp:Literal></p>
                <asp:TextBox ID="txtGraduationGrade" runat="server" onkeyup="vPrice(this)" MaxLength="6"></asp:TextBox>
                
                <br />
                <asp:ImageButton runat="server" ID="imgBtnSend" ImageUrl="~/Images/Button/SaveAndContinue.jpg"
                    OnClick="imgBtnSend_Click" ValidationGroup="vgMasterInfo" />
            </div>
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger  ControlID="imgBtnSend"/>
        </Triggers>
    </asp:UpdatePanel>
</div>
