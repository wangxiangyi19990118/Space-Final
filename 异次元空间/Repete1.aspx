<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Repete1.aspx.cs" Inherits="Repete" %>

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
    我的回复：<FTB:FreeTextBox ID="rpt1" runat="server"></FTB:FreeTextBox>
        <asp:Button ID="Button1" runat="server" Text="回复" OnClick ="Button1_Click" />
    </div>
                <asp:Button ID="Back" runat="server" Text="返回我的空间" PostBackUrl="~/Space.aspx" />
    </form>
    <p>
        Copyright © 2016 - 2016 定不负相思懿.All Rights Reserved.
    </p>
</body>
</html>
