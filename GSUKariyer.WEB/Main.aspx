<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="GSUKariyer.WEB.Main" ValidateRequest="false"%>
<%@ Register src="UserControls/SiteParamControls/uCities.ascx" tagname="uCities" tagprefix="uc1" %>
<%@ Register src="UserControls/SiteParamControls/uCountries.ascx" tagname="uCountries" tagprefix="uc2" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:TextBox ID="TextBox1" runat="server" Width="478px" TextMode="MultiLine"></asp:TextBox><br />
<asp:TextBox ID="TextBox2" runat="server" Width="478px" TextMode="MultiLine" 
            Height="368px"></asp:TextBox>
<br />
<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="ara" onclick="btnSearch_Click" />
    <uc1:uCities ID="uCities1" runat="server" />
    <uc2:uCountries ID="uCountries1" runat="server" />
</asp:Content>
