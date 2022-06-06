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
    public class GestorIdioma : servicio, IDisposable
    {
        public GestorIdioma()
        {

        }
        public void Dispose()
        {

        }

        public string IdiomaInsertar(string idioma_nombre, string idioma_iniciales, string idioma_estado)
        {
            Idioma nuevo = new Idioma(idioma_nombre, idioma_iniciales, idioma_estado);

            using (ServicioIdioma servicioCL = new ServicioIdioma())
                return servicioCL.IdiomaInsertar(nuevo);
        }
        public string IdiomaModificar(int idioma_id, string idioma_nombre, string idioma_iniciales, string idioma_estado)
        {
            Idioma modificar = new Idioma(idioma_id, idioma_nombre, idioma_iniciales, idioma_estado);

            using (ServicioIdioma servicioCL = new ServicioIdioma())
                return servicioCL.IdiomaModificar(modificar);
        }

        public object IdiomaListarA()
        {
            using (ServicioIdioma servicioCL = new ServicioIdioma())
                return servicioCL.IdiomaListarA();
        }
        public object IdiomaListarI()
        {
            using (ServicioIdioma servicioCL = new ServicioIdioma())
                return servicioCL.IdiomaListarI();
        }
        public DataSet IdiomaConsultar(int idioma_id)
        {
            using (ServicioIdioma servicioCL = new ServicioIdioma())
            {
                return servicioCL.IdiomaConsultar(idioma_id);
            }
        }
        public DataSet IdiomaActivar(int idioma_id)
        {
            using (ServicioIdioma servicioCL = new ServicioIdioma())
            {
                return servicioCL.IdiomaActivar(idioma_id);
            }
        }
        public DataSet IdiomaInactivar(int idioma_id)
        {
            using (ServicioIdioma servicioCL = new ServicioIdioma())
            {
                return servicioCL.IdiomaInactivar(idioma_id);
            }
        }






    }
}
