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
    public class GestorOreganizacion : servicio, IDisposable
    {
        public GestorOreganizacion()
        {

        }
        public void Dispose()
        {

        }

        public string OrganizacionInsertar(string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            Organizacion nuevo = new Organizacion(organizacion_nombre, organizacion_tipo, organizacion_descripcion, organizacion_estado);

            using (ServicioOrganizacion servicioCL = new ServicioOrganizacion())
                return servicioCL.OrganizacionInsertar(nuevo);
        }
        public string OrganizacionModificar(int organizacion_id, string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            Organizacion modificar = new Organizacion(organizacion_id, organizacion_nombre, organizacion_tipo, organizacion_descripcion, organizacion_estado);

            using (ServicioOrganizacion servicioCL = new ServicioOrganizacion())
                return servicioCL.OrganizacionModificar(modificar);
        }
        public object OrganizacionListarA()
        {
            using (ServicioOrganizacion servicioCL = new ServicioOrganizacion())
                return servicioCL.OrganizacionListarA();
        }
        public object OrganizacionListarI()
        {
            using (ServicioOrganizacion servicioCL = new ServicioOrganizacion())
                return servicioCL.OrganizacionListarI();
        }
        public DataSet OrganizacionConsultar(int Organizacion_id)
        {
            using (ServicioOrganizacion servicioCL = new ServicioOrganizacion())
            {
                return servicioCL.OrganizacionConsultar(Organizacion_id);
            }
        }
        public DataSet OrganizacionActivar(int Organizacion_id)
        {
            using (ServicioOrganizacion servicioCL = new ServicioOrganizacion())
            {
                return servicioCL.OrganizacionActivar(Organizacion_id);
            }
        }
        public DataSet OrganizacionInactivar(int Organizacion_id)
        {
            using (ServicioOrganizacion servicioCL = new ServicioOrganizacion())
            {
                return servicioCL.OrganizacionInactivar(Organizacion_id);
            }
        }












    }
}
