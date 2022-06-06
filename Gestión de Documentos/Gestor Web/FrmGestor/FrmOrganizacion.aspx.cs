using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmOrganizacion : System.Web.UI.Page
    {
        DataSet dsOrganizacion;
        DataTable dtOrganizacion;
        private int Organizacion_id;
        int Vacio_Organizacion;
        string Estado;
        /*
         * Este evento es el engardado de cargar los datos iniciales para poder trabajar 
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizarDatos();

                //
                string tipoUsuario;

                using (GestorUsuarioTipo servicioCL = new GestorUsuarioTipo())
                {
                    this.dsOrganizacion = servicioCL.usuarioConsultar(1);
                    this.dtOrganizacion = this.dsOrganizacion.Tables[0];
                }

                tipoUsuario = this.dtOrganizacion.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbOrganizacion.Visible = false;
                    BtnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }

        }

        #region METODOS

        /*
        * El metodo CargarGridOrganizacionA es el encargado de cargar los datos de los activos en la tabla.
        */
        protected void CargarGridOrganizacionA()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                gvOrganizacion.DataSource = servicioCL.OrganizacionListarA();
                gvOrganizacion.DataBind();

            }
        }

        /*
        * El metodo CargarGridOrganizacionI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        protected void CargarGridOrganizacionI()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                gvOrganizacion.DataSource = servicioCL.OrganizacionListarI();
                gvOrganizacion.DataBind();
            }
        }

        /*
         * El metodo CargarComboOrganizacionA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        protected void CargarComboOrganizacionA()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {

                ddlOrganizacion.DataSource = servicioCL.OrganizacionListarA();

                ddlOrganizacion.DataValueField = "Organizacion_id";
                ddlOrganizacion.DataTextField = "Organizacion_nombre";

                ddlOrganizacion.DataBind();
            }
        }

        /*
         * El metodo CargarComboOrganizacionI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        protected void CargarComboOrganizacionI()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {

                ddlOrganizacion.DataSource = servicioCL.OrganizacionListarI();

                ddlOrganizacion.DataValueField = "Organizacion_id";
                ddlOrganizacion.DataTextField = "Organizacion_nombre";

                ddlOrganizacion.DataBind();
                ddlOrganizacion.SelectedIndex = 0;
            }
        }

        /*
         * El metodo BuscarOrganizacion se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        protected void BuscarOrganizacion()
        {
            Organizacion_id = int.Parse(ddlOrganizacion.SelectedValue.ToString());

            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                this.dsOrganizacion = servicioCL.OrganizacionConsultar(Organizacion_id);
                this.dtOrganizacion = this.dsOrganizacion.Tables[0];
            }

            txtOrganizacion_nombre.Text = this.dtOrganizacion.Rows[0]["Organizacion_nombre"].ToString();
            txtOrganizacion_tipo.Text = this.dtOrganizacion.Rows[0]["Organizacion_tipo"].ToString();
            txtOrganizacion_descripcion.Text = this.dtOrganizacion.Rows[0]["Organizacion_descripcion"].ToString();
            Estado = this.dtOrganizacion.Rows[0]["Organizacion_estado"].ToString();
        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbOrganizacion.Checked == false)
            {
                CargarGridOrganizacionA();
                CargarComboOrganizacionA();
            }
            else
            {
                CargarGridOrganizacionI();
                CargarComboOrganizacionI();
            }
        }

        /*
         * El metodo VacioOrganizacion se encarga de verificar que los espacios de los datos esten llenos
         */
        protected void VacioOrganizacion()
        {
            if (txtOrganizacion_nombre.Text == "")
            {
                MessageBox.Show("Nombre de la organizacion 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Organizacion = 1;
            }
            if (txtOrganizacion_tipo.Text == "")
            {
                MessageBox.Show("Tipo de la organizacion 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Organizacion = 1;
            }
            if (txtOrganizacion_descripcion.Text == "")
            {
                MessageBox.Show("Descipcion de la organizacion 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Organizacion = 1;
            }
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtOrganizacion_nombre.Text = "";
            txtOrganizacion_tipo.Text = "";
            txtOrganizacion_descripcion.Text = "";
        }
        #endregion METODOS
        //----------------------------------------------------------------------------------------------------------------------    
        #region EVENTOS

        /*
         * El evento BtnCargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarDepartamento. 
         */
        protected void BtnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarOrganizacion();
            }
            catch (Exception)
            {

            }
        }

        /*
         * El evento Button1_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            VacioOrganizacion();
            if (Vacio_Organizacion == 0)
            {
                using (GestorOreganizacion Gestor = new GestorOreganizacion())
                {
                    Gestor.OrganizacionInsertar(txtOrganizacion_nombre.Text, txtOrganizacion_tipo.Text, txtOrganizacion_descripcion.Text, "A");
                }
                Organizacion_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Organizacion = 0;
        }

        /*
         * El evento BtnModificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioOrganizacion();
                Organizacion_id = int.Parse(ddlOrganizacion.SelectedValue.ToString());
                if (ckbOrganizacion.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }

                if (Vacio_Organizacion == 0 && Organizacion_id != 0)
                {
                    using (GestorOreganizacion Gestor = new GestorOreganizacion())
                    {
                        Gestor.OrganizacionModificar(Organizacion_id, txtOrganizacion_nombre.Text, txtOrganizacion_tipo.Text, txtOrganizacion_descripcion.Text, Estado);
                    }
                    Organizacion_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Organizacion = 0;
            }
            catch (Exception)
            {

            }
        }

        /*
         * El evento BtnInactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        protected void BtnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Organizacion_id = int.Parse(ddlOrganizacion.SelectedValue.ToString());
                if (Organizacion_id != 0)
                {
                    using (GestorOreganizacion Gestor = new GestorOreganizacion())
                    {
                        Gestor.OrganizacionInactivar(Organizacion_id);
                    }
                    Organizacion_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
            }
            catch (Exception)
            {

            }
        }

        /*
         * El evento BtnActivar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        protected void BtnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                Organizacion_id = int.Parse(ddlOrganizacion.SelectedValue.ToString());
                if (Organizacion_id != 0)
                {
                    using (GestorOreganizacion Gestor = new GestorOreganizacion())
                    {
                        Gestor.OrganizacionActivar(Organizacion_id);
                    }
                    Organizacion_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
            }
            catch (Exception)
            {

            }
        }

        /*
         * El evento Actualizar_datos_Click Actualiza los datos de inactivos a activos y viceversa
         */
        protected void Actualizar_datos_Click(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        #endregion EVENTOS
        
        /*
         * Esta region es la encargada de la navegacion entre los direfentes aspx
         */
        #region CAMBIO DE VENTANAS

        protected void btnOrganizacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOrganizacion.aspx");
        }

        protected void btnCodigo_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCodigo.aspx");
        }

        protected void btnIdioma_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmIdioma.aspx");
        }

        protected void btnDepartamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDepartamento.aspx");
        }

        protected void btnEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmEmpleado.aspx");
        }

        protected void btnTramite_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmTramite.aspx");
        }

        protected void btnCiclo_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCiclo.aspx");
        }

        protected void btDocumento_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDocumento.aspx");
        }

        protected void btnCaso_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCaso.aspx");
        }

        protected void btnDetalleCaso_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDetalleCaso.aspx");
        }

        protected void btnCerrarSecion_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }

        protected void ckbOrganizacion_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion CAMBIO DE VENTANAS
    }
}