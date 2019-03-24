<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" >
    <script type="text/javascript" src="~/scripts/jquery-3.3.1.min.js"></script>

    <link rel="stylesheet" href="../style/WebForm1Css.css"/>
    
  

</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                        <a class="nav-link" href="HomePage.aspx">Home</a>
                </li>
                <li class="nav-item" >
                    <div id="block">
                        <asp:Label runat="server" ID="nameBookLabel" CssClass="nav-link"></asp:Label>
                    </div>
                </li>
            </ul>
        </nav>
    </div>
        
        <div class="container" id="main_block">
            
            <div id="container1">
                <asp:Image runat="server" Id="aulbum" Width="220px" Height="300px"/>
                <div class="block">
                        <asp:Button runat="server" ID="editing"  CssClass="btn btn-outline-warning" Text="Редактирование" OnClick="editing_OnClick"/>
                        <asp:Button runat="server" ID="delete" CssClass="btn btn-outline-danger" Text="Удаление" OnClick="delete_OnClick" OnClientClick="return confirm('Вы уверенны?')"/>
                </div>
            </div>
            <div id="annotation">
                <asp:Label runat="server" ID="annotationLabel"></asp:Label>
            </div>
            <div id="read_load">
                    <asp:Button runat="server" ID="read" CssClass="btn btn-outline-primary" Text="Читать Онлайн" OnClick="read_OnClick"/>
                    <asp:Button runat="server" ID="load" CssClass="btn btn-primary" Text="Скачать" OnClick="load_OnClick"/>
            </div>
        </div>
        
    </form>
</body>
</html>
