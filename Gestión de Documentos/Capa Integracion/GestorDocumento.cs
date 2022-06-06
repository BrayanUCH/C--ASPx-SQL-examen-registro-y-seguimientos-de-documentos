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
    public class GestorDocumento : servicio, IDisposable
    {
        public GestorDocumento()
        {

        }
        public void Dispose()
        {

        }

        public string DocumentoInsertar(int tramite_id, int idioma_id, string documento_nombre, string documento_ruta, string documento_tipo, string documento_estado)
        {
            Documento nuevo = new Documento(tramite_id, idioma_id, documento_nombre, documento_ruta, documento_tipo, documento_estado);

            using (ServicioDocumento servicioCL = new ServicioDocumento())
                return servicioCL.DocumentoInsertar(nuevo);
        }
        public string DocumentoModificar(int documento_id, int tramite_id, int idioma_id, string documento_nombre, string documento_ruta, string documento_tipo, string documento_estado)
        {
            Documento modificar = new Documento(documento_id, tramite_id, idioma_id, documento_nombre, documento_ruta, documento_tipo, documento_estado);

            using (ServicioDocumento servicioCL = new ServicioDocumento())
                return servicioCL.DocumentoModificar(modificar);
        }

        public object DocumentoListarA()
        {
            using (ServicioDocumento servicioCL = new ServicioDocumento())
                return servicioCL.DocumentoListarA();
        }
        public object DocumentoListarI()
        {
            using (ServicioDocumento servicioCL = new ServicioDocumento())
                return servicioCL.DocumentoListarI();
        }
        public DataSet DocumentoConsultar(int documento_id)
        {
            using (ServicioDocumento servicioCL = new ServicioDocumento())
            {
                return servicioCL.DocumentoConsultar(documento_id);
            }
        }
        public DataSet DocumentoActivar(int documento_id)
        {
            using (ServicioDocumento servicioCL = new ServicioDocumento())
            {
                return servicioCL.DocumentoActivar(documento_id);
            }
        }
        public DataSet DocumentoInactivar(int documento_id)
        {
            using (ServicioDocumento servicioCL = new ServicioDocumento())
            {
                return servicioCL.DocumentoInactivar(documento_id);
            }
        }
    }
}
