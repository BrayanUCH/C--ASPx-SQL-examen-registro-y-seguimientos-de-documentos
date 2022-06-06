using Capa_Integracion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Gestor_Web.FrmGestor
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //=====================================================================================
        #region Veriables
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
        DataSet dsLogin = new DataSet();
        DataTable dtLogin = new DataTable();

        #endregion Veriables
        //=====================================================================================
        #region Metodos
        /*
         * El metodo BuscarCorreo es el encardado de verificar el correo que digito el usuario
         * para asi poder desplegar la informacion correspondiente (Usuario, Contraseña)
         */
        private void BuscarCorreo()
        {
            correo = txbCorreo.Text;

            using (GestorLogin servicioCL = new GestorLogin())
            {
                this.dsLogin = servicioCL.LoginConsultarCorreo(correo);
                this.dtLogin = this.dsLogin.Tables[0];
            }
            if ((dtLogin == null) || (dtLogin.Rows.Count == 0))
            {
                MessageBox.Show("Correo electronico incorrecto...");
            }
            else
            {
                cargarDatos();

                colocarDatos();
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
         * El metodo colocarDatos es el encagado de cargar la informacion en la ventana(labels)
         * para que el usuario vea la informacion corespondiente
         */
        private void colocarDatos()
        {
            lblUsuario.Text = contraseña;
            lblContraseña.Text = usuario;
        }
        #endregion Metodos
        //=====================================================================================
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //verificar
        /*
         * El evento Button1_Click es el encagardo de llamar a todos los eventos para la verificacion de
         * correo, cargar los datos y limpiar los datos al hacer una nueva verificación
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblUsuario.Text = "--";
            lblContraseña.Text = "--";

            if (string.IsNullOrEmpty(txbCorreo.Text))
            {
                MessageBox.Show("Debe completar la informacion...");
            }
            else
            {
                BuscarCorreo();
            }
        }

        //limpiar
        /*
       *El evento Button2_Click es el encagado de limpiar toda la informacion
       */
        protected void Button2_Click(object sender, EventArgs e)
        {
            lblUsuario.Text = "--";
            lblContraseña.Text = "--";
            txbCorreo.Text = "";
        }

        //volver
        /*
        *El evento Button3_Click es el encagado de resgresar a la ventana de login si el usuario asi lo desea
        */
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }
    }
}