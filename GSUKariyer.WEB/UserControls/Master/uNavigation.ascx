<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uNavigation.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Master.uNavigation" EnableViewState="true" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<%--DEFAULT MENU--%>
<asp:PlaceHolder runat="server" ID="phDefaultMenu">
 
<ajaxToolkit:Accordion ID="accUserGrp1" runat="server" SelectedIndex="1" CssClass="Nav" FadeTransitions="true" 
FramesPerSecond="40" TransitionDuration="150" AutoSize="None" RequireOpenedPane="true" SuppressHeaderPostbacks="false">
   <Panes>   

    <ajaxToolkit:AccordionPane ID="accUser1_Main" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlUser1_MainPage" NavigateUrl="#">ana sayfa</asp:HyperLink>
        </Header>
    </ajaxToolkit:AccordionPane>
        
    <ajaxToolkit:AccordionPane ID="accUser1_Search" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlUser1_Search" NavigateUrl="javascript:;">iş arıyorum</asp:HyperLink>
        </Header>
        <Content> 
            <asp:HyperLink runat="server" ID="hlUser1_Advertisements_Today" NavigateUrl="#">Bugün</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser1_Advertisements_ThisWeek" NavigateUrl="#">Bu hafta</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser1_Advertisements_LastMonth" NavigateUrl="#">Son 1 ay</asp:HyperLink>             
            <asp:HyperLink runat="server" ID="hlUser1_Advertisements_DetailSearch" NavigateUrl="#">Detaylı arama</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser1_Advertisements_Related" NavigateUrl="#">En uygun</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser1_Advertisements_Internship" NavigateUrl="#">Staj ilanları</asp:HyperLink>
        </Content>
    </ajaxToolkit:AccordionPane>    
    
    <ajaxToolkit:AccordionPane ID="accUser1_SendCv" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlUser1_SendCv" NavigateUrl="javascript:;">cv yolla</asp:HyperLink>
        </Header>
        <Content>

            <asp:Repeater ID="rptFirms" runat="server">
            <ItemTemplate>
                <asp:HyperLink  runat="server" ID="hlFirm" NavigateUrl='<%#ArrangeFirmUrl(Eval("Value").ToString(),Eval("Desc").ToString()) %>'><%#Eval("Desc") %></asp:HyperLink>
            </ItemTemplate>
            </asp:Repeater>

            <asp:HyperLink runat="server" ID="hlAllFirms" NavigateUrl='#'>Tüm firmalar...</asp:HyperLink>
        
        </Content>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accUser1_Sectors" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlUser1_Sectors" NavigateUrl="javascript:;">sektörler listesi</asp:HyperLink>            
        </Header>
        <Content>
            
            <asp:Repeater ID="rptSectors" runat="server">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hlSector" NavigateUrl='<%#ArrangeSectorUrl(Eval("Value").ToString()) %>'><%#Eval("Desc")%></asp:HyperLink>
            </ItemTemplate>
            </asp:Repeater>
            
        </Content>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accUser1_CityCountry" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlUser1_CityCountry" NavigateUrl="javascript:;">şehir / ülkeler</asp:HyperLink>            
        </Header>
        <Content>

            <asp:Repeater ID="rptCityCountry" runat="server">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hlCityCountry" NavigateUrl='<%#ArrangeCityCountryUrl(Eval("Value").ToString()) %>'><%#Eval("Desc") %></asp:HyperLink>
            </ItemTemplate>
            </asp:Repeater>

        </Content>
    </ajaxToolkit:AccordionPane>                       

    </Panes>
</ajaxToolkit:Accordion>

<ajaxToolkit:Accordion ID="accUserGrp2" runat="server" SelectedIndex="0" CssClass="Nav" FadeTransitions="false"
FramesPerSecond="40" TransitionDuration="150" AutoSize="None" RequireOpenedPane="true" SuppressHeaderPostbacks="false">
   <Panes>
   
    <ajaxToolkit:AccordionPane ID="accUser1_MyCareer" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlUser2_MyCareer" NavigateUrl="javascript:;">kariyerim</asp:HyperLink>
        </Header>
        <Content> 
            <asp:HyperLink runat="server" ID="hlUser2_UserCvList" NavigateUrl="#">Özgeçmişlerim</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser2_Signup" NavigateUrl="#">Üyelik Bilgilerim</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser2_UserApplications" NavigateUrl="#">Başvurularım</asp:HyperLink>            
            <asp:HyperLink runat="server" ID="hlUser2_UserMessages" NavigateUrl="#">Mesajlarım</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser2_UserFronPosts" NavigateUrl="#">Ön Yazılarım</asp:HyperLink>            
        </Content>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accUser1_CareerPlaning" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlUser2_CarreerPlaning" NavigateUrl="javascript:;">kariyer planlama</asp:HyperLink>            
        </Header>
        <Content>
            <asp:HyperLink runat="server" ID="hlUser2_Interview" NavigateUrl="#">Röportajlar</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser2_SuccessStories" NavigateUrl="#">Başarı Hikayeleri</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlUser2_Articles" NavigateUrl="#">Makaleler</asp:HyperLink>
        </Content>
    </ajaxToolkit:AccordionPane>                       

    <ajaxToolkit:AccordionPane ID="accUser1_Announcements" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlUser2_Announcements" NavigateUrl="#">duyurular</asp:HyperLink>
        </Header>
    </ajaxToolkit:AccordionPane>
    
    </Panes>
