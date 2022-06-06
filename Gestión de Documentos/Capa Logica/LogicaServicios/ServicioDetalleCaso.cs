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
    public class ServicioDetalleCaso : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioDetalleCaso()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }


        public string DetalleCasoInsertar(DetalleCaso nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor DetalleCasoInsertar");

            miComando.CommandText = "DetalleCasoInsertar";

            miComando.Parameters.Add("Caso_id", SqlDbType.Int);
            miComando.Parameters["Caso_id"].Value = nuevo.Caso_id;

            miComando.Parameters.Add("Ciclo_id", SqlDbType.Int);
            miComando.Parameters["Ciclo_id"].Value = nuevo.Ciclo_id;

            miComando.Parameters.Add("Documento_id", SqlDbType.Int);
            miComando.Parameters["Documento_id"].Value = nuevo.Documento_id;

            miComando.Parameters.Add("DetalleCaso_fechaRecibido", SqlDbType.Date);
            miComando.Parameters["DetalleCaso_fechaRecibido"].Value = nuevo.DetalleCaso_fechaRecibido;

            miComando.Parameters.Add("DetalleCaso_fechaTranspaso", SqlDbType.Date);
            miComando.Parameters["DetalleCaso_fechaTranspaso"].Value = nuevo.DetalleCaso_fechaTranspaso;

            miComando.Parameters.Add("DetalleCaso_descripcion", SqlDbType.VarChar);
            miComando.Parameters["DetalleCaso_descripcion"].Value = nuevo.DetalleCaso_descripcion;

            miComando.Parameters.Add("DetalleCaso_estado", SqlDbType.VarChar);
            miComando.Parameters["DetalleCaso_estado"].Value = nuevo.DetalleCaso_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio DetalleCasoInsertar");

            return respuesta;
        }

        public string DetalleCasoModificar(DetalleCaso nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor DetalleCasoModificar");

            miComando.CommandText = "DetalleCasoModificar";

            miComando.Parameters.Add("DetalleCaso_id", SqlDbType.Int);
            miComando.Parameters["DetalleCaso_id"].Value = nuevo.DetalleCaso_id;

            miComando.Parameters.Add("Caso_id", SqlDbType.Int);
            miComando.Parameters["Caso_id"].Value = nuevo.Caso_id;

            miComando.Parameters.Add("Ciclo_id", SqlDbType.Int);
            miComando.Parameters["Ciclo_id"].Value = nuevo.Ciclo_id;

            miComando.Parameters.Add("Documento_id", SqlDbType.Int);
            miComando.Parameters["Documento_id"].Value = nuevo.Documento_id;

            miComando.Parameters.Add("DetalleCaso_fechaRecibido", SqlDbType.Date);
            miComando.Parameters["DetalleCaso_fechaRecibido"].Value = nuevo.DetalleCaso_fechaRecibido;

            miComando.Parameters.Add("DetalleCaso_fechaTranspaso", SqlDbType.Date);
            miComando.Parameters["DetalleCaso_fechaTranspaso"].Value = nuevo.DetalleCaso_fechaTranspaso;

            miComando.Parameters.Add("DetalleCaso_descripcion", SqlDbType.VarChar);
            miComando.Parameters["DetalleCaso_descripcion"].Value = nuevo.DetalleCaso_descripcion;

            miComando.Parameters.Add("DetalleCaso_estado", SqlDbType.VarChar);
            miComando.Parameters["DetalleCaso_estado"].Value = nuevo.DetalleCaso_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio DetalleCasoModificar");

            return respuesta;
        }

        public DataSet DetalleCasoConsultar(int DetalleCaso_id)
        {
            miComando.CommandText = "DetalleCasoConsultar";
            miComando.Parameters.AddWithValue("@DetalleCaso_id", SqlDbType.Int);
            miComando.Parameters["@DetalleCaso_id"].Value = DetalleCaso_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable DetalleCasoListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor DetalleCasoListarA");

            miComando.CommandText = "DetalleCasoListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable DetalleCasoListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor DetalleCasoListarI");

            miComando.CommandText = "DetalleCasoListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet DetalleCasoActivar(int DetalleCaso_id)
        {
            miComando.CommandText = "DetalleCasoActivar";
            miComando.Parameters.AddWithValue("@DetalleCaso_id", SqlDbType.Int);
            miComando.Parameters["@DetalleCaso_id"].Value = DetalleCaso_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet DetalleCasoInactivar(int DetalleCaso_id)
        {
            miComando.CommandText = "DetalleCasoInactivar";
            miComando.Parameters.AddWithValue("@DetalleCaso_id", SqlDbType.Int);
            miComando.Parameters["@DetalleCaso_id"].Value = DetalleCaso_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet DetalleCasoEliminar(int DetalleCaso_id)
        {
            miComando.CommandText = "DetalleCasoEliminar";
            miComando.Parameters.AddWithValue("@DetalleCaso_id", SqlDbType.Int);
            miComando.Parameters["@DetalleCaso_id"].Value = DetalleCaso_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }





    }
}
