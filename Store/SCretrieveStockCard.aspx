<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCretrieveStockCard.aspx.cs" Inherits="SCretrieveStockCard" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <center><h1 style="color:darkblue;font-weight:bold;" >Retrieve Stock Card</h1></center>
    <br />
    <br />
    <table style="width: 86%; z-index: 1; height: 280px; position: absolute; top: 151px; left: 132px; margin-bottom: 54px;">
        <tr>
            <td class="modal-sm" style="width: 202px">&nbsp;<label class="labels">Item Description </label></td>
            <td>&nbsp;<asp:Label ID="Label2" runat="server" Text="Label" Font-Italic="True" Font-Size="X-Large"></asp:Label></td>
            
        </tr>
        <tr>
            <td class="modal-sm" style="width: 202px">&nbsp;<label class="labels">Bin# </label></td>
            <td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Font-Italic="True" Font-Size="X-Large"></asp:Label></td>
            
        </tr>
        <tr>
            <td class="modal-sm" style="width: 202px">&nbsp;<label class="labels">UOM </label></td>
            <td>&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Font-Italic="True" Font-Size="X-Large"></asp:Label></td>
           
        </tr>
         <tr>
            <td class="modal-sm" style="width: 202px">&nbsp;<label class="labels">1st Supplier </label></td>
            <td>&nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Font-Italic="True" Font-Size="X-Large"></asp:Label></td>
           
        </tr>
         <tr>
            <td class="modal-sm" style="width: 202px">&nbsp;<label class="labels">2nd Supplier </label></td>
            <td>&nbsp;<asp:Label ID="Label6" runat="server" Text="Label" Font-Italic="True" Font-Size="X-Large"></asp:Label></td>
           
        </tr>
         <tr>
            <td class="modal-sm" style="width: 202px">&nbsp;<label class="labels">3rd Supplier </label></td>
            <td>&nbsp;<asp:Label ID="Label7" runat="server" Text="Label" Font-Italic="True" Font-Size="X-Large"></asp:Label></td>
           
        </tr>
    </table>
    <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; position: absolute; top: 94px; left: 340px; width: 249px; height: 26px; " OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="itemcode" DataValueField="itemcode" AutoPostBack="True">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionstring %>" SelectCommand="SELECT [itemcode] FROM [Item]"></asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" CssClass="labels" Font-Bold="True" style="z-index: 1; position: absolute; top: 89px; left: 133px; width: 140px" Text="Item Code "></asp:Label>
<asp:GridView ID="GridView1" CssClass="grid" runat="server" style="z-index: 1; width: 921px; height: 127px; position: absolute; top: 460px; left: 130px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <FooterStyle BackColor="#CCCCCC" />
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#808080" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>
</asp:Content>

