<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateinf.aspx.cs" Inherits="updateinf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="update">
     &nbsp;&nbsp;&nbsp;
    账号：<asp:Label ID="lbname" runat="server"></asp:Label><br />
        <br />
&nbsp;&nbsp;&nbsp; 昵称：<asp:TextBox ID="txtname" runat="server" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp; 邮箱：<asp:TextBox ID="txtmail" runat="server" ></asp:TextBox>
        &nbsp;&nbsp;<br />
        <br />
        &nbsp; 出生年份：<asp:DropDownList ID="Year" runat="server" >
            <asp:ListItem>1995</asp:ListItem>
    <asp:ListItem>1996</asp:ListItem>
            <asp:ListItem>1997</asp:ListItem>
            <asp:ListItem>1998</asp:ListItem>
     <asp:ListItem>1999</asp:ListItem>
     <asp:ListItem>2000</asp:ListItem>
              </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp; 性别：<asp:RadioButtonList ID="radlSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem>男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem></asp:RadioButtonList> 
          <br />
          <br />
        &nbsp; 密保问题：<asp:DropDownList ID="question" runat="server">
            <asp:ListItem>父亲生日</asp:ListItem>
            <asp:ListItem >您的学号</asp:ListItem>
            <asp:ListItem>爱豆姓名</asp:ListItem>
              </asp:DropDownList>
        <br />
        <br />
&nbsp; 新密保答案：<asp:TextBox ID ="answerpwd" runat ="server" ></asp:TextBox>
        &nbsp;<br />
        <br />
       &nbsp;&nbsp;&nbsp; 头像： <asp:Repeater id="rptinf" runat ="server"  >
          <HeaderTemplate> 
                <table>
                    <tr>
                       
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                   
                     <td><asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("picture")%>' Width="100" Height="80"/></td>
                      
               </tr>
             </ItemTemplate>

             <FooterTemplate>
               </table>

            </FooterTemplate>
     
    </asp:Repeater>
      
          <br />
        <asp:FileUpload ID="upload1" runat="server" />
        <br />
        <br />
        <br />
        <br />
      
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID ="updatepwd" runat ="server" PostBackUrl="~/Updatepwd.aspx" Text ="修改密码" />
        <br />
          <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="update1" Onclick="update1_Click" runat ="server"  Text="修改"/>
         &nbsp;<asp:Button ID ="back" runat ="server" PostBackUrl="~/Information.aspx" Text ="返回" />
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
