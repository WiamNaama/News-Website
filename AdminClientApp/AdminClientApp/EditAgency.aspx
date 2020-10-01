<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAgency.aspx.cs" Inherits="AdminClientApp.EditAgency" %>
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
    width: 400px;
    height: 200px;
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
    width: 550px;
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
    width: 370px;
            
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
            overflow-y: auto;
            width: 370px;
            height:40px;
        }
</style>
    <link rel="stylesheet" type="text/css" href="style.css" />
      <div id="content">
          <div class="post">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AgencyID" 
            OnRowCreated="GridView1_OnRowCreated"  Width="660px" Font-Size="12pt" EmptyDataText="No news found!!"
                OnRowDeleting="GridView1_RowDeleting"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                 PagerSettings-FirstPageText="&nbsp;First" PagerSettings-LastPageText="&nbsp;Last" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-PageButtonCount="4" PagerSettings-NextPageText="&nbsp;Next" PagerSettings-PreviousPageText="&nbsp;Previous">
                <Columns>
                <asp:BoundField DataField="AgencyID" HeaderText="AgencyID" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Language" HeaderText="Language" />
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False"  OnClick="btnEdit_click" ImageUrl="images/edit.jpg" Width="25" Height="25" >
                        </asp:ImageButton>
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </asp:TemplateField>
                <asp:TemplateField >
                        <HeaderTemplate>
                        <center></center>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"  OnClientClick="return confirm('Are you sure?'); " ImageUrl="images/delete-forever.png" Width="25" Height="25" >
                        </asp:ImageButton> 
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </asp:TemplateField>  
                </Columns>

                <HeaderStyle BackColor="#456069" ForeColor="White" />

            </asp:GridView>
          </div>
        
    </div>
    <asp:Button ID="btnShowPopup" runat="server" style="display:none" />

     <cc1:modalpopupextender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
      CancelControlID="btnCancel" X="600" Y="100" BackgroundCssClass="modalBackground">
      </cc1:modalpopupextender>
     <asp:Panel ID="pnlpopup" runat="server"  CssClass="modalPopup" style="display:none; margin-top:0px"  >
          <div id="edit">
    <div class="post">
      <p class="details">Update Agency</p>
      <div class="buffer">
          <asp:HiddenField ID="hiddenID" runat="server" />
       <asp:Table ID="Table1" runat="server" CssClass="tblInp">
           <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    City:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="CityTxt" runat="server" Width="250px"></asp:TextBox>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell VerticalAlign="Top">
                    Language:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="LanguageTxt" runat="server" Width="250px"></asp:TextBox>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell></asp:TableCell>
               <asp:TableCell  HorizontalAlign="Center">
                   <br />

                   <asp:Button ID="addBtn" runat="server" OnClick="editAgency_Click" Text="Save" />
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
