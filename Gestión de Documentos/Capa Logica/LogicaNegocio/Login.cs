using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_registros.Capa_Logica.LogicaNegocio
{
    public class Login
    {
        protected int login_id;
        protected string login_usuario;
        protected string login_contraseña;
        protected string login_correoElectronico;
        protected string login_administrador;
        protected string login_estado;

        public Login()
        { 
        
        }

        public Login(string login_usuario, string login_contraseña, string login_correoElectronico, string login_administrador, string login_estado)
        {
            this.login_id = 0;
            this.login_usuario = login_usuario;
            this.login_contraseña = login_contraseña;
            this.login_correoElectronico = login_correoElectronico;
            this.login_administrador = login_administrador;
            this.login_estado = login_estado;
        }

        public Login(int login_id, string login_usuario, string login_contraseña, string login_correoElectronico, string login_administrador, string login_estado)
        {
            this.login_id = login_id;
            this.login_usuario = login_usuario;
            this.login_contraseña = login_contraseña;
            this.login_correoElectronico = login_correoElectronico;
            this.login_administrador = login_administrador;
            this.login_estado = login_estado;
        }

        public int Login_id { get => login_id; set => login_id = value; }
        public string Login_usuario { get => login_usuario; set => login_usuario = value; }
        public string Login_contraseña { get => login_contraseña; set => login_contraseña = value; }
        public string Login_correoElectronico { get => login_correoElectronico; set => login_correoElectronico = value; }
        public string Login_administrador { get => login_administrador; set => login_administrador = value; }
        public string Login_estado { get => login_estado; set => login_estado = value; }
    }
}
