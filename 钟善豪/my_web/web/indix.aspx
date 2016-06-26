<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indix.aspx.cs" Inherits="my_web.web.indix" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>留言板</title>
<link href="../css/css.css" type="text/css" rel="stylesheet"/>
<script src="../js/jquery-3.0.0.min.js"></script>
    <script src="../js/ckeditor/ckeditor.js"></script>
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
    <div class="bule">
        <span style="color:#FFF;margin-left:5px;">当前用户：</span><%=use%><%=name %><span style="color:#FFF;font-weight:bold;"></span>
        <%--<span style="margin-left:10px;" ><a href="" style="color:#00C;text-decoration:underline">登陆</a></span>--%>
        <span style="float:right;color:#FFF;margin-right:10px;">当前时间:<script type="text/javascript">document.write(Date())</script></span>
      <div id="write">
        <form action="../ashx/message board.ashx?ID=<%=id%>"+"&name=<%=name %>" method ="post" align="center">                 
            <textarea name="message" id="text" ></textarea>         
        </div>
                    <div style="float: right;" class="grey">    
                        <input type="submit" value="发    表" class="grey" style="font-size:23px;line-height:10px;" />                                                                 
                    </div>
                 </form>  
            </div>
    <%--  </div>
          <a href="">
              <div style="float:right;" class="grey">发&nbsp;&nbsp;&nbsp;表
              </div>
          </a>
         </form>  
    </div>
     --%>
    <!--历史留言框 可多加可重复-->
          
                      
                           
    <% for (int j = 0; j < da.Rows.Count; j++){%>
    <div class="bule">
          <div style="height:48px;">
          	<div style="float:left;" class="grey">用户：<%=da.Rows[j]["name"].ToString() %>
          	</div>
           
            <div  id="zan" >
            <span style="color:#FFF;float:right;padding-top:10px;font-size:25px;" ><label id="zancount<%=j %>"><%=da.Rows[j]["zancount"]%></label></span>
            <img  style="float:right;" src="../image/233.jpg" onclick="zan('<%=da.Rows[j]["name"]%> ','<%=j %>','<%=da.Rows[j]["time"] %>')"/>
            </div>
          </div>
    <script type="text/javascript" src="../js/ajax.js"></script>
    <script type="text/javascript">  
              function zan(name, i,time) {
                
                  ajax("../ashx/zancai.ashx?action=zan" + "&name=" + name+"&time="+time, function (resText)
                  {
                      document.getElementById("zancount" + i).innerHTML = resText;
                  });
              }

     
          </script>
         
                <div class="auto">
              <%=da.Rows[j]["text"].ToString() %>
          </div>
          <div style="float:right;" class="grey">时间：<%=da.Rows[j]["time"].ToString() %>
          </div>
    </div>
       <%} %>
  </div>
  
  <!--尾部-->
  <div id="foot">
  
  </div>


</body>
    
    <script type="text/javascript">

        var text = document.getElementById("text");
        CKEDITOR.replace(text);

</script>
</html>

