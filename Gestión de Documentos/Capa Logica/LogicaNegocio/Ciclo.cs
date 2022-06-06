using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Ciclo
    {

        protected int ciclo_id;
        protected int tramite_id;
        protected int departamento_id;
        protected string ciclo_orden;
        protected string ciclo_estado;

        public Ciclo()
        {

        }

        public Ciclo( int tramite_id, int departamento_id, string ciclo_orden, string ciclo_estado)
        {
            this.ciclo_id = 0;
            this.tramite_id = tramite_id;
            this.departamento_id = departamento_id;
            this.ciclo_orden = ciclo_orden;
            this.ciclo_estado = ciclo_estado;
        }

        public Ciclo(int ciclo_id, int tramite_id, int departamento_id, string ciclo_orden, string ciclo_estado)
        {
            this.ciclo_id = ciclo_id;
            this.tramite_id = tramite_id;
            this.departamento_id = departamento_id;
            this.ciclo_orden = ciclo_orden;
            this.ciclo_estado = ciclo_estado;
        }

        public int Ciclo_id { get => ciclo_id; set => ciclo_id = value; }
        public int Tramite_id { get => tramite_id; set => tramite_id = value; }
        public int Departamento_id { get => departamento_id; set => departamento_id = value; }
        public string Ciclo_orden { get => ciclo_orden; set => ciclo_orden = value; }
        public string Ciclo_estado { get => ciclo_estado; set => ciclo_estado = value; }
    }
}
