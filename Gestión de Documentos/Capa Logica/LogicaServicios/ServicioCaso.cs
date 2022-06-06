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
    public class ServicioCaso : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioCaso()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }


        public string CasoInsertar(Caso nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor InsertarCaso");

            miComando.CommandText = "CasoInsertar";

            miComando.Parameters.Add("Tramite_id", SqlDbType.Int);
            miComando.Parameters["Tramite_id"].Value = nuevo.Tramite_id;

            miComando.Parameters.Add("Caso_codigo", SqlDbType.VarChar);
            miComando.Parameters["Caso_codigo"].Value = nuevo.Caso_codigo;

            miComando.Parameters.Add("Caso_fechaInicio", SqlDbType.Date);
            miComando.Parameters["Caso_fechaInicio"].Value = nuevo.Caso_fechaInicio;

            miComando.Parameters.Add("Caso_fechaFinal", SqlDbType.Date);
            miComando.Parameters["Caso_fechaFinal"].Value = nuevo.Caso_fechaFinal;

            miComando.Parameters.Add("Caso_estado", SqlDbType.VarChar);
            miComando.Parameters["Caso_estado"].Value = nuevo.Caso_estado;


            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio InsertarCaso");

            return respuesta;
        }
        public string CasoModificar(Caso nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor CasoModificar");

            miComando.CommandText = "CasoModificar";

            miComando.Parameters.Add("Caso_id", SqlDbType.Int);
            miComando.Parameters["Caso_id"].Value = nuevo.Caso_id; 

            miComando.Parameters.Add("Tramite_id", SqlDbType.Int);
            miComando.Parameters["Tramite_id"].Value = nuevo.Tramite_id;

            miComando.Parameters.Add("Caso_codigo", SqlDbType.VarChar);
            miComando.Parameters["Caso_codigo"].Value = nuevo.Caso_codigo;

            miComando.Parameters.Add("Caso_fechaInicio", SqlDbType.Date);
            miComando.Parameters["Caso_fechaInicio"].Value = nuevo.Caso_fechaInicio;

            miComando.Parameters.Add("Caso_fechaFinal", SqlDbType.Date);
            miComando.Parameters["Caso_fechaFinal"].Value = nuevo.Caso_fechaFinal;

            miComando.Parameters.Add("Caso_estado", SqlDbType.VarChar);
            miComando.Parameters["Caso_estado"].Value = nuevo.Caso_estado;


            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio CasoModificar");

            return respuesta;
        }

        public DataSet CasoConsultar(int Caso_id)
        {
            miComando.CommandText = "CasoConsultar";
            miComando.Parameters.AddWithValue("@Caso_id", SqlDbType.Int);
            miComando.Parameters["@Caso_id"].Value = Caso_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable CasoListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor CasoListarA");

            miComando.CommandText = "CasoListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable CasoListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor CasoListarI");

            miComando.CommandText = "CasoListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet CasoActivar(int Caso_id)
        {
            miComando.CommandText = "CasoActivar";
            miComando.Parameters.AddWithValue("@Caso_id", SqlDbType.Int);
            miComando.Parameters["@Caso_id"].Value = Caso_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet CasoInactivar(int Caso_id)
        {
            miComando.CommandText = "CasoInactivar";
            miComando.Parameters.AddWithValue("@Caso_id", SqlDbType.Int);
            miComando.Parameters["@Caso_id"].Value = Caso_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet CasoEliminar(int Caso_id)
        {
            miComando.CommandText = "CasoEliminar";
            miComando.Parameters.AddWithValue("@Caso_id", SqlDbType.Int);
            miComando.Parameters["@Caso_id"].Value = Caso_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }
        public DataSet CasoConsultarCodigo(string Caso_codigo)
        {
            miComando.CommandText = "CasoConsultarCodigo";
            miComando.Parameters.AddWithValue("@Caso_codigo", SqlDbType.VarChar);
            miComando.Parameters["@Caso_codigo"].Value = Caso_codigo;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }
    }
}
