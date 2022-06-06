using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Integracion;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //=====================================================================================
        //Codigos para iniciar el programa si no hay datos
        string codigo_usuario = "Administrador";
        string Codigo_contraseña = "admin";
        //=====================================================================================
        #region Variables
        /**
         * Las presentes variables son las responsables de algunos de los metodos de las tablas y/o 
         * otros metodos.
         */

        int id;
        string usuario;
        string contraseña;
        string correo;
        string administrador;
        string estado;
        bool reconocimientoRegistrar = false;
        DataSet dsLogin = new DataSet();
        DataTable dtLogin = new DataTable();
        #endregion Variables
        //=====================================================================================
        #region Metodos
        /*
         * El metodo BuscarUsuario es el encardado de verificar el Nombre de usuario que digito el usuario
         * para asi saber si el usuario es correcto o incorrecto
         */
        private void BuscarUsuario()
        {
            usuario = txtNombre.Text;

            using (GestorLogin servicioCL = new GestorLogin())
            {
                this.dsLogin = servicioCL.LoginConsuLoginConsultarUsuarioltar(usuario);
                this.dtLogin = this.dsLogin.Tables[0];
            }
            if ((dtLogin == null) || (dtLogin.Rows.Count == 0))
            {
                if (txtContraseña.Text == Codigo_contraseña && txtNombre.Text == codigo_usuario)
                {
                    Entrar();
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto...");

                }
            }
            else
            {
                cargarDatos();
                Entrar();
            }
            
            
        }
        /*
        * El metodo cargarDatos es el cagado de guardar los datos cargados en el datatable en el 
        * metodo anterior en variables para mejor manejo
        */
        private void cargarDatos()
        {
            id = int.Parse(this.dtLogin.Rows[0]["Login_id"].ToString());
            usuario = this.dtLogin.Rows[0]["Login_Usuario"].ToString();
            contraseña = this.dtLogin.Rows[0]["Login_contraseña"].ToString();
            correo = this.dtLogin.Rows[0]["Login_correoElectronico"].ToString();
            administrador = this.dtLogin.Rows[0]["Login_administrador"].ToString();
            estado = this.dtLogin.Rows[0]["Login_estado"].ToString();
        }
        /*
         * El metodo Entrar es el encargado de llamar al From1(ventana del gestor de archivos)
         * pero revisar si el usuario es "Usuario general" o "Administrados" para saber si tiene 
         * o no los pribilegios de administrador, ademas de revisar si va a ingresar al From1 o LoginRegistrar
         * para registrar los usuario si solo si el usuario es administrador
         */
        private void Entrar()
        {
            if (reconocimientoRegistrar == true)
            {
                if ((administrador == "Administrador" && estado == "A") || (txtNombre.Text == codigo_usuario && txtContraseña.Text == Codigo_contraseña))
                {
                    if (contraseña == txtContraseña.Text || (txtNombre.Text == codigo_usuario && txtContraseña.Text == Codigo_contraseña))
                    {
                        this.Hide();

                        LoginRegistrar from = new LoginRegistrar();

                        from.Show();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta...");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario debe ser administrador para poder registrar a un nuevo usuario...");
                }
                
            }
            else
            {
                if ((contraseña == txtContraseña.Text && estado == "A") || (txtContraseña.Text == Codigo_contraseña && txtNombre.Text == codigo_usuario))
                {
                    this.Hide();
                    bool tipo;
                    if (administrador == "Administrador")
                    {
                        tipo = true;
                    }
                    else
                    {
                        tipo = false;
                    }
                    Form1 from = new Form1();
                    from.tipoUsuario(tipo);
                    from.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta...");
                }
            }
        }
        #endregion Metodos
        //=====================================================================================
        #region Eventos
        /*
         * El Evento btnIngresar_Click es el encargado de verificar si el usuario digito los datos 
         * nesesario para ingresar al Form1(gestor de archivos) de ser asi llama al metodo BuscarUsuario
         * para que haga las consultas necesarias para ingresar
         */
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            reconocimientoRegistrar = false;
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Debe completar la información...");
            }
            else {
                BuscarUsuario();
            }
        }
        /*
         * El Evento btnOlvidar_Click es el encargado llamar al form 
         * olvidarContraseñaUsuario(donde recupera la contraseña o el usuario)
         */
        private void btnOlvidar_Click(object sender, EventArgs e)
        {
            this.Hide();

            olvidarContraseñaUsuario from = new olvidarContraseñaUsuario();

            from.Show();
        }
        /*
         * El Evento btnRegistrar_Click es el encargado de verificar si el usuario digito los datos 
         * nesesario para ingresar al Form LoginRegistrar(para registrar usuarios) de ser asi llama al metodo BuscarUsuario
         * para que haga las consultas necesarias para ingresar
         */
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Debe completar la información para poder registrar un usuario nuevo...");
            }
            else
            {
                reconocimientoRegistrar = true;
                BuscarUsuario();
            }
        }
        #endregion Eventos
        //=====================================================================================
        private void Login_Load(object sender, EventArgs e)
        {

        }
        //=====================================================================================
    }
}