</ajaxToolkit:Accordion>
    
</asp:PlaceHolder>
<%-- ----- --%>

<%-- Firm MENU --%>
<asp:PlaceHolder runat="server" ID="phFirmMenu" Visible="false">

<ajaxToolkit:Accordion ID="accFirmGrp1" runat="server" SelectedIndex="1" CssClass="Nav" FadeTransitions="false" 
FramesPerSecond="40" TransitionDuration="150" AutoSize="None" RequireOpenedPane="true" SuppressHeaderPostbacks="false">
   <Panes>
   
    <ajaxToolkit:AccordionPane ID="accFirm1_Main" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlFirm1_MainPage" NavigateUrl="#">ana sayfa</asp:HyperLink>
        </Header>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accFirm1_Search" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlFirm1_Search" NavigateUrl="javascript:;">eleman ara</asp:HyperLink>
        </Header>
        <Content> 
            <asp:Repeater ID="rptFirmSearchUser" runat="server">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hlWorkingType" NavigateUrl='<%#ArrangeSearchUrlByWorkingType(Eval("Value").ToString()) %>'><%#Eval("Description") %></asp:HyperLink>
            </ItemTemplate>
            </asp:Repeater>
            <asp:HyperLink runat="server" ID="hlFirm1_SearchDetail" NavigateUrl="#">Detaylı arama</asp:HyperLink>
        </Content>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accFirm1_Departments" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlFirm1_Departments" NavigateUrl="javascript:;">bölümler listesi</asp:HyperLink>            
        </Header>
        <Content>
            <asp:Repeater ID="rptDepartments" runat="server">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hlDepartment" NavigateUrl='<%#ArrangeSearchUrlByDepartment(Eval("Value").ToString()) %>'><%#Eval("Description") %></asp:HyperLink>
            </ItemTemplate>
            </asp:Repeater>
        </Content>
    </ajaxToolkit:AccordionPane> 
    
    </Panes>
</ajaxToolkit:Accordion>

<ajaxToolkit:Accordion ID="accFirmGrp2" runat="server" SelectedIndex="0" CssClass="Nav" FadeTransitions="false" 
FramesPerSecond="40" TransitionDuration="150" AutoSize="None" RequireOpenedPane="true" SuppressHeaderPostbacks="false">
   <Panes>
   
    <ajaxToolkit:AccordionPane ID="accFirm2_MyAdvertisements" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlFirm2_MyAdvertisements" NavigateUrl="javascript:;">ilanlarım</asp:HyperLink>
        </Header>
        <Content>
            <asp:HyperLink runat="server" ID="hlFirm2_FirmMainPage" NavigateUrl="#">Genel bakış</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlFirm2_Advertisements" NavigateUrl="#">İlanlarım</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlFirm2_AdvertisementForm" NavigateUrl="#">Yeni ilan girişi</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlFirm2_FirmApplications" NavigateUrl="#">Başvurular</asp:HyperLink>
        </Content>
    </ajaxToolkit:AccordionPane>

    <ajaxToolkit:AccordionPane ID="accFirm2_SignUp" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlFirm2_SignUp" NavigateUrl="#">üyelik bilgilerim</asp:HyperLink>
        </Header>
    </ajaxToolkit:AccordionPane>
    
    <ajaxToolkit:AccordionPane ID="accFirm2_CareerPlaning" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlFirm2_CareerPlaning" NavigateUrl="javascript:;">kariyer planlama</asp:HyperLink>            
        </Header>
        <Content>
            <asp:HyperLink runat="server" ID="hlFirm2_Interviews" NavigateUrl="#">Röportajlar</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlFirm2_SuccessStories" NavigateUrl="#">Başarı Hikayeleri</asp:HyperLink>
            <asp:HyperLink runat="server" ID="hlFirm2_Articles" NavigateUrl="#">Makaleler</asp:HyperLink>
        </Content>
    </ajaxToolkit:AccordionPane>                       
        
    <ajaxToolkit:AccordionPane ID="accFirm2_Announcements" runat="server">
        <Header>
            <asp:HyperLink CssClass="NavFl" runat="server" ID="hlFirm2_Announcements" NavigateUrl="#">duyurular</asp:HyperLink>
        </Header>
    </ajaxToolkit:AccordionPane>
    
    </Panes>
</ajaxToolkit:Accordion>

</asp:PlaceHolder>
<%-- ----- --%>