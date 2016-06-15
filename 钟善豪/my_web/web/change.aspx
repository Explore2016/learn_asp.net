<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change.aspx.cs" Inherits="my_web.change" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <body>       
    <meta charset="utf-8" />
    <title>后台登录</title>
    <meta name="author" content="DeathGhost" />
   <!-- <link rel="stylesheet" type="text/css" href="style2.css" />-->
    <link href="../css/style2.css" type="text/css" rel="stylesheet">
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
    <script src="../js/jquery1.js"></script>
    <script src="../js/verificationNumbers.js"></script>
    <script src="../js/Particleground.js"></script>
    <script type="text/javascript" src="../js/ajax.js"></script>
<script type="text/javascript">
    function button()
    {
        ajax("../ashx/change.ashx?id=" + Id.value + "&keys=" + Key_1.value+ "&name=" + Name.value + "&sex=" + Sex.value + "&age=" + Age.value, function (resText) {
            alert(resText);
            if (resText == "修改成功!")
            {
                location.href = 'my_info.aspx';
            }
        }
            )//ajax封装函数
    }
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
            //location.href = "index.html";
        });
    });
    </script>
</head>
    <dl class="admin_login">
        <dt>
            <strong>这是一个很漂亮的登陆页面</strong>
            <em>Management System</em>
        </dt>      
        <dd class="user_icon">
            <input type="text" placeholder="用户名" class="login_txtbx" id="Id" name="id" value="<%=dt.Rows[0]["id"]%>" />
        </dd>
        <dd class="pwd_icon">
            <input type="text" placeholder="密码" class="login_txtbx" id="Key_1" name="key" value="<%=dt.Rows[0]["keys"]%>"/>
        </dd>
        <dd class="pwd_icon">
            <input type="text" placeholder="姓名" class="login_txtbx" id="Name" name="name" value="<%=dt.Rows[0]["name"]%>"/>
        </dd>
        <dd class="pwd_icon">
            <input type="text" placeholder="性别" class="login_txtbx" id="Sex" name="sex" value="<%=dt.Rows[0]["sex"]%>"/>
        </dd>
        <dd class="pwd_icon">
            <input type="text" placeholder="年龄" class="login_txtbx" id="Age" name="age" value="<%=dt.Rows[0]["age"]%>"/>
            </dd>
        <dd class="pwd_icon">
             <input type="button"  onclick="button()"value="修改" class="submit_btn" />
     </dd>
    </dl>
    
</>
</html>
