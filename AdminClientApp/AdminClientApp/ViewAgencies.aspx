<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAgencies.aspx.cs" Inherits="AdminClientApp.ViewAgencies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
.hiddencol
    {
        display:none;
    }
</style>
    <link rel="stylesheet" type="text/css" href="style.css" />
      <div id="content">
          <div class="post">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AgencyID" 
            OnRowCreated="GridView1_OnRowCreated"  Width="660px" Font-Size="12pt" EmptyDataText="No news found!!"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                 PagerSettings-FirstPageText="&nbsp;First" PagerSettings-LastPageText="&nbsp;Last" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-PageButtonCount="4" PagerSettings-NextPageText="&nbsp;Next" PagerSettings-PreviousPageText="&nbsp;Previous">
                <Columns>
                <asp:BoundField DataField="AgencyID" HeaderText="AgencyID" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Language" HeaderText="Language" />
                </Columns>

                <HeaderStyle BackColor="#456069" ForeColor="White" />

            </asp:GridView>
          </div>
        
    </div>
</asp:Content>
