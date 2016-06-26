<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="land.aspx.cs" Inherits="WebApplication1.land" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div style="text-align:center">
    <button onclick="button_xiugai()"style="background-color: aqua; color: violet">修改信息</button>
    <button onclick="button_quanbu()"style="background-color: magenta; color: white">全部信息</button>
    <button onclick="button_Message()"style="background-color: magenta; color: white">留言板</button>
     <%if (VIP) {  %>
        <button onclick="button_file()"style="background-color: hotpink; color: white">上传文件</button>
        <%} %> 
    <style>
	button
	{
		width: 104px;
		height: 100px;
		font-size: 32px;
	}
    </style>
    </div>
    <form id="form1" runat="server">
         <link href="../css/style.css" type="text/css" rel="stylesheet"/>
    <div id="listBox">
        <div id="Container">
    <table id="table_right" style="margin:25px;float:none;">
     <tr>
            <th class="t6">属性</th>
            <th class="t7">内容</th>
      </tr> 
       <tr>
            <td>ID</td>
            <td><%=student_info.Rows[0]["ID"] %></td>
        </tr>
        <tr>
            <td>姓名</td>
             <td><%=student_info.Rows[0]["name"] %></td>
        </tr>
         <tr>
            <td>班级</td>
            <td><%=student_info.Rows[0]["class ID"] %></td>
        </tr>
        <tr>
            <td>学号</td>
            <td><%=student_info.Rows[0]["stdent_number"] %></td>
        </tr>
        <tr>
            <td>密码</td>
            <td><%=student_info.Rows[0]["pass_word"] %></td>
        </tr>
        <tr>
            <td>专业</td>
            <td><%=student_info.Rows[0]["major"] %></td>
        </tr>
        <tr>
            <td>学院</td>
            <td><%=student_info.Rows[0]["college"] %></td>
        </tr>
        <tr>
            <td>Cookie</td>
            <td><%=student_info.Rows[0]["Cookie"] %></td>
        </tr>
    </table>
    </div>
    </div>
    </form>
</body>
     <script type="text/javascript">
         function button_xiugai() {
             location.href = 'use_to_change_my_information.aspx';
         }
         function button_quanbu() {
             location.href = 'central frame.aspx';
         }
         function button_file() {
             location.href = 'file_up_load.html';
         }
         function button_Message() {
             location.href = 'Message_Board.aspx';
         }
    </script>
</html>

