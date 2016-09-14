<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uStudent.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Main.uStudent" %>

<%@ Register src="~/UserControls/Common/uJobThumb.ascx" tagname="uJobThumb" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Common/uUserApplicationList.ascx" tagname="uUserApplicationList" tagprefix="uc2" %>
<%@ Register Src="~/UserControls/Common/HelperControls/uItem.ascx" TagName="uItem" TagPrefix="Item" %>

<%@ Register src="~/UserControls/Advertisement/uAdvertisementThumbList.ascx" tagname="uAdvertisementThumbList" tagprefix="uc3" %>


    
<div class="SubPage">
    
    <h1>özgeçmişlerim</h1>

    <ins></ins>

    <asp:HyperLink style="float: right;" CssClass="CvCreate" ID="hlCvAdd" runat="server" ToolTip="Yeni Cv oluştur"></asp:HyperLink>
    <ins></ins>


<asp:Repeater ID="rptCvs" runat="server" OnItemDataBound="rptCvs_ItemDataBound" OnItemCommand="rptCvs_ItemCommand">
    <HeaderTemplate>
        <table class="Grid" cellpadding="0" cellspacing="0">
            <tr class="GridHeader">
                <td></td>
                <td>Cv Adı</td>
                <td>Dil</td>
                <td>Son Güncelleme</td>
                <td></td>
                <td></td>              
                <td></td>                
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:HiddenField runat="server" ID="hdDefaultCv" Value='<%# Eval("IsDefault") %>' />
                <asp:LinkButton CommandArgument='<%# Eval("ID").ToString() %>' CommandName="DefaultCv" runat="server" ID="lnkDefaultCv" CssClass="aCheck ttT" ToolTip="Seçilmiş Cv yap" Visible="false"></asp:LinkButton>
                <asp:Image ID="imgCheckedCv" runat="server" AlternateText='Seçilmiş Cv' ImageUrl='~/Images/Global/Check.png' Visible="false" />
            </td>
            <td>
                <asp:HyperLink CssClass="Und" runat="server" ID="hlCvName" Target="_blank" Text='<%# Eval("Name") %>' NavigateUrl='<%# ArrangeViewUrl(Eval("ID").ToString()) %>'></asp:HyperLink>
            </td>
            <td><dfn><asp:Literal ID="ltlLanguage" runat="server" Text='<%# Eval("CvLanguage") %>'></asp:Literal></dfn></td>
            <td>
                <%# Convert.ToDateTime(Eval("ModifyDate")).ToShortDateString() %>
            </td>
            <td>
                <asp:HyperLink runat="server" ID="hlCvEdit" CssClass="aEdit" NavigateUrl='<%# UrlHelper.PageUrl.CvEdit(int.Parse(Eval("ID").ToString())) %>'>
                    Düzenle
                </asp:HyperLink>  
            </td>
            <td><dfn>
                <asp:Literal runat="server" ID="ltlCvState" Text='<%# Eval("CvState").ToString() %>' Visible="false"></asp:Literal>
                
                <asp:LinkButton CommandArgument='<%# Eval("ID").ToString() %>' CommandName="CvStateActive" runat="server" ID="lnkCvStateActive" CssClass="aActive ttT" ToolTip="Pasif yap" Visible="false"></asp:LinkButton>
                <asp:LinkButton CommandArgument='<%# Eval("ID").ToString() %>' CommandName="CvStatePassive" runat="server" ID="lnkCvStatePassive" CssClass="aPassive ttT" ToolTip="Aktif yap" Visible="false"></asp:LinkButton>
                
                
            </dfn></td>
            <td>
                <asp:LinkButton CommandName="Del" CommandArgument='<%# Eval("ID").ToString() %>' runat="server" ID="lnkDel" OnClientClick="return confirm('Silmek istediğinizden emin misiniz ?')" CssClass="aDel">
                Sil
                </asp:LinkButton>            
            </td>            
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table> 
    </FooterTemplate>
</asp:Repeater>
    
    <ins></ins>
        
    <h1>özgeçmişime en uygun ilanlar</h1>

    <ins></ins>

    <uc3:uAdvertisementThumbList ID="uAdvertisementThumbList1" runat="server" />
    
    <ins></ins>
    
    <asp:HyperLink CssClass="Und" runat="server" ID="hlMostSuitable" NavigateUrl="#">» özgeçmişinize en uygun ilanlar</asp:HyperLink>
    
    <ins></ins><ins></ins>
    
    <h1>başvurularım</h1>

    <ins></ins>
    
    <uc2:uUserApplicationList ID="uUserApplicationList1" runat="server" />
    
    <ins></ins>
    <asp:HyperLink CssClass="Und" runat="server" ID="hlUserApplications" NavigateUrl="#">» tüm başvurularım</asp:HyperLink>
    
    <ins></ins>
    <br /><br /><br /><br /><br /><br />
    
</div>

