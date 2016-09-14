<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUserApplications.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.User.uUserApplications" %>

<%@ Register src="~/UserControls/Common/uUserApplicationList.ascx" tagname="uUserApplicationList" tagprefix="uc1" %>
    
<div class="SubPageWide">

    <h1>başvurularım</h1>
    
    <ins></ins>        
    
    <uc1:uUserApplicationList ID="uUserApplicationList1" runat="server" />
    
    <ins></ins>

</div>