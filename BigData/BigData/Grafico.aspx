<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafico.aspx.cs" Inherits="BigData.Grafico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div>  
        <script type="text/javascript" src="https://www.google.com/jsapi"></script>
        <script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>        
        <div style="float:left"><asp:Literal ID="ltScripts" runat="server"></asp:Literal></div>
        <div style="float:left"><asp:GridView ID="GridView1" runat="server"></asp:GridView></div>
    </div>
    </form>
</body>
</html>
