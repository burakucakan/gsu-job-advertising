<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uPaging.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uPaging" %>

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
    
        Toplam Kayıt:
        <asp:Label runat="server" ID="lblRecordCount"></asp:Label>

        Gösterim Adedi:
        <asp:DropDownList runat="server" ID="ddlPageSize" />

    </div>

    <div class="PagingNav">
        « <asp:HyperLink runat="server" ID="hlPrevious">Önceki</asp:HyperLink> &nbsp;&nbsp;
        <asp:DropDownList runat="server" ID="ddlPageNumber" /> &nbsp;&nbsp;
        » <asp:HyperLink runat="server" ID="hlNext">Sonraki</asp:HyperLink>
    </div>
    
    <ins></ins>

</div>