<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change.aspx.cs" Inherits="weblogin.web_view.change" %>

<!DOCTYPE html>
<!-- saved from url=(0052)http://172.16.13.32/dkl/sign_in/html/all_detail.html -->
<html lang="en"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="UTF-8">
    <link href="./all_detail_files/style.css" type="text/css" rel="stylesheet">
    <title></title>
    <script src="./all_detail_files/jquery.min.js"></script>
    <script>
    function change(mima,xuehao,people,my){
           location.href = '../ashx/change.ashx?mima='+mima+'&xuehao='+xuehao+'&people='+people+'&myname='+my;
       }
    </script>
</head>
<body>
    <div id="listBox">
        
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;"><tbody><tr>
                        <th class="t2">用户名</th>
                <th><input type="text" id="textname"name="name" value="<%=name%>"/></th>
                        </tr><tr>
                        <th class="t3">密码</th>
                <th><input type="text" id="textmima"name="name" value="<%=mima%>"/></th>
                        </tr><tr>
                        <th class="t3">学号</th>
                <th><input type="text" id="textxuehao"name="name" value="<%=xuehao%>"/></th>
                        </tr><tr>
                        <th class="t3">姓名</th>
                <th><input type="text" id="textpeople"name="name" value="<%=xingming%>"/></th>
                        </tr><tr>
                        <th class="t5">身份证</th>
                <th><input type="text" id="textidentity"name="name" value="<%=shenfengzhen%>"/></th>
                        </tr><tr>
                <th><input type="button"name="b_1"onclick="change(textmima.value, textxuehao.value, textpeople.value, textidentity.value)"value="修改"/></th>
                        </tr><tr>
                       
                            </tr></tbody></table>
           <div style="clear:both;"></div>  
        </div>
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
    <br>
    <br>
    <br>


</body></html>