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
    public class ServicioIdioma : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioIdioma()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }

        public string IdiomaInsertar(Idioma nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor IdiomaInsertar");

            miComando.CommandText = "IdiomaInsertar";

            miComando.Parameters.Add("Idioma_nombre", SqlDbType.VarChar);
            miComando.Parameters["Idioma_nombre"].Value = nuevo.Idioma_nombre;

            miComando.Parameters.Add("Idioma_iniciales", SqlDbType.VarChar);
            miComando.Parameters["Idioma_iniciales"].Value = nuevo.Idioma_iniciales;

            miComando.Parameters.Add("Idioma_estado", SqlDbType.VarChar);
            miComando.Parameters["Idioma_estado"].Value = nuevo.Idioma_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio IdiomaInsertar");

            return respuesta;
        }

        public string IdiomaModificar(Idioma nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor IdiomaModificar");

            miComando.CommandText = "IdiomaModificar";

            miComando.Parameters.Add("Idioma_id", SqlDbType.Int);
            miComando.Parameters["Idioma_id"].Value = nuevo.Idioma_id;

            miComando.Parameters.Add("Idioma_nombre", SqlDbType.VarChar);
            miComando.Parameters["Idioma_nombre"].Value = nuevo.Idioma_nombre;

            miComando.Parameters.Add("Idioma_iniciales", SqlDbType.VarChar);
            miComando.Parameters["Idioma_iniciales"].Value = nuevo.Idioma_iniciales;

            miComando.Parameters.Add("Idioma_estado", SqlDbType.VarChar);
            miComando.Parameters["Idioma_estado"].Value = nuevo.Idioma_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio IdiomaModificar");

            return respuesta;
        }

        public DataSet IdiomaConsultar(int Idioma_id)
        {
            miComando.CommandText = "IdiomaConsultar";
            miComando.Parameters.AddWithValue("@Idioma_id", SqlDbType.Int);
            miComando.Parameters["@Idioma_id"].Value = Idioma_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable IdiomaListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor IdiomaListarA");

            miComando.CommandText = "IdiomaListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable IdiomaListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor IdiomaListarI");

            miComando.CommandText = "IdiomaListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet IdiomaActivar(int Idioma_id)
        {
            miComando.CommandText = "IdiomaActivar";
            miComando.Parameters.AddWithValue("@Idioma_id", SqlDbType.Int);
            miComando.Parameters["@Idioma_id"].Value = Idioma_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet IdiomaInactivar(int Idioma_id)
        {
            miComando.CommandText = "IdiomaInactivar";
            miComando.Parameters.AddWithValue("@Idioma_id", SqlDbType.Int);
            miComando.Parameters["@Idioma_id"].Value = Idioma_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet IdiomaEliminar(int Idioma_id)
        {
            miComando.CommandText = "IdiomaEliminar";
            miComando.Parameters.AddWithValue("@Idioma_id", SqlDbType.Int);
            miComando.Parameters["@Idioma_id"].Value = Idioma_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }
    }
}
