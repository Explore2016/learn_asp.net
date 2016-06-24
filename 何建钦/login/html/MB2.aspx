<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MB2.aspx.cs" Inherits="login.html.MB2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>留言板</title>
    <link href="../css/css.css" type="text/css" rel="stylesheet"/>
    <script src="../js/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="../js/ckeditor/ckeditor.js"></script>
</head>
<body style="background-color:#FFF">
 
  <div id="head">
      <span style="font-size:30px;margin-left:50px;"><a style="font-weight:bold;" href="">桂林电子科技大科技有限公司</a></span>
      <span style="padding-right:5%;float:right;padding-top:10px;"><a style="font-weight:bold;" href="">登陆</a>|<a style="font-weight:bold;" href="">注册</a></span>
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
        <div class="bule" style="height:400px;">
            <span style="color: #FFF; margin-left: 5px;">当前用户：</span><span style="color: #FFF; font-weight: bold;"><%=Name %></span>
            <span style="margin-left: 10px;"><a href="" style="color: #00C; text-decoration: underline">登陆</a></span>
            <span style="float: right; color: #FFF; margin-right: 10px;">当前时间:<script type="text/javascript">document.write(Date())</script></span>
            <form action="../handler/MessageBoard.ashx" method="post">
                <div id="write" style="height:310px;">
                    <textarea name="Msg" id="input_box"></textarea>
                </div>
                    <div style="float: right;" class="grey">
                        <input type="submit" value="发    表" class="grey" style="font-size:23px;line-height:10px;" />
                    </div>
            </form>
        </div>
    <!--历史留言框 可多加可重复-->
      <%for(int i=table.Rows.Count-1;i>=0;i--) {%>
    <div class="bule">
          <div style="height:48px;">
          	<div style="float:left;" class="grey">用户：<%=table.Rows[i]["Name"] %>
          	</div>
            <div  id="zan">
            <span style="color:#FFF;float:right;padding-top:10px;font-size:25px;"><label id="supports<%=i %>"><%=table.Rows[i]["Supports"] %></label></span>
            <img  style="float:right;" src="../image/233.jpg" onclick="support(<%=table.Rows[i]["ID"] %>,<%=i %>)" />
            </div>
          </div>
          <script>
              function support(id, i) {
                  htmlobj = $.ajax({ url: "../handler/Support.ashx?ID=" + id, async: false });
                  $("#supports" + i).html(htmlobj.responseText);
              }
          </script>
          
          <div class="auto">
              <%=table.Rows[i]["MessageContents"].ToString() %>
          </div>
          
          
          <div style="float:right;" class="grey">时间：<%=table.Rows[i]["DataTime"] %>
          </div>
    </div>
      <%} %>
  </div>
  
  <!--尾部-->
  <div id="foot">
  
  </div>

  <script type="text/javascript">
      var input_box = document.getElementById("input_box");
      CKEDITOR.replace(input_box);
    </script>
</body>
</html>
