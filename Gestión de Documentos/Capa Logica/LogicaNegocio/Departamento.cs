using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Departamento
    {
        protected int departamento_id;
        protected int organizacion_id;
        protected string departamento_nombre;
        protected string departamento_tipo;
        protected string departamento_descripcion;
        protected string departamento_estado;

        public Departamento()
        {

        }

        public Departamento(int organizacion_id, string departamento_nombre, string departamento_tipo, string departamento_descripcion, string departamento_estado)
        {
            this.departamento_id = 0;
            this.organizacion_id = organizacion_id;
            this.departamento_nombre = departamento_nombre;
            this.departamento_tipo = departamento_tipo;
            this.departamento_descripcion = departamento_descripcion;
            this.departamento_estado = departamento_estado;
        }

        public Departamento(int departamento_id, int organizacion_id, string departamento_nombre, string departamento_tipo, string departamento_descripcion, string departamento_estado)
        {
            this.departamento_id = departamento_id;
            this.organizacion_id = organizacion_id;
            this.departamento_nombre = departamento_nombre;
            this.departamento_tipo = departamento_tipo;
            this.departamento_descripcion = departamento_descripcion;
            this.departamento_estado = departamento_estado;
        }     

        public int Departamento_id { get => departamento_id; set => departamento_id = value; }
        public int Organizacion_id { get => organizacion_id; set => organizacion_id = value; }
        public string Departamento_nombre { get => departamento_nombre; set => departamento_nombre = value; }
        public string Departamento_tipo { get => departamento_tipo; set => departamento_tipo = value; }
        public string Departamento_descripcion { get => departamento_descripcion; set => departamento_descripcion = value; }
        public string Departamento_estado { get => departamento_estado; set => departamento_estado = value; }
    }
}
