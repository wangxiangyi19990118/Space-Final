<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Management.aspx.cs" Inherits="Management" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Repeater ID ="inf" runat ="server" OnItemDataBound ="inf_ItemDataBound" OnItemCommand="inf_ItemCommand">
        <HeaderTemplate> 
                <table>
                    <tr> <th>说说和日志</th>
                        <th>账号</th>
                        <th>昵称</th>
                        <th>标题</th>
                        <th>分类</th>
                        <th>摘要</th>
                        <th>正文</th>
                        <th>时间</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>  <td></td>
                    <td><%# Eval("userID")%></td>
                    <td><%# Eval("name")%></td>
                    <td><%# Eval("title")%></td>
                    <td><%# Eval("class")%></td>
                    <td><%# Eval("tip")%></td>
                    <td><FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text ='<%# Eval("matter")%>' ReadOnly ="true" ></FTB:FreeTextBox></td>
                    
                    <td><%# Eval("datetime")%></td>
                    <td><%# Eval("good")%> 个赞</td>
                  
                    <td><asp:LinkButton ID="LinkButton3" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
                    <asp:Repeater ID="friend2" runat="server" OnItemCommand="friend2_ItemCommand" >
                    <HeaderTemplate> 
                <table>
                    <tr>
                        <th>评论</th>
                        <th>昵称</th>
                        <th>账号</th>
                        <th>内容</th>
                        <th>时间</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr> <td></td>
                    <td><%# Eval("name")%></td>
                     <td><%# Eval("id0")%></td>
                    <td><%# Eval("rptmatter")%></td>
                    <td><%# Eval("datetime")%></td>
                    <td><asp:LinkButton ID="LinkButton3" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
               </tr>
                </ItemTemplate>
             <FooterTemplate>
               </table>
            </FooterTemplate>
                        </asp:Repeater>
             </ItemTemplate>
             <FooterTemplate>
              
            </FooterTemplate>
    </asp:Repeater>
    </div>
         <asp:Repeater ID="users" runat="server" OnItemCommand="users_ItemCommand" >
                    <HeaderTemplate> 
                <table>
                    <tr><th>用户</th>
                        <th>昵称</th>
                        <th>账户</th>
                        <th>年龄</th>
                        <th>性别</th>
                        <th>头像</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr> <td></td>
                    <td><%# Eval("name")%></td>
                     <td><%# Eval("ID")%></td>
                    <td><%# Eval("age")%></td>
                    <td><%# Eval("sex")%></td>
                     <td><asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("picture")%>' Width="100" Height="80"/></td>
                    <td><asp:LinkButton ID="LinkButton3" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
               </tr>
                </ItemTemplate>
             <FooterTemplate>
               </table>
            </FooterTemplate>
                        </asp:Repeater>
       

    </form>
</body>
</html>
