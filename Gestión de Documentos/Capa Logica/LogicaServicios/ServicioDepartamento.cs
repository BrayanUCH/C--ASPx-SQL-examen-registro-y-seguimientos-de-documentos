using Manejo_registros.Capa_Logica.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manejo_registros.CapaConexion;

namespace Manejo_registros.Capa_Logica.LogicaServicios
{
    public class ServicioDepartamento : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioDepartamento()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }

        public string DepartamentoInsertar(Departamento nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor DepartamentoInsertar");

            miComando.CommandText = "DepartamentoInsertar";

            miComando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            miComando.Parameters["Organizacion_id"].Value = nuevo.Organizacion_id;

            miComando.Parameters.Add("Departamento_nombre", SqlDbType.VarChar);
            miComando.Parameters["Departamento_nombre"].Value = nuevo.Departamento_nombre;

            miComando.Parameters.Add("Departamento_tipo", SqlDbType.VarChar);
            miComando.Parameters["Departamento_tipo"].Value = nuevo.Departamento_tipo;

            miComando.Parameters.Add("Departamento_descripcion", SqlDbType.VarChar);
            miComando.Parameters["Departamento_descripcion"].Value = nuevo.Departamento_descripcion;

            miComando.Parameters.Add("Departamento_estado", SqlDbType.VarChar);
            miComando.Parameters["Departamento_estado"].Value = nuevo.Departamento_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio DepartamentoInsertar");

            return respuesta;
        }
        public string DepartamentoModificar(Departamento nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor DepartamentoModificar");

            miComando.CommandText = "DepartamentoModificar";

            miComando.Parameters.Add("Departamento_id", SqlDbType.Int);
            miComando.Parameters["Departamento_id"].Value = nuevo.Departamento_id;

            miComando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            miComando.Parameters["Organizacion_id"].Value = nuevo.Organizacion_id;

            miComando.Parameters.Add("Departamento_nombre", SqlDbType.VarChar);
            miComando.Parameters["Departamento_nombre"].Value = nuevo.Departamento_nombre;

            miComando.Parameters.Add("Departamento_tipo", SqlDbType.VarChar);
            miComando.Parameters["Departamento_tipo"].Value = nuevo.Departamento_tipo;

            miComando.Parameters.Add("Departamento_descripcion", SqlDbType.VarChar);
            miComando.Parameters["Departamento_descripcion"].Value = nuevo.Departamento_descripcion;

            miComando.Parameters.Add("Departamento_estado", SqlDbType.VarChar);
            miComando.Parameters["Departamento_estado"].Value = nuevo.Departamento_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio DepartamentoModificar");

            return respuesta;
        }

        public DataSet DepartamentoConsultar(int Departamento_id)
        {
            miComando.CommandText = "DepartamentoConsultar";
            miComando.Parameters.AddWithValue("@Departamento_id", SqlDbType.Int);
            miComando.Parameters["@Departamento_id"].Value = Departamento_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable DepartamentoListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor DepartamentoListarA");

            miComando.CommandText = "DepartamentoListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable DepartamentoListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor DepartamentoListarI");

            miComando.CommandText = "DepartamentoListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet DepartamentoActivar(int Departamento_id)
        {
            miComando.CommandText = "DepartamentoActivar";
            miComando.Parameters.AddWithValue("@Departamento_id", SqlDbType.Int);
            miComando.Parameters["@Departamento_id"].Value = Departamento_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet DepartamentoInactivar(int Departamento_id)
        {
            miComando.CommandText = "DepartamentoInactivar";
            miComando.Parameters.AddWithValue("@Departamento_id", SqlDbType.Int);
            miComando.Parameters["@Departamento_id"].Value = Departamento_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }


    }
}
