<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uPhoneNumber.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uPhoneNumber" %>
<table cellpadding="0" cellspacing="0" border="0">
<tr>
    <td><asp:TextBox ID="txtCountryCode" runat="server" MaxLength="3" Width="30" ToolTip="Ülke Kodu" onkeyup="vNumber(this)"></asp:TextBox></td>
    <td style="padding-left:5px;"><asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="10" Width="100" ToolTip="Telefon Numarası" onkeyup="vNumber(this)"></asp:TextBox></td>
</tr>
</table>
<asp:RequiredFieldValidator ID="rfvCountryCode" ErrorMessage="*" runat="server" Display="Dynamic" ControlToValidate="txtCountryCode" ValidationGroup="vgContactInfo" Enabled="false"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="rfvPhoneNo" ErrorMessage="Lütfen Telefonu Giriniz" runat="server" Display="Dynamic" ControlToValidate="txtPhoneNo" ValidationGroup="vgContactInfo" Enabled="false"></asp:RequiredFieldValidator>