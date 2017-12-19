<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ManageTeacher.aspx.cs" Inherits="Admin_ManageTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>管理教师 - HAERMS</title>
    <link href="../../Content/SenateList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
        <div>
        <div class="teacher">
        <div class="choose">
             <a href="javascript:" style="color:blue">教师列表</a>
             <a href="../ManageDepartment.aspx">院系列表</a>
        </div> 
            <asp:GridView runat="server" DataSourceID="ObjectDataSourceGetAllTeachers" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="姓名" />
                    <asp:BoundField DataField="JobNumber" HeaderText="工号" />
                    <asp:TemplateField HeaderText="院系">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownListDepart" runat="server" DataSourceID="ObjectDataSourceDepartments" DataTextField="ChinesaeName" DataValueField="DepartmentId" />

                            <asp:ObjectDataSource runat="server" ID="ObjectDataSourceDepartments" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Impl.DepartmentServiceImpl"></asp:ObjectDataSource>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Introduction" HeaderText="简介" />
                    <asp:ButtonField ButtonType="Button" CommandName="Update" Text="冻结" />
                </Columns>
            </asp:GridView>

            <asp:ObjectDataSource runat="server" ID="ObjectDataSourceGetAllTeachers" UpdateMethod="FreezeTeacher" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Impl.TeacherServiceImpl" DataObjectTypeName="Models.Teacher">
              
            </asp:ObjectDataSource>
            <input type="button" class="button_delete" value="删除">
            <input type="button" class="button_delete" value="提交">
            <input type="button" class="button_create" value="新建">
        </div>
    </div>
        </form>
    <script src="../../Scripts/Senate.js"></script>
    <script src="../../Scripts/SenateObject.js"></script>
</asp:Content>

