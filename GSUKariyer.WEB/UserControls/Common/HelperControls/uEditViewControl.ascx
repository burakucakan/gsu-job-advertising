<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uEditViewControl.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.HelperControls.uEditViewControl" %>

<div id="trDropDown" runat="server">

    <asp:DropDownList ID="ddlList" runat="server" EnableViewState="false"></asp:DropDownList>   
    <asp:CustomValidator ID="cvDDLList" runat="server"  Enabled="false" EnableClientScript="true" OnServerValidate="Server_Validate"></asp:CustomValidator>  

    <asp:Literal ID ="ValidationScriptLiteral" runat="server"></asp:Literal>
    
    <div id="trFreeValue" runat="server" style="float:left;">
        <div style="padding-left:2px;"><asp:TextBox ID="txtFreeValue" runat="server"></asp:TextBox></div>
        <div><asp:RequiredFieldValidator ID="rfvFreeValue" runat="server" ErrorMessage="*" Enabled="false" ControlToValidate="txtFreeValue"></asp:RequiredFieldValidator></div>
    </div>
    
</div>
<div id="trLabel" runat="server" style="float:left;">
    <asp:Label ID="lblValue" runat="server" SkinID="ms-vbNormal"></asp:Label>
</div>

