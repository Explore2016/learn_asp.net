<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Files.aspx.cs" Inherits="WebApplication1.Fire" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/style.css" type="text/css" rel="stylesheet"/>
     <script type="text/javascript">
         function Dwonload_File(id){
             var DlOrNot = confirm("请确认是否下载该文件？");
             if (DlOrNot == true) {
                 window.location.href = "Files.aspx?ID_dl=" + id;
             }
             else {
                 window.location.href = "Files.aspx";
             }
         }
    </script>
</head>
<body>
    <div id="listBox">
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;">
                <tbody>
                    <tr>
                        <th class="t7">序号</th>
                        <th class="t7">文件编号</th>                        
                        <th class="t7">文件地址</th>
                         <th class="t7">文件名称</th>
                         <th class="t7">下载</th>
                    </tr>
                    <% for (int i = 0; i < table.Rows.Count; i++)
                       { %>
                    <tr>
                        <td><%=i+1 %></td>
                        <td id="id_<%=i+1 %>"><%=table.Rows[i]["ID"].ToString() %></td>
                        <td><%=table.Rows[i]["Address"].ToString() %></td>
                        <td><%=table.Rows[i]["file_name"].ToString() %></td>
                        <% long ID = long.Parse(table.Rows[i]["ID"].ToString()); %>
                        <th>
                            <input type="button" value="下载" onclick="Dwonload_File(<%=ID %>)"/>
                       </th>
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <div style="clear:both;"></div>
        </div><%--<center><%if (admin==1){ %>
            <p>文件上传</p>
        <form action="../handler/upload_files.ashx" method="post" enctype="multipart/form-data">
            <input type="file" name="upload" style="background-color:white;border:0px;color:black;width:auto" />
            <br />
            <input type="submit" />
        </form><%} %></center>--%>
    </div>
</body>
</html>

