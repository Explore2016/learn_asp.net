<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="xsgzc.Web.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>��ҳ</title>
    <link rel="stylesheet" type="text/css" href="style/css/index.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="tzgg">֪ͨ����
        <marquee direction="up" behavior="scroll" scrollamount="2" scrolldelay="0"
          onmouseover="this.stop();" onmouseout="this.start();">
        <asp:Repeater ID="RPtzgg" runat="server">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
          <li><a href="content.aspx?id=<%#Eval("ID")%>"><%#Eval("nTitle") %></a></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater></marquee>
    </div>
      <a href="list.aspx?id=1">����</a>
     
     
    <div id="xgdt">ѧ����̬
        <asp:Repeater ID="RPxgdt" runat="server">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
          <li><a href="content.aspx?id=<%#Eval("ID") %>"><%#Eval("nTitle") %></a></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>

        <div id="buttom"><a href="manage/login.aspx">��̨��½</a></div>
    </div>
           
    </div>
    </form>
</body>
</html>
