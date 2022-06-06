using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Tramite
    {
        protected int tramite_id;
        protected string tramite_nombre;
        protected string tramite_descripcion;
        protected string tramite_estado;

        public Tramite()
        { 
        
        }
            public Tramite(string tramite_nombre, string tramite_descripcion, string tramite_estado)
        {
            this.tramite_id = 0;
            this.tramite_nombre = tramite_nombre;
            this.tramite_descripcion = tramite_descripcion;
            this.tramite_estado = tramite_estado;
        }

        public Tramite(int tramite_id, string tramite_nombre, string tramite_descripcion, string tramite_estado)
        {
            this.tramite_id = tramite_id;
            this.tramite_nombre = tramite_nombre;
            this.tramite_descripcion = tramite_descripcion;
            this.tramite_estado = tramite_estado;
        }

        public int Tramite_id { get => tramite_id; set => tramite_id = value; }
        public string Tramite_nombre { get => tramite_nombre; set => tramite_nombre = value; }
        public string Tramite_descripcion { get => tramite_descripcion; set => tramite_descripcion = value; }
        public string Tramite_estado { get => tramite_estado; set => tramite_estado = value; }
    }
}
