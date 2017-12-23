<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelImport.aspx.cs" Inherits="Admin_Teacher_ExcelImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>上传Excel学生名单 - HAERMS</title>
    <link href="../../Content/form-controls.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload runat="server" class="btn btn-info" ID="Uploader" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet,application/vnd.ms-excel"/>
            <asp:Button runat="server" Text="上传" CssClass="btn btn-primary" OnClick="ExcelUpload" />
        </div>
    </form>
</body>
</html>
