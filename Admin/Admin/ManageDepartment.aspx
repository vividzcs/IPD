<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ManageDepartment.aspx.cs" Inherits="Admin_ManageDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    <link href="/Content/form-controls.css" rel="stylesheet"/>
    <link href="/Content/managedepart.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="school">
        <div class="choose">
            <a href="/Admin/Admin/ManageTeacher.aspx">教师列表</a>
            <a href="javascript:" style="color: blue">院系列表</a>
        </div>
        <form runat="server">
            <asp:GridView runat="server" ID="GridViewDepartments" AutoGenerateColumns="False"
                          OnRowCommand="GridViewDepartments_OnRowCommand"
                          CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True">
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField HeaderText="院系编号">

                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("DepartmentId") %>' ID="LabelDepartmentId"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="院系名称">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("ChinesaeName") %>' ID="TextBoxChineseName"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("ChinesaeName") %>' ID="LabelChineseName"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="英文名">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("EnglishName") %>' ID="TextBoxEnglishName"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("EnglishName") %>' ID="LabelEnglishName"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--                    <asp:ImageField DataImageUrlField="Image" HeaderText="图片" ControlStyle-Height="100px" NullImageUrl="~/Images/logo.png"></asp:ImageField>--%>

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
                    <asp:TemplateField HeaderText="操作">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbUpdate" CommandArgument='<%# Eval("DepartmentId") %>' CommandName="UpdateRow" ForeColor="#8C4510" runat="server">更新</asp:LinkButton>
                            <asp:LinkButton ID="lbCancel" CommandArgument='<%# Eval("DepartmentId") %>' CommandName="CancelUpdate" ForeColor="#8C4510" runat="server" CausesValidation="false">取消</asp:LinkButton>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEdit" CommandArgument='<%# Eval("DepartmentId") %>' CommandName="EditRow" ForeColor="#8C4510" runat="server">编辑</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#EFF3FB"></RowStyle>

                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
            </asp:GridView>
            <a class=" center btn btn-primary" href="CreateDepartment.aspx" style="width:100px; text-align:center">新建</a>
        </form>
    </div>
</asp:Content>