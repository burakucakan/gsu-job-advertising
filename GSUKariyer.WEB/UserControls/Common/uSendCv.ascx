<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uSendCv.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uSendCv" %>

<asp:UpdatePanel ID="upSendCv" runat="server">
    <ContentTemplate>        
    
    <asp:ImageButton runat="server" ID="imgBtnSendCv" ToolTip="Firmaya Cv'nizi yollayın"
        ImageUrl="~/Images/Button/SendCv.jpg" OnClick="imgBtnSendCv_Click" />

    <asp:UpdateProgress ID="upgrs1" runat="server" AssociatedUpdatePanelID="upSendCv" DynamicLayout="true">
        <ProgressTemplate> <img alt="" src="Images/Global/Indicator.gif" /> </ProgressTemplate>
    </asp:UpdateProgress>
                
    <asp:Panel runat="server" ID="succSendCv" CssClass="Success" Visible="false">Cv'niz gönderilmiştir</asp:Panel>
    <asp:Panel runat="server" ID="errSendCv" CssClass="Error" Visible="false">Cv'niz gönderilemedi. Lütfen daha sonra tekrar deneyiniz.</asp:Panel>
    <asp:Panel runat="server" ID="errNoCv" CssClass="Error" Visible="false">Cv gönderebilmek için önce bir Cv oluşturmanız gerekmektedir.</asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>