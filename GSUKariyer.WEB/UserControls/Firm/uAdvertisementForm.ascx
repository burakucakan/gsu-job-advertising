<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uAdvertisementForm.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uAdvertisementForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/SiteParamControls/uPositions.ascx" tagname="uPositions" tagprefix="uc1" %>
<%@ Register src="~/UserControls/SiteParamControls/uCountries.ascx" tagname="uCountries" tagprefix="uc2" %>
<%@ Register src="~/UserControls/SiteParamControls/uCities.ascx" tagname="uCities" tagprefix="uc3" %>
<%@ Register src="~/UserControls/SiteParamControls/uAdvertisementTypes.ascx" tagname="uAdvertisementTypes" tagprefix="uc4" %>


<div class="SubPage">

    <h1>ilan kaydı</h1>

    <ins></ins>
    
    <div class="Panel">
        
        İlan kaydınız gerçekleşmiştir.
                      
    </div>

    <ins></ins>
    
    <asp:Panel runat="server" ID="succSave" CssClass="Success" Visible="false">İLAN KAYDEDİLMİŞTİR</asp:Panel>
    <asp:Panel runat="server" ID="succUpdate" CssClass="Success" Visible="false">İLANINIZ GÜNCELLENMİŞTİR</asp:Panel>

    <asp:Panel runat="server" ID="errSave" CssClass="Error" Visible="false">İLAN KAYDEDİLİRKEN HATA OLUŞTU ! İlan bilgilerini kontrol ediniz.</asp:Panel>

    <asp:Panel ID="pnlForm" runat="server" CssClass="Form">
        
        <asp:HiddenField runat="server" ID="hdID" Value="0" />
    
        <p>İlan başlığı</p>
        <asp:TextBox runat="server" ID="txtTitle" ValidationGroup="vgAdvertisementForm" MaxLength="100"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqTitle" ErrorMessage="Lütfen ilan başlığını giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtTitle" ValidationGroup="vgAdvertisementForm"></asp:RequiredFieldValidator>

        <p>İlan başlangıç tarihi</p>
        <asp:TextBox runat="server" ID="txtStartDate" ValidationGroup="vgAdvertisementForm" MaxLength="20" Width="350"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqStartDate" ErrorMessage="Lütfen ilan başlangıç tarihini giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtStartDate" ValidationGroup="vgAdvertisementForm"></asp:RequiredFieldValidator>
        <cc1:CalendarExtender ID="ajCalendarStarDate" runat="server" TargetControlID="txtStartDate" Format="dd MMMM yyyy"></cc1:CalendarExtender>

        <p>İlan bitiş tarihi</p>
        <asp:TextBox runat="server" ID="txtEndDate" ValidationGroup="vgAdvertisementForm" MaxLength="20" Width="350"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqEndDate" ErrorMessage="Lütfen ilan bitiş tarihini giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtEndDate" ValidationGroup="vgAdvertisementForm"></asp:RequiredFieldValidator>
        <cc1:CalendarExtender ID="ajCalendarEndDate" runat="server" TargetControlID="txtEndDate" Format="dd MMMM yyyy"></cc1:CalendarExtender>

        <p>Çalışma şekli</p>
        <uc4:uAdvertisementTypes ID="uAdvertisementTypes1" runat="server" ValidationGroup="vgAdvertisementForm" ValidationErrorMessage="Lütfen çalışma şeklini seçiniz" />

        <p>Pozisyon</p>
        <uc1:uPositions ID="uPositions1" runat="server" ValidationRequired="true" ValidationGroup="vgAdvertisementForm" ValidationErrorMessage="Lütfen ilanın pozisyonunu seçiniz" />

        <asp:UpdatePanel ID="upCountryCity" runat="server">
            <ContentTemplate>
        
        <p>Ülke</p>
        <uc2:uCountries ID="uCountries1" runat="server" ValidationErrorMessage="Lütfen ülke seçiniz" ValidationGroup="vgAdvertisementForm" ValidationRequired="true" ShowAll="false"/>
            
        <p>Şehir</p>
        <uc3:uCities ID="uCities1" runat="server" ValidationErrorMessage="Lütfen şehir seçiniz" ValidationGroup="vgAdvertisementForm" ValidationRequired="true" ShowAll="false"/>

            </ContentTemplate>
        </asp:UpdatePanel>

        <p>İşe alınacak personel sayısı</p>
        <asp:TextBox runat="server" ID="txtEmployeesCount" ValidationGroup="vgAdvertisementForm" MaxLength="4" onkeyup="vNumber(this)" Width="100"></asp:TextBox>        

        <p>Genel nitelikler</p>
        <asp:RequiredFieldValidator CssClass="errTextArea" ID="reqDetail" ErrorMessage="Lütfen genel nitelikleri giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtDetail" ValidationGroup="vgAdvertisementForm"></asp:RequiredFieldValidator>
        <asp:TextBox runat="server" ID="txtDetail" ValidationGroup="vgAdvertisementForm" TextMode="MultiLine" Height="150"></asp:TextBox>        

        <p>İş tanımı</p>
        <asp:RequiredFieldValidator CssClass="errTextArea" ID="reqDesc" ErrorMessage="Lütfen iş tanımını giriniz" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtDescription" ValidationGroup="vgAdvertisementForm"></asp:RequiredFieldValidator>
        <asp:TextBox runat="server" ID="txtDescription" ValidationGroup="vgAdvertisementForm" TextMode="MultiLine" Height="150"></asp:TextBox>

        <br />

        <asp:ImageButton runat="server" ID="imgBtnSend" ImageUrl="~/Images/Button/Send.jpg" ValidationGroup="vgAdvertisementForm" onclick="imgBtnSend_Click" />                

    </asp:Panel>
    
</div>