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
    public class ServicioCiclo : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioCiclo()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }

        public string CicloInsertar(Ciclo nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor CicloInsertar");

            miComando.CommandText = "CicloInsertar";

            miComando.Parameters.Add("Tramite_id", SqlDbType.Int);
            miComando.Parameters["Tramite_id"].Value = nuevo.Tramite_id;

            miComando.Parameters.Add("Departamento_id", SqlDbType.Int);
            miComando.Parameters["Departamento_id"].Value = nuevo.Departamento_id;

            miComando.Parameters.Add("Ciclo_orden", SqlDbType.VarChar);
            miComando.Parameters["Ciclo_orden"].Value = nuevo.Ciclo_orden;

            miComando.Parameters.Add("Ciclo_estado", SqlDbType.VarChar);
            miComando.Parameters["Ciclo_estado"].Value = nuevo.Ciclo_estado;


            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio CicloInsertar");

            return respuesta;
        }

        public string CicloModificar(Ciclo nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor CicloModificar");

            miComando.CommandText = "CicloModificar";

            miComando.Parameters.Add("Ciclo_id", SqlDbType.Int);
            miComando.Parameters["Ciclo_id"].Value = nuevo.Ciclo_id;

            miComando.Parameters.Add("Tramite_id", SqlDbType.Int);
            miComando.Parameters["Tramite_id"].Value = nuevo.Tramite_id;

            miComando.Parameters.Add("Departamento_id", SqlDbType.Int);
            miComando.Parameters["Departamento_id"].Value = nuevo.Departamento_id;

            miComando.Parameters.Add("Ciclo_orden", SqlDbType.VarChar);
            miComando.Parameters["Ciclo_orden"].Value = nuevo.Ciclo_orden;

            miComando.Parameters.Add("Ciclo_estado", SqlDbType.VarChar);
            miComando.Parameters["Ciclo_estado"].Value = nuevo.Ciclo_estado;


            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio CicloModificar");

            return respuesta;
        }

        public DataSet CicloConsultar(int Ciclo_id)
        {
            miComando.CommandText = "CicloConsultar";
            miComando.Parameters.AddWithValue("@Ciclo_id", SqlDbType.Int);
            miComando.Parameters["@Ciclo_id"].Value = Ciclo_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable CicloListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor CicloListarA");

            miComando.CommandText = "CicloListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable CicloListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor CicloListarI");

            miComando.CommandText = "CicloListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet CicloActivar(int Ciclo_id)
        {
            miComando.CommandText = "CicloActivar";
            miComando.Parameters.AddWithValue("@Ciclo_id", SqlDbType.Int);
            miComando.Parameters["@Ciclo_id"].Value = Ciclo_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet CicloInactivar(int Ciclo_id)
        {
            miComando.CommandText = "CicloInactivar";
            miComando.Parameters.AddWithValue("@Ciclo_id", SqlDbType.Int);
            miComando.Parameters["@Ciclo_id"].Value = Ciclo_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet CicloEliminar(int Ciclo_id)
        {
            miComando.CommandText = "CicloEliminar";
            miComando.Parameters.AddWithValue("@Ciclo_id", SqlDbType.Int);
            miComando.Parameters["@Ciclo_id"].Value = Ciclo_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }


    }
}
