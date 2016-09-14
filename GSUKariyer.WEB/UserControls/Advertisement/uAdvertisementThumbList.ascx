<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uAdvertisementThumbList.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Advertisement.uAdvertisementThumbList" %>
<%@ Register src="../Common/uJobThumb.ascx" tagname="uJobThumb" tagprefix="uc1" %>
<asp:Repeater runat="server" ID="rptJob">
        <ItemTemplate>   
            <uc1:uJobThumb ID="uJobThumb1" runat="server" CompanyName='<%#Eval("Name")%>'         
                AdvertisementID='<%#Eval("ID") %>' 
                CompanyID='<%#Eval("FirmId") %>' 
                Desc='<%#Eval("Title") %>' />
        </ItemTemplate>
</asp:Repeater> 

 