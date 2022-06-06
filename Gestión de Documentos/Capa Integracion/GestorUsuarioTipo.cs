using Capa_Logica.LogicaNegocio;
using Capa_Logica.LogicaServicios;
using Manejo_registros.CapaConexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Integracion
{
    public class GestorUsuarioTipo : servicio, IDisposable
    {

        public GestorUsuarioTipo()
        {

        }
        public void Dispose()
        {

        }
        public string UsuarioInsertar(int usuario_id, string usuario_tipo)
        {
            UsuarioTipo nuevo = new UsuarioTipo(usuario_id, usuario_tipo);

            using (ServicioUsuarioTipo servicioCL = new ServicioUsuarioTipo())
                return servicioCL.UsuarioInsertar(nuevo);
        }

        public string UsuarioModificar(int usuario_id, string usuario_tipo)
        {
            UsuarioTipo nuevo = new UsuarioTipo(usuario_id, usuario_tipo);

            using (ServicioUsuarioTipo servicioCL = new ServicioUsuarioTipo())
                return servicioCL.UsuarioModificar(nuevo);
        }

        public DataSet usuarioConsultar(int usuario_id)
        {
            using (ServicioUsuarioTipo servicioCL = new ServicioUsuarioTipo())
            {
                return servicioCL.UsuarioTipoConsultar(usuario_id);
            }
        }
    }
}
