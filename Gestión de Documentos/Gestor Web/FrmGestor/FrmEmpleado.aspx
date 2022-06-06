<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEmpleado.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 230px;
        }
        .auto-style2 {
            width: 160px;
        }
        .auto-style3 {
            width: 760px;
        }
        .auto-style4 {
            width: 551px;
        }
        .auto-style5 {
            width: 230px;
            height: 30px;
        }
        .auto-style6 {
            width: 160px;
            height: 30px;
        }
        .auto-style7 {
            width: 760px;
            height: 30px;
        }
        .auto-style8 {
            width: 551px;
            height: 30px;
        }
        .auto-style9 {
            height: 30px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            width: 230px;
            height: 131px;
        }
        .auto-style12 {
            width: 160px;
            height: 131px;
        }
        .auto-style13 {
            width: 760px;
            height: 131px;
        }
        .auto-style14 {
            width: 551px;
            height: 131px;
        }
        .auto-style15 {
            height: 131px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <caption>
                    <strong>GESTOR DEL EMPLEADO</strong></caption>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="Nombre del departamento"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="cbxEmpleado_Departamento_id" runat="server" Height="16px" Width="152px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnOrganizacion" runat="server" Text="ORGANIZACION" Width="163px" Height="26px" OnClick="btnOrganizacion_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="Nombre del empleado"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtEmpleado_nombre" runat="server" Width="143px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCodigo" runat="server" Text="CODIGO" Width="163px" OnClick="btnCodigo_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Apellidos delempleado"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtEmpleado_apellidos" runat="server" Width="142px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnIdioma" runat="server" Text="IDIOMA" Width="162px" OnClick="btnIdioma_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label1" runat="server" Text="FechaNacimiento delEmpleado"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:Calendar ID="dateEmpleado_fechaNacimiento" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="16px" Width="200px">
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
                    <td class="auto-style13"></td>
                    <td class="auto-style14"></td>
                    <td class="auto-style15">
                    <asp:Button ID="btnDepartamento" runat="server" Text="DEPARTAMENTO" OnClick="btnDepartamento_Click" Width="163px" />
                    <asp:Button ID="btnEmpleado" runat="server" Text="EMPLEADO" Width="162px" OnClick="btnEmpleado_Click" />
                    <asp:Button ID="btnTramite" runat="server" Text="TRAMITE" Width="160px" OnClick="btnTramite_Click" />
                    <asp:Button ID="btnCiclo" runat="server" Text="CICLO" Width="161px" OnClick="btnCiclo_Click" />
                    <asp:Button ID="btDocumento" runat="server" Text="DOCUMENTO" Width="159px" OnClick="btDocumento_Click" />
                    <asp:Button ID="btnCaso" runat="server" Text="CASO" Width="158px" OnClick="btnCaso_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server" Text="Puesto del empleado"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtEmpleado_puesto" runat="server" Width="140px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnDetalleCaso" runat="server" Text="DETALLE CASO" Width="160px" OnClick="btnDetalleCaso_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label6" runat="server" Text="Genero del Empleado"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="cbxEmpleado_genero" runat="server" Height="16px" Width="152px">
                            <asp:ListItem>Masculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Otros</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label7" runat="server" Text="EstadoCivil del Empleado"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="cbxEmpleado_estadoCivil" runat="server" Height="16px" Width="152px">
                            <asp:ListItem>Soltero/a</asp:ListItem>
                            <asp:ListItem>Casado/a</asp:ListItem>
                            <asp:ListItem>Divorsiado/a</asp:ListItem>
                            <asp:ListItem>Viudo/a</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label8" runat="server" Text="FechaIngreso del Empleado"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Calendar ID="dateEmpleado_fechaIngreso" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="16px" Width="200px">
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
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" />
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnmodificar" runat="server" Text="MODIFICAR" OnClick="btnmodificar_Click" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnInactivar" runat="server" Text="INACTIVAR" OnClick="btnInactivar_Click" />
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnActivar" runat="server" Text="ACTIVAR" OnClick="btnActivar_Click" />
                    </td>
                    <td class="auto-style3">
                    <asp:Button ID="Actualizar_datos" runat="server" OnClick="Actualizar_datos_Click" Text="ACTUALIZAR DATOS" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="btnCargarDatos" runat="server" Text="CARGAR DATOS" OnClick="btnCargarDatos_Click" />
                    </td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="ddlEmpleado" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style7">
                        <asp:CheckBox ID="ckbEmpleado" runat="server" Text="MOSTRAR INACTIVOS" />
                    </td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style9">
                    <asp:Button ID="btnCerrarSecion" runat="server" Text="CERRAR SECIÓN" OnClick="btnCerrarSecion_Click" Width="162px" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvEmpleado" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
