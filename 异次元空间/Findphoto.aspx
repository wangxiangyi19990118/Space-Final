﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Findphoto.aspx.cs" Inherits="Findphoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    上传相片：<asp:FileUpload id="upload1" runat="server" /><asp:Button ID="newphoto" runat="server" Text="添加" OnClick="newphoto_Click" />
        <br />
     相片
        <asp:Repeater id="repeaterdiary" runat ="server" Visible="false">
          <HeaderTemplate> 
                <table>
                    <tr>
                        <th>名称</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("photo")%>' Width="100" Height="80"/></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除"  CommandName="Delete"  CommandArgument='<%#Eval("id1") %>' OnClick="lbtDelete_Click"></asp:LinkButton></td>
                    
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
             <asp:Button ID="Back" runat="server" Text="返回" PostBackUrl="~/Space.aspx" />
    </div>
         <br />
         <asp:Button ID="Button1" runat="server" Text="返回" PostBackUrl="~/Photo.aspx" />
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
