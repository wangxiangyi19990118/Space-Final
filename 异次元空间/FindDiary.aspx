<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindDiary.aspx.cs" Inherits="FindDiary" %>

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
     &nbsp;&nbsp; 标题：<asp:Label ID="txttitle" runat="server" Text="Label"></asp:Label>
        <br />
        
        <br />
        &nbsp;&nbsp;
        摘要：<asp:Label ID="txttip" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;
        分类：<asp:Label ID="class10" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
    &nbsp;&nbsp;
    正文：<FTB:FreeTextBox ID="txtmatter" runat="server" ReadOnly="true"></FTB:FreeTextBox>
       
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="update" runat="server" Text="编辑" PostBackUrl="~/UpdateDiary.aspx"/>
        &nbsp;
        <asp:Button ID="back" runat="server" Text="返回" PostBackUrl="~/Dairy.aspx" />
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
