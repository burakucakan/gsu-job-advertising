<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uCourseInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uCourseInfo" %>
<%@ Register src="../../Common/HelperControls/uDateDropDown.ascx" tagname="uDateDropDown" tagprefix="uc1" %>
<%@ Register src="../../Common/HelperControls/uItem.ascx" tagname="uItem" tagprefix="uc3" %>

<div class="CvFormContent">
    <b>ALINAN EĞİTİMLER</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplCourseInfo" runat="server">
        <ContentTemplate>
        <asp:UpdateProgress ID="upCourseInfo" runat="server" AssociatedUpdatePanelID="uplCourseInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
    <asp:Repeater ID="rptItems" runat="server">
    <ItemTemplate>
        <uc3:uItem ID="uItem1" runat="server" IsEdit="true" IsRemove="true" 
            Text='<%#ArrangeDesc(Eval("Name").ToString(),Eval("Institution").ToString()) %>' OnItemRemove="uItem_ItemRemove" OnItemEdit="uItem_ItemEdit"  />
        <asp:HiddenField id="hfId" runat="server" Value='<%#Eval("ID") %>'/>
        <asp:HiddenField id="hfName" runat="server" Value='<%#Eval("Name") %>'/>
        <asp:HiddenField id="hfInstitution" runat="server" Value='<%#Eval("Institution") %>'/>
        <asp:HiddenField id="hfStartDate" runat="server" Value='<%#Eval("StartDate") %>'/>
        <asp:HiddenField id="hfEndDate" runat="server" Value='<%#Eval("EndDate") %>'/>
        <asp:HiddenField id="hfDuration" runat="server" Value='<%#Eval("DurationInHours") %>'/>
        <asp:HiddenField id="hfDescription" runat="server" Value='<%#Eval("Description") %>'/>
    </ItemTemplate>
    </asp:Repeater>
    <ins></ins><ins></ins>
    <div class="Form" style="width:430px;">
    
        <div class="Panel">
            Lütfen aldığınız mesleki ve kişisel eğitim bilgilerini giriniz.
        </div>
        
        <asp:HiddenField id="hfRepeaterIndex" runat="server"/>
        <br /><br />
        <p>Eğitim Adı</p>
        <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" Display="Dynamic" ControlToValidate="txtCourseName" ValidationGroup="vgCourseAdd" ErrorMessage="Lütfen Eğitim Adını Giriniz"></asp:RequiredFieldValidator>
        
        <p>Eğitim Kurumu</p>
        <asp:TextBox ID="txtInstitution" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvInstitution" runat="server" Display="Dynamic" ControlToValidate="txtInstitution" ValidationGroup="vgCourseAdd" ErrorMessage="Lütfen Eğitim Kurumu Bilgisini Giriniz"></asp:RequiredFieldValidator>
                
        <p class="Free">Başlama Tarihi</p>
        <uc1:uDateDropDown ID="uStartDate" runat="server" />
        
        <p class="Free">Bitiş Tarihi</p>
        <uc1:uDateDropDown ID="uEndDate" runat="server" />
        
        <p class="Free">Süre (Saat)</p>
        <asp:TextBox ID="txtDuration" runat="server" onkeyup="vNumber(this)"></asp:TextBox>
        
        <p class="Free">Açıklamalar</p>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" MaxLength="255"></asp:TextBox>
        
        <br />
        <asp:ImageButton runat="server" ID="imgBtnAdd" 
        ImageUrl="~/Images/Button/Add.jpg" onclick="imgBtnAdd_Click" ValidationGroup="vgCourseAdd" /> 
        <asp:ImageButton id="btnCancel" runat="server" onclick="btnCancel_Click"  Visible="false" ImageUrl="~/Images/Button/Cancel.jpg"/>
    </div>
    
    <ins></ins>
    <div style="width:425px;text-align:right;">
    <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgCourseInfo" /> 
   </div>
   </ContentTemplate>
   <Triggers>
        <asp:PostBackTrigger ControlID="imgBtnSend" />
   </Triggers>
   </asp:UpdatePanel>
</div>

