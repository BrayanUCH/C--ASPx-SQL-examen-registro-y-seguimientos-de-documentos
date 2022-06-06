<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRegistroLogin.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmRegistroLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            width: 176px;
        }
        .auto-style12 {
            width: 237px;
        }
        .auto-style13 {
            width: 201px;
        }
        .auto-style14 {
            width: 273px;
        }
        .auto-style15 {
            width: 176px;
            height: 26px;
        }
        .auto-style16 {
            width: 237px;
            height: 26px;
        }
        .auto-style17 {
            width: 201px;
            height: 26px;
        }
        .auto-style18 {
            width: 273px;
            height: 26px;
        }
        .auto-style19 {
            height: 26px;
        }
        .auto-style20 {
            width: 75%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style20">
                <caption>
                    <strong>REGISTROS DE</strong> <strong>USUARIO</strong></caption>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="Label1" runat="server" Text="Nombre de usuario"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:TextBox ID="txbUsuario" runat="server" Width="166px"></asp:TextBox>
                    </td>
                    <td class="auto-style17"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txbContrraseña" runat="server" Width="166px"></asp:TextBox>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label3" runat="server" Text="Correo electrónico"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txbCorreo" runat="server" Width="166px"></asp:TextBox>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label4" runat="server" Text="Tipo de usuario"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:DropDownList ID="ddlTipoUsuario" runat="server" Height="16px" Width="166px">
                            <asp:ListItem Value="Administrador"></asp:ListItem>
                            <asp:ListItem>Usuario General</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" />
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnModificar" runat="server" Text="MODIFICAR" OnClick="btnModificar_Click" />
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Button ID="btninactivar" runat="server" Text="INACTIVAR" OnClick="btninactivar_Click" />
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnActivar" runat="server" Text="ACTIVAR" OnClick="btnActivar_Click" />
                    </td>
                    <td class="auto-style13">
                        <asp:Button ID="btnActualizarDatos" runat="server" OnClick="btnActualizarDatos_Click" Text="ACTUALIZAR DATOS" />
                    </td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Button ID="btnCargarDatos" runat="server" Text="CARGAR DATOS" OnClick="btnCargarDatos_Click" />
                    </td>
                    <td class="auto-style12">
                        <asp:DropDownList ID="ddlCargarDatos" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style13">
                        <asp:CheckBox ID="ckbMostrarInactivos" runat="server" Text="MOSTRAR INACTIVOS" />
                    </td>
                    <td class="auto-style14">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnVolverLogin" runat="server" Text="VOLVER AL LOGIN" OnClick="btnVolverLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvLoging" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
