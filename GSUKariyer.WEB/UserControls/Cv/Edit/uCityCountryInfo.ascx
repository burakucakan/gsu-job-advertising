<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCityCountryInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uCityCountryInfo" %>

<%@ Register src="../../SiteParamControls/uCities.ascx" tagname="uCities" tagprefix="uc1" %>
<%@ Register src="../../SiteParamControls/uCountries.ascx" tagname="uCountries" tagprefix="uc2" %>

<div class="CvFormContent">
    <b>ŞEHİR/ÜLKE TERCİHİM</b>
    <br />
    <br />
    
    <div class="Panel">
        Çalışmak istediğiniz şehirleri ve ülkeleri seçiniz.
    </div>
    
    <br /><br />
    <asp:UpdatePanel ID="uplCityCountryInfo" runat="server">
        <ContentTemplate>
        <asp:UpdateProgress ID="upCityCountryInfo" runat="server" AssociatedUpdatePanelID="uplCityCountryInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
    <div class="Form">
        <p><b>Çalışmak İstediğiniz Şehirler</b></p>
        <asp:Repeater ID="rptCities" runat="server">
        <ItemTemplate>
            <p class='<%#ArrangePClass(Container) %>'><asp:Literal ID="ltrCity1" runat="server" Text='<%#ArrangeCityDesc(Container) %>'></asp:Literal></p>
            <uc1:uCities ID="uCities1" runat="server" HasFreeValue="true" ValidationRequired='<%#ArrangeValidation(Container) %>' ValidationGroup="vgCityCountryInfo" ValidationErrorMessage='<%#ArrangeCityValidation(Container) %>' SelectedValue='<%#Eval("Value") %>' FreeItemValue='<%#ArrangeCityFreeItemValue() %>' FreeValue='<%#Eval("FreeValue") %>' DropDownViewStateEnabled="false"/>
        </ItemTemplate>
        </asp:Repeater>
        <br /><br />
        <p><b>Çalışmak İstediğiniz Ülkeler</b></p>
        <asp:Repeater ID="rptCountry" runat="server">
        <ItemTemplate>
            <p class='<%#ArrangePClass(Container) %>'><asp:Literal ID="ltrCountry1" runat="server" Text='<%#ArrangeCountryDesc(Container) %>'></asp:Literal></p>
            <uc2:uCountries ID="uCountries1" runat="server" HasFreeValue="true" ValidationRequired='<%#ArrangeValidation(Container) %>' ValidationGroup="vgCityCountryInfo" ValidationErrorMessage='<%#ArrangeCountryValidation(Container) %>' SelectedValue='<%#Eval("Value") %>' FreeItemValue='<%#ArrangeCountryFreeItemValue() %>' FreeValue='<%#Eval("FreeValue") %>'/>    
        </ItemTemplate>
        </asp:Repeater>
              
        <br />
        <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgCityCountryInfo" />           
    </div>                       
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger  ControlID="imgBtnSend"/>
    </Triggers>
    </asp:UpdatePanel>
</div>