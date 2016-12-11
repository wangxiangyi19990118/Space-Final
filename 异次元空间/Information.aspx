<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Information.aspx.cs" Inherits="Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Repeater id="rptinf" runat ="server"  >
          <HeaderTemplate> 
                <table>
                    <tr>
                        <th>账号</th>
                        <th>昵称</th>
                        <th>性别</th>
                        <th>出生年份</th>
                        <th>年龄</th>
                        <th>邮箱</th>
                        <th>头像</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID")%></td>
                    <td><%# Eval("name")%></td>
                    <td><%# Eval("sex")%></td>
                     <td><%# Eval("year")%></td>
                     <td><%# Eval("age")%></td>
                     <td><%# Eval("mail")%></td>
                     <td><asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("picture")%>' Width="100" Height="80"/></td>
                      <td><asp:LinkButton ID="lbtEditor" runat="server" Text="修改" PostBackUrl='<%#"updateinf.aspx?ID="+Eval("ID") %>'></asp:LinkButton></td>
               </tr>
             </ItemTemplate>

             <FooterTemplate>
               </table>

            </FooterTemplate>
     
    </asp:Repeater>
      
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:Button ID ="back" runat ="server" PostBackUrl="~/Space.aspx" Text ="返回" />
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
