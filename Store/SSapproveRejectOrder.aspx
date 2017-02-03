<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="SSapproveRejectOrder.aspx.cs" Inherits="SSapproveRejectOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center><h1 style="color:darkblue;font-weight:bold;">Approve/Reject Orders</h1></center>
    <p>


        <asp:GridView ID="GridView2" runat="server" CssClass="grid" AutoGenerateColumns="False" DataKeyNames="purchaseordernumber" Height="233px" Width="864px" OnRowCommand="GridView2_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="purchaseordernumber" HeaderText="Purchase Order Number" ReadOnly="True" SortExpression="purchaseordernumber" />
                <asp:BoundField DataField="employee.employeename" HeaderText="Ordered By" SortExpression="storeclerkcode" NullDisplayText="System" />
                <asp:BoundField DataField="orderdate" HeaderText="Order Date" SortExpression="orderdate" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="totalcost" HeaderText="Total Cost" SortExpression="totalcost" />
                <asp:BoundField DataField="suppliercode" HeaderText="Supplier" SortExpression="suppliercode" />
                <asp:ButtonField CommandName="Details" HeaderText="Details" ShowHeader="True" Text="Details" />
                <asp:ButtonField CommandName="Approve" HeaderText="Approve" ShowHeader="True" Text="Approve" />
                <asp:ButtonField CommandName="Reject" HeaderText="Reject" ShowHeader="True" Text="Reject" />

            </Columns>
        </asp:GridView>
    </p>
    <table style="width: 865px; height: 188px">
        <tr>
            <td class="modal-lg" style="width: 1225px; height: 30px;">
                <asp:Label ID="Label1" class="labels" runat="server" Style="z-index: 1; position: relative"></asp:Label>
            </td>
            <td style="width: 621px; height: 30px;" align ="right">
                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-danger" OnClick="LinkButton2_Click" Font-Size="Large" ForeColor="White">Reject All</asp:LinkButton>
            </td>
            <td style="width: 147px; height: 30px;" align ="right">
                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="LinkButton1_Click" Font-Size="Large" ForeColor="White">Approve All</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="modal-lg" style="width: 1225px; height: 64px;">&nbsp;</td>
            <td style="width: 621px; height: 64px;">&nbsp;</td>

            <td style="width: 147px; height: 64px;">

                <asp:Label ID="Label2" runat="server" Text="Reject Reason : " Font-Italic="True" Font-Size="Large"></asp:Label></td>
        </tr>
        <tr>
            <td class="modal-lg" style="width: 1707px"></td>
            <td style="width: 621px"></td>
            <td style="width: 147px">
                <asp:TextBox ID="TextBox1" runat="server" Height="70px" Width="271px" Style="margin-top: 29"></asp:TextBox>
            </td>
            <td></td>
        </tr>
    </table>





    <br />


    <asp:GridView ID="GridView1" class="grid" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="274px" Width="938px">
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
    <br />
</asp:Content>
