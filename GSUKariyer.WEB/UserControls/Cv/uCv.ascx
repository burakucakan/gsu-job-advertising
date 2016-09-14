<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCv.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.uCv" %>
<%@ Register src="../Common/uBanner.ascx" tagname="uBanner" tagprefix="uc1" %>


<div class="SubPage">

    <h1><asp:Literal ID="ltrDataCvName" runat="server"></asp:Literal></h1>
    
    <ins></ins>        
    
    
    <div class="Cv">
    
        <asp:Panel ID="pnlSendMessage" runat="server" CssClass="Form">
        
        <p>Başvuruyu Cevaplayın</p>
        <asp:TextBox runat="server" ID="txtMessage" ValidationGroup="vgSendMessage" TextMode="MultiLine" Height="70"></asp:TextBox>
        
        <asp:ImageButton runat="server" ID="btnImgSendMessage" ImageUrl="~/Images/Button/SendMessage.jpg" OnClick="btnImgSendMessage_Click" />
        
        </asp:Panel>
        
            
        <div class="CvHeader">
        
            <asp:Image runat="server" ID="imgUser" ImageUrl="~/Images/_U/Users/Default/gsu_1.jpg" />
        
            <div>    
                <h3><asp:Literal ID="ltrDataName" runat="server"></asp:Literal></h3>

                <asp:HyperLink runat="server" ID="hlDataMail"></asp:HyperLink>        
                
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td><b><asp:Literal ID="ltrStudentNumber" runat="server" Text="Öğr. No"></asp:Literal></b></td>
                        <td>:</td>
                        <td><asp:Literal ID="ltrDataStudentNumber" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td><b><asp:Literal ID="ltrMobileNo" runat="server" Text="Cep"></asp:Literal></b></td>
                        <td>:</td>
                        <td><asp:Literal ID="ltrDataMobileNo" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td><b><asp:Literal ID="ltrHomePhone" runat="server" Text="Ev"></asp:Literal></b></td>
                        <td>:</td>
                        <td><asp:Literal ID="ltrDataHomePhone" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td><b><asp:Literal ID="ltrAddress" runat="server" Text="Adres"></asp:Literal></b></td>
                        <td>:</td>
                        <td><asp:Literal ID="ltrDataAddress" runat="server"></asp:Literal></td>
                    </tr>               
                </table>
                
            </div>
        
        </div>

        <ins></ins>

        <div class="Panel">
            
            <h2><asp:Literal ID="ltrPersonalInfo" runat="server" Text="KİŞİSEL BİLGİLER"></asp:Literal></h2>
            
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><b><asp:Literal ID="ltrEducationState" runat="server" Text="Eğitim Durumu"></asp:Literal></b></td>
                    <td>:</td>
                    <td><asp:Literal ID="ltrDataEducationState" runat="server"></asp:Literal></td>
                    <td width="150"></td>
                    <td><b><asp:Literal ID="ltrDateOfBirth" runat="server" Text="Doğum Tarihi"></asp:Literal></b></td>
                    <td>:</td>
                    <td><asp:Literal ID="ltrDataDateOfBirth" runat="server"></asp:Literal></td>                
                </tr>
                <tr>
                    <td><b><asp:Literal ID="ltrMaritalStatus" runat="server" Text="Medeni Durum"></asp:Literal></b></td>
                    <td>:</td>
                    <td><asp:Literal ID="ltrDataMaritalStatus" runat="server"></asp:Literal></td>
                    <td></td>
                    <td><b><asp:Literal ID="ltrBirthPlace" runat="server" Text="Doğum Yeri"></asp:Literal></b></td>
                    <td>:</td>
                    <td><asp:Literal ID="ltrDataBirthPlace" runat="server"></asp:Literal></td>                
                </tr>
                <tr>
                    <td><b><asp:Literal ID="ltrExperience" runat="server" Text="Tecrübe"></asp:Literal></b></td>
                    <td>:</td>
                    <td><asp:Literal ID="ltrDataExperience" runat="server"></asp:Literal></td>
                    <td></td>
                    <td><b><asp:Literal ID="ltrDrivingLicense" runat="server" Text="Sürücü Belgesi"></asp:Literal></b></td>
                    <td>:</td>
                    <td><asp:Literal ID="ltrDataDrivingLicense" runat="server"></asp:Literal></td>      
                </tr>
                <tr>
                    <td><b><asp:Literal ID="ltrWorkStatus" runat="server" Text="Çalışma Durumu"></asp:Literal></b></td>
                    <td>:</td>
                    <td><asp:Literal ID="ltrDataWorkStatus" runat="server"></asp:Literal></td>
                    <td></td>
                    <td><b><asp:Literal ID="ltrNationality" runat="server" Text="Uyruk"></asp:Literal></b></td>
                    <td>:</td>
                    <td><asp:Literal ID="ltrDataNationality" runat="server"></asp:Literal></td>                
                </tr>
            </table>

        </div>
        
        <ins></ins>
        
        <div class="Panel">
            
            <h2><asp:Literal ID="ltrEducationInfo" runat="server" Text="EĞİTİM BİLGİLERİ"></asp:Literal></h2>
            <table width="100%" cellpadding="0" cellspacing="0">
            <tr id="trMaster" runat="server" visible="false">
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr valign="top" align="left">
                            <td width="150px">
                            <b><asp:Literal ID="ltrMasterInfo" runat="server"></asp:Literal></b>
                            </td>
                            <td>
                            <b><asp:Literal ID="ltrDataMasterUniversity" runat="server"></asp:Literal></b>
                            </td>
                            <td width="150px"><asp:Literal ID="ltrDataMasterScore" runat="server"></asp:Literal></td>
                        </tr>
                        <tr valign="top" align="left">
                            <td><asp:Literal ID="ltrDataMasterDates" runat="server"></asp:Literal></td>
                            <td><asp:Literal ID="ltrDataMasterDesc" runat="server"></asp:Literal></td>
                            <td></td>
                        </tr>
                    </table>    
                </td>
            </tr>
            <tr id="trLicense" runat="server" visible="true">
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr valign="top" align="left">
                            <td width="150px">
                                <b><asp:Literal ID="ltrLicenseInfo" runat="server"></asp:Literal></b>
                            </td>
                            <td>
                                <b><asp:Literal ID="ltrDataLicenseUniversity" runat="server"></asp:Literal></b>
                            </td>
                            <td width="150px"><asp:Literal ID="ltrDataLicenseScore" runat="server"></asp:Literal></td>
                        </tr>
                        <tr valign="top" align="left">
                            <td><asp:Literal ID="ltrDataLicenseDates" runat="server"></asp:Literal></td>
                            <td><asp:Literal ID="ltrDataLicenseDesc" runat="server"></asp:Literal></td>
                            <td></td>
                        </tr>
                    </table>    
                </td>
            </tr>
            <tr id="trHighSchool" runat="server" visible="true">
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr valign="top" align="left">
                            <td width="150px">
                                <b><asp:Literal ID="ltrHighSchoolInfo" runat="server"></asp:Literal></b>
                            </td>
                            <td>
                                <b><asp:Literal ID="ltrDataHighSchool" runat="server"></asp:Literal></b>
                            </td>
                            <td width="150px"><asp:Literal ID="ltrDataHighSchoolScore" runat="server"></asp:Literal></td>
                        </tr>
                        <tr valign="top" align="left">
                            <td><asp:Literal ID="ltrDataHighSchoolDates" runat="server"></asp:Literal></td>
                            <td><asp:Literal ID="ltrDataHighSchoolDesc" runat="server"></asp:Literal></td>
                            <td></td>
                        </tr>
                    </table>    
                </td>
            </tr>
            </table>

        </div>
        
        <ins></ins>
        
        <div class="Panel">
            
            <h2><asp:Literal ID="ltrExperienceInfo" runat="server" Text="İŞ TECRÜBELERİ"></asp:Literal></h2>
            <asp:Repeater id="rptWorkExperience" runat="server" 
                onitemdatabound="rptWorkExperience_ItemDataBound">
            <ItemTemplate>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr valign="top" align="left">
                        <td width="150px">
                        <b><asp:Literal ID="ltrDataExperinceDate" runat="server"></asp:Literal></b>
                        </td>
                        <td>
                            <b><asp:Literal ID="ltrDataFirmName" runat="server"></asp:Literal></b><br />
                            <asp:Literal ID="ltrDataPosition" runat="server"></asp:Literal>
                        </td>
                        <td width="150px"><asp:Literal ID="ltrDataFirmCity" runat="server"></asp:Literal></td>
                    </tr>
                    <tr valign="top" align="left">
                        <td colspan="3"><asp:Literal ID="ltrDataDesc" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table cellpadding="2" cellspacing="0" border="0">
                                <tr>
                                    <td width="160"><asp:Literal ID="ltrFirmSector" runat="server"></asp:Literal></td>
                                    <td width="5">:</td>
                                    <td width="182"><asp:Literal ID="ltrDataFirmSector" runat="server"></asp:Literal></td>
                                    <td width="160"><asp:Literal ID="ltrFirmWorkerCount" runat="server"></asp:Literal></td>
                                    <td width="5">:</td>
                                    <td width="183"><asp:Literal ID="ltrDataFirmWorkerCount" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td><asp:Literal ID="ltrWorkType" runat="server"></asp:Literal></td>
                                    <td>:</td>
                                    <td><asp:Literal ID="ltrDataWorkType" runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="ltrPersonelCount" runat="server"></asp:Literal></td>
                                    <td>:</td>
                                    <td><asp:Literal ID="ltrDataPersonelCount" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td><asp:Literal ID="ltrRelatedPerson" runat="server"></asp:Literal></td>
                                    <td>:</td>
                                    <td colspan="4"><asp:Literal ID="ltrDataRelatedPerson" runat="server"></asp:Literal></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>    
            </ItemTemplate>
            </asp:Repeater>
        </div>
        
        <ins></ins>
        
        <div class="Panel">    
            <h2><asp:Literal ID="ltrQualifications" runat="server" Text="NİTELİKLERİM"></asp:Literal></h2>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr valign="top" align="left">
                    <td width="180">
                        <b><asp:Literal ID="ltrLanguage" runat="server"></asp:Literal></b>              
                    </td>
                    <td style="padding-top:0px;padding-left:0px;">
                        <asp:Repeater ID="rptLanguages" runat="server" 
                            onitemdatabound="rptLanguages_ItemDataBound">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="margin-top:0px;" width="100%">
                                <tr>
                                    <td style="padding-right:20px;" nowrap>
                                    - <b><asp:Literal ID="ltrDataLanguage" runat="server"></asp:Literal></b>                                </td>
                                    <td width="100%"><asp:Literal ID="ltrDataLanguageDetail" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td><asp:Literal ID="ltrDataLearnPlace" runat="server"></asp:Literal></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5px"></td>
                </tr>
                <tr>
                    <td><b><asp:Literal ID="ltrComputerInfo" runat="server"></asp:Literal></b></td>
                    <td><asp:Literal ID="ltrDataComputerInfo" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="2" height="5px"></td>
                </tr>
                <tr>
                    <td valign="top"><b><asp:Literal ID="ltrCourseInfo" runat="server"></asp:Literal></b></td>
                    <td style="padding-top:0px;padding-left:0px;">
                        <asp:Repeater ID="rptCourseInfo" runat="server" 
                            onitemdatabound="rptCourseInfo_ItemDataBound">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="margin-top:0px;">
                                <tr>
                                    <td>
                                    - <b><asp:Literal ID="ltrDataCourseName" runat="server"></asp:Literal></b>                                </td>
                               </tr>
                               <tr>
                                    <td><asp:Literal ID="ltrDataCourseDesc" runat="server"></asp:Literal></td>
                               </tr>
                            </table>
                        </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5px"></td>
                </tr>
                <tr>
                    <td valign="top"><b><asp:Literal ID="ltrCertificateInfo" runat="server"></asp:Literal></b></td>
                    <td style="padding-top:0px;padding-left:0px;">
                        <asp:Repeater ID="rptCertificateInfo" runat="server" 
                            onitemdatabound="rptCertificateInfo_ItemDataBound">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="margin-top:0px;">
                                <tr>
                                    <td>
                                    - <b><asp:Literal ID="ltrDataName" runat="server"></asp:Literal></b>                                </td>
                               </tr>
                               <tr>
                                    <td><asp:Literal ID="ltrDataDesc" runat="server"></asp:Literal></td>
                               </tr>
                               <tr>
                                    <td><asp:Literal ID="ltrDataNote" runat="server"></asp:Literal></td>
                               </tr>
                            </table>
                        </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5px"></td>
                </tr>
                <tr>
                    <td valign="top"><b><asp:Literal ID="ltrReferances" runat="server"></asp:Literal></b></td>
                    <td style="padding-top:0px;padding-left:0px;">
                        <asp:Repeater ID="rptReferances" runat="server" 
                            onitemdatabound="rptReferances_ItemDataBound">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="margin-top:0px;">
                                <tr>
                                    <td>
                                    - <b><asp:Literal ID="ltrDataName" runat="server"></asp:Literal></b>                                </td>
                               </tr>
                               <tr>
                                    <td><asp:Literal ID="ltrDataDesc" runat="server"></asp:Literal></td>
                               </tr>
                            </table>
                        </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5px"></td>
                </tr>
                <tr>
                    <td><b><asp:Literal ID="ltrCigaretteUsage" runat="server"></asp:Literal></b></td>
                    <td><asp:Literal ID="ltrDataCigaretteUsage" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="2" height="5px"></td>
                </tr>
                <tr>
                    <td><b><asp:Literal ID="ltrClubs" runat="server" Text="Dernekler & Kulüpler"></asp:Literal></b></td>
                    <td><asp:Literal ID="ltrDataClubs" runat="server" Text="-"></asp:Literal></td>
                </tr>
            </table>
        </div>
        
        <br /><br />
                
        <asp:HyperLink runat="server" ID="hlPrint" CssClass="Print" Target="_blank" ImageUrl="~/Images/Button/Print.jpg" />
    
    </div>
    
</div>

