<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Friend.aspx.cs" Inherits="Firend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div >
         我的好友
     <asp:Repeater id="repeaterdiary" runat ="server" OnItemCommand="repeaterdiary_ItemCommand" Visible ="false" >
          <HeaderTemplate> 
                <table>
                    <tr>
                        
                        <th>特别关心账号</th>
                        <th>特别关心昵称</th>
                        <th>特别关心头像</th>
                        
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr><td><%# Eval("friendID")%></td>
                    <td><%# Eval("friendname")%></td>
                    <td><asp:ImageButton ID="Image2" runat="server" ImageUrl='<%#Eval("picture")%>' Width="100" Height="80" PostBackUrl='<%#"Visiter1.aspx?id="+Eval("friendID") %>'/></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" Text="不让他看我的动态" CommandName="no" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton2" runat="server" Text="让他看我的动态" CommandName="yes" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                     <td><asp:LinkButton ID="LinkButton3" runat="server" Text="不看他的动态" CommandName="no1" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                     <td><asp:LinkButton ID="LinkButton4" runat="server" Text="看他的动态" CommandName="yes1" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                    
                    <td><asp:LinkButton ID="LinkButton6" runat="server" Text="取消特别关心" CommandName="s2" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
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
             <asp:Button ID="Back" runat="server" Text="返回" PostBackUrl="~/Visiter.aspx" />
             <asp:Repeater id="repeater1" runat ="server" OnItemCommand="repeater1_ItemCommand" Visible ="false" >
          <HeaderTemplate> 
                <table>
                    <tr>
                        <th>账号</th>
                         <th>昵称</th>
                        <th>头像</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr><td><%# Eval("friendID")%></td>
                    <td><%# Eval("friendname")%></td>
                    <td><asp:ImageButton ID="Image2" runat="server" ImageUrl='<%#Eval("picture")%>' Width="100" Height="80" PostBackUrl='<%#"Visiter1.aspx?id="+Eval("friendID") %>'/></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" Text="不让他看我的动态" CommandName="no" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton2" runat="server" Text="让他看我的动态" CommandName="yes" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                     <td><asp:LinkButton ID="LinkButton3" runat="server" Text="不看他的动态" CommandName="no1" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                     <td><asp:LinkButton ID="LinkButton4" runat="server" Text="看他的动态" CommandName="yes1" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton5" runat="server" Text="设为特别关心" CommandName="s1" CommandArgument='<%#Eval("friendID") %>'></asp:LinkButton></td>
                   
               </tr>
             </ItemTemplate>

             <FooterTemplate>
               </table>

            </FooterTemplate>
      </asp:Repeater>
        <div id="Div1" runat ="server" visible ="false">
                    <br />
                    <br />
            &nbsp;<asp:Button ID="btnBefore1" runat="server" Text="上一页"  OnClick="btnBefore1_Click" Width="68px"/>  
    &nbsp;  
    <asp:Button ID="btnNext1" runat="server" Text="下一页" OnClick="btnNext1_Click" Width="64px" />  
        &nbsp;  
        <asp:Button ID="butTop1" runat="server" Text="首页" OnClick="butTop1_Click" />  
         &nbsp;  
         <asp:Button ID="btnFinal1" runat="server" Text="尾页" OnClick="btnFinal1_Click" />  
        &nbsp;  
        当前页为：<asp:Label ID="lblCurrentPage1" runat="server" Text="Label"></asp:Label> 
                共<asp:Label ID="labPage1" runat="server" Text="Label"></asp:Label>页 转到 <asp:TextBox ID="paper1" runat ="server" Width="37px" ></asp:TextBox>页
            <asp:Button ID ="paperturn1" runat ="server" Text ="跳转" OnClick ="paperturn1_Click" Width="63px" />
             <asp:Button ID="Back1" runat="server" Text="返回" PostBackUrl="~/Visiter.aspx" />
    </div>
    </div>
         <br />
         <asp:Button ID="Button1" runat="server" Text="返回" PostBackUrl="~/Space.aspx" />
          &nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button2" runat="server" Text="添加好友" PostBackUrl="~/Newfriend.aspx"/>
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
