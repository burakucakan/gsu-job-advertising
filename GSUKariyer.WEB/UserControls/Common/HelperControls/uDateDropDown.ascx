<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uDateDropDown.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.HelperControls.uDateDropDown" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<table cellpadding="0" border="0" cellspacing="0">
<tr>
    <td>
        <asp:TextBox ID="txtDate" runat="server" Width="100"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ibtnSelect" 
            TargetControlID="txtDate"></cc1:CalendarExtender>
        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDate" Display="Dynamic" Enabled="false">
        </asp:RequiredFieldValidator>
    </td>
    <td style="padding-left:5px;" valign="top"><asp:ImageButton id="ibtnSelect" runat="server" ImageUrl="~/Images/Button/CalenndarSchedule.png"/></td>
</tr>
</table>

