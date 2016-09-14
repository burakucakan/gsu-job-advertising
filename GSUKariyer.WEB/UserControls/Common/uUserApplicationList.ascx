<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uUserApplicationList.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Common.uUserApplicationList" %>

<%@ Register src="~/UserControls/Common/uPaging.ascx" tagname="uPaging" tagprefix="Paging" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Literal runat="server" ID="ltlNoData" Visible="false">
    <br />
    <h4>Başvurunuz bulunmamaktadır...</h4>
</asp:Literal>

<asp:PlaceHolder runat="server" ID="PHList">

<asp:UpdatePanel ID="upApply" runat="server">
    <ContentTemplate>            

    <ajaxToolkit:ModalPopupExtender ID="MPE" runat="server" 
                TargetControlID="btnHideForModal"
                PopupControlID="pnlModal" 
                BackgroundCssClass="ModalOverlay"           
                CancelControlID="hlClose"
                 />
        
    <asp:Button runat="server" ID="btnHideForModal" Text="" Style="display: none" />

    <asp:Panel ID="pnlModal" runat="server" Style="display: none" CssClass="Panel">
        
        <div class="ApplicationAnswer">
                         
            <h3>Sayın, <asp:Literal runat="server" ID="ltlFullName"></asp:Literal></h3>
            
            <br /><br />
            
            <asp:Literal runat="server" ID="ltlMessage"></asp:Literal>
            
            <ins></ins>
            
            <br /><br />
            
            <asp:HyperLink runat="server" ID="hlClose" CssClass="Und" NavigateUrl="javascript:;">x kapat</asp:HyperLink>
        
        </div>
        
    </asp:Panel>

    <asp:Repeater runat="server" ID="rptList" OnItemDataBound="rptList_ItemDataBound" OnItemCommand="rptList_ItemCommand">
        <HeaderTemplate>
            <table class="Grid" cellpadding="0" cellspacing="0">
                <tr class="GridHeader">
                    <td>Başvuru</td>
                    <td>İlan Başlığı</td>
                    <td>Firma</td>
                    <td>Cevap</td>
                    <td>Durum</td>
                </tr>        
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td>

                        <asp:HiddenField runat="server" ID="hdID" Value='<%# Eval("ID") %>' />                    
                        <asp:HiddenField runat="server" ID="hdState" Value='<%# Eval("State") %>' />
                        <asp:HiddenField runat="server" ID="hdIsRead" Value='<%# Eval("IsRead") %>' />
                        <asp:HiddenField runat="server" ID="hdEndDate" Value='<%# Eval("EndDate") %>' />
                        <asp:HiddenField runat="server" ID="hdAdvertisementAnswer" Value='<%# Eval("AdvertisementAnswer") %>' />
                    
                        <dfn><%# Convert.ToDateTime(Eval("CreateDate")).ToShortDateString() %></dfn>
                    </td>
                    <td>
                        <asp:HyperLink CssClass="Und" runat="server" ID="hlJobDetail" NavigateUrl='<%# Eval("AdvertisementID") %>' Text='<%# Eval("Title") %>'></asp:HyperLink>
                    </td>
                    <td><asp:HyperLink CssClass="Und" runat="server" ID="hlCompanyDetail" NavigateUrl='<%# Eval("FirmId") %>' Text='<%# Eval("Name") %>'></asp:HyperLink></td>
                    <td>
                        <asp:ImageButton CommandName="Message" ID="ImgMessage" runat="server" ImageUrl="~/Images/Global/Mail.png" AlternateText="Yeni Mesaj" Visible="false" />
                        <asp:ImageButton CommandName="MessageOpened" ID="ImgMessageOpen" runat="server" ImageUrl="~/Images/Global/MailOpen.png" Visible="false" />
                    </td>
                    <td>
                        <dfn>                            
                            <asp:Literal ID="ltlViewed" runat="server" Visible="false">İncelendi</asp:Literal>
                            <asp:Literal ID="ltlNotViewed" runat="server" Visible="false">İncelenmedi</asp:Literal>
                        </dfn>
                    </td>
                </tr>          
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>          

    </ContentTemplate>
</asp:UpdatePanel>

    <Paging:uPaging ID="uPaging" runat="server" Visible="false" />
    
</asp:PlaceHolder>