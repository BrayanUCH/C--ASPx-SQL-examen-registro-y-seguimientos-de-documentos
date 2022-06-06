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
    public partial class olvidarContraseñaUsuario : Form
    {
        public olvidarContraseñaUsuario()
        {
            InitializeComponent();
        }
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
            correo = txtCorreo.Text;

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
            labelContraseña.Text = contraseña;
            LabelUsuario.Text = usuario;
        }
        #endregion Metodos
        //=====================================================================================
        #region Eventos
        /*
         * El evento btnVerificar_Click es el encagardo de llamar a todos los eventos para la verificacion de
         * correo, cargar los datos y limpiar los datos al hacer una nueva verificación
         */
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            labelContraseña.Text = "--";
            LabelUsuario.Text = "--";

            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Debe completar la informacion...");
            }
            else
            {
                BuscarCorreo();
            }
        }
        /*
         *El metodo btnVolver_Click es el encagado de resgresar a la ventana de login si el usuario asi lo desea
         */
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login from = new Login();

            from.Show();
        }
        #endregion Eventos

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCorreo.Text = "";
            labelContraseña.Text = "--";
            LabelUsuario.Text = "--";
        }
    }
}
