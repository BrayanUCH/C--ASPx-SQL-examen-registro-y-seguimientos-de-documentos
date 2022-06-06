using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmCodigo : System.Web.UI.Page
    {
        DataSet dsCodigo;
        DataTable dtCodigo;
        private int Codigo_id;
        int Vacio_Codigo;
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
                    this.dsCodigo = servicioCL.usuarioConsultar(1);
                    this.dtCodigo = this.dsCodigo.Tables[0];
                }

                tipoUsuario = this.dtCodigo.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbCodigo.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }

        #region Metodos

        /*
        * El metodo CargarGridCodigoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridCodigoA()
        {
            using (GestorCodigo servicioCL = new GestorCodigo())
            {
                gvCodigo.DataSource = servicioCL.CodigoListarA();
                gvCodigo.DataBind();
            }

        }

        /*
        * El metodo CargarGridCodigoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridCodigoI()
        {
            using (GestorCodigo servicioCL = new GestorCodigo())
            {
                gvCodigo.DataSource = servicioCL.CodigoListarI();
                gvCodigo.DataBind();
            }
        }

        /*
         * El metodo CargarComboCodigoA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboCodigoA()
        {
            using (GestorCodigo servicioCL = new GestorCodigo())
            {
                ddlCodigo.DataSource = servicioCL.CodigoListarA();

                ddlCodigo.DataValueField = "Codigo_id";
                ddlCodigo.DataTextField = "Codigo_formato";

                ddlCodigo.DataBind();

            }
        }

        /*
         * El metodo CargarComboCodigoI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboCodigoI()
        {
            using (GestorCodigo servicioCL = new GestorCodigo())
            {

                ddlCodigo.DataSource = servicioCL.CodigoListarI();

                ddlCodigo.DataValueField = "Codigo_id";
                ddlCodigo.DataTextField = "Codigo_formato";

                ddlCodigo.DataBind();

            }
        }

        /*
         * El metodo BuscarCodigo se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarCodigo()
        {
            Codigo_id = int.Parse(ddlCodigo.SelectedValue.ToString());
            using (GestorCodigo Gestor = new GestorCodigo())
            {
                this.dsCodigo = Gestor.CodigoConsultar(Codigo_id);
                this.dtCodigo = this.dsCodigo.Tables[0];
            }
            cargarDatosCodigo();
        }

        private void cargarDatosCodigo()
        {
            try
            {
                cbxCodigo_organizacion.Text = this.dtCodigo.Rows[0]["Organizacion_id"].ToString();
            }
            catch (Exception)
            {
                cbxCodigo_organizacion.Items.Add(this.dtCodigo.Rows[0]["Organizacion_id"].ToString());
                cbxCodigo_organizacion.Text = this.dtCodigo.Rows[0]["Organizacion_id"].ToString();
            }

            txtCodigo_Codigo_formato.Text = this.dtCodigo.Rows[0]["Codigo_formato"].ToString();
            Estado = this.dtCodigo.Rows[0]["Codigo_estado"].ToString();
        }

        /*
         * El metodo CargarComboIdOrganizacion se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void CargarComboIdOrganizacion()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {

                cbxCodigo_organizacion.DataSource = servicioCL.OrganizacionListarA();

                cbxCodigo_organizacion.DataValueField = "Organizacion_id";
                cbxCodigo_organizacion.DataTextField = "Organizacion_nombre";

                cbxCodigo_organizacion.DataBind();
            }
        }
        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        void actualizarDatos()
        {
            if (ckbCodigo.Checked == false)
            {
                CargarGridCodigoA();
                CargarComboCodigoA();
                CargarComboIdOrganizacion();
            }
            else
            {
                CargarGridCodigoI();
                CargarComboCodigoI();
                CargarComboIdOrganizacion();
            }
        }
        /*
        * El metodo VacioOrganizacion se encarga de verificar que los espacios de los datos esten llenos
        */
        private void VacioCodigo()
        {
            if (cbxCodigo_organizacion.SelectedValue == null)
            {
                MessageBox.Show("Nombre de la organizacion 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Codigo = 1;
            }
            if (txtCodigo_Codigo_formato.Text == "")
            {
                MessageBox.Show("Formato del codigó 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Codigo = 1;
            }

        }
        /*
        * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
        */
        void Limpiar_txt()
        {
            txtCodigo_Codigo_formato.Text = "";
        }

        #endregion Metodos
        //----------------------------------------------------------------------------------------------------------------------    
        #region EVENTOS

        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCodigo();
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
            VacioCodigo();
            if (Vacio_Codigo == 0)
            {
                using (GestorCodigo Gestor = new GestorCodigo())
                {
                    Gestor.CodigoInsertar(int.Parse(cbxCodigo_organizacion.SelectedValue.ToString()), txtCodigo_Codigo_formato.Text, "A");
                }
                Codigo_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Codigo = 0;
        }
        /*
         * El evento btnModificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioCodigo();
                Codigo_id = int.Parse(ddlCodigo.SelectedValue.ToString());

                if (ckbCodigo.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }

                if (Vacio_Codigo == 0 && Codigo_id != 0)
                {
                    using (GestorCodigo Gestor = new GestorCodigo())
                    {
                        Gestor.CodigoModificar(Codigo_id, int.Parse(cbxCodigo_organizacion.SelectedValue.ToString()), txtCodigo_Codigo_formato.Text, Estado);
                    }

                    Codigo_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Codigo = 0;
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
                Codigo_id = int.Parse(ddlCodigo.SelectedValue.ToString());
                if (Codigo_id != 0)
                {
                    using (GestorCodigo Gestor = new GestorCodigo())
                    {
                        Gestor.CodigoInactivar(Codigo_id);
                    }
                    Codigo_id = 0;
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
                Codigo_id = int.Parse(ddlCodigo.SelectedValue.ToString());
                if (Codigo_id != 0)
                {
                    using (GestorCodigo Gestor = new GestorCodigo())
                    {
                        Gestor.CodigoActivar(Codigo_id);
                    }
                    Codigo_id = 0;
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
            Response.Redirect("FrmOrganizacion.aspx");
        }

        protected void btnCodigo_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmCodigo.aspx");
        }

        protected void btnIdioma_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmIdioma.aspx");
        }

        protected void btnDepartamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDepartamento.aspx");
        }

        protected void btnEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmEmpleado.aspx");
        }

        protected void btnTramite_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmTramite.aspx");
        }

        protected void btnCiclo_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmCiclo.aspx");
        }

        protected void btDocumento_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDocumento.aspx");
        }

        protected void btnCaso_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmCaso.aspx");
        }

        protected void btnDetalleCaso_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDetalleCaso.aspx");
        }

        protected void btnCerrarSecion_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogin.aspx");
        }

        protected void cbxCodigo_organizacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion CAMBIO DE VENTANAS
    }
}