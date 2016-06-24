<%@ Page Language="C#"   AutoEventWireup="true" CodeBehind="message board.aspx.cs" Inherits="my_web.web.message_board" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../js/ckeditor/ckeditor.js"></script>
    <title></title>
    <link href="../css/style.css" type="text/css" rel="stylesheet"/>
</head>
<body> 
     <h1 align="center" >留言板</h1>
       <div id="listBox">
        <div id="inputBox">          
        </div>
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;">
                <tbody><tr>          
                    <th class="t1">姓名</th>
                    <th class="t2">留言内容</th>
                    <th class="t3">时间</th>
                    <th class="t4">赞</th>
                    <th class="t5">踩</th>

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
                <td><%=da.Rows[j]["name"].ToString() %></td>
                <td><%=da.Rows[j]["text"].ToString() %></td>
                <td><%=da.Rows[j]["time"].ToString() %></td>                                     
                <th><a><input type="button"  value="赞" onclick="zan('<%=da.Rows[j]["name"]%> ','<%=j %>')"/><label id="zancount<%=j %>"></label></a></th>
                <th><a><input type="button"  value="踩" onclick="cai('<%=da.Rows[j]["name"]%> ','<%=j %>')"/><label id="caicount<%=j %>"></label></a></th>                          
            </tr> <%} %>
            </tbody></table>
           <div style="clear:both;"></div>  
        </div>
    </div>        
     <h2  >给用户<%=id %>留言</h2>
     <form action="../ashx/message board.ashx?ID=<%=id %>" method="post" align="center">       
            <p>作者</p>
            <input type="text" id="usr" name="name" value="" />
            <textarea name="message" id="text" ></textarea>
            <input type="submit" value="留言" />
     </form>      
</body>
    <script type="text/javascript" src="../js/ajax.js"></script>
    <script type="text/javascript">
        function zan(name,i)
        {          
      
            
                ajax("../ashx/zancai.ashx?action=zan"+"&name="+name, function (resText) {
                    document.getElementById("zancount"+i).innerHTML = resText;
                });
            
        }

        function cai(name,i)
        {
            ajax("../ashx/zancai.ashx?action=cai"+"&name="+name, function (resText)
            {
                document.getElementById("caicount"+i).innerHTML = resText;
            });
        }
    var text = document.getElementById("text");
    CKEDITOR.replace(text);

</script>
</html>
