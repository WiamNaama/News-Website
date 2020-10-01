<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAgency.aspx.cs" Inherits="AdminClientApp.AddAgency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .msgLbl-class{
            margin-left:5px;
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
            width: 800px;
            height:40px;
        }
    </style>
   <link rel="stylesheet" type="text/css" href="style.css" />
    <div id="panel">
    <div class="post">
      <p class="details">Add Agency</p>
      <div class="buffer">
       <asp:Table ID="Table1" runat="server" CssClass="tblInp">
           <asp:TableRow>
               <asp:TableCell>
                    City:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="cityBox" runat="server" Width="300px"></asp:TextBox>
               </asp:TableCell>
           </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell>
                    Language:
               </asp:TableCell>
               <asp:TableCell>
                   <asp:TextBox ID="languageBox" runat="server" Width="300px" ></asp:TextBox>
               </asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell></asp:TableCell>
               <asp:TableCell  HorizontalAlign="Center">
                   <asp:Button ID="addBtn" runat="server" OnClick="addBtn_Click" Text="Save" />
                  &nbsp; <asp:Label ID="msgLbl" runat="server" CssClass="msgLbl-class"></asp:Label>
               </asp:TableCell>
           </asp:TableRow>
       </asp:Table>
   </div>
  </div>
        </div>
</asp:Content>
