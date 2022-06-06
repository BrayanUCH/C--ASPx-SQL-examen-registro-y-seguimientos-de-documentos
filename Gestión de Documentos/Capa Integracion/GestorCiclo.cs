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
    public class GestorCiclo : servicio, IDisposable
    {
        public GestorCiclo()
        {

        }
        public void Dispose()
        {

        }

        public string CicloInsertar(int tramite_id, int departamento_id, string ciclo_orden, string ciclo_estado)
        {
            Ciclo nuevo = new Ciclo(tramite_id, departamento_id, ciclo_orden, ciclo_estado);

            using (ServicioCiclo servicioCL = new ServicioCiclo())
                return servicioCL.CicloInsertar(nuevo);
        }
        public string CicloModificar(int ciclo_id, int tramite_id, int departamento_id, string ciclo_orden, string ciclo_estado)
        {
            Ciclo modificar = new Ciclo(ciclo_id, tramite_id, departamento_id, ciclo_orden, ciclo_estado);

            using (ServicioCiclo servicioCL = new ServicioCiclo())
                return servicioCL.CicloModificar(modificar);
        }
        public object CicloListarA()
        {
            using (ServicioCiclo servicioCL = new ServicioCiclo())
                return servicioCL.CicloListarA();
        }
        public object CicloListarI()
        {
            using (ServicioCiclo servicioCL = new ServicioCiclo())
                return servicioCL.CicloListarI();
        }
        public DataSet CicloConsultar(int ciclo_id)
        {
            using (ServicioCiclo servicioCL = new ServicioCiclo())
            {
                return servicioCL.CicloConsultar(ciclo_id);
            }
        }
        public DataSet CicloActivar(int ciclo_id)
        {
            using (ServicioCiclo servicioCL = new ServicioCiclo())
            {
                return servicioCL.CicloActivar(ciclo_id);
            }
        }
        public DataSet CicloInactivar(int ciclo_id)
        {
            using (ServicioCiclo servicioCL = new ServicioCiclo())
            {
                return servicioCL.CicloInactivar(ciclo_id);
            }
        }







    }
}
