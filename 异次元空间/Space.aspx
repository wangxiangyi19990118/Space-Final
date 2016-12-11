<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Space.aspx.cs"  Inherits="Space" %>

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
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbname" runat="server"></asp:Label>
        
        
        欢迎来到异次元空间！<br />
&nbsp;<asp:linkbutton runat="server" ID="says" PostBackUrl="~/Says.aspx">说说</asp:linkbutton>
         &nbsp;&nbsp;
         <asp:linkbutton runat="server" ID ="dairy" PostBackUrl ="~/Dairy.aspx">日志</asp:linkbutton>
         &nbsp;&nbsp;
         <asp:linkbutton runat="server" ID ="inf" PostBackUrl ="~/Information.aspx">个人信息</asp:linkbutton>
         &nbsp;&nbsp;
         <asp:linkbutton runat="server" ID="photo" PostBackUrl ="~/Photo.aspx">相册</asp:linkbutton>
        &nbsp;&nbsp;&nbsp;
        <asp:linkbutton runat="server" ID="massage" PostBackUrl ="~/massage.aspx">留言板</asp:linkbutton>
         &nbsp;&nbsp;&nbsp;
         <asp:linkbutton runat="server" ID="find" PostBackUrl ="~/Friend.aspx">我的好友</asp:linkbutton>
        &nbsp;&nbsp;&nbsp;
        <asp:linkbutton runat="server" ID="back" onclick="back_Click">退出登录</asp:linkbutton>
        
    </div>
        <div id="special" runat ="server"  >
            我的特别关心：
             <asp:Repeater ID ="Repeater2" runat ="server" OnItemDataBound="Repeater2_ItemDataBound" OnItemCommand="Repeater2_ItemCommand" >
              <HeaderTemplate> 
                <table>
                    <tr>
                       <th>特别关心头像</th>
                        <th>特别关心账号</th>
                        <th>特别关心昵称</th>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>   
                     <td><asp:ImageButton ID="Image2" runat="server" ImageUrl='<%#Eval("picture")%>' Width="100" Height="80"  PostBackUrl='<%#"Visiter.aspx?id="+Eval("id") %>'/></td>
                    <td><%# Eval("userID")%></td>
                    <td><%# Eval("name")%></td>
                      <td><%# Eval("title")%></td>
                    <td><%# Eval("tip")%></td>
                    <td><FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text ='<%# Eval("matter")%>' ReadOnly ="true" ButtonPath="/images/" ></FTB:FreeTextBox></td>

                    <td><%# Eval("datetime")%></td>
                              <td><%# Eval("good")%>个赞</td>
                   <td><asp:LinkButton ID="LinkButton2" runat="server" Text="评论" PostBackUrl='<%#"Repete.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" Text="访问他的空间" PostBackUrl='<%#"Visiter.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                   <td><asp:LinkButton ID="LinkButton3" runat="server" Text="赞" CommandName="yes" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
                     <td><asp:LinkButton ID="LinkButton4" runat="server" Text="转载" CommandName="yes1" CommandArgument='<%#Eval("id") %>' OnClick ="LinkButton4_Click"></asp:LinkButton></td>
                    <asp:Repeater ID="friend02" runat="server" >
                    <HeaderTemplate> 
                <table>
                    <tr>
                        <th>评论</th>
                         <th>头像</th>
                        <th>账号</th>
                        <th>昵称</th>
                        <th>内容</th>
                        <th>时间</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr> 
                   <td></td>
                    <td><asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("picture1")%>' Width="100" Height="80" /></td>
                     <td><%# Eval("id0")%></td>
                    <td><%# Eval("name")%></td>
                     
                    <td><%# Eval("rptmatter")%></td>
                    
                    <td><%# Eval("datetime")%></td>
          
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
        我是<asp:Label ID="Lacount" runat="server" Text="Label"></asp:Label>人的特别关心

        </div>
    <div id="friend" runat ="server" >
      好友请求：
         <asp:Repeater ID ="Repeater1" runat ="server" OnItemCommand="Repeater1_ItemCommand" Visible ="false" >
              <HeaderTemplate> 
                <table>
                    <tr> <th>头像</th>
                        <th>账号</th>
                        <th>昵称</th>
                        <th>备注</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>  
                     <td><asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("picture")%>' Width="100" Height="80"/></td>
                    <td><%# Eval("ID")%></td>
                    <td><%# Eval("name")%></td>
                      <td><%# Eval("massage")%></td>
                    
                  
                   <td><asp:LinkButton ID="LinkButton2" runat="server" Text="同意" CommandName="yes" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" Text="不同意" CommandName="no" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton></td>
                  
             </ItemTemplate>
             <FooterTemplate>
              
            </FooterTemplate>
        </asp:Repeater>
      好友动态：
        <asp:Repeater ID ="friend1" runat ="server" OnItemDataBound="friend1_ItemDataBound" >
              <HeaderTemplate> 
                <table>
                    <tr>
                         <th>好友头像</th>
                        <th>好友账号</th>
                        <th>好友昵称</th>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>  <th>好友昵称</th>
                     <td><asp:ImageButton ID="Image2" runat="server" ImageUrl='<%#Eval("picture")%>' Width="100" Height="80"  PostBackUrl='<%#"Visiter.aspx?id="+Eval("id") %>'/></td>
                    <td><%# Eval("userID")%></td>
                    <td><%# Eval("name")%></td>
                      <td><%# Eval("title")%></td>
                    <td><%# Eval("tip")%></td>
                 
                    <td><FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text ='<%# Eval("matter")%>' ReadOnly ="true" ></FTB:FreeTextBox></td>
                    <td><%# Eval("datetime")%></td>
                    <td><%# Eval("id4")%></td>
                     <td><%# Eval("good")%>个赞</td>
                   <td><asp:LinkButton ID="LinkButton2" runat="server" Text="评论" PostBackUrl='<%#"Repete.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" Text="访问他的空间" PostBackUrl='<%#"Visiter.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton3" runat="server" Text="赞" CommandName="yes" CommandArgument='<%#Eval("id") %>' OnClick ="LinkButton3_Click"></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton4" runat="server" Text="转载" CommandName="yes" CommandArgument='<%#Eval("id") %>' OnClick ="LinkButton4_Click"></asp:LinkButton></td>
                    <asp:Repeater ID="friend2" runat="server" >
                    <HeaderTemplate> 
                <table>
                    <tr>
                        
                         <th>评论</th>
                         <th>头像</th>
                        <th>账号</th>
                        <th>昵称</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr> <td></td>
                    <td><asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("picture1")%>' Width="100" Height="80" /></td>
                    <td><%# Eval("name")%></td>
                     
                    <td><%# Eval("rptmatter")%></td>
                    
                    <td><%# Eval("datetime")%></td>
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
        <asp:Button ID="Button1" runat="server" Text="添加好友" PostBackUrl="~/Newfriend.aspx"/>
        </form >
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>

</html>
