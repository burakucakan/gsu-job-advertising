<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCvForm.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.uCvForm" %>

<%@ Register src="../Common/HelperControls/uItem.ascx" tagname="uItem" tagprefix="uc1" %>

<%@ Register src="Edit/uWelcome.ascx" tagname="uWelcome" tagprefix="uc3" %>

<%@ Register src="Edit/uPersonalInfo.ascx" tagname="uPersonalInfo" tagprefix="uc4" %>

<%@ Register src="Edit/uCvFormNavigation.ascx" tagname="uCvFormNavigation" tagprefix="uc2" %>

<%@ Register src="Edit/uCommunicationInfo.ascx" tagname="uCommunicationInfo" tagprefix="uc5" %>

<%@ Register src="Edit/uCityCountryInfo.ascx" tagname="uCityCountryInfo" tagprefix="uc6" %>

<%@ Register src="Edit/uCigaretteUsage.ascx" tagname="uCigaretteUsage" tagprefix="uc7" %>

<%@ Register src="Edit/uUserClubs.ascx" tagname="uUserClubs" tagprefix="uc8" %>

<%@ Register src="Edit/uEducationState.ascx" tagname="uEducationState" tagprefix="uc9" %>

<%@ Register src="Edit/uMasterInfo.ascx" tagname="uMasterInfo" tagprefix="uc10" %>

<%@ Register src="Edit/uUniversityInfo.ascx" tagname="uUniversityInfo" tagprefix="uc11" %>

<%@ Register src="Edit/uHighSchoolInfo.ascx" tagname="uHighSchoolInfo" tagprefix="uc12" %>

<%@ Register src="Edit/uLanguagelInfo.ascx" tagname="uLanguagelInfo" tagprefix="uc13" %>

<%@ Register src="Edit/uComputerInfo.ascx" tagname="uComputerInfo" tagprefix="uc15" %>

<%@ Register src="Edit/uCertificateInfo.ascx" tagname="uCertificateInfo" tagprefix="uc14" %>

<%@ Register src="Edit/uExamInfo.ascx" tagname="uExamInfo" tagprefix="uc16" %>

<%@ Register src="Edit/uCourseInfo.ascx" tagname="uCourseInfo" tagprefix="uc17" %>

<%@ Register src="Edit/uDrivingLicense.ascx" tagname="uDrivingLicense" tagprefix="uc18" %>
<%@ Register src="Edit/uPositions.ascx" tagname="uPositions" tagprefix="uc19" %>

<%@ Register src="Edit/uExperienceInfo.ascx" tagname="uExperienceInfo" tagprefix="uc20" %>

<%@ Register src="Edit/uReferanceInfo.ascx" tagname="uReferanceInfo" tagprefix="uc21" %>

<%@ Register src="Edit/uCVState.ascx" tagname="uCVState" tagprefix="uc22" %>

<%@ Register src="Edit/uMyPhoto.ascx" tagname="uMyPhoto" tagprefix="uc23" %>
<%@ Register src="Edit/uCVResult.ascx" tagname="uCVResult" tagprefix="uc24" %>

<div class="SubPageWide">

    <h1>cv oluşturma</h1>
    
    <ins> 
    </ins>               
    
    <uc2:uCvFormNavigation ID="uCvFormNavigation1" runat="server" OnMenuItemClick="uCvFormNavigation1_OnMenuItemClick" />    
    <uc3:uWelcome ID="uWelcome1" runat="server"  OnSubmitForm="Control_SubmitForm"/>
    <uc4:uPersonalInfo ID="uPersonalInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc5:uCommunicationInfo ID="uCommunicationInfo1" runat="server" OnSubmitForm="Control_SubmitForm" />
    <uc6:uCityCountryInfo ID="uCityCountryInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc7:uCigaretteUsage ID="uCigaretteUsage1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc8:uUserClubs ID="uUserClubs1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc9:uEducationState ID="uEducationState1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc10:uMasterInfo ID="uMasterInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc11:uUniversityInfo ID="uUniversityInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc12:uHighSchoolInfo ID="uHighSchoolInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc13:uLanguagelInfo ID="uLanguagelInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc15:uComputerInfo ID="uComputerInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc14:uCertificateInfo ID="uCertificateInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc16:uExamInfo ID="uExamInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc17:uCourseInfo ID="uCourseInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc18:uDrivingLicense ID="uDrivingLicense1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc19:uPositions ID="uPositions1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc20:uExperienceInfo ID="uExperienceInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc21:uReferanceInfo ID="uReferanceInfo1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc22:uCVState ID="uCVState1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc23:uMyPhoto ID="uMyPhoto1" runat="server" OnSubmitForm="Control_SubmitForm"/>
    <uc24:uCVResult ID="uCVResult1" runat="server" OnSubmitForm="Control_SubmitForm"/>

    <ins></ins>
        
</div>
