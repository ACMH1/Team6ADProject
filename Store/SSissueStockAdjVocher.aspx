<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="SSissueStockAdjVocher.aspx.cs" Inherits="SSissueStockAdjVocher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Issue Stock Adjustment Vouchers</h3>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="grid" DataKeyNames="vouchernumber" Width="1043px" OnRowCommand="GridView2_RowCommand">
            <Columns>
                <asp:BoundField DataField="vouchernumber" HeaderText="Voucher Number" ReadOnly="true" SortExpression="vouchernumber" />
                <asp:BoundField DataField="Issuedate" HeaderText="IssueDate" ReadOnly="true" SortExpression="vouchernumber" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="employee.employeename" HeaderText="ClerkName" ReadOnly="true" SortExpression="clerkname" />
                <asp:BoundField DataField="cost" HeaderText="Cost" ReadOnly="true" SortExpression="cost" />
                <asp:ButtonField CommandName="Details" HeaderText="Details" ShowHeader="True" Text="Details" />
                <asp:ButtonField CommandName="Approve" HeaderText="Approve" ShowHeader="True" Text="Approve" />
                <asp:ButtonField CommandName="Reject" HeaderText="Reject" ShowHeader="True" Text="Reject" />

            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <table style="width: 1043px; height: 188px">
            <tr><td> </td></tr>
            <tr>
                <td class="modal-lg" style="width: 1707px; height: 30px;">
                    <asp:Label ID="Label1" runat="server" class="labels" Style="z-index: 1; position: relative"></asp:Label>
                </td>
                <td style="width: 684px; height: 30px;" align="right">
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger" OnClick="LinkButton2_Click">Reject All</asp:LinkButton>
                </td>
                <td style="width: 135px; height: 30px;" align="right">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" OnClick="LinkButton1_Click">Approve All</asp:LinkButton>
                </td>
            </tr>
            <tr><td> </td></tr>
            <tr>
                <td class="modal-lg" style="width: 1707px; height: 26px;">&nbsp;</td>
                <td style="width: 684px; height: 26px;">&nbsp;</td>

                <td style="width: 135px; height: 26px;">

                    <asp:Label ID="Label2" runat="server" Text="Reject Reason : " Font-Size="Large"></asp:Label></td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 1707px"></td>
                <td style="width: 684px"></td>
                <td style="width: 135px">
                    <asp:TextBox ID="TextBox1" runat="server" Height="70px" Width="271px" Style="margin-top: 29"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>


    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" CssClass="grid" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
    </p>

    <br />
    <br />
</asp:Content>
