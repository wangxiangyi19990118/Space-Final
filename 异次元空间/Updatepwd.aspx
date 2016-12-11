<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updatepwd.aspx.cs" Inherits="Updatepwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 修改密码<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 账号:<asp:TextBox ID="txtID" runat="server" ></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
      &nbsp;&nbsp;&nbsp; 修改方式：
        1：密保问题：<asp:DropDownList ID="question" runat="server">
            <asp:ListItem>父亲生日</asp:ListItem>
            <asp:ListItem Selected="True">您的学号</asp:ListItem>
            <asp:ListItem>爱豆姓名</asp:ListItem>
              </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 密保答案：<asp:TextBox ID ="answerpwd" runat ="server" ></asp:TextBox>
        &nbsp;<br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 验证码(数字): <asp:TextBox ID="Vcode" runat="server"></asp:TextBox>
       
     看不清？<a href="javascript:changeCode()"style="text-decoration: underline;">换一张</a>

<script type="text/javascript">

function changeCode() {  document.getElementById('ImageButton1').src = document.getElementById('ImageButton1').src +'?';

          }

</script>
        <asp:Image ID="ImageButton1" runat="server" Width="100" Height="30"/>

        <br />

        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 新密码: <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 确认新密码: <asp:TextBox ID="txtpwd1" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="update" runat ="server" OnClick ="update_Click" Text ="修改" />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2：邮件找回：<asp:Button ID="update0" runat ="server" OnClick ="update0_Click" Text ="点击获取验证码" SmartNavigation="false"/>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;验证码: <asp:TextBox ID="Vcode0" runat="server"></asp:TextBox>
       
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;新密码: <asp:TextBox ID="txtpwd2" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;确认新密码: <asp:TextBox ID="txtpwd3" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="update1" runat ="server" OnClick ="update1_Click" Text ="修改" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="return" runat ="server" PostBackUrl="~/Login.aspx"  Text ="返回" />
        <br />
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
