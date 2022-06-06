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
    public class GestorCodigo : servicio, IDisposable
    {
        public GestorCodigo()
        {

        }
        public void Dispose()
        {

        }

        public string CodigoInsertar(int organizacion_id, string codigo_formato, string codigo_estado)
        {
            Codigo nuevo = new Codigo(organizacion_id, codigo_formato, codigo_estado);

            using (ServicioCodigo servicioCL = new ServicioCodigo())
                return servicioCL.CodigoInsertar(nuevo);
        }
        public string CodigoModificar(int codigo_id, int organizacion_id, string codigo_formato, string codigo_estado)
        {
            Codigo modificar = new Codigo(codigo_id, organizacion_id, codigo_formato, codigo_estado);

            using (ServicioCodigo servicioCL = new ServicioCodigo())
                return servicioCL.CodigoModificar(modificar);
        }
        public object CodigoListarA()
        {
            using (ServicioCodigo servicioCL = new ServicioCodigo())
                return servicioCL.CodigoListarA();
        }
        public object CodigoListarI()
        {
            using (ServicioCodigo servicioCL = new ServicioCodigo())
                return servicioCL.CodigoListarI();
        }
        public DataSet CodigoConsultar(int codigo_id)
        {
            using (ServicioCodigo servicioCL = new ServicioCodigo())
            {
                return servicioCL.CodigoConsultar(codigo_id);
            }
        }
        public DataSet CodigoActivar(int codigo_id)
        {
            using (ServicioCodigo servicioCL = new ServicioCodigo())
            {
                return servicioCL.CodigoActivar(codigo_id);
            }
        }
        public DataSet CodigoInactivar(int codigo_id)
        {
            using (ServicioCodigo servicioCL = new ServicioCodigo())
            {
                return servicioCL.CodigoInactivar(codigo_id);
            }
        }







    }
}
