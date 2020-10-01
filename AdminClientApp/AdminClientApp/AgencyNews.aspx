<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgencyNews.aspx.cs" Inherits="AdminClientApp.AgencyNews" %>
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
            padding-top: 10px;
            padding-left: 10px;
            width: 610px;
            height: 600px;
        }
        .modalBackground 
        {
            height:100%;
            background-color:#EBEBEB;
            filter:alpha(opacity=50);
            opacity:0.7;
        }
        #panel_div {
    float: left;
    width: 900px;
    overflow: hidden;
    padding-bottom: 11px;
    padding-top: 0px;
    
}
    #panel_div .post {
        float: left;
        width: 800px;
        padding: 11px 10px 0 0;
        font-size: 16px;
    }
        #panel_div .post .buffer {
            padding: 4px;
            background-color: #ECEBEB;
            margin: 0;
            width: 800px;
            
        }
        #panel_div .post .details {
            background-color: #ECEBEB;
            color: #808080;
            font-size: 0.8em;
            font-family: Verdana;
            font-weight: bold;
            padding: 8px 7px;
            text-transform: uppercase;
            margin-bottom: 5px;
            overflow-y: auto;
            width: 800px;
            height:40px;
        }
        #panel_div .post .buffer {
		padding: 4px;
        width:800px;
		background-color: #ECEBEB;
		margin: 0;
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
        overflow-y: auto;

        height: 40px;
    }
        .gv-class{
            margin-top:10px;
        }
</style>
     <link rel="stylesheet" type="text/css" href="style.css" />
      <div id="panel_div">
          <div class="post">
              <p class="details">Agency News</p>
              <div class="buffer">
                   <asp:DropDownList ID="Agencies" AppendDataBoundItems="true" runat="server" Width="200px" AutoPostBack="true"
                        DataTextField="City" DataValueField="AgencyID" Height="20px" OnSelectedIndexChanged="Agencies_Change" >
                        <asp:ListItem Value="0">Select news agency</asp:ListItem>
                    </asp:DropDownList>
              <br />
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
            OnRowCreated="GridView1_OnRowCreated"  Width="660px" Font-Size="12pt" CssClass="gv-class" EmptyDataText="No news found!!"
                    AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                 PagerSettings-FirstPageText="&nbsp;First" PagerSettings-LastPageText="&nbsp;Last" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-PageButtonCount="4" PagerSettings-NextPageText="&nbsp;Next" PagerSettings-PreviousPageText="&nbsp;Previous">
                <Columns>
                 <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Abstract" HeaderText="Abstract" />
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="TotalReads" HeaderText="Total Reads" />
                 <asp:BoundField DataField="Classification" HeaderText="Classification" />
                    <asp:BoundField DataField="Probability" HeaderText="Probability" /> 
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False"  OnClick="btnView_click" ImageUrl="images/view.png" Width="25" Height="25" >
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>

                <HeaderStyle BackColor="#456069" ForeColor="White" />

            </asp:GridView>
                  </div>
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
                   <asp:Label ID="tileLbl" runat="server" Width="500px" style="overflow: scroll;"></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Abstract:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Label ID="AbstractLbl" runat="server" Width="500px"  Height="120px" style="overflow: scroll;"></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Text:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Label ID="TextLbl" runat="server" Width="500px"  Height="130px" style="overflow: scroll;"></asp:Label>
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
