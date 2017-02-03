<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCsendOrdertoSupplier.aspx.cs" Inherits="SCsendOrdertoSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <center><h1 style="color:darkblue;font-weight:bold;" >
       Send Order to Supplier</h1></center>
    <asp:Button ID="Button3" runat="server" class="btn btn-warning" Style="z-index: 1; position: absolute; top: 323px; left: 271px" Text="Add Item" OnClick="Button3_Click" ValidationGroup="vg" />
    <asp:RadioButton ID="RadioButton1" GroupName="GROUP1" Checked="true" runat="server" Style="z-index: 1; position: absolute; top: 154px; left: 269px" Font-Italic="True" Font-Size="Large" />
    <asp:Label ID="Label4" runat="server" Style="z-index: 1; position: absolute; top: 155px; left: 348px; right: 93px;" Text="Label" Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
    <asp:RadioButton ID="RadioButton2" GroupName="GROUP1" runat="server" Style="z-index: 1; position: absolute; top: 186px; left: 269px" Font-Italic="True" Font-Size="Large" />
    <asp:Label ID="Label1" runat="server" Style="z-index: 1; position: absolute; top: 186px; left: 347px; right: 305px;" Text="Label" Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
    <asp:RadioButton ID="RadioButton3" GroupName="GROUP1" runat="server" Style="z-index: 1; position: absolute; top: 218px; left: 268px" Font-Italic="True" Font-Size="Large" />
    <asp:Label ID="Label5" runat="server" Style="z-index: 1; position: absolute; top: 218px; left: 347px; right: 312px;" Text="Label" Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>

    <asp:Label ID="Label2" CssClass="labels" runat="server" Style="z-index: 1; position: absolute; top: 103px; left: 160px" Text="Item Code"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" Style="z-index: 1; position: absolute; top: 108px; left: 279px" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="itemdescription" DataValueField="itemcode" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT [itemcode], [itemdescription] FROM [Item]"></asp:SqlDataSource>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Quantity in the Text Box" Style="z-index: 1; position: absolute; top: 272px; left: 345px" ValidationGroup="vg">*</asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="TextBox1" ErrorMessage="Please Enter Only Numbers" Style="z-index: 1; position: absolute; top: 272px; left: 369px" ForeColor="Red" ValidationGroup="vg">*</asp:CompareValidator>
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Style="z-index: 1; width: 371px; height: 53px; position: absolute; top: 268px; left: 462px" ValidationGroup="vg" />
    <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" ControlToValidate="TextBox1" ErrorMessage="Range~Min-0 Max-400" MinimumValue="0" MaximumValue="400" Style="z-index: 1; position: absolute; top: 272px; left: 358px; height: 23px;" ForeColor="Red" ValidationGroup="vg">*</asp:RangeValidator>
    <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1; position: absolute; top: 269px; left: 268px"></asp:TextBox>
    <asp:Label ID="Label6" CssClass="labels" runat="server" Style="z-index: 1; position: absolute; top: 270px; left: 160px" Text="Quantity"></asp:Label>
    <asp:Label ID="Label3" CssClass="labels" runat="server" Style="z-index: 1; position: absolute; top: 152px; left: 160px" Text="Supplier"></asp:Label>


    <%--<asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 734px; height: 127px; position: absolute; top: 386px; left: 161px"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
    <Columns> 
        <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>
       <asp:BoundField HeaderText="Item Number" DataField="item.itemcode" />
        <asp:BoundField HeaderText="ItemDescription" DataField="ItemDescription" />
        <asp:BoundField HeaderText="AllocatedQuantity" DataField="AllocatedQuantity" />
    </Columns>
</asp:GridView>--%>
    <table style="width: 50%; z-index: 1; height: 205px; position: absolute; top: 380px; left: 270px;">
        <tr>
            <td>
                <asp:GridView CssClass="grid" ID="GridView1" runat="server" Style="z-index: 1; width: 734px; height: 127px; position: relative" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical" ForeColor="Black">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <%--<asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>--%>
                        <asp:BoundField HeaderText="S.NO" DataField="S.no" />
                        <asp:BoundField HeaderText="Item Number" DataField="Item Number" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                        <asp:BoundField HeaderText="Price" DataField="Price" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" />
                        <asp:BoundField HeaderText="Supplier" DataField="Supplier" />
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
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
            <td align="right">
                <asp:Button ID="Button4" runat="server" class="btn btn-danger" OnClick="Button4_Click" Style="z-index: 1; position: relative;" Text="Delete" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" class="btn btn-success" runat="server" Style="z-index: 1; position: relative; height: 36px; width: 83px;" Text="Submit" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

