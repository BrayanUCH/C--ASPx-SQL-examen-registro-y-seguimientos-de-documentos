using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmEmpleado : System.Web.UI.Page
    {
        DataSet dsEmpleado;
        DataTable dtEmpleado;
        private int Empleado_id;
        int Vacio_Empleado;
        string Estado;
        DateTime fecha_actual;

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
                    this.dsEmpleado = servicioCL.usuarioConsultar(1);
                    this.dtEmpleado = this.dsEmpleado.Tables[0];
                }

                tipoUsuario = this.dtEmpleado.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbEmpleado.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }

        #region Metodos
        /*
        * El metodo CargarGridEmpleadoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridEmpleadoA()
        {
            using (GestorEmpleado servicioCL = new GestorEmpleado())
            {
                gvEmpleado.DataSource = servicioCL.EmpleadoListarA();
                gvEmpleado.DataBind();
            }
        }

        /*
        * El metodo CargarGridEmpleadoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridEmpleadoI()
        {
            using (GestorEmpleado servicioCL = new GestorEmpleado())
            {
                gvEmpleado.DataSource = servicioCL.EmpleadoListarI();
                gvEmpleado.DataBind();
            }
        }

        /*
         * El metodo CargarComboEmpleadoA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboEmpleadoA()
        {
            using (GestorEmpleado servicioCL = new GestorEmpleado())
            {
                ddlEmpleado.DataSource = servicioCL.EmpleadoListarA();

                ddlEmpleado.DataValueField = "Empleado_id";
                ddlEmpleado.DataTextField = "Empleado_nombre";

                ddlEmpleado.DataBind();
            }
        }

        /*
         * El metodo CargarComboEmpleadoI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboEmpleadoI()
        {
            using (GestorEmpleado servicioCL = new GestorEmpleado())
            {
                ddlEmpleado.DataSource = servicioCL.EmpleadoListarI();

                ddlEmpleado.DataValueField = "Empleado_id";
                ddlEmpleado.DataTextField = "Empleado_nombre";

                ddlEmpleado.DataBind();
            }
        }

        /*
         * El metodo BuscarEmpleado se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarEmpleado()
        {
            Empleado_id = int.Parse(ddlEmpleado.SelectedValue.ToString());
            using (GestorEmpleado servicioCL = new GestorEmpleado())
            {
                this.dsEmpleado = servicioCL.EmpleadoConsultar(Empleado_id);
                this.dtEmpleado = this.dsEmpleado.Tables[0];
            }
            CargarDatosEmpleado();
        }

        /*
         * El metodo CargarDatosEmpleado se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosEmpleado()
        {
            try
            {
                cbxEmpleado_Departamento_id.Text = this.dtEmpleado.Rows[0]["Departamento_id"].ToString();
            }
            catch (Exception)
            {
                cbxEmpleado_Departamento_id.Items.Add(this.dtEmpleado.Rows[0]["Departamento_id"].ToString());
                cbxEmpleado_Departamento_id.Text = this.dtEmpleado.Rows[0]["Departamento_id"].ToString();
            }

            txtEmpleado_nombre.Text = this.dtEmpleado.Rows[0]["Empleado_nombre"].ToString();
            txtEmpleado_apellidos.Text = this.dtEmpleado.Rows[0]["Empleado_apellidos"].ToString();
            dateEmpleado_fechaNacimiento.NextMonthText = this.dtEmpleado.Rows[0]["Empleado_fechaNacimiento"].ToString();
            txtEmpleado_puesto.Text = this.dtEmpleado.Rows[0]["Empleado_puesto"].ToString();
            cbxEmpleado_genero.Text = this.dtEmpleado.Rows[0]["Empleado_genero"].ToString();
            cbxEmpleado_estadoCivil.Text = this.dtEmpleado.Rows[0]["Empleado_estadoCivil"].ToString();
            dateEmpleado_fechaIngreso.NextMonthText = this.dtEmpleado.Rows[0]["Empleado_fechaIngreso"].ToString();
            Estado = this.dtEmpleado.Rows[0]["Empleado_estado"].ToString();
        }

        /*
         * El metodo CargarComboIdDepartamentoEmpleado se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void CargarComboIdDepartamentoEmpleado()
        {
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                cbxEmpleado_Departamento_id.DataSource = servicioCL.DepartamentoListarA();

                cbxEmpleado_Departamento_id.DataValueField = "Departamento_id";
                cbxEmpleado_Departamento_id.DataTextField = "Departamento_nombre";

                cbxEmpleado_Departamento_id.DataBind();
            }
        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbEmpleado.Checked == false)
            {
                CargarGridEmpleadoA();
                CargarComboEmpleadoA();
            }
            else
            {
                CargarGridEmpleadoI();
                CargarComboEmpleadoI();
            }
            CargarComboIdDepartamentoEmpleado();
        }

        /*
         * El metodo VacioDepartamento se encarga de verificar que los espacios de los datos esten llenos
         */
        protected void VacioEmpleado()
        {
            if (cbxEmpleado_Departamento_id.SelectedValue == null)
            {
                MessageBox.Show("Nombre del departamento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Empleado = 1;
            }
            if (txtEmpleado_nombre.Text == "")
            {
                MessageBox.Show("Nombre del empleado 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Empleado = 1;
            }
            if (txtEmpleado_apellidos.Text == "")
            {
                MessageBox.Show("Apellidos del empleado 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Empleado = 1;
            }

            if (txtEmpleado_puesto.Text == "")
            {
                MessageBox.Show("Puesto del empleado 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Empleado = 1;
            }
            if (cbxEmpleado_genero.SelectedItem == null)
            {
                MessageBox.Show("Genero del empleado 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Empleado = 1;
            }
            if (cbxEmpleado_estadoCivil.SelectedItem == null)
            {
                MessageBox.Show("Estado civil del empleado 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Empleado = 1;
            }

            //if (dateEmpleado_fechaIngreso.SelectedDate == null)
            //{
            //    MessageBox.Show("La fecha de ingreso esta vacida", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    Vacio_Empleado = 1;
            //}

            //if (dateEmpleado_fechaNacimiento.SelectedDate > fecha_actual.Date)
            //{
            //    MessageBox.Show("La fecha de nacimiento es mayor o igual a la fecha actual", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    Vacio_Empleado = 1;
            //}
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtEmpleado_nombre.Text = "";
            txtEmpleado_apellidos.Text = "";
            txtEmpleado_puesto.Text = "";
        }

        #endregion Metodos

        //----------------------------------------------------------------------------------------------------------------------
        #region EVENTOS

        /*
         * El evento btnCargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarEmpleado. 
         */
        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarEmpleado();
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
            VacioEmpleado();
            if (Vacio_Empleado == 0)
            {
                using (GestorEmpleado Gestor = new GestorEmpleado())
                {
                    Gestor.EmpleadoInsertar(int.Parse(cbxEmpleado_Departamento_id.SelectedValue.ToString()), txtEmpleado_nombre.Text, txtEmpleado_apellidos.Text, DateTime.Parse(dateEmpleado_fechaNacimiento.SelectedDate.ToString()), txtEmpleado_puesto.Text,
                        cbxEmpleado_genero.SelectedItem.ToString(), cbxEmpleado_estadoCivil.SelectedItem.ToString(), DateTime.Parse(dateEmpleado_fechaIngreso.SelectedDate.ToString()), "A");
                }
                Empleado_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Empleado = 0;
        }

        /*
         * El evento btnmodificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioEmpleado();
                Empleado_id = int.Parse(ddlEmpleado.SelectedValue.ToString());
                if (ckbEmpleado.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }

                if (Vacio_Empleado == 0 && Empleado_id != 0)
                {
                    using (GestorEmpleado Gestor = new GestorEmpleado())
                    {
                        Gestor.EmpleadoModificar(Empleado_id, int.Parse(cbxEmpleado_Departamento_id.SelectedValue.ToString()), txtEmpleado_nombre.Text, txtEmpleado_apellidos.Text, DateTime.Parse(dateEmpleado_fechaNacimiento.SelectedDate.ToString()), txtEmpleado_puesto.Text,
                            cbxEmpleado_genero.SelectedItem.ToString(), cbxEmpleado_estadoCivil.SelectedItem.ToString(), DateTime.Parse(dateEmpleado_fechaIngreso.SelectedDate.ToString()), Estado);
                    }

                    Empleado_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Empleado = 0;
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
                Empleado_id = int.Parse(ddlEmpleado.SelectedValue.ToString());
                if (Empleado_id != 0)
                {
                    using (GestorEmpleado Gestor = new GestorEmpleado())
                    {
                        Gestor.EmpleadoInactivar(Empleado_id);
                    }

                    Empleado_id = 0;
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
                Empleado_id = int.Parse(ddlEmpleado.SelectedValue.ToString());
                if (Empleado_id != 0)
                {
                    using (GestorEmpleado Gestor = new GestorEmpleado())
                    {
                        Gestor.EmpleadoActivar(Empleado_id);
                    }

                    Empleado_id = 0;
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