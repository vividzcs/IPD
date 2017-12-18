<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="Class_UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/form-controls.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload runat="server" class="btn btn-info" ID="Uploader" accept="application/msword,application/vnd.openxmlformats-officedocument.wordprocessingml.document,application/msexcel,application/pdf,application/rtf,application/x-zip-compressed"/>
            <asp:Button runat="server" Text="上传" CssClass="btn btn-primary" OnClick="FileUpload" />
        </div>
    </form>
</body>
</html>
