<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="WebApplication.Pages.AddPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" >
    <link rel="stylesheet" href="~/style/AddStyle.css">
    <script type="text/javascript" src="~/scripts/jquery-3.3.1.min.js"></script>
    
    <script runat="server">

   

    </script>
    
    <script type="text/javascript">
        window.onload = function () {

            var annotation = $("#annotation");
            var max_size = 999;
            var length = $("#side");

            annotation.keypress(function () {

                var size = annotation.val().length;
                    length.text(size+" / " + max_size);
            });
        }

    </script>

    <style type="text/css">
        .auto-style1 {
            width: 326px;
        }
        .auto-style2 {
            width: 572px;
        }
        .auto-style3 {
            width: 490px;
            margin-left: 0px;
        }
        .auto-style4 {
            width: 499px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="HomePage.aspx">Home</a>
                    </li>
                </ul>
            </nav>
        </div>

        <div class="container" id="container">
            <table>
                <tr>
                    <td class="auto-style2">
                            <asp:TextBox runat="server" placeholder="Название" CssClass="form-control" ID="nameBook" MaxLength="99"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="nameBook" ForeColor="red" ErrorMessage="Поле должно быть заполнено"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                            <asp:TextBox runat="server" placeholder="Автор" CssClass="form-control" ID="author" MaxLength="99"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="author" ForeColor="red" ErrorMessage="Поле должно быть заполнено"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                            <asp:TextBox runat="server" placeholder="Жанр" CssClass="form-control" ID="hangr" MaxLength="299"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="hangr" ForeColor="red" ErrorMessage="Поле должно быть заполнено"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" ID="side"></asp:Label>
                            <asp:TextBox runat="server" placeholder="Краткое описание" CssClass="form-control" ID="annotation" MaxLength="1499" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="annotation" ForeColor="red" ErrorMessage="Поле должно быть заполнено"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="uploadPicturesBlock">
                            <span style="color: darkturquoise">Обложка: </span><asp:FileUpload runat="server" CssClass="btn btn-outline-warning" ID="uploadPictures" Width="440px"/>
                        </div>

                        <div id="uploadFileBlock" class="auto-style4">
                            <p class="auto-style3">
                            <span style="color: darkturquoise">Файл: </span><asp:FileUpload runat="server" CssClass="btn btn-outline-warning" ID="uploadFile" Width="440px"/>
                            </p>
                        </div>
                    </td>
                    <td>
                        <div id="errorBlock">
                            <asp:Label runat="server" ID="error" ForeColor="red"></asp:Label>
                        </div>
                     </td>
                  </tr>
            </table>
            <asp:Button runat="server" ID="upload" OnClick="upload_OnClick" CssClass="btn btn-success" Text="Опубликовать" />
        </div>
    </form>
</body>
</html>
