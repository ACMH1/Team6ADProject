<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCselectStockSupplier.aspx.cs" Inherits="SCselectStockSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">Select Stock Supplier</h1></center>
    <table style="width: 50%; z-index: 1; height: 205px; position: absolute; top: 142px; left: 286px;">
        <tr>
            <td class="modal-sm" style="width: 164px">&nbsp;<label class="labels">Item Code</label></td>

            <td>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td>
            <td class="modal-sm" style="width: 164px">&nbsp;<label class="labels"></label></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 164px">&nbsp;<label class="labels">Supplier 1</label></td>
            <td class="modal-sm" style="width: 164px">&nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 164px">&nbsp;<label class="labels">Supplier 2</label></td>
            <td class="modal-sm" style="width: 164px">&nbsp;<asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 164px">&nbsp;<label class="labels">Supplier 3</label></td>
            <td class="modal-sm" style="width: 164px">&nbsp;<asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
            <td>&nbsp;<asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>
                <asp:Button ID="Update" runat="server" class="btn btn-success" Style="z-index: 1; position: relative;" Text="Update" OnClick="Update_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

