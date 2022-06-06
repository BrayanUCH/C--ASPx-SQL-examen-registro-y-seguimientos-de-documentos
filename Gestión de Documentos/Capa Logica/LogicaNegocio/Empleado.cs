using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Empleado
    {
        protected int empleado_id;
        protected int departamento_id;
        protected string empleado_nombre;
        protected string empleado_apellidos;
        protected DateTime empleado_fechaNacimiento;
        protected string empleado_puesto;
        protected string empleado_genero;
        protected string empleado_estadoCivil;
        protected DateTime empleado_fechaIngreso;
        protected string empleado_estado;

        public Empleado()
        { 
        
        }

            public Empleado( int departamento_id, string empleado_nombre, string empleado_apellidos, DateTime empleado_fechaNacimiento, string empleado_puesto, string empleado_genero, string empleado_estadoCivil, DateTime empleado_fechaIngreso, string empleado_estado)
        {
            this.empleado_id = 0;
            this.departamento_id = departamento_id;
            this.empleado_nombre = empleado_nombre;
            this.empleado_apellidos = empleado_apellidos;
            this.empleado_fechaNacimiento = empleado_fechaNacimiento;
            this.empleado_puesto = empleado_puesto;
            this.empleado_genero = empleado_genero;
            this.empleado_estadoCivil = empleado_estadoCivil;
            this.empleado_fechaIngreso = empleado_fechaIngreso;
            this.empleado_estado = empleado_estado;
        }

        public Empleado(int empleado_id, int departamento_id, string empleado_nombre, string empleado_apellidos, DateTime empleado_fechaNacimiento, string empleado_puesto, string empleado_genero, string empleado_estadoCivil, DateTime empleado_fechaIngreso, string empleado_estado)
        {
            this.empleado_id = empleado_id;
            this.departamento_id = departamento_id;
            this.empleado_nombre = empleado_nombre;
            this.empleado_apellidos = empleado_apellidos;
            this.empleado_fechaNacimiento = empleado_fechaNacimiento;
            this.empleado_puesto = empleado_puesto;
            this.empleado_genero = empleado_genero;
            this.empleado_estadoCivil = empleado_estadoCivil;
            this.empleado_fechaIngreso = empleado_fechaIngreso;
            this.empleado_estado = empleado_estado;
        }

        public int Empleado_id { get => empleado_id; set => empleado_id = value; }
        public int Departamento_id { get => departamento_id; set => departamento_id = value; }
        public string Empleado_nombre { get => empleado_nombre; set => empleado_nombre = value; }
        public string Empleado_apellidos { get => empleado_apellidos; set => empleado_apellidos = value; }
        public DateTime Empleado_fechaNacimiento { get => empleado_fechaNacimiento; set => empleado_fechaNacimiento = value; }
        public string Empleado_puesto { get => empleado_puesto; set => empleado_puesto = value; }
        public string Empleado_genero { get => empleado_genero; set => empleado_genero = value; }
        public string Empleado_estadoCivil { get => empleado_estadoCivil; set => empleado_estadoCivil = value; }
        public DateTime Empleado_fechaIngreso { get => empleado_fechaIngreso; set => empleado_fechaIngreso = value; }
        public string Empleado_estado { get => empleado_estado; set => empleado_estado = value; }
    }
}
