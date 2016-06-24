<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="weblogin.web_view.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/css.css" type="text/css" rel="stylesheet"/>
<script src="../js/jquery-3.0.0.min.js"></script>
<script type="text/javascript" src="../js/ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            $("#grey").click(function () {
                var data = CKEDITOR.instances.financialbz.getData();
                var mege = encodeURI(data);
                data = data.replace(/&/g, "<.and.>");
                data = data.replace(/#/g, "<.shup.>");


                location.href = '../ashx/write_message.ashx?&message=' + data;
            }
            )})
    </script>
</head>

<body style="background-color:#FFF">
 
  <div id="head">
      <span style="font-size:30px;margin-left:50px;"><a style="font-weight:bold;" href="">桂林电子科技大科技有限公司</a></span>
      <span style="padding-right:5%;float:right;padding-top:10px;">
           <% if(username == ""){%>
          <a id="login" style="font-weight:bold;" href="">登陆</a>|<a style="font-weight:bold;" href="">注册</a></span>
      <%} %>
  </div>
  <!--导航栏-->
  <div id="list">
        <ul>
          <a  style="color:#FFF" href=""><li>网站首页</li></a>
          <a style="color:#FFF"  href=""><li>给我留言</li></a>
          <a  style="color:#FFF" href=""><li>产品介绍</li></a>
          <a style="color:#FFF"  href=""><li>科技展示</li></a>
          <a  style="color:#FFF" href=""><li>信息中心</li></a>
          <a style="color:#FFF"  href=""><li>关于我们</li></a>
        </ul>
  </div>
  
  <!--主体-->
  <div id="main">
    <!--留言框-->
    <div class="bule">
        <span style="color:#FFF;margin-left:5px;">当前用户：<%=username %></span><span id="identity" style="color:#FFF;font-weight:bold;"><%=usertype %></span>
        <span style="margin-left:10px;" ><a id="login2" href="login.html" style="color:#00C;text-decoration:underline">登陆</a></span>
        <span style="float:right;color:#FFF;margin-right:10px;">当前时间:<script type="text/javascript">document.write(Date())</script></span>
      <div id="write">
        <!--输入框-->
          <textarea name="financialbz" style="width:741px;height:398px"></textarea>
          <script type="text/javascript">CKEDITOR.replace('financialbz');</script>
      </div>
          <a href="">
              <div id="grey" style="float:right;" class="grey">发&nbsp;&nbsp;&nbsp;表
              </div>
          </a>
    </div>
    <!--历史留言框 可多加可重复-->
      <% for (int i = 0; i < table.Rows.Count; i++)
                       { %>
    <div class="bule">
          <div style="height:48px;">
          	<div style="float:left;" class="grey">用户：<%=table.Rows[i]["username"].ToString() %>
          	</div>
              <div style="float:left;" class="grey"><%=i+1 %>楼
          	</div>
            <% long ID = long.Parse(table.Rows[i]["Id"].ToString()); %>
            <div  id="zan(<%=ID %>)">
            <span style="color:#FFF;float:right;padding-top:10px;font-size:25px;"><%=tables.Rows[i]["praise"]%></span>
            <img  style="float:right;" src="../image/233.jpg" />
            </div>
          </div>
          <script>
              $("#zan").click(function () {
                  ajax('../ashx/message.ashx?Id=' + ID, function (resTxt) {
                      var zan_count = "resTxt"; //这里我自己设定了一个值，你们应该用ajax从数据库中获取
                      var zan_now = $(this).find("span");
                      zan_now[0].innerHTML = zan_count;
                      $(this).find("span").innerHTML = zan_count;
                  })
              });
              
          </script>
          <div class="auto">
              <%=table.Rows[i]["message"].ToString() %>
          </div>
          
          
          <div style="float:right;" class="grey">时间：<%=table.Rows[i]["writetime"].ToString() %>
          </div>
        <div></div>
        <%} %>
    </div>
  </div>
    
  
  <!--尾部-->
  <div id="foot">
  
  </div>


</body>
</html>

