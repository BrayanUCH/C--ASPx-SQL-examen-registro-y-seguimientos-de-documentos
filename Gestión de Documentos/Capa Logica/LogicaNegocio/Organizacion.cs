using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Organizacion
    {

        protected int organizacion_id;
        protected string organizacion_nombre;
        protected string organizacion_tipo;
        protected string organizacion_descripcion;
        protected string organizacion_estado;
        public Organizacion()
        {

        }
        public Organizacion( string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            Organizacion_id = 0;
            Organizacion_nombre = organizacion_nombre;
            Organizacion_tipo = organizacion_tipo;
            Organizacion_descripcion = organizacion_descripcion;
            Organizacion_estado = organizacion_estado;
        }
        public Organizacion(int organizacion_id, string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            Organizacion_id = organizacion_id;
            Organizacion_nombre = organizacion_nombre;
            Organizacion_tipo = organizacion_tipo;
            Organizacion_descripcion = organizacion_descripcion;
            Organizacion_estado = organizacion_estado;
        }
        public int Organizacion_id { get => organizacion_id; set => organizacion_id = value; }
        public string Organizacion_nombre { get => organizacion_nombre; set => organizacion_nombre = value; }
        public string Organizacion_tipo { get => organizacion_tipo; set => organizacion_tipo = value; }
        public string Organizacion_descripcion { get => organizacion_descripcion; set => organizacion_descripcion = value; }
        public string Organizacion_estado { get => organizacion_estado; set => organizacion_estado = value; }
    }
}
