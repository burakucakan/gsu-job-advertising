<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uExamInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uExamInfo" %>
<%@ Register src="../../Common/HelperControls/uDateDropDown.ascx" tagname="uDateDropDown" tagprefix="uc1" %>
<%@ Register src="../../SiteParamControls/uCertificateTypes.ascx" tagname="uCertificateTypes" tagprefix="uc2" %>
<%@ Register src="../../Common/HelperControls/uItem.ascx" tagname="uItem" tagprefix="uc3" %>
<%@ Register src="../../SiteParamControls/uExams.ascx" tagname="uExams" tagprefix="uc4" %>
<%@ Register src="../../Common/HelperControls/uNumericDropdown.ascx" tagname="uNumericDropdown" tagprefix="uc5" %>
<div class="CvFormContent">
    <b>SINAV BİLGİLERİ</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplExamInfo" runat="server">
        <ContentTemplate>
        <asp:UpdateProgress ID="upExamInfo" runat="server" AssociatedUpdatePanelID="uplExamInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
    <asp:Repeater ID="rptItems" runat="server">
    <ItemTemplate>
        <uc3:uItem ID="uItem1" runat="server" IsEdit="true" IsRemove="true" 
            Text='<%#ArrangeDesc(Eval("ExamName").ToString(),Eval("StartYear").ToString()) %>' OnItemRemove="uItem_ItemRemove" OnItemEdit="uItem_ItemEdit"  />
        <asp:HiddenField id="hfId" runat="server" Value='<%#Eval("ID") %>'/>
        <asp:HiddenField id="hfExamName" runat="server" Value='<%#Eval("ExamName") %>'/>
        <asp:HiddenField id="hfExamYear" runat="server" Value='<%#Eval("StartYear") %>'/>
        <asp:HiddenField id="hfExamCorporation" runat="server" Value='<%#Eval("ExamCorporation") %>'/>
        <asp:HiddenField id="hfExamScore" runat="server" Value='<%#Eval("ExamScore") %>'/>
        <asp:HiddenField id="hfDescription" runat="server" Value='<%#Eval("Description") %>'/>
    </ItemTemplate>
    </asp:Repeater>
    <ins></ins><ins></ins>
    <div class="Form" style="width:430px;">
    
        <div class="Panel">
            Lütfen girdiğiniz sınav bilgilerinizi giriniz.
        </div>
        
        <asp:HiddenField id="hfRepeaterIndex" runat="server"/>
        <br /><br />
        <p>Sınav Adı</p>
        <uc4:uExams ID="uExams1" runat="server" ValidationGroup="vgExamAdd" ValidationRequired="true" ValidationErrorMessage="Lütfen Sınav Adını Seçiniz"/>
        
        <p>Sınavı Yapan Kuruluş</p>
        <asp:TextBox ID="txtExamCorporation" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvExamCorporation" runat="server" Display="Dynamic" ControlToValidate="txtExamCorporation" ValidationGroup="vgExamAdd" ErrorMessage="Lütfen Sınavı Yapan Kuruluş Bilgisini Giriniz"></asp:RequiredFieldValidator>
                
        <p>Sınav Tarihi</p>
        <uc5:uNumericDropdown ID="uExamYear" runat="server"  OrderAsc="false" ValidationGroup="vgExamAdd" ValidationRequired="true" ValidationErrorMessage="Lütfen Sınav Tarihini Giriniz"/>
        
        <p>Sınav Skoru</p>
        <asp:TextBox ID="txtExamScore" runat="server" onkeyup="vNumber(this)"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvExamScore" runat="server" Display="Dynamic" ControlToValidate="txtExamScore" ValidationGroup="vgExamAdd" ErrorMessage="Lütfen Sınavı Skorunu Giriniz"></asp:RequiredFieldValidator>
        
        <p class="Free">Açıklamalar</p>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
        
        <br />
        <asp:ImageButton runat="server" ID="imgBtnAdd" 
        ImageUrl="~/Images/Button/Add.jpg" onclick="imgBtnAdd_Click" ValidationGroup="vgExamAdd" /> 
        <asp:ImageButton id="btnCancel" runat="server" onclick="btnCancel_Click"  Visible="false" ImageUrl="~/Images/Button/Cancel.jpg"/>
    </div>
    
    <ins></ins>
    <div style="width:425px;text-align:right;">
    <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgExamInfo" /> 
   </div>
   </ContentTemplate>
   <Triggers>
        <asp:PostBackTrigger ControlID="imgBtnSend" />
   </Triggers>
   </asp:UpdatePanel>
</div>

