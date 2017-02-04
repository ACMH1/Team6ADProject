<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCupdateCatalog.aspx.cs" Inherits="SCupdateCatalog" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">Update Catalog</h1></center>
    

    <asp:GridView ID="GridView1" CssClass="grid" runat="server" style="z-index: 1;  width: 934px; height: 337px; position: absolute; top: 76px; left: 75px" 
         AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="itemcode" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="itemcode" HeaderText="ItemCode" ReadOnly="True" SortExpression="itemcode" />
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
            <asp:BoundField DataField="itemdescription" HeaderText="ItemDescription" SortExpression="itemdescription" />
            <asp:BoundField DataField="reorderlevel" HeaderText="ReorderLevel" SortExpression="reorderlevel" />
            <asp:BoundField DataField="reorderquantity" HeaderText="ReorderQuantity" SortExpression="reorderquantity" />
            <asp:BoundField DataField="unitofmeasure" HeaderText="UnitOfMeasure" SortExpression="unitofmeasure" />
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



    <asp:Button ID="Submit" runat="server" class="btn btn-success" style="z-index: 1; position: absolute; top: 921px; left: 234px; margin-top: 0;" Text="Submit" OnClick="Submit_Click" />
    <asp:Button ID="Delete" class="btn btn-danger" runat="server" style="z-index: 1; position: absolute; top: 429px; left: 357px; margin-top: 0;" Text="Delete" OnClick="Delete_Click" />
    <asp:Button ID="Modify" class="btn btn-warning" runat="server" style="z-index: 1; position: absolute; top: 429px; left: 502px" Text="Modify" OnClick="Modify_Click" />
    


    <table style="width: 94%; z-index: 1; height: 424px; position: absolute; top: 482px; left: 70px; right: 11px; margin-bottom: 66px;">
        <tr>
            <td style="height: 47px; width: 408px;">&nbsp;<label class="labels">Item Code</label></td>
            <td style="height: 47px">&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="183px"></asp:TextBox></td>
            
        </tr>
       <tr>
            <td style="width: 408px; height: 47px;">&nbsp;<label class="labels">Category</label></td>
            <td style="height: 47px">
                <asp:TextBox ID="TextBox6" runat="server" Width="243px" style="margin-left: 26" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox6" ErrorMessage="field required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>        
        </tr>
        <tr>
            <td style="width: 408px; height: 48px;">&nbsp;<label class="labels">Description</label></td>
            <td style="height: 48px">&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="636px" Height="27px" style="margin-left: 11"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="field required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>           
        </tr>
        <tr>
            <td style="width: 408px; height: 48px;">&nbsp;<label class="labels">Record Level</label></td>
            <td style="height: 48px"><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="field required" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please enter an integer" ForeColor="Red" Type="Integer"></asp:RangeValidator>
            </td>           
        </tr>
           <tr>
            <td style="width: 408px; height: 48px;">&nbsp;<label class="labels">Record Quantity</label></td>
            <td style="height: 48px"><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="field required" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please enter an integer" ForeColor="Red" Type="Integer"></asp:RangeValidator>
               </td>           
        </tr>
         <tr>
            <td style="width: 408px; height: 48px;">&nbsp;<label class="labels">Unit of Measure</label></td>
            <td style="height: 48px">
                <asp:TextBox ID="TextBox7" runat="server" Width="242px" ></asp:TextBox>
             </td>        
        </tr>
          <tr>
            <td style="width: 408px; height: 48px;">&nbsp;<label class="labels">Bin Number</label></td>
            <td style="height: 48px"><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>           
        </tr>
    </table>
    <asp:Button ID="Create" class="btn btn-success" runat="server" OnClick="Create_Click" style="z-index: 1; position: absolute; top: 429px; left: 662px" Text="Create" />
</asp:Content>

