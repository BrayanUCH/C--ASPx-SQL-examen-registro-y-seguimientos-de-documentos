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
    public class GestorDepartamento : servicio, IDisposable
    {
        public GestorDepartamento()
        {

        }
        public void Dispose()
        {

        }
        public string DepartamentoInsertar(int organizacion_id, string departamento_nombre, string departamento_tipo, string departamento_descripcion, string departamento_estado)
        {
            Departamento nuevo = new Departamento(organizacion_id, departamento_nombre, departamento_tipo, departamento_descripcion, departamento_estado);

            using (ServicioDepartamento servicioCL = new ServicioDepartamento())
                return servicioCL.DepartamentoInsertar(nuevo);
        }
        public string DepartamentoModificar(int departamento_id, int organizacion_id, string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            Departamento modificar = new Departamento(departamento_id, organizacion_id, organizacion_nombre, organizacion_tipo, organizacion_descripcion, organizacion_estado);

            using (ServicioDepartamento servicioCL = new ServicioDepartamento())
                return servicioCL.DepartamentoModificar(modificar);
        }
        public object DepartamentoListarA()
        {
            using (ServicioDepartamento servicioCL = new ServicioDepartamento())
                return servicioCL.DepartamentoListarA();
        }
        public object DepartamentoListarI()
        {
            using (ServicioDepartamento servicioCL = new ServicioDepartamento())
                return servicioCL.DepartamentoListarI();
        }
        public DataSet DepartamentoConsultar(int departamento_id)
        {
            using (ServicioDepartamento servicioCL = new ServicioDepartamento())
            {
                return servicioCL.DepartamentoConsultar(departamento_id);
            }
        }
        public DataSet DepartamentoActivar(int departamento_id)
        {
            using (ServicioDepartamento servicioCL = new ServicioDepartamento())
            {
                return servicioCL.DepartamentoActivar(departamento_id);
            }
        }
        public DataSet DepartamentoInactivar(int departamento_id)
        {
            using (ServicioDepartamento servicioCL = new ServicioDepartamento())
            {
                return servicioCL.DepartamentoInactivar(departamento_id);
            }
        }






    }
}
