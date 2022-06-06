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
    public class ServicioOrganizacion : servicio, IDisposable
    {

        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioOrganizacion()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }


        public string OrganizacionInsertar(Organizacion nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Servicio OrganizacionInsertar");

            miComando.CommandText = "OrganizacionInsertar";

            miComando.Parameters.Add("Organizacion_nombre", SqlDbType.VarChar);
            miComando.Parameters["Organizacion_nombre"].Value = nuevo.Organizacion_nombre;

            miComando.Parameters.Add("Organizacion_tipo", SqlDbType.VarChar);
            miComando.Parameters["Organizacion_tipo"].Value = nuevo.Organizacion_tipo;

            miComando.Parameters.Add("Organizacion_descripcion", SqlDbType.VarChar);
            miComando.Parameters["Organizacion_descripcion"].Value = nuevo.Organizacion_descripcion;

            miComando.Parameters.Add("Organizacion_estado", SqlDbType.VarChar);
            miComando.Parameters["Organizacion_estado"].Value = nuevo.Organizacion_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
                Console.WriteLine("ddddsssssssssssssssssssssssssssssssss");
            }
            else
            {
                Console.WriteLine("ddddddddddddddddddddddddddddddddddddddddddd");
            }
            Console.WriteLine("Fin Servicio OrganizacionInsertar");

            return respuesta;
        }
        public string OrganizacionModificar(Organizacion nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Servicio OrganizacionModificar");

            miComando.CommandText = "OrganizacionModificar";

            miComando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            miComando.Parameters["Organizacion_id"].Value = nuevo.Organizacion_id;

            miComando.Parameters.Add("Organizacion_nombre", SqlDbType.VarChar);
            miComando.Parameters["Organizacion_nombre"].Value = nuevo.Organizacion_nombre;

            miComando.Parameters.Add("Organizacion_tipo", SqlDbType.VarChar);
            miComando.Parameters["Organizacion_tipo"].Value = nuevo.Organizacion_tipo;

            miComando.Parameters.Add("Organizacion_descripcion", SqlDbType.VarChar);
            miComando.Parameters["Organizacion_descripcion"].Value = nuevo.Organizacion_descripcion;

            miComando.Parameters.Add("Organizacion_estado", SqlDbType.VarChar);
            miComando.Parameters["Organizacion_estado"].Value = nuevo.Organizacion_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio OrganizacionModificar");

            return respuesta;
        }

        public DataSet OrganizacionConsultar(int Organizacion_id)
        {
            miComando.CommandText = "OrganizacionConsultar";
            miComando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
            miComando.Parameters["@Organizacion_id"].Value = Organizacion_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable OrganizacionListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor OrganizacionListarA");

            miComando.CommandText = "OrganizacionListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable OrganizacionListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor OrganizacionListarI");

            miComando.CommandText = "OrganizacionListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet OrganizacionActivar(int Organizacion_id)
        {
            miComando.CommandText = "OrganizacionActivar";
            miComando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
            miComando.Parameters["@Organizacion_id"].Value = Organizacion_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet OrganizacionInactivar(int Organizacion_id)
        {
            miComando.CommandText = "OrganizacionInactivar";
            miComando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
            miComando.Parameters["@Organizacion_id"].Value = Organizacion_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet OrganizacionEliminar(int Organizacion_id)
        {
            miComando.CommandText = "OrganizacionEliminar";
            miComando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
            miComando.Parameters["@Organizacion_id"].Value = Organizacion_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }













    }
}
