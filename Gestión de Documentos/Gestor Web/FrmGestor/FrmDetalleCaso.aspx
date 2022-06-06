<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDetalleCaso.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmDetalleCaso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 147px;
        }
        .auto-style2 {
            width: 494px;
        }
        .auto-style3 {
            width: 309px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            width: 509px;
        }
        .auto-style12 {
            width: 147px;
            height: 160px;
        }
        .auto-style13 {
            width: 309px;
            height: 160px;
        }
        .auto-style14 {
            width: 509px;
            height: 160px;
        }
        .auto-style15 {
            width: 494px;
            height: 160px;
        }
        .auto-style16 {
            height: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <caption>
                    <strong>GESTOR DEL DETALLE DE CASO</strong></caption>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Nombre del caso"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="cbxCaso_id" runat="server" Height="19px" Width="145px">
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
                        <asp:Label ID="Label2" runat="server" Text="Nombre del ciclo"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="cbxCiclo_id" runat="server" Height="19px" Width="146px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCodigo" runat="server" Text="CODIGO" Width="163px" OnClick="btnCodigo_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="Nombre del documento"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="cbxDocumento_id" runat="server" Height="16px" Width="148px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style11"></td>
                    <td class="auto-style2"></td>
                    <td>
                    <asp:Button ID="btnIdioma" runat="server" Text="IDIOMA" Width="162px" OnClick="btnIdioma_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label4" runat="server" Text="Fecha de Recibido"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:Calendar ID="dtpDetalleCaso_fechaRecibido" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
                    <td class="auto-style14"></td>
                    <td class="auto-style15"></td>
                    <td class="auto-style16">
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
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server" Text="Fecha de Transpaso"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Calendar ID="dtpDetalleCaso_fechaTranspaso" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Descripcion</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDetalleCaso_descripcion" runat="server" Width="141px"></asp:TextBox>
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
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
                        &nbsp;</td>
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
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnCargarDatos" runat="server" Text="CARGAR DATOS" OnClick="btnCargarDatos_Click" />
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlDetalleCaso" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style11">
                        <asp:CheckBox ID="ckbDetalleCaso" runat="server" Text="MOSTRAR INACTIVOS" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                    <asp:Button ID="btnCerrarSecion" runat="server" Text="CERRAR SECIÓN" OnClick="btnCerrarSecion_Click" Width="162px" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvDetalleCaso" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
