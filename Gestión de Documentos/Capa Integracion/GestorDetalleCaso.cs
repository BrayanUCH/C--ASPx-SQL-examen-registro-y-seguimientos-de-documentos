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
    public class GestorDetalleCaso : servicio, IDisposable
    {
        public GestorDetalleCaso()
        {

        }
        public void Dispose()
        {

        }
        public string DetalleCasoInsertar(int caso_id, int ciclo_id, int documento_id, DateTime detalleCaso_fechaRecibido, DateTime detalleCaso_fechaTranspaso, string detalleCaso_descripcion, string detalleCaso_estado)
        {
            DetalleCaso nuevo = new DetalleCaso(caso_id, ciclo_id, documento_id, detalleCaso_fechaRecibido, detalleCaso_fechaTranspaso, detalleCaso_descripcion, detalleCaso_estado);

            using (ServicioDetalleCaso servicioCL = new ServicioDetalleCaso())
                return servicioCL.DetalleCasoInsertar(nuevo);
        }
        public string DetalleCasoModificar(int detalleCaso_id, int caso_id, int ciclo_id, int documento_id, DateTime detalleCaso_fechaRecibido, DateTime detalleCaso_fechaTranspaso, string detalleCaso_descripcion, string detalleCaso_estado)
        {
            DetalleCaso modificar = new DetalleCaso(detalleCaso_id, caso_id, ciclo_id, documento_id, detalleCaso_fechaRecibido, detalleCaso_fechaTranspaso, detalleCaso_descripcion, detalleCaso_estado);

            using (ServicioDetalleCaso servicioCL = new ServicioDetalleCaso())
                return servicioCL.DetalleCasoModificar(modificar);
        }
        public object DetalleCasoListarA()
        {
            using (ServicioDetalleCaso servicioCL = new ServicioDetalleCaso())
                return servicioCL.DetalleCasoListarA();
        }
        public object DetalleCasoListarI()
        {
            using (ServicioDetalleCaso servicioCL = new ServicioDetalleCaso())
                return servicioCL.DetalleCasoListarI();
        }
        public DataSet DetalleCasoConsultar(int detalleCaso_id)
        {
            using (ServicioDetalleCaso servicioCL = new ServicioDetalleCaso())
            {
                return servicioCL.DetalleCasoConsultar(detalleCaso_id);
            }
        }
        public DataSet DetalleCasoActivar(int detalleCaso_id)
        {
            using (ServicioDetalleCaso servicioCL = new ServicioDetalleCaso())
            {
                return servicioCL.DetalleCasoActivar(detalleCaso_id);
            }
        }
        public DataSet DetalleCasoInactivar(int detalleCaso_id)
        {
            using (ServicioDetalleCaso servicioCL = new ServicioDetalleCaso())
            {
                return servicioCL.DetalleCasoInactivar(detalleCaso_id);
            }
        }





    }
}
