<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 268px;
        }
        .auto-style2 {
            width: 271px;
        }
        .auto-style3 {
            width: 99%;
        }
    </style>
</head>
<body style="width: 399px">
    <form id="form1" runat="server">
        <table class="auto-style3">
            <caption>
                LOGIN</caption>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="                    USUARIO"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txbUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="                    CONTRASEÑA"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txbContraseña" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="INGRESAR" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="btnOlvidar" runat="server" OnClick="btnOlvidar_Click" Text="¿OLVIDO SU CONTRASEÑA O USUARIO?" Width="276px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="REGISTRAR USUARIO" />
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
