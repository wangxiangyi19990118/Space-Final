<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateSays.aspx.cs" Inherits="UpdateSays" validateRequest="false" %>

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
       
    正文： <FTB:FreeTextBox ID="txtmatter" runat="server"></FTB:FreeTextBox>
        <br />
        <br /> <asp:Button ID="insert" runat="server" Text="保存" onclick="insert_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="back" runat="server" Text="返回" PostBackUrl="~/Says.aspx" />
    </div>
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
