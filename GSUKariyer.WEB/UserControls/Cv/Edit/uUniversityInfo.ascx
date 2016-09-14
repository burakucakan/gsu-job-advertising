<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUniversityInfo.ascx.cs"
    Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uUniversityInfo" %>

<%@ Register src="../../Common/HelperControls/uDateDropDown.ascx" tagname="uDateDropDown" tagprefix="uc1" %>

<%@ Register src="../../SiteParamControls/uUniversityInstitute.ascx" tagname="uUniversityInstitute" tagprefix="uc2" %>

<%@ Register src="../../SiteParamControls/uUniversityDepartments.ascx" tagname="uUniversityDepartments" tagprefix="uc3" %>

<%@ Register src="../../SiteParamControls/uEducationGradeSystem.ascx" tagname="uEducationGradeSystem" tagprefix="uc4" %>

<%@ Register src="../../SiteParamControls/uUniversities.ascx" tagname="uUniversities" tagprefix="uc5" %>

<%@ Register src="../../SiteParamControls/uLicenseEducationType.ascx" tagname="uLicenseEducationType" tagprefix="uc6" %>

<div class="CvFormContent">
    <b>LİSANS BİLGİLERİ</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplUniversityInfo" runat="server">
        <ContentTemplate>
            <div class="Form">
                <asp:UpdateProgress ID="upUniversityInfo" runat="server" AssociatedUpdatePanelID="uplUniversityInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                
                <div class="Panel">
                    Lütfen üniversite bilgilerinizi giriniz.
                </div>
                
                <p><asp:Literal ID="ltrStartDate" runat="server" Text="Başlangıç Tarihi"></asp:Literal></p>
                <uc1:uDateDropDown ID="uStartDate" runat="server" ValidationRequired="true" ValidationGroup="vgUniversityInfo" ValidationError="Lütfen Başlangıç Tarihini Giriniz"/>
                <p class="Free"><asp:Literal ID="ltrEndDate" runat="server" Text="Bitiş Tarihi"></asp:Literal></p>             
                <uc1:uDateDropDown ID="uEndDate" runat="server" />
                <p><asp:Literal ID="ltrUniversity" runat="server" Text="Üniversite"></asp:Literal></p>
                <uc5:uUniversities ID="uUniversities1" runat="server" HasFreeValue="true" ValidationRequired="true" ValidationGroup="vgUniversityInfo" ValidationError="Lütfen Üniversite Bilgisini Giriniz"/>
                <p><asp:Literal ID="ltrInstitude" runat="server" Text="Fakülte Adı"></asp:Literal></p>
                <uc2:uUniversityInstitute ID="uUniversityInstitute1" runat="server" ValidationRequired="true" ValidationGroup="vgUniversityInfo" ValidationError="Lütfen Fakülte Bilgisini Giriniz"/>
                <p><asp:Literal ID="ltrDepartment" runat="server" Text="Bölümüm"></asp:Literal></p>
                <uc3:uUniversityDepartments ID="uUniversityDepartments1" runat="server" HasFreeValue="true" ValidationRequired="true" ValidationGroup="vgUniversityInfo" ValidationError="Lütfen Fakülte Bilgisini Giriniz"/>
                <asp:PlaceHolder ID="phEducationType" runat="server" Visible="false">
                <p><asp:Literal ID="ltrEducationType" runat="server" Text="Öğrenim Tipi"></asp:Literal></p>
                <uc6:uLicenseEducationType ID="uLicenseEducationType1" runat="server" ValidationRequired="false" ValidationGroup="vgUniversityInfo" ValidationError="Lütfen Öğrenim Tipini Giriniz" />
                </asp:PlaceHolder>
                <p class="Free"><asp:Literal ID="ltrGradeSystem" runat="server" Text="Diploma Not Sistemi"></asp:Literal></p>
                <uc4:uEducationGradeSystem ID="uEducationGradeSystem1" runat="server" />            
                <p class="Free"><asp:Literal ID="ltrGraduationGrade" runat="server" Text="Mezuniyet Derecesi"></asp:Literal></p>
                <asp:TextBox ID="txtGraduationGrade" runat="server" onkeyup="vPrice(this)" MaxLength="6"></asp:TextBox>
                
                <br /> 
                <asp:ImageButton runat="server" ID="imgBtnSend" ImageUrl="~/Images/Button/SaveAndContinue.jpg"
                    OnClick="imgBtnSend_Click" ValidationGroup="vgUniversityInfo" />
            </div>
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger  ControlID="imgBtnSend"/>
        </Triggers>
    </asp:UpdatePanel>
</div>
