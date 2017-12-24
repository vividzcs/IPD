<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="EditCourseWare.aspx.cs" Inherits="Admin_Teacher_EditCourseWare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - 上传课件 - HAERMS</title>
    <link href="../../Content/index.css" rel="stylesheet" />
    <link href="../../Content/classes.css" rel="stylesheet" />
    <link href="../../Content/teacher-style.css" rel="stylesheet" />
    <link href="../../Content/form-controls.css" rel="stylesheet" />
    <link href="../../Content/progressbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="progressbar-container progressbar-margin-top">
        <ul class="progressbar">
            <li>基本信息</li>
            <li>详细介绍</li>
            <li>时间安排</li>
            <li class="active">上传课件</li>
            <li>上传实验</li>
            <li>上传作业</li>
        </ul>
    </div>

    <form class="main-container create-class-main-container" runat="server">
        <div class="main-content card">
            <h2>上传课件</h2>
           
            <input id="CourseIds" type="hidden" value="<%= Request.QueryString["id"] ?? "0" %>">
            <hr>
            <div class="table-top-form">
                <button class="btn btn-info" type="button" onclick="addCourseWare()">添加课件</button>
            </div>
            <table class="attachment-table clear" id="AttachmentTable" border="2">
                <tr>
                    <th>课件名称</th>
                    <th colspan="2">操作</th>
                </tr>
                <tr>
                    <td>
                        <div class="content-cell">
                            <input type="text"  title="课件名称" placeholder="不用输" class="input-style name1" disabled="disabled">
                        </div>
                    </td>
                    <td>
                        <div class="content-cell">
                            <input type="file" id="file1" class="btn btn-danger input-style" >
                        </div>

                    </td>
                    <td>
                        <div class="content-cell">
                            <button id="upfile1" class="btn btn-primary" type="button" onclick="Upload(this)">上传</button>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="button-group">
            &nbsp;&nbsp;&nbsp;<span id="warning" style="display:none"></span>
            <asp:button class="btn btn-warning" runat="server" text="跳过" OnClick ="StepOver" />
            <asp:button class="btn btn-success" runat="server" text="完成，下一步" OnClick="NextStep" />
        </div>
    </form>
    <script>
        var courseCounter = 1;
        function addCourseWare() {
            courseCounter++;
            var attachmentTable = document.getElementById("AttachmentTable");
            var tr = document.createElement("tr");

            var td1 = document.createElement("td");
            var div1 = document.createElement("div");
            var input1 = document.createElement("input");

            var td2 = document.createElement("td");
            var div2 = document.createElement("div");
            var input2 = document.createElement("input");

            var td3 = document.createElement("td");
            var div3 = document.createElement("div");
            var btn = document.createElement("button");

            div1.setAttribute("class", "content-cell");
            div2.setAttribute("class", "content-cell");
            div3.setAttribute("class", "content-cell");

            input1.setAttribute("type", "text");
            input1.setAttribute("title", "课件名称");
            input1.setAttribute("placeholder", "不用输");
            input1.setAttribute("class", "input-style name" + courseCounter);
            input1.setAttribute("disabled","disabled");
            input2.setAttribute("type", "file");
            input2.setAttribute("class", "btn btn-danger input-style");
            input2.setAttribute("id", "file" + courseCounter);
            btn.setAttribute("class", "btn btn-primary");
            btn.setAttribute("type", "button");
            btn.innerText = "上传";
            btn.setAttribute("onclick", "Upload(this)");
            btn.setAttribute("id", "upfile" + courseCounter);

            div1.appendChild(input1);
            td1.appendChild(div1);

            div2.appendChild(input2);
            td2.appendChild(div2);

            div3.appendChild(btn);
            td3.appendChild(div3);

            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);
            attachmentTable.appendChild(tr);
        }

        function getXMLHttpRequest()
        {
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                return new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
        }

        function Upload(obj)
        {
            var buttonId = obj.id;
            var CourseId = document.getElementById('CourseIds').value;
            //alert(CourseId)
            var warn = document.getElementById('warning');
            var num = parseInt(buttonId.substr(-1, 1));
            var fileName = document.getElementsByClassName("name" + num)[0];
            
            //console.log(fileName,num-1);
            var fd = new FormData(); //创建一个空的FormData
            var fileId = "file" + num;
            var fm = document.getElementById(fileId).files[0];
            
            fd.append("file", fm); //将文件加到fd里面
            fd.append("CourseId", CourseId);
            var xhr = getXMLHttpRequest();
            xhr.open("post", "CourseWareUploadHandler.ashx", true);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4)
                {
                    if (xhr.status == 200)
                    {
                        var rs = eval('(' + xhr.responseText + ')');
                        if (rs.status == 1)
                        {
                            warn.style.display = "block";
                            warn.style.color = "green";
                            warn.innerHTML = "上传成功!";
                            fileName.value = rs.msg;
                            console.log(rs.msg);
                            fileName.style.backgroundColor = "rgba(0,255,0,0.5)";
                            obj.disabled = "disabled";
                            obj.style = "background-color:#eee;"
                            
                        }
                        else
                        {
                            fileName.value = rs.msg;
                            fileName.style.backgroundColor = "rgba(255,0,0,0.5)";
                            warn.innerHTML = rs.msg;
                            warn.style.display = "block";
                            warn.style.color = "red";
                        }
                    }
                    else {
                        fileName.value = "上传失败";
                        fileName.style.backgroundColor = "rgba(255,0,0,0.5)";
                        warn.innerHTML = "上传失败";
                        warn.style.color = "red";
                    }
                }
                
            }
            xhr.send(fd);
        }
        </script>
</asp:Content>


