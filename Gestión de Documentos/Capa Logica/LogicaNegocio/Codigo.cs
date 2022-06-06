using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Codigo
    {
        protected int codigo_id;
        protected int organizacion_id;
        protected string codigo_formato;
        protected string codigo_estado;

        public Codigo()
        {

        }

        public Codigo(int organizacion_id, string codigo_formato, string codigo_estado)
        {
            this.codigo_id = 0;
            this.organizacion_id = organizacion_id;
            this.codigo_formato = codigo_formato;
            this.codigo_estado = codigo_estado;
        }
        public Codigo(int codigo_id, int organizacion_id, string codigo_formato, string codigo_estado)
        {
            this.codigo_id = codigo_id;
            this.organizacion_id = organizacion_id;
            this.codigo_formato = codigo_formato;
            this.codigo_estado = codigo_estado;
        }

        public int Codigo_id { get => codigo_id; set => codigo_id = value; }
        public int Organizacion_id { get => organizacion_id; set => organizacion_id = value; }
        public string Codigo_formato { get => codigo_formato; set => codigo_formato = value; }
        public string Codigo_estado { get => codigo_estado; set => codigo_estado = value; }
    }
}
