<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>主页 - HAERMS</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
        <div class="container">
            <asp:Repeater runat="server" DataSourceID="allDepartment">
                <ItemTemplate>
                    <div class="block">
                        <div class="photo">
                            <img src=<%#Eval("Image") %> alt="x">
                            <a href="/Teacher/TeacherList.aspx?did=<%#Eval("DepartmentId") %>">点击查看</a>
                        </div>
                        <div class="info">
                            <h2 class="title"><%#Eval("ChinesaeName") %></h2>
                            <span class="english-name"><%#Eval("EnglishName") %></span>
                            <span class="school-intro"><%#Eval("Introduction")%></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="allDepartment" runat="server" SelectMethod="GetAll"
                                  TypeName="BusinessLogicLayer.Impl.DepartmentServiceImpl">
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>