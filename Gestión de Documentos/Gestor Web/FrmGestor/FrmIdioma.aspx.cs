using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmIdioma : System.Web.UI.Page
    {
        DataSet dsIdioma;
        DataTable dtIdioma;
        private int Idioma_id;
        int Vacio_Idioma;
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
                    this.dsIdioma = servicioCL.usuarioConsultar(1);
                    this.dtIdioma = this.dsIdioma.Tables[0];
                }

                tipoUsuario = this.dtIdioma.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbIdioma.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }

        #region METODOS

        /*
       * El metodo CargarGridIdiomaA es el encargado de cargar los datos de los activos en la tabla.
       */
        protected void CargarGridIdiomaA()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                gvIdioma.DataSource = servicioCL.IdiomaListarA();
                gvIdioma.DataBind();
            }
        }

        /*
        * El metodo CargarGridIdiomaI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        protected void CargarGridIdiomaI()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                gvIdioma.DataSource = servicioCL.IdiomaListarI();
                gvIdioma.DataBind();

            }
        }

        /*
         * El metodo CargarComboIdiomaA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        protected void CargarComboIdiomaA()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                ddlIdioma.DataSource = servicioCL.IdiomaListarA();

                ddlIdioma.DataValueField = "Idioma_id";
                ddlIdioma.DataTextField = "Idioma_nombre";

                ddlIdioma.DataBind();
            }
        }

        /*
         * El metodo CargarComboIdiomaI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        protected void CargarComboIdiomaI()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {

                ddlIdioma.DataSource = servicioCL.IdiomaListarI();

                ddlIdioma.DataValueField = "Idioma_id";
                ddlIdioma.DataTextField = "Idioma_nombre";

                ddlIdioma.DataBind();
            }
        }

        /*
         * El metodo BuscarIdioma se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        protected void BuscarIdioma()
        {
            Idioma_id = int.Parse(ddlIdioma.SelectedValue.ToString());

            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                this.dsIdioma = servicioCL.IdiomaConsultar(Idioma_id);
                this.dtIdioma = this.dsIdioma.Tables[0];
            }
            CargarDatosIdioma();
        }

        /*
         * El metodo CargarDatosIdioma se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        protected void CargarDatosIdioma()
        {
            txtIdioma_nombre.Text = this.dtIdioma.Rows[0]["Idioma_nombre"].ToString();
            txtIdioma_iniciales.Text = this.dtIdioma.Rows[0]["Idioma_iniciales"].ToString();
            Estado = this.dtIdioma.Rows[0]["Idioma_estado"].ToString();
        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbIdioma.Checked == false)
            {
                CargarGridIdiomaA();
                CargarComboIdiomaA();
            }
            else
            {
                CargarGridIdiomaI();
                CargarComboIdiomaI();
            }
        }

        /*
         * El metodo VacioIdioma se encarga de verificar que los espacios de los datos esten llenos
         */
        protected void VacioIdioma()
        {
            if (txtIdioma_nombre.Text == "")
            {
                MessageBox.Show("Nombre del idioma 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Idioma = 1;
            }

            if (txtIdioma_iniciales.Text == "")
            {
                MessageBox.Show("Iniciales del idioma 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Idioma = 1;
            }
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtIdioma_nombre.Text = "";
            txtIdioma_iniciales.Text = "";
        }

        #endregion METODOS
        //----------------------------------------------------------------------------------------------------------------------    
        #region EVENTOS
        /*
         * El evento btnCargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarIdioma. 
         */
        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarIdioma();
            }
            catch (Exception)
            {

            }
        }
        /*
         * El evento btnInsertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnInsertar_Click(object sender, EventArgs e)
        {

            VacioIdioma();
            if (Vacio_Idioma == 0)
            {
                using (GestorIdioma Gestor = new GestorIdioma())
                {
                    Gestor.IdiomaInsertar(txtIdioma_nombre.Text, txtIdioma_iniciales.Text, "A");
                }
                Idioma_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Idioma = 0;
        }
        /*
        * El evento btnModificar_Click se encarga de modificar los datos en la base de datos
        * y actualiza los comboBox y las tablas. 
        */
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioIdioma();
                Idioma_id = int.Parse(ddlIdioma.SelectedValue.ToString());
                if (ckbIdioma.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }

                if (Vacio_Idioma == 0 && Idioma_id != 0)
                {
                    using (GestorIdioma Gestor = new GestorIdioma())
                    {
                        Gestor.IdiomaModificar(Idioma_id, txtIdioma_nombre.Text, txtIdioma_iniciales.Text, Estado);
                    }
                    Idioma_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Idioma = 0;
            }
            catch (Exception)
            {

            }
        }
        /*
        * El evento btnInactivar_Click se encarga de Inactivar los datos en la base de datos
        * y actualiza los comboBox y las tablas.
        */
        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Idioma_id = int.Parse(ddlIdioma.SelectedValue.ToString());
                if (Idioma_id != 0)
                {
                    using (GestorIdioma Gestor = new GestorIdioma())
                    {
                        Gestor.IdiomaInactivar(Idioma_id);
                    }
                    Idioma_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
            }
            catch (Exception)
            {

            }
        }
        /*
         * El evento btnActivar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                Idioma_id = int.Parse(ddlIdioma.SelectedValue.ToString());
                if (Idioma_id != 0)
                {
                    using (GestorIdioma Gestor = new GestorIdioma())
                    {
                        Gestor.IdiomaActivar(Idioma_id);
                    }
                    Idioma_id = 0;
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

        #endregion CAMBIO DE VENTANAS

    }
}