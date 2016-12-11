<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dairy.aspx.cs" Inherits="Dairy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:linkbutton runat="server" ID ="writedairy" PostBackUrl ="~/WriteDiary.aspx">写日志</asp:linkbutton>
    </div>
    <div>
    我的日志
        <asp:Repeater id="repeaterdiary" runat ="server" Visible="False" OnItemDataBound="repeaterdiary_ItemDataBound" OnItemCommand ="repeaterdiary_ItemCommand">
          <HeaderTemplate> 
                <table>
                    <tr>
                        <th>标题</th>
                        <th>日期</th>
                        <th>摘要</th>
                        <th>分类</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("title")%></td>
                    <td><%# Eval("datetime")%></td>
                    <td><%# Eval("tip")%></td>
                     <td><%# Eval("class")%></td>
                     <td><%# Eval("good")%>个赞</td>
                     <td><asp:LinkButton ID="LinkButton3" runat="server" Text="赞" CommandName="yes" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除"  CommandName="Delete"  CommandArgument='<%#Eval("id") %>' OnClick="lbtDelete_Click"></asp:LinkButton></td>
                     <td><asp:LinkButton ID="lbFind" runat="server" Text="查看" PostBackUrl='<%#"FindDiary.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                   <asp:Repeater ID="friend2" runat="server" >
                    <HeaderTemplate> 
                <table>
                    <tr>
                        <th>评论</th>
                        <th>头像</th>
                        <th>昵称</th>
                        <th>内容</th>
                        <th>时间</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>  <td></td>
                    <td><asp:ImageButton ID="Image2" runat="server" ImageUrl='<%#Eval("picture1")%>' Width="100" Height="80"  PostBackUrl='<%#"Visiter.aspx?id="+Eval("id") %>'/></td>
                    <td><%# Eval("name")%></td>
                    <td><%# Eval("rptmatter")%></td>       
                    <td><%# Eval("datetime")%></td>
                     <td><asp:LinkButton ID="LinkButton2" runat="server" Text="回复" PostBackUrl='<%#"huifu.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                     <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除"  CommandName="Delete"  CommandArgument='<%#Eval("id") %>' OnClick="lbtDelete_Click"></asp:LinkButton></td>
               </tr>
                </ItemTemplate>
             <FooterTemplate>
               </table>
            </FooterTemplate>
                        </asp:Repeater>
               </tr>
             </ItemTemplate>

             <FooterTemplate>
               </table>

            </FooterTemplate>
      </asp:Repeater>
                <div id="page1" runat ="server" visible ="false">
                    <br />
                    <br />
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
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Back" runat="server" Text="返回" PostBackUrl="~/Space.aspx" />
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
