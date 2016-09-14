<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUsers.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uUsers" %>

<%@ Register src="~/UserControls/Firm/uUserList.ascx" tagname="uUserList" tagprefix="uc1" %>

<div class="SubPageWide">
     
     <h1>galatasaray üniversiteliler</h1>
     
     <br />
     <ins></ins>
     <asp:LinkButton CssClass="ReturnSearch" id="lbtnOpenSearchCriteria" runat="server" ToolTip="Arama kriterlerine geri dön" Visible="false" OnClick="lbtnOpenSearchCriteria_Click"></asp:LinkButton>
     <ins></ins>
     <uc1:uUserList ID="uUserList1" runat="server" />
     
</div>