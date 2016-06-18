<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="废弃.aspx.cs" Inherits="WebApplication1.Up_load" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>文件上传</title>
    <meta name="author" content="DeathGhost" />
    <link rel="stylesheet" type="text/css" href="../style2.css" />
    <style>
        body {
            height: 100%;
            background: #16a085;
            overflow: hidden;
        }

        canvas {
            z-index: -1;
            position: absolute;
        }
    </style>
    <script src="../js/Ajax.js"></script>
    <script src="../js/jquery1.js"></script>
    <script src="../js/verificationNumbers.js"></script>
    <script src="../js/Particleground.js"></script>
    <script>
        $(document).ready(function () {
            //粒子背景特效
            $('body').particleground({
                dotColor: '#5cbdaa',
                lineColor: '#5cbdaa'
            });
            //验证码
            createCode();
            //测试提交，对接程序删除即可
            $(".submit_btn").click(function () {
                location.href = "index.html";
            });
        });
    </script>
</head>
<body>
   <%-- <form enctype="multipart/form-data" method="post" dir="ltr" lang="zh-cn" action="Up_load.aspx">
        <input type="file" name="upload" />
        <input type="submit" />
    </form>--%>
     <dl class="admin_login">
        <dt>
            <strong>欢迎，这是管理员才能使用的文件上传</strong>
            <em>Management System</em>
        </dt>
        <dd class="user_icon">
            <input type="file" name="upload" />
        </dd>
         <dd>
            <input type="button" value="上传文件" class="submit_btn2" onclick="button_file()"/>
        </dd>
        <dd>
        </dd>
    </dl>
</body>
</html>
