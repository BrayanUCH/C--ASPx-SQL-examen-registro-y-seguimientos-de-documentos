using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Caso
    {
        protected int caso_id;
        protected int tramite_id;
        protected string caso_codigo;
        protected DateTime caso_fechaInicio;
        protected DateTime caso_fechaFinal;
        protected string caso_estado;

        public Caso()
        {

        }

        public Caso(int tramite_id, string caso_codigo, DateTime caso_fechaInicio, DateTime caso_fechaFinal, string caso_estado)
        {
            this.caso_id = 0;
            this.tramite_id = tramite_id;
            this.caso_codigo = caso_codigo;
            this.caso_fechaInicio = caso_fechaInicio;
            this.caso_fechaFinal = caso_fechaFinal;
            this.caso_estado = caso_estado;
        }

        public Caso(int caso_id, int tramite_id, string caso_codigo, DateTime caso_fechaInicio, DateTime caso_fechaFinal, string caso_estado)
        {
            this.caso_id = caso_id;
            this.tramite_id = tramite_id;
            this.caso_codigo = caso_codigo;
            this.caso_fechaInicio = caso_fechaInicio;
            this.caso_fechaFinal = caso_fechaFinal;
            this.caso_estado = caso_estado;
        }

        public int Caso_id { get => caso_id; set => caso_id = value; }
        public int Tramite_id { get => tramite_id; set => tramite_id = value; }
        public string Caso_codigo { get => caso_codigo; set => caso_codigo = value; }
        public DateTime Caso_fechaInicio { get => caso_fechaInicio; set => caso_fechaInicio = value; }
        public DateTime Caso_fechaFinal { get => caso_fechaFinal; set => caso_fechaFinal = value; }
        public string Caso_estado { get => caso_estado; set => caso_estado = value; }

        
    }
}
