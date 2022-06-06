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
    public class ServicioTramite : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioTramite()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }


        public string TramiteInsertar(Tramite nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor TramiteInsertar");

            miComando.CommandText = "TramiteInsertar";

            miComando.Parameters.Add("Tramite_nombre", SqlDbType.VarChar);
            miComando.Parameters["Tramite_nombre"].Value = nuevo.Tramite_nombre;

            miComando.Parameters.Add("Tramite_descripcion", SqlDbType.VarChar);
            miComando.Parameters["Tramite_descripcion"].Value = nuevo.Tramite_descripcion;

            miComando.Parameters.Add("Tramite_estado", SqlDbType.VarChar);
            miComando.Parameters["Tramite_estado"].Value = nuevo.Tramite_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio TramiteInsertar");

            return respuesta;
        }

        public string TramiteModificar(Tramite nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor TramiteModificar");

            miComando.CommandText = "TramiteModificar";

            miComando.Parameters.Add("Tramite_id", SqlDbType.Int);
            miComando.Parameters["Tramite_id"].Value = nuevo.Tramite_id;

            miComando.Parameters.Add("Tramite_nombre", SqlDbType.VarChar);
            miComando.Parameters["Tramite_nombre"].Value = nuevo.Tramite_nombre;

            miComando.Parameters.Add("Tramite_descripcion", SqlDbType.VarChar);
            miComando.Parameters["Tramite_descripcion"].Value = nuevo.Tramite_descripcion;

            miComando.Parameters.Add("Tramite_estado", SqlDbType.VarChar);
            miComando.Parameters["Tramite_estado"].Value = nuevo.Tramite_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio TramiteModificar");

            return respuesta;
        }

        public DataSet TramiteConsultar(int Tramite_id)
        {
            miComando.CommandText = "TramiteConsultar";
            miComando.Parameters.AddWithValue("@Tramite_id", SqlDbType.Int);
            miComando.Parameters["@Tramite_id"].Value = Tramite_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable TramiteListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor TramiteListarA");

            miComando.CommandText = "TramiteListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable TramiteListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor TramiteListarI");

            miComando.CommandText = "TramiteListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet TramiteActivar(int Tramite_id)
        {
            miComando.CommandText = "TramiteActivar";
            miComando.Parameters.AddWithValue("@Tramite_id", SqlDbType.Int);
            miComando.Parameters["@Tramite_id"].Value = Tramite_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet TramiteInactivar(int Tramite_id)
        {
            miComando.CommandText = "TramiteInactivar";
            miComando.Parameters.AddWithValue("@Tramite_id", SqlDbType.Int);
            miComando.Parameters["@Tramite_id"].Value = Tramite_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet TramiteEliminar(int Tramite_id)
        {
            miComando.CommandText = "TramiteEliminar";
            miComando.Parameters.AddWithValue("@Tramite_id", SqlDbType.Int);
            miComando.Parameters["@Tramite_id"].Value = Tramite_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }


    }
}
