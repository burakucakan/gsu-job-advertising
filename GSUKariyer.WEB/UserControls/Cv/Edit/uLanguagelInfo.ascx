<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uLanguagelInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uLanguagelInfo" %>

<%@ Register Src="~/UserControls/Common/HelperControls/uDateDropDown.ascx" TagName="uDateDropDown" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/SiteParamControls/uUniversityDepartments.ascx" TagName="uUniversityDepartments" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/SiteParamControls/uEducationGradeSystem.ascx" TagName="uEducationGradeSystem" TagPrefix="uc4" %>
<%@ Register src="~/UserControls/Common/HelperControls/uNumericDropdown.ascx" tagname="uNumericDropdown" tagprefix="uc2" %>

<script type="text/javascript">

    var arrLngElements = new Array();

    function cValLanguageInfo(source, args) {

        args.IsValid = false;
        
        var hdLngElIds = $get('<%=hdValScr.ClientID %>').value;
        hdLngElIds = Left(hdLngElIds, hdLngElIds.length - 1);
        var scrIds = hdLngElIds.split('~');
        
        var errMsg = "||Lang|| için istenen bilgileri giriniz";

        var LngItem;
        var LngName;
        var LngRead;
        var LngWrite;
        var LngTalk;
        var LngLearnPlace;
        
        for (var i = 0; i < scrIds.length; i++) {

            LngItem = scrIds[i].split(',');

            LngName = ddlSelectedText(LngItem[0]);
            LngRead = $get(LngItem[1]).selectedIndex;
            LngWrite = $get(LngItem[2]).selectedIndex;
            LngTalk = $get(LngItem[3]).selectedIndex;
            LngLearnPlace = $get(LngItem[4]).value;

            args.IsValid = (LngName == 'Seçiniz') || (
                    LngRead > 0 && LngWrite > 0 && LngTalk > 0 && LngLearnPlace.length > 0
                );

            if (!args.IsValid) {
                //alert(errMsg.replace('||Lang||', LngName));
                $get('spncValErr').style.display = '';
                $get('spncValErr').innerHTML = errMsg.replace('||Lang||', LngName);
                break;
            } 
            else
                $get('spncValErr').style.display = 'none';
        }
    }
    
</script>

<div class="CvFormContent">
    
    <b>YABANCI DİL</b>
    <br /><br />
    
    <div class="Form">
    
        <div class="Panel">
            Bildiğiniz yabancı dillere ait bilgileri ilgili alanlara giriniz. <br />
            Yabancı dil seviyenizi, okuma, yazma ve konuşma olarak derecelendiriniz. <br />
            Derecelendirmede 1 başlangıç seviyesini, 10 ise en üst seviyeyi göstermektedir.
        </div>
        
        <ins></ins><ins></ins>
                
        <asp:CustomValidator ID="cValLanguage" runat="server" Display="None" ClientValidationFunction="cValLanguageInfo" ErrorMessage="Lütfen bilgileri giriniz" ValidationGroup="vgLanguageInfo" />
        
        <table cellpadding="1" cellspacing="1" border="0">
            <tr>
                <td>
                    Dil
                    <span id="spncValErr" style="display: none;"></span>
                </td>
                <td>Okuma</td>
                <td>Yazma</td>
                <td>Konuşma</td>
                <td>Öğrendiğiniz Yer</td>
            </tr>
        
        <asp:Repeater ID="rptLanguageInfo" runat="server" OnItemDataBound="rptLanguageInfo_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlLanguages" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <uc2:uNumericDropdown ID="uReadGrade" runat="server" ValidationGroup="vgLanguageInfo" ValidationMessage="*"  ClientValidationEnabled="false"/>
                </td>
                <td>
                    <uc2:uNumericDropdown ID="uWriteGrade" runat="server" ValidationGroup="vgLanguageInfo" ValidationMessage="*" ClientValidationEnabled="false"/>
                </td>
                <td>
                    <uc2:uNumericDropdown ID="uTalkGrade" runat="server" ValidationGroup="vgLanguageInfo" ValidationMessage="*" ClientValidationEnabled="false"/>
                </td>
                <td>
                    <asp:TextBox ID="txtLearnPlace" runat="server" MaxLength="255"></asp:TextBox>
                </td>
            </tr>
            
        </ItemTemplate>
        </asp:Repeater>
        
        </table>
        
        <br />        
        
        <asp:ImageButton runat="server" ID="imgBtnSend" ImageUrl="~/Images/Button/SaveAndContinue.jpg" OnClick="imgBtnSend_Click" ValidationGroup="vgLanguageInfo" />
        
        <ins></ins>
        
    </div>
</div>

<asp:HiddenField runat="server" ID="hdValScr"></asp:HiddenField>