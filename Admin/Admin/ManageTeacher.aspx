<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ManageTeacher.aspx.cs" Inherits="Admin_ManageTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>管理教师 - HAERMS</title>
    <link href="/Content/managedepart.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
        <div>
        <div class="teacher">
        <div class="choose">
             <a href="javascript:" style="color:blue">教师列表</a>
             <a href="/Admin/Admin/ManageDepartment.aspx">院系列表</a>
        </div> 
            <asp:GridView ID="GridViewTeacher" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="GridViewTeacher_RowEditing" OnRowCancelingEdit="GridViewTeacher_RowCancelingEdit" OnRowCommand="GridViewTeacher_RowCommand">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="姓名"></asp:BoundField>
                    <asp:TemplateField HeaderText="院系">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="dropdownListDepartment" DataSourceID="ObjectDataSourceDepartment"></asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSourceDepartment"></asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label1" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="简介">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("Introduction") %>' ID="TextBox2"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Introduction") %>' ID="Label2"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="工号">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("JobNumber") %>' ID="TextBox3"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("JobNumber") %>' ID="Label3"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbUpdate" CommandArgument='<%# Eval("DepartmentId") %>' CommandName="UpdateRow" ForeColor="#8C4510" runat="server">更新</asp:LinkButton>
                            <asp:LinkButton ID="lbCancel" CommandArgument='<%# Eval("DepartmentId") %>' CommandName="CancelUpdate" ForeColor="#8C4510" runat="server" CausesValidation="false">取消</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TeacherId")%>'  CommandName="edit" Text="编辑"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonFreeze" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TeacherId")%>'  CommandName="freeze" Text="冻结"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonReset" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TeacherId")%>' CommandName="reset" Text="重置"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
        </form>
    <script src="/Scripts/Senate.js"></script>
    <script src="/Scripts/SenateObject.js"></script>
</asp:Content>

