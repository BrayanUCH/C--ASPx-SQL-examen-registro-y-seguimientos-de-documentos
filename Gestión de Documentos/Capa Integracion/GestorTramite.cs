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
    public class GestorTramite : servicio, IDisposable
    {
        public GestorTramite()
        {

        }
        public void Dispose()
        {

        }

        public string TramiteInsertar(string tramite_nombre, string tramite_descripcion, string tramite_estado)
        {
            Tramite nuevo = new Tramite(tramite_nombre, tramite_descripcion, tramite_estado);

            using (ServicioTramite servicioCL = new ServicioTramite())
                return servicioCL.TramiteInsertar(nuevo);
        }
        public string TramiteModificar(int tramite_id, string tramite_nombre, string tramite_descripcion, string tramite_estado)
        {
            Tramite modificar = new Tramite(tramite_id, tramite_nombre, tramite_descripcion, tramite_estado);

            using (ServicioTramite servicioCL = new ServicioTramite())
                return servicioCL.TramiteModificar(modificar);
        }

        public object TramiteListarA()
        {
            using (ServicioTramite servicioCL = new ServicioTramite())
                return servicioCL.TramiteListarA();
        }
        public object TramiteListarI()
        {
            using (ServicioTramite servicioCL = new ServicioTramite())
                return servicioCL.TramiteListarI();
        }
        public DataSet TramiteConsultar(int tramite_id)
        {
            using (ServicioTramite servicioCL = new ServicioTramite())
            {
                return servicioCL.TramiteConsultar(tramite_id);
            }
        }
        public DataSet TramiteActivar(int tramite_id)
        {
            using (ServicioTramite servicioCL = new ServicioTramite())
            {
                return servicioCL.TramiteActivar(tramite_id);
            }
        }
        public DataSet TramiteInactivar(int tramite_id)
        {
            using (ServicioTramite servicioCL = new ServicioTramite())
            {
                return servicioCL.TramiteInactivar(tramite_id);
            }
        }













    }
}
