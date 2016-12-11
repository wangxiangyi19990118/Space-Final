<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WriteDiary.aspx.cs" Inherits="WriteDiary" validaterequest="false" %>

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
        &nbsp;&nbsp; 标题：<asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        摘要：<asp:TextBox ID="txttip" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        分类：<asp:DropDownList ID="class1" runat="server">
              <asp:ListItem>随笔</asp:ListItem>
    <asp:ListItem>心情</asp:ListItem>
            <asp:ListItem Selected="True">感悟</asp:ListItem>
            <asp:ListItem>游记</asp:ListItem>
     <asp:ListItem>其他</asp:ListItem>
           </asp:DropDownList>
        <br />
        <br />
    &nbsp;&nbsp;
    正文：<FTB:FreeTextBox ID="txtmatter" runat="server"></FTB:FreeTextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="insert" runat="server" Text="发表" onclick="insert_Click" />
         &nbsp;
         <asp:Button ID="back" runat="server" Text="返回" PostBackUrl="~/Dairy.aspx" />
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
