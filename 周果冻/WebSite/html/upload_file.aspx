<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload_file.aspx.cs" Inherits="html_upload_file" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form enctype="multipart/form-data" method="POST" dir="ltr" lang="zh-cn" action="upload_file.aspx">
        <input type="file" name="upload" />
        <input type="submit" />
    </form>
</body>
</html>
