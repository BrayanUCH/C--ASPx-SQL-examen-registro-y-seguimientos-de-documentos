using Manejo_registros.Capa_Logica.LogicaNegocio;
using Manejo_registros.Capa_Logica.LogicaServicios;
using Manejo_registros.CapaConexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Integracion
{
    public class GestorCaso : servicio, IDisposable
    {
        public GestorCaso()
        {

        }
        public void Dispose()
        {

        }
        public string CasoInsertar(int tramite_id, string caso_codigo, DateTime caso_fechaInicio, DateTime caso_fechaFinal, string caso_estado)
        {
            Caso nuevo = new Caso(tramite_id, caso_codigo, caso_fechaInicio, caso_fechaFinal, caso_estado);

            using (ServicioCaso servicioCL = new ServicioCaso())
                return servicioCL.CasoInsertar(nuevo);
        }
        public string CasoModificar(int caso_id, int tramite_id, string caso_codigo, DateTime caso_fechaInicio, DateTime caso_fechaFinal, string caso_estado)
        {
            Caso modificar = new Caso(caso_id, tramite_id, caso_codigo, caso_fechaInicio, caso_fechaFinal, caso_estado);

            using (ServicioCaso servicioCL = new ServicioCaso())
                return servicioCL.CasoModificar(modificar);
        }
        public object CasoListarA()
        {
            using (ServicioCaso servicioCL = new ServicioCaso())
                return servicioCL.CasoListarA();
        }
        public object CasoListarI()
        {
            using (ServicioCaso servicioCL = new ServicioCaso())
                return servicioCL.CasoListarI();
        }
        public DataSet CasoConsultar(int Caso_id)
        {
            using (ServicioCaso servicioCL = new ServicioCaso())
            {
                return servicioCL.CasoConsultar(Caso_id);
            }
        }
        public DataSet CasoActivar(int Caso_id)
        {
            using (ServicioCaso servicioCL = new ServicioCaso())
            {
                return servicioCL.CasoActivar(Caso_id);
            }
        }
        public DataSet CasoInactivar(int Caso_id)
        {
            using (ServicioCaso servicioCL = new ServicioCaso())
            {
                return servicioCL.CasoInactivar(Caso_id);
            }
        }

        public DataSet CasoConsultarCodigo(string Caso_codigo)
        {
            using (ServicioCaso servicioCL = new ServicioCaso())
            {
                return servicioCL.CasoConsultarCodigo(Caso_codigo);
            }
        }





    }
}
