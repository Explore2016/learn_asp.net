<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="weblogin.web_view.message" %>

<!DOCTYPE html>

<<html lang="en"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="UTF-8">
    <link href="../css/style.css" type="text/css" rel="stylesheet">
    <title></title>
    <script src="../js/jquery.min.js"></script>
    <script type="text/javascript"src="../js/ajax.js"></script>
    <script>
        $(document).ready(function(){
            $("p").click(function(id){
                ajax('../ashx/message.ashx?Id=' + Id, function (resTxt) {
                    if (resTxt != "") {
                        location.href = 'praise.aspx';

                    }
                })
            });
        });
</script>
    <script type="text/javascript">
        function praise(Id){
            ajax('../ashx/message.ashx?Id=' + Id, function (resTxt) {
                if (resTxt != "") {
                    document.getElementById("praise" + Id).innerHTML = resTxt;

                }
            })
            }
    </script>
</head>
<body>
     <script language=JavaScript>
         today = new Date();
         function initArray() {
             this.length = initArray.arguments.length
             for (var i = 0; i < this.length; i++)
                 this[i + 1] = initArray.arguments[i]
         }
         var d = new initArray(
         "星期日",
         "星期一",
         "星期二",
         "星期三",
         "星期四",
         "星期五",
         "星期六");
         document.write(
         "<font color=#333 style='font-size:9pt;font-family: 宋体'> ",
         today.getFullYear(), "年",
         today.getMonth() + 1, "月",
         today.getDate(), "日",
         d[today.getDay() + 1],
         "</font>");
</script>
    <div id="listBox">
        
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;"><tbody><tr>
                        <th class="t1">序号</th>
                        <th class="t2">用户名</th>
                        <th class="t3">留言时间</th>
                        <th class="t3">留言内容</th>
                        <th class="t3">阅读</th>
                        <th class="t3">已阅人数</th>
                        
                        
                <% for (int i = 0; i < table.Rows.Count; i++)
                       { %>
                <tr>
                        <td><%=i+1 %></td>
                        
                        <td><%=table.Rows[i]["username"].ToString() %></td>
                        <td><%=table.Rows[i]["writetime"].ToString() %></td>
                        <td><%=table.Rows[i]["message"].ToString() %></td>
                        <% long ID = long.Parse(table.Rows[i]["Id"].ToString()); %>
                        <th>
                            
                            <input type="button" value="赞" onclick="praise(<%=ID%>)" />
                            
                        </th>
                    <td id ="praise<%=ID%>" ><%=tables.Rows[i]["praise"]%></td>
                    </tr>
                    <%} %>
    </tbody></table>
           <div style="clear:both;"></div>  
        </div>
    </div>
</body>
</html>
