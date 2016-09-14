<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uSurvey.ascx.cs" Inherits="GSUKariyer.WEB.UserControls.Master.uSurvey" %>

<div class="Survey">
                
    <b><asp:Literal ID="ltrSurveyQuestion" runat="server"></asp:Literal></b>
    
    <br /><br />
    
    <asp:Panel runat="server" ID="pnlSurveyResults" Visible="false">    

        <asp:Repeater runat="server" ID="rptSurveyResult" OnItemDataBound="rptSurveyResult_ItemDataBound">
            <ItemTemplate>

            <%# Eval("Description") %> <br />
            <dfn>
                <asp:Literal runat="server" ID="ltlPercent"></asp:Literal>
            %</dfn>
            <asp:Image runat="server" ID="imgBar" ImageUrl="~/Images/Screen/SurveyResultBar.gif" Height="8" />
            <br /> <br />
            
            <asp:Literal runat="server" ID="ltlVote" Text='<%# Eval("Vote") %>' Visible="false"></asp:Literal>
            
            </ItemTemplate>
        </asp:Repeater>
                    
        <ins></ins>
        
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pnlSurveyItems" Visible="false">
    
        <asp:RadioButtonList RepeatColumns="1" ID="rblSurveyItems" TextAlign="Left" RepeatDirection="Vertical" runat="server" ValidationGroup="vgSurvey" />    
       
        <ins></ins>
        <br />
        
        <asp:Button runat="server" ID="btnSurveySend" CssClass="ButtonAlt" ValidationGroup="Survey"
            Text="GÖNDER" onclick="btnSurveySend_Click" />       
       
    </asp:Panel>       
    
</div>