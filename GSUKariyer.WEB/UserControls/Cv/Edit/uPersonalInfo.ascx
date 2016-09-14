<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uPersonalInfo.ascx.cs"
    Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uPersonalInfo" %>
<%@ Register Src="~/UserControls/Common/HelperControls/uItem.ascx" TagName="uItem"
    TagPrefix="uc1" %>
<%@ Register Src="../../SiteParamControls/uGenders.ascx" TagName="uGenders" TagPrefix="uc2" %>
<%@ Register Src="../../SiteParamControls/uMaritalStatus.ascx" TagName="uMaritalStatus"
    TagPrefix="uc3" %>
<%@ Register Src="../../SiteParamControls/uCities.ascx" TagName="uCities" TagPrefix="uc4" %>
<%@ Register Src="../../SiteParamControls/uCountries.ascx" TagName="uCountries" TagPrefix="uc5" %>
<%@ Register src="../../Common/HelperControls/uDateDropDown.ascx" tagname="uDateDropDown" tagprefix="uc6" %>
<div class="CvFormContent">
    <b>KİŞİSEL BİLGİLERİM</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplPersonalInfo" runat="server">
        <ContentTemplate>
            <div class="Form">
                <asp:UpdateProgress ID="upPersonalInfo" runat="server" AssociatedUpdatePanelID="uplPersonalInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <p>
                    <asp:Literal ID="ltrName" runat="server" Text="Ad"></asp:Literal></p>
                <asp:TextBox ID="txtName" runat="server" Text="Ufuk" Enabled="false"></asp:TextBox>
                <p>
                    <asp:Literal ID="ltrSurname" runat="server" Text="Soyad"></asp:Literal></p>
                <asp:TextBox ID="txtSurname" runat="server" Text="Aslan" Enabled="false"></asp:TextBox>
                <p>
                    <asp:Literal ID="ltrBirtDate" runat="server" Text="Doğum Tarihi"></asp:Literal>
                </p>
                <uc6:uDateDropDown ID="uBirthDate" runat="server" Enabled="false" />
                
                <p>
                    <asp:Literal ID="ltrGender" runat="server" Text="Cinsiyet"></asp:Literal></p>
                <uc2:uGenders ID="uGenders1" runat="server" Enabled="false" />
                <p>
                    <asp:Literal ID="ltrMaritalStatus" runat="server" Text="Medeni Durum"></asp:Literal></p>
                <uc3:uMaritalStatus ID="uMaritalStatus1" runat="server" ValidationErrorMessage="Lütfen Medeni Durumunuzu Seçiniz"
                    ValidationGroup="vgPersonalInfo" ValidationRequired="true" />
                <p>
                    <asp:Literal ID="ltrBirthCountry" runat="server" Text="Doğum Yeri(Ülke)"></asp:Literal></p>
                <uc5:uCountries ID="uCountries1" runat="server" ValidationErrorMessage="Lütfen Doğum Yerinizi(Ülke) Seçiniz"
                    ValidationGroup="vgPersonalInfo" ValidationRequired="true" ShowAll="false" />
                <p>
                    <asp:Literal ID="ltrBirthCity" runat="server" Text="Doğum Yeri(Şehir)"></asp:Literal></p>
                <uc4:uCities ID="uCities1" runat="server" ValidationErrorMessage="Lütfen Doğum Yerinizi(Şehir) Seçiniz"
                    ValidationGroup="vgPersonalInfo" ValidationRequired="true" ShowAll="false" />
                <p>
                    <asp:Literal ID="Literal1" runat="server" Text="Uyruk"></asp:Literal></p>
                <uc5:uCountries ID="uNationality" runat="server" ValidationErrorMessage="Lütfen Uyruk Seçiniz"
                    ValidationGroup="vgPersonalInfo" ValidationRequired="true" ShowAll="false" />
                <br />
                <asp:ImageButton runat="server" ID="imgBtnSend" ImageUrl="~/Images/Button/SaveAndContinue.jpg"
                    OnClick="imgBtnSend_Click" ValidationGroup="vgPersonalInfo" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgBtnSend" />
        </Triggers>
    </asp:UpdatePanel>
</div>
