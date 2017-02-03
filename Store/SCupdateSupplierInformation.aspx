<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCupdateSupplierInformation.aspx.cs" Inherits="SCupdateSupplierInformation" EnableEventValidation = "false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">Update Supplier Information</h1></center>


    <asp:GridView ID="GridView1" runat="server" CssClass="grid" style="z-index: 1; width: 952px; height: 248px; position: absolute; top: 93px; left: 54px; right: 383px;"
        AutoGenerateColumns="False" DataKeyNames="suppliercode" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView1_RowCommand" AutoPostBack="true" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
         <AlternatingRowStyle BackColor="#CCCCCC" />
         <Columns>
            <asp:BoundField DataField="suppliercode" HeaderText="SupplierCode"  SortExpression="suppliercode" />
            <asp:BoundField DataField="suppliername" HeaderText="SupplierNamee" SortExpression="suppliernamee" />
            <asp:BoundField DataField="contactname" HeaderText="ContactName" SortExpression="contactname" />
            <asp:BoundField DataField="phonenumber" HeaderText="PhoneNumber" SortExpression="phonenumber" />
            <asp:BoundField DataField="faxnumber" HeaderText="FaxNumber" SortExpression="faxnumber" />
            <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
            <asp:BoundField DataField="gstregistrationno" HeaderText="GstRegistrationNo" SortExpression="gstregistrationno" />

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


    <asp:Button ID="Delete" class="btn btn-danger" runat="server" style="z-index: 1; position: absolute; top: 366px; left: 326px; height: 30px;" Text="Delete" OnClick="Delete_Click" />
    <asp:Button ID="Modify" class="btn btn-warning" runat="server" style="z-index: 1; position: absolute; top: 366px; left: 495px; width: 83px; height: 30px;" Text="Modify" OnClick="Modify_Click" />
    <asp:Button ID="Create" class="btn btn-success" runat="server" style="z-index: 1; position: absolute; top: 366px; left: 646px; height: 30px; width: 84px;" Text="Create" OnClick="Create_Click" />
    
    
    
    <table style="width: 68%; z-index: 1; height: 316px; position: absolute; top: 421px; left: 233px; margin-top: 0px;">
        <tr>
            <td style="width: 217px" class="modal-sm">&nbsp;<label class="labels">Supplier Code</label></td>
            <td style="width: 406px">&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>         
        </tr>
         <tr>
            <td style="width: 217px" class="modal-sm">&nbsp;<label class="labels">Supplier Name</label></td>
            <td style="width: 406px">&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 217px" class="modal-sm">&nbsp;<label class="labels">Contact Name</label></td>
            <td style="width: 406px">&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 217px" class="modal-sm">&nbsp;<label class="labels">Phone Number</label></td>
            <td style="width: 406px">&nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 217px" class="modal-sm">&nbsp;<label class="labels">Fax Number</label></td>
            <td style="width: 406px">&nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 217px" class="modal-sm">&nbsp;<label class="labels">Address</label></td>
            <td style="width: 406px">&nbsp;<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 217px" class="modal-sm">&nbsp;<label class="labels">GST Registration No</labe></td>
            <td style="width: 406px">&nbsp;<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>         
        </tr>
    </table>



<asp:Button ID="Cancel" runat="server" class="btn btn-danger" style="z-index: 1; position: absolute; top: 765px; left: 328px" Text="Cancel" OnClick="Cancel_Click" />
<asp:Button ID="Submit" class="btn btn-success" runat="server" style="z-index: 1; position: absolute; top: 765px; left: 503px" Text="Save" OnClick="Save_Click" />




</asp:Content>

