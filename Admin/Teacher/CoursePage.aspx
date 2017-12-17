﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontSite.master" AutoEventWireup="true" CodeFile="CoursePage.aspx.cs" Inherits="Admin_CoursePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>课程首页 - HAERMS</title>
    <link href="../../Content/index.css" rel="stylesheet" />
    <link href="../../Content/classes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="">
    <nav class="sidebar">
        <div class="card">
            <img src="../../Images/course-main_image.png" class="image-item"/>
        </div>
        <ul class="list-class card">
            <li class="list-class-item selected-class-item">
                <a href="#">简介</a>
            </li>
            <li class="list-class-item">
                <a href="#">课件</a>
            </li>
            <li class="list-class-item">
                <a href="#">实验</a>
            </li>
            <li class="list-class-item">
                <a href="#">作业</a>
            </li>
        </ul>
    </nav>
    <div class="main-container">
        <div class="main-content card">
            <h2>计算机网络</h2>
            <h5 class="teacher">陈晓江/肖云</h5>
            <hr>
            <div class="paragraphs">
                <p>
                    你想理解计算机网络吗？你想了解如何开发网络应用程序吗？你想深入探究计算机网络深层奥秘吗？你知道虚拟的网络世界危机四伏吗？
                    ……那么这门课程是你最佳选择！《计算机网络》课将带你认识计算机网络、了解网络应用程序开发技术、探索计算机网络深层机理、
                    了解计算机网络安全威胁及其防护技术等内容。
                </p>
            </div>
        </div>
        <div class="main-content card">
            <h2>课程概述</h2>
            <hr>
            <div class="paragraphs">
                <p>《计算机网络》课程分为三个单元：“计算机网络之网尽其用”、“计算机网络之探赜索隐”和“计算机网络之危机四伏”。</p>
                <p>
                    “计算机网络之网尽其用”将带你快速了解、认识计算机网络，理解并掌握计算机网络与网络协议等基本概念、网络组成与网络体系结构，剖析你每天都在使用的网络应用的类型、运行原理以及应用层协议，帮助你理解绝大多数网络应用所采用的应用编程接口-套接字（Socket），学习并掌握Socket编程技术，具备开发简单网络应用的能力。</p>
                <p>
                    “计算机网络之探赜索隐”将带你深入计算机网络内部，探究计算机网络深层奥秘，了解并掌握计算机网络深层次的原理、协议及网络技术，让你不仅知其然而且知其所以然，真正成为计算机网络的行家里手。这部分主要讲授：可靠数据传输基本原理、停-等协议与滑动窗口协议、典型传输层协议（UDP与TCP）、虚电路网络与数据报网络、路由与转发、IP协议与IP地址、CIDR、子网划分与路由聚集、ICMP协议、DHCP协议、NAT、IPv6、路由算法、路由协议、差错编码、MAC协议、ARP协议、以太网、VLAN、PPP协议、无线局域网等。</p>
                <p>
                    “计算机网络之危机四伏”将带你一起认识网络安全威胁，理解并掌握保障网络安全的基本原理、网络协议以及技术措施，让你认识到如何在享受网络带给你诸多便利的同时尽可能避免令自身处于重重危机之中。这部分主要讲授：网络安全基本概念；网络安全威胁；密码学基础；信息完整性与数字签名；身份认证；安全电子邮件；SSL；IPsec与VPN；无线网局域网安全；防火墙；入侵检测等。</p>
            </div>
        </div>
        <div class="main-content card">
            <h2>授课教师</h2>
            <hr>
            <img class="teacher-image" src="../../Images/1444660450180.jpg"/>
            <div class="teacher-info">
                <span class="">围绕过程管理展开应用基础理论、软件度量、软件开发方法学的研究</span>
                <br>
                <span class="teacher-position">教授/硕士生导师</span>
            </div>
        </div>
        <div class="main-content card">
            <h2>课程时间</h2>
            <hr>
            <table class="class-hour-table" border="2">
                <tr>
                    <td class="table-head">开课时间</td>
                    <td>2017年9月1日 - 2018年1月10日</td>
                </tr>
                <tr>
                    <td class="table-head">课时安排</td>
                    <td>理论72课时 + 实验36课时</td>
                </tr>
            </table>
        </div>
    </div>
</div>
</asp:Content>

