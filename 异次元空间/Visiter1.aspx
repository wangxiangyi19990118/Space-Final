<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Visiter1.aspx.cs" Inherits="Visiter" %>

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
        <asp:Label ID="Label1" runat="server"></asp:Label>的异次元空间
         
        <br />
        <asp:linkbutton runat="server" ID="says" OnClick ="says_Click">说说</asp:linkbutton>
         &nbsp;&nbsp;
         <asp:linkbutton runat="server" ID ="dairy" OnClick ="dairy_Click">日志</asp:linkbutton>
         &nbsp;&nbsp;
         <asp:linkbutton runat="server" ID ="inf" OnClick ="inf_Click">个人信息</asp:linkbutton>
         &nbsp;&nbsp;
         <asp:linkbutton runat="server" ID="photo" OnClick="photo_Click">相册</asp:linkbutton>
        &nbsp;&nbsp;&nbsp;
        <asp:linkbutton runat="server" ID="massage" OnClick="massage_Click">留言板</asp:linkbutton>

        &nbsp;&nbsp;&nbsp;
        <asp:linkbutton runat="server" ID="back" PostBackUrl ="~/Space.aspx" >返回我的空间</asp:linkbutton>
        <div id="itSays" runat ="server" visible ="false" >
            说说：
        <asp:Repeater ID="itsays1" runat ="server" OnItemDataBound="itsays1_ItemDataBound" >
              <HeaderTemplate> 
                <table>
                    <tr>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>  <th>说说</th>
                    <td><%# Eval("userID")%></td>
                    <td><%# Eval("name")%></td>
                    
                    <td><FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text ='<%# Eval("matter")%>' ReadOnly ="true" ></FTB:FreeTextBox></td>
                    
                    <td><%# Eval("datetime")%></td>
                    <td><%# Eval("good")%> 个赞</td>
                   <td><asp:LinkButton ID="LinkButton2" runat="server" Text="评论" PostBackUrl='<%#"Repete1.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton3" runat="server" Text="赞" CommandName="yes" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton3_Click"></asp:LinkButton></td>
                    <asp:Repeater ID="friend2" runat="server" >
                    <HeaderTemplate> 
                <table>
                    <tr>
                        <th>评论</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr> 
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
              <div id="page1" runat ="server" visible ="false" >
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
    </div>
          <div id ="itdiary" runat ="server" visible ="false" >
              日志
        <asp:Repeater id="repeaterdiary" runat ="server" OnItemDataBound="repeaterdiary_ItemDataBound1">
          <HeaderTemplate> 
                <table>
                    <tr>
                        <th>标题</th>
                        <th>日期</th>
                        <th>摘要</th>
                        <th>分类</th>
                         <th>正文</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("title")%></td>
                    <td><%# Eval("datetime")%></td>
                    <td><%# Eval("tip")%></td>
                     <td><%# Eval("class")%></td>
                     <td><FTB:FreeTextBox ID="FreeTextBox1" runat="server" Text ='<%# Eval("matter")%>' ReadOnly ="true" ></FTB:FreeTextBox></td>
                    <td><%# Eval("good")%> 个赞</td>
                    
                    <td><asp:LinkButton ID="LinkButton2" runat="server" Text="评论" PostBackUrl='<%#"Repete1.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton3" runat="server" Text="赞" CommandName="yes" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton3_Click"></asp:LinkButton></td>
                    <asp:Repeater ID="friend3" runat="server" >
                    <HeaderTemplate> 
                <table>
                    <tr>
                        <th>评论</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr> 
                    <td><%# Eval("name")%></td>
                    <td><%# Eval("rptmatter")%></td>       
                    <td><%# Eval("datetime")%></td>
                    
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
              </div>
                <div id="page2" runat ="server" visible ="false">
                    <br />
                    <br />
            &nbsp;<asp:Button ID="btnBefore1" runat="server" Text="上一页"  OnClick="btnBefore_Click1" Width="68px"/>  
    &nbsp;  
    <asp:Button ID="btnNext1" runat="server" Text="下一页" OnClick="btnNext_Click1" Width="64px" />  
        &nbsp;  
        <asp:Button ID="butTop1" runat="server" Text="首页" OnClick="butTop_Click1" />  
         &nbsp;  
         <asp:Button ID="btnFinal1" runat="server" Text="尾页" OnClick="btnFinal_Click1" />  
        &nbsp;  
        当前页为：<asp:Label ID="lblCurrentPage1" runat="server" Text="Label"></asp:Label> 
                共<asp:Label ID="labPage1" runat="server" Text="Label"></asp:Label>页 转到 <asp:TextBox ID="paper1" runat ="server" Width="37px" ></asp:TextBox>页
            <asp:Button ID ="paperturn1" runat ="server" Text ="跳转" OnClick ="paperturn_Click1" Width="63px" />

        </div>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div id="inf1" runat ="server" visible ="false" >
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
                     
               </tr>
             </ItemTemplate>

             <FooterTemplate>
               </table>

            </FooterTemplate>
     
    </asp:Repeater>
            </div>
        </div>
        <div id="massage1" runat="server" visible ="false" >
            <asp:Repeater id="Repeater1" runat ="server"  >
          <HeaderTemplate> 
                <table>
                    <tr>
                        <th>账号</th>
                        <th>昵称</th>
                        <th>留言时间</th>
                        <th>内容</th>
                        
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID2")%></td>
                    <td><%# Eval("name")%></td>
                    <td><%# Eval("datetime")%></td>
                     <td><%# Eval("massagematter")%></td>
                    
               </tr>
             </ItemTemplate>

             <FooterTemplate>
               </table>

            </FooterTemplate>
     
    </asp:Repeater>
            留言<FTB:FreeTextBox ID="massage2" runat="server"></FTB:FreeTextBox>
            <asp:Button ID="Button1" runat="server" Text="留言" OnClick ="Button1_Click"/>
        </div>
        <div id="picture" runat ="server" visible ="false" >
        相册：
        <asp:Repeater ID="picture2" runat ="server" >
              <HeaderTemplate> 
                <table>
                    <tr>
                        <th>名称</th>
                        <th>日期</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("album")%></td>
                    <td><%# Eval("datetime")%></td>
                     <td><%# Eval("id1")%></td>
                    <td><asp:LinkButton ID="LinkButton2" runat="server" Text="查看" PostBackUrl='<%#"Photo1.aspx?id1="+Eval("id1") %>'></asp:LinkButton></td>
             </ItemTemplate>
             <FooterTemplate>
              
            </FooterTemplate>
        </asp:Repeater>
              <div id="page3" runat ="server" visible ="false" >
                    <br />
                    <br />
            &nbsp;<asp:Button ID="btnBefore2" runat="server" Text="上一页"  OnClick="btnBefore_Click2" Width="68px"/>  
    &nbsp;  
    <asp:Button ID="btnNext2" runat="server" Text="下一页" OnClick="btnNext_Click2" Width="64px" />  
        &nbsp;  
        <asp:Button ID="butTop2" runat="server" Text="首页" OnClick="butTop_Click2" />  
         &nbsp;  
         <asp:Button ID="btnFinal2" runat="server" Text="尾页" OnClick="btnFinal_Click2" />  
        &nbsp;  
        当前页为：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> 
                共<asp:Label ID="lblCurrentPage2" runat="server" Text="Label"></asp:Label>页 转到 <asp:TextBox ID="pape2" runat ="server" Width="37px" ></asp:TextBox>页
            <asp:Button ID ="paperturn2" runat ="server" Text ="跳转" OnClick="paperturn2_Click" Width="63px" />

        </div>
            </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
