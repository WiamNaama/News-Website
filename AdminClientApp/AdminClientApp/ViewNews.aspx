<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewNews.aspx.cs" Inherits="AdminClientApp.ViewNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .hiddencol
         {
             display:none;
         }
        .modalPopup {
            background-color: #456069;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 5px;
            padding-left: 10px;
            width: 550px;
            height: 610px;
        }
        .modalBackground 
        {
            height:100%;
            background-color:#EBEBEB;
            filter:alpha(opacity=50);
            opacity:0.7;
        }
        #panel .post .buffer {
    padding: 4px;
    background-color: #ECEBEB;
    margin: 0;
    width: 520px;
            
}
        #panel .post .details {
    background-color: #ECEBEB;
    color: #808080;
    font-size: 0.8em;
    font-family: Verdana;
    font-weight: bold;
    padding: 8px 7px;
    text-transform: uppercase;
    margin-bottom: 5px;
    margin-top:0px;
    overflow-y: auto;
    width: 520px;
    height:40px;
}
    </style>
    <link rel="stylesheet" type="text/css" href="style.css" />
      <div id="content">
          <div class="post">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
            OnRowCreated="GridView1_OnRowCreated"  Width="660px" Font-Size="12pt" EmptyDataText="No news found!!"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" 
                 PagerSettings-FirstPageText="&nbsp;First" PagerSettings-LastPageText="&nbsp;Last" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-PageButtonCount="4" PagerSettings-NextPageText="&nbsp;Next" PagerSettings-PreviousPageText="&nbsp;Previous">
                <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Abstract" HeaderText="Abstract" />
                <asp:BoundField DataField="City" HeaderText="Agency" />
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="TotalReads" HeaderText="Total Reads" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:TemplateField>
                    <HeaderTemplate>Ranking</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" ID="rankLbl"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False"  OnClick="btnView_click" ImageUrl="images/view.png" Width="25" Height="25" >
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>

                <HeaderStyle BackColor="#456069" ForeColor="White" />

<PagerSettings FirstPageText="&#160;First" LastPageText="&#160;Last" Mode="NextPreviousFirstLast" NextPageText="&#160;Next" PageButtonCount="4" PreviousPageText="&#160;Previous"></PagerSettings>

            </asp:GridView>
          </div>
        
    </div>
    <asp:Button ID="btnShowPopup" runat="server" style="display:none" />

     <cc1:modalpopupextender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
      CancelControlID="btnCancel" X="600" Y="-5" BackgroundCssClass="modalBackground">
      </cc1:modalpopupextender>
     <asp:Panel ID="pnlpopup" runat="server"  CssClass="modalPopup" style="display:none; margin-top:0px"  >
          <div id="panel">
    <div class="post">
      <p class="details">View News</p>
      <div class="buffer">
          <asp:HiddenField ID="hiddenID" runat="server" />
       <asp:Table ID="Table1" runat="server" CssClass="tblInp">
           <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Title:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Label ID="tileLbl" runat="server" Width="430px" style="overflow: scroll;" ></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Abstract:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Label ID="AbstractLbl" runat="server" Width="430px"  Height="120px" style="overflow: scroll;" ></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Text:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Label ID="TextLbl" runat="server" Width="430px"  Height="140px" style="overflow: scroll;"></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Image:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Image ID="newsImage" runat="server" Width="180px" Height="180px"></asp:Image>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell></asp:TableCell>
               <asp:TableCell  HorizontalAlign="Center"> 
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
               </asp:TableCell>
           </asp:TableRow>
       </asp:Table>
   </div>
  </div>
        </div>
     </asp:Panel>
</asp:Content>
