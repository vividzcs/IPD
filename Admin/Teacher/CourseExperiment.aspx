﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CourseExperiment.aspx.cs" Inherits="Admin_CourseExperiment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>课程实验 - HAERMS</title>
    <link href="../Content/index.css" rel="stylesheet"/>
    <link href="../Content/classes.css" rel="stylesheet"/>
    <link href="../Content/form-controls.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="">
    <nav class="sidebar">
        <div class="card">
            <img src="../../style/images/course-main_image.png" class="image-item"/>
        </div>
        <ul class="list-class card">
            <li class="list-class-item">
                <a href="#">简介</a>
            </li>
            <li class="list-class-item">
                <a href="#">课件</a>
            </li>
            <li class="list-class-item selected-class-item">
                <a href="#">实验</a>
            </li>
            <li class="list-class-item">
                <a href="#">作业</a>
            </li>
        </ul>
    </nav>
    <div class="main-container">
        <div class="main-content card">
            <h2>课程实验列表</h2>
            <hr>
            <div class="experiments" onclick="expandOrCollapse(event)">
                <div class="an-experiment">
                    <div class="title-box" id="title-box-0">
                        <img src="../../style/images/down_arrow.svg" id="img-0">
                        <span class="experiment-name" id="experiment-name-0">实验一：使用Wireshark操作TCP的三次握手</span>
                        <span class="experiment-deadline" id="experiment-deadline-0">截止时间：2017年12月21日</span>
                        <!-- 下载报告 -->
                        <div class="experiment-operation" id="btn-0">
                            <button type="button" class="btn btn-info">打包下载</button>
                            <button type="button" class="btn btn-info"><a href="#">单独查看</a></button>
                        </div>
                        <!-- 下载报告-->
                    </div>
                    <div class="experiment-detail">
                        <div class="experiment-purpose">
                            <h4>实验目的：</h4>
                            <hr>
                            <p>1. 了解Tcp的数据组成部分</p>
                            <p>2. 理解Tcp三次握手的基本原理</p>
                            <p>3. 用Wireshark抓包来进一步理解Tcp的三次握手原理</p>
                        </div>
                        <div class="experiment-steps">
                            <h4>实验步骤：</h4>
                            <hr>
                            <div class="experiment-step">
                                <h5>1. Tcp的数据组成部分，并结合抓包数据进行分析对应。</h5>
                                <p>源端口和目的端口字段——各占2字节。端口是传输层与应用层的服务接口。传输层的复用和分用功能都要通过端口才能实现。</p>
                                <p>序号字段——占4字节。TCP连接中传送的数据流中的每一个字节都编上一个序号。序号字段的值则指的是本报文段所发送的数据的第一个字节的序号。</p>
                                <p>
                                    确认号字段——占4字节，是期望收到对方的下一个报文段的数据的第一个字节的序号。它和IP数据包头部一样，也有个Options字段，长度是不固定的，而为了要确认整个TCP封包大小，就需要这个标志来说明整个封包区段的起始位置。</p>
                                <p>数据偏移——占4bit，它指出TCP报文段的数据起始处距离 CP报文段的起始处有多远。“数据偏移”的单位不是字节而是32bit字（4字节为计算单位）。</p>
                            </div>
                            <div class="experiment-step">
                                <h5>2.三次握手的过程</h5>
                                <p>第一次握手：建立连接时，客户端发送syn包(syn=j)到服务器，并进入SYN_SEND状态，等待服务器确认；</p>
                                <p>
                                    第二次握手：服务器收到syn包，必须确认客户的SYN（ack=j+1），同时自己也发送一个SYN包（syn=k），即SYN+ACK包，此时服务器进入SYN_RECV状态；</p>
                                <p>
                                    第三次握手：客户端收到服务器的SYN＋ACK包，向服务器发送确认包ACK(ack=k+1)，此包发送完毕，客户端和服务器进入ESTABLISHED状态，完成三次握手。</p>
                                <p>完成三次握手，客户端与服务器开始传送数据。</p>
                            </div>
                            <div class="experiment-step">
                                <h5>3. 分析每一次的握手过程：</h5>
                                <p>在第一次握手中：Seq=0， Ack=1，Win=14600 Len=0 MSS=1488 SACK_PERM=1;</p>
                                <p>在第二次握手中：Seq=1，ACK=466,Win=15744,Len=0;</p>
                                <p>在第三次握手中：Seq=466，ACK=7241,Win=261848,Len=0;</p>
                            </div>

                        </div>
                        <div class="experiment-references">
                            <h4>参考资料：</h4>
                            <hr>
                            <div class="experiment-reference">
                                <span>w3school: </span><a
                                    href="http://www.w3school.com.cn">http://www.w3school.com.cn</a><br>
                            </div>
                            <div class="experiment-reference">
                                <span>w3school: </span><a
                                    href="http://www.w3school.com.cn">http://www.w3school.com.cn</a><br>
                            </div>
                            <div class="experiment-reference">
                                <span>w3school: </span><a
                                    href="http://www.w3school.com.cn">http://www.w3school.com.cn</a><br>
                            </div>
                            <div class="experiment-reference">
                                <span>w3school: </span><a
                                    href="http://www.w3school.com.cn">http://www.w3school.com.cn</a><br>
                            </div>
                            <div class="experiment-reference">
                                <span>附FDP: </span><a
                                    href="http://www.w3school.com.cn/a.pdf">http://www.w3school.com.cn/a.pdf</a><br>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    (function init() {
        var allExpDet = document.getElementsByClassName('experiment-detail');
        for (var exp in allExpDet) {
            allExpDet[exp].style.display = 'none'
        }
    })();

    function expandOrCollapse(event) {
        var experiment = document.getElementsByClassName('experiment-detail')[
            parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
                event.target.id.length))];
        var flagEx = experiment.style.display === 'none';
        if (experiment !== undefined) {
            experiment.style.display = flagEx ? 'block' : 'none';
        }
        var img = document.getElementById('img-' + parseInt(event.target.id.substr(event.target.id.lastIndexOf('-') + 1,
            event.target.id.length)));
        if (img !== null) {
            img.src = flagEx ? '../../style/images/up_arrow.svg' : '../../style/images/down_arrow.svg';
        }
    }
</script>
</asp:Content>

