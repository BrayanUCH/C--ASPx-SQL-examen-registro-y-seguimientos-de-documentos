using Capa_Logica.LogicaNegocio;
using Manejo_registros.CapaConexion;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Logica.LogicaServicios
{
    public class ServicioUsuarioTipo : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioUsuarioTipo()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }

        public string UsuarioInsertar(UsuarioTipo nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor UsuarioInsertar");

            miComando.CommandText = "UsuarioInsertar";

            miComando.Parameters.Add("Usuario_id", SqlDbType.Int);
            miComando.Parameters["Usuario_id"].Value = nuevo.Usuario_id;

            miComando.Parameters.Add("Usuario_tipo", SqlDbType.VarChar);
            miComando.Parameters["Usuario_tipo"].Value = nuevo.Usuario_tipo;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio UsuarioInsertar");

            return respuesta;
        }

        public string UsuarioModificar(UsuarioTipo nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor UsuarioModificar");

            miComando.CommandText = "UsuarioModificar";

            miComando.Parameters.Add("Usuario_id", SqlDbType.Int);
            miComando.Parameters["Usuario_id"].Value = nuevo.Usuario_id;

            miComando.Parameters.Add("Usuario_tipo", SqlDbType.VarChar);
            miComando.Parameters["Usuario_tipo"].Value = nuevo.Usuario_tipo;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio UsuarioModificar");

            return respuesta;
        }

        public DataSet UsuarioTipoConsultar(int Usuario_id)
        {
            miComando.CommandText = "UsuarioConsultar";
            miComando.Parameters.AddWithValue("@Usuario_id", SqlDbType.Int);
            miComando.Parameters["@Usuario_id"].Value = Usuario_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }
    }
}
