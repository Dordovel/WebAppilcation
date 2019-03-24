<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication.HomePage" EnableEventValidation="false" EnableViewState="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script type="text/javascript" src="../scripts/jquery-3.3.1.min.js"></script>
    <link rel="stylesheet" href="../style/StyleSheet1.css"/>
    <script type="text/javascript" src="../scripts/HomePageScript.js"></script>
    <link rel="stylesheet" href="../Content/bootstrap.min.css" >
   

</head>
<body style="background-color: rgb(0,30,50)">
    <form id="form1" runat="server">
        <div>
    
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="HomePage.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AddPage.aspx">Загрузить книгу</a>
                    </li>
                </ul>
                <div id="searchBlock">
                    <form class="form-inline my-2 my-lg-0">
                        <asp:TextBox runat="server" ID="search" CssClass="form-control mr-sm-2" placeholder="Search" aria-label="Search"/>
                        <asp:Button runat="server" ID="buttonSearch" CssClass="btn btn-warning my-2 my-sm-0" Text="Search" OnClick="buttonFormSearch_OnClick"></asp:Button>
                    </form>
                </div>
             </nav>
        </div>
        
        <asp:Panel runat="server" id="filter">
        </asp:Panel>
        
        <asp:PlaceHolder runat="server"  ID="placeHolder"></asp:PlaceHolder>

    </form>
</body>
</html>
