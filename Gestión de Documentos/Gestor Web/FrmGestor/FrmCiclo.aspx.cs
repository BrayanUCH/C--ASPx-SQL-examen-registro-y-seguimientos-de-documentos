using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmCiclo : System.Web.UI.Page
    {
        DataSet dsCiclo;
        DataTable dtCiclo;
        int Ciclo_id = 0;
        int tramite_id = 0;
        int departamento_id = 0;
        int Vacio_Ciclo = 0;
        string Estado = "";
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
                    this.dsCiclo = servicioCL.usuarioConsultar(1);
                    this.dtCiclo = this.dsCiclo.Tables[0];
                }

                tipoUsuario = this.dtCiclo.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbCiclo.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }
        #region Metodos

        /*
        * El metodo CargarGridCicloA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridCicloA()
        {
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                gvCiclo.DataSource = servicioCL.CicloListarA();
                gvCiclo.DataBind();
            }
        }

        /*
        * El metodo CargarGridCicloI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridCicloI()
        {
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                gvCiclo.DataSource = servicioCL.CicloListarI();
                gvCiclo.DataBind();
            }
        }

        /*
         * El metodo CargarComboCicloA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboCicloA()
        {
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                ddlCiclo.DataSource = servicioCL.CicloListarA();

                ddlCiclo.DataValueField = "Ciclo_id";
                ddlCiclo.DataTextField = "Ciclo_orden";

                ddlCiclo.DataBind();
            }
        }

        /*
         * El metodo CargarComboCicloI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboCicloI()
        {
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                ddlCiclo.DataSource = servicioCL.CicloListarI();

                ddlCiclo.DataValueField = "Ciclo_id";
                ddlCiclo.DataTextField = "Ciclo_orden";

                ddlCiclo.DataBind();
            }
        }

        /*
         * El metodo BuscarCiclo se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarCiclo()
        {
            Ciclo_id = int.Parse(ddlCiclo.SelectedValue.ToString());
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                this.dsCiclo = servicioCL.CicloConsultar(Ciclo_id);
                this.dtCiclo = this.dsCiclo.Tables[0];
            }
            CargarDatosCiclo();
        }

        /*
         * El metodo CargarDatosCiclo se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosCiclo()
        {
            try
            {
                cbxCiclo_TramiteId.Text = this.dtCiclo.Rows[0]["Tramite_id"].ToString();
            }
            catch (Exception)
            {
                cbxCiclo_TramiteId.Items.Add(this.dtCiclo.Rows[0]["Tramite_id"].ToString());
                cbxCiclo_TramiteId.Text = this.dtCiclo.Rows[0]["Tramite_id"].ToString();
            }
            try
            {
                cbxCiclo_DepartamentoId.Text = this.dtCiclo.Rows[0]["Departamento_id"].ToString();
            }
            catch (Exception)
            {
                cbxCiclo_DepartamentoId.Items.Add(this.dtCiclo.Rows[0]["Departamento_id"].ToString());
                cbxCiclo_DepartamentoId.Text = this.dtCiclo.Rows[0]["Departamento_id"].ToString();
            }
            txtCiclo_orden.Text = this.dtCiclo.Rows[0]["Ciclo_orden"].ToString();
            Estado = this.dtCiclo.Rows[0]["Ciclo_estado"].ToString();

        }

        /*
         * El metodo cagarDatoscbxTramite se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void cagarDatoscbxTramite()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                cbxCiclo_TramiteId.DataSource = servicioCL.TramiteListarA();

                cbxCiclo_TramiteId.DataValueField = "Tramite_id";
                cbxCiclo_TramiteId.DataTextField = "Tramite_nombre";

                cbxCiclo_TramiteId.DataBind();
            }
        }

        /*
         * El metodo cagarDatoscbxDepartamento se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void cagarDatoscbxDepartamento()
        {
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                cbxCiclo_DepartamentoId.DataSource = servicioCL.DepartamentoListarA();

                cbxCiclo_DepartamentoId.DataValueField = "Departamento_id";
                cbxCiclo_DepartamentoId.DataTextField = "Departamento_nombre";

                cbxCiclo_DepartamentoId.DataBind();
            }
        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbCiclo.Checked == false)
            {
                CargarGridCicloA();
                CargarComboCicloA();
            }
            else
            {
                CargarGridCicloI();
                CargarComboCicloI();
            }
            cagarDatoscbxTramite();
            cagarDatoscbxDepartamento();
        }

        /*
         * El metodo VacioCiclo se encarga de verificar que los espacios de los datos esten llenos
         */
        protected void VacioCiclo()
        {
            if (cbxCiclo_TramiteId.SelectedValue == null)
            {
                MessageBox.Show("Nombre del tramite 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Ciclo = 1;
            }
            if (cbxCiclo_DepartamentoId.SelectedValue == null)
            {
                MessageBox.Show("Nombre del departamento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Ciclo = 1;
            }
            if (txtCiclo_orden.Text == "")
            {
                MessageBox.Show("Orden 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Ciclo = 1;
            }
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtCiclo_orden.Text = "";
        }

        #endregion Metodos

        //----------------------------------------------------------------------------------------------------------------------    
        #region EVENTOS

        /*
         * El evento btnCargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarCiclo. 
         */
        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCiclo();
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
            VacioCiclo();
            if (Vacio_Ciclo == 0)
            {
                using (GestorCiclo Gestor = new GestorCiclo())
                {
                    Gestor.CicloInsertar(int.Parse(cbxCiclo_TramiteId.SelectedValue.ToString()), int.Parse(cbxCiclo_DepartamentoId.SelectedValue.ToString()), txtCiclo_orden.Text, "A");
                }

                Ciclo_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Ciclo = 0;
        }

        /*
         * El evento btnmodificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioCiclo();
                Ciclo_id = int.Parse(ddlCiclo.SelectedValue.ToString());
                if (ckbCiclo.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }

                if (Vacio_Ciclo == 0 && Ciclo_id != 0)
                {
                    using (GestorCiclo Gestor = new GestorCiclo())
                    {
                        Gestor.CicloModificar(Ciclo_id, int.Parse(cbxCiclo_TramiteId.SelectedValue.ToString()), int.Parse(cbxCiclo_DepartamentoId.SelectedValue.ToString()), txtCiclo_orden.Text, Estado);
                    }

                    Ciclo_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Ciclo = 0;
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
                Ciclo_id = int.Parse(ddlCiclo.SelectedValue.ToString());
                if (Ciclo_id != 0)
                {
                    using (GestorCiclo Gestor = new GestorCiclo())
                    {
                        Gestor.CicloInactivar(Ciclo_id);
                    }

                    Ciclo_id = 0;
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
                Ciclo_id = int.Parse(ddlCiclo.SelectedValue.ToString());
                if (Ciclo_id != 0)
                {
                    using (GestorCiclo Gestor = new GestorCiclo())
                    {
                        Gestor.CicloActivar(Ciclo_id);
                    }

                    Ciclo_id = 0;
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
        //----------------------------------------------------------------------------------------------------------------------    
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