<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Board.aspx.cs" Inherits="WebApplication1.Message_Board" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>留言板文档</title>
    <link href="../css/css.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery-3.0.0.min.js"></script>
    <script src="../js/ckeditor/ckeditor.js"></script>
    <script src="../js/Ajax.js"></script>
</head>

<body style="background-color: #FFF">

    <div id="head">
        <span style="font-size: 30px; margin-left: 50px;"><a style="font-weight: bold;" href="">桂林电子科技大科技有限公司</a></span>
        <span style="padding-right: 5%; float: right; padding-top: 10px;"><a style="font-weight: bold;" href="../GL_login.html">切换用户</a>|<a style="font-weight: bold;" href="register.html">注册</a></span>
    </div>
    <!--导航栏-->
    <div id="list">
        <ul>
            <a style="color: #FFF" href="">
                <li>网站首页</li>
            </a>
            <a style="color: #FFF" href="">
                <li>给我留言</li>
            </a>
            <a style="color: #FFF" href="">
                <li>产品介绍</li>
            </a>
            <a style="color: #FFF" href="">
                <li>科技展示</li>
            </a>
            <a style="color: #FFF" href="">
                <li>信息中心</li>
            </a>
            <a style="color: #FFF" href="">
                <li>关于我们</li>
            </a>
        </ul>
    </div>

    <!--主体-->
    <div id="main">
        <!--留言框-->
        <div class="bule">
            <span style="color: #FFF; margin-left: 5px;">当前用户：</span><span style="color: #FFF; font-weight: bold;"><%=user.Rows[0]["name"] %></span>
            <span style="margin-left: 10px;"><a href="../GL_login.html" style="color: #00C; text-decoration: underline">切换用户</a></span>
            <span style="float: right; color: #FFF; margin-right: 10px;">当前时间:<script type="text/javascript">document.write(Date())</script></span>
            <div id="listBox">
                <form action="../handler/Message_Board.ashx" method="post">
                    <textarea name="Msg" id="input_box"></textarea>
                    <input type="submit" class="grey" style="float:right" value="发表" />
                </form>
            </div>
        </div>
        <!--历史留言框 可多加可重复-->
        <% for (int i = 0; i < table.Rows.Count; i++)
           { %>
        <div class="bule">
            <div style="height: 48px;">
                <div style="float: left;" class="grey">
                    用户：<%=table.Rows[i]["Name"] %>
                </div>
                <div class="zan">
                    <span style="color: #FFF; float: right; padding-top: 10px; font-size: 25px;" id="<%=table.Rows[i]["ID"] %>"><%=table.Rows[i]["Approve"] %></span>
                    <img style="float: right;" src="../image/233.jpg" />
                </div>
            </div>

            <div class="auto">
                <%=table.Rows[i]["MessageContents"].ToString() %>
            </div>
            <div style="float: right;" class="grey">
                时间：<%=table.Rows[i]["DataTime"] %>
            </div>

            <script type="text/javascript">
                var input_box = document.getElementById("input_box");
                CKEDITOR.replace(input_box);
            </script>
        </div>
        <%} %>
    </div>
    <script>
        $(".zan").click(function () {

            var id = $(this).find("span")[0].id;
            var zan_now = $(this).find("span");

            Ajax("../handler/Message_approve.ashx?ID=" + id, function (resText) {
                zan_now[0].innerHTML = resText;
            })
            
        });
    </script>
</body>
</html>

