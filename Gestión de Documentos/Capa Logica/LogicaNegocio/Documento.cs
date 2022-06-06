using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Documento
    {

        protected int documento_id;
        protected int tramite_id;
        protected int idioma_id;
        protected string documento_nombre;
        protected string documento_ruta;
        protected string documento_tipo;
        protected string documento_estado;

        public Documento()
        {

        }

        public Documento( int tramite_id, int idioma_id, string documento_nombre, string documento_ruta, string documento_tipo, string documento_estado)
        {
            this.documento_id = 0;
            this.tramite_id = tramite_id;
            this.idioma_id = idioma_id;
            this.documento_nombre = documento_nombre;
            this.documento_ruta = documento_ruta;
            this.documento_tipo = documento_tipo;
            this.documento_estado = documento_estado;
        }

        public Documento(int documento_id, int tramite_id, int idioma_id, string documento_nombre, string documento_ruta, string documento_tipo, string documento_estado)
        {
            this.documento_id = documento_id;
            this.tramite_id = tramite_id;
            this.idioma_id = idioma_id;
            this.documento_nombre = documento_nombre;
            this.documento_ruta = documento_ruta;
            this.documento_tipo = documento_tipo;
            this.documento_estado = documento_estado;
        }

        public int Documento_id { get => documento_id; set => documento_id = value; }
        public int Tramite_id { get => tramite_id; set => tramite_id = value; }
        public int Idioma_id { get => idioma_id; set => idioma_id = value; }
        public string Documento_nombre { get => documento_nombre; set => documento_nombre = value; }
        public string Documento_ruta { get => documento_ruta; set => documento_ruta = value; }
        public string Documento_tipo { get => documento_tipo; set => documento_tipo = value; }
        public string Documento_estado { get => documento_estado; set => documento_estado = value; }
    }
}
