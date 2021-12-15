<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>INDEX</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <style type="text/css">
        #form1 {
            height: 170px;
        }
    </style>

</head>
<body>
    <asp:Panel ID="Panel1" runat="server" Width="624px" HorizontalAlign="Center">
        <form id="form1" runat="server">
            <div class="container">
                <h2>INICIAR SESIÓN</h2>
            </div>
            <div class="form-group">
                <label for="email">Usuario:</label>&nbsp;
                <label for="email">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="form-group">
                <label for="pwd">Contraseña:</label>
                &nbsp;
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        </form>
    </asp:Panel>    
</body>
</html>
