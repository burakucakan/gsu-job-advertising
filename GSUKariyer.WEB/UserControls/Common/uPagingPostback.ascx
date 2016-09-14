<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uPagingPostback.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uPagingPostback1" %>


<script type="text/javascript">
    function ChangePage(PageValue, ValueType) {
        var chr = "&";
        var path = String(location.href);
        if (path.indexOf(ValueType + "=") != "-1") { path = path.substring(0, eval(path.indexOf(ValueType + "=") - 1)); }
        if (path.indexOf("?") == "-1") { chr = "?"; }
        path = path + chr + ValueType + "=" + PageValue;
        location.href = path;
    }
</script>


<ins></ins>

<div runat="server" id="dvPagingPanel" class="Paging Panel" visible="false">

    <ins></ins>

    <div class="fLeft">
    
        <asp:Literal runat="server" ID="ltlRecordCountTitle" Text="Toplam Kayıt" />:
        <asp:Label CssClass="RecordCountText" runat="server" ID="lblRecordCount" />

        <asp:Literal runat="server" ID="ltlPageSize" Text="Gösterim Adedi" />:
        <asp:DropDownList runat="server" ID="ddlPageSize" CssClass="DropDownList" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"
                    AutoPostBack="true" />

    </div>

    <div class="PagingNav">
        <asp:LinkButton runat="server" CssClass="NextPrevLink" ID="hlPrevious" Enabled="False"
                OnClick="hlPrevious_Click" OnClientClick="javascript:window.location='#top';">«« &nbsp;Önceki</asp:LinkButton> &nbsp;&nbsp;
        <asp:DropDownList runat="server" CssClass="DropDownList" ID="ddlPageNumber" OnSelectedIndexChanged="ddlPageNumber_SelectedIndexChanged"
                AutoPostBack="true" />&nbsp;&nbsp;
        <asp:LinkButton runat="server" CssClass="NextPrevLink" ID="hlNext" Enabled="False"
                OnClick="hlNext_Click" OnClientClick="javascript:window.location='#top';">Sonraki&nbsp; »»</asp:LinkButton>
    </div>
    
    <ins></ins>

</div>

