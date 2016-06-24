<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_success.aspx.cs" Inherits="login.html.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/style.css" type="text/css" rel="stylesheet"/>
    <title></title>
    <script>
        function admin() {
            window.location.href = "Admin.aspx";
        }
    </script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js">
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input#Msg_btn").click(function () {
                window.location.href = "../html/MessageBoard.aspx";
            });
        });
</script>
    <%--<script src="../js/ajax.js"></script>
    <script type="text/javascript">
        function check() {
            ajax("../handler/admin_ajax.ashx", function (resText) {
                if (resText == "right") {
                    window.location.href = "admin.aspx";
                }
                else if (resText == "error") {
                    alert("您不是管理员！");
                }
                else if (resText == "unknow_error") {
                    alert("未知错误！");
                }
                else {
                    alert("一般处理程序出错！");
                }
            });
        }
    </script>--%>
</head>
<body>
    <div id="listBox"><center>
        <div id="Container">
            <table id="table_left" style="margin: 25px; float: none;">
                <tbody>
                    <tr>
                        <th style="width: 100px">帐号：</th>
                        <td><%=table.Rows[0]["ID"].ToString() %></td>
                    </tr>
                    <tr>
                        <th style="width: 100px">姓名：</th>
                        <td><%=table.Rows[0]["Name"].ToString() %></td>
                    </tr>
                    <tr>
                        <th style="width: 100px">性别：</th>
                        <td><%=table.Rows[0]["Gender"].ToString() %></td>
                    </tr>
                    <tr>
                        <th style="width: 100px">专业：</th>
                        <td><%=table.Rows[0]["Major"].ToString() %></td>
                    </tr>
                </tbody>
            </table>
            <div style="clear: both;"></div>
        </div>
        </center>
        <div id="inputBox">
            <input type="button" name="btnLeft" value="返回登录" onclick="window.location.href = '../html/Login.html';"/>
            <input type="button" name="btnLeft" id="Msg_btn" value="留言板" <%--onclick="window.location.href = '../html/MessageBoard.aspx'"--%>/><br />
            <a href="Files.aspx"><input type="button" name="btnLeft" value="下载文件" /></a>
            <%=admin_btn %>
           <%-- <input type="button" name="btnLeft" value="启用管理员身份" onclick="check()"/>--%>
        </div>
    </div>
</body>
</html>
