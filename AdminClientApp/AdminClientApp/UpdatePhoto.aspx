<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePhoto.aspx.cs" Inherits="AdminClientApp.UpdatePhoto" %>
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
        width: 530px;
        height: 550px;
    }
    .modalBackground 
    {
        height:100%;
        background-color:#EBEBEB;
        filter:alpha(opacity=50);
        opacity:0.7;
    }
#edit {
    float: left;
    width: 670px;
    overflow: hidden;
    padding-bottom: 11px;
    padding-top: 0px;
    
}
#edit .post {
    float: left;
    width: 500px;
    padding: 11px 10px 0 0;
    font-size: 16px;
}
#edit .post .buffer {
    padding: 4px;
    background-color: #ECEBEB;
    margin: 0;
    width: 500px;
            
}
#edit .post .details {
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
    width: 500px;
    height:40px;
}
.tblInp1 {
    margin-top: 10px;
    margin-left: 10px;
    font-size: 14px;
    
}
.tblInp1 tr{
    height:25px;
}
table.tblInp1 td{ border:2px solid #ECEBEB;}
    </style>
    <link rel="stylesheet" type="text/css" href="style.css" />
      <div id="content">
          <div class="post">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
            OnRowCreated="GridView1_OnRowCreated"  Width="660px" Font-Size="12pt" EmptyDataText="No data found!!"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                 PagerSettings-FirstPageText="&nbsp;First" PagerSettings-LastPageText="&nbsp;Last" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-PageButtonCount="4" PagerSettings-NextPageText="&nbsp;Next" PagerSettings-PreviousPageText="&nbsp;Previous">
                <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Abstract" HeaderText="Abstract" />
                <asp:BoundField DataField="City" HeaderText="Agency" />
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="TotalReads" HeaderText="Total Reads" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False"  OnClick="btnEdit_click" ImageUrl="images/edit.jpg" Width="25" Height="25" >
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>

                <HeaderStyle BackColor="#456069" ForeColor="White" />

            </asp:GridView>
          </div>
        
    </div>
    <asp:Button ID="btnShowPopup" runat="server" style="display:none" />

     <cc1:modalpopupextender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
      CancelControlID="btnCancel" X="600" Y="50" BackgroundCssClass="modalBackground">
      </cc1:modalpopupextender>
     <asp:Panel ID="pnlpopup" runat="server"  CssClass="modalPopup" style="display:none; margin-top:0px"  >
          <div id="edit">
    <div class="post">
      <p class="details">Update News Image</p>
      <div class="buffer">
          <asp:HiddenField ID="hiddenID" runat="server" />
       <asp:Table ID="Table1" runat="server" CssClass="tblInp1">
           <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Title:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Label ID="tileLbl" runat="server" Width="400px" style="overflow: scroll;"></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Abstract:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Label ID="AbstractLbl" runat="server" Width="400px"  Height="150px" style="overflow: scroll;"></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Image:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:Image ID="newsImage" runat="server" Width="200px" Height="200px"></asp:Image>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell>
                    Update Image:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:FileUpload ID="photo" runat="server" Width="250px" />
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell></asp:TableCell>
               <asp:TableCell  HorizontalAlign="Center">
                   <br />
                   <asp:Button ID="addBtn" runat="server" OnClick="editImg_Click" Text="Save" />
                   &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
               </asp:TableCell>
           </asp:TableRow>
       </asp:Table>
   </div>
  </div>
        </div>
     </asp:Panel>
</asp:Content>
