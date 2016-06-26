<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="use_to_change_my_information.aspx.cs" Inherits="WebApplication1.use_to_change_my_information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>修改信息</title>
    <meta name="author" content="DeathGhost" />
    <link rel="stylesheet" type="text/css" href="../css/style2.css" />
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
    <script type="text/javascript">
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
        
        //function land()
        //{
        //    var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest() : new ActiveXObject('Microsoft XMLHTTP');
        //    xmlhttp.open("POST", "Ajax_text.ashx?student_number=" + student_number.value + "&password=" + password.value, true);
        //    xmlhttp.onreadystatechange = function ()
        //    {
        //        if (xmlhttp.readyState == 4)
        //        {
        //            if (xmlhttp.status == 200) {
        //                alert(xmlhttp.responseText);
        //            }
        //            else
        //            {
        //                alert("Ajax服务返回错误！");
        //            }
        //        }
        //    }
        //    xmlhttp.send();
        //}ajax使用
    </script>
    <script type="text/javascript">
        function go() {
            Ajax("../handler/use_to_change_my_information.ashx?student_number=" + student_number.value + "&password=" + password.value + "&myname=" + myname.value + "&class_ID=" + class_ID.value + "&major=" + major.value + "&college=" + college.value + "&cookie=" + cookie.value + "&ID=<%=student_info.Rows[0]["ID"]%>", function (resText) {
                alert(resText);
                if (resText == "修改成功！") {
                    location.href = '../GL_login.html';
                }
            }
                )//ajax封装函数
            //alert("sdfsdffthfg");
        }
    </script>
</head>
<body>
    <%--<center>
    <form action="../handler/use_to_change_my_information.ashx?ID=<%=student_info.Rows[0]["ID"]%>" method="post">
name:           <br/>   <input type="text" name="name" value="<%=student_info.Rows[0]["name"] %>"/><br/>
class_ID:        <br/>  <input type="text" name="class_ID" value="<%=student_info.Rows[0]["class ID"] %>"/><br/>
student_number: <br/>   <input type="text" name="student_number"value="<%=student_info.Rows[0]["stdent_number"] %>"/><br/>
password:   <br/>       <input type="text" name="password"value="<%=student_info.Rows[0]["pass_word"] %>"/><br/>
major:        <br/>     <input type="text" name="major"value="<%=student_info.Rows[0]["major"] %>"/><br/>
college:      <br/>     <input type="text" name="college"value="<%=student_info.Rows[0]["college"] %>"/><br/>
cookie:    <br/>        <input type="text" name="cookie"value="<%=student_info.Rows[0]["cookie"] %>"/><br/>
    <input type="submit"value="修改"/>
     </form>
        </center>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>--%>
    <dl class="admin_login">
        <dt>
            <strong>请认真核对你要修改的信息</strong>
            <em>Management System</em>
        </dt>
        <dd class="user_icon">
            <input type="text" placeholder="姓名：<%=student_info.Rows[0]["name"] %>" id="myname" class="login_txtbx" />
        </dd>
        <dd class="pwd_icon">
            <input type="text" placeholder="班级：<%=student_info.Rows[0]["class ID"] %>" id="class_ID" class="login_txtbx" />
        </dd>
        <dd class="user_icon">
            <input type="text" placeholder="学号：<%=student_info.Rows[0]["stdent_number"] %>" id="student_number" class="login_txtbx" />
        </dd>
        <dd class="user_icon">
            <input type="password" placeholder="密码：<%=student_info.Rows[0]["pass_word"] %>" id="password" class="login_txtbx" />
        </dd>
        <dd class="user_icon">
            <input type="text" placeholder="专业：<%=student_info.Rows[0]["major"] %>" id="major" class="login_txtbx" />
        </dd>
        <dd class="user_icon">
            <input type="text" placeholder="学院：<%=student_info.Rows[0]["college"] %>" id="college" class="login_txtbx" />
        </dd>
        <dd class="user_icon">
            <input type="text" placeholder="Cookie：<%=student_info.Rows[0]["cookie"] %>" id="cookie" class="login_txtbx" />
        </dd>
        <dd class="val_icon">
            <div class="checkcode">
                <input type="text" id="J_codetext" placeholder="验证码" maxlength="4" class="login_txtbx"/>
                <canvas class="J_codeimg" id="myCanvas" onclick="createCode()">对不起，您的浏览器不支持canvas，请下载最新版浏览器!</canvas>
            </div>
            <input type="button" value="验证码核验" class="ver_btn" onclick="validate()"/>
        </dd>
        <dd>
           <input type="button" value="修改" class="submit_btn2" onclick="go()"/>
        </dd>
        <dd>
        </dd>
    </dl>
</body>
</html>
