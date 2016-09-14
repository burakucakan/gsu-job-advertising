<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uSearch.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Search.uSearch " %>
<%@ Register Src="~/UserControls/Common/HelperControls/uItem.ascx" TagName="uItem"
    TagPrefix="Item" %>
<%@ Register Src="../Advertisement/uAdvertisements.ascx" TagName="uAdvertisements"
    TagPrefix="uc1" %>
<div class="SubPage" id="divSearchArea" runat="server">
    <h1>
        detaylı arama</h1>
    <input type="hidden" id="hfSearchForm" name="hfSearchForm" value="FromDetailedSearch" />
    <ins></ins>
    <asp:UpdatePanel ID="uplSearchCriteria" runat="server">
        <ContentTemplate>
            <div class="SearchNavigation">
                <asp:HyperLink runat="server" ID="hlItem1" NavigateUrl="#">
                    <asp:LinkButton ID="lbtnSearchKeyword" Text="· ANAHTAR KELİME" runat="server" OnClick="lbtnSearchCriteria_Click"
                        CommandArgument="divKeyword"></asp:LinkButton>
                </asp:HyperLink>
                <asp:Repeater ID="rptSearchKeyword" runat="server">
                    <ItemTemplate>
                        <Item:uItem ID="UItem1" runat="server" IsRemove="true" IsEdit="false" Text='<%#Eval("Definition")%>'
                            SpecialValue='<%#Eval("Value") %>' ParentUserControlId='<%#Eval("ParentControlId") %>'
                            OnItemRemove="UItem1_ItemOnRemove" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <ins></ins>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HyperLink runat="server" ID="hlItem2" NavigateUrl="#">
                    <asp:LinkButton ID="lbtnDate" Text="· TARİH" runat="server" OnClick="lbtnSearchCriteria_Click"
                        CommandArgument="divDate"></asp:LinkButton>
                </asp:HyperLink>
                <asp:Repeater ID="rptDate" runat="server">
                    <ItemTemplate>
                        <Item:uItem ID="UItem1" runat="server" IsRemove="true" IsEdit="false" Text='<%#Eval("Definition")%>'
                            SpecialValue='<%#Eval("Value") %>' ParentUserControlId='<%#Eval("ParentControlId") %>'
                            OnItemRemove="UItem1_ItemOnRemove" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <ins></ins>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HyperLink runat="server" ID="hlItem3" NavigateUrl="#">
                    <asp:LinkButton ID="lbtnSectors" Text="· SEKTÖRLER" runat="server" OnClick="lbtnSearchCriteria_Click"
                        CommandArgument="divSectors"></asp:LinkButton>
                </asp:HyperLink>
                <asp:Repeater ID="rptSectors" runat="server">
                    <ItemTemplate>
                        <Item:uItem ID="UItem1" runat="server" IsRemove="true" IsEdit="false" Text='<%#Eval("Definition")%>'
                            SpecialValue='<%#Eval("Value") %>' ParentUserControlId='<%#Eval("ParentControlId") %>'
                            OnItemRemove="UItem1_ItemOnRemove" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <ins></ins>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HyperLink runat="server" ID="hlItem4" NavigateUrl="#">
                    <asp:LinkButton ID="lbtnCityCountry" Text="· ŞEHİR / ÜLKE" runat="server" OnClick="lbtnSearchCriteria_Click"
                        CommandArgument="divCityCountry"></asp:LinkButton>
                </asp:HyperLink>
                <asp:Repeater ID="rptSelectedCityCountry" runat="server">
                    <ItemTemplate>
                        <Item:uItem ID="UItem1" runat="server" IsRemove="true" IsEdit="false" Text='<%#Eval("Definition")%>'
                            SpecialValue='<%#Eval("Value") %>' ParentUserControlId='<%#Eval("ParentControlId") %>'
                            OnItemRemove="UItem1_ItemOnRemove" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <ins></ins>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HyperLink runat="server" ID="hlItem6" NavigateUrl="#">
                    <asp:LinkButton ID="lbtnPositions" Text="· POZİSYONLAR" runat="server" OnClick="lbtnSearchCriteria_Click"
                        CommandArgument="divPosition"></asp:LinkButton>
                </asp:HyperLink>
                <asp:Repeater ID="rptPositions" runat="server">
                    <ItemTemplate>
                        <Item:uItem ID="UItem1" runat="server" IsRemove="true" IsEdit="false" Text='<%#Eval("Definition")%>'
                            SpecialValue='<%#Eval("Value") %>' ParentUserControlId='<%#Eval("ParentControlId") %>'
                            OnItemRemove="UItem1_ItemOnRemove" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <ins></ins>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HyperLink runat="server" ID="hlItem7" NavigateUrl="#">
                    <asp:LinkButton ID="lbtnWorkType" Text="· ÇALIŞMA ŞEKLİ" runat="server" OnClick="lbtnSearchCriteria_Click"
                        CommandArgument="divWorkType"></asp:LinkButton>
                </asp:HyperLink>
                <asp:Repeater ID="rptWorkTypes" runat="server">
                    <ItemTemplate>
                        <Item:uItem ID="UItem1" runat="server" IsRemove="true" IsEdit="false" Text='<%#Eval("Definition")%>'
                            SpecialValue='<%#Eval("Value") %>' ParentUserControlId='<%#Eval("ParentControlId") %>'
                            OnItemRemove="UItem1_ItemOnRemove" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <ins></ins>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HyperLink runat="server" ID="hlItem8" NavigateUrl="#">
                    <asp:LinkButton ID="lbtnFirm" Text="· FİRMA" runat="server" OnClick="lbtnSearchCriteria_Click"
                        CommandArgument="divFirm"></asp:LinkButton>
                </asp:HyperLink>
                <asp:Repeater ID="rptFirm" runat="server">
                    <ItemTemplate>
                        <Item:uItem ID="UItem1" runat="server" IsRemove="true" IsEdit="false" Text='<%#Eval("Definition")%>'
                            SpecialValue='<%#Eval("Value") %>' ParentUserControlId='<%#Eval("ParentControlId") %>'
                            OnItemRemove="UItem1_ItemOnRemove" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <ins></ins>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="SearchContent">
                <asp:UpdateProgress ID="upSearchCriteria" runat="server" AssociatedUpdatePanelID="uplSearchCriteria"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <img alt="" src="Images/Global/Indicator.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div id="divKeyword" runat="server" class="Panel">
                    <b>ANAHTAR KELİME</b> <ins></ins>Anahtar kelime ile firmaların iş ilanlarında belirtmiş
                    oldukları iş tanımlarında arama yapabilirisiniz. <ins></ins>
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    <ins></ins>
                    <asp:ImageButton id="ibtnAddKeywordCriteria" runat="server" OnClick="ibtnAddKeywordCriteria_Click" ImageUrl="~/Images/Button/Add.jpg" />
                </div>
                <div id="divDate" runat="server" visible="false" class="Panel">
                    <b>TARİH</b> <ins></ins>İlan tarihi seçerek aşağıda belirtilen seçenekler süresince
                    girilmiş ilanları listeleyebilirsiniz. <ins></ins>
                    <asp:RadioButtonList ID="rblDateOptions" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblDateOptions_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </div>
                <div id="divSectors" runat="server" visible="false" class="Panel">
                    <b>SEKTÖRLER</b> <ins></ins>
                    <asp:ListBox runat="server" ID="lbSectors" Rows="20" SelectionMode="Multiple" OnSelectedIndexChanged="lbSectors_OnSelectedIndexChanged" Width="300"
                        AutoPostBack="true"></asp:ListBox>
                    <ins></ins>'CTRL' tuşunu basılı tutarak en fazla 5 adet 'SEKTÖR' seçimi yapabilirsiniz.
                </div>
                <div id="divCityCountry" runat="server" visible="false" class="Panel">
                    <b>ŞEHİR / ÜLKE</b> <ins></ins>
                    <asp:ListBox runat="server" ID="lbCityCountry" Rows="20" SelectionMode="Multiple"
                        AutoPostBack="true" OnSelectedIndexChanged="lbCityCountry_OnSelectedIndexChanged" Width="300">
                    </asp:ListBox>
                    <ins></ins>'CTRL' tuşunu basılı tutarak en fazla 5 adet 'ŞEHİR / ÜLKE' seçimi yapabilirsiniz.
                </div>
                <div id="divPosition" runat="server" visible="false" class="Panel">
                    <b>POZİSYON</b> <ins></ins>
                    <asp:ListBox runat="server" ID="lbPosition" Rows="20" SelectionMode="Multiple" OnSelectedIndexChanged="lbPosition_OnSelectedIndexChanged" Width="300"
                        AutoPostBack="true"></asp:ListBox>
                    <ins></ins>'CTRL' tuşunu basılı tutarak en fazla 5 adet 'POZİSYON' seçimi yapabilirsiniz.
                </div>
                <div id="divWorkType" runat="server" visible="false" class="Panel">
                    <b>ÇALIŞMA ŞEKLİ</b> <ins></ins>
                    <asp:ListBox runat="server" ID="lbWorkType" Rows="20" SelectionMode="Multiple" OnSelectedIndexChanged="lbWorkType_OnSelectedIndexChanged" Width="300"
                        AutoPostBack="true"></asp:ListBox>
                    <ins></ins>'CTRL' tuşunu basılı tutarak en fazla 5 adet 'ÇALIŞMA ŞEKLİ' seçimi yapabilirsiniz.
                </div>
                <div id="divFirm" runat="server" visible="false" class="Panel">
                    <b>FİRMA</b> <ins></ins>Firma adının tamamını veya bir kısmını aşağıdaki kutuya
                    yazarak arama yapabilirsiniz. <ins></ins>
                    <asp:TextBox ID="txtFirmName" runat="server"></asp:TextBox>
                    <ins></ins>
                    <asp:ImageButton ID="ibtnAddFirmNameCriteria" runat="server" OnClick="ibtnAddFirmNameCriteria_Click"
                        ImageUrl="~/Images/Button/Add.jpg" />
                    <ins></ins>
                    <asp:CheckBox ID="chbMyFirms" runat="server" Text="Sadece takip listeme aldığım firmaların ilanlarını göster" AutoPostBack="true" OnCheckedChanged="chbMyFirms_CheckedChanged"  />
                </div>
                <ins></ins>
                <asp:ImageButton runat="server" ID="imgBtnSearch" ImageUrl="~/Images/Button/Search.jpg"/>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
