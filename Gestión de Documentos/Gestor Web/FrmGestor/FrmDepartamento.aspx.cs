using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmDepartamento : System.Web.UI.Page
    {
        DataSet dsDepartamento;
        DataTable dtDepartamento;
        private int Departamento_id;
        int Vacio_Departamento;
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
                    this.dsDepartamento = servicioCL.usuarioConsultar(1);
                    this.dtDepartamento = this.dsDepartamento.Tables[0];
                }

                tipoUsuario = this.dtDepartamento.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbDepartamento.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }

        #region Metodos

        /*
        * El metodo CargarGridDepartamentoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridDepartamentoA()
        {
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                gvDepartamento.DataSource = servicioCL.DepartamentoListarA();
                gvDepartamento.DataBind();
            }
        }

        /*
        * El metodo CargarGridDepartamentoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridDepartamentoI()
        {
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                gvDepartamento.DataSource = servicioCL.DepartamentoListarI();
                gvDepartamento.DataBind();
            }
        }

        /*
         * El metodo CargarComboDepartamentoA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboDepartamentoA()
        {
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                ddlDepartamento.DataSource = servicioCL.DepartamentoListarA();

                ddlDepartamento.DataValueField = "Departamento_id";
                ddlDepartamento.DataTextField = "Departamento_nombre";

                ddlDepartamento.DataBind();
            }
        }

        /*
         * El metodo CargarComboDepartamentoI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboDepartamentoI()
        {
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                ddlDepartamento.DataSource = servicioCL.DepartamentoListarI();

                ddlDepartamento.DataValueField = "Departamento_id";
                ddlDepartamento.DataTextField = "Departamento_nombre";

                ddlDepartamento.DataBind();
            }
        }

        /*
         * El metodo BuscarDepartamento se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarDepartamento()
        {
            Departamento_id = int.Parse(ddlDepartamento.SelectedValue.ToString());
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                this.dsDepartamento = servicioCL.DepartamentoConsultar(Departamento_id);
                this.dtDepartamento = this.dsDepartamento.Tables[0];
            }
            CargarDatosDepartamento();
        }

        /*
         * El metodo CargarDatosDepartamento se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosDepartamento()
        {
            try
            {
                cbxDepartamento_organizacion.Text = this.dtDepartamento.Rows[0]["Organizacion_id"].ToString();
            }
            catch (Exception)
            {
                cbxDepartamento_organizacion.Items.Add(this.dtDepartamento.Rows[0]["Organizacion_id"].ToString());
                cbxDepartamento_organizacion.Text = this.dtDepartamento.Rows[0]["Organizacion_id"].ToString();
            }

            txtDepartamento_nombre.Text = this.dtDepartamento.Rows[0]["Departamento_nombre"].ToString();
            txtDepartamento_tipo.Text = this.dtDepartamento.Rows[0]["Departamento_tipo"].ToString();
            txtDepartamento_descripcion.Text = this.dtDepartamento.Rows[0]["Departamento_descripcion"].ToString();
            Estado = this.dtDepartamento.Rows[0]["Departamento_estado"].ToString();

        }

        /*
         * El metodo CargarComboIdOrganizacionDepartamento se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void CargarComboIdOrganizacionDepartamento()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                cbxDepartamento_organizacion.DataSource = servicioCL.OrganizacionListarA();

                cbxDepartamento_organizacion.DataValueField = "Organizacion_id";
                cbxDepartamento_organizacion.DataTextField = "Organizacion_nombre";

                cbxDepartamento_organizacion.DataBind();
            }
        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbDepartamento.Checked == false)
            {
                CargarGridDepartamentoA();
                CargarComboDepartamentoA();
                CargarComboIdOrganizacionDepartamento();
            }
            else
            {
                CargarGridDepartamentoI();
                CargarComboDepartamentoI();
                CargarComboIdOrganizacionDepartamento();
            }
        }

        /*
         * El metodo VacioDepartamento se encarga de verificar que los espacios de los datos esten llenos
         */
        protected void VacioDepartamento()
        {
            if (cbxDepartamento_organizacion.SelectedValue == null)
            {
                MessageBox.Show("Nombre de la organizacion 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Departamento = 1;
            }
            if (txtDepartamento_nombre.Text == "")
            {
                MessageBox.Show("Nombre del departamento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Departamento = 1;
            }
            if (txtDepartamento_tipo.Text == "")
            {
                MessageBox.Show("Tipo del departamento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Departamento = 1;
            }
            if (txtDepartamento_descripcion.Text == "")
            {
                MessageBox.Show("Descrición del departamento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Departamento = 1;
            }
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtDepartamento_nombre.Text = "";
            txtDepartamento_tipo.Text = "";
            txtDepartamento_descripcion.Text = "";
        }

        #endregion Metodos
        //----------------------------------------------------------------------------------------------------------------------    
        #region EVENTOS

        /*
         * El evento btnCargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarDepartamento. 
         */
        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarDepartamento();
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
            VacioDepartamento();
            if (Vacio_Departamento == 0)
            {
                using (GestorDepartamento Gestor = new GestorDepartamento())
                {
                    Gestor.DepartamentoInsertar(int.Parse(cbxDepartamento_organizacion.SelectedValue.ToString()), txtDepartamento_nombre.Text, txtDepartamento_tipo.Text, txtDepartamento_descripcion.Text, "A");
                }
                Departamento_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Departamento = 0;
        }

        /*
         * El evento btnDepartamento_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioDepartamento();

                Departamento_id = int.Parse(ddlDepartamento.SelectedValue.ToString());
                if (ckbDepartamento.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }

                if (Vacio_Departamento == 0 && Departamento_id != 0)
                {
                    using (GestorDepartamento Gestor = new GestorDepartamento())
                    {
                        Gestor.DepartamentoModificar(Departamento_id, int.Parse(cbxDepartamento_organizacion.SelectedValue.ToString()), txtDepartamento_nombre.Text, txtDepartamento_tipo.Text, txtDepartamento_descripcion.Text, Estado);
                    }
                    Departamento_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Departamento = 0;
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
                Departamento_id = int.Parse(ddlDepartamento.SelectedValue.ToString());
                if (Departamento_id != 0)
                {
                    using (GestorDepartamento Gestor = new GestorDepartamento())
                    {
                        Gestor.DepartamentoInactivar(Departamento_id);
                    }
                    Departamento_id = 0;
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
                Departamento_id = int.Parse(ddlDepartamento.SelectedValue.ToString());
                if (Departamento_id != 0)
                {
                    using (GestorDepartamento Gestor = new GestorDepartamento())
                    {
                        Gestor.DepartamentoActivar(Departamento_id);
                    }
                    Departamento_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
            }
            catch (Exception)
            {

            }
        }


        internal void cargarDatos_inicio()
        {
            CargarGridDepartamentoA();
            CargarComboDepartamentoA();
            CargarComboIdOrganizacionDepartamento();
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