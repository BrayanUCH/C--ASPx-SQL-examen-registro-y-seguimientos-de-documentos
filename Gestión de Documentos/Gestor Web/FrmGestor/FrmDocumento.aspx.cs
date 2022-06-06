using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmDocumento : System.Web.UI.Page
    {
        DataSet dsDocumento;
        DataTable dtDocumento;
        private int Documento_id;
        int Vacio_Documento;
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
                    this.dsDocumento = servicioCL.usuarioConsultar(1);
                    this.dtDocumento = this.dsDocumento.Tables[0];
                }

                tipoUsuario = this.dtDocumento.Rows[0]["Usuario_tipo"].ToString();

                if (tipoUsuario == "Usuario")
                {
                    ckbDocumento.Visible = false;
                    btnActivar.Visible = false;
                    Actualizar_datos.Visible = false;
                }
                //
            }
        }
        #region Metodos

        /*
        * El metodo CargarGridDocumentoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridDocumentoA()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                gvDocumento.DataSource = servicioCL.DocumentoListarA();
                gvDocumento.DataBind();
            }
        }

        /*
        * El metodo CargarGridDocumentoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridDocumentoI()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                gvDocumento.DataSource = servicioCL.DocumentoListarI();
                gvDocumento.DataBind();
            }
        }

        /*
         * El metodo CargarComboDocumentoA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboDocumentoA()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                ddlDocumento.DataSource = servicioCL.DocumentoListarA();

                ddlDocumento.DataValueField = "Documento_id";
                ddlDocumento.DataTextField = "Documento_nombre";

                ddlDocumento.DataBind();
            }
        }
        /*
         * El metodo CargarComboDocumentoI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboDocumentoI()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                ddlDocumento.DataSource = servicioCL.DocumentoListarI();

                ddlDocumento.DataValueField = "Documento_id";
                ddlDocumento.DataTextField = "Documento_nombre";

                ddlDocumento.DataBind();
            }
        }

        /*
         * El metodo BuscarDocumento se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarDocumento()
        {
            Documento_id = int.Parse(ddlDocumento.SelectedValue.ToString());
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                this.dsDocumento = servicioCL.DocumentoConsultar(Documento_id);
                this.dtDocumento = this.dsDocumento.Tables[0];
            }
            CargarDatosDocumento();
        }

        /*
         * El metodo CargarDatosDocumento se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosDocumento()
        {
            try
            {
                cbxDocumento_TramiteId.Text = this.dtDocumento.Rows[0]["Tramite_id"].ToString();
            }
            catch (Exception)
            {
                cbxDocumento_TramiteId.Items.Add(this.dtDocumento.Rows[0]["Tramite_id"].ToString());
                cbxDocumento_TramiteId.Text = this.dtDocumento.Rows[0]["Tramite_id"].ToString();
            }
            try
            {
                cbxDocumento_IdiomaId.Text = this.dtDocumento.Rows[0]["Idioma_id"].ToString();

            }
            catch (Exception)
            {
                cbxDocumento_IdiomaId.Items.Add(this.dtDocumento.Rows[0]["Idioma_id"].ToString());
                cbxDocumento_IdiomaId.Text = this.dtDocumento.Rows[0]["Idioma_id"].ToString();
            }

            txtDocumento_nombre.Text = this.dtDocumento.Rows[0]["Documento_nombre"].ToString();
            txtDocumento_ruta.Text = this.dtDocumento.Rows[0]["Documento_ruta"].ToString();
            txtDocumento_tipo.Text = this.dtDocumento.Rows[0]["Documento_tipo"].ToString();
            Estado = this.dtDocumento.Rows[0]["Documento_estado"].ToString();
        }

        /*
         * El metodo cagarDatoscbxDocumento_TramiteId se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void cagarDatoscbxDocumento_TramiteId()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                cbxDocumento_TramiteId.DataSource = servicioCL.TramiteListarA();
                cbxDocumento_TramiteId.DataValueField = "Tramite_id";
                cbxDocumento_TramiteId.DataTextField = "Tramite_nombre";

                cbxDocumento_TramiteId.DataBind();
            }
        }

        /*
         * El metodo cagarDatoscbxcbxDocumento_IdiomaId se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void cagarDatoscbxcbxDocumento_IdiomaId()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                cbxDocumento_IdiomaId.DataSource = servicioCL.IdiomaListarA();
                cbxDocumento_IdiomaId.DataValueField = "Idioma_id";
                cbxDocumento_IdiomaId.DataTextField = "Idioma_nombre";

                cbxDocumento_IdiomaId.DataBind();
            }
        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y comboBox
         */
        protected void actualizarDatos()
        {
            if (ckbDocumento.Checked == false)
            {
                CargarGridDocumentoA();
                CargarComboDocumentoA();
                cagarDatoscbxDocumento_TramiteId();
                cagarDatoscbxcbxDocumento_IdiomaId();
            }
            else
            {
                CargarGridDocumentoI();
                CargarComboDocumentoI();
                cagarDatoscbxDocumento_TramiteId();
                cagarDatoscbxcbxDocumento_IdiomaId();
            }
        }

        /*
         * El metodo VacioDocumento se encarga de verificar que los espacios de los datos esten llenos
         */
        protected void VacioDocumento()
        {
            if (cbxDocumento_TramiteId.SelectedValue == null)
            {
                MessageBox.Show("Nombre del tramite 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Documento = 1;
            }
            if (cbxDocumento_IdiomaId.SelectedValue == null)
            {
                MessageBox.Show("Nombre del idioma 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Documento = 1;
            }
            if (txtDocumento_nombre.Text == "")
            {
                MessageBox.Show("Nombre del documento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Documento = 1;
            }
            if (txtDocumento_ruta.Text == "")
            {
                MessageBox.Show("Ruta del documento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Documento = 1;
            }
            if (txtDocumento_tipo.Text == "")
            {
                MessageBox.Show("Tipo de documento 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Documento = 1;
            }
        }

        /*
         * El metodo Limpiar_txt limpia los datos de los txt presentes en la pagina
         */
        protected void Limpiar_txt()
        {
            txtDocumento_nombre.Text = "";
            txtDocumento_ruta.Text = "";
            txtDocumento_tipo.Text = "";
        }

        #endregion Metodos

        //----------------------------------------------------------------------------------------------------------------------    
        #region EVENTOS

        /*
         * El evento btnCargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarDocumento. 
         */
        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarDocumento();
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
            VacioDocumento();
            if (Vacio_Documento == 0)
            {
                using (GestorDocumento Gestor = new GestorDocumento())
                {
                    Gestor.DocumentoInsertar(int.Parse(cbxDocumento_TramiteId.SelectedValue.ToString()), int.Parse(cbxDocumento_IdiomaId.SelectedValue.ToString()),
                        txtDocumento_nombre.Text, txtDocumento_ruta.Text, txtDocumento_tipo.Text, "A");
                }

                Documento_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Documento = 0;
        }

        /*
         * El evento btnmodificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                VacioDocumento();

                Documento_id = int.Parse(ddlDocumento.SelectedValue.ToString());
                if (ckbDocumento.Checked == false)
                {
                    Estado = "A";
                }
                else
                {
                    Estado = "I";
                }

                if (Vacio_Documento == 0 && Documento_id != 0)
                {
                    using (GestorDocumento Gestor = new GestorDocumento())
                    {
                        Gestor.DocumentoModificar(Documento_id, int.Parse(cbxDocumento_TramiteId.SelectedValue.ToString()), int.Parse(cbxDocumento_IdiomaId.SelectedValue.ToString()),
                            txtDocumento_nombre.Text, txtDocumento_ruta.Text, txtDocumento_tipo.Text, Estado);
                    }

                    Documento_id = 0;
                    actualizarDatos();
                    Limpiar_txt();
                }
                Vacio_Documento = 0;
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
                Documento_id = int.Parse(ddlDocumento.SelectedValue.ToString());
                if (Documento_id != 0)
                {
                    using (GestorDocumento Gestor = new GestorDocumento())
                    {
                        Gestor.DocumentoInactivar(Documento_id);
                    }
                    Documento_id = 0;
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
                Documento_id = int.Parse(ddlDocumento.SelectedValue.ToString());
                if (Documento_id != 0)
                {
                    using (GestorDocumento Gestor = new GestorDocumento())
                    {
                        Gestor.DocumentoActivar(Documento_id);
                    }
                    Documento_id = 0;
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