using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmCaso : System.Web.UI.Page
    {
        DataSet dsCaso;
        DataTable dtCaso;
        private int Caso_id;
        int Vacio_Caso;
        string Estado;
        string Codigo;

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
                    this.dsCaso = servicioCL.usuarioConsultar(1);
                    this.dtCaso = this.dsCaso.Tables[0];
                }

                tipoUsuario = this.dtCaso.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbCaso.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }

        #region Metodos

        /*
        * El metodo CargarGridCasoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridCasoA()
        {
            using (GestorCaso servicioCL = new GestorCaso())
            {
                gvCaso.DataSource = servicioCL.CasoListarA();
                gvCaso.DataBind();
            }
        }

        /*
        * El metodo CargarGridCasoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridCasoI()
        {
            using (GestorCaso servicioCL = new GestorCaso())
            {
                gvCaso.DataSource = servicioCL.CasoListarI();
                gvCaso.DataBind();
            }
        }

        /*
         * El metodo CargarComboCasoA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboCasoA()
        {
            using (GestorCaso servicioCL = new GestorCaso())
            {
                ddlCaso.DataSource = servicioCL.CasoListarA();

                ddlCaso.DataValueField = "Caso_id";
                ddlCaso.DataTextField = "Caso_codigo";

                ddlCaso.DataBind();
            }
        }

        /*
         * El metodo CargarComboCasoI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboCasoI()
        {
            using (GestorCaso servicioCL = new GestorCaso())
            {
                ddlCaso.DataSource = servicioCL.CasoListarI();

                ddlCaso.DataValueField = "Caso_id";
                ddlCaso.DataTextField = "Caso_codigo";

                ddlCaso.DataBind();
            }
        }

        /*
         * El metodo BuscarCaso se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarCaso()
        {
            Caso_id = int.Parse(ddlCaso.SelectedValue.ToString());
            using (GestorCaso servicioCL = new GestorCaso())
            {
                this.dsCaso = servicioCL.CasoConsultar(Caso_id);
                this.dtCaso = this.dsCaso.Tables[0];
            }
            CargarDatosCaso();
        }

        /*
         * El metodo CargarDatosCaso se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosCaso()
        {
            try
            {
                cbxCaso_TramiteId.Text = this.dtCaso.Rows[0]["Tramite_id"].ToString();
            }
            catch (Exception)
            {
                cbxCaso_TramiteId.Items.Add(this.dtCaso.Rows[0]["Tramite_id"].ToString());
                cbxCaso_TramiteId.Text = this.dtCaso.Rows[0]["Tramite_id"].ToString();
            }
            txtCaso_Codigo.Text = this.dtCaso.Rows[0]["Caso_codigo"].ToString();
            Codigo = this.dtCaso.Rows[0]["Caso_codigo"].ToString();
            dtpCaso_fechaInicio.SelectMonthText = this.dtCaso.Rows[0]["Caso_fechaInicio"].ToString();
            dtpCaso_fechaFinal.SelectMonthText = this.dtCaso.Rows[0]["Caso_fechaFinal"].ToString();
            Estado = this.dtCaso.Rows[0]["Caso_estado"].ToString();
        }

        /*
         * El metodo cagarDatoscbxCaso_TramiteId se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void cagarDatoscbxCaso_TramiteId()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                cbxCaso_TramiteId.DataSource = servicioCL.TramiteListarA();

                cbxCaso_TramiteId.DataValueField = "Tramite_id";
                cbxCaso_TramiteId.DataTextField = "Tramite_nombre";

                cbxCaso_TramiteId.DataBind();
            }
        }

        /*
         * El metodo CodigoExistente es el encargado de revisar si ya existe un codigo de ser asi el usuario deberá
         * generar uno nuevo para ser nuevamente evaluado y poder insertar o modificar los datos
         */
        private string CodigoExistente(String codigo)
        {
            Caso_id = int.Parse(ddlCaso.SelectedValue.ToString());
            using (GestorCaso servicioCL = new GestorCaso())
            {
                this.dsCaso = servicioCL.CasoConsultar(Caso_id);
                this.dtCaso = this.dsCaso.Tables[0];
            }
            //

            string actual = this.dtCaso.Rows[0]["Caso_codigo"].ToString();


            if (codigo != actual)
            {
                using (GestorCaso servicioCL = new GestorCaso())
                {
                    this.dsCaso = servicioCL.CasoConsultarCodigo(codigo);
                    this.dtCaso = this.dsCaso.Tables[0];
                }
                if ((dtCaso == null) || (dtCaso.Rows.Count == 0))
                {
                    return "No existe";
                }
                else
                {
                    return "Existe";
                }
            }
            else
            {
                return "No existe";
            }

        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbCaso.Checked == false)
            {
                CargarGridCasoA();
                CargarComboCasoA();
            }
            else
            {
                CargarGridCasoI();
                CargarComboCasoI();
            }
            cagarDatoscbxCaso_TramiteId();
        }

        /*
         * El metodo VacioDepartamento se encarga de verificar que los espacios de los datos esten llenos
         */
        protected void VacioCaso()
        {
            if (cbxCaso_TramiteId.SelectedValue == null)
            {
                MessageBox.Show("Nombre del tramite 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Caso = 1;
            }
            if (txtCaso_Codigo.Text == "")
            {
                MessageBox.Show("Codigo del caso 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Caso = 1;
            }
            else
            {
                if (CodigoExistente(txtCaso_Codigo.Text) == "Existe")
                {
                    MessageBox.Show("Codigo del caso ya existe, generar uno nuevo ", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Vacio_Caso = 1;
                }
            }
            //if (dtpCaso_fechaInicio.SelectedDates >= dtpCaso_fechaFinal.SelectedDate)
            //{
            //    MessageBox.Show("La fecha inicil es mayor o igual a la fecha final ", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    Vacio_Caso = 1;
            //}
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtCaso_Codigo.Text = "";
        }


        #endregion Metodos
        //----------------------------------------------------------------------------------------------------------------------    
        #region EVENTOS

        /*
         * El evento btnCargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarCaso. 
         */
        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCaso();
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
            VacioCaso();
            if (Vacio_Caso == 0)
            {
                using (GestorCaso Gestor = new GestorCaso())
                {
                    Gestor.CasoInsertar(int.Parse(cbxCaso_TramiteId.SelectedValue.ToString()), txtCaso_Codigo.Text, DateTime.Parse(dtpCaso_fechaInicio.SelectMonthText.ToString()), DateTime.Parse(dtpCaso_fechaFinal.SelectMonthText.ToString()), "A");
                }

                Caso_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Caso = 0;
        }


        /*
         * El evento btnmodificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioCaso();
                Caso_id = int.Parse(ddlCaso.SelectedValue.ToString());
                if (Vacio_Caso == 0 && Caso_id != 0)
                {
                    using (GestorCaso Gestor = new GestorCaso())
                    {
                        if (ckbCaso.Checked == false)
                        {
                            Gestor.CasoModificar(Caso_id, int.Parse(cbxCaso_TramiteId.SelectedValue.ToString()), txtCaso_Codigo.Text,
                            DateTime.Parse(dtpCaso_fechaInicio.SelectedDate.ToString()), DateTime.Parse(dtpCaso_fechaFinal.SelectedDate.ToString()), "A");
                        }
                        else
                        {
                            Gestor.CasoModificar(Caso_id, int.Parse(cbxCaso_TramiteId.SelectedValue.ToString()), txtCaso_Codigo.Text,
                            DateTime.Parse(dtpCaso_fechaInicio.SelectedDate.ToString()), DateTime.Parse(dtpCaso_fechaFinal.SelectedDate.ToString()), "I");
                        }
                    }

                    Caso_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Caso = 0;
            }
            catch (Exception)
            {

            }
        }

        /*
         * El evento btnCaso_Inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Caso_id = int.Parse(ddlCaso.SelectedValue.ToString());
                if (Caso_id != 0)
                {
                    using (GestorCaso Gestor = new GestorCaso())
                    {
                        Gestor.CasoInactivar(Caso_id);
                    }

                    Caso_id = 0;
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
                Caso_id = int.Parse(ddlCaso.SelectedValue.ToString());
                if (Caso_id != 0)
                {
                    using (GestorCaso Gestor = new GestorCaso())
                    {
                        Gestor.CasoActivar(Caso_id);
                    }

                    Caso_id = 0;
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

        /*
         * El evento Button16_Click se encarga de generar un codigo alfanumerico para el codigo del caso.
         */
        protected void Button16_Click(object sender, EventArgs e)
        {

            int tamaño = 5;
            string Codigo = string.Empty;
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Random Eleccion = new Random();

            for (int i = 0; i < tamaño; i++)
            {
                int Letra = Eleccion.Next(0, 100);
                int Numero = Eleccion.Next(0, 9);

                if (Letra < letras.Length)
                {
                    Codigo += letras[Letra];
                    txtCaso_Codigo.Text = Codigo;
                }
                else
                {
                    Codigo += Numero.ToString();
                    txtCaso_Codigo.Text = Codigo;
                }
            }

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