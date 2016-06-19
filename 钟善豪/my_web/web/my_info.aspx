<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_info.aspx.cs" Inherits="my_web.my_info2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
       <div id="listBox">
        <div id="inputBox">
            <a href="login.html"><input type="button" name="btnLeft" value="返回登录" onclick="next(--week)"/></a>
             <a href="file.aspx"><input type="button" name="btnRight" value="上传文件" onclick="next(++week)"/></a>
        </div>
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;">
                <tbody><tr>
                    <%--<th class="t1">序号</th>--%>
                    <th class="t2">用户</th>
                    <th class="t3">姓名</th>
                    <th class="t3">性别</th>
                    <th class="t3">年龄</th>
                    <th class="t2">删除</th>
                    <th class="t2">编辑</th>
                    <th class="t2">留言</th>
                </tr>              
                <tr>
                    <td style="background:none;"></td>
                    <td style="background:none;"></td>
                    <td style="background:none;"></td>
                    <td style="background:none;"></td>
                    <td style="background:none;"></td>
                    <td style="background:none;"></td>
                </tr>      
                      <% for (int j = 0; j < da.Rows.Count; j++){%>
                <tr>
                <td><%=da.Rows[j]["id"].ToString() %></td>
                <td><%=da.Rows[j]["name"].ToString() %></td>
                <td><%=da.Rows[j]["sex"].ToString() %></td>
                <td><%=da.Rows[j]["age"].ToString() %></td>                           
                <th><a href="../ashx/delete.ashx?id=<%=da.Rows[j]["id"] %>"> <input type="button" name="btnLeft" value="删除" onclick=""/></a>
                <th><a href="change.aspx?id=<%=da.Rows[j]["id"] %>"> <input type="button" name="btnLeft" value="编辑" onclick=""/></a>    
                 <th><a href="message board.aspx?id=<%=da.Rows[j]["id"] %>"> <input type="button" name="btnLeft" value="留言" onclick=""/></a>             
            </tr> <%} %>
            </tbody></table>
           <div style="clear:both;"></div>  
        </div>
    </div>
    <script>
        var week = 0;
        function next(week) {
            $.ajax({
                url: '../handler/info.ashx?info=All&week=' + week,
                type: 'post',
                success: function (re) {
                    table_left.innerHTML = re;
                }
            })
        }
        next(week);
    </script>
    <br>
    <br>
    <br>
    </form>
</body>
</html>
