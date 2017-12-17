<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ManageTeacher.aspx.cs" Inherits="Admin_ManageTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>管理教师 - HAERMS</title>
    <link href="../Content/SenateList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div class="teacher">
            <table>
                <tr class="tr_head">
                    <td>姓名</td>
                    <td>工号</td>
                    <td>院系</td>
                    <td>简介</td>
                    <td class="tr_head"></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <input type="button" class="button_delete" value="删除">
            <input type="button" class="button_submit" value="提交">
            <input type="button" class="button_create" value="新建">
        </div>
    </div>
    <script src="../Scripts/Senate.js"></script>
    <script src="../Scripts/SenateObject.js"></script>
</asp:Content>

