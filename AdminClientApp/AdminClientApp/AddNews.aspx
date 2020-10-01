<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="AdminClientApp.AddNews" %>
  

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .msgLbl-class{
            margin-left:5px;
        }
    </style>
   <link rel="stylesheet" type="text/css" href="style.css" />
    <div id="panel">
    <div class="post">
      <p class="details1">Add News</p>
      <div class="buffer">
       <asp:Table ID="Table1" runat="server" CssClass="tblInp">
           <asp:TableRow>
               <asp:TableCell>
                    News Agency:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:DropDownList ID="Agencies" AppendDataBoundItems="true" runat="server" Width="200px"
                        DataTextField="City" DataValueField="AgencyID" Height="20px" >
                        <asp:ListItem Value="0">Select news agency</asp:ListItem>
                    </asp:DropDownList>
               </asp:TableCell>  
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell>
                    Category:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="CategoryBox" runat="server" Width="300px"></asp:TextBox>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell>
                    Title:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="tileBox" runat="server" Width="300px"></asp:TextBox>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell>
                    Abstract:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="AbstractBox" runat="server" Width="350px" TextMode="MultiLine" Height="200px"></asp:TextBox>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell>
                    Text:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="NewsText" runat="server" Width="350px" TextMode="MultiLine" Height="250px"></asp:TextBox>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell>
                    Photo:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:FileUpload ID="photo" runat="server" Width="250px" />
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell></asp:TableCell>
               <asp:TableCell  HorizontalAlign="Center">
                   <asp:Button ID="addBtn" runat="server" OnClick="addBtn_Click" Text="Save" />
                   <asp:Label ID="msgLbl" runat="server" CssClass="msgLbl-class"></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
       </asp:Table>
   </div>
  </div>
        </div>
</asp:Content>
