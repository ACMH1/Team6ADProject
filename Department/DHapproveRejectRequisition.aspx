<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DHapproveRejectRequisition.aspx.cs" Inherits="DHapproveReject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">Approve Reject</h1></center>



    <table>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" CssClass="grid" Style="z-index: 1; width: 744px; height: 214px; position: relative" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-success" Style="z-index: 1; position: relative" Text="Approve" />
            &nbsp;
                <asp:Button ID="Reject" runat="server" class="btn btn-danger" OnClick="Reject_Click" Style="z-index: 1; position: relative; height: 38px; width: 102px;" Text="Reject" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" class="labels" Style="z-index: 1; position: relative; height: 22px; width: 515px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" CssClass="labels" Style="z-index: 1; position: relative; width: 76px; height: 39px" Text="Reason"></asp:Label>
            </td>
            <td align="right">
                <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1; position: relative; width: 368px; height: 108px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>

