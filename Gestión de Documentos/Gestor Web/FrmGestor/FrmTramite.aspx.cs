using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmTramite : System.Web.UI.Page
    {
        DataSet dsTramite;
        DataTable dtTramite;
        private int Tramite_id;
        int Vacio_Tramite;
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
                    this.dsTramite = servicioCL.usuarioConsultar(1);
                    this.dtTramite = this.dsTramite.Tables[0];
                }

                tipoUsuario = this.dtTramite.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbTramite.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }

        #region Metodos

        /*
        * El evento CargarGridTramiteA es el encargado de cargar los datos de los activos en la tabla.
        */
        protected void CargarGridTramiteA()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                gvTramite.DataSource = servicioCL.TramiteListarA();
                gvTramite.DataBind();
            }
        }

        /*
        * El evento CargarGridTramiteI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        protected void CargarGridTramiteI()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                gvTramite.DataSource = servicioCL.TramiteListarI();
                gvTramite.DataBind();
            }
        }

        /*
         * El evento CargarComboTramiteA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        protected void CargarComboTramiteA()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                ddlTramite.DataSource = servicioCL.TramiteListarA();

                ddlTramite.DataValueField = "Tramite_id";
                ddlTramite.DataTextField = "Tramite_nombre";

                ddlTramite.DataBind();
            }
        }

        /*
         * El evento CargarComboTramiteI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboTramiteI()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                ddlTramite.DataSource = servicioCL.TramiteListarI();

                ddlTramite.DataValueField = "Tramite_id";
                ddlTramite.DataTextField = "Tramite_nombre";

                ddlTramite.DataBind();
            }
        }

        /*
         * El evento BuscarTramite se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        protected void BuscarTramite()
        {
            Tramite_id = int.Parse(ddlTramite.SelectedValue.ToString());
            using (GestorTramite servicioCL = new GestorTramite())
            {
                this.dsTramite = servicioCL.TramiteConsultar(Tramite_id);
                this.dtTramite = this.dsTramite.Tables[0];
            }
            CargarDatosTramite();
        }

        /*
         * El evento CargarDatosTramite se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        protected void CargarDatosTramite()
        {
            txtTramite_nombre.Text = this.dtTramite.Rows[0]["Tramite_nombre"].ToString();
            txtTramite_descripcion.Text = this.dtTramite.Rows[0]["Tramite_descripcion"].ToString();
        }


        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbTramite.Checked == false)
            {
                CargarGridTramiteA();
                CargarComboTramiteA();

            }
            else
            {
                CargarGridTramiteI();
                CargarComboTramiteI();
            }
        }

        /*
         * El metodo VacioTramite se encarga de verificar que los espacios de los datos esten llenos
         */
        private void VacioTramite()
        {
            if (txtTramite_nombre.Text == "")
            {
                MessageBox.Show("Nombre del tramite 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Tramite = 1;
            }
            if (txtTramite_descripcion.Text == "")
            {
                MessageBox.Show("Descripcion del tramite 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Tramite = 1;
            }
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtTramite_nombre.Text = "";
            txtTramite_descripcion.Text = "";
        }

        #endregion Metodos

        //----------------------------------------------------------------------------------------------------------------------    
        #region EVENTOS

        /*
        * El metodo btnTramite_cargarDatos_Click se encarga de cargar los datos de la base de datos
        * en los txt, cbx y los dtp, con la ayuda de metodo BuscarTramite. 
        */
        protected void btncargardatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarTramite();
            }
            catch (Exception)
            {

            }
        }

        /*
         * El metodo btnTramite_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            VacioTramite();
            if (Vacio_Tramite == 0)
            {

                using (GestorTramite Gestor = new GestorTramite())
                {
                    Gestor.TramiteInsertar(txtTramite_nombre.Text, txtTramite_descripcion.Text, "A");
                }

                Tramite_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Tramite = 0;
        }

        /*
         * El metodo btnTramite_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioTramite();
                Tramite_id = int.Parse(ddlTramite.SelectedValue.ToString());
                if (ckbTramite.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }
                if (Vacio_Tramite == 0 && Tramite_id != 0)
                {
                    using (GestorTramite Gestor = new GestorTramite())
                    {
                        Gestor.TramiteModificar(Tramite_id, txtTramite_nombre.Text, txtTramite_descripcion.Text, Estado);
                    }

                    Tramite_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Tramite = 0;
            }
            catch (Exception)
            {

            }
        }

        /*
         * El metodo btnTramite_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Tramite_id = int.Parse(ddlTramite.SelectedValue.ToString());
                if (Tramite_id != 0)
                {
                    using (GestorTramite Gestor = new GestorTramite())
                    {
                        Gestor.TramiteInactivar(Tramite_id);
                    }
                    Tramite_id = 0;
                    actualizarDatos();
                    Vacio_Tramite = 0;
                    Limpiar_txt();
                }
            }
            catch (Exception)
            {

            }
        }

        /*
         * El metodo btnActivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                Tramite_id = int.Parse(ddlTramite.SelectedValue.ToString());
                if (Tramite_id != 0)
                {
                    using (GestorTramite Gestor = new GestorTramite())
                    {
                        Gestor.TramiteActivar(Tramite_id);
                    }
                    Tramite_id = 0;
                    actualizarDatos();
                    Vacio_Tramite = 0;
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
            Response.Redirect("frmCiclo.aspx");
        }

        protected void btnCaso_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDocumento.aspx");
        }

        protected void btnDetalleCaso_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDetalleCaso.aspx");
        }

        protected void btnCerrarSecion_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }

        protected void btnEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmEmpleado.aspx");
        }

        #endregion CAMBIO DE VENTANAS
        //Response.Redirect("frpAula.aspx");

    }
}