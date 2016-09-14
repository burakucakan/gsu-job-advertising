<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerPositions.ascx.cs" Inherits="UC_Common_BannerPositions" %>

<asp:DropDownList runat="server" ID="ddlBannerPositions">
</asp:DropDownList>

<asp:RequiredFieldValidator ID="rqBannerPositions" runat="server" ErrorMessage="Banner pozisyonunu seçiniz!" ControlToValidate="ddlBannerPositions" SetFocusOnError="true" Display="None" InitialValue="0" />