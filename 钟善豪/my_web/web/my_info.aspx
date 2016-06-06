<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_info.aspx.cs" Inherits="my_web.my_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div>
        <h1>用户名：<%=id %></h1>
        </div>
        <table border="1">
            <tr>
                <th>用户名</th>
                <th>姓名</th>
                <th>性别</th>
                <th>年龄</th>
            </tr>
                <% for (int j = 0; j < da.Rows.Count; j++){%>
                <tr>
                <td><%=da.Rows[j]["id"].ToString() %></td>
                <td><%=da.Rows[j]["name"].ToString() %></td>
                <td><%=da.Rows[j]["sex"].ToString() %></td>
                <td><%=da.Rows[j]["age"].ToString() %></td>                           
                <td> <th><a href="../ashx/delete.ashx?id=<%=da.Rows[j]["id"] %>"><h4 align="center" style="color:"><%="删除"%></h4></a></th></td>
                     <td> <th><a href="change.aspx?id=<%=da.Rows[j]["id"] %>"><h4 align="center" style="color:"><%="编辑"%></h4></a></th></td>               
            </tr> <%} %>
            
        </table>
        <td style="width: 151px">
    </form>
</body>
</html>
