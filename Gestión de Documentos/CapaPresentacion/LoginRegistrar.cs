using Capa_Integracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class LoginRegistrar : Form
    {
        public LoginRegistrar()
        {
            InitializeComponent();

            CargarGridLoginA();
            CargarComboLoginA();
        }

        //=====================================================================================
        #region Variables
        /**
         * Las presentes variables son las responsables de algunos de los metodos de las tablas y/o 
         * otros metodos.
         */
        DataSet dsLogin = new DataSet();
        DataTable dtLogin = new DataTable();
        int Login_id = 0;
        string Login_estado = "";
        string CORREO = "";
        string USUARIO = "";

        #endregion Variables
        //=====================================================================================
        #region Metodos
        /*
         *El metodo UsuarioExistente es el encargado de verificar si el Nombre de usuario digitado
         * ya esta registrado
         */
        private string UsuarioExistente(String usuario)
        {
            if (USUARIO != txtLogin_Usuario.Text)
            {
                using (GestorLogin servicioCL = new GestorLogin())
                {
                    this.dsLogin = servicioCL.LoginConsuLoginConsultarUsuarioltar(usuario);
                    this.dtLogin = this.dsLogin.Tables[0];
                }
                if ((dtLogin == null) || (dtLogin.Rows.Count == 0))
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
         * El metodo CorreoExistente es el encargado de verificar si el correo electronico digitado
         * ya esta registrado
         */
        private string CorreoExistente(String correo)
        {
            if (CORREO != txtLogin_Correo.Text)
            {
                using (GestorLogin servicioCL = new GestorLogin())
                {
                    this.dsLogin = servicioCL.LoginConsultarCorreo(correo);
                    this.dtLogin = this.dsLogin.Tables[0];
                }
                if ((dtLogin == null) || (dtLogin.Rows.Count == 0))
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
        * El metodo CargarGridLoginA es el encargado de cargar los datos de los activos en la tabla.
        */
        private void CargarGridLoginA()
        {
            using (GestorLogin servicioCL = new GestorLogin())
            {
                dgvLogin.DataSource = servicioCL.LoginListarA();

                dgvLogin.Columns["Login_id"].Visible = false;
                dgvLogin.Columns["Login_Usuario"].HeaderText = "Usuario";
                dgvLogin.Columns["Login_contraseña"].HeaderText = "Contraseña";
                dgvLogin.Columns["Login_correoElectronico"].HeaderText = "Correo electronico";
                dgvLogin.Columns["Login_administrador"].HeaderText = "Tipo de usuario";
                dgvLogin.Columns["Login_estado"].Visible = false;
            }
        }
        /*
        * El metodo CargarGridLoginI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridLoginI()
        {
            using (GestorLogin servicioCL = new GestorLogin())
            {
                dgvLogin.DataSource = servicioCL.LoginListarI();

                dgvLogin.Columns["Login_id"].Visible = false;
                dgvLogin.Columns["Login_Usuario"].HeaderText = "Usuario";
                dgvLogin.Columns["Login_contraseña"].HeaderText = "Contraseña";
                dgvLogin.Columns["Login_correoElectronico"].HeaderText = "Correo electronico";
                dgvLogin.Columns["Login_administrador"].HeaderText = "Tipo de usuario";
                dgvLogin.Columns["Login_estado"].Visible = false;
            }
        }
        /*
         * El metodo CargarComboLoginA es el engargado de cargar los combobox de cargar datos
         * con el Id o usuarios de los datos activos de las tablas.
         */
        private void CargarComboLoginA()
        {
            using (GestorLogin servicioCL = new GestorLogin())
            {
                cbxLogin.DataSource = servicioCL.LoginListarA();

                cbxLogin.ValueMember = "Login_id";
                cbxLogin.DisplayMember = "Login_Usuario";
            }
        }
        /*
         * El metodo CargarComboLoginI es el engargado de cargar los combobox de cargar datos
         * con el Id o usuarios de los datos inactivos de las tablas.
         */
        private void CargarComboLoginI()
        {
                using (GestorLogin servicioCL = new GestorLogin())
                {
                    cbxLogin.DataSource = servicioCL.LoginListarI();

                    cbxLogin.ValueMember = "Login_id";
                    cbxLogin.DisplayMember = "Login_Usuario";
                }
            }
        /*
        * El metodo BuscarLogin se encarga de buscar un dato espesifico mediante una id
        * y guarda los datos en un DataTable.
        */
        private void BuscarLogin()
        {
            Login_id = int.Parse(cbxLogin.SelectedValue.ToString());
                using (GestorLogin servicioCL = new GestorLogin())
                {
                    this.dsLogin = servicioCL.LoginConsultar(Login_id);
                    this.dtLogin= this.dsLogin.Tables[0];
                }
            CargarDatosLogin();
        }
        /*
         * El metodo CargarDatosLogin se encarga de desplegar los id o usuarios
         * en un comboBox especifico.
         */
        private void CargarDatosLogin()
        {
            string Aux = "";
            txtLogin_Usuario.Text = this.dtLogin.Rows[0]["Login_Usuario"].ToString();
            USUARIO = this.dtLogin.Rows[0]["Login_Usuario"].ToString();
            txtLogin_Contraseña.Text = this.dtLogin.Rows[0]["Login_contraseña"].ToString();
            txtLogin_Correo.Text = this.dtLogin.Rows[0]["Login_correoElectronico"].ToString();
            CORREO = this.dtLogin.Rows[0]["Login_correoElectronico"].ToString();

            Aux = this.dtLogin.Rows[0]["Login_administrador"].ToString();

            if (Aux=="Administrador")
            {
                ckbUsuario.Checked = false;
                ckbAdministrador.Checked = true;
            }
            else
            {
                ckbUsuario.Checked = true;
                ckbAdministrador.Checked = false;
            }
            Login_estado = this.dtLogin.Rows[0]["Login_estado"].ToString();
        }
        /* 
         * el metodo limpiarDatos es el encagado de limpiar la informacion de los diferentes txt
         */
        private void limpiarDatos()
        {
            txtLogin_Usuario.Text = "";
            txtLogin_Contraseña.Text = "";
            txtLogin_Correo.Text = "";

            if (ckbAdministrador.Checked == true)
            {
                ckbAdministrador.Checked = false;
            }
            if (ckbUsuario.Checked == true)
            {
                ckbUsuario.Checked = false;
            }

            Login_id = 0;
            Login_estado = "";
            
        }
        #endregion Metodos
        //=====================================================================================3
        #region Eventos
        /*
         * El evento dgvLogin_CellClick se encarga de selecionar los elementos de la tabla para poder ser
         * modificados, inactivados y/o activados.
         */
        private void dgvLogin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                int numFila = dgvLogin.CurrentCell.RowIndex;
                try
                {
                    Login_id = int.Parse(this.dgvLogin[0, numFila].Value.ToString());
                    using (GestorLogin Gestor = new GestorLogin())
                    {
                        dsLogin = Gestor.LoginConsultar(Login_id);
                        this.dtLogin = this.dsLogin.Tables[0];

                    }
                    CargarDatosLogin();
                }
                catch (Exception)
                {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla. ", "ALERTA",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /*
         * El evento btnLogin_cargarDatos_Click se encarga de cargar los datos de la base de datos
         * en los txt, cbx y los dtp, con la ayuda de metodo BuscarLogin. 
         */
        private void btnLogin_cargarDatos_Click(object sender, EventArgs e)
        {
            BuscarLogin();
        }
        /*
        * El evento btnLogin_insertar_Click se encarga de insertar los datos en la base de datos
        * y actualiza el comboBox y la tabla. 
        */
        private void btnLogin_insertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin_Usuario.Text) || string.IsNullOrEmpty(txtLogin_Contraseña.Text) ||
                string.IsNullOrEmpty(txtLogin_Correo.Text) || (ckbAdministrador.Checked == false && ckbUsuario.Checked == false))
            {
                if (txtLogin_Usuario.Text == "")
                {
                    MessageBox.Show("El nombre del usuario es un espacio requerido ", "ALERTA", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (txtLogin_Contraseña.Text == "")
                {
                    MessageBox.Show("La contraseña es un espacio requerido", "ALERTA", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (txtLogin_Correo.Text == "")
                {
                    MessageBox.Show("El correo es un espacio requerido ", "ALERTA", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (ckbAdministrador.Checked==false && ckbUsuario.Checked==false)
                {
                    MessageBox.Show("El tipo de usuario es un espacio requerido ", "ALERTA", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (UsuarioExistente(txtLogin_Usuario.Text) == "No existe" && CorreoExistente(txtLogin_Correo.Text) == "No existe" 
                    && USUARIO != txtLogin_Usuario.Text &&  CORREO !=txtLogin_Correo.Text)
                {
                    using (GestorLogin Gestor = new GestorLogin())
                    {
                        if (ckbAdministrador.Checked == true)
                        {
                            Gestor.LoginInsertar(txtLogin_Usuario.Text, txtLogin_Contraseña.Text, txtLogin_Correo.Text, "Administrador", "A");
                        }
                        else
                        {
                            Gestor.LoginInsertar(txtLogin_Usuario.Text, txtLogin_Contraseña.Text, txtLogin_Correo.Text, "Usuario", "A");
                        }
                    }

                    limpiarDatos();

                    if (ckbLogin_MostrarInactivos.Checked == false)
                    {
                        CargarGridLoginA();
                        CargarComboLoginA();
                    }
                    else
                    {
                        CargarGridLoginI();
                        CargarComboLoginI();
                    }
                }
                else
                {
                    if (UsuarioExistente(txtLogin_Usuario.Text) == "Existe" && CorreoExistente(txtLogin_Correo.Text) == "No existe")
                    {
                        MessageBox.Show("El nombre del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (USUARIO == txtLogin_Usuario.Text)
                    {
                        MessageBox.Show("El nombre del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (CORREO == txtLogin_Correo.Text)
                    {
                        MessageBox.Show("El correo electronico del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (UsuarioExistente(txtLogin_Usuario.Text) == "No existe" && CorreoExistente(txtLogin_Correo.Text) == "Existe")
                    {
                        MessageBox.Show("El correo electronico del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (UsuarioExistente(txtLogin_Usuario.Text) == "Existe" && CorreoExistente(txtLogin_Correo.Text) == "Existe")
                    {
                        MessageBox.Show("El nombre y el correo del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        /*
         * El evento btnLogin_modificar_Click se encarga de modificar los datos en la base de datos
         * y actualiza el comboBox y la tabla. 
         */
        private void btnLogin_modificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin_Usuario.Text) || string.IsNullOrEmpty(txtLogin_Contraseña.Text) ||
                string.IsNullOrEmpty(txtLogin_Correo.Text) || (ckbAdministrador.Checked == false && ckbUsuario.Checked == false))
            {
                if (txtLogin_Usuario.Text == "")
                {
                    MessageBox.Show("El nombre del usuario es un espacio requerido ", "ALERTA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (txtLogin_Contraseña.Text == "")
                {
                    MessageBox.Show("La contraseña es un espacio requerido", "ALERTA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (txtLogin_Correo.Text == "")
                {
                    MessageBox.Show("El correo es un espacio requerido ", "ALERTA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (ckbAdministrador.Checked == false && ckbUsuario.Checked == false)
                {
                    MessageBox.Show("El tipo de usuario es un espacio requerido ", "ALERTA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (UsuarioExistente(txtLogin_Usuario.Text) == "No existe" && CorreoExistente(txtLogin_Correo.Text) == "No existe")
                {
                    using (GestorLogin Gestor = new GestorLogin())
                    {
                        if (ckbAdministrador.Checked == true)
                        {
                            Gestor.LoginModificar(Login_id, txtLogin_Usuario.Text, txtLogin_Contraseña.Text, txtLogin_Correo.Text, "Administrador", Login_estado);
                        }
                        else
                        {
                            Gestor.LoginModificar(Login_id, txtLogin_Usuario.Text, txtLogin_Contraseña.Text, txtLogin_Correo.Text, "Usuario", Login_estado);
                        }
                    }

                    limpiarDatos();

                    if (ckbLogin_MostrarInactivos.Checked == false)
                    {
                        CargarGridLoginA();
                        CargarComboLoginA();
                    }
                    else
                    {
                        CargarGridLoginI();
                        CargarComboLoginI();
                    }
                }
                else
                {
                    if (UsuarioExistente(txtLogin_Usuario.Text) == "Existe" && CorreoExistente(txtLogin_Correo.Text) == "No existe")
                    {
                        MessageBox.Show("El nombre del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (UsuarioExistente(txtLogin_Usuario.Text) == "No existe" && CorreoExistente(txtLogin_Correo.Text) == "Existe")
                    {
                        MessageBox.Show("El correo electronico del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if(UsuarioExistente(txtLogin_Usuario.Text) == "Existe" && CorreoExistente(txtLogin_Correo.Text) == "Existe")
                    {
                        MessageBox.Show("El nombre y el correo del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        /*
        * El evento btnLogin_inactivar_Click se encarga de Inactivar los datos en la base de datos
        * y actualiza el comboBox y la tabla.
        */
        private void btnLogin_inactivar_Click(object sender, EventArgs e)
        {
            if (Login_id!=0)
            {
                using (GestorLogin Gestor = new GestorLogin())
                {
                    Gestor.LoginInactivar(Login_id);
                }

                limpiarDatos();

                if (ckbLogin_MostrarInactivos.Checked == false)
                {
                    CargarGridLoginA();
                    CargarComboLoginA();
                }
                else
                {
                    CargarGridLoginI();
                    CargarComboLoginI();
                }
            }
        }
        /*
         * El evento btnLogin_activar_Click se encarga de activar los datos en la base de datos
         * y actualiza el comboBox y la tabla.
         */
        private void btnLogin_activar_Click(object sender, EventArgs e)
        {
            if (Login_id != 0)
            {
                using (GestorLogin Gestor = new GestorLogin())
                {
                    Gestor.LoginActivar(Login_id);
                }

                Login_id = 0;

                if (ckbLogin_MostrarInactivos.Checked == false)
                {
                    CargarGridLoginA();
                    CargarComboLoginA();
                }
                else
                {
                    CargarGridLoginI();
                    CargarComboLoginI();
                }
                limpiarDatos();
            }
        }
        /*
         * El evento ckbLogin_MostrarInactivos_CheckedChanged se encarga de mostrar los datos inactivos o activos
         * en las tablas, comboBox.
         */
        private void ckbLogin_MostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbLogin_MostrarInactivos.Checked == false)
            {
                CargarGridLoginA();
                CargarComboLoginA();
            }
            else
            {
                CargarGridLoginI();
                CargarComboLoginI();
            }
            limpiarDatos();
        }
        /*
         * El evento ckbUsuario_CheckStateChanged uno de los metodos encargados de conservar un unico tipo de usuario 
         * canbiando el otro check box para que solo quede uno activo
         */
        private void ckbUsuario_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbAdministrador.Checked == true)
            {
                ckbAdministrador.Checked = false;
            }
        }
        /*
        * El evento ckbAdministrador_CheckStateChanged es el otro metodo encargado de conservar un unico tipo de usuario 
        * canbiando el otro check box para que solo quede uno activo
        */
        private void ckbAdministrador_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbUsuario.Checked == true)
            {
                ckbUsuario.Checked = false;
            }
        }
        /*
         *El evento button1_Click es el encagado de resgresar a la ventana de login si el usuario asi lo desea
         */
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }


        #endregion Eventos

        /*
         * El evento btnReporte_Click es el encargado de generar un reporte de los usuario dependiendo 
         * si estan los activos o los inactivos
         */
        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (ckbLogin_MostrarInactivos.Checked == true)
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_Login_I");
                reporte.Show();
            }
            else
            {
                Reporte reporte = new Reporte();
                reporte.DeteccionDeReporte("R_Login_A");
                reporte.Show();
            }
        }
    }
}
