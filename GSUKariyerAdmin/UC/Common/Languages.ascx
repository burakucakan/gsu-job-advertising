<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Languages.ascx.cs" Inherits="UC_Common_Languages" %>

<asp:DropDownList runat="server" ID="ddlLanguages">
    <asp:ListItem Text="Azerbaycan" Value="1" Selected="True"></asp:ListItem>
    <asp:ListItem Text="English" Value="2"></asp:ListItem>
</asp:DropDownList>

<asp:RequiredFieldValidator ID="rqLanguages" runat="server" ErrorMessage="Lütfen dil seçimini yapınız!" ControlToValidate="ddlLanguages" SetFocusOnError="true" Display="None" />