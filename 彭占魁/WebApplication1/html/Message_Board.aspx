<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Board.aspx.cs" Inherits="WebApplication1.Message_Board" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link href="../css/style.css" type="text/css" rel="stylesheet">--%>
    <script type="text/javascript" src="../js/ckeditor/ckeditor.js"></script>
    <script src="../js/Ajax.js">
    </script>
    <script type="text/javascript">
        function support(id,i) {
            Ajax("../handler/Message_approve.ashx?ID="+id,function(resText){
                document.getElementById("Approve"+i).innerHTML=resText;
            })
        }
    </script>
</head>
<body>
    <div id="listBox">
        <form action="../handler/Message_Board.ashx" method="post" >
            <textarea name="Msg" id="input_box"></textarea>
            <input type="text" name="Name"/>
            <input type="submit" value="发表" />
        </form>
        <div id="Container" style="width:663px;">
            <table id="table_left" style="margin:25px;float:none;">
                <tbody>                    
                    <% for (int i = 0; i < table.Rows.Count; i++)
                       { %>
                    <tr>
                        <td style="text-align:left;"><%=table.Rows[i]["ID"] %>楼<br /><%=table.Rows[i]["Name"] %>:<br />
                          <%=table.Rows[i]["MessageContents"].ToString() %><br /><input type="button" onclick="support(<%=table.Rows[i]["ID"] %>,<%=i %>)" value="赞" />
                         <label id="Approve<%=i %>"><%=table.Rows[i]["Approve"] %></label></td> 
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <div style="clear:both;"></div>
        </div>
    </div>
    <script type="text/javascript">
        var input_box = document.getElementById("input_box");
        CKEDITOR.replace(input_box);
    </script>
</body>
</html>
