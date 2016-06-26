<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="central frame.aspx.cs" Inherits="WebApplication1.view_string" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../css/style.css" type="text/css" rel="stylesheet"/>
    <div id="listBox">
        <div id="Container">
        <table id="table_right" style="margin:25px;float:none;">
        <tr>
            <th class="t1">ID</th>
            <th class="t2">name</th>
            <th class="t3">class_ID</th>
            <th class="t3">stdent_number</th>
            <th class="t3">password</th>
            <th class="t4">major</th>
            <th class="t4">college</th>
            <th class="t5">cookie</th>
         </tr>      
        <tr>
            <td><%=stdent_info.Rows[0]["ID"] %></td>
            <td><%=stdent_info.Rows[0]["name"] %></td>
            <td><%=stdent_info.Rows[0]["class ID"] %></td>
            <td><%=stdent_info.Rows[0]["stdent_number"] %></td>
             <td><%=stdent_info.Rows[0]["pass_word"] %></td>
            <td><%=stdent_info.Rows[0]["major"] %></td>
            <td><%=stdent_info.Rows[0]["college"]%></td>
            <td><%=stdent_info.Rows[0]["Cookie"]%></td>
        </tr>
     </table>
    <table id="table_left" style="margin:25px;float:none;">
       <%for (int i = all_info.Rows.Count - 1; i > -1 && VIP; --i)
         {if (Convert.ToInt32(all_info.Rows[i]["ID"]) == VIP_ID) continue;%>
        <tr>
            <th class="t1">ID</th>
            <th class="t2">name</th>
            <th class="t3">class_ID</th>
            <th class="t3">stdent_number</th>
            <th class="t3">password</th>
            <th class="t4">major</th>
            <th class="t4">college</th>
            <th class="t5">功能</th>
         </tr>
        <tr>
            <td><%=all_info.Rows[i]["ID"] %></td>
            <td><%=all_info.Rows[i]["name"] %></td>
            <td><%=all_info.Rows[i]["class ID"] %></td>
            <td><%=all_info.Rows[i]["stdent_number"] %></td>
            <td><%=all_info.Rows[i]["pass_word"]%></td>
            <td><%=all_info.Rows[i]["major"] %></td>
            <td><%=all_info.Rows[i]["college"] %></td>
            <th><a href="../handler/delete.ashx?ID=<%=all_info.Rows[i]["ID"] %>"><h3 align="center" style="color:red"><%="删除"%></h3></a></th>
        </tr>
        <%} %>
     </table>
         <%if (VIP) {  %>
        <h1 align="center" style="color:red"><%="您是管理员，可以观看删除其他人的信息" %></h1>
        <%}else{ %>
        <h1 align="center" style="color:red"><%="你不是管理员，不可以查看其他人的信息" %></h1>
        <%} %>
    </div>
        </div>
    </form>
</body>
</html>
