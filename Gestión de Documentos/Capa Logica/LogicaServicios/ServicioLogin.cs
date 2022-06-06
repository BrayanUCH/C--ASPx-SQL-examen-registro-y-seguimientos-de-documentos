using Manejo_registros.Capa_Logica.LogicaNegocio;
using Manejo_registros.CapaConexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaServicios
{
    public class ServicioLogin : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioLogin()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }

        public string LoginInsertar(Login nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor LoginInsertar");

            miComando.CommandText = "LoginInsertar";

            miComando.Parameters.Add("Login_Usuario", SqlDbType.VarChar);
            miComando.Parameters["Login_Usuario"].Value = nuevo.Login_usuario;

            miComando.Parameters.Add("Login_contraseña", SqlDbType.VarChar);
            miComando.Parameters["Login_contraseña"].Value = nuevo.Login_contraseña;

            miComando.Parameters.Add("Login_correoElectronico", SqlDbType.VarChar);
            miComando.Parameters["Login_correoElectronico"].Value = nuevo.Login_correoElectronico;

            miComando.Parameters.Add("Login_administrador", SqlDbType.VarChar);
            miComando.Parameters["Login_administrador"].Value = nuevo.Login_administrador;

            miComando.Parameters.Add("Login_estado", SqlDbType.VarChar);
            miComando.Parameters["Login_estado"].Value = nuevo.Login_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio LoginInsertar");

            return respuesta;
        }

        public string LoginModificar(Login nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor LoginModificar");

            miComando.CommandText = "LoginModificar";

            miComando.Parameters.Add("Login_id", SqlDbType.Int);
            miComando.Parameters["Login_id"].Value = nuevo.Login_id;

            miComando.Parameters.Add("Login_Usuario", SqlDbType.VarChar);
            miComando.Parameters["Login_Usuario"].Value = nuevo.Login_usuario;

            miComando.Parameters.Add("Login_contraseña", SqlDbType.VarChar);
            miComando.Parameters["Login_contraseña"].Value = nuevo.Login_contraseña;

            miComando.Parameters.Add("Login_correoElectronico", SqlDbType.VarChar);
            miComando.Parameters["Login_correoElectronico"].Value = nuevo.Login_correoElectronico;

            miComando.Parameters.Add("Login_administrador", SqlDbType.VarChar);
            miComando.Parameters["Login_administrador"].Value = nuevo.Login_administrador;

            miComando.Parameters.Add("Login_estado", SqlDbType.VarChar);
            miComando.Parameters["Login_estado"].Value = nuevo.Login_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio LoginModificar");

            return respuesta;
        }


        public DataSet LoginConsultar(int Login_id)
        {
            miComando.CommandText = "LoginConsultar";
            miComando.Parameters.AddWithValue("@Login_id", SqlDbType.Int);
            miComando.Parameters["@Login_id"].Value = Login_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable LoginListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor LoginListarA");

            miComando.CommandText = "LoginListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable LoginListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor LoginListarI");

            miComando.CommandText = "LoginListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet LoginActivar(int Login_id)
        {
            miComando.CommandText = "LoginActivar";
            miComando.Parameters.AddWithValue("@Login_id", SqlDbType.Int);
            miComando.Parameters["@Login_id"].Value = Login_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet LoginInactivar(int Login_id)
        {
            miComando.CommandText = "LoginInactivar";
            miComando.Parameters.AddWithValue("@Login_id", SqlDbType.Int);
            miComando.Parameters["@Login_id"].Value = Login_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet LoginEliminar(int Login_id)
        {
            miComando.CommandText = "LoginEliminar";
            miComando.Parameters.AddWithValue("@Login_id", SqlDbType.Int);
            miComando.Parameters["@Login_id"].Value = Login_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet LoginConsultarUsuario(string Login_Usuario)
        {
            miComando.CommandText = "LoginConsultarUsuario";
            miComando.Parameters.AddWithValue("@Login_Usuario", SqlDbType.VarChar);
            miComando.Parameters["@Login_Usuario"].Value = Login_Usuario;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet LoginConsultarCorreo(string Login_correoElectronico)
        {
            miComando.CommandText = "LoginConsultarCorreo";
            miComando.Parameters.AddWithValue("@Login_correoElectronico", SqlDbType.VarChar);
            miComando.Parameters["@Login_correoElectronico"].Value = Login_correoElectronico;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }






    }
}
