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
    public class ServicioDocumento : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioDocumento()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }

        public string DocumentoInsertar(Documento nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor DocumentoInsertar");

            miComando.CommandText = "DocumentoInsertar";

            miComando.Parameters.Add("Tramite_id", SqlDbType.Int);
            miComando.Parameters["Tramite_id"].Value = nuevo.Tramite_id;

            miComando.Parameters.Add("Idioma_id", SqlDbType.Int);
            miComando.Parameters["Idioma_id"].Value = nuevo.Idioma_id;

            miComando.Parameters.Add("Documento_nombre", SqlDbType.VarChar);
            miComando.Parameters["Documento_nombre"].Value = nuevo.Documento_nombre;

            miComando.Parameters.Add("Documento_ruta", SqlDbType.VarChar);
            miComando.Parameters["Documento_ruta"].Value = nuevo.Documento_ruta;

            miComando.Parameters.Add("Documento_tipo", SqlDbType.VarChar);
            miComando.Parameters["Documento_tipo"].Value = nuevo.Documento_tipo;

            miComando.Parameters.Add("Documento_estado", SqlDbType.VarChar);
            miComando.Parameters["Documento_estado"].Value = nuevo.Documento_estado;


            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio DocumentoInsertar");

            return respuesta;
        }

        public string DocumentoModificar(Documento nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor DocumentoModificar");

            miComando.CommandText = "DocumentoModificar";

            miComando.Parameters.Add("Documento_id", SqlDbType.Int);
            miComando.Parameters["Documento_id"].Value = nuevo.Documento_id;

            miComando.Parameters.Add("Tramite_id", SqlDbType.Int);
            miComando.Parameters["Tramite_id"].Value = nuevo.Tramite_id;

            miComando.Parameters.Add("Idioma_id", SqlDbType.Int);
            miComando.Parameters["Idioma_id"].Value = nuevo.Idioma_id;

            miComando.Parameters.Add("Documento_nombre", SqlDbType.VarChar);
            miComando.Parameters["Documento_nombre"].Value = nuevo.Documento_nombre;

            miComando.Parameters.Add("Documento_ruta", SqlDbType.VarChar);
            miComando.Parameters["Documento_ruta"].Value = nuevo.Documento_ruta;

            miComando.Parameters.Add("Documento_tipo", SqlDbType.VarChar);
            miComando.Parameters["Documento_tipo"].Value = nuevo.Documento_tipo;

            miComando.Parameters.Add("Documento_estado", SqlDbType.VarChar);
            miComando.Parameters["Documento_estado"].Value = nuevo.Documento_estado;


            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio DocumentoModificar");

            return respuesta;
        }



        public DataSet DocumentoConsultar(int Documento_id)
        {
            miComando.CommandText = "DocumentoConsultar";
            miComando.Parameters.AddWithValue("@Documento_id", SqlDbType.Int);
            miComando.Parameters["@Documento_id"].Value = Documento_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable DocumentoListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor DocumentoListarA");

            miComando.CommandText = "DocumentoListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable DocumentoListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor DocumentoListarI");

            miComando.CommandText = "DocumentoListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet DocumentoActivar(int Documento_id)
        {
            miComando.CommandText = "DocumentoActivar";
            miComando.Parameters.AddWithValue("@Documento_id", SqlDbType.Int);
            miComando.Parameters["@Documento_id"].Value = Documento_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet DocumentoInactivar(int Documento_id)
        {
            miComando.CommandText = "DocumentoInactivar";
            miComando.Parameters.AddWithValue("@Documento_id", SqlDbType.Int);
            miComando.Parameters["@Documento_id"].Value = Documento_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet DocumentoEliminar(int Documento_id)
        {
            miComando.CommandText = "DocumentoEliminar";
            miComando.Parameters.AddWithValue("@Documento_id", SqlDbType.Int);
            miComando.Parameters["@Documento_id"].Value = Documento_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }


    }
}
