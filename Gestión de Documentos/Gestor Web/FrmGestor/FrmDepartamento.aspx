<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDepartamento.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmDepartamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 265px;
        }
        .auto-style3 {
            width: 309px;
        }
        .auto-style11 {
            width: 509px;
        }
        .auto-style2 {
            width: 494px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table style="width:100%;">
                <caption>
                    <strong>GESTOR DEL DEPARTAMENTO</strong></caption>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;nombre de la organizacion</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="cbxDepartamento_organizacion" runat="server" Height="16px" Width="171px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnOrganizacion" runat="server" Text="ORGANIZACION" Width="163px" Height="26px" OnClick="btnOrganizacion_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        Nombre del departamento</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDepartamento_nombre" runat="server" Width="167px"></asp:TextBox>
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCodigo" runat="server" Text="CODIGO" Width="163px" OnClick="btnCodigo_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        tipo del departamento</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDepartamento_tipo" runat="server" Width="164px"></asp:TextBox>
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnIdioma" runat="server" Text="IDIOMA" Width="162px" OnClick="btnIdioma_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        descripcion del departamento</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDepartamento_descripcion" runat="server" Width="162px"></asp:TextBox>
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnDepartamento" runat="server" Text="DEPARTAMENTO" OnClick="btnDepartamento_Click" Width="163px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnEmpleado" runat="server" Text="EMPLEADO" Width="162px" OnClick="btnEmpleado_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnTramite" runat="server" Text="TRAMITE" Width="160px" OnClick="btnTramite_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCiclo" runat="server" Text="CICLO" Width="161px" OnClick="btnCiclo_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btDocumento" runat="server" Text="DOCUMENTO" Width="159px" OnClick="btDocumento_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" />
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnmodificar" runat="server" Text="MODIFICAR" OnClick="btnmodificar_Click" />
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCaso" runat="server" Text="CASO" Width="158px" OnClick="btnCaso_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnInactivar" runat="server" Text="INACTIVAR" OnClick="btnInactivar_Click" />
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnActivar" runat="server" Text="ACTIVAR" OnClick="btnActivar_Click" />
                    </td>
                    <td class="auto-style11">
                    <asp:Button ID="Actualizar_datos" runat="server" OnClick="Actualizar_datos_Click" Text="ACTUALIZAR DATOS" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnDetalleCaso" runat="server" Text="DETALLE CASO" Width="160px" OnClick="btnDetalleCaso_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnCargarDatos" runat="server" Text="CARGAR DATOS" OnClick="btnCargarDatos_Click" />
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style11">
                        <asp:CheckBox ID="ckbDepartamento" runat="server" Text="MOSTRAR INACTIVOS" />
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>
                    <asp:Button ID="btnCerrarSecion" runat="server" Text="CERRAR SECIÓN" OnClick="btnCerrarSecion_Click" Width="162px" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvDepartamento" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
