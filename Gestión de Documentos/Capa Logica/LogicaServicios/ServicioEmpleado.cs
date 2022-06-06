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
    public class ServicioEmpleado : servicio, IDisposable
    {
        private SqlCommand miComando;
        private String respuesta;

        public void Dispose()
        {

        }

        public ServicioEmpleado()
        {
            respuesta = "";
            miComando = new SqlCommand();
        }

        public string EmpleadoInsertar(Empleado nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor EmpleadoInsertar");

            miComando.CommandText = "EmpleadoInsertar";

            //miComando.Parameters.Add("Empleado_id", SqlDbType.Int);
            //miComando.Parameters["Empleado_id"].Value = nuevo.Empleado_id;

            miComando.Parameters.Add("Departamento_id", SqlDbType.Int);
            miComando.Parameters["Departamento_id"].Value = nuevo.Departamento_id;

            miComando.Parameters.Add("Empleado_nombre", SqlDbType.VarChar);
            miComando.Parameters["Empleado_nombre"].Value = nuevo.Empleado_nombre;

            miComando.Parameters.Add("Empleado_apellidos", SqlDbType.VarChar);
            miComando.Parameters["Empleado_apellidos"].Value = nuevo.Empleado_apellidos;

            miComando.Parameters.Add("Empleado_fechaNacimiento", SqlDbType.Date);
            miComando.Parameters["Empleado_fechaNacimiento"].Value = nuevo.Empleado_fechaNacimiento;

            miComando.Parameters.Add("Empleado_puesto", SqlDbType.VarChar);
            miComando.Parameters["Empleado_puesto"].Value = nuevo.Empleado_puesto;

            miComando.Parameters.Add("Empleado_genero", SqlDbType.VarChar);
            miComando.Parameters["Empleado_genero"].Value = nuevo.Empleado_genero;

            miComando.Parameters.Add("Empleado_estadoCivil", SqlDbType.VarChar);
            miComando.Parameters["Empleado_estadoCivil"].Value = nuevo.Empleado_estadoCivil;

            miComando.Parameters.Add("Empleado_fechaIngreso", SqlDbType.Date);
            miComando.Parameters["Empleado_fechaIngreso"].Value = nuevo.Empleado_fechaIngreso;

            miComando.Parameters.Add("Empleado_estado", SqlDbType.VarChar);
            miComando.Parameters["Empleado_estado"].Value = nuevo.Empleado_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio EmpleadoInsertar");

            return respuesta;
        }

        public string EmpleadoModificar(Empleado nuevo)
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gestor EmpleadoModificar");

            miComando.CommandText = "EmpleadoModificar";

            miComando.Parameters.Add("Empleado_id", SqlDbType.Int);
            miComando.Parameters["Empleado_id"].Value = nuevo.Empleado_id;

            miComando.Parameters.Add("Departamento_id", SqlDbType.Int);
            miComando.Parameters["Departamento_id"].Value = nuevo.Departamento_id;

            miComando.Parameters.Add("Empleado_nombre", SqlDbType.VarChar);
            miComando.Parameters["Empleado_nombre"].Value = nuevo.Empleado_nombre;

            miComando.Parameters.Add("Empleado_apellidos", SqlDbType.VarChar);
            miComando.Parameters["Empleado_apellidos"].Value = nuevo.Empleado_apellidos;

            miComando.Parameters.Add("Empleado_fechaNacimiento", SqlDbType.Date);
            miComando.Parameters["Empleado_fechaNacimiento"].Value = nuevo.Empleado_fechaNacimiento;

            miComando.Parameters.Add("Empleado_puesto", SqlDbType.VarChar);
            miComando.Parameters["Empleado_puesto"].Value = nuevo.Empleado_puesto;

            miComando.Parameters.Add("Empleado_genero", SqlDbType.VarChar);
            miComando.Parameters["Empleado_genero"].Value = nuevo.Empleado_genero;

            miComando.Parameters.Add("Empleado_estadoCivil", SqlDbType.VarChar);
            miComando.Parameters["Empleado_estadoCivil"].Value = nuevo.Empleado_estadoCivil;

            miComando.Parameters.Add("Empleado_fechaIngreso", SqlDbType.Date);
            miComando.Parameters["Empleado_fechaIngreso"].Value = nuevo.Empleado_fechaIngreso;

            miComando.Parameters.Add("Empleado_estado", SqlDbType.VarChar);
            miComando.Parameters["Empleado_estado"].Value = nuevo.Empleado_estado;

            respuesta = this.ejecutaSentencia(miComando);

            if (respuesta == "")
            {
                respuesta += "Se ha realisado carrectamente la transacción";
            }
            Console.WriteLine("Fin Servicio EmpleadoModificar");

            return respuesta;
        }


        public DataSet EmpleadoConsultar(int Empleado_id)
        {
            miComando.CommandText = "EmpleadoConsultar";
            miComando.Parameters.AddWithValue("@Empleado_id", SqlDbType.Int);
            miComando.Parameters["@Empleado_id"].Value = Empleado_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataTable EmpleadoListarA()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor CasoListarA");

            miComando.CommandText = "EmpleadoListarA";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataTable EmpleadoListarI()
        {
            miComando = new SqlCommand();
            Console.WriteLine("Gertor EmpleadoListarI");

            miComando.CommandText = "EmpleadoListarI";

            DataSet midataset = new DataSet();
            this.abrirConexion();

            midataset = this.seleccionarInformacion(miComando);
            DataTable miTabla = midataset.Tables[0];

            return miTabla;
        }

        public DataSet EmpleadoActivar(int Empleado_id)
        {
            miComando.CommandText = "EmpleadoActivar";
            miComando.Parameters.AddWithValue("@Empleado_id", SqlDbType.Int);
            miComando.Parameters["@Empleado_id"].Value = Empleado_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet EmpleadoInactivar(int Empleado_id)
        {
            miComando.CommandText = "EmpleadoInactivar";
            miComando.Parameters.AddWithValue("@Empleado_id", SqlDbType.Int);
            miComando.Parameters["@Empleado_id"].Value = Empleado_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

        public DataSet EmpleadoEliminar(int Empleado_id)
        {
            miComando.CommandText = "EmpleadoEliminar";
            miComando.Parameters.AddWithValue("@Empleado_id", SqlDbType.Int);
            miComando.Parameters["@Empleado_id"].Value = Empleado_id;

            DataSet miDataSet = new DataSet();
            this.abrirConexion();

            miDataSet = this.seleccionarInformacion(miComando);
            this.cerrarConexion();

            return miDataSet;
        }

    }
}
