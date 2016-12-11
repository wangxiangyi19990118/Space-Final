<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Newfriend.aspx.cs" Inherits="Newfriend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="selsct" runat ="server" >
        <asp:Label ID="lbname" runat="server"></asp:Label>
         请选择查找类型:<br />
        <br />
&nbsp;查找类型：<asp:DropDownList ID="dropProv" runat="server">
            <asp:ListItem>账号</asp:ListItem>
            <asp:ListItem>昵称</asp:ListItem>
    <asp:ListItem>出生日期</asp:ListItem>
    <asp:ListItem>性别</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID ="txtinput" runat ="server" ></asp:TextBox>
        &nbsp;&nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="insert"  />
        <br />
        <br />
        </div> 
   <div id="friend1" runat ="server"  visible ="false" >
         <asp:Repeater id="rptinsert" runat ="server"   >
          <HeaderTemplate> 
                <table>
                    <tr>
                        <th>账号</th>
                        <th>昵称</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID")%></td>
                    <td><%# Eval("name")%></td>
                       <td><asp:LinkButton ID="insert" runat="server"  Text="添加"  CommandName="insert"  CommandArgument='<%#Eval("ID") %>'  OnClick="insert_Click"></asp:LinkButton></td>
                   
               </tr>
             </ItemTemplate>

             <FooterTemplate>
               </table>

            </FooterTemplate>
     
    </asp:Repeater>
         <div id="page1" visible ="false" runat ="server">
            &nbsp;<asp:Button ID="btnBefore" runat="server" Text="上一页"  OnClick="btnBefore_Click" Width="68px"/>  
    &nbsp;  
    <asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnNext_Click" Width="64px" />  
        &nbsp;  
        <asp:Button ID="butTop" runat="server" Text="首页" OnClick="butTop_Click" />  
         &nbsp;  
         <asp:Button ID="btnFinal" runat="server" Text="尾页" OnClick="btnFinal_Click" />  
        &nbsp;  
        当前页为：<asp:Label ID="lblCurrentPage" runat="server" Text="Label"></asp:Label> 
                共<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>页 转到 <asp:TextBox ID="paper" runat ="server" Width="37px" ></asp:TextBox>页
            <asp:Button ID ="paperturn" runat ="server" Text ="跳转" OnClick ="paperturn_Click" Width="63px" />

        </div>
        <br />
&nbsp;备注：<asp:TextBox ID="ask1" runat="server" Height="16px"></asp:TextBox>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
    </div>
         <asp:Button ID ="back" runat ="server" PostBackUrl="~/Space.aspx" Text ="返回" />
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
