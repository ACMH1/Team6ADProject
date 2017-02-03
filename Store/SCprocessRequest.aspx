<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCprocessRequest.aspx.cs" Inherits="SCprocessRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        //Stop Form Submission of Enter Key Press
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
        }
        document.onkeypress = stopRKey;
    </script>
    <link href="StyleSheet.css" rel="stylesheet" />
    <center><h1 style="color:darkblue;font-weight:bold;">
        Process Request</h1></center>
    <asp:Button ID="Button3" runat="server" class="btn btn-success" style="z-index: 1; position: absolute; top: 10px; left: 963px"  Text="New Request" OnClick="Button3_Click" />
     <asp:Button ID="Button2" runat="server" class="btn btn-success" style="z-index: 1; position: absolute; top: 10px; left: 950px"  Text="Owe Request" OnClick="Button2_Click" />
    <table>
        <tr style="height: 100px;">
            <td>
                <asp:BulletedList ID="BulletedList1" runat="server" Font-Bold="True" ForeColor="Red" Style="z-index: 1; width: 246px; height: 93px; position: relative; top: 65px; left: 294px; margin-right: 113px">
                </asp:BulletedList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView CssClass="grid" ID="GridView1" runat="server" Style="z-index: 1; width: 969px; height: 127px; position: relative;" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField HeaderText="BIN" DataField="BIN" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                        <asp:BoundField HeaderText="Actualqty" DataField="Actualqty" />
                        <asp:BoundField HeaderText="RequisitionID" DataField="RequisitionID" />
                        <asp:BoundField HeaderText="DepartmentName" DataField="DepartmentName" />
                        <asp:BoundField HeaderText="deptneeded" DataField="deptneeded" />
                        <asp:TemplateField HeaderText="Allocated">
                            <ItemTemplate>
                                <asp:TextBox ID="Textfrom" runat="server" CssClass="txtBoxNormalmedium" Text=''></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator" runat="server"
                                    ErrorMessage='<%#"Min-0 Max-"+ Eval("deptneeded") %>' ControlToValidate="Textfrom"
                                    MaximumValue='<%# Eval("deptneeded") %>' MinimumValue="0" ForeColor="Red"
                                    Display="Dynamic" ClientIDMode="Predictable" Type="Double" ValidationGroup="vg" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="Textfrom" ErrorMessage="Value Required" ValidationGroup="vg"></asp:RequiredFieldValidator>
                                <%--             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" style="z-index: 1; width: 289px; height: 45px; position: absolute; top: 70px; left: 681px" ValidationGroup="vg" />
    <br />--%>
                            </ItemTemplate>


                        </asp:TemplateField>



                        <asp:BoundField HeaderText="Itemcode" DataField="Itemcode" />
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
        <asp:ScriptManager ID="scriptmanager" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="updateprogress" runat="server" AssociatedUpdatePanelID="updatepanel">
            <ProgressTemplate>
                <div class="div1" style="margin-left: 160px">
                    <asp:Image ID="image" ImageUrl="~/Images/Loading_icon.gif" AlternateText="processing" runat="server" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="updatepanel" runat="server">
            <ContentTemplate>

                <tr>
                    <td align="right">
                        <asp:Button ID="Button1" runat="server" class="btn btn-success" Style="z-index: 1; position: relative;" Text="Submit" OnClick="Button1_Click" ValidationGroup="vg" s />
                    </td>
                </tr>

            </ContentTemplate>

        </asp:UpdatePanel>
    </table>


    <center><h3><asp:Label ID="Label1" runat="server" style="z-index: 1; position: absolute; top: 90px; left: 326px; width: 206px; height: 37px;" Text="Label" Font-Italic="True" Font-Size="XX-Large" ForeColor="#333399"></asp:Label></h3>
    
    </center>
</asp:Content>

