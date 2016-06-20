<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="write_message.aspx.cs" Inherits="weblogin.web_view.write_massage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <link href="../css/style.css" type="text/css" rel="stylesheet">
    <title></title>
    <script src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        function refer(user) {
            var data = CKEDITOR.instances.financialbz.getData();
            var mege=encodeURI(data);
            data = data.replace(/&/g, "<.and.>");
            data = data.replace(/#/g, "<.shup.>");

            
            location.href = '../ashx/write_message.ashx?username='+user+ '&message=' + data;
        }

    </script>
</head>
<body>
    <div id="listBox">
        
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;"><tbody>
                <td><%=username%></td>
                        
                <%var user = username; %>
                <%var word = password; %>
                <%var nowtime = new DateTime();  %>
                <td>
                    
                    <textarea name="financialbz"></textarea>
                    <script type="text/javascript">CKEDITOR.replace('financialbz');</script>
                    
                </td>
                
                <dd>
             <input type="button" value="提交" class="submit_btn2" onclick="refer('<% =user%>')"/><br/>
            
                </dd>
                 </tbody></table>
           <div style="clear:both;"></div>  
        </div>
    </div>

</body>
</html>

