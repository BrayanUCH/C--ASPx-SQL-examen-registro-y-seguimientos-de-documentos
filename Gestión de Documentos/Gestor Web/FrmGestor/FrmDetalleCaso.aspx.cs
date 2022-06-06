using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmDetalleCaso : System.Web.UI.Page
    {
        DataSet dsDetalleCaso;
        DataTable dtDetalleCaso;
        private int DetalleCaso_id;
        int Vacio_DetalleCaso;
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
                    this.dsDetalleCaso = servicioCL.usuarioConsultar(1);
                    this.dtDetalleCaso = this.dsDetalleCaso.Tables[0];
                }

                tipoUsuario = this.dtDetalleCaso.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbDetalleCaso.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }
        #region Metodos

        /*
        * El metodo CargarGridDetalleCasoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridDetalleCasoA()
        {
            using (GestorDetalleCaso servicioCL = new GestorDetalleCaso())
            {
                gvDetalleCaso.DataSource = servicioCL.DetalleCasoListarA();
                gvDetalleCaso.DataBind();
            }
        }

        /*
        * El metodo CargarGridDetalleCasoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridDetalleCasoI()
        {
            using (GestorDetalleCaso servicioCL = new GestorDetalleCaso())
            {
                gvDetalleCaso.DataSource = servicioCL.DetalleCasoListarI();
                gvDetalleCaso.DataBind();
            }
        }

        /*
         * El metodo CargarComboDetalleCasoA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboDetalleCasoA()
        {
            using (GestorDetalleCaso servicioCL = new GestorDetalleCaso())
            {
                ddlDetalleCaso.DataSource = servicioCL.DetalleCasoListarA();

                ddlDetalleCaso.DataValueField = "DetalleCaso_id";
                ddlDetalleCaso.DataTextField = "DetalleCaso_descripcion";

                ddlDetalleCaso.DataBind();
            }
        }

        /*
         * El metodo CargarComboDetalleCasoI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboDetalleCasoI()
        {
            using (GestorDetalleCaso servicioCL = new GestorDetalleCaso())
            {
                ddlDetalleCaso.DataSource = servicioCL.DetalleCasoListarI();

                ddlDetalleCaso.DataValueField = "DetalleCaso_id";
                ddlDetalleCaso.DataTextField = "DetalleCaso_descripcion";

                ddlDetalleCaso.DataBind();
            }
        }

        /*
         * El metodo BuscarDetalleCaso se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarDetalleCaso()
        {
            DetalleCaso_id = int.Parse(ddlDetalleCaso.SelectedValue.ToString());
            using (GestorDetalleCaso servicioCL = new GestorDetalleCaso())
            {
                this.dsDetalleCaso = servicioCL.DetalleCasoConsultar(DetalleCaso_id);
                this.dtDetalleCaso = this.dsDetalleCaso.Tables[0];
            }
            CargarDatosDetalleCaso();
        }

        /*
         * El metodo CargarDatosDetalleCaso se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosDetalleCaso()
        {
            try
            {
                cbxCaso_id.Text = this.dtDetalleCaso.Rows[0]["Caso_id"].ToString();
            }
            catch (Exception)
            {
                cbxCaso_id.Items.Add(this.dtDetalleCaso.Rows[0]["Caso_id"].ToString());
                cbxCaso_id.Text = this.dtDetalleCaso.Rows[0]["Caso_id"].ToString();
            }
            try
            {
                cbxCiclo_id.Text = this.dtDetalleCaso.Rows[0]["Ciclo_id"].ToString();
            }
            catch (Exception)
            {
                cbxCiclo_id.Items.Add(this.dtDetalleCaso.Rows[0]["Ciclo_id"].ToString());
                cbxCiclo_id.Text = this.dtDetalleCaso.Rows[0]["Ciclo_id"].ToString();
            }
            try
            {
                cbxDocumento_id.Text = this.dtDetalleCaso.Rows[0]["Documento_id"].ToString();
            }
            catch (Exception)
            {
                cbxDocumento_id.Items.Add(this.dtDetalleCaso.Rows[0]["Documento_id"].ToString());
                cbxDocumento_id.Text = this.dtDetalleCaso.Rows[0]["Documento_id"].ToString();
            }

            dtpDetalleCaso_fechaRecibido.NextMonthText = this.dtDetalleCaso.Rows[0]["DetalleCaso_fechaRecibido"].ToString();
            dtpDetalleCaso_fechaTranspaso.NextMonthText = this.dtDetalleCaso.Rows[0]["DetalleCaso_fechaTranspaso"].ToString();
            txtDetalleCaso_descripcion.Text = this.dtDetalleCaso.Rows[0]["DetalleCaso_descripcion"].ToString();
            Estado = this.dtDetalleCaso.Rows[0]["DetalleCaso_estado"].ToString();
        }

        /*
         * El metodo CargarComboIdDetalleCasoCaso se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void CargarComboIdDetalleCasoCaso()
        {
            using (GestorCaso servicioCL = new GestorCaso())
            {
                cbxCaso_id.DataSource = servicioCL.CasoListarA();

                cbxCaso_id.DataValueField = "Caso_id";
                cbxCaso_id.DataTextField = "Caso_codigo";

                cbxCaso_id.DataBind();
            }
        }

        /*
         * El metodo CargarComboIdDetalleCasoEmpleado se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void CargarComboIdDetalleCasoCiclo()
        {
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                cbxCiclo_id.DataSource = servicioCL.CicloListarA();

                cbxCiclo_id.DataValueField = "Ciclo_id";
                cbxCiclo_id.DataTextField = "Ciclo_orden";

                cbxCiclo_id.DataBind();
            }
        }

        /*
         * El metodo CargarComboIdDetalleCasoDocumento se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void CargarComboIdDetalleCasoDocumento()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                cbxDocumento_id.DataSource = servicioCL.DocumentoListarA();

                cbxDocumento_id.DataValueField = "Documento_id";
                cbxDocumento_id.DataTextField = "Documento_nombre";

                cbxDocumento_id.DataBind();
            }
        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbDetalleCaso.Checked == false)
            {
                CargarGridDetalleCasoA();
                CargarComboDetalleCasoA();
            }
            else
            {
                CargarGridDetalleCasoI();
                CargarComboDetalleCasoI();
            }
            CargarComboIdDetalleCasoCaso();
            CargarComboIdDetalleCasoDocumento();
            CargarComboIdDetalleCasoCiclo();
        }

        /*
         * El metodo VacioDetalleCaso se encarga de verificar que los espacios de los datos esten llenos
         */
        protected void VacioDetalleCaso()
        {
            if (cbxCaso_id.SelectedValue == null)
            {
                MessageBox.Show("Nombre del caso 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_DetalleCaso = 1;
            }
            if (cbxCiclo_id.SelectedValue == null)
            {
                MessageBox.Show("Nombre del ciclo 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_DetalleCaso = 1;
            }
            if (cbxDocumento_id.SelectedValue == null)
            {
                MessageBox.Show("Nombre del documento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_DetalleCaso = 1;
            }
            //if (dtpDetalleCaso_fechaRecibido.Value > dtpDetalleCaso_fechaTranspaso.Value)
            //{
            //    MessageBox.Show("La fecha de resivido es mayor a la fecha de traspaso ", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    Vacio_DetalleCaso = 1;
            //}
            if (txtDetalleCaso_descripcion.Text == "")
            {
                MessageBox.Show("Descripcion del detalle del caso esta 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_DetalleCaso = 1;
            }
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtDetalleCaso_descripcion.Text = "";
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
                BuscarDetalleCaso();
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
            VacioDetalleCaso();
            if (Vacio_DetalleCaso == 0)
            {
                using (GestorDetalleCaso Gestor = new GestorDetalleCaso())
                {
                    Gestor.DetalleCasoInsertar(int.Parse(cbxCaso_id.SelectedValue.ToString()), int.Parse(cbxCiclo_id.SelectedValue.ToString()), int.Parse(cbxDocumento_id.SelectedValue.ToString()),
                         DateTime.Parse(dtpDetalleCaso_fechaRecibido.SelectedDate.ToString()), DateTime.Parse(dtpDetalleCaso_fechaTranspaso.SelectedDate.ToString()), txtDetalleCaso_descripcion.Text, "A");
                }

                DetalleCaso_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_DetalleCaso = 0;
        }

        /*
         * El evento btnDepartamento_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioDetalleCaso();
                DetalleCaso_id = int.Parse(ddlDetalleCaso.SelectedValue.ToString());
                if (ckbDetalleCaso.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }
                if (Vacio_DetalleCaso == 0 && DetalleCaso_id != 0)
                {
                    using (GestorDetalleCaso Gestor = new GestorDetalleCaso())
                    {
                        Gestor.DetalleCasoModificar(DetalleCaso_id, int.Parse(cbxCaso_id.SelectedValue.ToString()), int.Parse(cbxCiclo_id.SelectedValue.ToString()), int.Parse(cbxDocumento_id.SelectedValue.ToString()),
                             DateTime.Parse(dtpDetalleCaso_fechaRecibido.SelectedDate.ToString()),
                             DateTime.Parse(dtpDetalleCaso_fechaTranspaso.SelectedDate.ToString()), txtDetalleCaso_descripcion.Text, Estado);
                    }

                    DetalleCaso_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_DetalleCaso = 0;
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
                DetalleCaso_id = int.Parse(ddlDetalleCaso.SelectedValue.ToString());
                if (DetalleCaso_id != 0)
                {
                    using (GestorDetalleCaso Gestor = new GestorDetalleCaso())
                    {
                        Gestor.DetalleCasoInactivar(DetalleCaso_id);
                    }

                    DetalleCaso_id = 0;
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
                DetalleCaso_id = int.Parse(ddlDetalleCaso.SelectedValue.ToString());
                if (DetalleCaso_id != 0)
                {
                    using (GestorDetalleCaso Gestor = new GestorDetalleCaso())
                    {
                        Gestor.DetalleCasoActivar(DetalleCaso_id);
                    }

                    DetalleCaso_id = 0;
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