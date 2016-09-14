<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uHighSchoolInfo.ascx.cs"
    Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uHighSchoolInfo" %>
<%@ Register Src="../../Common/HelperControls/uDateDropDown.ascx" TagName="uDateDropDown"
    TagPrefix="uc1" %>
<%@ Register Src="../../SiteParamControls/uUniversityDepartments.ascx" TagName="uUniversityDepartments"
    TagPrefix="uc3" %>
<%@ Register Src="../../SiteParamControls/uEducationGradeSystem.ascx" TagName="uEducationGradeSystem"
    TagPrefix="uc4" %>
<div class="CvFormContent">
    <b>LİSE BİLGİLERİ</b>
    <br />
    <br />
    <div class="Form">
    
    <div class="Panel">
        Lütfen mezun olduğunuz liseye ait bilgileri giriniz.
    </div>
    
        <br />
        <p>
            <asp:Literal ID="ltrHighSchool" runat="server" Text="Lise"></asp:Literal></p>
        <asp:TextBox ID="txtHighSchool" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvHighSchool" runat="server" ControlToValidate="txtHighSchool" Display="Dynamic" ErrorMessage="Lütfen Lise Bilginizi Giriniz" ValidationGroup="vgHighSchoolInfo"></asp:RequiredFieldValidator>
        <p>
            <asp:Literal ID="ltrEndDate" runat="server" Text="Bitiş Tarihi"></asp:Literal></p>
        <uc1:uDateDropDown ID="uEndDate" runat="server" ValidationRequired="true" ValidationGroup="vgHighSchoolInfo" ValidationError="Lütfen Bitiş Tarihi Bilgisini Giriniz"/>
        <p class="Free">
            <asp:Literal ID="ltrGradeSystem" runat="server" Text="Diploma Not Sistemi"></asp:Literal></p>
        <uc4:uEducationGradeSystem ID="uEducationGradeSystem1" runat="server" />
        <p class="Free">
            <asp:Literal ID="ltrGraduationGrade" runat="server" Text="Mezuniyet Derecesi"></asp:Literal></p>
        <asp:TextBox ID="txtGraduationGrade" runat="server" onkeyup="vPrice(this)" MaxLength="6"></asp:TextBox>
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" ImageUrl="~/Images/Button/SaveAndContinue.jpg"
            OnClick="imgBtnSend_Click" ValidationGroup="vgHighSchoolInfo" />
    </div>
</div>
