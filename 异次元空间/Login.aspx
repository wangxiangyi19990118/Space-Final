<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
    <div id="divLogin" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 登录页面
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 账号:<asp:TextBox ID="txtID" runat="server" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 密码:<asp:TextBox ID="txtpwd" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 验证码(数字):<asp:TextBox ID="Vcode" runat="server"></asp:TextBox>
       
     看不清？<a href="javascript:changeCode()"style="text-decoration: underline;">换一张</a>

<script type="text/javascript">

function changeCode() {  document.getElementById('ImageButton1').src = document.getElementById('ImageButton1').src +'?';

          }

</script>
        <asp:Image ID="ImageButton1" runat="server" Width="100" Height="30"/>

        <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogin" runat="server" OnClick="btnRegester_Click" Text="登录" Width="66px" style="margin-left: 56px" />
            <asp:Button ID ="btnRegister" runat ="server" PostBackUrl="~/Register.aspx" Text="注册" Width="66px" style="margin-left: 56px" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat ="server"  PostBackUrl="~/Updatepwd.aspx" Text ="忘记密码" Width="107px" style="margin-left: 56px" /></div>
          
         
    </form>
      <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
      </p>
</body>
</html>
