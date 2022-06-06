using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.CapaConexion
{
    public class servicio
    {
        private SqlConnection conexion;

        public servicio()
        {
            //    conexion = new SqlConnection(@"user=BRAYANUCH\BRAYAN; password=validpassword; server=BRAYANUCH; 
            //                                    TRUSTED_Connection=yes; database=Manejo_registros; connection timeout=30");

            conexion = new SqlConnection(@"Server=(local);DataBase= Manejo_registros; integrated security= true");

            //conexion = new SqlConnection(@"user=LAPTOP-155E316T\Brandon; password=validpassword; server=LAPTOP-155E316T; 
            //                                TRUSTED_Connection=yes; database=Manejo_registros; connection timeout=30");
        }

        protected void abrirConexion()
        {
            conexion.Open();
        }

        protected void cerrarConexion()
        {
            conexion.Close();
        }

        protected string ejecutaSentencia(String sentencia)
        {
            SqlCommand comando = new SqlCommand(sentencia, conexion);
            try
            {
                this.abrirConexion();
                comando.ExecuteScalar();
            }
            catch (Exception e)
            {
                this.cerrarConexion();
                return e.Message;
            }

            this.cerrarConexion();

            return "";
        }

        protected string ejecutaSentencia(SqlCommand miComando)
        {
            miComando.Connection = conexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandTimeout = 6000;

            try
            {
                this.abrirConexion();
                miComando.ExecuteScalar();
            }
            catch (Exception e)
            {
                this.cerrarConexion();
                return e.Message;
            }
            this.cerrarConexion();

            return "";
        }

        protected DataSet seleccionarInformacion(string sentencia)
        {
            DataSet miDataSet = new DataSet();
            SqlCommand miSqlCommand = conexion.CreateCommand();

            miSqlCommand.CommandText = sentencia;
            SqlDataAdapter miSqlDataAdapter = new SqlDataAdapter();

            miSqlDataAdapter.SelectCommand = miSqlCommand;
            miSqlDataAdapter.Fill(miDataSet);

            return miDataSet;
        }

        protected DataSet seleccionarInformacion(SqlCommand miComando)
        {
            DataSet miDataSet = new DataSet();
            SqlDataAdapter miSqlAdapter = new SqlDataAdapter();

            miComando.CommandTimeout = 2000;
            miComando.Connection = conexion;

            miComando.CommandType = CommandType.StoredProcedure;
            miSqlAdapter.SelectCommand = miComando;
            miSqlAdapter.Fill(miDataSet);

            return miDataSet;
        }
    }
}
