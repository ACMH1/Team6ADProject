<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCreceiveOrderfromSupplier.aspx.cs" Inherits="SCreceiveOrderfromSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">Receive Order from Supplier</h1></center>
    <table>
        <tr>
            <td>
                <asp:Label CssClass="labels" ID="Label1" runat="server" Style="z-index: 1; position: relative;" Text="Supplier"></asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Style="z-index: 1; position: relative;" DataSourceID="SqlDataSource1" DataTextField="suppliercode" DataValueField="suppliercode" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT [suppliercode] FROM [Supplier]"></asp:SqlDataSource>
                <asp:Label CssClass="labels" ID="Label2" runat="server" Style="z-index: 1; position: relative;" Text="DeliveryNO"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1; position: relative;" ValidationGroup="vg"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Key in Delivery Order Number" ForeColor="Red" Style="z-index: 1; position: relative;" ValidationGroup="vg"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <%--    <table style="width: 21%; z-index: 1; height: 60px; position: absolute; top: 118px; left: 170px;">
        <tr>
            <td style="width: 140px">&nbsp;<label>Delivery Order No</label></td>
            <td>&nbsp;<label id="delivery"></label></td>
        
        </tr>
        <tr>
            <td style="width: 140px">&nbsp;<label>Reference no</label></td>
            <td>&nbsp;<label id="ref"></label></td>
          
        </tr>
       
    </table>--%>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Style="z-index: 1; position: relative;" Font-Italic="True" Font-Size="XX-Large" ForeColor="#333399"></asp:Label><br />
                <asp:GridView ID="GridView1" CssClass="grid" runat="server" Style="z-index: 1; width: 882px; height: 247px; position: relative" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField HeaderText="Purchaseid" DataField="purchaseid" />
                        <asp:BoundField HeaderText="ItemCode" DataField="ItemCode" />
                        <asp:BoundField HeaderText="ItemDescription" DataField="ItemDescription" />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />

                        <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:TextBox ID="TextRemarks" runat="server" CssClass="txtBoxNormalmedium" Text=''></asp:TextBox>
                            </ItemTemplate>

                        </asp:TemplateField>

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
            </td>
        </tr>
        <tr>
            <td>&nbsp</td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="Button1" class="btn btn-success" runat="server" Style="z-index: 1; position: relative; height: 36px;" Text="Submit" OnClick="Button1_Click" ValidationGroup="vg" />
            </td>
        </tr>
    </table>
</asp:Content>

