<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmIdioma.aspx.cs" Inherits="Gestor_Web.FrmGestor.FrmIdioma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 167px;
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
            width: 167px;
        }
        .auto-style2 {
            width: 208px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style14 {
            height: 26px;
            width: 492px;
        }
        .auto-style15 {
            width: 492px;
        }
        .auto-style16 {
            width: 167px;
            height: 30px;
        }
        .auto-style17 {
            width: 208px;
            height: 30px;
        }
        .auto-style19 {
            width: 492px;
            height: 30px;
        }
        .auto-style20 {
            height: 30px;
        }
        .auto-style21 {
            width: 435px;
            height: 26px;
        }
        .auto-style22 {
            width: 435px;
            height: 30px;
        }
        .auto-style23 {
            width: 435px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
        <table style="width:100%;">
            <caption>
                <strong>GESTOR DE LOS IDIOMA</strong></caption>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style21">
                </td>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Nombre del idioma</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtIdioma_nombre" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style5">
                  
                    <asp:Button ID="btnOrganizacion" runat="server" Text="ORGANIZACION" Width="163px" Height="26px" OnClick="btnOrganizacion_Click" />
                  
                </td>
            </tr>
            <tr>
                <td class="auto-style16">Iniciales del idioma</td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtIdioma_iniciales" runat="server" Width="175px" MaxLength="3"></asp:TextBox>
                </td>
                <td class="auto-style22"></td>
                <td class="auto-style19"></td>
                <td class="auto-style20">
               
                    <asp:Button ID="btnCodigo" runat="server" Text="CODIGO" Width="163px" OnClick="btnCodigo_Click" />
               
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td>
              
                    <asp:Button ID="btnIdioma" runat="server" Text="IDIOMA" Width="162px" OnClick="btnIdioma_Click" />
              
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td>
              
                    <asp:Button ID="btnDepartamento" runat="server" Text="DEPARTAMENTO" OnClick="btnDepartamento_Click" Width="163px" />
              
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style23">
                    &nbsp;</td>
                <td class="auto-style15">
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
                <td class="auto-style23">
                    &nbsp;</td>
                <td class="auto-style15">
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
                <td class="auto-style23">
                    &nbsp;</td>
                <td class="auto-style15">
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
                <td class="auto-style23">
                    &nbsp;</td>
                <td class="auto-style15">
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
                <td class="auto-style23">
                    &nbsp;</td>
                <td class="auto-style15">
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
                <td class="auto-style23">
                    <asp:Button ID="Actualizar_datos" runat="server" OnClick="Actualizar_datos_Click" Text="ACTUALIZAR TABLA" />
                </td>
                <td class="auto-style15">
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
                        <asp:DropDownList ID="ddlIdioma" runat="server" CssClass="auto-style10" Height="20px" Width="157px">
                        </asp:DropDownList>
                </td>
                <td class="auto-style23">
                        <asp:CheckBox ID="ckbIdioma" runat="server" Text="MOSTRAR INACTIVOS" />
                </td>
                <td class="auto-style15">
                    &nbsp;</td>
                <td>
                 
                    <asp:Button ID="btnCerrarSecion" runat="server" Text="CERRAR SECIÓN" OnClick="btnCerrarSecion_Click" Width="162px" />
                 
                </td>
            </tr>
        </table>
        <div>
        </div>
        <asp:GridView ID="gvIdioma" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
