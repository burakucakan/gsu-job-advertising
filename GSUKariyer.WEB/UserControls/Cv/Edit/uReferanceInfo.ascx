<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uReferanceInfo.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Cv.Edit.uReferanceInfo" %>
<%@ Register src="../../Common/HelperControls/uDateDropDown.ascx" tagname="uDateDropDown" tagprefix="uc1" %>
<%@ Register src="../../Common/HelperControls/uItem.ascx" tagname="uItem" tagprefix="uc3" %>

<%@ Register src="../../Common/uPhoneNumber.ascx" tagname="uPhoneNumber" tagprefix="uc2" %>

<%@ Register src="../../SiteParamControls/uSectors.ascx" tagname="uSectors" tagprefix="uc4" %>
<%@ Register src="../../SiteParamControls/uPositions.ascx" tagname="uPositions" tagprefix="uc5" %>

<div class="CvFormContent">
    <b>REFERANSLAR</b>
    <br />
    <br />
    <asp:UpdatePanel ID="uplReferancesInfo" runat="server">
        <ContentTemplate>
        <asp:UpdateProgress ID="upReferancesInfo" runat="server" AssociatedUpdatePanelID="uplReferancesInfo"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
    <asp:Repeater ID="rptItems" runat="server">
    <ItemTemplate>
        <uc3:uItem ID="uItem1" runat="server" IsEdit="true" IsRemove="true" 
            Text='<%#ArrangeDesc(Eval("Name").ToString(),Eval("Surname").ToString(),Eval("WorkingFirm").ToString()) %>' OnItemRemove="uItem_ItemRemove" OnItemEdit="uItem_ItemEdit"  />
        <asp:HiddenField id="hfId" runat="server" Value='<%#Eval("ID") %>'/>
        <asp:HiddenField id="hfName" runat="server" Value='<%#Eval("Name") %>'/>
        <asp:HiddenField id="hfSurname" runat="server" Value='<%#Eval("Surname") %>'/>
        <asp:HiddenField id="hfEmail" runat="server" Value='<%#Eval("Email") %>'/>
        <asp:HiddenField id="hfPhone" runat="server" Value='<%#Eval("Phone") %>'/>
        <asp:HiddenField id="hfFirmName" runat="server" Value='<%#Eval("WorkingFirm") %>'/>
        <asp:HiddenField id="hfFirmSector" runat="server" Value='<%#Eval("FirmSector") %>'/>
        <asp:HiddenField id="hfPosition" runat="server" Value='<%#Eval("WorkingPosition") %>'/>
    </ItemTemplate>
    </asp:Repeater>
    <ins></ins><ins></ins>
    <div class="Form" style="width:430px;">
    
        <div class="Panel">
            Lütfen referanslarınızı giriniz.
        </div>
        
        <asp:HiddenField id="hfRepeaterIndex" runat="server"/>
        <asp:HiddenField id="hfId" runat="server"/>
        <br /><br />
        <p>Referansınızın Adı</p>
        <asp:TextBox ID="txtReferanceName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvReferanceName" runat="server" Display="Dynamic" ControlToValidate="txtReferanceName" ValidationGroup="vgReferanceAdd" ErrorMessage="Lütfen Referansınızın Adını Giriniz"></asp:RequiredFieldValidator>
        
        <p>Soyadı</p>
        <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSurname" runat="server" Display="Dynamic" ControlToValidate="txtSurname" ValidationGroup="vgReferanceAdd" ErrorMessage="Lütfen Soyadını Giriniz"></asp:RequiredFieldValidator>
                
        <p>E-posta Adresi</p>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>       
        <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" 
            ControlToValidate="txtEmail" ValidationGroup="vgReferanceAdd" 
            ErrorMessage="Lütfen Geçerli Email Bilgisi Giriniz" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
        
        <p>Telefonu</p>
        <uc2:uPhoneNumber ID="uPhoneNumber1" runat="server" ValidationGroup="vgReferanceAdd" ValidationRequired="true" ValidationError="Lütfen Telefon Numarası Giriniz"/>
        
        <p class="Free">Çalıştığı Firmanın Adı</p>
        <asp:TextBox ID="txtFirmName" runat="server"></asp:TextBox>
                
        <p class="Free">Firmanın Sektörü</p>
        <uc4:uSectors ID="uSectors1" runat="server" />
        
        <p class="Free">Pozisyonu</p>
        <uc5:uPositions ID="uPositions1" runat="server" />
        
        <br />
        <asp:ImageButton runat="server" ID="imgBtnAdd" 
        ImageUrl="~/Images/Button/Add.jpg" onclick="imgBtnAdd_Click" ValidationGroup="vgReferanceAdd" /> 
        <asp:ImageButton id="btnCancel" runat="server" onclick="btnCancel_Click"  Visible="false" ImageUrl="~/Images/Button/Cancel.jpg"/>
    </div>

    <ins></ins>
    <div style="width:425px;text-align:right;">
    <asp:ImageButton runat="server" ID="imgBtnSend" 
        ImageUrl="~/Images/Button/SaveAndContinue.jpg" onclick="imgBtnSend_Click" ValidationGroup="vgReferanceInfo" /> 
   </div>
   </ContentTemplate>
   <Triggers>
        <asp:PostBackTrigger ControlID="imgBtnSend" />
   </Triggers>
   </asp:UpdatePanel>
</div>

