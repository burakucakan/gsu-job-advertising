<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uExperienceInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uExperienceInfo" %>
<%@ Register src="../../Common/HelperControls/uDateDropDown.ascx" tagname="uDateDropDown" tagprefix="uc1" %>
<%@ Register src="../../SiteParamControls/uCertificateTypes.ascx" tagname="uCertificateTypes" tagprefix="uc2" %>
<%@ Register src="../../Common/HelperControls/uItem.ascx" tagname="uItem" tagprefix="uc3" %>
<%@ Register src="../../SiteParamControls/uCityCountry.ascx" tagname="uCityCountry" tagprefix="uc4" %>
<%@ Register src="../../SiteParamControls/uSectors.ascx" tagname="uSectors" tagprefix="uc5" %>
<%@ Register src="../../SiteParamControls/uWorkerCounts.ascx" tagname="uWorkerCounts" tagprefix="uc6" %>
<%@ Register src="../../SiteParamControls/uPositions.ascx" tagname="uPositions" tagprefix="uc7" %>
<%@ Register src="../../SiteParamControls/uWorkingType.ascx" tagname="uWorkingType" tagprefix="uc8" %>
<%@ Register src="../../SiteParamControls/uPersonalCount.ascx" tagname="uPersonalCount" tagprefix="uc9" %>
<%@ Register src="../../SiteParamControls/uExperienceCount.ascx" tagname="uExperienceCount" tagprefix="uc10" %>
<%@ Register src="../../Common/uPhoneNumber.ascx" tagname="uPhoneNumber" tagprefix="uc11" %>
<%@ Register src="../../SiteParamControls/uWorkingExperiences.ascx" tagname="uWorkingExperiences" tagprefix="uc12" %>
<%@ Register src="../../SiteParamControls/uWorkingStatus.ascx" tagname="uWorkingStatus" tagprefix="uc13" %>
<div class="CvFormContent">
    <b>İŞ TECRÜBELERİM</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplExperienceInfo" runat="server">
        <ContentTemplate>
        <asp:UpdateProgress ID="upExperienceInfo" runat="server" AssociatedUpdatePanelID="uplExperienceInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
        
    
    <div class="Form" style="width:430px;">    
     <div class="Panel">Lütfen iş tecrübelerinizi giriniz.</div>
     <p>Toplam İş ve/veya Staj Tecrübem</p>
        <uc12:uWorkingExperiences ID="uWorkingExperiences1" runat="server" ValidationGoup="vgExperienceInfo" />
     <p>Çalışma Durumum</p>
        <uc13:uWorkingStatus ID="uWorkingStatus1" runat="server" ValidationGoup="vgExperienceInfo"  />
     <div class="Panel">İş Tecrübelerim</div>
    </div>
    <ins></ins>
    
    <asp:Repeater ID="rptItems" runat="server">
    <ItemTemplate>
        <uc3:uItem ID="uItem" runat="server" IsEdit='<%#ArrangeIsEdit(Container) %>' IsRemove='<%#ArrangeIsEdit(Container) %>' 
            Text='<%#ArrangeDesc(Eval("FirmName").ToString(),Eval("WorkStartDate").ToString()) %>' OnItemRemove="uItem_ItemRemove" OnItemEdit="uItem_ItemEdit"  />
        <asp:HiddenField id="hfId" runat="server" Value='<%#Eval("ID") %>'/>
        <asp:HiddenField id="hfFirmName" runat="server" Value='<%#Eval("FirmName") %>'/>
        <asp:HiddenField id="hfStartDate" runat="server" Value='<%#Eval("WorkStartDate") %>'/>
        <asp:HiddenField id="hfEndDate" runat="server" Value='<%#Eval("WorkEndDate") %>'/>
        <asp:HiddenField id="hfCity" runat="server" Value='<%#Eval("WorkCity") %>'/>
        <asp:HiddenField id="hfSector" runat="server" Value='<%#Eval("FirmSector") %>'/>
        <asp:HiddenField id="hfPosition" runat="server" Value='<%#Eval("WorkingPosition") %>'/>
        <asp:HiddenField id="hfWorkerCount" runat="server" Value='<%#Eval("FirmWorkerCount") %>'/>
        <asp:HiddenField id="hfWorkingType" runat="server" Value='<%#Eval("WorkingType") %>'/>
        <asp:HiddenField id="hfPersonelCount" runat="server" Value='<%#Eval("NumberOfPeopleOnResponsibility") %>'/>
        <asp:HiddenField id="hfExperience" runat="server" Value='<%#Eval("WorkingExperience") %>'/>
        <asp:HiddenField id="hfLeaveReason" runat="server" Value='<%#Eval("JobLeavingReason") %>'/>
        <asp:HiddenField id="hfDescription" runat="server" Value='<%#Eval("JobDescription") %>'/>
        <asp:HiddenField id="hfResponsibleName" runat="server" Value='<%#Eval("ResponsibleName") %>'/>
        <asp:HiddenField id="hfResponsibleTitle" runat="server" Value='<%#Eval("ResponsibleTitle") %>'/>
        <asp:HiddenField id="hfResponsiblePhone" runat="server" Value='<%#Eval("ResponsiblePhone") %>'/>
    </ItemTemplate>
    </asp:Repeater>
   
    
    <div class="Form" style="width:430px;">    
        <asp:HiddenField id="hfRepeaterIndex" runat="server"/>
        <asp:HiddenField id="hfItemId" runat="server"/>
        <br /><br />
        <p>Firma Adı</p>
        <asp:TextBox ID="txtFirm" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFirm" runat="server" ControlToValidate="txtFirm" Display="Dynamic"
         ErrorMessage="Lütfen Firma Adını Giriniz" ValidationGroup="vgExperienceAdd"></asp:RequiredFieldValidator>
        
        <p>İşe Giriş Tarihi</p>
        <uc1:uDateDropDown ID="uStartDate" runat="server" ValidationRequired="true" ValidationGroup="vgExperienceAdd" ValidationError="Lütfen İşe Giriş Tarihini Giriniz"/>
        
        <p class="Free">İşten Ayrılma Tarihi</p>
        <uc1:uDateDropDown ID="uEndDate" runat="server"/>
        
        <p>Şehir</p>
        <uc4:uCityCountry ID="uCityCountry1" runat="server"  ValidationRequired="true" ValidationGroup="vgExperienceAdd" ValidationErrorMessage="Lütfen Şehir Bilgisini Giriniz"/>
        
        <p>Firmanızın Faaliyet Gösterdiği Sektör</p>
        <uc5:uSectors ID="uSectors1" runat="server"  ValidationRequired="true" ValidationGroup="vgExperienceAdd" ValidationErrorMessage="Lütfen Firmanızın Faaliyet Gösterdiği Sektörü Giriniz"/>
        
        <p class="Free">Firmadaki Çalışan Sayısı</p>
        <uc6:uWorkerCounts ID="uWorkerCounts1" runat="server" />
        
        <p>Firmadaki Pozisyonunuz</p>
        <uc7:uPositions ID="uPositions1" runat="server" ValidationRequired="true" ValidationGroup="vgExperienceAdd" ValidationErrorMessage="Lütfen Firmadaki Pozisyonunuzu Giriniz"/>
        
        <p class="Free">Çalışma Şekli</p>      
        <uc8:uWorkingType ID="uWorkingType1" runat="server" />
        
        <p class="Free">Size Bağlı Personel Sayısı</p>      
        <uc9:uPersonalCount ID="uPersonalCount1" runat="server" />
        
        <p class="Free">Bu Pozisondaki Tecrübeniz</p>
        <uc10:uExperienceCount ID="uExperienceCount1" runat="server" />
        
        <p class="Free">İşten Ayrılma Sebebiniz</p>
        <asp:TextBox ID="txtJobLeaveReason" runat="server" MaxLength="100"></asp:TextBox>
        
        <p>İş Tanımı</p>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup="vgExperienceAdd" ErrorMessage="Lütfen İş Tanımını Giriniz"></asp:RequiredFieldValidator>
        
        <br />
        <p>Firmada bağlı olduğunuz kişinin;</p>
        <br />
        
        <p class="Free">Adı</p>
        <asp:TextBox ID="txtResponsibleName" runat="server"></asp:TextBox>
        
        <p class="Free">Ünvanı</p>
        <asp:TextBox id="txtResponsibleTitle" runat="server"></asp:TextBox>
        
        <p class="Free">Telefonu</p>
        <uc11:uPhoneNumber ID="uResponsiblePhoneNumber" runat="server" />        
        
        <br />
        <asp:ImageButton runat="server" ID="imgBtnAdd" 
        ImageUrl="~/Images/Button/Add.jpg" onclick="imgBtnAdd_Click" ValidationGroup="vgExperienceAdd" /> 
        <asp:ImageButton id="btnCancel" runat="server" onclick="btnCancel_Click"  Visible="false" ImageUrl="~/Images/Button/Cancel.jpg"/>
    </div>

    <ins></ins>
   
    <div style="width:425px;text-align:right;">
    <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgExperienceInfo" /> 
   </div>
   </ContentTemplate>
   <Triggers>
        <asp:PostBackTrigger ControlID="imgBtnSend" />
   </Triggers>
   </asp:UpdatePanel>
</div>

