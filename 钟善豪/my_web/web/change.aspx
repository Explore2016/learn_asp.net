<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change.aspx.cs" Inherits="my_web.change" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form action="../ashx/change.ashx" id="login" method="get">
    <div>
     <p>用户名：</p>
            <input type="text" id="Id" name="id" value="<%=dt.Rows[0]["id"]%>"/>
            <p>密码：</p>
            <input type="text" id="Keys" name="keys" value="<%=dt.Rows[0]["keys"]%>"/>
            <p>姓名：</p>
            <input type="text" id="Name" name="name" value="<%=dt.Rows[0]["name"]%>"/>
            <p>性别：</p>
            <input type="text" id="Sex" name="sex" value="<%=dt.Rows[0]["sex"]%>"/>
            <p>年龄：</p>
            <input type="text" id="Age" name="age" value="<%=dt.Rows[0]["age"]%>"/>
            <br />
            <button >修改</button>
            <br />
    </div>
    </form>
</body>
</html>
