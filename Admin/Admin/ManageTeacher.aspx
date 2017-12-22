<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ManageTeacher.aspx.cs" Inherits="Admin_ManageTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>管理教师 - HAERMS</title>
    <link href="/Content/form-controls.css" rel="stylesheet"/>
    <link href="/Content/managedepart.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
        <div>
        <div class="teacher">
            <div class="nav">
                <ul>
                    <li>
                        <a href="ManageDepartment.aspx" style="color:black">院系列表</a>
                    </li>
                    <li>
                        <a href="javascript:" style="color:blue">教师列表</a>
                    </li>
                </ul>
            </div>
            <asp:GridView ID="GridViewTeacher" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="true" OnPageIndexChanging="GridViewTeacher_PageIndexChanging"  OnRowEditing="GridViewTeacher_RowEditing" OnRowCancelingEdit="GridViewTeacher_RowCancelingEdit" OnRowCommand="GridViewTeacher_RowCommand" OnRowDataBound="GridViewTeacher_RowDataBound">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>
                    <asp:TemplateField HeaderText="姓名">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("Name") %>' ID="TextBoxName"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Name") %>' ID="LabelName"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="院系">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="dropdownListDepartment" AutoPostBack="True"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label1" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="简介">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("Introduction") %>' ID="TextBoxIntroduction" TextMode="multiline" Columns="40" Rows="4"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="block-with-text longtext">
                                <asp:Label runat="server" Text='<%# Bind("Introduction") %>' ID="LabelIntroduction" TextMode="multiline" Columns="40" Rows="4"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="工号">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("JobNumber") %>' ID="TextBoxJobNumber"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("JobNumber") %>' ID="LabelJobNumber"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbUpdate" CommandArgument='<%# Eval("TeacherId") %>' CommandName="UpdateRow" ForeColor="#8C4510" runat="server">更新</asp:LinkButton>
                            <asp:LinkButton ID="lbCancel" CommandArgument='<%# Eval("TeacherId") %>' CommandName="CancelUpdate" ForeColor="#8C4510" runat="server" CausesValidation="false">取消</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TeacherId")%>' ForeColor="#8C4510"   CommandName="edit" Text="编辑"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonFreeze" CssClass="freeze" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TeacherId")%>' ForeColor="#8C4510"   CommandName="freeze" Text="冻结"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonReset" CssClass="reset" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TeacherId")%>' ForeColor="#8C4510"  CommandName="reset" Text="重置"></asp:LinkButton>
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
             <a class=" center btn btn-primary" href="CreateTeacher.aspx" style="width:100px; text-align:center">新建</a>
        </div>
    </div>
        </form>
</asp:Content>

