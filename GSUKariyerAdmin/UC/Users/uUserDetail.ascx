<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uUserDetail.ascx.cs" Inherits="UC_Firms_uUserDetail" %>

<%@ Register src="../Common/Error.ascx" tagname="Error" tagprefix="uc1" %>
<%@ Register src="../Common/Success.ascx" tagname="Success" tagprefix="uc2" %>

<h1>ÜYE DETAYI</h1>

<div class="fW1">

     <uc1:Error ID="Error1" runat="server" Visible="false" Title="Hata" />
     <uc2:Success ID="Success1" runat="server" Visible="false" Title="İşleminiz Başarıyla Tamamlandı." />  

    <asp:RegularExpressionValidator ID="rexEmail" runat="server"
                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                 ControlToValidate="txtEmail"
                 Display="None"
                 SetFocusOnError="true"
                 ErrorMessage="Lütfen geçerli bir email giriniz !"
                 ValidationGroup="vgUserEdit" />  
    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="None"
                ErrorMessage="Lütfen bir email giriniz !" ValidationGroup="vgUserEdit"/>
    

    <asp:ValidationSummary ID="ValSum" runat="server" CssClass="Validate" ShowSummary="true" ValidationGroup="vgUserEdit" />
    
    <div class="Form">
    
        <b>ÜYE BİLGİLERİ</b>
        <br /><br />
    
        <asp:Image runat="server" ID="imgUser" ImageUrl="" />
    
        Adı: <b>
        <asp:Literal runat="server" ID="ltlName"></asp:Literal>
        </b> <br /><br />
        
        Soyadı: <b>
        <asp:Literal runat="server" ID="ltlSurName"></asp:Literal>
        </b> <br /><br />

        Uyruk: <b>
        <asp:Literal runat="server" ID="ltlNationality"></asp:Literal>
        </b> <br /><br />        

        Doğum Tarihi: <b>
        <asp:Literal runat="server" ID="ltlBirthDate"></asp:Literal>
        </b> <br /><br />            

        Öğrenci Numarası: <b>
        <asp:Literal runat="server" ID="ltlStudentNumber"></asp:Literal>
        </b> <br /><br />
            
        Cinsiyet: <b>
        <asp:Literal runat="server" ID="ltlGender"></asp:Literal>
        </b> <br /><br />
        
        Email: <b>
        <asp:TextBox CssClass="TextBox" runat="server" ID="txtEmail" MaxLength="320"></asp:TextBox>
        </b> <br /><br />
        
        Adres: <b>
        <asp:Literal runat="server" ID="ltlAddress"></asp:Literal>
        </b> <br /><br />
        
        Ülke: <b>
        <asp:Literal runat="server" ID="ltlCountry"></asp:Literal>
        </b> <br /><br />
        
        Şehir: <b>
        <asp:Literal runat="server" ID="ltlCity"></asp:Literal>
        </b> <br /><br />
        
        Aktif/Pasif: <b>
        <asp:DropDownList ID="ddlIsActive" runat="server"></asp:DropDownList>
        </b> <br /><br />
                
        Aktivasyon Tarihi/Aktivasyon Yollanma Tarihi: <b>
        <asp:Literal runat="server" ID="ltlActivationDate"></asp:Literal>
        </b> <br /><br />
        
        Kayıt Tarihi: <b>
        <asp:Literal runat="server" ID="ltlCreateDate"></asp:Literal>
        </b> <br /><br />
                
        
        <asp:Button CssClass="Button2" runat="server" ID="btnSave" 
            Text="Kaydet" ValidationGroup="vgUserEdit" 
            onclick="btnSave_Click" />  
        <asp:Button CssClass="Button2" runat="server" ID="btnDelete" 
            Text="Sil" onclick="btnDelete_Click" OnClientClick="return confirm('Kaydı silmek istediğinize emin misiniz ?')"  /> 
        <asp:Button CssClass="Button2" runat="server" ID="btnSendActivation" 
            Text="Aktivasyon Yolla" onclick="btnSendActivation_Click" />        
        
    </div>

</div>