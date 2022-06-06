using Manejo_registros.Capa_Logica.LogicaServicios;
using Manejo_registros.Capa_Logica.LogicaNegocio;
using Manejo_registros.CapaConexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Integracion
{
    public class GestorEmpleado : servicio, IDisposable
    {
        public GestorEmpleado()
        {

        }
        public void Dispose()
        {

        }
        public string EmpleadoInsertar(int departamento_id, string empleado_nombre, string empleado_apellidos, DateTime empleado_fechaNacimiento, string empleado_puesto, string empleado_genero, string empleado_estadoCivil, DateTime empleado_fechaIngreso, string empleado_estado)
        {
            Empleado nuevo = new Empleado(departamento_id, empleado_nombre, empleado_apellidos, empleado_fechaNacimiento, empleado_puesto, empleado_genero, empleado_estadoCivil, empleado_fechaIngreso, empleado_estado);

            using (ServicioEmpleado servicioCL = new ServicioEmpleado())
                return servicioCL.EmpleadoInsertar(nuevo);
        }
        public string EmpleadoModificar(int empleado_id, int departamento_id, string empleado_nombre, string empleado_apellidos, DateTime empleado_fechaNacimiento, string empleado_puesto, string empleado_genero, string empleado_estadoCivil, DateTime empleado_fechaIngreso, string empleado_estado)
        {
            Empleado modificar = new Empleado(empleado_id, departamento_id, empleado_nombre, empleado_apellidos, empleado_fechaNacimiento, empleado_puesto, empleado_genero, empleado_estadoCivil, empleado_fechaIngreso, empleado_estado);

            using (ServicioEmpleado servicioCL = new ServicioEmpleado())
                return servicioCL.EmpleadoModificar(modificar);
        }

        public object EmpleadoListarA()
        {
            using (ServicioEmpleado servicioCL = new ServicioEmpleado())
                return servicioCL.EmpleadoListarA();
        }
        public object EmpleadoListarI()
        {
            using (ServicioEmpleado servicioCL = new ServicioEmpleado())
                return servicioCL.EmpleadoListarI();
        }
        public DataSet EmpleadoConsultar(int empleado_id)
        {
            using (ServicioEmpleado servicioCL = new ServicioEmpleado())
            {
                return servicioCL.EmpleadoConsultar(empleado_id);
            }
        }
        public DataSet EmpleadoActivar(int empleado_id)
        {
            using (ServicioEmpleado servicioCL = new ServicioEmpleado())
            {
                return servicioCL.EmpleadoActivar(empleado_id);
            }
        }
        public DataSet EmpleadoInactivar(int empleado_id)
        {
            using (ServicioEmpleado servicioCL = new ServicioEmpleado())
            {
                return servicioCL.EmpleadoInactivar(empleado_id);
            }
        }











    }
}
