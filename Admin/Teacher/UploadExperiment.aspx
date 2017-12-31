<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="UploadExperiment.aspx.cs" Inherits="Admin_UploadExperiment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>创建课程 - 上传实验 - HAERMS</title>
    <link href="../../Content/index.css" rel="stylesheet"/>
    <link href="../../Content/classes.css" rel="stylesheet"/>
    <link href="../../Content/teacher-style.css" rel="stylesheet"/>
    <link href="../../Content/form-controls.css" rel="stylesheet"/>
    <link href="../../Content/progressbar.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="progressbar-container progressbar-margin-top">
        <ul class="progressbar">
            <li>基本信息</li>
            <li>详细介绍</li>
            <li>时间安排</li>
            <li>上传课件</li>
            <li class="active">上传实验</li>
            <li>上传作业</li>
        </ul>
    </div>

    <form class="main-container create-class-main-container" runat="server">
        <div class="main-content card">
            <h2>课程实验</h2>
            <input id="CourseIds" type="hidden" value="<%= Request.QueryString["id"] ?? "0" %>">
            <hr>
            <div class="table-top-form">
                <button class="btn btn-info" type="button" onclick="addExperiment()">添加实验</button>
            </div>
            <div class="experiments" id="experiment-container" onclick="expandOrCollapseExp(event)">
                <div class="an-experiment">
                    <div class="title-box" id="title-box-ex-0">
                        <img src="../../Images/down_arrow.svg" id="img-ex-0">
                        <span class="experiment-name" id="experiment-name-ex-0">
                            <input title="实验名称" placeholder="实验名称" class="create-course-h4 input-style" id="ExperimentName0">
                        </span>
                        <span class="experiment-deadline" id="experiment-deadline-0">
                            截止时间：
                            <input title="作业截止时间" type="datetime-local" class="input-style" id="ExperimentDeadLine0">
                        </span>
                    </div>
                    <div class="experiment-detail" style="display:block">
                        <div class="experiment-purpose">
                            <h4>实验目的：</h4>
                            <hr>
                            <p>
                                <textarea title="实验目的" rows="5" class="input-style" id="ExperimentPurpose0"></textarea>
                            </p>
                        </div>
                        <div class="experiment-steps">
                            <h4>实验步骤：</h4>
                            <hr>
                            <div class="experiment-step">
                                <p>
                                    <textarea title="步骤内容" rows="5" placeholder="步骤详细内容" class="input-style" id="ExperimentSteps0"></textarea>
                                </p>
                            </div>
                        </div>
                        <div class="experiment-references">
                            <h4>参考资料：</h4>
                            <hr>
                            <div class="experiment-reference">
                                <p>
                                    <textarea title="资料" rows="5" placeholder="资料名称, URL" class="input-style" id="ExperimentReferences0"></textarea>
                                </p>
                            </div>
                        </div>
                    <button id="upExperiment0" class="btn btn-primary" type="button" onclick="Upload(this)">上传</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="button-group">
             &nbsp;&nbsp;&nbsp;<span id="warning" style="display:none"></span>
            <asp:button class="btn btn-warning" runat="server" text="跳过" OnClick ="StepOver" />
            <asp:button class="btn btn-success" runat="server" text="完成，下一步" OnClick="NextStep" />
        </div>
    </form>

    <script>

        function expandOrCollapseExp(event) {
            var experiment = document.getElementsByClassName('experiment-detail')[
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length))];
            var flagEx;
            if (experiment !== undefined) {
                flagEx = experiment.style.display === 'none';
                experiment.style.display = flagEx ? 'block' : 'none';
            } else {
                return;
            }
            var img = document.getElementById('img-ex-' +
                parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                    event.target.id.length)));
            if (img !== null) {
                img.src = flagEx ? '../../Images/down_arrow.svg' : '../../Images/up_arrow.svg';
            }
        }

        var experimentCounter = 0;

        function addExperiment() {
            experimentCounter++;
            var div = document.createElement("div");
            div.setAttribute("class", "an-experiment");
            div.innerHTML = "<div class=\"title-box\" id=\"title-box-ex-" +
                experimentCounter +
                "\">\n" +
                "                    <img src=\"../../Images/down_arrow.svg\" id=\"img-ex-" +
                experimentCounter +
                "\">\n" +
                "                    <span class=\"experiment-name\" id=\"experiment-name-ex-" +
                experimentCounter +
                "\">\n" +
                "                        <input title=\"实验名称\" placeholder=\"实验名称\" class=\"create-course-h4 input-style\" id='ExperimentName" + experimentCounter +"'>\n" +
                "                    </span>\n" +
                "                    <span class=\"experiment-deadline\" id=\"experiment-deadline-" +
                experimentCounter +
                "\">\n" +
                "                        截止时间：\n" +
                "                        <input title=\"作业截止时间\" type=\"datetime-local\" class=\"input-style\" id='ExperimentDeadLine" + experimentCounter +"'>\n" +
                "                    </span>\n" +
                "                </div>\n" +
                "                <div class=\"experiment-detail\">\n" +
                "                    <div class=\"experiment-purpose\">\n" +
                "                        <h4>实验目的：</h4>\n" +
                "                        <hr>\n" +
                "                        <p><textarea title=\"实验目的\" rows=\"5\" class=\"input-style\" id='ExperimentPurpose" + experimentCounter+"'></textarea></p>\n" +
                "                    </div>\n" +
                "                    <div class=\"experiment-steps\">\n" +
                "                        <h4>实验步骤：</h4>\n" +
                "                        <hr>\n" +
                "                        <div class=\"experiment-step\">\n" +
                "                            <p><textarea title=\"步骤内容\" rows=\"5\" placeholder=\"步骤详细内容\" class=\"input-style\" id='ExperimentSteps" + experimentCounter+"'></textarea></p>\n" +
                "                        </div>\n" +
                "                    </div>\n" +
                "                    <div class=\"experiment-references\">\n" +
                "                        <h4>参考资料：</h4>\n" +
                "                        <hr>\n" +
                "                        <div class=\"experiment-reference\">\n" +
                "                        <p><textarea title=\"资料\" rows=\"5\" placeholder=\"资料名称, URL\" class=\"input-style\" id='ExperimentReferences" + experimentCounter+"'></textarea></p>\n" +
                "                    </div>\n" +
                "                    </div>\n" +
                '<button id="upExperiment' + experimentCounter+'" class="btn btn-primary" type="button" onclick="Upload(this)">上传</button>'+
                "                </div>";
            document.getElementById("experiment-container").appendChild(div);
            document.getElementsByClassName('experiment-detail')[experimentCounter].style.display = 'block';
        }

        function getXMLHttpRequest() {
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                return new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
        }

        function Upload(obj) {
            var buttonId = obj.id;
            var CourseId = document.getElementById('CourseIds').value;
            var warn = document.getElementById('warning');
            //alert(CourseId)
            var num = parseInt(buttonId.substr(-1, 1));
           //开始组装数据 
            var ExperimentName = document.getElementById('ExperimentName' + num).value;
            var ExperimentDeadLine = document.getElementById('ExperimentDeadLine' + num).value;
            var ExperimentPurpose = document.getElementById('ExperimentPurpose' + num).value;
            var ExperimentSteps = document.getElementById('ExperimentSteps' + num).value;
            var ExperimentReferences = document.getElementById('ExperimentReferences' + num).value;
            if (ExperimentName == "" || ExperimentDeadLine == "" || ExperimentPurpose == "" || ExperimentSteps == "" || ExperimentReferences == "")
            {
                warn.innerHTML = "请填写完整";
                warn.style.display = "block";
                warn.style.color = "red";
            }

            var fd = new FormData();
            
            fd.append("ExperimentName", ExperimentName);
            fd.append("ExperimentDeadLine", ExperimentDeadLine);
            fd.append("ExperimentPurpose", ExperimentPurpose);
            fd.append("ExperimentSteps", ExperimentSteps);
            fd.append("ExperimentReferences", ExperimentReferences);
            fd.append("CourseId", CourseId);
            var xhr = getXMLHttpRequest();
            xhr.open("post", "UploadExperimentHandler.ashx", true);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4) {
                    if (xhr.status == 200) {
                        var rs = eval('(' + xhr.responseText + ')');
                        if (rs.status == 1) {
                            warn.style.display = "block";
                            warn.style.color = "green";
                            warn.innerHTML = rs.msg;
                            obj.disabled = "disabled";
                            obj.style = "background-color:#eee;"

                        }
                        else {
                            warn.innerHTML = rs.msg;
                            warn.style.display = "block";
                            warn.style.color = "red";
                        }
                    }
                    else {
                        warn.innerHTML = "上传失败";
                        warn.style.color = "red";
                    }
                }

            }
            xhr.send(fd);
        }

    </script>
</asp:Content>