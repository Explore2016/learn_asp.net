<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="using.aspx.cs" Inherits="WebApplication2._using" %>

<!DOCTYPE html>
<!-- saved from url=(0052)http://172.16.13.32/dkl/sign_in/html/all_detail.html -->
<html lang="en"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="UTF-8">
    <link href="../css/style.css" type="text/css" rel="stylesheet">
    <title></title>
    <script src="../js/jquery.min.js"></script>
    <script type="text/javascript">
        function remove(timeId) {
            var remove = confirm("是否确定删除该用户？")
            if (remove == true) {
                ajax('../ashx/delete.ashx?Id=' + timeId, function (resTxt) {
                    if (resTxt == "yes") {
                        alert('成功删除用户！');
                    }
                    else {
                        alert('未知错误！');
                    }
                
                })
            }
        }
        function delet(Id) {
            location.href = '../ashx/delete.ashx?Id=' + Id;
        }
        function change(){
            location.href = 'change.aspx';
        }
    </script>
</head>
<body>
    <div id="listBox">
        
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;"><tbody><tr>
                        <th class="t1">序号</th>
                        <th class="t2">用户名</th>
                        <th class="t3">密码</th>
                        <th class="t3">学号</th>
                        <th class="t3">姓名</th>
                        <th class="t5">身份证</th>
                <% if(usertype == "1"){%>
                        <th class="t3">删除</th>
                <%} %>
                        </tr><tr>
                        
                            <%for (int i = tables.Rows.Count - 1 ; i > -1;  --i)
          {
              
              string timeusername = tables.Rows[i]["Name"].ToString();
              if (timeusername == name)
              {
                  continue;
              }
              else
              { %>
                            
                        <td><%= i%></td>
                        <td><%=tables.Rows[i]["Name"].ToString()%></td>
                        <td><%=tables.Rows[i]["Password"].ToString()%></td>
                        <td><%=tables.Rows[i]["studentnumber"].ToString()%></td>
                        <td><%=tables.Rows[i]["peoplename"].ToString()%></td>
                        <td><%=tables.Rows[i]["Idcard"].ToString()%></td>
                            <% var timeid = tables.Rows[i]["Id"].ToString();%>
                            <% if(usertype == "1"){%>
                        <th><input type="button" name="btnRight" value="删除" onclick="delet('<%=tables.Rows[i]["Name"].ToString()%>    ')"></th>
                        <%} %>
                        </tr><tr>
                             <%} %>
        <%} %>
                       <th class="t3">个人信息</th>
                       </tr><tr>
                       <th class="t1">序号</th>
                       <th class="t2">用户名</th>
                       <th class="t3">密码</th>
                       <th class="t3">学号</th>
                       <th class="t3">姓名</th>
                       <th class="t5">身份证</th>
                       <th class="t5">更改信息</th>
                       </tr><tr>
                       <td>1</td>
                       <td><%=name%></td>
                        <td><%=mima%></td>
                        <td><%=xuehao%></td>
                        <td><%=xingming%></td>
                        <td><%=shenfengzhen%></td>
                          
                         <th><input type="button" name="btnRight" value="修改个人信息" onclick="change()"></th></tr><tr>
                         <% if(usertype == "1"){%>
                         <th><form method="post" enctype="multipart/form-data"action="../ashx/upload_file.ashx">
                            <input type="file" name="upload" /><input type="submit" />
                                </form></th>
                             <%} %>
                            </tbody></table>
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

