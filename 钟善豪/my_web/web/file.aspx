<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="file.aspx.cs" Inherits="my_web.web.file" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title></title>
     <link href="../css/style.css" type="text/css" rel="stylesheet">
</head>
<body>  
    
        <form action="../ashx/upload_file.ashx" method="post" enctype="multipart/form-data">                      
        <input type="file" name="upload"  />      
        <input type="submit" />
        </form>
     <div id="listBox">
        <div id="inputBox">
         <div id="Container">
            <table id="table_left" style="margin:25px;float:none;">
                <tbody><tr>                   
                    <th class="t2">文件名</th>
                    <th class="t3">文件路径</th>
                    <th class="t4">下载</th>
                </tr>              
                <tr>
                    <td style="background:none;"></td>
                    <td style="background:none;"></td>    
                    <td style="background:none;"></td>        
                </tr>    
                    <% for (int j = 0; j < table.Rows.Count; j++){%>
                <tr>
                <td><%=table.Rows[j]["filename"].ToString() %></td>
                <td><%=table.Rows[j]["filepath"].ToString() %></td>
                <th><a href="file.aspx?id=<%=table.Rows[j]["id"] %>"> <input type="button" name="btnLeft" value="下载" onclick=""></a></th>                                              
            </tr> <%} %>
            </tbody></table>          
           <div style="clear:both;"></div>  
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
</body>
</html>
