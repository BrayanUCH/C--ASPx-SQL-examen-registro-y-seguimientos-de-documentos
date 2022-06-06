<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDocumento.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmDocumento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 661px;
        }
        .auto-style2 {
            width: 668px;
        }
        .auto-style4 {
            width: 232px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            width: 303px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <caption>
                    <strong>GESTOR DE DOCUMENTOS </strong>
                </caption>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label1" runat="server" Text="Nombre del tramite"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:DropDownList ID="cbxDocumento_TramiteId" runat="server" Height="16px" Width="134px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnOrganizacion" runat="server" Text="ORGANIZACION" Width="163px" Height="26px" OnClick="btnOrganizacion_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label2" runat="server" Text="Nombre del idioma"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:DropDownList ID="cbxDocumento_IdiomaId" runat="server" Height="16px" Width="137px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCodigo" runat="server" Text="CODIGO" Width="163px" OnClick="btnCodigo_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label3" runat="server" Text="Nombre del documento"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtDocumento_nombre" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnIdioma" runat="server" Text="IDIOMA" Width="162px" OnClick="btnIdioma_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label4" runat="server" Text="Ruta del documento"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtDocumento_ruta" runat="server"></asp:TextBox>
                       </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnDepartamento" runat="server" Text="DEPARTAMENTO" OnClick="btnDepartamento_Click" Width="163px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label5" runat="server" Text="Tipo del documento"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtDocumento_tipo" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnEmpleado" runat="server" Text="EMPLEADO" Width="162px" OnClick="btnEmpleado_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnTramite" runat="server" Text="TRAMITE" Width="160px" OnClick="btnTramite_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCiclo" runat="server" Text="CICLO" Width="161px" OnClick="btnCiclo_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btDocumento" runat="server" Text="DOCUMENTO" Width="159px" OnClick="btDocumento_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" />
                    </td>
                    <td class="auto-style11">
                        <asp:Button ID="btnmodificar" runat="server" Text="MODIFICAR" OnClick="btnmodificar_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCaso" runat="server" Text="CASO" Width="158px" OnClick="btnCaso_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="btnInactivar" runat="server" Text="INACTIVAR" OnClick="btnInactivar_Click" />
                    </td>
                    <td class="auto-style11">
                        <asp:Button ID="btnActivar" runat="server" Text="ACTIVAR" OnClick="btnActivar_Click" />
                    </td>
                    <td class="auto-style2">
                    <asp:Button ID="Actualizar_datos" runat="server" OnClick="Actualizar_datos_Click" Text="ACTUALIZAR DATOS" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnDetalleCaso" runat="server" Text="DETALLE CASO" Width="160px" OnClick="btnDetalleCaso_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="btnCargarDatos" runat="server" Text="CARGAR DATOS" OnClick="btnCargarDatos_Click" />
                    </td>
                    <td class="auto-style11">
                        <asp:DropDownList ID="ddlDocumento" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:CheckBox ID="ckbDocumento" runat="server" Text="MOSTRAR INACTIVOS" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCerrarSecion" runat="server" Text="CERRAR SECIÓN" OnClick="btnCerrarSecion_Click" Width="162px" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvDocumento" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
