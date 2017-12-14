<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogOff.aspx.cs" Inherits="LogOff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<% Session.Remove("user");
   Response.Redirect("Default.aspx"); %>
</body>
</html>