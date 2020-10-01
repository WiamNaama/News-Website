<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemoveNews.aspx.cs" Inherits="AdminClientApp.RemoveNews" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <style>
        .hiddencol
         {
             display:none;
         }
    </style>
    <link rel="stylesheet" type="text/css" href="style.css" />
      <div id="content">
          <div class="post">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
            OnRowCreated="GridView1_OnRowCreated" OnRowDeleting="GridView1_RowDeleting" Width="660px" Font-Size="12pt"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"  
                 PagerSettings-FirstPageText="&nbsp;First" PagerSettings-LastPageText="&nbsp;Last" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-PageButtonCount="4" PagerSettings-NextPageText="&nbsp;Next" PagerSettings-PreviousPageText="&nbsp;Previous"
                EmptyDataText="No data found!!">
                <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" >
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Abstract" HeaderText="Abstract" >
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="City" HeaderText="Agency" >
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}">
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="TotalReads" HeaderText="Total Reads" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="Classification" HeaderText="Classification" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Probability" HeaderText="Probability" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"
                            OnClientClick="return confirm('Are you sure?');" >
                            <img src="images/delete-forever.png" width="25" height="25" />
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>

                <HeaderStyle BackColor="#456069" ForeColor="White" />

<PagerSettings FirstPageText="&#160;First" LastPageText="&#160;Last" Mode="NextPreviousFirstLast" NextPageText="&#160;Next" PageButtonCount="4" PreviousPageText="&#160;Previous"></PagerSettings>

            </asp:GridView>
          </div>
        
    </div>
    </asp:Content>
