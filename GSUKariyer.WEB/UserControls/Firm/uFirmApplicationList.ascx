<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uFirmApplicationList.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Firm.uFirmApplicationList" %>

<%@ Register src="~/UserControls/Common/uPaging.ascx" tagname="uPaging" tagprefix="Paging" %>

<asp:Literal runat="server" ID="ltlNoData" Visible="false">
    <br />
    <h4>Başvuru bulunmamaktadır...</h4>
</asp:Literal>

<asp:PlaceHolder runat="server" ID="PHList">

<asp:Repeater runat="server" ID="rptAdvs" OnItemDataBound="rptAdvs_ItemDataBound">
     <ItemTemplate>     

    <asp:HyperLink CssClass="aGroup" runat="server" ID="hlAdvertisement"
        NavigateUrl='<%# Eval("AdvertisementId") %>' Text='<%# Eval("Title") %>'>    
    </asp:HyperLink>

    <ins></ins>

    <asp:Repeater runat="server" ID="rptList" OnItemDataBound="rptList_ItemDataBound">
        <HeaderTemplate>
            <table cellpadding="0" cellspacing="0" class="Grid">
        </HeaderTemplate>
        <ItemTemplate>
            <tr> 
                <td style="height: 60px; width: 55px;">                                                        
                    <asp:HyperLink runat="server" ID="hlImgUser" ImageUrl='<%# Eval("UserId") %>' NavigateUrl='<%# Eval("CvId") %>' />
                </td>
                <td>
                    <asp:HiddenField runat="server" ID="hdApplicationId" Value='<%# Eval("ID") %>' Visible="false"></asp:HiddenField>
                    <asp:HyperLink runat="server" ID="hlUser" CssClass="Und" NavigateUrl="#">
                        <asp:Literal runat="server" ID="ltlName" Text='<%# Eval("Name") %>'></asp:Literal>&nbsp;
                        <asp:Literal runat="server" ID="ltlSurname" Text='<%# Eval("Surname") %>'></asp:Literal>
                    </asp:HyperLink><br /><br />
                    
                    <asp:Literal runat="server" ID="ltlGender" Text='<%# Eval("Gender") %>'></asp:Literal>
                    
                    <dfn>
                        (<asp:Literal runat="server" ID="ltlBirthDate" Text='<%# Eval("BirthDate") %>'></asp:Literal>)
                    </dfn>
                    
                </td>
                <td>
                    
                    <br /><br />                                                                        
                        <asp:Literal runat="server" ID="ltlUnvDepartment"></asp:Literal>
                        <asp:HiddenField runat="server" ID="hdMasterDepartment" Value='<%# Eval("MasterDepartment") %>' Visible="false"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="hdMasterDepartmentFree" Value='<%# Eval("MasterDepartmentFree") %>' Visible="false"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="hdLicenseDepartment" Value='<%# Eval("LicenseDepartment") %>' Visible="false"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="hdLicenseDepartmentFree" Value='<%# Eval("LicenseDepartmentFree") %>' Visible="false"></asp:HiddenField>
                        &nbsp; 
                    <dfn>
                        (<asp:Literal runat="server" ID="ltlEducationState" Text='<%# Eval("EducationState") %>'></asp:Literal>)
                    </dfn>
                    
                </td>
                <td>
                    <br /><br />
                        <asp:Literal runat="server" ID="ltlCity" Text='<%# Eval("City") %>'></asp:Literal> &nbsp; 
                    <dfn>
                        (<asp:Literal runat="server" ID="ltlCountry" Text='<%# Eval("Country") %>'></asp:Literal>)
                    </dfn>
                </td> 
                <td>
                    <br /><br />
                    <dfn>
                        <%# Convert.ToDateTime(Eval("CreateDate")).ToShortDateString() %>                        
                    </dfn>
                </td>
                <td>
                    <br /><br />
                    
                    <asp:Literal runat="server" ID="ltlState" Text='<%# Eval("State") %>' Visible="false"></asp:Literal>

                    <asp:Image ID="imgViewed" runat="server" CssClass="ttT" ImageUrl="~/Images/Global/NotViewed.gif" Visible="false"
                    ToolTip="Yeni Başvuru" />
                                        
                    <asp:Image ID="imgNotViewed" runat="server" CssClass="ttT" ImageUrl="~/Images/Global/Viewed.gif" Visible="false"
                    ToolTip="İncelendi" />                    
                    
                    <asp:Image ID="imgAnswered" runat="server" CssClass="ttT" ImageUrl="~/Images/Global/Answered.gif" Visible="false"
                    ToolTip="Cevaplandıi" />
                    
                </td>
            </tr>        
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

     </ItemTemplate>
</asp:Repeater>

<Paging:uPaging ID="uPaging" runat="server" Visible="false" />

</asp:PlaceHolder>