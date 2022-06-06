<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOlvidarCotra.aspx.cs" Inherits="Gestor_Web.FrmGestor.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 198px;
        }
        .auto-style3 {
            width: 99%;
        }
        .auto-style4 {
            width: 498px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style4">
        <div>
            <table class="auto-style3">
                <caption>
                    USUARIO CONTRASEÑA OLVIDADO</caption>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>DIGITE SU CORREO ELECTRONICO</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txbCorreo" runat="server" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnVerificar" runat="server" OnClick="Button1_Click" Text="VEREFICAR" Width="135px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnLimpiarDatos" runat="server" OnClick="Button2_Click" Text="LIMPIAR DATOS" Width="135px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">USUARIO</td>
                    <td>
                        <asp:Label ID="lblUsuario" runat="server" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">CONTRASEÑA</td>
                    <td>
                        <asp:Label ID="lblContraseña" runat="server" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnVolverLogin" runat="server" OnClick="Button3_Click" Text="VOLVER AL LOGIN" Width="136px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
