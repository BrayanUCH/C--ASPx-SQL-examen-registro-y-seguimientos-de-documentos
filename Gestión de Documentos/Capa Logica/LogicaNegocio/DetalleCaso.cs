using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class DetalleCaso
    {

        protected int detalleCaso_id;
        protected int caso_id;
        protected int ciclo_id;
        protected int documento_id;
        protected DateTime detalleCaso_fechaRecibido;
        protected DateTime detalleCaso_fechaTranspaso;
        protected string detalleCaso_descripcion;
        protected string detalleCaso_estado;

        public DetalleCaso()
        {

        }

        public DetalleCaso(int detalleCaso_id, int caso_id, int ciclo_id, int documento_id, DateTime detalleCaso_fechaRecibido, DateTime detalleCaso_fechaTranspaso, string detalleCaso_descripcion, string detalleCaso_estado)
        {
            this.detalleCaso_id = detalleCaso_id;
            this.caso_id = caso_id;
            this.ciclo_id = ciclo_id;
            this.documento_id = documento_id;
            this.detalleCaso_fechaRecibido = detalleCaso_fechaRecibido;
            this.detalleCaso_fechaTranspaso = detalleCaso_fechaTranspaso;
            this.detalleCaso_descripcion = detalleCaso_descripcion;
            this.detalleCaso_estado = detalleCaso_estado;
        }
        public DetalleCaso( int caso_id, int ciclo_id, int documento_id, DateTime detalleCaso_fechaRecibido, DateTime detalleCaso_fechaTranspaso, string detalleCaso_descripcion, string detalleCaso_estado)
        {
            this.detalleCaso_id = 0;
            this.caso_id = caso_id;
            this.ciclo_id = ciclo_id;
            this.documento_id = documento_id;
            this.detalleCaso_fechaRecibido = detalleCaso_fechaRecibido;
            this.detalleCaso_fechaTranspaso = detalleCaso_fechaTranspaso;
            this.detalleCaso_descripcion = detalleCaso_descripcion;
            this.detalleCaso_estado = detalleCaso_estado;
        }

        public int DetalleCaso_id { get => detalleCaso_id; set => detalleCaso_id = value; }
        public int Caso_id { get => caso_id; set => caso_id = value; }
        public int Ciclo_id { get => ciclo_id; set => ciclo_id = value; }
        public int Documento_id { get => documento_id; set => documento_id = value; }
        public DateTime DetalleCaso_fechaRecibido { get => detalleCaso_fechaRecibido; set => detalleCaso_fechaRecibido = value; }
        public DateTime DetalleCaso_fechaTranspaso { get => detalleCaso_fechaTranspaso; set => detalleCaso_fechaTranspaso = value; }
        public string DetalleCaso_descripcion { get => detalleCaso_descripcion; set => detalleCaso_descripcion = value; }
        public string DetalleCaso_estado { get => detalleCaso_estado; set => detalleCaso_estado = value; }
    }
}
