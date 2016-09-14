<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uFirmDetail.ascx.cs" Inherits="UC_Firms_uFirmDetail" %>
<%@ Register src="~/UC/Common/Error.ascx" tagname="uError" tagprefix="uc1" %>
<%@ Register src="~/UC/Common/Success.ascx" tagname="uSuccess" tagprefix="uc2" %>


<h1>FİRMA DETAYI</h1>

<div class="fW1">

    <uc2:uSuccess ID="uSuccess1" runat="server" Visible="false" Title="FİRMA ONAYI" Desc="Firmanın üyeliği onaylanmıştır" />
    <uc1:uError ID="uError1" runat="server" Visible="false" Title="FİRMA ONAYLANAMADI" Desc="Firma onaylanırken hata oluştu" />
    
    <asp:HiddenField runat="server" ID="hdFirmId" Value="0" />

    <div class="Form">
    
        <h4> FİRMA BİLGİLERİ </h4>
        
        <br />
            
        <asp:Image runat="server" ID="imgLogo" ImageUrl="" />
        
        <br /><br />
            
        <b> Firma Ünvanı: </b>
        <strong><asp:Literal runat="server" ID="ltlName"></asp:Literal></strong>
        <br /><br />
        
        <b> Sektör: </b>
        <strong><asp:Literal runat="server" ID="ltlSector"></asp:Literal></strong>
        <br /><br />

        <b> Çalışan Sayısı: </b>
        <strong><asp:Literal runat="server" ID="ltlWorkerCount"></asp:Literal></strong>
        <br /><br />        

        <b> Adres: </b>
        <strong><asp:Literal runat="server" ID="ltlAddress"></asp:Literal></strong>
        <br /><br />            

        <b> Zip Kodu: </b>
        <strong><asp:Literal runat="server" ID="ltlZipCode"></asp:Literal></strong>
        <br /><br />
            
        <b> Ülke: </b>
        <strong><asp:Literal runat="server" ID="ltlCountry"></asp:Literal></strong>
        <br /><br />
        
        <b> Şehir: </b>
        <strong><asp:Literal runat="server" ID="ltlCity"></asp:Literal></strong>
        <br /><br />
        
        <b> Firma Hakkında: </b> <br />
        <strong><asp:Literal runat="server" ID="ltlDescription"></asp:Literal></strong>
        <br /><br />
                
        <b> Web Sayfası: </b>
        <asp:HyperLink runat="server" ID="hlWebPage" Target="_blank" NavigateUrl="#"></asp:HyperLink>
        <br /><br />
                
        <b> Kayıt Tarihi: </b>
        <strong><asp:Literal runat="server" ID="ltlCreateDate"></asp:Literal></strong>
        
        
        <br /><br /><br /><br />
        
        <h4> FİRMA YETKİLİSİ </h4>
        <br />
                                
        <b> Yetkili Adı: </b>
        <strong><asp:Literal runat="server" ID="ltlFirmUserName"></asp:Literal></strong>
        <br /><br />

        <b> Yetkili Soyadı: </b>
        <strong><asp:Literal runat="server" ID="ltlFirmUserSurname"></asp:Literal></strong>
        <br /><br />
        
        <b> Pozisyonu: </b>
        <strong><asp:Literal runat="server" ID="ltlFirmUserPosition"></asp:Literal></strong>
        <br /><br />

        <b> Telefon: </b>
        <strong><asp:Literal runat="server" ID="ltlFirmUserPhone"></asp:Literal></strong>
        <br /><br />
        
        <b> Fax: </b>
        <strong><asp:Literal runat="server" ID="ltlFirmUserFax"></asp:Literal></strong>
        <br /><br />
        
        <b> Email: </b>
        <strong><asp:Literal runat="server" ID="ltlFirmUserEmail"></asp:Literal></strong>
        <br /><br />
                
        <b> Şifre: </b>
        <strong><asp:Literal runat="server" ID="ltlFirmUserPassword"></asp:Literal></strong>
        <br /><br /><br />
        
        <div class="FormFooter">
            <asp:Button CssClass="Button" runat="server" ID="btnApprove" 
                Text="ONAYLA" 
                OnClientClick="return confirm('Firmayı onaylamak istiyor musunuz ?')" 
                onclick="btnApprove_Click" />
        </div>       

    </div>
    
</div>