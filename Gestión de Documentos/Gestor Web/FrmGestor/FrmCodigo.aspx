<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCodigo.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmCodigo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 191px;
            height: 26px;
        }
        .auto-style4 {
            width: 208px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
        .auto-style1 {
            width: 191px;
        }
        .auto-style2 {
            width: 208px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            height: 26px;
            width: 184px;
        }
        .auto-style13 {
            width: 184px;
        }
        .auto-style20 {
            width: 479px;
            height: 26px;
        }
        .auto-style21 {
            width: 479px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <caption>
                <strong>GESTOR DEL CODIGO</strong></caption>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style11">
                </td>
                <td class="auto-style20">
                    &nbsp;</td>
                <td class="auto-style20">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Nombre de la organizacion</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="cbxCodigo_organizacion" runat="server" Height="24px" Width="182px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style11">
                    &nbsp;</td>
                <td class="auto-style20">
                    &nbsp;</td>
                <td class="auto-style20">
                    &nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="btnOrganizacion" runat="server" Text="ORGANIZACION" Width="163px" OnClick="btnOrganizacion_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">formato del odigo</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCodigo_Codigo_formato" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>
                    <asp:Button ID="btnCodigo" runat="server" Text="CODIGO" Width="161px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>
                    <asp:Button ID="btnIdioma" runat="server" Text="IDIOMA" Width="162px" OnClick="btnIdioma_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>
                    <asp:Button ID="btnDepartamento" runat="server" Text="DEPARTAMENTO" OnClick="btnDepartamento_Click" Width="163px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style13">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnEmpleado" runat="server" Text="EMPLEADO" Width="162px" OnClick="btnEmpleado_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style13">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnTramite" runat="server" Text="TRAMITE" Width="160px" OnClick="btnTramite_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style13">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnCiclo" runat="server" Text="CICLO" Width="161px" OnClick="btnCiclo_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style13">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btDocumento" runat="server" Text="DOCUMENTO" Width="159px" OnClick="btDocumento_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                        <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" />
                </td>
                <td class="auto-style2">
                        <asp:Button ID="btnModificar" runat="server" Text="MODIFICAR" OnClick="btnModificar_Click" />
                </td>
                <td class="auto-style13">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnCaso" runat="server" Text="CASO" Width="158px" OnClick="btnCaso_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                        <asp:Button ID="btnInactivar" runat="server" Text="INACTIVAR" OnClick="btnInactivar_Click" />
                </td>
                <td class="auto-style2">
                        <asp:Button ID="btnActivar" runat="server" Text="ACTIVAR" OnClick="btnActivar_Click" />
                </td>
                <td class="auto-style13">
                    <asp:Button ID="Actualizar_datos" runat="server" OnClick="Actualizar_datos_Click" Text="ACTUALIZAR TABLA" />
                </td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnDetalleCaso" runat="server" Text="DETALLE CASO" Width="160px" OnClick="btnDetalleCaso_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                        <asp:Button ID="btnCargarDatos" runat="server" Text="CARGAR DATOS" OnClick="btnCargarDatos_Click" />
                </td>
                <td class="auto-style2">
                        <asp:DropDownList ID="ddlCodigo" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                </td>
                <td class="auto-style13">
                        <asp:CheckBox ID="ckbCodigo" runat="server" Text="MOSTRAR INACTIVOS" />
                </td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnCerrarSecion" runat="server" Text="CERRAR SECIÓN" OnClick="btnCerrarSecion_Click" Width="166px" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvCodigo" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
