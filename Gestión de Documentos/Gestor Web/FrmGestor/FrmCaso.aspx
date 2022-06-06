<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCaso.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmCaso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 660px;
        }
        .auto-style2 {
            width: 777px;
        }
        .auto-style10 {
            width: 235px;
        }
        .auto-style12 {
            width: 432px;
        }
        .auto-style14 {
            width: 166px;
        }
        .auto-style15 {
            width: 166px;
            height: 191px;
        }
        .auto-style16 {
            width: 432px;
            height: 191px;
        }
        .auto-style17 {
            width: 777px;
            height: 191px;
        }
        .auto-style18 {
            width: 660px;
            height: 191px;
        }
        .auto-style19 {
            height: 191px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <caption>
                    <strong>GESTOR DEL CASO</strong></caption>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="Label1" runat="server" Text="Nombre del tramite"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:DropDownList ID="cbxCaso_TramiteId" runat="server" Height="16px" Width="144px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnOrganizacion" runat="server" Text="ORGANIZACION" Width="163px" Height="26px" OnClick="btnOrganizacion_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="Label2" runat="server" Text="Codigo del caso"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtCaso_Codigo" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="Button16" runat="server" Text="GENERAR CODIGO" Width="156px" OnClick="Button16_Click" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCodigo" runat="server" Text="CODIGO" Width="163px" OnClick="btnCodigo_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="Label3" runat="server" Text="Fecha Inicio del caso"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:Calendar ID="dtpCaso_fechaInicio" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </td>
                    <td class="auto-style17"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style19">
                    <asp:Button ID="btnIdioma" runat="server" Text="IDIOMA" Width="162px" OnClick="btnIdioma_Click" />
                    <asp:Button ID="btnDepartamento" runat="server" Text="DEPARTAMENTO" OnClick="btnDepartamento_Click" Width="163px" />
                    <asp:Button ID="btnEmpleado" runat="server" Text="EMPLEADO" Width="162px" OnClick="btnEmpleado_Click" />
                    <asp:Button ID="btnTramite" runat="server" Text="TRAMITE" Width="160px" OnClick="btnTramite_Click" />
                    <asp:Button ID="btnCiclo" runat="server" Text="CICLO" Width="161px" OnClick="btnCiclo_Click" />
                    <asp:Button ID="btDocumento" runat="server" Text="DOCUMENTO" Width="159px" OnClick="btDocumento_Click" />
                    <asp:Button ID="btnCaso" runat="server" Text="CASO" Width="158px" OnClick="btnCaso_Click" />
                    <asp:Button ID="btnDetalleCaso" runat="server" Text="DETALLE CASO" Width="160px" OnClick="btnDetalleCaso_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="Label4" runat="server" Text="Fecha Final del caso"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:Calendar ID="dtpCaso_fechaFinal" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </td>
                    <td class="auto-style2"></td>
                    <td class="auto-style1"></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" />
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnmodificar" runat="server" Text="MODIFICAR" OnClick="btnmodificar_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Button ID="btnInactivar" runat="server" Text="INACTIVAR" OnClick="btnInactivar_Click" />
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnActivar" runat="server" Text="ACTIVAR" OnClick="btnActivar_Click" />
                    </td>
                    <td class="auto-style2">
                    <asp:Button ID="Actualizar_datos" runat="server" OnClick="Actualizar_datos_Click" Text="ACTUALIZAR DATOS" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Button ID="btnCargarDatos" runat="server" Text="CARGAR DATOS" OnClick="btnCargarDatos_Click" />
                    </td>
                    <td class="auto-style12">
                        <asp:DropDownList ID="ddlCaso" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:CheckBox ID="ckbCaso" runat="server" Text="MOSTRAR INACTIVOS" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCerrarSecion" runat="server" Text="CERRAR SECIÓN" OnClick="btnCerrarSecion_Click" Width="162px" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvCaso" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
