using System;
using System.Data;
using System.Windows.Forms;
using Capa_Integracion;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmRegistroLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridLoginA();
                CargarComboLoginA();
            }
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
        string CONTRASEÑA = "";
        string USUARIO = "";

        #endregion Variables
        //=====================================================================================
        #region Metodos
        /*
         *El metodo UsuarioExistente es el encargado de verificar si el Nombre de usuario digitado
         * ya esta registrado
         */
        private string UsuarioExistente(string usuario, string usuarioActual)
        {
            if (usuarioActual != txbUsuario.Text)
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
        private string CorreoExistente(string correo, string correoActual)
        {
            if (correoActual != txbCorreo.Text)
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
                gvLoging.DataSource = servicioCL.LoginListarA();

                gvLoging.DataBind();
            }
        }
        /*
        * El metodo CargarGridLoginI es el encargado de cargar los datos de los inactivos en la tabla.
        */
        private void CargarGridLoginI()
        {
            using (GestorLogin servicioCL = new GestorLogin())
            {
                gvLoging.DataSource = servicioCL.LoginListarI();

                gvLoging.DataBind();
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
                ddlCargarDatos.DataSource = servicioCL.LoginListarA();

                ddlCargarDatos.DataValueField = "Login_id";
                ddlCargarDatos.DataTextField = "Login_Usuario";

                ddlCargarDatos.DataBind();
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
                ddlCargarDatos.DataSource = servicioCL.LoginListarI();

                ddlCargarDatos.DataValueField = "Login_id";
                ddlCargarDatos.DataTextField = "Login_Usuario";
                ddlCargarDatos.DataBind();
            }
        }
        /*
        * El metodo BuscarLogin se encarga de buscar un dato espesifico mediante una id
        * y guarda los datos en un DataTable.
        */
        private void BuscarLogin()
        {
            Login_id = int.Parse(ddlCargarDatos.SelectedValue.ToString());
            using (GestorLogin servicioCL = new GestorLogin())
            {
                this.dsLogin = servicioCL.LoginConsultar(Login_id);
                this.dtLogin = this.dsLogin.Tables[0];
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
            txbUsuario.Text = this.dtLogin.Rows[0]["Login_Usuario"].ToString();
            USUARIO = this.dtLogin.Rows[0]["Login_Usuario"].ToString();
            txbContrraseña.Text = this.dtLogin.Rows[0]["Login_contraseña"].ToString();
            txbCorreo.Text = this.dtLogin.Rows[0]["Login_correoElectronico"].ToString();
            CORREO = this.dtLogin.Rows[0]["Login_correoElectronico"].ToString();

            Aux = this.dtLogin.Rows[0]["Login_administrador"].ToString();

            if (Aux == "Administrador")
            {
                ddlTipoUsuario.Text = "Administrador";
            }
            else
            {
                ddlTipoUsuario.Text = "Usuario General";
            }
            Login_estado = this.dtLogin.Rows[0]["Login_estado"].ToString();
        }
        /* 
         * el metodo limpiarDatos es el encagado de limpiar la informacion de los diferentes txt
         */
        private void limpiarDatos()
        {
            txbContrraseña.Text = "";
            txbCorreo.Text = "";
            txbUsuario.Text = "";

            ddlTipoUsuario.SelectedIndex = 0;

            Login_id = 0;
            Login_estado = "";

        }
        #endregion Metodos
        //=====================================================================================3

        #region Eventos
        /*
        * El evento btnInsertar_Click se encarga de insertar los datos en la base de datos
        * y actualiza el comboBox y la tabla. 
        */
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbUsuario.Text) || string.IsNullOrEmpty(txbContrraseña.Text) ||
                string.IsNullOrEmpty(txbCorreo.Text))
            {
                if (txbUsuario.Text == "")
                {
                    MessageBox.Show("El nombre del usuario es un espacio requerido ", "ALERTA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (txbContrraseña.Text == "")
                {
                    MessageBox.Show("La contraseña es un espacio requerido", "ALERTA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (txbCorreo.Text == "")
                {
                    MessageBox.Show("El correo es un espacio requerido ", "ALERTA",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (UsuarioExistente(txbUsuario.Text, USUARIO) == "No existe" && CorreoExistente(txbCorreo.Text, CORREO) == "No existe"
                    && USUARIO != txbUsuario.Text && CORREO != txbCorreo.Text)
                {
                    using (GestorLogin Gestor = new GestorLogin())
                    {
                        if (ddlTipoUsuario.SelectedValue == "Administrador")
                        {
                            Gestor.LoginInsertar(txbUsuario.Text, txbContrraseña.Text, txbCorreo.Text, "Administrador", "A");
                        }
                        else
                        {
                            Gestor.LoginInsertar(txbUsuario.Text, txbContrraseña.Text, txbCorreo.Text, "Usuario", "A");
                        }
                    }

                    limpiarDatos();

                    if (ckbMostrarInactivos.Checked == false)
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
                    if (UsuarioExistente(txbUsuario.Text, USUARIO) == "Existe" && CorreoExistente(txbCorreo.Text, CORREO) == "No existe")
                    {
                        MessageBox.Show("El nombre del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (USUARIO == txbUsuario.Text)
                    {
                        MessageBox.Show("El nombre del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (CORREO == txbCorreo.Text)
                    {
                        MessageBox.Show("El correo electronico del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (UsuarioExistente(txbUsuario.Text, USUARIO) == "No existe" && CorreoExistente(txbCorreo.Text, CORREO) == "Existe")
                    {
                        MessageBox.Show("El correo electronico del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (UsuarioExistente(txbUsuario.Text, USUARIO) == "Existe" && CorreoExistente(txbCorreo.Text, CORREO) == "Existe")
                    {
                        MessageBox.Show("El nombre y el correo del usuario ya existe", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        /*
        * El evento btnModificar_Click se encarga de modificar los datos en la base de datos
        * y actualiza el comboBox y la tabla. 
        */
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Login_id = int.Parse(ddlCargarDatos.SelectedValue.ToString());
                if (Login_id != 0)
                {

                    using (GestorLogin servicioCL = new GestorLogin())
                    {
                        this.dsLogin = servicioCL.LoginConsultar(Login_id);
                        this.dtLogin = this.dsLogin.Tables[0];
                    }

                    string Aux = "";
                    USUARIO = this.dtLogin.Rows[0]["Login_Usuario"].ToString();
                    CONTRASEÑA = this.dtLogin.Rows[0]["Login_contraseña"].ToString();
                    CORREO = this.dtLogin.Rows[0]["Login_correoElectronico"].ToString();

                    Aux = this.dtLogin.Rows[0]["Login_administrador"].ToString();

                    
                    Login_estado = this.dtLogin.Rows[0]["Login_estado"].ToString();
                }

                //#######################################################################################

                if (string.IsNullOrEmpty(txbUsuario.Text) || string.IsNullOrEmpty(txbContrraseña.Text) ||
                    string.IsNullOrEmpty(txbCorreo.Text))
                {
                    if (txbUsuario.Text == "")
                    {
                        MessageBox.Show("El nombre del usuario es un espacio requerido ", "ALERTA",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (txbContrraseña.Text == "")
                    {
                        MessageBox.Show("La contraseña es un espacio requerido", "ALERTA",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (txbCorreo.Text == "")
                    {
                        MessageBox.Show("El correo es un espacio requerido ", "ALERTA",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    if (UsuarioExistente(txbUsuario.Text, USUARIO) == "No existe" && CorreoExistente(txbCorreo.Text, CORREO) == "No existe")
                    {
                        using (GestorLogin Gestor = new GestorLogin())
                        {
                            Login_id = int.Parse(ddlCargarDatos.SelectedValue.ToString());

                            if (ddlTipoUsuario.Text == "Administrador")
                            {
                                Gestor.LoginModificar(Login_id, txbUsuario.Text, txbContrraseña.Text, txbCorreo.Text, "Administrador", Login_estado);
                            }
                            else
                            {
                                Gestor.LoginModificar(Login_id, txbUsuario.Text, txbContrraseña.Text, txbCorreo.Text, "Usuario", Login_estado);
                            }
                        }

                        limpiarDatos();

                        if (ckbMostrarInactivos.Checked == false)
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
                        if (UsuarioExistente(txbUsuario.Text, USUARIO) == "Existe" && CorreoExistente(txbCorreo.Text, CORREO) == "No existe")
                        {
                            MessageBox.Show("El nombre del usuario ya existe", "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (UsuarioExistente(txbUsuario.Text, USUARIO) == "No existe" && CorreoExistente(txbCorreo.Text, CORREO) == "Existe")
                        {
                            MessageBox.Show("El correo electronico del usuario ya existe", "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (UsuarioExistente(txbUsuario.Text, USUARIO) == "Existe" && CorreoExistente(txbCorreo.Text, CORREO) == "Existe")
                        {
                            MessageBox.Show("El nombre y el correo del usuario ya existe", "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        /*
        * El evento btnActivar_Click se encarga de activar los datos en la base de datos
        * y actualiza el comboBox y la tabla.
        */
        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                Login_id = int.Parse(ddlCargarDatos.SelectedValue.ToString());

                if (Login_id != 0)
                {
                    using (GestorLogin Gestor = new GestorLogin())
                    {
                        Gestor.LoginActivar(Login_id);
                    }

                    limpiarDatos();

                    if (ckbMostrarInactivos.Checked == false)
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
            catch (Exception)
            {

            }
        }
        /*
        * El evento btninactivar_Click se encarga de Inactivar los datos en la base de datos
        * y actualiza el comboBox y la tabla.
        */
        protected void btninactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Login_id = int.Parse(ddlCargarDatos.SelectedValue.ToString());
                if (Login_id != 0)
                {
                    using (GestorLogin Gestor = new GestorLogin())
                    {
                        Gestor.LoginInactivar(Login_id);
                    }

                    Login_id = 0;

                    if (ckbMostrarInactivos.Checked == false)
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
            catch (Exception)
            {

            }
        }
        /*
        * El evento btnCargarDatos_Click se encarga de cargar los datos de la base de datos
        * en los txt, cbx y los dtp, con la ayuda de metodo BuscarLogin. 
        */
        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarLogin();
            }
            catch (Exception)
            {

            }
        }
        /*
         *El evento btnActualizarDatos_Click es el encagado de regresar a la ventana de login
         *
         */
        protected void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            if (ckbMostrarInactivos.Checked == false)
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
         *El evento btnVolverLogin_Click es el encagado de resgresar a la ventana de login si el usuario asi lo desea
         */
        protected void btnVolverLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogin.aspx");
        }
        #endregion Eventos

    }
}