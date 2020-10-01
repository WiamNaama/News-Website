<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminClientApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="style.css" />
    <div id="content">
        <asp:ListView ID="LV1" runat="server" GroupItemCount="2" DataKeyNames="ID" OnItemDataBound="LV1_OnItemDataBound">
             <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
             <ItemTemplate>
                  <!-- begin post -->
                 <div class="post">
                     <asp:HiddenField ID="IDHid" Value='<%# Eval("ID") %>' runat="server" />
                    <p class="details1"><%# Eval("Date","{0:dd, MM, yyyy}") %>
                        <br /><br /><%# Eval("Title") %></p>
                    <div class="buffer">
                    <div class="content">
                        <asp:Image ID="newsPhoto"  runat="server"  Height="100" Width="150"/>
                        <h2><%# Eval("Abstract") %></h2>
                        <p><%# Eval("Text") %></p>
                    </div>
                        <p class="details2">Total Reads:<%# Eval("TotalReads") %>
                            <br />
                            <p class="details2">Ranking:<%# Eval("Classification") %>:<%# Eval("Probability") %>   
                           </p>
                        </p>
                    </div>
                </div>
                <!-- end post -->
             </ItemTemplate>
        </asp:ListView>
  </div>

</asp:Content>
