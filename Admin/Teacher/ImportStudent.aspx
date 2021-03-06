﻿<%@ Page Title="" codepage=65001 Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="ImportStudent.aspx.cs" Inherits="ImportStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>导入学生 - HAERMS</title>
    <link href="../../Content/form.css" rel="stylesheet" />
    <link href="../../Content/index.css" rel="stylesheet" />
    <link href="../../Content/importstu.css" rel="stylesheet" />
    <script src="../../Scripts/importstu.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
        <div class="container">
            <div class="block2">
                <form class="" method="post" onsubmit="return checknulldata()" runat="server">
                    <table border="1">
                        <tbody id="stutable">
                        <tr id="table_head">
                            <th>姓名</th>
                            <th>学号</th>
                            <th>班级</th>
                        </tr>
                        </tbody>
                    </table>
                    <div class="controltable">
                        <button type="button" name="button" class="btn btn-primary" onclick="createnewrow()">创建新行</button>
                        <button type="button" name="button" class="btn btn-danger" onclick="deleteblankrow()">删除空行</button>
                        <button type="submit" class="btn btn-success" runat="server" onserverclick="import_ServerClick">提交信息</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
