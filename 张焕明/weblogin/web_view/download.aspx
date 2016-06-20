<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="weblogin.web_view.download" %>

<!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta charset="UTF-8">
        <link href="../css/style.css" type="text/css" rel="stylesheet">
        <title></title>
        <script src="../js/jquery.min.js"></script>
        <script type="text/javascript">
            function Dwonload_File(id){
                var DlOrNot = confirm("请确认是否下载该文件？");
                if (DlOrNot == true) {
                    window.location.href = "../ashx/file_download.ashx?ID_dl=" + id;
                }
                else {
                    window.location.href = "../ashx/file_download.ashx";
                }
            }

            </script>
    </head>
    <body>
        <div id="listBox">
        
            <div id="Container">
                <table id="table_left" style="margin:25px;float:none;"><tbody><tr>
                            <th class="t1">序号</th>
                            <th class="t3">文件编号</th>
                            <th class="t2">文件名</th>
                            <th class="t3">随机名</th>
                            <th class="t3">文件下载</th>
                           
                            </tr>
                     <% for (int i = 0; i < table.Rows.Count; i++)
                       { %>
                     <tr>
                        <td><%=i+1 %></td>
                        <td id="id_<%=i+1 %>"><%=table.Rows[i]["Id"].ToString() %></td>
                        <td><%=table.Rows[i]["Filesname"].ToString() %></td>
                        <td><%=table.Rows[i]["Filesguid"].ToString() %></td>
                        <% long ID = long.Parse(table.Rows[i]["Id"].ToString()); %>
                        <th>
                            <input type="button" value="下载" onclick="Dwonload_File(<%=ID%>)" />
                        </th>
                    </tr>
                    <%} %>
      </tbody></table>
               <div style="clear:both;"></div>  
            </div>
        </div>
    </body>
    </html>
