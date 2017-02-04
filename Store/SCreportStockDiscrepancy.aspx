<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCreportStockDiscrepancy.aspx.cs" Inherits="SCreportStockDiscrepancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">Report Stock Discrepancy</h1></center>

    <table style="width: 79%; z-index: 1; height: 327px; position: absolute; top: 289px; left: 27px;">
        <tr>
            <td style="width: 241px">&nbsp;<label class="labels">Supplier Code</label></td>
            <td>&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 241px">&nbsp;<label class="labels">Item Code</label></td>
            <td>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
                <asp:Calendar ID="Calendar1" runat="server" Style="z-index: 1; width: 379px; height: 184px; position: absolute; top: -204px; left: 246px" OnSelectionChanged="DateSelectedChanged" BackColor="White"></asp:Calendar>
            </td>

        </tr>
        <tr>
            <td style="width: 241px">&nbsp;<label class="labels">Item Category</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="23px" ReadOnly="True" Width="218px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 241px">&nbsp;<label class="labels">Item Description</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Width="287px" Enabled="False"></asp:TextBox>
                <asp:Label ID="Date" CssClass="labels" runat="server" Style="z-index: 1; position: absolute; top: -205px; left: 9px; width: 130px; height: 26px" Text="Date issued "></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 241px">&nbsp;<label class="labels">quantity</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox3" runat="server" ReadOnly="True" Width="215px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 241px">&nbsp;<label class="labels">Adjust</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="214px"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Must be an integer." ForeColor="Red" Type="Integer"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please enter a quantity." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 241px">&nbsp;<label class="labels">Reason</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
    </table>


    <asp:Button ID="Add" class="btn btn-success" runat="server" Style="z-index: 1; position: absolute; top: 631px; left: 271px; width: 109px; height: 35px;" Text="Add" OnClick="Add_Click" />
    <asp:Button ID="Report" class="btn btn-danger" runat="server" Style="z-index: 1; position: absolute; top: 631px; left: 91px; height: 35px; width: 114px;" Text="Report" OnClick="Report_Click" />
    <asp:GridView ID="GridView1" CssClass="grid" runat="server" Style="z-index: 1; width: 187px; height: 127px; position: absolute; top: 694px; left: 95px" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="itemcode" HeaderText="itemcode" SortExpression="itemcode" />
            <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
            <asp:BoundField DataField="reason" HeaderText="reason" SortExpression="reason" />
            <asp:ButtonField CommandName="Delete" Text="Remove" />
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

</asp:Content>


