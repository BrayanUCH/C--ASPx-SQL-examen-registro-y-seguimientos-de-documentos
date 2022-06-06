using Capa_Integracion;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestor_Web.FrmGestor
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        DataSet dsUsuarioTipo = new DataSet();
        DataTable dtUsuarioTipo = new DataTable();

        #endregion Variables

        #region Metodos
        /*
         * El metodo BuscarUsuario es el encardado de verificar el Nombre de usuario que digito el usuario
         * para asi saber si el usuario es correcto o incorrecto
         */
        private void BuscarUsuario()
        {
            usuario = txbUsuario.Text;

            using (GestorLogin servicioCL = new GestorLogin())
            {
                this.dsLogin = servicioCL.LoginConsuLoginConsultarUsuarioltar(usuario);
                this.dtLogin = this.dsLogin.Tables[0];
            }
            if ((dtLogin == null) || (dtLogin.Rows.Count == 0))
            {
                if (txbContraseña.Text == Codigo_contraseña && txbUsuario.Text == codigo_usuario)
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
            usuario = txbUsuario.Text;

            using (GestorLogin servicioCL = new GestorLogin())
            {
                this.dsLogin = servicioCL.LoginConsuLoginConsultarUsuarioltar(usuario);
                this.dtLogin = this.dsLogin.Tables[0];
            }
            if ((dtLogin != null) && (dtLogin.Rows.Count != 0))
            {
                id = int.Parse(this.dtLogin.Rows[0]["Login_id"].ToString());
                usuario = this.dtLogin.Rows[0]["Login_Usuario"].ToString();
                contraseña = this.dtLogin.Rows[0]["Login_contraseña"].ToString();
                correo = this.dtLogin.Rows[0]["Login_correoElectronico"].ToString();
                administrador = this.dtLogin.Rows[0]["Login_administrador"].ToString();
                estado = this.dtLogin.Rows[0]["Login_estado"].ToString();
            }

            ////////////
            if (reconocimientoRegistrar == true)
            {
                if ((administrador == "Administrador" && estado == "A") || (txbUsuario.Text == codigo_usuario && txbContraseña.Text == Codigo_contraseña))
                {
                    if (contraseña == txbContraseña.Text || (txbUsuario.Text == codigo_usuario && txbContraseña.Text == Codigo_contraseña))
                    {
                        Response.Redirect("FrmRegistroLogin.aspx");
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
                if ((contraseña == txbContraseña.Text && estado == "A") || (txbContraseña.Text == Codigo_contraseña && txbUsuario.Text == codigo_usuario))
                {
                    using (GestorUsuarioTipo servicio = new GestorUsuarioTipo())
                    {
                        this.dsUsuarioTipo = servicio.usuarioConsultar(1);
                        this.dtUsuarioTipo = this.dsUsuarioTipo.Tables[0];
                    }

                    if ((dtUsuarioTipo == null) || (dtUsuarioTipo.Rows.Count == 0))
                    {
                        using (GestorUsuarioTipo Gestor = new GestorUsuarioTipo())
                        {
                            Gestor.UsuarioInsertar(1, administrador);
                        }
                    }
                    else
                    {
                        if ((txbContraseña.Text == Codigo_contraseña && txbUsuario.Text == codigo_usuario))
                        {
                            using (GestorUsuarioTipo Gestor = new GestorUsuarioTipo())
                            {
                                Gestor.UsuarioModificar(1, "Administrador");
                            }
                        }
                        else
                        {
                            using (GestorUsuarioTipo Gestor = new GestorUsuarioTipo())
                            {
                                Gestor.UsuarioModificar(1, administrador);
                            }
                        }
                        
                    }

                    Response.Redirect("FrmOrganizacion.aspx");
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta...");
                }
            }
        }
        #endregion Metodos
        //=====================================================================================
        /*
         * El Evento btnIngresar_Click es el encargado de verificar si el usuario digito los datos 
         * nesesario para ingresar al Form1(gestor de archivos) de ser asi llama al metodo BuscarUsuario
         * para que haga las consultas necesarias para ingresar
         */
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            reconocimientoRegistrar = false;
            if (string.IsNullOrEmpty(txbUsuario.Text) || string.IsNullOrEmpty(txbContraseña.Text))
            {
                MessageBox.Show("Debe completar la información...");
            }
            else
            {
                BuscarUsuario();
            }
        }
        /*
        * El Evento btnOlvidar_Click es el encargado llamar al form 
        * olvidarContraseñaUsuario(donde recupera la contraseña o el usuario)
        */
        protected void btnOlvidar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOlvidarCotra.aspx");
        }
        /*
        * El Evento btnRegistrar_Click es el encargado de verificar si el usuario digito los datos 
        * nesesario para ingresar al Form LoginRegistrar(para registrar usuarios) de ser asi llama al metodo BuscarUsuario
        * para que haga las consultas necesarias para ingresar
        */
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbUsuario.Text) || string.IsNullOrEmpty(txbContraseña.Text))
            {
                MessageBox.Show("Debe completar la información para poder registrar un usuario nuevo...");
            }
            else
            {
                reconocimientoRegistrar = true;
                BuscarUsuario();
            }
        }
    }
}