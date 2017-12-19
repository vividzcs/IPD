<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ManageDepartment.aspx.cs" Inherits="Admin_ManageDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
    <link href="../Content/SenateList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="school">
        <div class="choose">
             <a href="./Admin/ManageTeacher.aspx">教师列表</a>
             <a href="javascript:" style="color:blue">院系列表</a>
        </div> 
        <table>
            <tr>
                <td>编号</td>
                <td>名称</td>
                <td></td>
            </tr>
        </table>
        <input type="button" class="button_delete" value="删除">
        <input type="button" class="button_submit" value="提交">
        <input type="button" class="button_create" value="新建">
    </div>
    <script src="../Scripts/SenateObject.js"></script>
    <script src="../Scripts/Senate.js"></script>
</asp:Content>

