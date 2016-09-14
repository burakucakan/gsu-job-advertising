<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFirm.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uFirm" %>

<%@ Register src="~/UserControls/SiteParamControls/uCountries.ascx" tagname="uCountries" tagprefix="ucCountries" %>
<%@ Register src="~/UserControls/SiteParamControls/uCities.ascx" tagname="uCities" tagprefix="ucCities" %>
<%@ Register Src="~/UserControls/Common/HelperControls/uItem.ascx" TagName="uItem" TagPrefix="Item" %>
<%@ Register src="uFirmAdvertisementList.ascx" tagname="uFirmAdvertisementList" tagprefix="uc1" %>
<%@ Register src="uFirmApplicationList.ascx" tagname="uFirmApplicationList" tagprefix="uc1" %>

<%@ Register src="../SiteParamControls/uUniversityDepartments.ascx" tagname="uUniversityDepartments" tagprefix="uc2" %>

<%@ Register src="../SiteParamControls/uWorkingType.ascx" tagname="uWorkingType" tagprefix="uc3" %>

<div class="SubPageWide">

    <h1>hızlı elaman ara</h1>

    <ins></ins>
    
    <div class="Panel">
           
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    Bölüm<br />
                    <asp:DropDownList ID="ddlUnivDepartments" runat="server" Width="315"></asp:DropDownList>
                </td>
                <td>
                    Yaş <br />
                    <asp:DropDownList runat="server" ID="ddlAge"></asp:DropDownList>
                </td>
                <td>                    
                    Çalışma Şekli<br />
                    <asp:DropDownList ID="ddlWorkTypes" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <br />
                    <asp:RadioButtonList id="rblEducationState" RepeatDirection="Horizontal" runat="server"></asp:RadioButtonList>
                </td>
                <td style="padding-top: 8px;">
                   <asp:ImageButton runat="server" ID="btnSearch" 
                        ImageUrl="~/Images/Button/QuickSearch.jpg" onclick="btnSearch_Click" /> 
                </td>
            </tr>
           </table>
        
    </div>
    <br />
        <asp:HyperLink runat="server" ID="hlUserDetailSearch" CssClass="Und" NavigateUrl="#">» detaylı arama</asp:HyperLink>

    <ins></ins><ins></ins>
        
    <h1>ilanlarım</h1>

    <ins></ins>
    
    <uc1:uFirmAdvertisementList ID="uFirmAdvertisementListLast" runat="server" />
    
    <ins></ins>
    
    <asp:HyperLink CssClass="Und" runat="server" ID="hlAllFirmAdvertisements" NavigateUrl="#">» tüm ilanlarım</asp:HyperLink>
    
    <ins></ins><ins></ins>
    
    <h1>son başvurular</h1>
    
    <ins></ins>

    <%--SON 10 BAŞVURU--%>
        
    <uc1:uFirmApplicationList ID="uFirmApplicationList1" runat="server" />
    
    <ins></ins>
    <asp:HyperLink CssClass="Und" runat="server" ID="hlFirmApplications" NavigateUrl="#">» tamamı</asp:HyperLink>

    <ins></ins><ins></ins>    
    
</div>