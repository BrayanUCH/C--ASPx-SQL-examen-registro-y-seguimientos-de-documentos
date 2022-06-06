7<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmOrganizacion.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmOrganizacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 194px;
        }
        .auto-style4 {
            width: 194px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
            width: 330px;
        }
        .auto-style7 {
            width: 330px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            height: 26px;
            width: 656px;
        }
        .auto-style12 {
            width: 656px;
        }
        .auto-style13 {
            width: 274px;
            height: 26px;
        }
        .auto-style14 {
            width: 274px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <caption>
                <strong>GESTOR DE LA ORGANIZACIÓN</strong></caption>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style11">
                </td>
                <td class="auto-style6">
                    &nbsp;</td>
          &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <asp:Label ID="Label1" runat="server" Text="Nombre de la organizacion"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtOrganizacion_nombre" runat="server" Width="174px"></asp:TextBox>
                </td>
                <td class="auto-style11">
                </td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="btnOrganizacion" runat="server" Text="ORGANIZACION" Width="163px" Height="26px" OnClick="btnOrganizacion_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    <asp:Label ID="Label2" runat="server" Text="Tipo de la organizacion"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtOrganizacion_tipo" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>
                    <asp:Button ID="btnCodigo" runat="server" Text="CODIGO" Width="163px" OnClick="btnCodigo_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    <asp:Label ID="Label3" runat="server" Text="Descripcion de la organizacion"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtOrganizacion_descripcion" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>
                    <asp:Button ID="btnIdioma" runat="server" Text="IDIOMA" Width="162px" OnClick="btnIdioma_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>
                    <asp:Button ID="btnDepartamento" runat="server" Text="DEPARTAMENTO" OnClick="btnDepartamento_Click" Width="163px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnEmpleado" runat="server" Text="EMPLEADO" Width="162px" OnClick="btnEmpleado_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnTramite" runat="server" Text="TRAMITE" Width="160px" OnClick="btnTramite_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnCiclo" runat="server" Text="CICLO" Width="161px" OnClick="btnCiclo_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btDocumento" runat="server" Text="DOCUMENTO" Width="159px" OnClick="btDocumento_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                        <asp:Button ID="BtnInsertar" runat="server" Text="INSERTAR" OnClick="Button1_Click" />
                    </td>
                <td class="auto-style2">
                        <asp:Button ID="BtnModificar" runat="server" Text="MODIFICAR" OnClick="BtnModificar_Click" />
                    </td>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnCaso" runat="server" Text="CASO" Width="158px" OnClick="btnCaso_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                        <asp:Button ID="BtnInactivar" runat="server" Text="INACTIVAR" OnClick="BtnInactivar_Click" />
                    </td>
                <td class="auto-style2">
                        <asp:Button ID="BtnActivar" runat="server" Text="ACTIVAR" OnClick="BtnActivar_Click" />
                    </td>
                <td class="auto-style12">
                    <asp:Button ID="Actualizar_datos" runat="server" OnClick="Actualizar_datos_Click" Text="ACTUALIZAR DATOS" />
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnDetalleCaso" runat="server" Text="DETALLE CASO" Width="160px" OnClick="btnDetalleCaso_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                        <asp:Button ID="BtnCargarDatos" runat="server" Text="CARGAR DATOS" OnClick="BtnCargarDatos_Click" />
                    </td>
                <td class="auto-style2">
                        <asp:DropDownList ID="ddlOrganizacion" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                    </td>
                <td class="auto-style12">
                        <asp:CheckBox ID="ckbOrganizacion" runat="server" Text="MOSTRAR INACTIVOS" OnCheckedChanged="ckbOrganizacion_CheckedChanged" />
                    </td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnCerrarSecion" runat="server" Text="CERRAR SECIÓN" OnClick="btnCerrarSecion_Click" Width="162px" />
                </td>
            </tr>
        </table>
        <div>
        </div>
        <asp:GridView ID="gvOrganizacion" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
