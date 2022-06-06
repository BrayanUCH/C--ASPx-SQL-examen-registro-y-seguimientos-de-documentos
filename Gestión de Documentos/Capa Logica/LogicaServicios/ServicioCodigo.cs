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
    public class ServicioCodigo : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioCodigo()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }

        public string CodigoInsertar(Codigo nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor CodigoInsertar");

            miComando.CommandText = "CodigoInsertar";

            miComando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            miComando.Parameters["Organizacion_id"].Value = nuevo.Organizacion_id;

            miComando.Parameters.Add("Codigo_formato", SqlDbType.VarChar);
            miComando.Parameters["Codigo_formato"].Value = nuevo.Codigo_formato;

            miComando.Parameters.Add("Codigo_estado", SqlDbType.VarChar);
            miComando.Parameters["Codigo_estado"].Value = nuevo.Codigo_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio CodigoInsertar");

            return respuesta;
        }
        public string CodigoModificar(Codigo nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor CodigoModificar");

            miComando.CommandText = "CodigoModificar";

            miComando.Parameters.Add("Codigo_id", SqlDbType.Int);
            miComando.Parameters["Codigo_id"].Value = nuevo.Codigo_id;

            miComando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            miComando.Parameters["Organizacion_id"].Value = nuevo.Organizacion_id;

            miComando.Parameters.Add("Codigo_formato", SqlDbType.VarChar);
            miComando.Parameters["Codigo_formato"].Value = nuevo.Codigo_formato;

            miComando.Parameters.Add("Codigo_estado", SqlDbType.VarChar);
            miComando.Parameters["Codigo_estado"].Value = nuevo.Codigo_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio CodigoModificar");

            return respuesta;
        }

        public DataSet CodigoConsultar(int Codigo_id)
        {
            miComando.CommandText = "CodigoConsultar";
            miComando.Parameters.AddWithValue("@Codigo_id", SqlDbType.Int);
            miComando.Parameters["@Codigo_id"].Value = Codigo_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable CodigoListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor CodigoListarA");

            miComando.CommandText = "CodigoListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable CodigoListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor CodigoListarI");

            miComando.CommandText = "CodigoListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet CodigoActivar(int Codigo_id)
        {
            miComando.CommandText = "CodigoActivar";
            miComando.Parameters.AddWithValue("@Codigo_id", SqlDbType.Int);
            miComando.Parameters["@Codigo_id"].Value = Codigo_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet CodigoInactivar(int Codigo_id)
        {
            miComando.CommandText = "CodigoInactivar";
            miComando.Parameters.AddWithValue("@Codigo_id", SqlDbType.Int);
            miComando.Parameters["@Codigo_id"].Value = Codigo_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet CodigoEliminar(int Codigo_id)
        {
            miComando.CommandText = "CodigoEliminar";
            miComando.Parameters.AddWithValue("@Codigo_id", SqlDbType.Int);
            miComando.Parameters["@Codigo_id"].Value = Codigo_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

    }
}
