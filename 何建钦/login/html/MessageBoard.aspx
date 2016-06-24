<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageBoard.aspx.cs" Inherits="login.html.MessageBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/style.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="../js/ckeditor/ckeditor.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js">
    </script>
    <script src="../js/ajax.js">
    </script>
    <script type="text/javascript">
        function support(id,i) {
            //ajax("../handler/Support.ashx?ID="+id,function(resText){
            //    document.getElementById("supports"+i).innerHTML=resText;
            //})
            htmlobj=$.ajax({url:"../handler/Support.ashx?ID="+id,async:false});
            $("#supports"+i).html(htmlobj.responseText);
        }
        //$(document).ready(function(){
        //    $("input#supports"+i).click(function(){
        //        htmlobj=$.ajax({url:"/jquery/test1.txt",async:false});
        //        $("#myDiv").html(htmlobj.responseText);
        //    });
        //});
    </script>
</head>
<body>
    <div id="listBox">
        <form action="../handler/MessageBoard.ashx" method="post" >
            <textarea name="Msg" id="input_box"></textarea>
            <input type="submit" value="发表" />
        </form>
        <div id="Container" style="width:663px;">
            <table id="table_left" style="margin:25px;float:none;">
                <tbody>                    
                    <% for (int i = table.Rows.Count-1; i >=0; i--)
                       { %>
                    <tr>
                        <td style="text-align:left;"><%=table.Rows[i]["ID"] %>楼<br /><%=table.Rows[i]["DataTime"] %><br />
                            <%=table.Rows[i]["Name"] %>:<br /><%=table.Rows[i]["MessageContents"].ToString() %><br />
                            <input type="button" onclick="support(<%=table.Rows[i]["ID"] %>,<%=i %>)" value="赞" /><label id="supports<%=i %>"><%=table.Rows[i]["Supports"] %></label></td> 
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
