using Capa_Integracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{

    /*
     * La clase Form1 es la que se encarga de hacer todos lo registro que se requieren en el programa.
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DateTime fecha_actual;

        //====================================================================================

        /*
         * El metodo tipoUsuario se encarga de resivir una variable de otro from o clase
         * para determinar si es un usuario o administrador y poder llamar al metodo Inactivar_funciones
         * que inavilita determinadas funciones al usuario.
         */
        internal void tipoUsuario(bool tipo)
        {
            if (tipo == false)
            {
                Inactivar_funciones();
            }
        }
        //====================================================================================

        /**
         * El metodo Form1_Load se encarga de cargar los grid con los datos 
         * de la base de datos y los combos de cargar datos.
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            fecha_actual = DateTime.Now;
            actualizarDatos();
        }

        /*
         * El metodo actualizarDatos se encarga de actualizar los datos de las tablas y los commboBox
         */
        void actualizarDatos()
        {
            //organizacion
            if (ckbOrganizacionMostrarInactivos.Checked == false)
            {
                CargarGridOrganizacionA();
                CargarComboOrganizacionA();
            }
            else
            {
                CargarGridOrganizacionI();
                CargarComboOrganizacionI();
            }
            //codigo
            if (ckbCodigoMostrarInactivos.Checked == false)
            {
                CargarGridCodigoA();
                CargarComboCodigoA();
            }
            else
            {
                CargarGridCodigoI();
                CargarComboCodigoI();
            }
            CargarComboIdOrganizacion();
            //idioma
            if (ckbIdioma_MostrarInactivos.Checked == false)
            {
                CargarGridIdiomaA();
                CargarComboIdiomaA();
            }
            else
            {
                CargarGridIdiomaI();
                CargarComboIdiomaI();
            }
            //departamento
            if (ckbDepartamentoMostrarInactivos.Checked == false)
            {
                CargarGridDepartamentoA();
                CargarComboDepartamentoA();
            }
            else
            {
                CargarGridDepartamentoI();
                CargarComboDepartamentoI();
            }
            CargarComboIdOrganizacionDepartamento();
            //empleado
            if (ckbEmpleadoMostrarInactivos.Checked == false)
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
            //tramite
            if (ckbTramiteMostrarInactivos.Checked == false)
            {
                CargarGridTramiteA();
                CargarComboTramiteA();

            }
            else
            {
                CargarGridTramiteI();
                CargarComboTramiteI();
            }
            //ciclo
            if (ckbCicloMostrarInactivos.Checked == false)
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
            //documento
            if (ckbDocumentoMostrarInactivos.Checked == false)
            {
                CargarGridDocumentoA();
                CargarComboDocumentoA();
            }
            else
            {
                CargarGridDocumentoI();
                CargarComboDocumentoI();
            }
            cagarDatoscbxDocumento_TramiteId();
            cagarDatoscbxcbxDocumento_IdiomaId();
            //caso
            if (ckbCasoMostrarInactivos.Checked == false)
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
            //detalle del caso
            if (ckbDetalleCasoMostrarInactivos.Checked == false)
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
            CargarComboIdDetalleCasoEmpleado();
            //
        }
        //====================================================================================
        #region VARIABLES

        /**
         * Las presentes variables son las responsables de algunos de los metodos de las tablas.
         */

        DataSet dsOrganizacion = new DataSet();
        DataTable dtOrganizacion = new DataTable();
        int Organizacion_id = 0;
        int Vacio_Organizacion = 0;

        DataSet dsCodigo = new DataSet();
        DataTable dtCodigo = new DataTable();
        int Codigo_id = 0;
        int Vacio_Codigo = 0;

        DataSet dsIdioma = new DataSet();
        DataTable dtIdioma = new DataTable();
        int Idioma_id = 0;
        int Vacio_Idioma = 0;

        DataSet dsDepartamento = new DataSet();
        DataTable dtDepartamento = new DataTable();
        int Departamento_id = 0;
        int Vacio_Departamento = 0;

        DataSet dsEmpleado = new DataSet();
        DataTable dtEmpleado = new DataTable();
        int Empleado_id = 0;
        int Vacio_Empleado = 0;

        DataSet dsTramite = new DataSet();
        DataTable dtTramite = new DataTable();
        int Tramite_id = 0;
        int Vacio_Tramite = 0;

        DataSet dsCiclo = new DataSet();
        DataTable dtCiclo = new DataTable();
        int Ciclo_id = 0;
        int Vacio_Ciclo = 0;

        DataSet dsDocumento = new DataSet();
        DataTable dtDocumento = new DataTable();
        int Documento_id = 0;
        int Vacio_Documento = 0;

        DataSet dsCaso = new DataSet();
        DataTable dtCaso = new DataTable();
        int Caso_id = 0;
        int Vacio_Caso = 0;
        string Codigo;

        DataSet dsDetalleCaso = new DataSet();
        DataTable dtDetalleCaso = new DataTable();
        int DetalleCaso_id = 0;
        int Vacio_DetalleCaso = 0;

        #endregion VARIABLES
        //====================================================================================
        #region INACTIVAR_FUNCIONES

        /*
         *El metodo Inactivar_funciones es el encargado de desabilitar determinadas funciones
         *que no pueden ser utilizadas por el usuario comun.
         */
        void Inactivar_funciones()
        {
                btnOrganizacion_activar.Visible = false;
                ckbOrganizacionMostrarInactivos.Visible = false;
                btnCodigo_activar.Visible = false;
                ckbCodigoMostrarInactivos.Visible = false;
                btnIdioma_activar.Visible = false;
                ckbIdioma_MostrarInactivos.Visible = false;
                btnDepartamento_activar.Visible = false;
                ckbDepartamentoMostrarInactivos.Visible = false;
                btnEmpleado_activar.Visible = false;
                ckbEmpleadoMostrarInactivos.Visible = false;
                btnTramite_activar.Visible = false;
                ckbTramiteMostrarInactivos.Visible = false;
                btnCiclo_activar.Visible = false;
                ckbCicloMostrarInactivos.Visible = false;
                btnDocumento_Activar.Visible = false;
                ckbDocumentoMostrarInactivos.Visible = false;
                btnCaso_Activar.Visible = false;
                ckbCasoMostrarInactivos.Visible = false;
                btnDetalleCaso_activar.Visible = false;
                ckbDetalleCasoMostrarInactivos.Visible = false;
        }

        #endregion INACTIVAR_FUNCIONES
        //====================================================================================
        #region vacios o no 
        /*
         * Los metodos de esta region son los encargados de hacer las validaciones para la verificación
         * en el momento de insertar o modificar algun elemento de las tablas.
         * */

        private void VacioOrganizacion()
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

        private void VacioIdioma()
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

        private void VacioDepartamento()
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

        private void VacioEmpleado()
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

            if (dateEmpleado_fechaNacimiento.Value > fecha_actual)
            {
                MessageBox.Show("La fecha de nacimiento es mayor o igual a la fecha actual", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        }

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

        private void VacioCiclo()
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

        private void VacioDocumento()
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

        private void VacioCaso()
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
            if (dtpCaso_fechaInicio.Value >= dtpCaso_fechaFinal.Value)
            {
                MessageBox.Show("La fecha inicil es mayor o igual a la fecha final ", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_Caso = 1;
            }
        }

        private void VacioDetalleCaso()
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
            if (dtpDetalleCaso_fechaRecibido.Value > dtpDetalleCaso_fechaTranspaso.Value)
            {
                MessageBox.Show("La fecha de resivido es mayor a la fecha de traspaso ", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_DetalleCaso = 1;
            }
            if (txtDetalleCaso_descripcion.Text == "")
            {
                MessageBox.Show("Descripcion del detalle del caso esta 'Vacio'", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Vacio_DetalleCaso = 1;
            }   
        }

        #endregion vacios o no 
        //====================================================================================
        #region Limpiar_txt

        /*
         * El metodo Limpiar_txt se encarga de hacer la limpieza de los texbox presentes en la interfas.
         */
        void Limpiar_txt()
        {
            txtOrganizacion_nombre.Text = "";
            txtOrganizacion_tipo.Text = "";
            txtOrganizacion_descripcion.Text = "";
            txtCodigo_Codigo_formato.Text = "";
            txtIdioma_nombre.Text = "";
            txtIdioma_iniciales.Text = "";
            txtDepartamento_nombre.Text = "";
            txtDepartamento_tipo.Text = "";
            txtDepartamento_descripcion.Text = "";
            txtEmpleado_nombre.Text = "";
            txtEmpleado_apellidos.Text = "";
            txtEmpleado_puesto.Text = "";
            txtTramite_nombre.Text = "";
            txtTramite_descripcion.Text = "";
            txtCiclo_orden.Text = "";
            txtDocumento_nombre.Text = "";
            txtDocumento_ruta.Text = "";
            txtDocumento_tipo.Text = "";
            txtCaso_Codigo.Text = "";
            txtDetalleCaso_descripcion.Text = "";
        }

        #endregion Limpiar_txt
        //====================================================================================
        #region ORGANIZACION 

        #region Metodos

        /*
         * El metodo CargarGridOrganizacionA es el encargado de cargar los datos de los activos en la tabla.
         */
        private void CargarGridOrganizacionA()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                dgvOrganizacion.DataSource = servicioCL.OrganizacionListarA();

                dgvOrganizacion.Columns["Organizacion_id"].HeaderText = "ID";
                dgvOrganizacion.Columns["Organizacion_nombre"].HeaderText = "Nombre de la organización";
                dgvOrganizacion.Columns["Organizacion_tipo"].HeaderText = "Tipo de la organización";
                dgvOrganizacion.Columns["Organizacion_descripcion"].HeaderText = "Descripccion de la organización";
                dgvOrganizacion.Columns["Organizacion_estado"].Visible = false;
            }
        }

        /*
        * El metodo CargarGridOrganizacionI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridOrganizacionI()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                dgvOrganizacion.DataSource = servicioCL.OrganizacionListarI();

                dgvOrganizacion.Columns["Organizacion_id"].HeaderText = "ID";
                dgvOrganizacion.Columns["Organizacion_nombre"].HeaderText = "Nombre de la organización";
                dgvOrganizacion.Columns["Organizacion_tipo"].HeaderText = "Tipo de la organización";
                dgvOrganizacion.Columns["Organizacion_descripcion"].HeaderText = "Descripccion de la organización";
                dgvOrganizacion.Columns["Organizacion_estado"].Visible = false;
            }
        }

        /*
         * El metodo CargarComboOrganizacionA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboOrganizacionA()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                cbxOrganizacion.DataSource = servicioCL.OrganizacionListarA();

                cbxOrganizacion.ValueMember = "Organizacion_id";
                cbxOrganizacion.DisplayMember = "Organizacion_nombre";
            }
        }

        /*
         * El metodo CargarComboOrganizacionI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboOrganizacionI()
        {
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                cbxOrganizacion.DataSource = servicioCL.OrganizacionListarI();

                cbxOrganizacion.ValueMember = "Organizacion_id";
                cbxOrganizacion.DisplayMember = "Organizacion_nombre";
            }
        }

        /*
         * El metodo BuscarOrganizacion se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarOrganizacion()
        {
            Organizacion_id = int.Parse(cbxOrganizacion.SelectedValue.ToString());
            using (GestorOreganizacion servicioCL = new GestorOreganizacion())
            {
                this.dsOrganizacion = servicioCL.OrganizacionConsultar(Organizacion_id);
                this.dtOrganizacion = this.dsOrganizacion.Tables[0];
            }
            CargarDatosOrganizacion();
        }

        /*
         * El metodo CargarDatosOrganizacion se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosOrganizacion()
        {
            txtOrganizacion_nombre.Text = this.dtOrganizacion.Rows[0]["Organizacion_nombre"].ToString();
            txtOrganizacion_tipo.Text = this.dtOrganizacion.Rows[0]["Organizacion_tipo"].ToString();
            txtOrganizacion_descripcion.Text = this.dtOrganizacion.Rows[0]["Organizacion_descripcion"].ToString();
        }

        #endregion Metodos

        #region Eventos

        /*
         * El evento dgvOrganizacion_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dgvOrganizacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvOrganizacion.CurrentCell.RowIndex;
                Organizacion_id = int.Parse(this.dgvOrganizacion[0, numFila].Value.ToString());

                using (GestorOreganizacion Gestor = new GestorOreganizacion())
                {
                    dsOrganizacion = Gestor.OrganizacionConsultar(Organizacion_id);
                    this.dtOrganizacion = this.dsOrganizacion.Tables[0];

                }
                CargarDatosOrganizacion();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnOrganizacion_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarOrganizacion. 
         */
        private void btnOrganizacion_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarOrganizacion();
        }

        /*
         * El evento btnOrganizacion_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnOrganizacion_insertar_Click(object sender, EventArgs e)
        {
            VacioOrganizacion();
            if (Vacio_Organizacion == 0) { 
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
         * El evento btnOrganizacion_modificar_Clickse se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnOrganizacion_modificar_Click(object sender, EventArgs e)
        {
            VacioOrganizacion();
            if (Vacio_Organizacion == 0 && Organizacion_id != 0)
            {
                using (GestorOreganizacion Gestor = new GestorOreganizacion())
                {
                    Gestor.OrganizacionModificar(Organizacion_id, txtOrganizacion_nombre.Text, txtOrganizacion_tipo.Text, txtOrganizacion_descripcion.Text, this.dtOrganizacion.Rows[0]["Organizacion_estado"].ToString());
                }

                Organizacion_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Organizacion = 0;
        }

        /*
         * El evento btnOrganizacion_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnOrganizacion_inactivar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento btnOrganizacion_activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnOrganizacion_activar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento ckbOrganizacionMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbOrganizacionMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Organizacion_id = 0;
            actualizarDatos();
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion ORGANIZACION 
        //====================================================================================
        #region CODIGO

        #region Metodos

        /*
        * El metodo CargarGridCodigoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridCodigoA()
        {
            using (GestorCodigo Gestor = new GestorCodigo())
            {
                dgvCodigo.DataSource = Gestor.CodigoListarA();

                dgvCodigo.Columns["Codigo_id"].HeaderText = "ID";
                dgvCodigo.Columns["Organizacion_id"].HeaderText = "Organización id";
                dgvCodigo.Columns["Codigo_formato"].HeaderText = "Formato";
                dgvCodigo.Columns["Codigo_estado"].Visible = false;
            }
        }

        /*
        * El metodo CargarGridCodigoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridCodigoI()
        {
            using (GestorCodigo Gestor = new GestorCodigo())
            {
                dgvCodigo.DataSource = Gestor.CodigoListarI();

                dgvCodigo.Columns["Codigo_id"].HeaderText = "ID";
                dgvCodigo.Columns["Organizacion_id"].HeaderText = "Organización id";
                dgvCodigo.Columns["Codigo_formato"].HeaderText = "Formato";
                dgvCodigo.Columns["Codigo_estado"].Visible = false;
            }
        }

        /*
         * El metodo CargarComboCodigoA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboCodigoA()
        {
            using (GestorCodigo Gestor = new GestorCodigo())
            {
                cbxCodigo.DataSource = Gestor.CodigoListarA();

                cbxCodigo.ValueMember = "Codigo_id";
                cbxCodigo.DisplayMember = "Codigo_formato";
            }
        }

        /*
         * El metodo CargarComboCodigoI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboCodigoI()
        {
            using (GestorCodigo Gestor = new GestorCodigo())
            {
                cbxCodigo.DataSource = Gestor.CodigoListarI();

                cbxCodigo.ValueMember = "Codigo_id";
                cbxCodigo.DisplayMember = "Codigo_formato";
            }
        }

        /*
         * El metodo BuscarCodigo se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarCodigo()
        {
            Codigo_id = int.Parse(cbxCodigo.SelectedValue.ToString());

            using (GestorCodigo Gestor = new GestorCodigo())
            {
                this.dsCodigo = Gestor.CodigoConsultar(Codigo_id);
                this.dtCodigo = this.dsCodigo.Tables[0];
            }
            CargarDatosCodigo();
        }

        /*
         * El metodo CargarDatosCodigo se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosCodigo()
        {
            cbxCodigo_organizacion.Text = this.dtCodigo.Rows[0]["Organizacion_id"].ToString();
            txtCodigo_Codigo_formato.Text = this.dtCodigo.Rows[0]["Codigo_formato"].ToString();
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
                
                cbxCodigo_organizacion.ValueMember = "Organizacion_id";
                cbxCodigo_organizacion.DisplayMember = "Organizacion_id";
            }
        }

        #endregion Metodos

        #region Eventos

        /*
         * El evento dgvCodigo_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dgvCodigo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvCodigo.CurrentCell.RowIndex;
                Codigo_id = int.Parse(this.dgvCodigo[0, numFila].Value.ToString());

                using (GestorCodigo Gestor = new GestorCodigo())
                {
                    this.dsCodigo = Gestor.CodigoConsultar(Codigo_id);
                    this.dtCodigo = this.dsCodigo.Tables[0];

                }
                CargarDatosCodigo();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnCodigo_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarCodigo. 
         */
        private void btnCodigo_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarCodigo();
        }

        /*
         * El evento btnCodigo_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnCodigo_insertar_Click(object sender, EventArgs e)
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
         * El evento btnCodigo_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnCodigo_modificar_Click(object sender, EventArgs e)
        {
            VacioCodigo();
            if (Vacio_Codigo == 0 )
            {
                using (GestorCodigo Gestor = new GestorCodigo())
                {
                    MessageBox.Show("######### "+ int.Parse(cbxCodigo_organizacion.SelectedValue.ToString()), "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Gestor.CodigoModificar(Codigo_id, int.Parse(cbxCodigo_organizacion.SelectedValue.ToString()), txtCodigo_Codigo_formato.Text, "A");
                }

                Codigo_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Codigo = 0;
        }

        /*
         * El evento btnCodigo_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnCodigo_inactivar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento btnCodigo_activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnCodigo_activar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento ckbCodigoMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbCodigoMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Codigo_id = 0;
            actualizarDatos();
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion CODIGO PANEL
        //====================================================================================
        #region IDIOMA

        #region Metodos

        /*
        * El metodo CargarGridIdiomaA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridIdiomaA()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                dgvIdioma.DataSource = servicioCL.IdiomaListarA();

                dgvIdioma.Columns["Idioma_id"].HeaderText = "ID";
                dgvIdioma.Columns["Idioma_nombre"].HeaderText = "Nombre del idioma";
                dgvIdioma.Columns["Idioma_iniciales"].HeaderText = "Iniciales del idioma";
                dgvIdioma.Columns["Idioma_estado"].Visible = false;
            }
        }

        /*
        * El metodo CargarGridIdiomaI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridIdiomaI()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                dgvIdioma.DataSource = servicioCL.IdiomaListarI();

                dgvIdioma.Columns["Idioma_id"].HeaderText = "ID";
                dgvIdioma.Columns["Idioma_nombre"].HeaderText = "Nombre del idioma";
                dgvIdioma.Columns["Idioma_iniciales"].HeaderText = "Iniciales del idioma";
                dgvIdioma.Columns["Idioma_estado"].Visible = false;
            }
        }

        /*
         * El metodo CargarComboIdiomaA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboIdiomaA()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                cbxIdioma.DataSource = servicioCL.IdiomaListarA();

                cbxIdioma.ValueMember = "Idioma_id";
                cbxIdioma.DisplayMember = "Idioma_nombre";
            }
        }

        /*
         * El metodo CargarComboIdiomaI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboIdiomaI()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                cbxIdioma.DataSource = servicioCL.IdiomaListarI();

                cbxIdioma.ValueMember = "Idioma_id";
                cbxIdioma.DisplayMember = "Idioma_nombre";
            }
        }

        /*
         * El metodo BuscarIdioma se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarIdioma()
        {
            Idioma_id = int.Parse(cbxIdioma.SelectedValue.ToString());
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
        private void CargarDatosIdioma()
        {
            txtIdioma_nombre.Text = this.dtIdioma.Rows[0]["Idioma_nombre"].ToString();
            txtIdioma_iniciales.Text = this.dtIdioma.Rows[0]["Idioma_iniciales"].ToString();
        }

        #endregion Metodos

        #region Eventos

        /*
         * El evento dgvIdioma_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dgvIdioma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvIdioma.CurrentCell.RowIndex;
                Idioma_id = int.Parse(this.dgvIdioma[0, numFila].Value.ToString());

                using (GestorIdioma Gestor = new GestorIdioma())
                {
                    dsIdioma = Gestor.IdiomaConsultar(Idioma_id);
                    this.dtIdioma = this.dsIdioma.Tables[0];

                }
                CargarDatosIdioma();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnIdioma_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarIdioma. 
         */
        private void btnIdioma_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarIdioma();
        }

        /*
         * El evento btnIdioma_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnIdioma_insertar_Click(object sender, EventArgs e)
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
         * El evento btnIdioma_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnIdioma_modificar_Click(object sender, EventArgs e)
        {
            VacioIdioma();
            if (Vacio_Idioma == 0 && Idioma_id != 0)
            {
                using (GestorIdioma Gestor = new GestorIdioma())
                {
                    Gestor.IdiomaModificar(Idioma_id, txtIdioma_nombre.Text, txtIdioma_iniciales.Text, this.dtIdioma.Rows[0]["Idioma_estado"].ToString());
                }

                Idioma_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Idioma = 0;
        }

        /*
         * El evento btnIdioma_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnIdioma_inactivar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento btnIdioma_activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnIdioma_activar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento ckbIdioma_MostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbIdioma_MostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Idioma_id = 0;
            actualizarDatos();
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion IDIOMA
        //====================================================================================
        #region DEPARTAMENTO

        #region Metodos

        /*
        * El metodo CargarGridDepartamentoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridDepartamentoA()
        {
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                dgvDepartamento.DataSource = servicioCL.DepartamentoListarA();

                dgvDepartamento.Columns["Departamento_id"].HeaderText = "ID";
                dgvDepartamento.Columns["Organizacion_id"].HeaderText = "Organizacion id";
                dgvDepartamento.Columns["Departamento_nombre"].HeaderText = "Departamento nombre";
                dgvDepartamento.Columns["Departamento_tipo"].HeaderText = "Tipo";
                dgvDepartamento.Columns["Departamento_descripcion"].HeaderText = "Descripcion";
                dgvDepartamento.Columns["Departamento_estado"].Visible = false;
            }
        }

        /*
        * El metodo CargarGridDepartamentoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridDepartamentoI()
        {
            using (GestorDepartamento servicioCL = new GestorDepartamento())
            {
                dgvDepartamento.DataSource = servicioCL.DepartamentoListarI();

                dgvDepartamento.Columns["Departamento_id"].HeaderText = "ID";
                dgvDepartamento.Columns["Organizacion_id"].HeaderText = "Organizacion id";
                dgvDepartamento.Columns["Departamento_nombre"].HeaderText = "Departamento nombre";
                dgvDepartamento.Columns["Departamento_tipo"].HeaderText = "Tipo";
                dgvDepartamento.Columns["Departamento_descripcion"].HeaderText = "Descripcion";
                dgvDepartamento.Columns["Departamento_estado"].Visible = false;
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
                cbxDepartamento.DataSource = servicioCL.DepartamentoListarA();

                cbxDepartamento.ValueMember = "Departamento_id";
                cbxDepartamento.DisplayMember = "Departamento_nombre";
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
                cbxDepartamento.DataSource = servicioCL.DepartamentoListarI();

                cbxDepartamento.ValueMember = "Departamento_id";
                cbxDepartamento.DisplayMember = "Departamento_nombre";
            }
        }

        /*
         * El metodo BuscarDepartamento se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarDepartamento()
        {
            Departamento_id = int.Parse(cbxDepartamento.SelectedValue.ToString());
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
            cbxDepartamento_organizacion.Text = this.dtDepartamento.Rows[0]["Organizacion_id"].ToString();
            txtDepartamento_nombre.Text = this.dtDepartamento.Rows[0]["Departamento_nombre"].ToString();
            txtDepartamento_tipo.Text = this.dtDepartamento.Rows[0]["Departamento_tipo"].ToString();
            txtDepartamento_descripcion.Text = this.dtDepartamento.Rows[0]["Departamento_descripcion"].ToString();
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
               
                cbxDepartamento_organizacion.ValueMember = "Organizacion_id";
                cbxDepartamento_organizacion.DisplayMember = "Organizacion_nombre";
            }
        }

        #endregion Metodos

        #region Eventos

        /*
         * El evento dgvDepartamento_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dgvDepartamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvDepartamento.CurrentCell.RowIndex;
                Departamento_id = int.Parse(this.dgvDepartamento[0, numFila].Value.ToString());

                using (GestorDepartamento Gestor = new GestorDepartamento())
                {
                    dsDepartamento = Gestor.DepartamentoConsultar(Departamento_id);
                    this.dtDepartamento = this.dsDepartamento.Tables[0];

                }
                CargarDatosDepartamento();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnDepartamento_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarDepartamento. 
         */
        private void btnDepartamento_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarDepartamento();
        }

        /*
         * El evento btnDepartamento_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnDepartamento_insertar_Click(object sender, EventArgs e)
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
        private void btnDepartamento_modificar_Click(object sender, EventArgs e)
        {
            VacioDepartamento();
            if (Vacio_Departamento == 0 && Departamento_id != 0)
            {
                using (GestorDepartamento Gestor = new GestorDepartamento())
                {
                    Gestor.DepartamentoModificar(Departamento_id, int.Parse(cbxDepartamento_organizacion.SelectedValue.ToString()), txtDepartamento_nombre.Text, txtDepartamento_tipo.Text, txtDepartamento_descripcion.Text, this.dtDepartamento.Rows[0]["Departamento_estado"].ToString());
                }
                Departamento_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Departamento = 0;
        }

        /*
         * El evento btnDepartamento_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnDepartamento_inactivar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento btnDepartamento_activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnDepartamento_activar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento ckbDepartamentoMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbDepartamentoMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Departamento_id = 0;
            actualizarDatos();
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion DEPARTAMENTO
        //====================================================================================
        #region EMPLEADO

        #region Metodos
        /*
        * El metodo CargarGridEmpleadoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridEmpleadoA()
        {
            using (GestorEmpleado servicioCL = new GestorEmpleado())
            {
                dgvEmpleado.DataSource = servicioCL.EmpleadoListarA();

                dgvEmpleado.Columns["Empleado_id"].HeaderText = "ID";
                dgvEmpleado.Columns["Departamento_id"].HeaderText = "Departamento id";
                dgvEmpleado.Columns["Empleado_nombre"].HeaderText = "Nombre";
                dgvEmpleado.Columns["Empleado_apellidos"].HeaderText = "Apellidos";
                dgvEmpleado.Columns["Empleado_fechaNacimiento"].HeaderText = "Fecha de nacimiento";
                dgvEmpleado.Columns["Empleado_puesto"].HeaderText = "Puesto";
                dgvEmpleado.Columns["Empleado_genero"].HeaderText = "Genero";
                dgvEmpleado.Columns["Empleado_estadoCivil"].HeaderText = "Estado civil";
                dgvEmpleado.Columns["Empleado_fechaIngreso"].HeaderText = "Fecha de ingreso";
                dgvEmpleado.Columns["Empleado_estado"].Visible = false;
            }
        }

        /*
        * El metodo CargarGridEmpleadoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridEmpleadoI()
        {
            using (GestorEmpleado servicioCL = new GestorEmpleado())
            {
                dgvEmpleado.DataSource = servicioCL.EmpleadoListarI();

                dgvEmpleado.Columns["Empleado_id"].HeaderText = "ID";
                dgvEmpleado.Columns["Departamento_id"].HeaderText = "Departamento_id";
                dgvEmpleado.Columns["Empleado_nombre"].HeaderText = "Nombre";
                dgvEmpleado.Columns["Empleado_apellidos"].HeaderText = "Apellidos";
                dgvEmpleado.Columns["Empleado_fechaNacimiento"].HeaderText = "Fecha de nacimiento";
                dgvEmpleado.Columns["Empleado_puesto"].HeaderText = "Puesto";
                dgvEmpleado.Columns["Empleado_genero"].HeaderText = "Genero";
                dgvEmpleado.Columns["Empleado_estadoCivil"].HeaderText = "Estado civil";
                dgvEmpleado.Columns["Empleado_fechaIngreso"].HeaderText = "Fecha de ingreso";
                dgvEmpleado.Columns["Empleado_estado"].Visible = false;
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
                cbxEmpleado.DataSource = servicioCL.EmpleadoListarA();

                cbxEmpleado.ValueMember = "Empleado_id";
                cbxEmpleado.DisplayMember = "Empleado_nombre";
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
                cbxEmpleado.DataSource = servicioCL.EmpleadoListarI();

                cbxEmpleado.ValueMember = "Empleado_id";
                cbxEmpleado.DisplayMember = "Empleado_nombre";
            }
        }

        /*
         * El metodo BuscarEmpleado se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarEmpleado()
        {
            Empleado_id = int.Parse(cbxEmpleado.SelectedValue.ToString());
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
            cbxEmpleado_Departamento_id.Text = this.dtEmpleado.Rows[0]["Departamento_id"].ToString();
            txtEmpleado_nombre.Text = this.dtEmpleado.Rows[0]["Empleado_nombre"].ToString();
            txtEmpleado_apellidos.Text = this.dtEmpleado.Rows[0]["Empleado_apellidos"].ToString();
            dateEmpleado_fechaNacimiento.Text = this.dtEmpleado.Rows[0]["Empleado_fechaNacimiento"].ToString();
            txtEmpleado_puesto.Text = this.dtEmpleado.Rows[0]["Empleado_puesto"].ToString();
            cbxEmpleado_genero.Text = this.dtEmpleado.Rows[0]["Empleado_genero"].ToString();
            cbxEmpleado_estadoCivil.Text = this.dtEmpleado.Rows[0]["Empleado_estadoCivil"].ToString();
            dateEmpleado_fechaIngreso.Text = this.dtEmpleado.Rows[0]["Empleado_fechaIngreso"].ToString();
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
                
                cbxEmpleado_Departamento_id.ValueMember = "Departamento_id";
                cbxEmpleado_Departamento_id.DisplayMember = "Departamento_nombre";
            }
        }

        #endregion Metodos
        //----------------------------------------------------------------------------------------------------------------------    
        #region Eventos

        /*
         * El evento dgvEmpleado_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dgvEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvEmpleado.CurrentCell.RowIndex;
                Empleado_id = int.Parse(this.dgvEmpleado[0, numFila].Value.ToString());

                using (GestorEmpleado Gestor = new GestorEmpleado())
                {
                    dsEmpleado = Gestor.EmpleadoConsultar(Empleado_id);
                    this.dtEmpleado = this.dsEmpleado.Tables[0];

                }
                CargarDatosEmpleado();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnOrganizacion_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarEmpleado. 
         */
        private void btnEmpleado_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarEmpleado();
        }

        /*
         * El evento btnEmpleado_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnEmpleado_insertar_Click(object sender, EventArgs e)
        {
            VacioEmpleado();
            if (Vacio_Empleado == 0)
            {
                using (GestorEmpleado Gestor = new GestorEmpleado())
                {
                    Gestor.EmpleadoInsertar(int.Parse(cbxEmpleado_Departamento_id.SelectedValue.ToString()), txtEmpleado_nombre.Text, txtEmpleado_apellidos.Text, DateTime.Parse(dateEmpleado_fechaNacimiento.Value.ToString()), txtEmpleado_puesto.Text,
                        cbxEmpleado_genero.SelectedItem.ToString(), cbxEmpleado_estadoCivil.SelectedItem.ToString(), DateTime.Parse(dateEmpleado_fechaIngreso.Value.ToString()), "A");
                }
                Empleado_id = 0; 
                actualizarDatos();                
                Limpiar_txt();
            }
            Vacio_Empleado = 0;
        }

        /*
         * El evento btnEmpleado_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnEmpleado_modificar_Click(object sender, EventArgs e)
        {
            VacioEmpleado();
            if (Vacio_Empleado == 0 && Empleado_id != 0)
            {
                using (GestorEmpleado Gestor = new GestorEmpleado())
                {
                    Gestor.EmpleadoModificar(Empleado_id, int.Parse(cbxEmpleado_Departamento_id.SelectedValue.ToString()), txtEmpleado_nombre.Text, txtEmpleado_apellidos.Text, DateTime.Parse(dateEmpleado_fechaNacimiento.Value.ToString()), txtEmpleado_puesto.Text,
                        cbxEmpleado_genero.SelectedItem.ToString(), cbxEmpleado_estadoCivil.SelectedItem.ToString(), DateTime.Parse(dateEmpleado_fechaIngreso.Value.ToString()), this.dtEmpleado.Rows[0]["Empleado_estado"].ToString());
                }

                Empleado_id = 0;
                actualizarDatos();               
                Limpiar_txt();
            }
            Vacio_Empleado = 0;
        }

        /*
         * El evento btnEmpleado_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnEmpleado_inactivar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento btnEmpleado_activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnEmpleado_activar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento ckbEmpleadoMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbEmpleadoMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Empleado_id = 0;
            actualizarDatos();
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion EMPLEADO
        //====================================================================================
        #region TRAMITE

        #region Metodos

        /*
        * El evento CargarGridTramiteA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridTramiteA()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                dgvTramite.DataSource = servicioCL.TramiteListarA();

                dgvTramite.Columns["Tramite_id"].HeaderText = "ID";
                dgvTramite.Columns["Tramite_nombre"].HeaderText = "Nombre";
                dgvTramite.Columns["Tramite_descripcion"].HeaderText = "Descripción";
                dgvTramite.Columns["Tramite_estado"].Visible = false;
            }
        }

        /*
        * El evento CargarGridTramiteI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridTramiteI()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                dgvTramite.DataSource = servicioCL.TramiteListarI();

                dgvTramite.Columns["Tramite_id"].HeaderText = "ID";
                dgvTramite.Columns["Tramite_nombre"].HeaderText = "Nombre";
                dgvTramite.Columns["Tramite_descripcion"].HeaderText = "Descripción";
                dgvTramite.Columns["Tramite_estado"].Visible = false;
            }
        }

        /*
         * El evento CargarComboTramiteA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboTramiteA()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                cbxTramite.DataSource = servicioCL.TramiteListarA();

                cbxTramite.ValueMember = "Tramite_id";
                cbxTramite.DisplayMember = "Tramite_nombre";
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
                cbxTramite.DataSource = servicioCL.TramiteListarI();

                cbxTramite.ValueMember = "Tramite_id";
                cbxTramite.DisplayMember = "Tramite_nombre";
            }
        }

        /*
         * El evento BuscarTramite se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarTramite()
        {
            Tramite_id = int.Parse(cbxTramite.SelectedValue.ToString());
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
        private void CargarDatosTramite()
        {
            txtTramite_nombre.Text = this.dtTramite.Rows[0]["Tramite_nombre"].ToString();
            txtTramite_descripcion.Text = this.dtTramite.Rows[0]["Tramite_descripcion"].ToString();
        }



        #endregion Metodos

        #region Eventos

        /*
         * El metodo dgvTramite_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dgvTramite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvTramite.CurrentCell.RowIndex;
                Tramite_id = int.Parse(this.dgvTramite[0, numFila].Value.ToString());

                using (GestorTramite Gestor = new GestorTramite())
                {
                    dsTramite = Gestor.TramiteConsultar(Tramite_id);
                    this.dtTramite = this.dsTramite.Tables[0];

                }
                CargarDatosTramite();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El metodo btnTramite_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarTramite. 
         */
        private void btnTramite_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarTramite();
        }

        /*
         * El metodo btnTramite_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnTramite_insertar_Click(object sender, EventArgs e)
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
        private void btnTramite_modificar_Click(object sender, EventArgs e)
        {
            VacioTramite();
            if (Vacio_Tramite == 0 && Tramite_id != 0)
            {
                using (GestorTramite Gestor = new GestorTramite())
                {
                    Gestor.TramiteModificar(Tramite_id, txtTramite_nombre.Text, txtTramite_descripcion.Text, this.dtTramite.Rows[0]["Tramite_estado"].ToString());
                }

                Tramite_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Tramite = 0;
        }

        /*
         * El metodo btnTramite_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnTramite_inactivar_Click(object sender, EventArgs e)
        {
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

        /*
         * El metodo btnTramite_activar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnTramite_activar_Click(object sender, EventArgs e)
        {
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

        /*
         * El metodo ckbTramiteMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbTramiteMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Tramite_id = 0;
            actualizarDatos();
            Vacio_Tramite = 0;
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion TRAMITE
        //====================================================================================
        #region CICLO

        #region Metodos

        /*
        * El metodo CargarGridCicloA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridCicloA()
        {
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                dgvCiclo.DataSource = servicioCL.CicloListarA();

                dgvCiclo.Columns["Ciclo_id"].HeaderText = "ID";
                dgvCiclo.Columns["Tramite_id"].HeaderText = "Tramite id";
                dgvCiclo.Columns["Departamento_id"].HeaderText = "Departamento id";
                dgvCiclo.Columns["Ciclo_orden"].HeaderText = "Orden";
                dgvCiclo.Columns["Ciclo_estado"].Visible = false;
            }
        }

        /*
        * El metodo CargarGridCicloI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridCicloI()
        {
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                dgvCiclo.DataSource = servicioCL.CicloListarI();

                dgvCiclo.Columns["Ciclo_id"].HeaderText = "ID";
                dgvCiclo.Columns["Tramite_id"].HeaderText = "Tramite id";
                dgvCiclo.Columns["Departamento_id"].HeaderText = "Departamento id";
                dgvCiclo.Columns["Ciclo_orden"].HeaderText = "Orden";
                dgvCiclo.Columns["Ciclo_estado"].Visible = false;
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
                cbxCiclo.DataSource = servicioCL.CicloListarA();

                cbxCiclo.ValueMember = "Ciclo_id";
                cbxCiclo.DisplayMember = "Ciclo_orden";
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
                cbxCiclo.DataSource = servicioCL.CicloListarI();

                cbxCiclo.ValueMember = "Ciclo_id";
                cbxCiclo.DisplayMember = "Ciclo_orden";
            }
        }

        /*
         * El metodo BuscarCiclo se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarCiclo()
        {
            Ciclo_id = int.Parse(cbxCiclo.SelectedValue.ToString());
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
            cbxCiclo_TramiteId.Text = this.dtCiclo.Rows[0]["Tramite_id"].ToString();
            cbxCiclo_DepartamentoId.Text = this.dtCiclo.Rows[0]["Departamento_id"].ToString();
            txtCiclo_orden.Text = this.dtCiclo.Rows[0]["Ciclo_orden"].ToString();
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
                
                cbxCiclo_TramiteId.ValueMember = "Tramite_id";
                cbxCiclo_TramiteId.DisplayMember = "Tramite_nombre";
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

                cbxCiclo_DepartamentoId.ValueMember = "Departamento_id";
                cbxCiclo_DepartamentoId.DisplayMember = "Departamento_nombre";
            }
        }
        #endregion Metodos

        #region Eventos

        /*
         * El evento dgvCiclo_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dgvCiclo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvCiclo.CurrentCell.RowIndex;
                Ciclo_id = int.Parse(this.dgvCiclo[0, numFila].Value.ToString());

                using (GestorCiclo Gestor = new GestorCiclo())
                {
                    dsCiclo = Gestor.CicloConsultar(Ciclo_id);
                    this.dtCiclo = this.dsCiclo.Tables[0];

                }
                CargarDatosCiclo();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnCiclo_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarCiclo. 
         */
        private void btnCiclo_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarCiclo();
        }

        /*
         * El evento btnCiclo_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnCiclo_insertar_Click(object sender, EventArgs e)
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
         * El evento btnCiclo_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnCiclo_modificar_Click(object sender, EventArgs e)
        {
            VacioCiclo();
            if (Vacio_Ciclo == 0 && Ciclo_id != 0)
            {
                using (GestorCiclo Gestor = new GestorCiclo())
                {
                    Gestor.CicloModificar(Ciclo_id, int.Parse(cbxCiclo_TramiteId.SelectedValue.ToString()), int.Parse(cbxCiclo_DepartamentoId.SelectedValue.ToString()), txtCiclo_orden.Text, this.dtCiclo.Rows[0]["Ciclo_estado"].ToString());
                }

                Ciclo_id = 0;
                actualizarDatos();                
                Limpiar_txt();
            }
            Vacio_Ciclo = 0;
        }

        /*
         * El evento btnCiclo_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnCiclo_inactivar_Click(object sender, EventArgs e)
        {
            if (Ciclo_id != 0)
            {
                using (GestorCiclo Gestor = new GestorCiclo())
                {
                    Gestor.CicloInactivar(Ciclo_id);
                }

                Ciclo_id = 0;
                actualizarDatos();
                Vacio_Ciclo = 0;
                Limpiar_txt();
            }
        }

        /*
         * El evento btnCiclo_activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnCiclo_activar_Click(object sender, EventArgs e)
        {
            if (Ciclo_id != 0)
            {
                using (GestorCiclo Gestor = new GestorCiclo())
                {
                    Gestor.CicloActivar(Ciclo_id);
                }

                Ciclo_id = 0;
                actualizarDatos();
                Vacio_Ciclo = 0;
                Limpiar_txt();
            }
        }

        /*
         * El evento ckbCicloMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbCicloMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Ciclo_id = 0;
            actualizarDatos();
            Vacio_Ciclo = 0;
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion CICLO
        //====================================================================================
        #region DOCUMENTO

        #region Metodos
        /*
        * El evento CargarGridDocumentoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridDocumentoA()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                dgvDocumento.DataSource = servicioCL.DocumentoListarA();

                dgvDocumento.Columns["Documento_id"].HeaderText = "ID";
                dgvDocumento.Columns["Tramite_id"].HeaderText = "Tramite id";
                dgvDocumento.Columns["Idioma_id"].HeaderText = "Idioma id";
                dgvDocumento.Columns["Documento_nombre"].HeaderText = "Nombre";
                dgvDocumento.Columns["Documento_ruta"].HeaderText = "Ruta";
                dgvDocumento.Columns["Documento_tipo"].HeaderText = "Tipo";
                dgvDocumento.Columns["Documento_estado"].Visible = false;
            }
        }

        /*
        * El evento CargarGridDocumentoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridDocumentoI()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                dgvDocumento.DataSource = servicioCL.DocumentoListarI();

                dgvDocumento.Columns["Documento_id"].HeaderText = "ID";
                dgvDocumento.Columns["Tramite_id"].HeaderText = "Tramite id";
                dgvDocumento.Columns["Idioma_id"].HeaderText = "Idioma id";
                dgvDocumento.Columns["Documento_nombre"].HeaderText = "Nombre";
                dgvDocumento.Columns["Documento_ruta"].HeaderText = "Ruta";
                dgvDocumento.Columns["Documento_tipo"].HeaderText = "Tipo";
                dgvDocumento.Columns["Documento_estado"].Visible = false;
            }
        }

        /*
         * El evento CargarComboDocumentoA es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos activos de las tablas.
         */
        private void CargarComboDocumentoA()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                cbxDocumento.DataSource = servicioCL.DocumentoListarA();

                cbxDocumento.ValueMember = "Documento_id";
                cbxDocumento.DisplayMember = "Documento_nombre";
            }
        }
        /*
         * El evento CargarComboDocumentoI es el engargado de cargar los combobox de cargar datos
         * con el Id o Nombres de los datos inactivos de las tablas.
         */
        private void CargarComboDocumentoI()
        {
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                cbxDocumento.DataSource = servicioCL.DocumentoListarI();

                cbxDocumento.ValueMember = "Documento_id";
                cbxDocumento.DisplayMember = "Documento_nombre";
            }
        }

        /*
         * El evento BuscarDocumento se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarDocumento()
        {
            Documento_id = int.Parse(cbxDocumento.SelectedValue.ToString());
            using (GestorDocumento servicioCL = new GestorDocumento())
            {
                this.dsDocumento = servicioCL.DocumentoConsultar(Documento_id);
                this.dtDocumento = this.dsDocumento.Tables[0];
            }
            CargarDatosDocumento();
        }

        /*
         * El evento CargarDatosDocumento se encarga de tomar datos de un DataTable y los asigna
         * a los txt, cbx o dtp
         */
        private void CargarDatosDocumento()
        {
            cbxDocumento_TramiteId.Text = this.dtDocumento.Rows[0]["Tramite_id"].ToString();
            cbxDocumento_IdiomaId.Text = this.dtDocumento.Rows[0]["Idioma_id"].ToString();
            txtDocumento_nombre.Text = this.dtDocumento.Rows[0]["Documento_nombre"].ToString();
            txtDocumento_ruta.Text = this.dtDocumento.Rows[0]["Documento_ruta"].ToString();
            txtDocumento_tipo.Text = this.dtDocumento.Rows[0]["Documento_tipo"].ToString();
        }

        /*
         * El evento cagarDatoscbxDocumento_TramiteId se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void cagarDatoscbxDocumento_TramiteId()
        {
            using (GestorTramite servicioCL = new GestorTramite())
            {
                cbxDocumento_TramiteId.DataSource = servicioCL.TramiteListarA();
                
                cbxDocumento_TramiteId.ValueMember = "Tramite_id";
                cbxDocumento_TramiteId.DisplayMember = "Tramite_nombre";
            }
        }

        /*
         * El evento cagarDatoscbxcbxDocumento_IdiomaId se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void cagarDatoscbxcbxDocumento_IdiomaId()
        {
            using (GestorIdioma servicioCL = new GestorIdioma())
            {
                cbxDocumento_IdiomaId.DataSource = servicioCL.IdiomaListarA();
                
                cbxDocumento_IdiomaId.ValueMember = "Idioma_id";
                cbxDocumento_IdiomaId.DisplayMember = "Idioma_nombre";
            }
        }

        #endregion Metodos

        #region Eventos

        /*
         * El evento txtDocumento_ruta_Click se encarga de selecionar una ruta del documento. 
         */
        private void txtDocumento_ruta_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog folder = new FolderBrowserDialog();

            //folder.Description = "Seleccione una ruta";
            //folder.RootFolder = Environment.SpecialFolder.Desktop;
            //if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    txtDocumento_ruta.Text = folder.SelectedPath;
            //}

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                txtDocumento_ruta.Text = sFileName;
            }
        }

        /*
         * El evento dataGridView1_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvDocumento.CurrentCell.RowIndex;
                Documento_id = int.Parse(this.dgvDocumento[0, numFila].Value.ToString());

                using (GestorDocumento Gestor = new GestorDocumento())
                {
                    dsDocumento = Gestor.DocumentoConsultar(Documento_id);
                    this.dtDocumento = this.dsDocumento.Tables[0];

                }
                CargarDatosDocumento();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnDocumento_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarDocumento. 
         */
        private void btnDocumento_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarDocumento();
        }

        /*
         * El evento btnDocumento_Insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnDocumento_Insertar_Click(object sender, EventArgs e)
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
         * El evento btnDocumento_Modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnDocumento_Modificar_Click(object sender, EventArgs e)
        {
            VacioDocumento();
            if (Vacio_Documento == 0 && Documento_id != 0)
            {
                using (GestorDocumento Gestor = new GestorDocumento())
                {
                    Gestor.DocumentoModificar(Documento_id, int.Parse(cbxDocumento_TramiteId.SelectedValue.ToString()), int.Parse(cbxDocumento_IdiomaId.SelectedValue.ToString()), 
                        txtDocumento_nombre.Text, txtDocumento_ruta.Text, txtDocumento_tipo.Text, this.dtDocumento.Rows[0]["Documento_estado"].ToString());
                }

                Documento_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Documento = 0;
        }

        /*
         * El evento btnDocumento_Inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnDocumento_Inactivar_Click(object sender, EventArgs e)
        {
            if (Documento_id != 0) {
                using (GestorDocumento Gestor = new GestorDocumento())
                {
                    Gestor.DocumentoInactivar(Documento_id);
                }
                Documento_id = 0;
                actualizarDatos();
                Vacio_Documento = 0;
                Limpiar_txt();
            }
        }

        /*
         * El evento btnDocumento_Activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnDocumento_Activar_Click(object sender, EventArgs e)
        {
            if (Documento_id != 0)
            {
                using (GestorDocumento Gestor = new GestorDocumento())
                {
                    Gestor.DocumentoActivar(Documento_id);
                }
                Documento_id = 0;
                actualizarDatos();
                Vacio_Documento = 0;
                Limpiar_txt();
            }
        }

        /*
         * El evento ckbDocumentoMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbDocumentoMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Documento_id = 0;
            actualizarDatos();
            Vacio_Documento = 0;
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion DOCUMENTO
        //====================================================================================
        #region CASO

        #region Metodos

        /*
        * El metodo CargarGridCasoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridCasoA()
        {
            using (GestorCaso servicioCL = new GestorCaso())
            {
                dgvCaso.DataSource = servicioCL.CasoListarA();

                dgvCaso.Columns["Caso_id"].HeaderText = "ID";
                dgvCaso.Columns["Tramite_id"].HeaderText = "Tramite id";
                dgvCaso.Columns["Caso_codigo"].HeaderText = "Codigo";
                dgvCaso.Columns["Caso_fechaInicio"].HeaderText = "Fecha inicial";
                dgvCaso.Columns["Caso_fechaFinal"].HeaderText = "Fecha final";
                dgvCaso.Columns["Caso_estado"].Visible = false;
            }
        }

        /*
        * El metodo CargarGridCasoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridCasoI()
        {
            using (GestorCaso servicioCL = new GestorCaso())
            {
                dgvCaso.DataSource = servicioCL.CasoListarI();

                dgvCaso.Columns["Caso_id"].HeaderText = "ID";
                dgvCaso.Columns["Tramite_id"].HeaderText = "Tramite id";
                dgvCaso.Columns["Caso_codigo"].HeaderText = "Codigo";
                dgvCaso.Columns["Caso_fechaInicio"].HeaderText = "Fecha inicial";
                dgvCaso.Columns["Caso_fechaFinal"].HeaderText = "Fecha final";
                dgvCaso.Columns["Caso_estado"].Visible = false;
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
                cbxCaso.DataSource = servicioCL.CasoListarA();

                cbxCaso.ValueMember = "Caso_id";
                cbxCaso.DisplayMember = "Caso_codigo";
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
                cbxCaso.DataSource = servicioCL.CasoListarI();

                cbxCaso.ValueMember = "Caso_id";
                cbxCaso.DisplayMember = "Caso_codigo";
            }
        }

        /*
         * El metodo BuscarCaso se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarCaso()
        {
            Caso_id = int.Parse(cbxCaso.SelectedValue.ToString());
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
            cbxCaso_TramiteId.Text = this.dtCaso.Rows[0]["Tramite_id"].ToString();
            txtCaso_Codigo.Text = this.dtCaso.Rows[0]["Caso_codigo"].ToString();
            Codigo = this.dtCaso.Rows[0]["Caso_codigo"].ToString();
            dtpCaso_fechaInicio.Text = this.dtCaso.Rows[0]["Caso_fechaInicio"].ToString();
            dtpCaso_fechaFinal.Text = this.dtCaso.Rows[0]["Caso_fechaFinal"].ToString();
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

                cbxCaso_TramiteId.ValueMember = "Tramite_id";
                cbxCaso_TramiteId.DisplayMember = "Tramite_nombre";
            }
        }

        /*
         * El metodo CodigoExistente es el encargado de revisar si ya existe un codigo de ser asi el usuario deberá
         * generar uno nuevo para ser nuevamente evaluado y poder insertar o modificar los datos
         */
        private string CodigoExistente(String codigo)
        {
            if (Codigo != txtCaso_Codigo.Text)
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
        #endregion Metodos

        #region Eventos

        /*
         * El evento txtCaso_codigo_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void txtCaso_codigo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvCaso.CurrentCell.RowIndex;
                Caso_id = int.Parse(this.dgvCaso[0, numFila].Value.ToString());

                using (GestorCaso Gestor = new GestorCaso())
                {
                    dsCaso = Gestor.CasoConsultar(Caso_id);
                    this.dtCaso = this.dsCaso.Tables[0];

                }
                CargarDatosCaso();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnCaso_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarCaso. 
         */
        private void btnCaso_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarCaso();
        }

        /*
         * El evento btnCaso_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnCaso_insertar_Click(object sender, EventArgs e)
        {
            VacioCaso();
            if (Vacio_Caso == 0)
            {
                using (GestorCaso Gestor = new GestorCaso())
                {
                    Gestor.CasoInsertar(int.Parse(cbxCaso_TramiteId.SelectedValue.ToString()), txtCaso_Codigo.Text, DateTime.Parse(dtpCaso_fechaInicio.Value.ToString()), DateTime.Parse(dtpCaso_fechaFinal.Value.ToString()), "A");
                }

                Caso_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Caso = 0;
        }

        /*
         * El evento btnCaso_Modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnCaso_Modificar_Click(object sender, EventArgs e)
        {
            VacioCaso();
            if (Vacio_Caso == 0 && Caso_id != 0)
            {
                using (GestorCaso Gestor = new GestorCaso())
                {
                    if(ckbCasoMostrarInactivos.Checked == false)
                    {
                        Gestor.CasoModificar(Caso_id, int.Parse(cbxCaso_TramiteId.SelectedValue.ToString()), txtCaso_Codigo.Text,
                        DateTime.Parse(dtpCaso_fechaInicio.Value.ToString()), DateTime.Parse(dtpCaso_fechaFinal.Value.ToString()), "A");
                    }
                    else
                    {
                        Gestor.CasoModificar(Caso_id, int.Parse(cbxCaso_TramiteId.SelectedValue.ToString()), txtCaso_Codigo.Text,
                        DateTime.Parse(dtpCaso_fechaInicio.Value.ToString()), DateTime.Parse(dtpCaso_fechaFinal.Value.ToString()), "I");
                    }
                }

                Caso_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_Caso = 0;
        }

        /*
         * El evento btnCaso_Inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnCaso_Inactivar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento btnCaso_Activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnCaso_Activar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento ckbCasoMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbCasoMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Caso_id = 0;
            actualizarDatos();
            Limpiar_txt();
        }

        /*
         * El evento btncaso_codigo_Click se encarga de generar un codigo alfanumerico para el codigo del caso.
         */
        private void btncaso_codigo_Click(object sender, EventArgs e)
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
        #endregion Eventos

        #endregion CASO
        //====================================================================================
        #region DETALLECASO

        #region Metodos

        /*
        * El metodo CargarGridDetalleCasoA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridDetalleCasoA()
        {
            using (GestorDetalleCaso servicioCL = new GestorDetalleCaso())
            {
                dgvDetalleCaso.DataSource = servicioCL.DetalleCasoListarA();

                dgvDetalleCaso.Columns["DetalleCaso_id"].HeaderText = "ID";
                dgvDetalleCaso.Columns["Caso_id"].HeaderText = "Caso id";
                dgvDetalleCaso.Columns["Ciclo_id"].HeaderText = "Ciclo id";
                dgvDetalleCaso.Columns["Documento_id"].HeaderText = "Documento id";
                dgvDetalleCaso.Columns["DetalleCaso_fechaRecibido"].HeaderText = "Fecha recibido";
                dgvDetalleCaso.Columns["DetalleCaso_fechaTranspaso"].HeaderText = "Fecha transpaso";
                dgvDetalleCaso.Columns["DetalleCaso_descripcion"].HeaderText = "Descripcion";
                dgvDetalleCaso.Columns["DetalleCaso_estado"].Visible = false;
            }
        }

        /*
        * El metodo CargarGridDetalleCasoI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridDetalleCasoI()
        {
            using (GestorDetalleCaso servicioCL = new GestorDetalleCaso())
            {
                dgvDetalleCaso.DataSource = servicioCL.DetalleCasoListarI();

                dgvDetalleCaso.Columns["DetalleCaso_id"].HeaderText = "ID";
                dgvDetalleCaso.Columns["Caso_id"].HeaderText = "Caso id";
                dgvDetalleCaso.Columns["Ciclo_id"].HeaderText = "Ciclo id";
                dgvDetalleCaso.Columns["Documento_id"].HeaderText = "Documento id";
                dgvDetalleCaso.Columns["DetalleCaso_fechaRecibido"].HeaderText = "Fecha recibido";
                dgvDetalleCaso.Columns["DetalleCaso_fechaTranspaso"].HeaderText = "Fecha transpaso";
                dgvDetalleCaso.Columns["DetalleCaso_descripcion"].HeaderText = "Descripcion";
                dgvDetalleCaso.Columns["DetalleCaso_estado"].Visible = false;
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
                cbxDetalleCaso.DataSource = servicioCL.DetalleCasoListarA();

                cbxDetalleCaso.ValueMember = "DetalleCaso_id";
                cbxDetalleCaso.DisplayMember = "DetalleCaso_descripcion";
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
                cbxDetalleCaso.DataSource = servicioCL.DetalleCasoListarI();

                cbxDetalleCaso.ValueMember = "DetalleCaso_id";
                cbxDetalleCaso.DisplayMember = "DetalleCaso_descripcion";
            }
        }

        /*
         * El metodo BuscarDetalleCaso se encarga de buscar un dato espesifico mediante una id
         * y guarda los datos en un DataTable.
         */
        private void BuscarDetalleCaso()
        {
            DetalleCaso_id = int.Parse(cbxDetalleCaso.SelectedValue.ToString());
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
            cbxCaso_id.Text = this.dtDetalleCaso.Rows[0]["Caso_id"].ToString();
            cbxCiclo_id.Text = this.dtDetalleCaso.Rows[0]["Ciclo_id"].ToString();
            cbxDocumento_id.Text = this.dtDetalleCaso.Rows[0]["Documento_id"].ToString();
            dtpDetalleCaso_fechaRecibido.Text = this.dtDetalleCaso.Rows[0]["DetalleCaso_fechaRecibido"].ToString();
            dtpDetalleCaso_fechaTranspaso.Text = this.dtDetalleCaso.Rows[0]["DetalleCaso_fechaTranspaso"].ToString();
            txtDetalleCaso_descripcion.Text = this.dtDetalleCaso.Rows[0]["DetalleCaso_descripcion"].ToString();
        }

        /*
         * El metodo CargarComboIdDetalleCasoCaso se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void CargarComboIdDetalleCasoCaso ()
        {
            using (GestorCaso servicioCL = new GestorCaso())
            {
                cbxCaso_id.DataSource = servicioCL.CasoListarA();
                  
                cbxCaso_id.ValueMember = "Caso_id";
                cbxCaso_id.DisplayMember = "Caso_codigo";
            }
        }

        /*
         * El metodo CargarComboIdDetalleCasoEmpleado se encarga de desplegar los id o nombres
         * en un comboBox especifico.
         */
        private void CargarComboIdDetalleCasoEmpleado()
        {
            using (GestorCiclo servicioCL = new GestorCiclo())
            {
                cbxCiclo_id.DataSource = servicioCL.CicloListarA();
                 
                cbxCiclo_id.ValueMember = "Ciclo_id";
                cbxCiclo_id.DisplayMember = "Ciclo_orden";
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
                  
                cbxDocumento_id.ValueMember = "Documento_id";
                cbxDocumento_id.DisplayMember = "Documento_nombre";
            }
        }


        #endregion Metodos

        #region Eventos

        /*
         * El evento dgvDetalleCaso_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivar y/o activar.
         */
        private void dgvDetalleCaso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numFila = dgvDetalleCaso.CurrentCell.RowIndex;
                DetalleCaso_id = int.Parse(this.dgvDetalleCaso[0, numFila].Value.ToString());

                using (GestorDetalleCaso Gestor = new GestorDetalleCaso())
                {
                    dsDetalleCaso = Gestor.DetalleCasoConsultar(DetalleCaso_id);
                    this.dtDetalleCaso = this.dsDetalleCaso.Tables[0];

                }
                CargarDatosDetalleCaso();
            }
            catch (Exception)
            {
                MessageBox.Show("No ha selecionado ningun elemento de la tabla. ", "ALERTA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         * El evento btnDetalleCaso_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarDetalleCaso. 
         */
        private void btnDetalleCaso_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarDetalleCaso();
        }

        /*
         * El evento btnDetalleCaso_insertar_Click se encarga de insertar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnDetalleCaso_insertar_Click(object sender, EventArgs e)
        {
            VacioDetalleCaso();
            if (Vacio_DetalleCaso == 0)
            {
                using (GestorDetalleCaso Gestor = new GestorDetalleCaso())
                {
                    Gestor.DetalleCasoInsertar(int.Parse(cbxCaso_id.SelectedValue.ToString()), int.Parse(cbxCiclo_id.SelectedValue.ToString()), int.Parse(cbxDocumento_id.SelectedValue.ToString()),
                         DateTime.Parse(dtpDetalleCaso_fechaRecibido.Value.ToString()), DateTime.Parse(dtpDetalleCaso_fechaTranspaso.Value.ToString()), txtDetalleCaso_descripcion.Text, "A");
                }

                DetalleCaso_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_DetalleCaso = 0;
        }

        /*
         * El evento btnDetalleCaso_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza los comboBox y las tablas. 
         */
        private void btnDetalleCaso_modificar_Click(object sender, EventArgs e)
        {
            VacioDetalleCaso();
            if (Vacio_DetalleCaso == 0 && DetalleCaso_id != 0)
            {
                using (GestorDetalleCaso Gestor = new GestorDetalleCaso())
                {
                    Gestor.DetalleCasoModificar(DetalleCaso_id, int.Parse(cbxCaso_id.SelectedValue.ToString()), int.Parse(cbxCiclo_id.SelectedValue.ToString()), int.Parse(cbxDocumento_id.SelectedValue.ToString()),
                         DateTime.Parse(dtpDetalleCaso_fechaRecibido.Value.ToString()), 
                         DateTime.Parse(dtpDetalleCaso_fechaTranspaso.Value.ToString()), txtDetalleCaso_descripcion.Text, this.dtDetalleCaso.Rows[0]["DetalleCaso_estado"].ToString());
                }
                
                DetalleCaso_id = 0;
                actualizarDatos();
                Limpiar_txt();
            }
            Vacio_DetalleCaso = 0;
        }

        /*
         * El evento btnDetalleCaso_inactivar_Click se encarga de Inactivar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnDetalleCaso_inactivar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento btnDetalleCaso_activar_Click se encarga de activar los datos en la base de datos
         * y actualiza los comboBox y las tablas.
         */
        private void btnDetalleCaso_activar_Click(object sender, EventArgs e)
        {
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

        /*
         * El evento ckbDetalleCasoMostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbDetalleCasoMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            DetalleCaso_id = 0;
            actualizarDatos();
            Limpiar_txt();
        }

        #endregion Eventos

        #endregion DETALLECASO
        //====================================================================================
        #region REPORTES

        /*
         * El metodo Reporte_organizacion_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_organizacion_Click(object sender, EventArgs e)
        {
            if(ckbOrganizacionMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_ORGANIZACION_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_ORGANIZACION_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_codigo_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_codigo_Click(object sender, EventArgs e)
        {
            if (ckbCodigoMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_CODIGO_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_CODIGO_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_idioma_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_idioma_Click(object sender, EventArgs e)
        {
            if (ckbIdioma_MostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_IDIOMA_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_IDIOMA_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_departamento_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_departamento_Click(object sender, EventArgs e)
        {
            if (ckbDepartamentoMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_DEPARTAMENTO_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_DEPARTAMENTO_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_empleo_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_empleo_Click(object sender, EventArgs e)
        {
            if (ckbEmpleadoMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_EMPLEADO_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_EMPLEADO_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_tramite_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_tramite_Click(object sender, EventArgs e)
        {
            if (ckbTramiteMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_TRAMITE_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_TRAMITE_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_ciclo_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_ciclo_Click(object sender, EventArgs e)
        {
            if (ckbCicloMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_CICLO_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_CICLO_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_documento_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_documento_Click(object sender, EventArgs e)
        {
            if (ckbDocumentoMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_DOCUMENTO_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_DOCUMENTO_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_caso_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_caso_Click(object sender, EventArgs e)
        {
            if (ckbCasoMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_CASO_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_CASO_A");
                reporte.Show();
            }
        }

        /*
         * El metodo Reporte_detalleCaso_Click se encargade generar un reporte de la tabla corespondiento.
         */
        private void Reporte_detalleCaso_Click(object sender, EventArgs e)
        {
            if (ckbDetalleCasoMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_DETALLECASO_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_DETALLECASO_A");
                reporte.Show();
            }
        }

        private void txtDocumento_ruta_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void Reporte_empleo_Click_1(object sender, EventArgs e)
        {
            if (ckbEmpleadoMostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_EMPLEADO_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_EMPLEADO_A");
                reporte.Show();
            }
        }
        #endregion REPORTES
        //====================================================================================
        #region Eventos de cerrar sesión

        /*
         * Los eventos presentes en esta region se encargan de pasar de la pestaña de from1 
         * a la pestaña de Login.
         */

        private void btnVolver_organizacion_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_codigo_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_idioma_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_departamento_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_empleado_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_tramite_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_ciclo_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_documento_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_caso_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        private void btnVolver_detalleCaso_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }

        #endregion Eventos de cerrar sesión
        //====================================================================================

    }
}