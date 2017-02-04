<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCupdateTenderInformation.aspx.cs" Inherits="SCupdateTenderInformation" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">Update Tender Information
        
         
        </h1></center>
    <table style="width: 73%; z-index: 1; height: 96px; position: absolute; top: 96px; left: 78px; margin-top: 0px;">
        <tr>
            <td style="width: 298px"><label class="labels">Name of Supplier</label></td>
            
            <td><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td>
          
        </tr>
        <tr>
            <td style="width: 298px"><label class="labels">Address of Supplier</label></td>
            <td><asp:Label ID="Label" runat="server" Text="Label" Font-Italic="True" Font-Size="Large"></asp:Label></td>      
        </tr>
       
    </table>

<asp:GridView ID="GridView1" runat="server" CssClass="grid" style="z-index: 1; width: 578px; height: 255px; position: absolute; top: 211px; left: 87px" AutoGenerateColumns="False" 
    OnRowDataBound="OnRowDataBound" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" PageSize="8" AllowPaging="True">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:BoundField DataField="itemdesc" HeaderText="ItemDescription" SortExpression="itemdesc" ControlStyle-BorderWidth="350px" >
<ControlStyle BorderWidth="350px"></ControlStyle>
        </asp:BoundField>
        <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" ControlStyle-BorderWidth="353px" >
<ControlStyle BorderWidth="353px"></ControlStyle>
        </asp:BoundField>
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




    <table style="position: absolute; top: 475px; left: 93px;">
       <tr>
            <td style="width: 256px">
               <asp:Label ID="Label3" CssClass="labels" runat="server" style="z-index: 1;  top: 114px; left: 128px; width: 22px;" Text="ItemCode"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" style="z-index: 1; position: relative; width: 240px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td style="width: 256px">
                <asp:Label ID="Label1" CssClass="labels" runat="server" style="z-index: 1;  top: 40px; left: 94px" Text="ItemDescription"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; position: relative; width: 240px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td style="width: 256px">
               <asp:Label ID="Label2" CssClass="labels" runat="server" style="z-index: 1;  top: 114px; left: 128px; width: 22px;" Text="Price"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; position: relative; width: 240px; margin-top: 0;"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Price needs to be a number" ControlToValidate="TextBox2" ForeColor="Red" Type="Currency"></asp:CompareValidator>
            </td>
           
        </tr>
    </table>
    <asp:Button ID="Submit" CssClass="btn btn-success" runat="server" style="z-index: 1; position: absolute; top: 652px; left: 354px" Text="Save" OnClick="Save_Click" />
</asp:Content>

