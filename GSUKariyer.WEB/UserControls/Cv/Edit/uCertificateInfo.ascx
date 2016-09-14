<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCertificateInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uCertificateInfo" %>
<%@ Register src="../../Common/HelperControls/uDateDropDown.ascx" tagname="uDateDropDown" tagprefix="uc1" %>
<%@ Register src="../../SiteParamControls/uCertificateTypes.ascx" tagname="uCertificateTypes" tagprefix="uc2" %>
<%@ Register src="../../Common/HelperControls/uItem.ascx" tagname="uItem" tagprefix="uc3" %>
<div class="CvFormContent">
    <b>SERTİFİKA BİLGİLERİ</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplCertificateInfo" runat="server">
        <ContentTemplate>
        <asp:UpdateProgress ID="upCertificateInfo" runat="server" AssociatedUpdatePanelID="uplCertificateInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
    <asp:Repeater ID="rptCertificates" runat="server">
    <ItemTemplate>
        <uc3:uItem ID="uCertificateItem" runat="server" IsEdit='<%#ArrangeIsEdit(Container) %>' IsRemove='<%#ArrangeIsEdit(Container) %>' 
            Text='<%#ArrangeCertificateDesc(Eval("Name").ToString(),Eval("TakenInstitution").ToString(),Eval("CertificateDate").ToString()) %>' OnItemRemove="uCertificateItem_ItemRemove" OnItemEdit="uCertificateItem_ItemEdit"  />
        <asp:HiddenField id="hfId" runat="server" Value='<%#Eval("ID") %>'/>
        <asp:HiddenField id="hfCerticateDate" runat="server" Value='<%#Eval("CertificateDate") %>'/>
        <asp:HiddenField id="hfCertificateCategory" runat="server" Value='<%#Eval("Category") %>'/>
        <asp:HiddenField id="hfCertificateName" runat="server" Value='<%#Eval("Name") %>'/>
        <asp:HiddenField id="hfCertificateFirm" runat="server" Value='<%#Eval("TakenInstitution") %>'/>
        <asp:HiddenField id="hfCertificateDescription" runat="server" Value='<%#Eval("Description") %>'/>
    </ItemTemplate>
    </asp:Repeater>
    <ins></ins><ins></ins>
    <div class="Form" style="width:430px;">
        
        <div class="Panel">
            Lütfen sertifika bilgilerinizi giriniz.       
        </div>
        
        <asp:HiddenField id="hfRepeaterIndex" runat="server"/>
        <br /><br />
        <p class="Free">Aldığınız Tarih</p>
        <uc1:uDateDropDown ID="uCertificateDate" runat="server" />
        
        <p class="Free">Kategori</p>
        <uc2:uCertificateTypes ID="uCertificateTypes1" runat="server" />
        
        <p>Sertifika Adı</p>
        <asp:TextBox ID="txtCertificateName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCertificateName" runat="server" ControlToValidate="txtCertificateName"
         ErrorMessage="Lütfen Sertifika Adını Giriniz" ValidationGroup="vgCertificateAdd"></asp:RequiredFieldValidator>
        <p>Alındığı Kurum</p>
        <asp:TextBox ID="txtCertificateFirm" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCertificateFirm" runat="server" ControlToValidate="txtCertificateFirm"
         ErrorMessage="Lütfen Aldığınız Kurum Bilgisini Giriniz" ValidationGroup="vgCertificateAdd"></asp:RequiredFieldValidator>
        <p class="Free">Açıklama</p>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
        
        <br />
        <asp:ImageButton runat="server" ID="imgBtnAdd" 
        ImageUrl="~/Images/Button/Add.jpg" onclick="imgBtnAdd_Click" ValidationGroup="vgCertificateAdd" /> 
        <asp:ImageButton id="btnCancel" runat="server" onclick="btnCancel_Click"  Visible="false" ImageUrl="~/Images/Button/Cancel.jpg"/>
    </div>

    <ins></ins>
    <div style="width:425px;text-align:right;">
    <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgCertificateInfo" /> 
   </div>
   </ContentTemplate>
   <Triggers>
        <asp:PostBackTrigger ControlID="imgBtnSend" />
   </Triggers>
   </asp:UpdatePanel>
</div>

